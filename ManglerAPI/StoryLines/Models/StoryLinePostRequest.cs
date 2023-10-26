using Mangler.Common.Monads;
using ManglerAPI.Infrastructure.Validation;

namespace ManglerAPI.StoryLines.Models;

public class StoryLinePostRequest
{
    /// <summary>
    /// The primary key of the Story record this line is for.
    /// </summary>
    public string StoryId { get; set; }

    /// <summary>
    /// The type of client the user submitted the line as.
    /// </summary>
    public StoryLineClientType ClientType { get; set; } = StoryLineClientType.Discord;
    
    /// <summary>
    /// Client dependent User ID of the person who wrote this line
    /// </summary>
    public string AuthorUserIdentifier { get; set; }
    
    /// <summary>
    /// The actual text of the line 
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// The date that the line was completed.  If null, the line is considered in a draft state.
    /// </summary>
    public DateTime? CompleteDt { get; set; }

}

public static class StoryLinePostRequestExtensions
{
    public static Result ValidateRequest(this StoryLinePostRequest request) => Validate.Begin()
        .Then(Validate.ThatEnumIsDefined(request.ClientType, "Invalid Client Type Specified"))
        .Then(Validate.ThatStringIsNotEmpty(request.AuthorUserIdentifier, "UserID is required"))
        .Then(Validate.ThatStringIsNotEmpty(request.StoryId, "StoryID is required"));
}