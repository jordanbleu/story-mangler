namespace ManglerAPI.Story.Repositories;

using Entities;

public class StoryDbRepository : IStoryRepository
{
    public Task<Story> GetById(long id)
    {
        // todo: stubbed data.
        return Task.FromResult(new Story(123, 1234, "Example Story"));
    }
}