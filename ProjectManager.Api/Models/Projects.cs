namespace ProjectManager.Api.Models;

public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public int PriorityId { get; set; }
    public int ProjectStatusId { get; set; }
    public DateTime ProjectCreatedDate { get; set; }
    public DateTime? ProjectDueDate { get; set; }
    public string? Comments { get; set; }
    public int CreatedByUserId { get; set; }
    public int LogicalCancelValue { get; set; }
    public DateTime? ProjectCompleteDate { get; set; }
}
