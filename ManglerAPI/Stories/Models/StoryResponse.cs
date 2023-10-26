using ManglerAPI.Infrastructure.Entities;
using ManglerAPI.Stories.Entities;

namespace ManglerAPI.Stories.Models;

[Serializable]
public class StoryResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public StoryClientType ClientType { get; set; }
    public string AuthorUserIdentifier { get; set; }
    public string GroupIdentifier { get; set; } 
    public DateTime? CompleteDt { get; set; }
    public DateTime CreateDt { get; set; }
}

public static class StoryModelExtensions
{
    public static StoryResponse MapToStoryGetResponse(this Story story) => new StoryResponse()
    {
        Id = story.Id.ToString(),
        Title = story.Title,
        ClientType = MapEntityClientType(story.ClientType),
        AuthorUserIdentifier = story.AuthorUserIdentifier,
        GroupIdentifier = story.GroupIdentifier,
        CompleteDt = story.CompleteDt,
        CreateDt = story.CreateDt
    };
    
    private static StoryClientType MapEntityClientType(ClientType ct) =>
        ct == ClientType.Discord ? StoryClientType.Discord : StoryClientType.Web;
}