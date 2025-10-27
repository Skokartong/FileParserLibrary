using System.Collections;
using System.Text.Json;
using System.IO;
using FileParserLib;

public class FileParser : IFileParser
{
    private readonly FileReader _reader = new FileReader();

    private readonly Dictionary<string, Func<string, IEnumerable<string[]>>> _parsers =
    new Dictionary<string, Func<string, IEnumerable<string[]>>>(StringComparer.OrdinalIgnoreCase)
    {
        { ".csv",  ParseHelper.ParseCsv },
        { ".json", ParseHelper.ParseJson },
        { ".txt",  ParseHelper.ParseTxt }
    };

    public async Task<IEnumerable<string[]>> ParseContentAsync(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("File name cannot be null or empty.", nameof(fileName));

        var extension = Path.GetExtension(fileName)?.ToLower();
        if (string.IsNullOrEmpty(extension))
            throw new NotSupportedException("File has no extension.");


        if (!_parsers.TryGetValue(extension, out var parser))
            throw new NotSupportedException($"Filetype: {extension} not supported for parsing.");

        var rawData = await _reader.ReadAllAsync(fileName);
        return parser(rawData);
    }
}