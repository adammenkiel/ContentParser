using System.Text.Json;

namespace Domain.Parser;
// JsonDocument require dispose execution so ParsedInfo is IDisposable!
public class ParsedInfo(JsonDocument jsonContent, int count) : IDisposable
{
    public JsonDocument JsonContent { get; } = jsonContent;
    public int Count { get; } = count;

    public string GetContentString()
    {
        return JsonSerializer.Serialize(JsonContent);
    }

    public void Dispose()
    {
        JsonContent?.Dispose();
    }
}