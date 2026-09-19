using Microsoft.AspNetCore.Mvc;
using ProjectManager.Api.Repositories;

namespace ProjectManager.Api.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;

    public ProjectsController(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int userId)
    {
        var projects = await _projectRepository.GetAllAsync(userId);

        return Ok(projects);
    }
}
