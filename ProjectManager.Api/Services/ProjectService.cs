using Microsoft.AspNetCore.Http.HttpResults;
using ProjectManager.Api.Models;
using ProjectManager.Api.Repositories;
using ProjectManager.Api.DTOs;

namespace ProjectManager.Api.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync(int createdByUserId)
    {
        return await _projectRepository.GetAllAsync(createdByUserId);
    }

    public async Task<int> CreateProjectAsync(CreateProjectRequest request, int createdByUserId)
    {
        return await _projectRepository.CreateAsync(request, createdByUserId);
    }

    public async Task<bool> UpdateProjectAsync(int projectId, CreateProjectRequest request, int createdByUserId)
    {
        return await _projectRepository.UpdateAsync(projectId, request, createdByUserId);
    }

    public async Task<bool> DeleteProjectAsync(int projectId, int createdByUserId)
    {
        return await _projectRepository.DeleteAsync(projectId, createdByUserId);
    }

    public async Task<bool> CompleteProjectAsync(int projectId, int createdByUserId)
    {
        return await _projectRepository.CompleteAsync(projectId, createdByUserId);
    }
}
