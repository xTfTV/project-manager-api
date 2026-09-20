using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ProjectManager.Api.Models;

public class User
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public int? UserRoleId { get; set; }
    public int? LogicalCancelValue { get; set; }
    public DateTime? CreatedDate { get; set; }
}
