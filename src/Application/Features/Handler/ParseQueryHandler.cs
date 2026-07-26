
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
            int Count = info.Count;
            string ContentString = info.GetContentString();
            info.Dispose();

            return new UnsureResponse<ParseResponse>(
                new ParseResponse(Count, ContentString)
            );
        } catch (Exception e)
        {
            return new UnsureResponse<ParseResponse>(
                new ExceptionResponse(e.Message)
            );   
        }
    }
}