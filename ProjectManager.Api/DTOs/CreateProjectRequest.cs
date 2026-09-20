namespace ProjectManager.Api.DTOs;

public class CreateProjectRequest()
{
    public string ProjectName { get; set; } = string.Empty;
    public int PriorityId { get; set; }
    public int ProjectStatusId { get; set; }
    public DateTime? ProjectDueDate {get; set;}
    public string? Comments { get; set; }
}
