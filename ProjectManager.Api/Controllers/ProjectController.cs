using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ProjectManager.Api.Services;
using ProjectManager.Api.DTOs;
using ProjectManager.Api.Models;

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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectRequest request)
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdValue, out var userId))
        {
            return Unauthorized(new { message = "User ID claim is missing or invalid." });
        }

        var projectId = await _projectService.CreateProjectAsync(request, userId);

        return CreatedAtAction(nameof(GetAll), new { id = projectId }, new { projectId, message = "Project Created Successfully" });
    }

    [HttpPut("{projectId:int}")]
    public async Task<IActionResult> Update(int projectId, [FromBody] CreateProjectRequest request)
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdValue, out var userId))
        {
            return Unauthorized(new { message = "User ID claim is missing or invalid" });
        }

        var updated = await _projectService.UpdateProjectAsync(projectId, request, userId);

        if (!updated)
        {
            return NotFound(new { message = "Project not found or you do not have permission to update it" });
        }

        return Ok(new { message = "Project updated successfully" });
    }
}
