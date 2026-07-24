

using Microsoft.AspNetCore.Mvc;

[Route("/api/v1/parse-content")]
[ApiController]
public class ApiController : ControllerBase
{
    //[FromBody] string PageBody
    [HttpPost]
    public async Task<IActionResult> Parse()
    {
        return Ok("Accepted");
    }
}