using System.Text.Json;

public class ParsedInfo
{
    public JsonDocument JsonContent { get; }
    public int count { get; }

    public ParsedInfo(JsonDocument JsonContent, int count)
    {
        this.JsonContent = JsonContent;
        this.count = count;
    }
}