using System.Linq.Expressions;
using ToDoApp.DAL.Entities;

namespace ToDoApp.DAL.Specifications;

public class CategorySpecification : Specification<UserTask>
{
    private readonly List<int> _categoryIds;
    public CategorySpecification(List<int> categoryIds)
    {
        _categoryIds = categoryIds;
    }

    public override Expression<Func<UserTask, bool>> ToExpression()
    {
        return task => task.Categories.Any(c => _categoryIds.Contains(c.Id));
    }
}