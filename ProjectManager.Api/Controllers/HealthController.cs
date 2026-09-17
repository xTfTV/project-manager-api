using Microsoft.AspNetCore.Mvc;
using ProjectManager.Api.Data;

namespace ProjectManager.Api.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
public class HealthController : ControllerBase
{

    private readonly DbConnectionFactory _dbConnectionFactory;

    public HealthController(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "ok",
            service = "ProjectManager.Api",
            timestamp = DateTime.UtcNow
        });
    }

    [HttpGet("database")]
    public async Task<IActionResult> GetDatabaseHealth()
    {
        await using var connection = _dbConnectionFactory.CreateConnection();

        await connection.OpenAsync();

        return Ok(new
        {
            status = "Ok",
            database = connection.Database,
            timestamp = DateTime.UtcNow
        });
    }
}
