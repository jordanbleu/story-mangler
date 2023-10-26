using Mangler.Common.Monads;
using ManglerAPI.Infrastructure.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.Infrastructure.Models;

[Serializable]
public class ErrorResponseModel
{
    public ErrorResponseModel()
    {
    }

    public ErrorResponseModel(string message)
    {
        Message = message;
    }
    
    /// <summary>
    /// Error code representing the specific error.
    /// </summary>
    public string ErrorCode { get; init; } = string.Empty;
    /// <summary>
    /// Localized copy for the error
    /// </summary>
    public string Message { get; init; } = string.Empty;
    /// <summary>
    /// Internal details about the error, if applicable.  Will always be in English.
    /// </summary>
    public string Details { get; init; } = string.Empty;
    
}
