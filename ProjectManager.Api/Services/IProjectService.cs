using ProjectManager.Api.Models;

namespace ProjectManager.Api.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllProjectsAsync(int createdByUserId);
}
