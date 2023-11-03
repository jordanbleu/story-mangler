using Mangler.Common.Results;
using ManglerAPI.Entities;

namespace ManglerAPI.Repositories;

public interface IStoryRepository
{
    /// <summary>
    /// Gets a single story with the requested ID, or returns null.
    /// </summary>
    Task<Result<Story>> GetById(long id);
    
    /// <summary>
    /// Gets a list of stories matching the specified criteria.  
    /// </summary>
    /// <param name="guildIdentifier">guild the story is owned by, or null for any guild</param>
    /// <param name="authorIdentifier">author that began the story, or null or any author</param>
    /// <param name="pageSize">how many results to return</param>
    /// <param name="beforeDate">returns stories before this date, or leave null to return latest</param>
    /// <returns></returns>
    Task<Result<IEnumerable<Story>>> GetList(string guildIdentifier, string authorIdentifier, int pageSize,
        DateTime? beforeDate);
}