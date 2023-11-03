
namespace ManglerAPI.Entities;

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
    /// UserIdentifier of the story's author.
    /// </summary>
    public string AuthorUserIdentifier { get; }
    
    /// <summary>
    /// Type of client that the author is part of 
    /// </summary>
    public ClientType AuthorClientType { get; }
    
    /// <summary>
    /// Group that is responsible for this story, or null if it is open to the world.
    /// </summary>
    public string GuildIdentifier { get; } 

    /// <summary>
    /// Date the story was marked completed, or null if the story is still open.
    /// </summary>
    public DateTime? CompleteDt { get; }
    
    /// <summary>
    /// Date that the story was first created.
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