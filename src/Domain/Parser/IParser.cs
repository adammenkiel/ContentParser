namespace Domain.Parser;
public interface IParser
{
    public ParsedInfo Parse(string text);
}