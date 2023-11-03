using Mangler.Common.Results;
using ManglerAPI.Entities;
using ManglerAPI.Infrastructure.Models;
using ManglerAPI.Infrastructure.Mvc;
using ManglerAPI.Infrastructure.Validation;
using ManglerAPI.Models;
using ManglerAPI.Repositories;
using ManglerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.Controllers;

/// <summary>
/// A story is a logical grouping of storylines.  It is initiated by a single person but the lines
/// can be written by many.
/// </summary>
public class StoryController : ManglerController
{
    private readonly StoryService _storyService;
    private readonly IStoryRepository _storyRepository;

    public StoryController(StoryService storyService, IStoryRepository storyRepository)
    {
        _storyService = storyService;
        _storyRepository = storyRepository;
    }

    /// <summary>
    /// Retrieve a single story by ID.  Will not include story lines.
    /// </summary>
    [HttpGet]
    [Route("/story/{id}")]
    [ProducesResponseType(typeof(StoryModel), (int)StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _storyRepository.GetById(id);

        if (result.IsFailure())
        {
            return InternalServerError(ErrorCode.UnableToRetrieveStory, "There was an internal server error");
        }

        if (!result.HasValue())
        {
            return NotFound(ErrorCode.StoryDoesNotExist, $"Unable to find story with id {id}");
        }
        
        return Ok(result.Value.ToModel());
    }

    /// <summary>
    /// Returns a list of stories matching the specified criteria.  Stories are returned from newest to oldest.
    /// </summary>
    [HttpGet]
    [Route("/stories")]
    [ProducesResponseType(typeof(CursorPaginatedList<StoryModel>), (int)StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList([FromQuery] StoryListRequestModel request)
    {
        var hasErrors = Validate.IsNumberOutOfRange(request.PageSize, 1, 50, ErrorCode.InvalidPageSize).Invoke();

        if (hasErrors.IsSuccess)
        {
            return UnprocessableEntity(hasErrors.Value, "GET request was not valid.  Check the specified URL parameters.");
        }

        DateTime? beforeDate = null;

        if (request.Cursor != null)
        {
            if (DateTime.TryParse(request.Cursor, out var parsedDate))
            {
                beforeDate = parsedDate;
            }
            else
            {
                return UnprocessableEntity(ErrorCode.InvalidCursor, "The passed in cursor is malformed or not valid.");
            }
        }

        var storiesResult = await _storyRepository.GetList(request.GuildIdentifier, request.AuthorIdentifier,
            request.PageSize, beforeDate);

        if (storiesResult.IsFailure())
        {
            return InternalServerError(ErrorCode.UnableToRetrieveStory, "An internal error occured while retrieving stories.");
        }

        var stories = storiesResult.Value;
        var storyModels = new List<StoryModel>();
        
        // Determine next cursor by grabbing the last create date, or null if there were no stories.
        string nextCursor = null;
        Story lastStory = null; 
        
        foreach (var story in stories)
        {
            storyModels.Add(story.ToModel());
            lastStory = story;
        }

        if (lastStory != null)
        {
            nextCursor = lastStory?.CreateDt.ToString("MM-dd-yyyy HH:mm:ss");
        }

        return Ok(new CursorPaginatedList<StoryModel>() { Cursor = nextCursor, Items = storyModels.ToList() });
    }

    /// <summary>
    /// Creates a new story.
    /// </summary>
    [HttpPost]
    [Route("/stories")]
    [ProducesResponseType(typeof(StoryModel), (int)StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] StoryPostRequestModel request)
    {
        var hasErrors = request.ValidateModel();

        if (hasErrors.IsSuccess)
        {
            return UnprocessableEntity(hasErrors.Value, "POST request was not valid.");
        }
        
        
        
        
        

        return Ok();
    }

}