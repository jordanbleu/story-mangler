namespace Mangler.Common.Monads;

public class Result
{
    protected Result() { }

    public bool IsSuccess { get; protected init; } = true;
    public Exception? Exception { get; protected init; } = new();
    public string? ErrorDetails { get; protected init; } = string.Empty;
    public string? ErrorCode { get; protected init; } = string.Empty;

    public static Result Success() => new Result();
    public static Result Failure(string? message, string errorCode = "", Exception? ex = null) => new Result()
    {
        ErrorDetails = message,
        Exception = ex,
        IsSuccess = false,
        ErrorCode = errorCode
    };

    public static Result FromBool(bool success, string errorCode = "", string errorMessage = "")
    {
        if (success)
        {
            return Success();
        }

        return Failure(errorCode, errorMessage);
    }
    
    /// <summary>
    /// Invokes the passed in function.  If an exception
    /// of any kind occurs, it will be caught and returned as a failed result.
    /// </summary>
    public static async Task<Result> WrapAsync(Func<Task> function, string? messageOnError = null)
    {
        try
        {
            await function.Invoke();
            return Success();
        }
        catch (Exception ex)
        {
            return Failure(messageOnError ?? "There was an internal server exception", ex: ex);
        }
    }
}

public class Result<TValue> : Result
{
    protected Result() { }
    public TValue? Value { get; private set; }
    

    public static async Task<Result<TValue>> WrapAsync(Func<Task<TValue>> function, string errorCodeOnError = "", string? messageOnError = null)
    {
        try
        {
            var val = await function.Invoke();
            return Success(val);
        }
        catch (Exception ex)
        {
            return Failure(errorCodeOnError,messageOnError ?? "There was an internal server exception", ex);
        }
    }
    
    public static Result<TValue> Success(TValue value) => new Result<TValue>() { Value = value };
    
    public new static Result<TValue> Failure(string errorCode, string details = "", Exception? ex = null) => new Result<TValue>()
    {
        ErrorDetails = details,
        Exception = ex,
        ErrorCode = errorCode
    };
    
}

public static class ResultExtensions
{
    public static bool IsFailure(this Result result) => result.IsSuccess == false;

    public static Result Then(this Result currentResult, Func<Result> nextResultFunc)
    {
        if (!currentResult.IsSuccess)
        {
            return currentResult;
        }
        return nextResultFunc.Invoke();
    }

    public static Result<TTo> CastToFailedResult<TFrom, TTo>(this Result<TFrom> fromResult)
        => Result<TTo>.Failure(fromResult.ErrorCode, fromResult.ErrorDetails, fromResult.Exception);



}



