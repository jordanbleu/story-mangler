
using Discord.WebSocket;
using ManglerBot.Commands;
using ManglerBot.Services;
using ManglerBot.Workers;
using Microsoft.Extensions.Hosting;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// todo: only do this on development
builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddHostedService<DiscordBotWorker>();
builder.Services.AddSingleton<CommandHandlerService>();
builder.Services.AddSingleton<DiscordSocketClient>();
builder.Services.AddSingleton<ISlashCommand, HelloCommand>();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();