using ManglerAPI.Infrastructure.Models;

namespace ManglerAPI.Models;

public class StoryListRequestModel : ICursorPaginationRequest
{
    public string GuildIdentifier { get; set; }
    public string AuthorIdentifier { get; set; }
    public string Cursor { get; set; }
    public int PageSize { get; set; }
}

