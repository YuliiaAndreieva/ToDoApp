using ToDoApp.API.Contracts.Responses.Task;
using ToDoApp.BLL.DTOs;
using ToDoApp.BLL.DTOs.Category;
using ToDoApp.BLL.DTOs.Task;
using ToDoApp.DAL.Common;

namespace ToDoApp.API.Mapping;

public static class ResponsesMapping
{
    public static PagedUserTasksResponse ToResponse(
        this PagedList<UserTaskDto> pagedList)
    {
        return new PagedUserTasksResponse(
            pagedList.Page,
            pagedList.PageSize,
            pagedList.HasPreviousPage,
            pagedList.HasNextPage,
            pagedList.TotalCount,
            pagedList.Items.ToResponse()
        );
    }

    public static List<UserTaskShortResponse> ToResponse(
        this List<UserTaskDto> userTaskDtos)
    {
         return userTaskDtos.Select(dto => new UserTaskShortResponse(
             dto.Id,
             dto.Name,
             dto.IsDone,
             dto.CategoryDtos.Select(c => new CategoryDto { Id = c.Id, Name = c.Name }).ToList()
         )).ToList();
    }
}