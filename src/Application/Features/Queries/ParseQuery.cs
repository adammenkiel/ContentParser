using MediatR;
using Application.Answer;
using Application.Features.Responses;

namespace Application.Features.Queries;

public class ParseQuery : IRequest<UnsureResponse<ParseResponse>>
{
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}