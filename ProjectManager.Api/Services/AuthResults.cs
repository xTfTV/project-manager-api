using ProjectManager.Api.DTOs;

namespace ProjectManager.Api.Services;

public class AuthResult
{
    public LoginResponse Response { get; set; } = new();
    public string? Token { get; set; }
}
