using Application.Answer;

namespace Application.Features.Responses;
public class ParseResponse : IResponse
{
    public string Status { get; } = "success";
    public int Count { get; } = 0;
    public string EncodedContent { get; } = string.Empty;

    public ParseResponse(int Count, string EncodedContent)
    {
        this.Count = Count;
        this.EncodedContent = EncodedContent;
    }
}