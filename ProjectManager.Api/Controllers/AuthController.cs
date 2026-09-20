using Microsoft.AspNetCore.Mvc;
using ProjectManager.Api.DTOs;
using ProjectManager.Api.Services;

namespace ProjectManager.Api.Controllers;

[ApiController]
[Route("v1/api[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);

        if (!result.Response.Success || string.IsNullOrWhiteSpace(result.Token))
        {
            return Unauthorized(result);
        }

        Response.Cookies.Append("access_token", result.Token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddHours(8)
        });
        
        return Ok(result.Response);
    }
}
