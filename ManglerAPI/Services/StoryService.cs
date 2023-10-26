using Mangler.Common.Monads;
using ManglerAPI.Infrastructure.ErrorHandling;
using ManglerAPI.Infrastructure.Options;
using ManglerAPI.Stories.Entities;
using ManglerAPI.Stories.Repositories;
using Microsoft.Extensions.Options;

namespace ManglerAPI.Services;

public class StoryService
{
    private readonly GlobalRules _rules;
    private readonly IStoryRepository _storyRepository;

    public StoryService(IStoryRepository storyRepository, IOptions<GlobalRules> globalRulesOption)
    {
        _storyRepository = storyRepository;
        _rules = globalRulesOption.Value;
    }

    public async Task<Result> CreateStory(Story story, string firstLine)
    {
        var openStoriesCount = await _storyRepository.GetOpenStoriesCountForGroup(story.GroupIdentifier);

        if (openStoriesCount.IsFailure())
        {
            return openStoriesCoun    
        }
    

        if (openStoriesCount > _rules.MaxOpenStoriesPerGroup)
        {
            return Result.Failure(ErrorCode.TooManyOpenStories
        }

    }




}