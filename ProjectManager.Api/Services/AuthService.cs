using ProjectManager.Api.DTOs;
using ProjectManager.Api.Repositories;

namespace ProjectManager.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.EmailAddress);

        if (user == null)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Invalid email or password"
            };
        }

        var passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!passwordValid)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Password is incorrect"
            };
        }

        return new LoginResponse
        {
            Success = true,
            Message = "Login successful"
        };
    }
}
