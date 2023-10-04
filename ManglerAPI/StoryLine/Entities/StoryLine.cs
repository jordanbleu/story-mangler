namespace ManglerAPI.StoryLine.Entities;

public class StoryLine
{
    /// <summary>
    /// The ID of the story this line is part of
    /// </summary>
    public long StoryId { get; }
    
    /// <summary>
    /// The text of this line
    /// </summary>
    public string Text { get; }
    
    /// <summary>
    /// User id who wrote this line
    /// </summary>
    public long AuthorUserId { get; }
    
    /// <summary>
    /// Date the line was originally written and submitted
    /// </summary>
    public DateTime CreateDate { get; }
    
    /// <summary>
    /// Date the line was last edited or updated
    /// </summary>
    public DateTime UpdateDate { get; }
    
    /// <summary>
    /// Order that the line should appear in the story
    /// </summary>
    public short Order { get; }
    
    
    
    
    
}