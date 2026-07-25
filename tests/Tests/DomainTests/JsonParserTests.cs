
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

    
    // TODO: Correct it
    [Fact]
    public void ParseLongJsonTest() 
    {
        //Arrange
        JsonParser sut = new();
        string LongJson = "{\"text\": \"Example Json\"}";
        for(int i = 0; i < 1000; i++)
        {
            LongJson = "{\"List\":[" + LongJson + "]}";
        }
        
        //Act & Assert
        Assert.Throws<ParseException>(() => { 
            // I need to correct it, StackOverflowException/Max Depth Exception detection
            // is required because of execution time!
            sut.Parse(LongJson);
        });
    }
}