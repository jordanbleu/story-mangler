namespace ManglerAPI.Infrastructure.Models;

public interface ICursorPaginationRequest
{
    string Cursor { get; }
    int PageSize { get; }
}

public interface ICursorPaginationResponse
{
    string Cursor { get; }
}

public class CursorPaginatedList<T> : ICursorPaginationResponse
{
    public string Cursor { get; set; }
    public List<T> Items { get; set; }
}