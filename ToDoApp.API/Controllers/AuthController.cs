using ErrorOr;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.Mapping;
using ToDoApp.BLL.Services.Interfaces;

namespace ToDoApp.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(
        ILogger<AuthController> logger,
        IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(Error.Validation());

        var result = await _authService.Register(registerRequest.ToRegisterRequestDto());

        return result.Match<IActionResult>(
            userDto => Created($"/user/{userDto.Email}", userDto), 
            errors => Problem(errors.ToResponse()) 
        );
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(Error.Validation());

        var result = await _authService.Login(loginRequest.ToLoginRequestDto());

        return result.Match<IActionResult>(
            userDto => Ok(userDto), 
            errors => Problem(errors.ToResponse()) 
        );
    }
}