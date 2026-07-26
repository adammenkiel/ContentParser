
using MediatR;

public class ParseQueryHandler : IRequestHandler<ParseQuery, ParseResponse>
{
    public async Task<ParseResponse> Handle(ParseQuery request, CancellationToken cancellationToken)
    {
        return new ParseResponse();
    }
}