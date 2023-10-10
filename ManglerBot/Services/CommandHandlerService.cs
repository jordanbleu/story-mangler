using Discord.WebSocket;
using ManglerBot.Commands;

namespace ManglerBot.Services;

/// <summary>
/// Entry point for all slash commands.  Delegates to the appropriate ICommand implementation.
/// </summary>
public class CommandHandlerService
{
    private readonly IDictionary<string, ISlashCommand> _commands;
    private readonly ILogger<CommandHandlerService> _logger;
    
    public CommandHandlerService(IEnumerable<ISlashCommand> commands, ILogger<CommandHandlerService> logger)
    {
        _logger = logger;
        _commands = commands.ToDictionary(c => c.Name, c => c);
    }

    public async Task HandleCommand(SocketSlashCommand command)
    {
        var cmdName = command.Data.Name.ToLower();
        
        if (!_commands.TryGetValue(cmdName, out var cmd))
        {
            _logger.LogCritical($"Registered command '{command}' has no implementation. Do we need to regenerate slash commands?");
            await command.RespondAsync("Sorry, I don't recognize that command 🥺", ephemeral:true);
            return;
        }
        await cmd.ExecuteAsync(command);
    
    }
}