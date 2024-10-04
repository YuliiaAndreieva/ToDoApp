using Microsoft.AspNetCore.Identity;

namespace ToDoApp.DAL.Entities;

public class UserTask
{
    public int Id { get; set; }
    
    public string UserId { get; set; }
    
    public IdentityUser User { get; set; }
    
    public string Name { get; set; } = default!;

    public string? Description { get; set; } 
    
    public DateTime DueDate { get; set; }
    
    public bool IsDone { get; set; }

    public List<Category>? Categories { get; set; }
}