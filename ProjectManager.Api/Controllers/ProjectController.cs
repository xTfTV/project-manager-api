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

    [HttpDelete("{projectId:int}")]
    public async Task<IActionResult> Delete(int projectId)
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdValue, out var userId))
        {
            return Unauthorized(new { message = "User ID claim is missing or invalid" });
        }

        var deleted = await _projectService.DeleteProjectAsync(projectId, userId);

        if (!deleted)
        {
            return NotFound(new { message = "Project not found or you do not have permission to delete it." });
        }

        return Ok(new { message = "Project was deleted successfully" });
    }

    [HttpPatch("{projectId:int}/complete")]
    public async Task<IActionResult> Complete(int projectId)
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdValue, out var userId))
        {
            return Unauthorized(new { message = "User ID claim is missing or invalid" });
        }

        var completed = await _projectService.CompleteProjectAsync(projectId, userId);

        if (!completed)
        {
            return NotFound(new { message = "Project not found or you do not have permission to complete it" });
        }

        return Ok(new { message = "Project completed successfully" });
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetByFilter([FromQuery] ProjectQueryRequest request)
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdValue, out var userId))
        {
            return Unauthorized(new { message = "User ID claim is missing or invalid." });
        }

        if (request.Page < 1)
        {
            return BadRequest(new { message = "Page must be greater than 0" });
        }

        if (request.PageSize < 1)
        {
            return BadRequest(new { message = "Page size must be greater than 0" });
        }

        if (request.ProjectStatusId.HasValue && request.ProjectStatusId is < 1 or > 3)
        {
            return BadRequest(new { message = "Project status must be 1, 2, or 3" });
        }

        var result = await _projectService.GetProjectsByFilterAsync(request, userId);

        return Ok(result);
    }
}
