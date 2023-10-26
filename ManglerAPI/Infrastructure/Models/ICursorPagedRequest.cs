namespace ManglerAPI.Infrastructure.Models;

public interface ICursorPagedRequest
{
    int PageSize { get; }
    string Cursor { get; }
}