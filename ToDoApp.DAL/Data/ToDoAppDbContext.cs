using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DAL.Entities;

namespace ToDoApp.DAL.Data;

public class ToDoAppDbContext : IdentityDbContext
{
    public ToDoAppDbContext(
        DbContextOptions<ToDoAppDbContext> contextOptions)
        : base(contextOptions)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<UserTask> UserTasks { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserTask>().ToTable("UserTasks");
        modelBuilder.Entity<Category>().ToTable("Categories");

        modelBuilder.Entity<UserTask>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.Tasks)
            .UsingEntity("CategoriesTasks");
    }
}