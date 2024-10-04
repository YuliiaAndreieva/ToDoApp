using System.Linq.Expressions;
using ToDoApp.DAL.Entities;

namespace ToDoApp.DAL.Specifications;

public class UserIdSpecification : Specification<UserTask>
{
    private readonly string _userId;

    public UserIdSpecification(string userId)
    {
        _userId = userId;
    }

    public override Expression<Func<UserTask, bool>> ToExpression()
    {
        return task => task.UserId == _userId;
    }
}