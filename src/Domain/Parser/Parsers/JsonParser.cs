
using System.Text.Json;

public class JsonParser : IParser
{
    public ParsedInfo parse(string content)
    {
        return new ParsedInfo(
            JsonDocument.Parse(content),
            0
        );
    }
}