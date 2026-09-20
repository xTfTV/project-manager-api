using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetAll([FromQuery] int userId)
    {
        var projects = await _projectService.GetAllProjectsAsync(userId);

        return Ok(projects);
    }
}
