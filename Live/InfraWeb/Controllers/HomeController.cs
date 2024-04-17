using Microsoft.AspNetCore.Mvc;

namespace InfraWeb.Controllers;

[ApiController]
[Route("home")]
public class HomeController : ControllerBase
{
    [HttpGet("index")]
    public ActionResult<string> Index()
    {
        Console.WriteLine($"  Inside Home {HttpContext.Items["x"]}");
        return Content("Home");
    }
}
