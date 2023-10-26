using Mangler.Common.Monads;
using ManglerAPI.Infrastructure.ErrorHandling;
using ManglerAPI.Infrastructure.Localization;
using ManglerAPI.Infrastructure.Models;
using ManglerAPI.Infrastructure.Validation;

namespace ManglerAPI.Stories.Models;

public class StoryListGetRequest : ICursorPagedRequest
{
    public int PageSize { get; set; }
    public string Cursor { get; set; }
    public string GroupIdentifier { get; set; }
    public StoryClientType? ClientType { get; set; }
    public string UserIdentifier { get; set; }
}

public static class StoryListGetRequestExtensions
{
    public static Result ValidateRequest(this StoryListGetRequest request) => Validate.Begin()
        .Then(Validate.ThatIntIsInRange(request.PageSize, 1, 50, ErrorCode.InvalidPageSize, "Page size must be between 1 and 50"));
}