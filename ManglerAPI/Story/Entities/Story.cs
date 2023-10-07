
namespace ManglerAPI.Story.Entities;

public record Story
{
    /// <summary>
    /// The primary key of the Story record
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// The title of the story
    /// </summary>
    public string Title { get; } 
    
    /// <summary>
    /// User ID of the person who first created the story
    /// </summary>
    public long AuthorId { get; }
    
    /// <summary>
    /// Information about the client / group that created the story.  Can be null
    /// </summary>
    public long? GuildId { get; } 

    /// <summary>
    /// Date the story was marked completed
    /// </summary>
    public DateTime? CompleteDt { get; }
    
    /// <summary>
    /// Date that the story was first created
    /// </summary>
    public DateTime CreateDt { get; }
    
    /// <summary>
    /// If true, the story will show up to the public
    /// </summary>
    public bool IsViewableByPublic { get; }
    
    /// <summary>
    /// If true, will show up to users who want to contribute to a random story
    /// </summary>
    public bool IsWritableByPublic { get; }
    
}