﻿using Microsoft.AspNetCore.Identity.Data;
using ToDoApp.API.Contracts.Requests.Auth;
using ToDoApp.API.Contracts.Requests.Category;
using ToDoApp.API.Contracts.Requests.Task;
using ToDoApp.BLL.DTOs.Auth;
using ToDoApp.BLL.DTOs.Category;
using ToDoApp.BLL.DTOs.Task;

namespace ToDoApp.API.Mapping;

public static class RequestsMapping
{
    public static AuthRequestDto ToAuthRequestDto(
        this AuthRequest authRequest)
    {
        return new AuthRequestDto()
        {
            Email = authRequest.Email,
            Password = authRequest.Password
        };
    }

    public static CreateCategoryDto ToDto(
        this CreateCategoryRequest createCategoryRequest)
    {
        return new CreateCategoryDto()
        {
            Name = createCategoryRequest.Name
        };
    }
    
    public static PagedUserTasksRequestDto ToDto(
        this GetPagedUserTasksRequest getPagedTasksRequest)
    {
        return new PagedUserTasksRequestDto()
        {
            CategoryIds = getPagedTasksRequest.CategoryIds,
            PageSize = getPagedTasksRequest.PageSize,
            Page = getPagedTasksRequest.Page,
            SearchTerm = getPagedTasksRequest.SearchTerm
        };
    }

    public static UserTaskCategoriesDto ToDto(
        this AddCategoriesRequest request,
        int taskId)
    {
        return new UserTaskCategoriesDto()
        {
            TaskId = taskId,
            CategoryIds = request.CategoryIds
        };
    }

    public static CreateUserTaskDto ToDto(
        this CreateUserTaskRequest request)
    {
        return new CreateUserTaskDto()
        {
            Name = request.Name,
            Description = request.Description,
            DueDate = request.DueDate,
            CategoryIds= request.CategoryIds,
            IsDone = request.IsDone
        };
    }
    
    public static UpdateUserTaskDto ToDto(
        this (int Id, UpdateUserTaskRequest Request) tuple)
    {
        return new ()
        {
            Id = tuple.Id,
            Name = tuple.Request.Name,
            Description = tuple.Request.Description,
            DueDate = tuple.Request.DueDate,
            IsDone = tuple.Request.IsDone,
            CategoryIds = tuple.Request.CategoryIds
        };
    }
}