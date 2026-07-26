using MediatR;

public class ParseQuery : IRequest
{
    public string Type { get; set; }
    public string Content { get; set; }
}