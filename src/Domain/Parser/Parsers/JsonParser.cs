
using System.Text.Json;
using Domain.Error;

namespace Domain.Parser.Parsers;

public class JsonParser : IParser
{

    private readonly int _jsonMaxDepth = 256;
    public JsonParser() {}

    public JsonParser(int jsonMaxDepth)
    {
        _jsonMaxDepth = jsonMaxDepth;
    }
    public ParsedInfo Parse(string content)
    {
        try {
            JsonDocument document;
            if(_jsonMaxDepth >= 0) {
                var JsonOptions = new JsonDocumentOptions
                {
                  MaxDepth = _jsonMaxDepth
                };
                document = JsonDocument.Parse(content, JsonOptions);
            }
            else
            {
                document = JsonDocument.Parse(content);    
            }

            /*
                Count method of JSON object isn't strictly defined, also as Json format
                There are also other ways to count JSON objects, for example by DFS algorithm
                It could count every children, but because of practical perspective, I will count
                just elements inside Root array or return 1 if root isn't array, it could be helpful
                for counting for example list of products and other thinks like that.
            */ 
            int count = document.RootElement.ValueKind switch
            {
                JsonValueKind.Array => document.RootElement.GetArrayLength(),
                JsonValueKind.Object => 1,
                _ => 1
            };

            return new ParsedInfo(
                document,
                count
            );
        } catch (Exception exception)
        {
            throw new ParseException(exception.Message, exception);
        }
    }
}