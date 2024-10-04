namespace ToDoApp.DAL.Common;

public class PagedList<T>
{
    public List<T> Items { get; private set; }
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; }

    public bool HasNextPage => Page * PageSize < TotalCount;
    public bool HasPreviousPage => Page > 1;
    
    public PagedList(List<T> items, int page, int pageSize, int totalCount)
    {
        Items = items ?? new List<T>();
        Page = page > 0 ? page : 1; 
        PageSize = pageSize > 0 ? pageSize : 10; 
        TotalCount = totalCount >= 0 ? totalCount : 0; 
    }
}