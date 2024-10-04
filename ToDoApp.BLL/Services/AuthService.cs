using ErrorOr;
using Microsoft.AspNetCore.Identity;
using ToDoApp.BLL.Common.Errors;
using ToDoApp.BLL.DTOs.Auth;
using ToDoApp.BLL.Mapping;
using ToDoApp.BLL.Services.Interfaces;

namespace ToDoApp.BLL.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IJwtTokenService _tokenService;
    
    public AuthService(
        UserManager<IdentityUser> userManager,
        IJwtTokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<ErrorOr<AuthResultDto>> Register(AuthRequestDto requestDto)
    {
        var existingUser = await _userManager.FindByEmailAsync(requestDto.Email);
        if (existingUser is not null)
        {
            return AuthErrors.UserAlreadyExist;
        }

        var newUser = requestDto.ToIdentityUser();
        var identityResult = await _userManager.CreateAsync(newUser, requestDto.Password);

        if (!identityResult.Succeeded)
            return AuthErrors.UserCreationFailed;
        
        return new AuthResultDto()
        {
            Email = newUser.Email, 
            Token =  _tokenService.GenerateJwtToken(newUser)
        };
    }

    public async Task<ErrorOr<AuthResultDto>> Login(AuthRequestDto requestDto)
    {
        var user = await _userManager.FindByEmailAsync(requestDto.Email);
        if (user is null)
            return AuthErrors.UserNotFound;
        
        var passwordCorrect = await _userManager.CheckPasswordAsync(user, requestDto.Password);
        if (!passwordCorrect)
            return AuthErrors.InvalidCredentials;
        
        return  new AuthResultDto()
        {
            Email = user.Email, 
            Token =  _tokenService.GenerateJwtToken(user)
        };
    }
}