using Microsoft.AspNetCore.Mvc;
using ProjectA.MyCustomHttpClient;

namespace ProjectA.Controllers;

[ApiController]
[Route("[controller]")]
public class HttpClientController : ControllerBase
{
    private readonly ICustomHttpClient _customHttpClient;
    public HttpClientController(ICustomHttpClient customHttpClient)
    {
        _customHttpClient = customHttpClient;
    }

    [HttpGet("test")]
    public async Task<IActionResult> Get()
    {
        await _customHttpClient.SendAsync();
        return Ok("Succeed");
    }
}
