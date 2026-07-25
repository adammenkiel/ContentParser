
using System.Text.Json;

public class JsonParserTests
{
    [Fact]
    public void ParseJsonTest()
    {
        JsonParser jsonParser = new();
        ParsedInfo parsed = jsonParser.parse("{\"text\": \"Hello world\"}");
        var RootElement = parsed.JsonContent.RootElement;
        RootElement.TryGetProperty("text", out JsonElement jsonElement);
        Console.WriteLine(jsonElement.GetString());
    }

    [Fact]
    public void ParseInvaildJsonTest()
    {
        
    }
}