using Mangler.Common.Extensions;
using Mangler.Common.Results;

namespace ManglerAPI.Infrastructure.Validation;

/// <summary>
/// Used for basic input validation that doesn't require any dependencies.  For anything more
/// advanced a separate business logic service should be used.
///
/// The validator logic is a bit backwards in that a success result means the item is NOT valid.
/// </summary>
public static class Validate
{
    private static readonly Result<string> DefaultResult = Result<string>.Failure<string>(string.Empty);

    public static Func<Result<string>> IsStringEmpty(string value, string errorCode) =>
        Is(string.IsNullOrEmpty(value), errorCode);

    public static Func<Result<string>> IsStringLengthOutOfRange(string value, int minLength, int maxLength, string errorCode) =>
        Is(!value.LengthIsInRange(minLength, maxLength), errorCode);

    public static Func<Result<string>> IsNumberOutOfRange(int value, int min, int max, string errorCode) =>
        Is(!value.IsBetween(min, max), errorCode);

    public static Func<Result<string>> IsDateInFuture(DateTime dt, string errorCode) =>
        Is(dt > DateTime.UtcNow, errorCode);


    
    /// <summary>
    /// Returns a success result with the specified error code if the passed in condition is true.
    /// Can be used for one-off validations alongside other chained
    /// validations.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="errorCode"></param>
    /// <returns></returns>
    public static Func<Result<string>> Is(bool condition, string errorCode) => () =>
    {
        if (condition)
        {
            return Result<string>.Success(errorCode);
        }

        return DefaultResult;
    };

    
}