using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ProjectManager.Api.DTOs;

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
