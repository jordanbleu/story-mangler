using Microsoft.AspNetCore.Mvc;

namespace ManglerBot.Controllers;

[Route("/hello")]
public class HelloController : ControllerBase 
{

    [HttpGet]
    public IActionResult GetAsync()
    {
        return Ok("Hello");
    }

}