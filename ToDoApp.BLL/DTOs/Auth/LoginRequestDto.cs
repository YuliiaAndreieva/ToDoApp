﻿namespace ToDoApp.BLL.DTOs.Auth;

public record LoginRequestDto(
    string Email,
    string Password
    );