using ProjectManager.Api.DTOs;

namespace ProjectManager.Api.Services;

public interface IProjectLookupService
{
    Task<IEnumerable<PriorityResponse>> GetPrioritiesAsync();
    Task<IEnumerable<ProjectStatusResponse>> GetStatusesAsync();
}
