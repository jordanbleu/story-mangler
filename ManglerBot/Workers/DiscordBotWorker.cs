using Discord;
using Discord.WebSocket;
using ManglerBot.Services;

namespace ManglerBot.Workers;

public class DiscordBotWorker : BackgroundService
{
    private readonly IConfiguration _configuration;
    private readonly DiscordSocketClient _client;
    private readonly ILogger<DiscordBotWorker> _logger;
    private readonly CommandHandlerService _commandHandler;
    public DiscordBotWorker(IConfiguration configuration, ILogger<DiscordBotWorker> logger, DiscordSocketClient client, CommandHandlerService commandHandler)
    {
        _configuration = configuration;
        _logger = logger;
        _client = client;
        _commandHandler = commandHandler;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Delay(-1, cancellationToken: stoppingToken);
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("ManglerBot is starting up, beep boop boop bop.");
        var token = _configuration["DiscordBot:Token"];
        
        _client.SlashCommandExecuted += _commandHandler.HandleCommand;
        
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();
        
        await base.StartAsync(cancellationToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("ManglerBot is...shutting...downnnnn....:(");
        await base.StopAsync(cancellationToken);
    }
}