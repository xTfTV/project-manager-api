
using ProjectManager.Api.Configuration;
using ProjectManager.Api.Data;
using ProjectManager.Api.Models;
using ProjectManager.Api.Repositories;
using ProjectManager.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add the services to the container
builder.Services.AddControllers();

// Adding the DB Connection options
builder.Services.Configure<DatabaseOptions>(
    builder.Configuration.GetSection(DatabaseOptions.SectionName)
);

// Registering the DB Connection
builder.Services.AddSingleton<DbConnectionFactory>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

// Adding swagger
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuring the HTTP Request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
