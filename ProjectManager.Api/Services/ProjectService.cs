using Microsoft.AspNetCore.Http.HttpResults;
using ProjectManager.Api.Models;
using ProjectManager.Api.Repositories;

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
}
