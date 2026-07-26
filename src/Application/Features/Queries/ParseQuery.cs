using MediatR;

public class ParseQuery : IRequest<UnsureResponse<ParseResponse>>
{
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}