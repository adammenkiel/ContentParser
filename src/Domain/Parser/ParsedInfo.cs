using System.Text.Json;

public class ParsedInfo(JsonDocument JsonContent, int Count)
{
    public JsonDocument JsonContent { get; } = JsonContent;
    public int Count { get; } = Count;

    public string GetContentString()
    {
        return JsonSerializer.Serialize(JsonContent);
    }
}