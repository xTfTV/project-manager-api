
using ProjectManager.Api.Configuration;
using ProjectManager.Api.Data;

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

var app = builder.Build();

// Configuring the HTTP Request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
