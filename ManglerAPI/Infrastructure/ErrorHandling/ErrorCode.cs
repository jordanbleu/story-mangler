namespace ManglerAPI.Infrastructure.ErrorHandling;


public static class ErrorCode
{
    public static string RequestValidationFailed = nameof(RequestValidationFailed);
    public static string TooManyOpenStories = nameof(TooManyOpenStories);
    public static string InternalServerError = nameof(InternalServerError);
    public static string UnableToRetrieveStory = nameof(UnableToRetrieveStory);
    public static string UnableToCreateStory = nameof(UnableToCreateStory);
    public static string InvalidPageSize = nameof(InvalidPageSize);

    public static string TitleIsRequired = nameof(TitleIsRequired);
    public static string TitleLengthInvalid = nameof(TitleLengthInvalid);
    public static string FirstLineIsRequired = nameof(FirstLineIsRequired);
    public static string InvalidUserId = nameof(InvalidUserId);
    public static string InvalidClientType = nameof(InvalidClientType);
    public static string IdImproperFormat = nameof(IdImproperFormat);
    
    /// <summary>
    /// Default english translations for all error codes.  These can be displayed directly on the UI.
    /// </summary>
    public static readonly Dictionary<string, string> DefaultLocalizations = new()
    {
        { ErrorCode.RequestValidationFailed, "Request was not valid"},
        { ErrorCode.TooManyOpenStories, "There are too many unfinished stories for this group"},
        { ErrorCode.InternalServerError, "There was an internal server error" },
        { ErrorCode.UnableToRetrieveStory, "Story not found"},
        { ErrorCode.UnableToCreateStory, "Unable to create story" },
        { ErrorCode.InvalidPageSize, "Invalid page size" },
        
        { ErrorCode.TitleIsRequired, "Title is required" },
        { ErrorCode.TitleLengthInvalid, "The title length is not valid" },
        { ErrorCode.FirstLineIsRequired, "First line of story required" },
        { ErrorCode.InvalidUserId, "User is not present or invalid." },
        { ErrorCode.InvalidClientType, "Invalid client type" },
        { ErrorCode.IdImproperFormat, "The id was not formatted correctly" }

    };
}

