
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
        string RawExampleContent = """
            {"text": "Hello World"}
        """;

        string EncodedExampleContext = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(RawExampleContent)
        );

        AppConfiguration appConfiguration = new()
        {
            MaxContentSize = EncodedExampleContext.Length - 1
        };
        ParserRegistry registry = new(appConfiguration);
        ParseService sut = new(registry, appConfiguration);

        //Act & Assert
        Assert.Throws<MaxContentLengthException>(() => 
            sut.ParseEncodedContent("INTERNAL_JSON", EncodedExampleContext)
        );  
    }

    [Fact]
    public void CorrectContextLengthTest()
    {
        //Arrange
        string RawExampleContent = """
            {"text": "Hello World"}
        """;

        string EncodedExampleContext = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(RawExampleContent)
        );

        AppConfiguration appConfiguration = new()
        {
            MaxContentSize = EncodedExampleContext.Length
        };
        ParserRegistry registry = new(appConfiguration);
        ParseService sut = new(registry, appConfiguration);


        //Act & Assert
        Assert.IsType<ParsedInfo>(sut.ParseEncodedContent("INTERNAL_JSON", EncodedExampleContext)); 
    }

    [Fact]
    public void DisabledConfigurationOfMaxLengthContentTest()
    {
        //Arrange
        string RawExampleContent = """
            {"text": "Hello World"}
        """;

        string EncodedExampleContext = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(RawExampleContent)
        );

        AppConfiguration appConfiguration = new()
        {
            MaxContentSize = -1
        };
        ParserRegistry registry = new(appConfiguration);
        ParseService sut = new(registry, appConfiguration);

        //Act & Assert
        Assert.IsType<ParsedInfo>(sut.ParseEncodedContent("INTERNAL_JSON", EncodedExampleContext));         
    }
}