using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("/api/v1/parse-content")]
[ApiController]
public class ApiController : ControllerBase
{

    private readonly IMediator _mediator;

    public ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Parse([FromBody] ParseQuery Query)
    {
        var result = await _mediator.Send(Query);
        
        return Ok(Query.Type + " - " + Query.Content);
    }
}