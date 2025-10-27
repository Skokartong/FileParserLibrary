using System.Collections;
using System.Text.Json;
using FileParserLib;

public class FileParser : IFileParser
{
    private readonly FileReader _reader = new FileReader();
    public async Task<IEnumerable<string[]>> ParseContentAsync(string fileName)
    {
        var extension = Path.GetExtension(fileName).ToLower();
        var rawData = _reader.ReadAllAsync(fileName);

        switch (extension)
        {
            case ".json":
                return new List<string[]>();
            case ".csv":
                return new List<string[]>();
            case ".txt":
                return new List<string[]>();
            case ".docx":
                return new List<string[]>();
            case ".odt":
                return new List<string[]>();
            default:
                throw new NotSupportedException($"Filetype: {extension} not supported for parsing.");
        }
    }
}