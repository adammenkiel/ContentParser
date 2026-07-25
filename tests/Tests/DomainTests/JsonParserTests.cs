
using System.Text.Json;

public class JsonParserTests
{
    [Fact]
    public void ParseJsonTest()
    {
        //Arrange
        JsonParser sut = new();

        //Act
        sut.Parse("{\"text\": \"Hello World\"}")
        .JsonContent
        .RootElement
        .TryGetProperty("text", out JsonElement jsonElement);
        
        //Assert
        Assert.Equal("Hello World", jsonElement.GetString());
    }

    [Fact]
    public void ParseInvaildJsonTest()
    {
        //Arrange
        JsonParser sut = new();
        
        //Act & Assert
        Assert.Throws<ParseException>(() => {
            sut.Parse("NOT JSON$u%#@{}{}{}}}}}{{{{{}}}}}");
        });
    }

    /*
    [Fact]
    public void ParseLongJsonTest() // TODO: End it
    {
        //Arrange
        JsonParser sut = new();
        string LongJson = "{\"text\": \"Example Json\"}";
        for(int i = 0; i < 100000; i++)
        {
            LongJson = "{\"List\":[" + LongJson + "]}";
        }
        Console.WriteLine("Start");
        
        //Act
        sut.Parse(LongJson);
        Console.WriteLine("End");
    }*/
}