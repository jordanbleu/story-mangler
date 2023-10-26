using Mangler.Common.Monads;
using ManglerAPI.Infrastructure.ErrorHandling;
using ManglerAPI.Infrastructure.Localization;
using ManglerAPI.Infrastructure.Models;
using ManglerAPI.Infrastructure.Mongo;
using ManglerAPI.Stories.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ManglerAPI.Stories.Repositories;

public interface IStoryRepository
{
    Task<Result<Story>> GetById(string id);
    Task<Result<Story>> Create(Story story);
    Task<Result<List<Story>>> GetList(string cursor, int maxResults);
    Task<Result<List<Story>>> GetOpenStoriesForGroup(string groupIdentifier);
    Task<Result<int>> GetOpenStoriesCountForGroup(string groupIdentifier);
}

public class StoryMongoRepository : IStoryRepository
{
    private readonly IMongoQueryable<Story> _stories;
    private readonly IMongoCollection<Story> _storyDb;

    public StoryMongoRepository(MongoClientFactory clientFactory)
    {
        var mongo= clientFactory.GetQueryable<Story>("Stories");
        _storyDb = mongo.collection;
        _stories = mongo.queryable;
    }

    public async Task<Result<Story>> GetById(string id)
    {
        if (!ObjectId.TryParse(id, out var oId))
        {
            return Result<Story>.Failure(ErrorCode.IdImproperFormat, $"ID is not formatted properly.");
        }

        return await Result<Story>.WrapAsync(()=>_stories.FirstOrDefaultAsync(s => s.Id == oId), errorCodeOnError:ErrorCode.InternalServerError);
    }

    public Task<Result<Story>> Create(Story story) => Result<Story>.WrapAsync(async () =>
    {
        await _storyDb.InsertOneAsync(story);
        return story;
    });

    public Task<Result<List<Story>>> GetList(string cursor, int maxResults) =>
        Result<List<Story>>.WrapAsync(() => _stories.Take(maxResults).ToListAsync());

    
    public Task<Result<List<Story>>> GetOpenStoriesForGroup(string groupIdentifier) => Result<List<Story>>.WrapAsync( () =>
    {
        return _stories
            .Where(s => s.GroupIdentifier == groupIdentifier)
            .Where(s => s.CompleteDt == null)
            .ToListAsync();
    });

    public Task<Result<int>> GetOpenStoriesCountForGroup(string groupIdentifier)=> Result<int>.WrapAsync( () =>
    {
        return _stories
            .Where(s => s.GroupIdentifier == groupIdentifier)
            .Where(s => s.CompleteDt == null)
            .CountAsync();
    });
}