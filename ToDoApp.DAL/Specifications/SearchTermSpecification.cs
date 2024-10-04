using System.Linq.Expressions;
using ToDoApp.DAL.Entities;

namespace ToDoApp.DAL.Specifications;

public class SearchTermSpecification : Specification<UserTask>
{
    private readonly string _searchTerm;
    public SearchTermSpecification(string searchTerm)
    {
        _searchTerm = searchTerm;
    }

    public override Expression<Func<UserTask, bool>> ToExpression()
    {
        if (string.IsNullOrEmpty(_searchTerm))
        {
            return task => true;
        }
        
        return task => task.Name.Contains(_searchTerm) 
                       || (task.Description != null && task.Description.Contains(_searchTerm));
    }
}