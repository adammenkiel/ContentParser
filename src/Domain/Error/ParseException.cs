
// TODO: Finalize implementation
public class ParseException : Exception
{

    public readonly string Message;

    public ParseException()
    {
        Message = "";
    }

    public ParseException(Exception Exception)
    {
        Message = Exception.Message;
    }

    public ParseException(string Message)
    {
        this.Message = Message;
    }
}