// See https://aka.ms/new-console-template for more information

using Discord;
using Discord.Net;
using Discord.WebSocket;
using ManglerBot.CommandGen;
using ManglerBot.Commands;
using Microsoft.Extensions.Configuration;
using static ManglerBot.CommandGen.ConsoleWriter;

Print("Hello, I am going to regenerate the discord commands for you.");
Print("This might take a bit.");

var builder = new ConfigurationBuilder()
    .AddUserSecrets<Program>();
    
var config = builder.Build();

var token = config["DiscordBot:Token"];

if (string.IsNullOrEmpty(token))
{
    Error("The DiscordBot:Token secret was null or empty.  If running this for the first time, you may need to repeat the setup steps in the project's readme.md");
}

Print("Logging into discord...");
var client = new DiscordSocketClient();
await client.LoginAsync(TokenType.Bot, token);
Print("Logged in!  Starting client...");
await client.StartAsync();
Print("Started!  Waiting for it to be ready.");

client.Ready += () => CommandGenerator.GenerateCommands(client);

// This thread waits forever, the other thread running the commands should exit for us
// Not a great way to do that but who care's its a utility app
await Task.Delay(-1);

