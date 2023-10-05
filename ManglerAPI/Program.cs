using ManglerAPI.Extensions;
using ManglerAPI.Infrastructure.ModelProviders;
using ManglerAPI.Story.Repositories;
using ManglerAPI.Story.Services;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Tells Mangler.CodeGen to format methods like '{HttpMethod}{ControllerName}Async'
    c.CustomOperationIds(e => $"{e.HttpMethod?.ToTitleCase()}{e.ActionDescriptor.RouteValues["controller"]}");
});

builder.Services.AddSingleton<StoryService>();
builder.Services.AddSingleton<IStoryRepository, StoryDbRepository>();
builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, ProduceResponseTypeModelProvider>());

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

