using ProjectManager.Api.Models;
using ProjectManager.Api.DTOs;

namespace ProjectManager.Api.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync(int createdByUserId);

    Task<int> CreateAsync(CreateProjectRequest request, int createdByUserId);

    Task<bool> UpdateAsync(int projectId, CreateProjectRequest request, int createdByUserId);

    Task<bool> DeleteAsync(int projectId, int createdByUserId);

    Task<bool> CompleteAsync(int projectId, int createdByUserId);
}
