namespace ManglerAPI.Infrastructure.Middleware;

public class CallIdMiddleware
{
    private const string CallIdHeader = "X-callId";

    private readonly RequestDelegate _next;

    public CallIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Client may assign their own callId if they want by setting X-callId, otherwise one will be assigned.
        
        Guid callId;

        context.Request.Headers.TryGetValue(CallIdHeader, out var callIdString);

        if (!string.IsNullOrEmpty(callIdString) && Guid.TryParse(callIdString, out var callIdParsed))
        {
            callId = callIdParsed;
        }
        else
        {
            callId = Guid.NewGuid();
            context.Request.Headers.Add(CallIdHeader, callId.ToString());
        }
        
        context.Response.Headers.Add(CallIdHeader, callId.ToString());

        await _next.Invoke(context);
    }
}

public static class CallIdMiddlewareExtensions
{
    public static IApplicationBuilder UseCallIdGenerator(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CallIdMiddleware>();
    }
}