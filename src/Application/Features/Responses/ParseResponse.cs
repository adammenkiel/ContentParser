
public class ParseResponse
{
    public string Status { get; } = "success";
    public int Count { get; } = 0;
    public string EncodedContext { get; } = string.Empty;

    public ParseResponse(int Count, string EncodedContext)
    {
        this.Count = Count;
        this.EncodedContext = EncodedContext;
    }
}