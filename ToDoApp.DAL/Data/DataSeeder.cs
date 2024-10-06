using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DAL.Entities;

namespace ToDoApp.DAL.Data;

public class DataSeeder
{
    private readonly ToDoAppDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public DataSeeder(ToDoAppDbContext dbContext,
        UserManager<IdentityUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }
    
    public async Task SeedDataAsync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
        await _dbContext.Database.MigrateAsync();
        
        var user = new IdentityUser
        {
            UserName = "testuser",
            Email = "testuser@example.com"
        };

        var result = await _userManager.CreateAsync(user, "YourStrongP@ssword123");
        
        var categories = new List<Category>
        {
            new Category { Name = "Work" },
            new Category { Name = "University" },
            new Category { Name = "Languages" }
        };

        _dbContext.Categories.AddRange(categories);
        await _dbContext.SaveChangesAsync();
        
        var tasks = new List<UserTask>()
        {
            new UserTask()
            {
                Name = "Do cross-platform lab1",
                UserId = user.Id,
                IsDone = false, 
                Description = "i need to do 13 labs, for 1-3 lab deadline is over",
                DueDate = DateTime.Now.AddDays(2),
                Categories = new List<Category>() {categories.ElementAt(1)}
            },
            new UserTask()
            {
                Name = "Do 5 lessons on Monday", 
                IsDone = false, 
                UserId = user.Id,
                DueDate = DateTime.Now.AddDays(3),
                Description = "lessons with Oleksandr, Gleb, Victoria. for lesson with Gleb i need to prepare a worksheet",
                Categories = new List<Category>() {categories.ElementAt(0)}
            },
            new UserTask()
            {
                Name = "Make a presentation with perfect tenses", 
                IsDone = false, 
                UserId = user.Id,
                DueDate = DateTime.Now.AddDays(4),
                Description = "some drafts ive already created in canva",
                Categories = new List<Category>() {categories.ElementAt(0)}
            },
            new UserTask()
            {
                Name = "Do front-end lab 3-5", 
                IsDone = false, 
                UserId = user.Id,
                DueDate = DateTime.Now.AddDays(5),
                Description = "ive done 1-2 labs, it's deadline for 3rd",
                Categories = new List<Category>() {categories.ElementAt(1)}
            },
            new UserTask()
            {
                Name = "Prepare for ielts", 
                UserId = user.Id,
                IsDone = false, 
                DueDate = DateTime.Now.AddDays(1),
                Categories = new List<Category>() {categories.ElementAt(2)}
            },
            new UserTask()
            {
                Name = "Prepare for mkr on operating system", 
                UserId = user.Id,
                IsDone = false, 
                DueDate = DateTime.Now.AddDays(2),
                Description = "hurry up",
                Categories = new List<Category>() {categories.ElementAt(2)}
            },
            new UserTask()
            {
                Name = "Make a presentation for philosophy", 
                UserId = user.Id,
                IsDone = false, 
                DueDate = DateTime.Now.AddDays(6),
                Description = "hurry up its up to 2 days",
                Categories = new List<Category>() {categories.ElementAt(2)}
            },
        };
        
        _dbContext.UserTasks.AddRange(tasks);
        await _dbContext.SaveChangesAsync();
    }
}