using Discord;
using Discord.WebSocket;
using ManglerBot.Extensions;

namespace ManglerBot.Commands;

[CommandParameter(Name = "myeyesonly", 
    Description = "If true, the returned story will only be visible to you.", 
    IsRequired = false, Type = ApplicationCommandOptionType.Boolean)]
public class ReadCommand : ISlashCommand
{
    public string Name => "random";
    public string Description => "Read a random story from our vast collection of incredible crowd-sourced novels."; 
    public async Task ExecuteAsync(SocketSlashCommand command)
    {
        var isEphemeral = command.GetParameter<bool>("myeyesonly") ?? false;
        
        await command.DeferAsync(isEphemeral);

        // todo: api call to get a rando story

        await Task.Delay(1000);

        await command.FollowupAsync("<return stuff here>", ephemeral: isEphemeral);
    }
}