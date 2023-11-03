namespace ManglerAPI.Entities;

public record StoryLine
{
    public long Id { get; }
    
    /// <summary>
    /// The ID of the story this line is part of
    /// </summary>
    public long StoryId { get; }
    
    /// <summary>
    /// UserIdentifier of the story's author.
    /// </summary>
    public string UserIdentifier { get; }
    
    /// <summary>
    /// Type of client that the author is part of 
    /// </summary>
    public string ClientType { get; }
    
    /// <summary>
    /// Group that is responsible for this story, or null if it is open to the world.
    /// </summary>
    public string? GuildId { get; } 
    
    /// <summary>
    /// The text of this line
    /// </summary>
    public string Text { get; }
    
    /// <summary>
    /// Date the line was originally started 
    /// </summary>
    public DateTime CreateDt { get; }
    
    /// <summary>
    /// Date the line was completed
    /// </summary>
    public DateTime CompleteDt { get; }
}