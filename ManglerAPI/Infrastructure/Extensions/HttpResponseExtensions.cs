namespace ManglerAPI.Infrastructure.Extensions;

public static class HttpResponseExtensions
{
    public static bool IsSuccessResponse(this HttpResponse response) => response.StatusCode < 400;
}