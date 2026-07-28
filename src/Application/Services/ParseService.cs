
using System.Text;
using Application.Configuration;
using Application.Error;
using Application.Registry;
using Domain.Parser;

namespace Application.Services;

public class ParseService(ParserRegistry registry, AppConfiguration configuration)
{

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
        IParser parser = registry.GetParser(ContentType);
        return parser.Parse(DecodedContent);
    }
}