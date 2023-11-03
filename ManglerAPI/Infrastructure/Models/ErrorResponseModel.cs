namespace ManglerAPI.Infrastructure.Models;

[Serializable]
public class ErrorResponseModel
{
    /// <summary>
    /// Error code representing the specific error.
    /// </summary>
    public string ErrorCode { get; init; } = string.Empty;
    
    /// <summary>
    /// Detailed message of the error.
    /// </summary>
    public string Message { get; init; } = string.Empty;

    /// <summary>
    /// The callId of the errored response.
    /// </summary>
    public string CallId { get; init; } = string.Empty;
}