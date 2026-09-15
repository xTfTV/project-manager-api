using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Api.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
public class HealthController : ControllerBase
{
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
}
