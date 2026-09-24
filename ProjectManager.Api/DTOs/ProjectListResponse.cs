using ProjectManager.Api.Models;

namespace ProjectManager.Api.DTOs;

public class ProjectListResponse
{
    public IEnumerable<Project> Projects { get; set; } = Enumerable.Empty<Project>();
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
}
