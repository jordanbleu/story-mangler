using ManglerAPI.Infrastructure.Entities;

namespace ManglerAPI.Guild.Entities;

public class Guild
{
    public ClientType ClientType { get; }
    public string GuildIdentifier { get; }
}