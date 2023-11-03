using ManglerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.Controllers;

[Route("/helloworld")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(HelloWorldModel), StatusCodes.Status200OK)]
    public IActionResult GetAsync()
    {
        return Ok(new HelloWorldModel() {Text = "Hello from the API"});
    }

    [HttpGet]
    [Route("/exceptionTest")]
    public IActionResult GetErrorAsync()
    {
        throw new ArgumentException("Task failed successfully (this should log but not be shown in api response)");
    }

}