
public class ParserRegistryTests()
{
    [Fact]
    public void ChooseCorrectParserTest()
    {
        //Arrange
        ParserRegistry sut = new();

        //Act
        IParser parser = sut.GetParser("INTERNAL_JSON");

        //Assert
        Assert.IsType<JsonParser>(parser);
    } 
    
    [Fact]
    public void ChooseIncorrectParserTest()
    {
        //Arrange
        ParserRegistry sut = new();

        //Act & Assert
        Assert.Throws<ArgumentException>(
            () => sut.GetParser("____TYPE_NOT_EXISTS____")
        );
    } 
}