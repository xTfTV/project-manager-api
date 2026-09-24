namespace ProjectManager.Api.DTOs;

public class ProjectQueryRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int? PriorityId { get; set; }
    public int? ProjectStatusId { get; set; }
}
