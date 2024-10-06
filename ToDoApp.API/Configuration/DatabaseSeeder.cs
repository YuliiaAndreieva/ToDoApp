using Microsoft.AspNetCore.Identity;
using ToDoApp.DAL.Data;

namespace ToDoApp.API.Configuration;

public class DatabaseSeeder
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseSeeder(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task SeedAsync()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ToDoAppDbContext>();
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

                var seeder = new DataSeeder(context, userManager);
                await seeder.SeedDataAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while seeding the database: {ex.Message}");
            }
        }
    }
}