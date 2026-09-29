using ProjectManager.Api.DTOs;

namespace ProjectManager.Api.Repositories;

public interface IProjectLookupRepository
{
    Task<IEnumerable<PriorityResponse>> GetPrioritiesAsync();

    Task<IEnumerable<ProjectStatusResponse>> GetStatusesAsync();
}
