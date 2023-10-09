using Discord;
using Discord.Net;
using Discord.WebSocket;
using ManglerBot.Commands;
using static ManglerBot.CommandGen.ConsoleWriter;
namespace ManglerBot.CommandGen;

public static class CommandGenerator
{
    public static async Task GenerateCommands(DiscordSocketClient client)
    {
        try
        {
            var commandInterfaceType = typeof(ISlashCommand);
            
            var allCommands = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => commandInterfaceType.IsAssignableFrom(t))
                .Where(t => t != commandInterfaceType)
                .ToList();

            if (allCommands?.Any() != true)
            {
                Error("No commands found at all.  Don't think that's right.");
                return;
            }

            var totalCommands = allCommands.Count;
            var currentCommandIndex = 0;

            Print($"Found {totalCommands} command(s)");

            foreach (var cmdType in allCommands)
            {
                Print($"Generating command {++currentCommandIndex} of {totalCommands}.");

                if (Activator.CreateInstance(cmdType) is not ISlashCommand inst)
                {
                    throw new InvalidCastException($"Something went wrong casting {cmdType.Name} to ISlashCommand.");
                }

                Print($"Generating command {inst.Name}.");

                var parameterAttributes = cmdType.GetCustomAttributes(typeof(CommandParameterAttribute), false)
                    .Select(attr => (CommandParameterAttribute)attr);

                var globalCommand = new SlashCommandBuilder()
                    .WithName(inst.Name)
                    .WithDescription(inst.Description);

                foreach (var par in parameterAttributes)
                {
                    Print("Adding option: " + par.Name);
                    globalCommand.AddOption(par.Name, par.Type, par.Description, par.IsRequired);
                }

                Print("Sending to discord...");
                await client.CreateGlobalApplicationCommandAsync(globalCommand.Build());
                Print("done");
            }
        }
        catch (HttpException ex)
        {
            Error("Error from discord=> " + ex.Message);
        }
        catch (Exception ex)
        {
            Error(ex.Message);
        }
        finally
        {
            Print("Logging out of discord...");
            await client.LogoutAsync();
        }
    }
}