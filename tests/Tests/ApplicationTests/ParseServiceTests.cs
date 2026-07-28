
using System.Text;
using Application.Configuration;
using Application.Error;
using Application.Registry;
using Application.Services;
using Domain.Parser;

namespace Tests.ApplicationTests;
public class ParseServiceTests
{
    [Fact]
    public void TooLongContentTest()
    {
        //Arrange
        string rawExampleContent = """
            {"text": "Hello World"}
        """;

        string encodedExampleContext = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(rawExampleContent)
        );

        AppConfiguration appConfiguration = new()
        {
            MaxContentSize = encodedExampleContext.Length - 1
        };
        ParserRegistry registry = new(appConfiguration);
        ParseService sut = new(registry, appConfiguration);

        //Act & Assert
        Assert.Throws<MaxContentLengthException>(() => 
            sut.ParseEncodedContent("INTERNAL_JSON", encodedExampleContext)
        );  
    }

    [Fact]
    public void CorrectContextLengthTest()
    {
        //Arrange
        string rawExampleContent = """
            {"text": "Hello World"}
        """;

        string encodedExampleContext = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(rawExampleContent)
        );

        AppConfiguration appConfiguration = new()
        {
            MaxContentSize = encodedExampleContext.Length
        };
        ParserRegistry registry = new(appConfiguration);
        ParseService sut = new(registry, appConfiguration);


        //Act & Assert
        Assert.IsType<ParsedInfo>(sut.ParseEncodedContent("INTERNAL_JSON", encodedExampleContext)); 
    }

    [Fact]
    public void DisabledConfigurationOfMaxLengthContentTest()
    {
        //Arrange
        string rawExampleContent = """
            {"text": "Hello World"}
        """;

        string encodedExampleContext = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(rawExampleContent)
        );

        AppConfiguration appConfiguration = new()
        {
            MaxContentSize = -1
        };
        ParserRegistry registry = new(appConfiguration);
        ParseService sut = new(registry, appConfiguration);

        //Act & Assert
        Assert.IsType<ParsedInfo>(sut.ParseEncodedContent("INTERNAL_JSON", encodedExampleContext));         
    }
}