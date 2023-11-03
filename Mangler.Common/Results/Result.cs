using Microsoft.Extensions.Logging;

namespace Mangler.Common.Results;

public class Result
{
    public bool IsSuccess { get; init; } = true;
    public string Error { get; init; } = string.Empty;

    public static Result Failure(string message) => new Result()
    {
        Error = message,
        IsSuccess = false
    };
    
    
}

public class Result<T> : Result
{
    public T Value { get; init; }

    /// <summary>
    /// Invokes the passed in Task, attempts to return the result, and captures any exception.  If an exception occurs, 
    /// it will be 'wrapped' inside a failed result object. 
    /// </summary>
    /// <param name="task">task to invoke</param>
    /// <param name="onError">used ot handle any exceptions (logging, etc)</param>
    /// <returns>Result of <typeparamref name="T"/></returns>
    public static async Task<Result<T>> WrapAsync(Task<T> task, Action<Exception> onError)
    {
        try
        {
            var val = await task;
            return Result<T>.Success(val);
        }
        catch (Exception ex)
        {
            onError?.Invoke(ex);
            return Result<T>.Failure<T>("The operation failed.");
        }
    }

    public static Result<T> Success(T value) => new Result<T>()
    {
        IsSuccess = true,
        Value = value,
    };

    public static new Result<TResult> Failure<TResult>(string message) => new Result<TResult>()
    {
        IsSuccess = false,
        Error = message
    };
}

public static class ResultExtensions
{
    /// <summary>
    /// Returns true if result failed.
    /// </summary>
    /// <returns>!result.IsSuccess</returns>
    public static bool IsFailure(this Result result) => !result.IsSuccess;

    /// <summary>
    /// returns true if the result is non-null and the result's <typeparamref name="T"/> is non-null
    /// </summary>
    public static bool HasValue<T>(this Result<T>? result) => result != null && result.Value != null;
    
    /// <summary>
    /// Used for chaining multiple result returning methods together.  If any <paramref name="nextResultFunc"/>
    /// returns a *failure*, will skip any remaining invocations and return that result as is.
    /// <para>Similar to <see cref="Or"/> except will short circuit on failure instead of success.</para>
    /// </summary>
    /// <returns>Result after running through each chained func.</returns>
    public static Result Then(this Result currentResult, Func<Result> nextResultFunc)
    {
        if (!currentResult.IsSuccess)
        {
            return currentResult;
        }
        return nextResultFunc.Invoke();
    }

    /// <summary>
    /// Used for chaining multiple result returning methods together.  If any <paramref name="nextResultFunc"/>
    /// returns a *success*, will skip any remaining invocations and return that result as is. 
    /// <para>Similar to <see cref="Then"/> except will short circuit on success instead of failure.</para>
    /// </summary>
    public static Result<T> Or<T>(this Result<T> currentResult, Func<Result<T>> nextResultFunc)
    {
        if (currentResult.IsSuccess)
        {
            return currentResult;
        }

        return nextResultFunc.Invoke();
    }
    
    /// <summary>
    /// Used for chaining multiple result returning methods together.  If any <paramref name="nextResultFunc"/>
    /// returns a *success*, will skip any remaining invocations and return that result as is. 
    /// <para>Similar to <see cref="Then"/> except will short circuit on success instead of failure.</para>
    /// </summary>
    public static Result<T> Or<T>(this Func<Result<T>> currentResultFunc, Func<Result<T>> nextResultFunc)
    {
        var currentResult = currentResultFunc.Invoke();
        if (currentResult.IsSuccess)
        {
            return currentResult;
        }

        return nextResultFunc.Invoke();
    }
}