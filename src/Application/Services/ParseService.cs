
using System.Text;

public class ParseService(ParserRegistry Registry, AppConfiguration configuration)
{
    private readonly ParserRegistry Registry = Registry;

    public ParsedInfo ParseEncodedContent(string ContentType, string Content)
    {
        if(
            configuration.MaxContentSize >= 0 &&
            Content.Length > configuration.MaxContentSize
        )
        {
            throw new MaxContentLengthException("Content is too long!");
        } 
        byte[] EncodedContextBytes = Convert.FromBase64String(Content);
        string EncodedString = Encoding.UTF8.GetString(EncodedContextBytes);
        return ParseDecodedContent(ContentType, EncodedString);
    }

    private ParsedInfo ParseDecodedContent(string ContentType, string DecodedContent)
    {
        IParser parser = Registry.GetParser(ContentType);
        return parser.Parse(DecodedContent);
    }
}