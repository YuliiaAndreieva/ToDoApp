﻿using FluentValidation;
using ToDoApp.BLL.DTOs.Task;

namespace ToDoApp.BLL.Validation.UserTask;

public class CreateUserTaskDtoValidator : AbstractValidator<CreateUserTaskDto>
{
    public CreateUserTaskDtoValidator()
    {
        Include(new BaseUserTaskDtoValidator());
    }
}