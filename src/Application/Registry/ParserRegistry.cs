
using Application.Configuration;
using Domain.Parser;
using Domain.Parser.Parsers;

namespace Application.Registry;
public class ParserRegistry
{
    private readonly AppConfiguration _configuration;
    private readonly Dictionary<ParserType, IParser> _parsers = [];

    /*
        These parsers are just functions 
        and don't changes states as the assumed so these classes are singletons
    */
    private void LoadParsers()
    {
        _parsers.Add(ParserType.CSV, new CSVParser());
        _parsers.Add(ParserType.INTERNAL_JSON, new JsonParser(_configuration.MaxDepth));
    }
    
    public ParserRegistry(AppConfiguration configuration)
    {
        this._configuration = configuration;
        LoadParsers();
    }

    public IParser GetParser(ParserType Type)
    {
        if(!_parsers.TryGetValue(Type, out IParser? value))
            throw new KeyNotFoundException("This type of parser not found");
        return value;
    }

    public IParser GetParser(string NameOfType)
    {
       return GetParser(Enum.Parse<ParserType>(NameOfType));
    }

}