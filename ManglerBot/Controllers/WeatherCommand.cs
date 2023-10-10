using Discord.WebSocket;
using ManglerBot.Commands;

namespace ManglerBot.Controllers;

public class WeatherCommand : ISlashCommand
{
    public string Name => "weather";
    public string Description => "Get Today's weather forecast";
    public Task ExecuteAsync(SocketSlashCommand command)
    {
        return command.RespondAsync("Today will be a high of 50 degrees and a low of 32");
    }
}