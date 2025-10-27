using System.Text.Json;

public static class ParseHelper
{
    public static IEnumerable<string[]> ParseJson(string rawData)
    {
        using var doc = JsonDocument.Parse(rawData);
        return FlattenJsonElement(doc.RootElement);
    }
}