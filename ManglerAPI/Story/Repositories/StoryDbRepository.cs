namespace ManglerAPI.Story.Repositories;

using Entities;

public class StoryDbRepository : IStoryRepository
{
    public Task<Story> GetById(long id)
    {
        return null;
    }
}