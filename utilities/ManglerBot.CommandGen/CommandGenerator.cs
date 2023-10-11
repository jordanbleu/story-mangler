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
            
            var commandImplementations = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => commandInterfaceType.IsAssignableFrom(t))
                .Where(t => t != commandInterfaceType)
                .Select(t=>Activator.CreateInstance(t) as ISlashCommand)
                .ToList();

            if (commandImplementations?.Any() != true)
            {
                Error("No command implementations found at all.  Don't think that's right.");
                return;
            }

            var totalCommands = commandImplementations.Count;
            var currentCommandIndex = 0;
            
            Print($"Found {totalCommands} command implementations");

            Print("Getting currently registered commands from discord...");
            
            var registeredCommands = await client.GetGlobalApplicationCommandsAsync();
            var implementedCommands = commandImplementations.Where(i => i is not null).Select(i => i.Name).ToHashSet();
            
            foreach (var registeredCommand in registeredCommands)
            {
                if (implementedCommands.Contains(registeredCommand.Name)) continue;
                Print($"\tDeleting existing command with no implementation: {registeredCommand.Name}");
                await registeredCommand.DeleteAsync();
            }

            Print("Done with registered commands, now we are gonna register / re-register new commands");

            foreach (var commandImpl in commandImplementations)
            {
                if (commandImpl is null)
                {
                    throw new InvalidCastException("There was an issue casting a command impl as ICommand");
                }
                
                Print($"Generating command {commandImpl.Name} ({++currentCommandIndex} of {totalCommands}).");
                
                var parameterAttributes = commandImpl.GetType().GetCustomAttributes(typeof(CommandParameterAttribute), false)
                    .Select(attr => (CommandParameterAttribute)attr);

                var globalCommand = new SlashCommandBuilder()
                    .WithName(commandImpl.Name)
                    .WithDescription(commandImpl.Description);

                foreach (var par in parameterAttributes)
                {
                    Print("\tAdding option: " + par.Name);
                    globalCommand.AddOption(par.Name, par.Type, par.Description, par.IsRequired);
                }

                Print($"Sending {commandImpl.Name} to discord...");
                await client.CreateGlobalApplicationCommandAsync(globalCommand.Build());
                Print("...done");
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
            Console.WriteLine("All done, press enter to exit");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}