using ManglerAPI.Entities;

namespace ManglerAPI.Models;

public class StoryModel
{
    /// <summary>
    /// The primary key of the Story record
    /// </summary>
    public long Id { get; init; }

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
    /// Date the story was marked completed, or null if the story is still open.
    /// </summary>
    public DateTime? CompleteDt { get; init; }
    
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
    
}

public static class StoryModelExtensions
{
    /// <summary>
    /// Maps an entity object to a API response object.
    /// </summary>

    public static StoryModel ToModel(this Story story) => new StoryModel()
    {
        Id = story.Id,
        Title = story.Title,
        AuthorUserIdentifier = story.AuthorUserIdentifier,
        AuthorClientType = story.AuthorClientType.ToModel(),
        GuildIdentifier = story.GuildIdentifier,
        CompleteDt = story.CompleteDt,
        CreateDt = story.CreateDt,
        IsViewableByPublic = story.IsViewableByPublic,
        IsWritableByPublic = story.IsWritableByPublic
    };
}