using ProjectManager.Api.DTOs;

namespace ProjectManager.Api.Services;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginRequest request);
}
