//Temporary maybe pattern
//TODO: GetValue returns object; It's good to consider to refactor it

public class UnsureResponse<T>
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

    public object GetValue()
    {
        if(ExceptionValue != null) return ExceptionValue;
        if(Value != null) return Value;
        throw new Exception("Response can be only ExceptionResponse or TResult");
    }
}