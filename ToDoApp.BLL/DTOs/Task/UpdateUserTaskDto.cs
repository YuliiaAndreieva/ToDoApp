﻿namespace ToDoApp.BLL.DTOs.Task;

public class UpdateUserTaskDto : BaseUserTaskDto
{
    public int Id { get; set; }
    
    public bool IsDone { get; set; }
}