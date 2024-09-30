namespace ToDoApp.BLL.DTOs;

public class PagedList<T>
{
    public List<T> Items { get; set; } 

    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalCount => Items.Count;

    public bool HasNextPage => Page * PageSize < TotalCount;

    public bool HasPreviousPage => Page > 1;
}