
using System.Text.Json;

public class JsonParser : IParser
{
    public ParsedInfo Parse(string content)
    {
        try {
            var JsonOptions = new JsonDocumentOptions
            {
              MaxDepth = 256  // Move into configuration
            };
            JsonDocument Document = JsonDocument.Parse(content, JsonOptions);

            //Count Document

            return new ParsedInfo(
                Document,
                0
            );
        } catch
        {
            throw new ParseException();
        }
    }
}