namespace ManglerAPI.Infrastructure.Middleware;

/// <summary>
/// For every Request, generates a new guid, then shoves it into the request / response headers.
/// </summary>
public class CallIdMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CallIdMiddleware> _logger;

    public CallIdMiddleware(RequestDelegate next, ILogger<CallIdMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var callId = Guid.NewGuid();
        
        _logger.LogTrace("Begin request {}", callId);
        context.Request.Headers.Add("X-CallId", callId.ToString());
        
        await _next.Invoke(context);

        _logger.LogTrace("End request {}, status code {}", callId, context.Response.StatusCode);
    }
}

public static class CallIdMiddlewareExtensions
{
    public static IApplicationBuilder UseCallIdGeneration(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CallIdMiddleware>();
    }
}