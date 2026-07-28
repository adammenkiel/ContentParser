namespace Application.Answer;

public class UnsureResponse<T> where T : IResponse
{
    private readonly T? Value;
    private readonly ExceptionResponse? ExceptionValue;

    public UnsureResponse(T response)
    {
        Value = response;
    }

    public UnsureResponse(ExceptionResponse exception)
    {
        ExceptionValue = exception;
    }

    public IResponse GetValue()
    {
        if(ExceptionValue != null) return ExceptionValue;
        if(Value != null) return Value;
        throw new Exception("Response can be only ExceptionResponse or TResult");
    }
}