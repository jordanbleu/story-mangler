using Mangler.Common.Extensions;
using ManglerAPI.Infrastructure.ErrorHandling;
using ManglerAPI.Infrastructure.Localization;
using ManglerAPI.Infrastructure.Mongo;
using ManglerAPI.Infrastructure.Options;
using ManglerAPI.Infrastructure.Swagger;
using ManglerAPI.Services;
using ManglerAPI.Stories.Repositories;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using ManglerAPI.Infrastructure.Middleware;
using MongoDB.Bson.Serialization.Conventions;

// tells the mongodb driver to map camel case to Pascal Case
var pack = new ConventionPack { new CamelCaseElementNameConvention() };
ConventionRegistry.Register("camel case", pack, t => true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ManglerDbSettings>(builder.Configuration.GetSection("ManglerDb"));
builder.Services.Configure<GlobalRules>(builder.Configuration.GetSection("GlobalRules"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "ManglerAPI v1",
        Version = "v1",
        Description = "REST API for StoryMangler"
    });

    // Makes swaggerUI generate documentation based on XML comments
    c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "ManglerAPI.xml"));
    
    // Tells Mangler.CodeGen to format methods like '{HttpMethod}{ControllerName}Async'
    c.CustomOperationIds(e => $"{e.HttpMethod?.ToTitleCase()}{e.ActionDescriptor.RouteValues["controller"]}");
});

builder.Services.AddSingleton<ILocalizer, InMemoryLocalizer>();
builder.Services.AddSingleton<MongoClientFactory>();
builder.Services.AddSingleton<StoryService>();
builder.Services.AddSingleton<IStoryRepository, StoryMongoRepository>();
builder.Services.AddSingleton<ErrorFactory>();
builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, ProduceResponseTypeModelProvider>());


var app = builder.Build();

app.UseCallIdGeneration();

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

