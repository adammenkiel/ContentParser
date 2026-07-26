
using MediatR;

public class ParseQueryHandler : IRequestHandler<ParseQuery, UnsureResponse<ParseResponse>>
{
    public async Task<UnsureResponse<ParseResponse>> Handle(ParseQuery request, CancellationToken cancellationToken)
    {
        return new UnsureResponse<ParseResponse>(new ExceptionResponse("Test"));
    }
}