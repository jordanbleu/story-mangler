namespace ManglerAPI.Models;

public class StoryLineModel
{
    public long Id { get; }
    
    /// <summary>
    /// The ID of the story this line is part of
    /// </summary>
    public long StoryId { get; }
    
    /// <summary>
    /// User id who wrote this line
    /// </summary>
    public long AuthorId { get; }
    
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