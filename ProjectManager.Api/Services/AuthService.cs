using ProjectManager.Api.DTOs;
using ProjectManager.Api.Repositories;

namespace ProjectManager.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthService(IUserRepository userRepository, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<AuthResult> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.EmailAddress);

        if (user == null)
        {
            return new AuthResult
            {
                Response = new LoginResponse
                {
                    Success = false,
                    Message = "Invalid email or password"
                }
            };
        }

        var passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!passwordValid)
        {
            return new AuthResult
            {
                Response = new LoginResponse
                {
                    Success = false,
                    Message = "Password is incorrect"
                }
            };
        }

        var token = _jwtTokenService.GenerateToken(user);

        return new AuthResult
        {
            Response = new LoginResponse
            {
                Success = true,
                Message = "Login successful"    
            },
            Token = token
        };
    }
}
