
using MediatR;

public class ParseQueryHandler(ParseService parseService) 
    : IRequestHandler<ParseQuery, UnsureResponse<ParseResponse>>
{
    private readonly ParseService ParseService = parseService;

    public async Task<UnsureResponse<ParseResponse>> Handle(
        ParseQuery request,
        CancellationToken cancellationToken
    )
    {
        try {
            ParsedInfo info = ParseService.ParseEncodedContent(request.Type, request.Content);
            return new UnsureResponse<ParseResponse>(
                new ParseResponse(info.Count, info.GetContentString())
            );
        } catch (Exception e)
        {
            return new UnsureResponse<ParseResponse>(
                new ExceptionResponse(e.Message)
            );   
        }
    }
}