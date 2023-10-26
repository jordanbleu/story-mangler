using Mangler.Common.Monads;
using ManglerAPI.Infrastructure.ErrorHandling;
using ManglerAPI.Infrastructure.Models;
using ManglerAPI.Infrastructure.Mvc;
using ManglerAPI.Services;
using ManglerAPI.Stories.Models;
using ManglerAPI.Stories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.Stories;

[Route("/story")]
public class StoryController : ControllerBase
{
    private readonly StoryService _storyService;
    private readonly IStoryRepository _storyRepository;
    private readonly ErrorFactory _errorFactory;

    private static readonly List<StoryResponse> DefaultListResponse = new List<StoryResponse>(0);

    public StoryController(StoryService storyService, IStoryRepository storyRepository, ErrorFactory errorFactory)
    {
        _storyService = storyService;
        _storyRepository = storyRepository;
        _errorFactory = errorFactory;
    }

    /// <summary>
    /// Gets a list of stories matching the requested criteria
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<StoryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromQuery] StoryListGetRequest request)
    {
        var validationResult = request.ValidateRequest();

        if (validationResult.IsFailure())
        {
            return UnprocessableEntity(_errorFactory.CreateErrorResponse(validationResult));
        }

        var entityListResult = await _storyRepository.GetList(request.Cursor, request.PageSize);

        if (entityListResult.IsFailure())
        {
            return new InternalServerErrorObjectResult(_errorFactory.CreateErrorResponse(entityListResult));
        }

        var stories = entityListResult.Value;

        if (stories == null || !stories?.Any() == true)
        {
            return Ok(DefaultListResponse);
        }

        return Ok(stories.Select(s=>s.MapToStoryGetResponse()));
    }

    /// <summary>
    /// Retrieves a single Story by Id.
    /// </summary>
    [HttpGet]
    [Route("/story/{id}")]
    [ProducesResponseType(typeof(StoryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
    {
        var entityResult = await _storyRepository.GetById(id);

        if (entityResult.IsFailure())
        {
            return new InternalServerErrorObjectResult(_errorFactory.CreateErrorResponse(entityResult));
        }
       
        var entity = entityResult.Value;

        if (entity == null)
        {
            return NotFound(_errorFactory.CreateErrorResponse(ErrorCode.UnableToRetrieveStory));
        }
        
        return Ok(entity.MapToStoryGetResponse());
    }

    /// <summary>
    /// Create a new story, along with the first line.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(StoryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> PostAsync([FromBody] StoryPostRequest request)
    {
        var validationResult = request.ValidateRequest();

        if (validationResult.IsFailure())
        {
            return UnprocessableEntity(_errorFactory.CreateErrorResponse(validationResult));
        }

        var result = await _storyRepository.Create(request.MapToNewEntity());

        if (result.IsFailure())
        {
            return new InternalServerErrorObjectResult(_errorFactory.CreateErrorResponse(result));
        }

        var createdStory = result.Value;
        return Ok(createdStory.MapToStoryGetResponse());
    }

}