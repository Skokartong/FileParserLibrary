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
                var parseJson = await JsonSerializer.DeserializeAsync<string[]>(rawData);
                break;
            case ".csv":
                break;
            case ".txt":
                break;
            case ".docx":
                break;
            case ".odt":
                break;
        }
    }
}