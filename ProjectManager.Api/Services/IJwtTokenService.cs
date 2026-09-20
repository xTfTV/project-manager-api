using ProjectManager.Api.Models;

namespace ProjectManager.Api.Services;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
