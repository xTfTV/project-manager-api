using ProjectManager.Api.Models;
using ProjectManager.Api.DTOs;

namespace ProjectManager.Api.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllProjectsAsync(int createdByUserId);

    Task<int> CreateProjectAsync(CreateProjectRequest request, int createdByUserId);

    Task<bool> UpdateProjectAsync(int projectId, CreateProjectRequest request, int createdByUserId);

    Task<bool> DeleteProjectAsync(int projectId, int createdByUserId);
}
