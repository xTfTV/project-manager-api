using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ProjectManager.Api.Services;

namespace ProjectManager.Api.Controllers;

[ApiController]
[Authorize]
[Route("v1/api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdValue, out var userId))
        {
            return Unauthorized(new
            {
                message = "User Id claim is missing or invalid"
            });
        }

        var projects = await _projectService.GetAllProjectsAsync(userId);

        return Ok(projects);
    }
}
