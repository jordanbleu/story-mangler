namespace ManglerAPI.Rating.Entities;

public class Rating
{
    /// <summary>
    /// Story that was rated
    /// </summary>
    public long StoryId { get; }
    
    /// <summary>
    /// Rating out of five stars
    /// </summary>
    public byte Rate { get; }
    
    /// <summary>
    /// User who submitted the rating
    /// </summary>
    public long UserId { get; }
}