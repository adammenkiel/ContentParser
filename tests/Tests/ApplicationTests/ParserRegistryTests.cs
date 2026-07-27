
using Xunit.Sdk;

public class ParserRegistryTests()
{

    public AppConfiguration GetAppConfiguration()
    {
        AppConfiguration appConfiguration = new AppConfiguration();
        return appConfiguration;
    }

    [Fact]
    public void ChooseCorrectParserTest()
    {
        //Arrange
        ParserRegistry sut = new(GetAppConfiguration());

        //Act
        IParser parser = sut.GetParser("INTERNAL_JSON");

        //Assert
        Assert.IsType<JsonParser>(parser);
    } 
    
    [Fact]
    public void ChooseIncorrectParserTest()
    {
        //Arrange
        ParserRegistry sut = new(GetAppConfiguration());

        //Act & Assert
        Assert.Throws<ArgumentException>(
            () => sut.GetParser("____TYPE_NOT_EXISTS____")
        );
    } 
}