using System.Text.Json;

public class CSVParserTests
{
    [Fact]
    public void CorrectCSVParseTest()
    {
        //Arrange
        CSVParser sut = new();
        string input = "a,b,c\n1,2,3\n4,5,6\n7,8,9";
        string ExceptedResult = """[{"a":"1","b":"2","c":"3"},{"a":"4","b":"5","c":"6"},{"a":"7","b":"8","c":"9"}]""";

        //Act
        ParsedInfo info = sut.parse(input);

        //Assert
        Assert.Equal(JsonSerializer.Serialize(info.JsonContent), ExceptedResult);        
    }
}