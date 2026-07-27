
public class ParserRegistry
{
    private AppConfiguration Configuration;
    private Dictionary<ParserType, IParser> Parsers = new Dictionary<ParserType, IParser>();

    private void LoadParsers()
    {
        Parsers.Add(ParserType.CSV, new CSVParser());
        Parsers.Add(ParserType.INTERNAL_JSON, new JsonParser(Configuration.MaxDepth));
    }
    
    public ParserRegistry(AppConfiguration Configuration)
    {
        this.Configuration = Configuration;
        LoadParsers();
    }

    public IParser GetParser(ParserType Type)
    {
        if(!Parsers.TryGetValue(Type, out IParser? value))
            throw new KeyNotFoundException("This type of parser not found");
        return value;
    }

    public IParser GetParser(string NameOfType)
    {
       return GetParser(Enum.Parse<ParserType>(NameOfType));
    }

}