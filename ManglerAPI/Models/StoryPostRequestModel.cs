using Mangler.Common.Results;
using ManglerAPI.Infrastructure.Models;
using ManglerAPI.Infrastructure.Validation;

namespace ManglerAPI.Models;

public class StoryPostRequestModel
{
    /// <summary>
    /// The title of the story
    /// </summary>
    public string Title { get; init; } 
    
    /// <summary>
    /// UserIdentifier of the story's author.
    /// </summary>
    public string AuthorUserIdentifier { get; init; }
    
    /// <summary>
    /// Type of client that the author is part of 
    /// </summary>
    public ClientTypeModel AuthorClientType { get; init; }
    
    /// <summary>
    /// Group that is responsible for this story, or null if it is open to the world.
    /// </summary>
    public string GuildIdentifier { get; init; } 
    
    /// <summary>
    /// Date that the story was first created.
    /// </summary>
    public DateTime CreateDt { get; init; }
    
    /// <summary>
    /// If true, the story will show up to the public
    /// </summary>
    public bool IsViewableByPublic { get; init; }
    
    /// <summary>
    /// If true, will show up to users who want to contribute to a random story
    /// </summary>
    public bool IsWritableByPublic { get; init; }
    
    /// <summary>
    /// The first line of the story to kick things off.  
    /// </summary>
    public string FirstLine { get; init; }

}

public static class StoryPostRequestModelExtensions
{

    public static Result<string> ValidateModel(this StoryPostRequestModel request) => Validate
        .IsStringEmpty(request.Title, ErrorCode.StoryTitleRequired)
        .Or(Validate.IsStringLengthOutOfRange(request.Title, 5, 120, ErrorCode.StoryTitleInvalidSize))
        .Or(Validate.IsStringEmpty(request.AuthorUserIdentifier, ErrorCode.StoryAuthorRequired))
        .Or(Validate.IsDateInFuture(request.CreateDt, ErrorCode.CreateDateInFuture))
        .Or(Validate.IsStringEmpty(request.FirstLine, ErrorCode.StoryFirstLineRequired));



}