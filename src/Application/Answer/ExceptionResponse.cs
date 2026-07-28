namespace Application.Answer;

public class ExceptionResponse(string errorMessage) : IResponse
{
    public string Status { get; } = "failed";
    public string ErrorMessage { get; } = errorMessage;
}