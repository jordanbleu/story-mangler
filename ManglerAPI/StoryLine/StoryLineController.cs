using ManglerAPI.Story.Controllers.Models;
using ManglerAPI.Story.Repositories;
using ManglerAPI.Story.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.StoryLine;

[Route("/storyLine")]
public class StoryLineController : ControllerBase
{
    private readonly StoryService _storyService;
    private readonly IStoryRepository _storyRepository;

    public StoryLineController(StoryService storyService, IStoryRepository storyRepository)
    {
        _storyService = storyService;
        _storyRepository = storyRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] StoryGetRequest request)
    {
        await Task.CompletedTask;
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(StoryPostRequest request)
    {
        await Task.CompletedTask;
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(StoryDeleteRequest request)
    {
        await Task.CompletedTask;
        return NoContent();
    }



}