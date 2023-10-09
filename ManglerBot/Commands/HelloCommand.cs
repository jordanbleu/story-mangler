using Discord.WebSocket;

namespace ManglerBot.Commands;

[CommandParameter(Name="name", Description = "Tell us your name so we can personalize the message :)", IsRequired = false)]
public class HelloCommand : ISlashCommand
{
    public string Name => "hello";
    
    public string Description => "Checks that the bot is alive.";
    
    public async Task ExecuteAsync(SocketSlashCommand command)
    {
        var name = command.Data.Options.Where(opt => opt.Name == "name")?.FirstOrDefault()?.Value?.ToString();

        if (string.IsNullOrEmpty(name))
        {
            await command.RespondAsync("Hello from ManglerBot <3");
        }
        else
        {
            await command.RespondAsync($"Hello {name} from ManglerBot <3");
        }


    }
    
}