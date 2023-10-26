using System.ComponentModel;
using Mangler.Common.Monads;
using ManglerAPI.Entities;
using ManglerAPI.Infrastructure.Entities;
using ManglerAPI.Infrastructure.ErrorHandling;
using ManglerAPI.Infrastructure.Localization;
using ManglerAPI.Infrastructure.Validation;
using ManglerAPI.Stories.Entities;
using ManglerAPI.StoryLines.Entities;

namespace ManglerAPI.Stories.Models;

[Serializable]
public class StoryPostRequest
{
    public string Title { get; set; }
    public StoryClientType ClientType { get; set; } = StoryClientType.Discord;
    public string AuthorUserIdentifier { get; set; }
    public string GroupIdentifier { get; set; } 
    public string FirstLine { get; set; }
}

public static class StoryPostRequestExtensions
{
    public static Result ValidateRequest(this StoryPostRequest request) => Validate.Begin()
        .Then(Validate.ThatStringIsNotEmpty(request.Title, ErrorCode.TitleIsRequired,"Title is required"))
        .Then(Validate.ThatStringLengthIsInRange(request.Title, 1,100, ErrorCode.TitleLengthInvalid, "Title must be between 1-100 characters"))
        .Then(Validate.ThatStringIsNotEmpty(request.FirstLine, ErrorCode.FirstLineIsRequired, "For new stories, the author must provide the first line"))
        .Then(Validate.ThatStringIsNotEmpty(request.AuthorUserIdentifier, ErrorCode.InvalidUserId, "UserID is required for new stories."))
        .Then(Validate.ThatEnumIsDefined(request.ClientType, ErrorCode.InvalidClientType, "Invalid client type specified"));
    
    public static Story MapToNewEntity(this StoryPostRequest r) 
    {
        var now = DateTime.UtcNow;
        var mappedClientType = r.ClientType == StoryClientType.Discord ? ClientType.Discord : ClientType.Web;

        return new Story()
        {
            Title = r.Title,
            ClientType = mappedClientType,
            AuthorUserIdentifier = r.AuthorUserIdentifier,
            GroupIdentifier = r.GroupIdentifier,
            CreateDt = now,
            Lines = new List<StoryLine>()
            {
                new StoryLine()
                {
                    ClientType = mappedClientType,
                    AuthorUserIdentifier = r.AuthorUserIdentifier,
                    Text = r.FirstLine,
                    CreateDt = now,
                    CompleteDt = now
                }

            }
        };
    }



}