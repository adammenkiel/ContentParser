using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("/api/v1/parse-content")]
[ApiController]
public class ApiController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Parse([FromBody] ParseQuery Query)
    {
        var result = await _mediator.Send(Query);
        var obj = result.GetValue();
        
        if(obj is ParseResponse response)
        {
            return Ok(response);   
        }
        if(obj is ExceptionResponse errorResponse)
        {
            return BadRequest(errorResponse);
        }
        return StatusCode(500);
    }
}