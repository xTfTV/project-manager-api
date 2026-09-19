using ProjectManager.Api.DTOs;

namespace ProjectManager.Api.Services;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}
