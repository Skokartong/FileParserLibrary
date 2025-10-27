using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public static class ParseHelper
{
    public static IEnumerable<string[]> ParseJson(string rawData)
    {
        using var doc = JsonDocument.Parse(rawData);
        return FlattenJsonElement(doc.RootElement).ToList();
    }

    private static IEnumerable<string[]> FlattenJsonElement(JsonElement element)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                var objValues = element.EnumerateObject()
                                       .Select(prop => $"{prop.Name}: {prop.Value}")
                                       .ToArray();
                yield return objValues;
                yield break;

            case JsonValueKind.Array:
                foreach (var item in element.EnumerateArray())
                {
                    foreach (var sub in FlattenJsonElement(item))
                        yield return sub;
                }
                yield break;

            default:
                yield return new[] { element.ToString() };
                yield break;
        }
    }

    public static IEnumerable<string[]> ParseCsv(string rawData)
    {
        var lines = rawData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            yield return line.Split(',')
                             .Select(cell => cell.Trim())
                             .ToArray();
        }
    }

    public static IEnumerable<string[]> ParseTxt(string rawData)
    {
        var lines = rawData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            yield return new[] { line.Trim() };
        }
    }
}
