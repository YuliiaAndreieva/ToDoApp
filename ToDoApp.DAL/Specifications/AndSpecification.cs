using System.Linq.Expressions;

namespace ToDoApp.DAL.Specifications;

public class AndSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;
 
    public AndSpecification(Specification<T> left, Specification<T> right)
    {
        _right = right;
        _left = left;
    }
 
    public override Expression<Func<T , bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();
        
        var parameter = Expression.Parameter(typeof(T));
        var leftBody = Expression.Invoke(leftExpression, parameter);
        var rightBody = Expression.Invoke(rightExpression, parameter);

        var andExpression = Expression.AndAlso(leftBody, rightBody);

        return Expression.Lambda<Func<T, bool>>(andExpression, parameter);
    }
}