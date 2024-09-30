using Microsoft.AspNetCore.Identity.Data;
using ToDoApp.API.Contracts.Requests.Category;
using ToDoApp.API.Contracts.Requests.Task;
using ToDoApp.BLL.DTOs.Auth;
using ToDoApp.BLL.DTOs.Category;
using ToDoApp.BLL.DTOs.Task;

namespace ToDoApp.API.Mapping;

public static class RequestsMapping
{
    public static RegisterRequestDto ToRegisterRequestDto(
        this RegisterRequest registerRequest)
    {
        return new RegisterRequestDto(
            Name: registerRequest.Email,
            Email: registerRequest.Email,
            Password: registerRequest.Password
        );
    }
    
    public static LoginRequestDto ToLoginRequestDto(
        this LoginRequest loginRequest)
    {
        return new LoginRequestDto(
            Email: loginRequest.Email,
            Password: loginRequest.Password
        );
    }

    public static CreateCategoryDto ToDto(
        this CreateCategoryRequest createCategoryRequest)
    {
        return new CreateCategoryDto()
        {
            Name = createCategoryRequest.Name
        };
    }
    
    public static PagedUserTasksDto ToDto(
        this GetPagedUserTasksRequest getPagedTasksRequest)
    {
        return new PagedUserTasksDto()
        {
            CategoryIds = getPagedTasksRequest.CategoryIds,
            Page = getPagedTasksRequest.Page,
            PageSize = getPagedTasksRequest.PageSize,
            SearchString = getPagedTasksRequest.SearchTerm,
            Items =  new List<UserTaskDto>()
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
            CategoryIds= request.CategoryIds
        };
    }
}