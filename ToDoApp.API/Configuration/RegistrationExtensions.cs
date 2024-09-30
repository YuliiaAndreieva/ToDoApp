using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoApp.BLL.Configuration.Settings;
using ToDoApp.BLL.Helpers;
using ToDoApp.BLL.Services;
using ToDoApp.BLL.Services.Interfaces;
using ToDoApp.DAL.Data;
using ToDoApp.DAL.Repositories;
using ToDoApp.DAL.Repositories.Interfaces;


namespace ToDoApp.API.Configuration;

public static class RegistrationExtensions
{
    public static void AddStorage(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (connectionString is null)
            throw new NullReferenceException(nameof(connectionString));
        
        serviceCollection.AddDbContext<ToDoAppDbContext>(options =>
        {
            options.UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);
        });
        
        serviceCollection.AddScoped<IUserTaskRepository, UserTaskRepository>();
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
    }
    
    public static void AddJwtSettings(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var jwtSettingsSection = configuration.GetSection(ConfigurationConstants.JwtSettings);
        var jwtSettings = jwtSettingsSection.Get<JwtSettings>();

        serviceCollection.Configure<JwtSettings>(jwtSettingsSection);
        
        serviceCollection.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwt =>
        {
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            
            jwt.SaveToken = true;
            jwt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true
            };
        });
    }

    public static void AddServices(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IUserTaskService, UserTaskService>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<IJwtTokenService, JwtTokenService>();
        serviceCollection.AddScoped<ICurrentUserService, CurrentUserService>();
    }
}