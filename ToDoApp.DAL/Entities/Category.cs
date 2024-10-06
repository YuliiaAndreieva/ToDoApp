using Microsoft.AspNetCore.Identity;

namespace ToDoApp.DAL.Entities;

public class Category
{
    public int Id { get; set; }
    
    public string UserId { get; set; }
    
    public IdentityUser User { get; set; }
    
    public string Name { get; set; } = default!;
    
    public List<UserTask> Tasks { get; set; }
}