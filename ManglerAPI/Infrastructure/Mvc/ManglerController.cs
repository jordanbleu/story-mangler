using ManglerAPI.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.Infrastructure.Mvc;

/// <summary>
/// Currently this class basically just provides syntactic sugar 
/// </summary>
public class ManglerController : ControllerBase
{
    public NotFoundObjectResult NotFound(string errorCode, string message)
    {
        var obj = new ErrorResponseModel()
        {
            ErrorCode = errorCode,
            Message = message
        };
        return new NotFoundObjectResult(obj);
    }

    /// <summary>
    /// Returns a 500 error.
    /// </summary>
    public ObjectResult InternalServerError(string errorCode, string message)
    {
        HttpContext.Request.Headers.TryGetValue("X-callId", out var callId);
        var obj = new ErrorResponseModel()
        {
            ErrorCode = errorCode,
            Message = message,
            CallId = callId.ToString()
        };
        return new ObjectResult(obj) { StatusCode = 500 };
    }

    public ObjectResult UnprocessableEntity(string errorCode, string message)
    {
        HttpContext.Request.Headers.TryGetValue("X-callId", out var callId);

        var obj = new ErrorResponseModel()
        {
            ErrorCode = errorCode,
            Message = message,
            CallId = callId.ToString()
        };
        return new UnprocessableEntityObjectResult(obj);
    }
}