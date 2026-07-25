
using System.Text.Json;

public class JsonParser : IParser
{
    public ParsedInfo parse(string content)
    {
        try {
            return new ParsedInfo(
                JsonDocument.Parse(content),
                0
            );
        } catch
        {
            throw new ParseException();
        }
    }
}