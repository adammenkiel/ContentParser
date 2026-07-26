
public class ExceptionResponse
{
    public bool success = false;
    public string ErrorMessage { get; }
    public ExceptionResponse(string ErrorMessage)
    {
        this.ErrorMessage = ErrorMessage;
    }
}