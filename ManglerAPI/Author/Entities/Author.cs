using ManglerAPI.Infrastructure.Entities;

namespace ManglerAPI.Author.Entities;

public class Author
{
    public string Name { get; }
    public string UserIdentifier { get; }
    public ClientType ClientType { get; }
}