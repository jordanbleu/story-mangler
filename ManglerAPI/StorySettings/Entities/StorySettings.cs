namespace ManglerAPI.StorySettings.Entities;

public class StorySettings
{
    /// <summary>
    /// If true, the story will not be allowed to be shown to the public for writing.  It will only show in the current
    /// user's client / group.  If false, when a user wants to write a story with random people it can show up.
    /// </summary>
    public bool IsWritableByPublic { get; }
    
    /// <summary>
    /// If true, the public can discover this story.  If false, it will be restricted only to the
    /// group that created it.
    /// </summary>
    public bool IsReadableByPublic { get; }
    
}