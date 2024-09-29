using Microsoft.AspNetCore.Identity;

namespace ToDoApp.BLL.Services.Interfaces;

public interface IJwtTokenService
{
    string GenerateJwtToken(IdentityUser user);
}