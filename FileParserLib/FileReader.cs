using FileParserLib;

public class FileReader : IFileReader
{
    public async Task<string[]> ReadAllAsync(string fileName)
    {
        // Combine is used to get full path, as hardcoding it might cause issues
        // on different OS with finding it
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        if (!File.Exists(fullPath))
            throw new FileNotFoundException($"No file found at path: {fullPath}");

        var readContent = await File.ReadAllLinesAsync(fullPath);

        if (readContent.Length == 0)
            throw new Exception("The file contains no content");

        return readContent;
    }
}
