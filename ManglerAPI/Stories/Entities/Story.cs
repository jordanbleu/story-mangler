using ManglerAPI.Entities;
using ManglerAPI.Infrastructure.Entities;
using ManglerAPI.StoryLines.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ManglerAPI.Stories.Entities;

/// <summary>
/// A story is a grouping of storylines 
/// </summary>
[BsonIgnoreExtraElements]
public record Story
{
    /// <summary>
    /// The primary key of the Story record
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    /// <summary>
    /// The title of the story
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The type of client the user submitted the story as.
    /// </summary>
    public ClientType ClientType { get; set; }
    
    /// <summary>
    /// Client dependent User ID of the person who first created the story
    /// </summary>
    public string AuthorUserIdentifier { get; set; }
    
    /// <summary>
    /// Client dependant group identifier (for discord, this is the guild id)
    /// </summary>
    public string GroupIdentifier { get; set; } 

    /// <summary>
    /// Date the story was marked completed
    /// </summary>
    public DateTime? CompleteDt { get; set; }
    
    /// <summary>
    /// Date that the story was first created
    /// </summary>
    public DateTime CreateDt { get; set; }
    
    /// <summary>
    /// The lines of this story.  They should be ordered by CreateDt
    /// </summary>
    public List<StoryLine> Lines { get; set; }
    
}