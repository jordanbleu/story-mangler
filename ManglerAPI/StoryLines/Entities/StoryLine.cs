using ManglerAPI.Infrastructure.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ManglerAPI.StoryLines.Entities;

/// <summary>
/// A single line of a story, written by a single user.
/// </summary>
[BsonIgnoreExtraElements]
public class StoryLine
{
    
    /// <summary>
    /// The primary key of the Story record
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    
    /// <summary>
    /// The type of client the user submitted the story as.
    /// </summary>
    public ClientType ClientType { get; set; }
    
    /// <summary>
    /// Client dependent User ID of the person who first created the story
    /// </summary>
    public string AuthorUserIdentifier { get; set; }
    
    /// <summary>
    /// The actual text of this line 
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Date the story was marked completed
    /// </summary>
    public DateTime? CompleteDt { get; set; }
    
    /// <summary>
    /// Date that the story was first created
    /// </summary>
    public DateTime CreateDt { get; set; }
}