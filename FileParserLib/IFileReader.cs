namespace FileParserLib;
// SUMMARY: 
// This FileReader reads in the content from the file without interpreting it
// It returns the raw data from the file it reads from
public interface IFileReader
{
    Task<string> ReadAllAsync(string path);
}

