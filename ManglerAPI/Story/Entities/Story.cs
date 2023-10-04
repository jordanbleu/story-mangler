
namespace ManglerAPI.Story.Entities;

public record Story
{
    public Story(long id, long authorUserId, string title, long? groupId, bool isComplete)
    {
        Id = id;
        AuthorUserId = authorUserId;
        Title = title;
        GroupId = groupId;
        IsComplete = isComplete;
    }

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
    public long AuthorUserId { get; }
    
    /// <summary>
    /// Information about the client / group that created the story.  If left
    /// null, will be a public story
    /// </summary>
    public long? GroupId { get; } 
    
    public bool IsComplete { get; }
    
}