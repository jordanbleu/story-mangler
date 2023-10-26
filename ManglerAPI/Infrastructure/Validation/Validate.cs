using Mangler.Common.Extensions;
using Mangler.Common.Monads;

namespace ManglerAPI.Infrastructure.Validation;

public static class Validate
{
    private const string RequestValidationFailedMessage = "Request validation failed";
    /// <summary>
    /// Begin validation.  
    /// </summary>
    /// <returns></returns>
    public static Result Begin() => Result.Success();

    public static Func<Result> ThatStringIsNotEmpty(string value, string errorCode, string details = null) =>
        () => Result.FromBool(!string.IsNullOrWhiteSpace(value), errorCode, details ?? RequestValidationFailedMessage);

    public static Func<Result> ThatStringLengthIsInRange(string str, int min, int max, string errorCode, string details = null) =>
        () => Result.FromBool(str.LengthIsInRange(min, max), errorCode, details ?? RequestValidationFailedMessage);
 
    public static Func<Result> ThatEnumIsDefined<TEnum>(TEnum enumValue, string errorCode, string details = null) where TEnum : System.Enum
    {
        var allValues = (TEnum[])Enum.GetValues(typeof(TEnum));
        return () => Result.FromBool(allValues.Contains(enumValue), errorCode, details ?? RequestValidationFailedMessage);
    }
    
    public static Func<Result> ThatIntIsInRange(int value, int min, int max, string errorCode, string details = null) =>
        ()=> Result.FromBool(value.IsBetween(min, max), errorCode, details ?? RequestValidationFailedMessage);
}

