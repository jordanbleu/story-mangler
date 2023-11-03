using ManglerAPI.Extensions;
using ManglerAPI.Infrastructure.Middleware;
using ManglerAPI.Infrastructure.ModelProviders;
using ManglerAPI.Infrastructure.Options;
using ManglerAPI.Repositories;
using ManglerAPI.Services;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ManglerDbSettings>(builder.Configuration.GetSection("ManglerDb"));
builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration["ManglerDb:ConnectionString"]));
builder.Services.AddSingleton<StoryService>();
builder.Services.AddTransient<IStoryRepository, StoryDbRepository>();
builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, ProduceResponseTypeModelProvider>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCallIdGenerator();
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();