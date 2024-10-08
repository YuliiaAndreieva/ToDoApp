﻿using ErrorOr;
using ToDoApp.DAL.Common;
using ToDoApp.DAL.Entities;
using ToDoApp.DAL.Specifications;

namespace ToDoApp.DAL.Repositories.Interfaces;

public interface IUserTaskRepository
{
    Task<ErrorOr<UserTask>> AddCategoriesAsync(
        int userTaskId, 
        List<int> categoryIds);

    Task<ErrorOr<UserTask>> CreateUserTask(
        UserTask userTask,
        List<int>? categoryIds);

    Task<ErrorOr<Deleted>> DeleteUserTask(
        int taskId);

    Task<ErrorOr<UserTask>> UpdateUserTaskAsync(
        UserTask updatedUserTask,
        List<int>? categoryIds);

    Task<PagedList<UserTask>> GetPagedTasksAsync(
        Specification<UserTask> specification,
        int page,
        int pageSize);

    Task<UserTask?> FindUserTaskByIdAsync(
        int userTaskId);
}