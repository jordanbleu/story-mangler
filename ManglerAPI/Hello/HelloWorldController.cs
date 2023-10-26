using ManglerAPI.Hello.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.Hello;

[Route("/helloworld")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(HelloWorldGetResponse), StatusCodes.Status200OK)]
    public IActionResult GetAsync()
    {
        return Ok(new HelloWorldGetResponse() {Text = "Hello from the API"});
    }
}