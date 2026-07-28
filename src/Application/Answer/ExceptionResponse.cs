namespace Application.Answer;

public class ExceptionResponse : IResponse
{
    public string Status { get; } = "failed";
    public string ErrorMessage { get; }
    public ExceptionResponse(string ErrorMessage)
    {
        this.ErrorMessage = ErrorMessage;
    }
}