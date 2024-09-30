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
            CategoryIds = getPagedTasksRequest.categoryIds,
            Page = getPagedTasksRequest.page,
            PageSize = getPagedTasksRequest.pageSize,
            SearchString = getPagedTasksRequest.searchTerm,
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
            CategoriesIds = request.categoryIds
        };
    }
}