
using System.Text.Json;

public class JsonParser : IParser
{

    private int JsonMaxDepth = 256;
    public JsonParser() {}

    public JsonParser(int JsonMaxDepth)
    {
        this.JsonMaxDepth = JsonMaxDepth;
    }
    public ParsedInfo Parse(string content)
    {
        try {
            var JsonOptions = new JsonDocumentOptions
            {
              MaxDepth = JsonMaxDepth  // Move into configuration
            };
            JsonDocument Document = JsonDocument.Parse(content, JsonOptions);
            /*
                Count method of JSON object isn't strictly defined, also as Json format
                There are also other ways to count JSON objects, for example by DFS algorithm
                It could count every children, but because of practical perspective, I will count
                just elements inside Root array or return 1 if root isn't array, it could be helpful
                for counting for example list of products and other thinks like that.
            */ 
            int Count = Document.RootElement.ValueKind switch
            {
                JsonValueKind.Array => Document.RootElement.GetArrayLength(),
                JsonValueKind.Object => 1,
                _ => 1
            };

            return new ParsedInfo(
                Document,
                Count
            );
        } catch (Exception exception)
        {
            throw new ParseException(exception.Message, exception);
        }
    }
}