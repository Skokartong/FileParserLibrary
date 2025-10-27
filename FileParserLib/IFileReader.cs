namespace FileParserLib;
// <summary>
// This FileReader reads in the content from the file without interpreting it
// It returns the raw data from the file it reads from
// </summary>
public interface IFileReader
{
    Task<string> ReadAllAsync(string fileName);
}

