using System.Text.Json;

namespace Domain.Parser;
// JsonDocument require dispose execution so ParsedInfo is IDisposable!
public class ParsedInfo(JsonDocument JsonContent, int Count) : IDisposable
{
    public JsonDocument JsonContent { get; } = JsonContent;
    public int Count { get; } = Count;

    public string GetContentString()
    {
        return JsonSerializer.Serialize(JsonContent);
    }

    public void Dispose()
    {
        JsonContent?.Dispose();
    }
}