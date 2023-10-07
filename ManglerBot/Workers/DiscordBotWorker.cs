namespace ManglerBot.Workers;

public class DiscordBotWorker : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Starting DiscordBotWorker...");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Stopping DiscordBotWorker...");
        return Task.CompletedTask; 
    }
}