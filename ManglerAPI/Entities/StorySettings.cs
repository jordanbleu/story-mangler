namespace ManglerAPI.Entities;

/// <summary>
/// Specific settings and permissions for a single story
/// </summary>
public class StorySettings
{
    /// <summary>
    /// If true, the story will show up to the public
    /// </summary>
    public bool IsViewableByPublic { get; }
    
    /// <summary>
    /// If true, will show up to users who want to contribute to a random story
    /// </summary>
    public bool IsWritableByPublic { get; }
}