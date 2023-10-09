using Discord.WebSocket;

namespace ManglerBot.Commands;

public interface ISlashCommand
{
    /// <summary>
    /// The command name, aka the actual command the user types to invoke.  Must be lowercase.
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// The command's description, visible in discord
    /// </summary>
    string Description { get; }
    
    /// <summary>
    /// Code that is executed when the command gets invoked
    /// </summary>
    /// <returns></returns>
    Task ExecuteAsync(SocketSlashCommand command);
}