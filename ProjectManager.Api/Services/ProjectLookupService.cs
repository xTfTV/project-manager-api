using ProjectManager.Api.DTOs;
using ProjectManager.Api.Repositories;

namespace ProjectManager.Api.Services;

public class ProjectLookupService : IProjectLookupService
{
    private readonly IProjectLookupRepository _projectLookupRepository;

    public ProjectLookupService(IProjectLookupRepository projectLookupRepository)
    {
        _projectLookupRepository = projectLookupRepository;
    }

    public async Task<IEnumerable<PriorityResponse>> GetPrioritiesAsync()
    {
        return await _projectLookupRepository.GetPrioritiesAsync();
    }

    public async Task<IEnumerable<ProjectStatusResponse>> GetStatusesAsync()
    {
        return await _projectLookupRepository.GetStatusesAsync();
    }
}
