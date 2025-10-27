using System.Text.Json;
using System.Text.Json.Nodes;

public static class ParseHelper
{
    public static IEnumerable<string[]> ParseJson(string rawData)
    {
        using var doc = JsonDocument.Parse(rawData);
        return FlattenJsonElement(doc.RootElement);
    }

    public static IEnumerable<string[]> FlattenJsonElement(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            var objValues = new List<string>();

            foreach (var prop in element.EnumerateObject())
            {
                objValues.Add($"{prop.Name}: {prop.Value}");
            }

            yield return objValues.ToArray();
            yield break;
        }

        if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in element.EnumerateArray())
            {
                foreach (var sub in FlattenJsonElement(item))
                    yield return sub;
            }
            
            yield break;
        }

        yield return new[] { element.ToString() };
    }
}