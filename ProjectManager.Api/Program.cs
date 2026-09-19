
using ProjectManager.Api.Configuration;
using ProjectManager.Api.Data;
using ProjectManager.Api.Models;
using ProjectManager.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add the services to the container
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Adding the DB Connection options
builder.Services.Configure<DatabaseOptions>(
    builder.Configuration.GetSection(DatabaseOptions.SectionName)
);

// Registering the DB Connection
builder.Services.AddSingleton<DbConnectionFactory>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

var app = builder.Build();

// Configuring the HTTP Request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
