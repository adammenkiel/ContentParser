
using System.Text.Json;

public interface IParser
{
    public ParsedInfo parse(string text);
}