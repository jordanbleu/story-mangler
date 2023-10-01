using ManglerAPI.Story.Controllers.Models;
using ManglerAPI.Story.Repositories;
using ManglerAPI.Story.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.Story;

[Route("/story")]
public class StoryController : ControllerBase
{
    private readonly StoryService _storyService;
    private readonly IStoryRepository _storyRepository;

    public StoryController(StoryService storyService, IStoryRepository storyRepository)
    {
        _storyService = storyService;
        _storyRepository = storyRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] StoryGetRequest request)
    {
        var story = await _storyRepository.GetById(request.Id);

        return Ok(new StoryGetResponse()
        {
            Id = story.Id,
            Title = story.Title
        });
    }



}