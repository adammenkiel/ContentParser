
public class ParseResponse
{
    public bool Status { get; } = true;
    public int Count { get; } = 0;
    public string EncodedContext { get; } = string.Empty;

    public ParseResponse(int Count, string EncodedContext)
    {
        this.Count = Count;
        this.EncodedContext = EncodedContext;
    }
}