using ManglerAPI.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.HelloWorld;

[Route("/helloworld")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public IActionResult GetAsync()
    {
        return Ok("hello world!");
    }
}