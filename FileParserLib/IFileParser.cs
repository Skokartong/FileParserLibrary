namespace FileParserLib;
// <summary>
// This parser structures the data into more meaningful content and interprets it
// </summary>
public interface IFileParser
{
    IEnumerable<string[]> ParseContent(string fileContent);
}
