
public class ParseException : Exception
{
    public ParseException()
        : base() {}

    public ParseException(string Message, Exception InnerException)
        : base(Message, InnerException) {}

    public ParseException(string Message) 
        : base(Message) {}
}