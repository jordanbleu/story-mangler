using Discord.WebSocket;

namespace ManglerBot.Extensions;

public static class SocketSlashCommandExtensions
{
    /// <summary>
    /// Retrieves the slash command parameter value requested.  If it is not present, or it is in the wrong
    /// format, it will return null;
    /// </summary>
    /// <param name="command"></param>
    /// <param name="name"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? GetParameter<T>(this SocketSlashCommand command, string name) where T:struct
    {
        var value = command.Data.Options
            .FirstOrDefault(opt => opt.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?.Value;

        return value as T?;
    }

}