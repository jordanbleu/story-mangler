using ManglerAPI.Repositories;
using ManglerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.Controllers;

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

    /// <summary>
    /// Retrieve the specified count of story lines.
    /// </summary>
    /// <param name="storyId">story id</param>
    /// <param name="count">How many lines to retrieve</param>
    /// <param name="reverseSort">if true, will return lines latest -> oldest.  This is the default.</param>
    [HttpGet]
    [Route("/story/{storyId}/lines")]
    public async Task<IActionResult> GetList([FromRoute] int storyId, [FromQuery] int? count = null, [FromQuery] bool reverseSort = true)
    {
        await Task.Delay(100);
        return Ok();
    }

    /// <summary>
    /// Returns a single story line by ID
    /// </summary>
    [HttpGet]
    [Route("/story/{storyId}/line/{lineId}")]
    public async Task<IActionResult> Get([FromRoute] int storyId, [FromRoute] int lineId)
    {
        await Task.Delay(100);
        return Ok(); 
    }

    /// <summary>
    /// Creates a new story line for the given story.
    /// </summary>
    [HttpPost]
    [Route("/story/{id}/lines")]
    public async Task<IActionResult> Post([FromRoute] int storyId)
    {
        await Task.Delay(100);
        return Ok();
    }

    /// <summary>
    /// Updates a story line by id
    /// </summary>
    [HttpPut]
    [Route("/story/{storyId}/line/{lineId}")]
    public async Task<IActionResult> Put([FromRoute] int storyId, [FromRoute] int lineId)
    {
        await Task.Delay(100);
        return Ok();
    }



}