namespace ManglerAPI.Group.Entities;

public class Group
{
    /// <summary>
    /// Primary key
    /// </summary>
    public long ClientId { get; }
    
    /// <summary>
    /// Identifier for the group.  The implementation is dependent on
    /// the Client Type
    /// </summary>
    public string Identifier { get; }
    
    /// <summary>
    /// Dictates the identifier implementation, as well as how the settings
    /// should be structured.
    /// </summary>
    public ClientType Type { get; }
    
    /// <summary>
    /// JSON blob representing unstructured settings for a particular client.  The
    /// implementation varies from client to client.
    /// </summary>
    public Dictionary<string,string> Settings { get; }
}