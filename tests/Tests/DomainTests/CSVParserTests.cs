using System.Text.Json;
using Domain.Error;
using Domain.Parser;
using Domain.Parser.Parsers;

namespace Tests.DomainTests;

public class CSVParserTests
{
    [Fact]
    public void CorrectCSVParseTest()
    {
        //Arrange
        CSVParser sut = new();
        string input = "a,b,c\n1,2,3\n4,5,6\n7,8,9";
        string expectedResult = """[{"a":"1","b":"2","c":"3"},{"a":"4","b":"5","c":"6"},{"a":"7","b":"8","c":"9"}]""";

        //Act
        ParsedInfo info = sut.Parse(input);

        //Assert
        Assert.Equal(info.GetContentString(), expectedResult);        
    }

    /*
        Tests below checks if injecting " in CSV cell name is possible,
        if yes, that may cause some problems, in edge case Json injection may be possible
    */
    [Fact]
    public void CSVInjectionFirstTest()
    {
        //Arrange
        CSVParser sut = new();
        string input = "a,b,c\n1,2,3\"\n4,5,6\n7,8,9";

        //Act & Assert
        Assert.Throws<ParseException>(() => {
            sut.Parse(input);
        });
    }
        
    [Fact]
    public void CSVInjectionSecondTest()
    {
        //Arrange
        CSVParser sut = new();
        string input = "a,b,c\n1,2,3\\\"\n4,5,6\n7,8,9";

        //Act & Assert
        Assert.Throws<ParseException>(() => {
            sut.Parse(input);
        });
    }
}
