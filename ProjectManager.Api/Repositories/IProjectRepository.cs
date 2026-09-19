using ProjectManager.Api.Models;

namespace ProjectManager.Api.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync();
}
