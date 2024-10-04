using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.Contracts.Requests.Auth;
using ToDoApp.API.Mapping;
using ToDoApp.BLL.DTOs.Auth;
using ToDoApp.BLL.Services.Interfaces;

namespace ToDoApp.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(
        IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AuthRequest registerRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(Error.Validation());

        var result = await _authService.Register(registerRequest.ToAuthRequestDto());

        return result.Match<IActionResult>(
            userDto => Created($"/user/{userDto.Email}", userDto), 
            errors => Problem(errors.ToResponse()) 
        );
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequest loginRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(Error.Validation());

        var result = await _authService.Login(loginRequest.ToAuthRequestDto());

        return result.Match<IActionResult>(
            userDto => Ok(userDto), 
            errors => Problem(errors.ToResponse()) 
        );
    }
}