using Microsoft.AspNetCore.Mvc;

namespace ProjectB.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        if (Request.Cookies.TryGetValue("ih-rvp", out var ihRvpValue))
        {
            Console.WriteLine($"Received ih-rvp cookie value: {ihRvpValue}");
            //HttpContext.Response.Cookies.Delete("ih-rvp");
            HttpContext.Response.Cookies.Append("ih-rvp", ihRvpValue);

            return Ok($"Cookie value: {ihRvpValue}");
        }
        return NotFound("Cookie ih-rvp not found");
    }
}
