
public class MaxContentLengthException : Exception
{
    public MaxContentLengthException()
        : base() {}

    public MaxContentLengthException(string Message, Exception InnerException)
        : base(Message, InnerException) {}

    public MaxContentLengthException(string Message) 
        : base(Message) {}
}