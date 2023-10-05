namespace ManglerAPI.Story.Repositories;
using Entities;

public interface IStoryRepository
{
    Task<Story> GetById(long id);
}