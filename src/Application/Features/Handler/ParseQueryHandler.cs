using MediatR;
using Application.Answer;
using Application.Services;
using Application.Features.Responses;
using Application.Features.Queries;
using Domain.Parser;

namespace Application.Features.Handler;

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
            using ParsedInfo info = ParseService.ParseEncodedContent(request.Type, request.Content);
            int count = info.Count;
            string contentString = info.GetContentString();

            return new UnsureResponse<ParseResponse>(
                new ParseResponse(count, contentString)
            );
        } catch (Exception e)
        {
            return new UnsureResponse<ParseResponse>(
                new ExceptionResponse(e.Message)
            );   
        }
    }
}