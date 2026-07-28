using Application.Answer;

namespace Application.Features.Responses;
public class ParseResponse(int Count, string EncodedContent) : IResponse
{
    public string Status { get; } = "success";
    public int Count { get; } = Count;
    public string EncodedContent { get; } = EncodedContent;
}