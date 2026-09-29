using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Api.Services;

namespace ProjectManager.Api.Controllers;

[ApiController]
[Authorize]
[Route("v1/api/projects")]
public class ProjectLookupController : ControllerBase
{
    private readonly IProjectLookupService _projectLookupService;

    public ProjectLookupController(IProjectLookupService projectLookupService)
    {
        _projectLookupService = projectLookupService;
    }

    [HttpGet("priorities")]
    public async Task<IActionResult> GetPriorities()
    {
        var priorities = await _projectLookupService.GetPrioritiesAsync();

        return Ok(priorities);
    }

    [HttpGet("statuses")]
    public async Task<IActionResult> GetStatuses()
    {
        var statuses = await _projectLookupService.GetStatusesAsync();

        return Ok(statuses);
    }
}
