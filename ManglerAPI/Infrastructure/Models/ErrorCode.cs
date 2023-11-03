namespace ManglerAPI.Infrastructure.Models;

/// <summary>
/// ManglerAPI uses string based error codes.  Making the codes into a more human readable format
/// helps consumers debug issues.  However, due to this approach please don't modify existing error codes
/// once they have gone live.
/// </summary>
public static class ErrorCode
{
    public const string InternalServerError = "internal_server_error";
    
    public const string StoryDoesNotExist = "story_does_not_exist";
    public const string UnableToRetrieveStory = "failed_to_retrieve_story";
    
    // Miscellaneous Request errors
    public const string InvalidPageSize = "invalid_page_size";
    public const string InvalidCursor = "invalid_cursor";

    // story post request
    public const string StoryTitleRequired = "story_title_requred";
    public const string StoryTitleInvalidSize = "story_title_length_invalid";
    public const string StoryAuthorRequired = "story_author_required";
    public const string CreateDateInFuture = "story_createdt_in_future";
    public const string StoryFirstLineRequired = "story_first_line_required";

}