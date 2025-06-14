using AutoService.Shared.Models;
using AuthService.Api.Services;
using Microsoft.AspNetCore.Mvc;

public record LoginRequest(string Username, string Password);
public record RegisterRequest(string Username, string Password);

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public ActionResult<User> Login([FromBody] LoginRequest request)
    {
        var user = _userService.AuthenticateUser(request.Username, request.Password);
        if (user == null)
        {
            return Unauthorized("Invalid username or password.");
        }
        return Ok(user);
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        bool success = _userService.RegisterUser(request.Username, request.Password);
        if (!success)
        {
            return Conflict("User with this name already exists.");
        }
        return Ok("User registered successfully.");
    }
}