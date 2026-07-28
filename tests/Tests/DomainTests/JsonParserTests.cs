
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

    //Two tests below checks if MaxDepth property works
    [Fact]
    public void ParseBelowMaxDepthLimitJsonTest() 
    {
        //Arrange
        JsonParser sut = new(100);
        string LongJson = "{\"text\": \"Example Json\"}";
        for(int i = 0; i < 49; i++)
        {
            LongJson = "{\"List\":[" + LongJson + "]}";
        }
        //Act
        ParsedInfo info = sut.Parse(LongJson);

        //Assert
        Assert.NotNull(info);
    }    

    [Fact]
    public void ParseLongJsonTest() 
    {
        //Arrange
        JsonParser sut = new(100);
        string LongJson = "{\"text\": \"Example Json\"}";
        for(int i = 0; i < 50; i++)
        {
            LongJson = "{\"List\":[" + LongJson + "]}";
        }
        
        //Act & Assert
        Assert.Throws<ParseException>(() => { 
            sut.Parse(LongJson);
        });
    }
}