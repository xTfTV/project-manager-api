using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ProjectManager.Api.DTOs;

public class LoginRequest
{
    public string EmailAddress { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
