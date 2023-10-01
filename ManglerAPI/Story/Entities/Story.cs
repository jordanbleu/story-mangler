namespace ManglerAPI.Story.Entities;

public record Story
{
    public Story(long id, long authorUserId, string title)
    {
        Id = id;
        AuthorUserId = authorUserId;
        Title = title;
    }

    public long Id { get; }

    public string Title { get; } 
    
    public long AuthorUserId { get; }
    
    
}