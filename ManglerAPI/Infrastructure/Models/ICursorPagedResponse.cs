namespace ManglerAPI.Infrastructure.Models;

public interface ICursorPagedResponse
{
    string NextCursor { get; }
}