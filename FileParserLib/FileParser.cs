using System.Collections;
using System.Text.Json;
using System.IO;
using FileParserLib;

public class FileParser : IFileParser
{
    private readonly FileReader _reader = new FileReader();
    public async Task<IEnumerable<string[]>> ParseContentAsync(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("File name cannot be null or empty.", nameof(fileName));

        var extension = Path.GetExtension(fileName)?.ToLower();
        if (string.IsNullOrEmpty(extension))
            throw new NotSupportedException("File has no extension.");

        var rawData = await _reader.ReadAllAsync(fileName);

        return extension switch
        {
            ".json" => ParseHelper.ParseJson(rawData),
            ".csv"  => ParseHelper.ParseCsv(rawData),
            ".txt"  => ParseHelper.ParseTxt(rawData),
            _       => throw new NotSupportedException($"Filetype: {extension} not supported for parsing.")
        };
    }
}