using System.Net;
using Mangler.Common.Monads;
using ManglerAPI.Infrastructure.Localization;
using ManglerAPI.Infrastructure.Models;

namespace ManglerAPI.Infrastructure.ErrorHandling;

/// <summary>
/// Generates errors in the common error format, with localized text
/// </summary>
public class ErrorFactory
{
    private const string DefaultErrorMessage = "There was an error processing your request";
    
    private readonly ILocalizer _localizer;

    public ErrorFactory(ILocalizer localizer)
    {
        _localizer = localizer;
    }

    
    public ErrorResponseModel CreateErrorResponse(Result result)
    {
        var localizedError = _localizer.Localize("en-US", result.ErrorCode);

        if (string.IsNullOrEmpty(localizedError))
        {
            localizedError = DefaultErrorMessage;
        }
        return new ErrorResponseModel()
        {
            ErrorCode = result.ErrorCode,
            Message = localizedError,
            Details = result.ErrorDetails
        };
    }

    public ErrorResponseModel CreateErrorResponse(string errorCode)
    {
        var localizedError = _localizer.Localize("en-US", errorCode);

        if (string.IsNullOrEmpty(localizedError))
        {
            localizedError = DefaultErrorMessage;
        }
        return new ErrorResponseModel()
        {
            ErrorCode = errorCode,
            Message = localizedError,
        };
    }

}