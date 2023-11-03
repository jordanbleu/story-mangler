using ManglerAPI.Infrastructure.Models;
using ManglerAPI.Infrastructure.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ManglerController
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    // This is invoked internally whenever an exception occurs
    [HttpGet]
    [Route("/error")]
    public ActionResult Error()
    {
        var ctx = HttpContext.Features.Get<IExceptionHandlerFeature>();
        HttpContext.Request.Headers.TryGetValue("X-callId", out var callIdString);
        _logger.LogError(ctx.Error, "An exception occured, returning 500.  Call ID = {}", callIdString);
        return InternalServerError(ErrorCode.InternalServerError, "An error occured processing your request.");
    }
}