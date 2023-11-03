using Mangler.Common.Results;
using ManglerAPI.Entities;

namespace ManglerAPI.Services;

public class StoryService
{

    public Result<Story> CreateNewStory(Story createdStory, string firstLine)
    {
        
        return Result<Story>.Success(createdStory);
    }

}