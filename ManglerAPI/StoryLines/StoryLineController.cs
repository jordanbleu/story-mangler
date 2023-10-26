using Mangler.Common.Monads;
using ManglerAPI.Infrastructure.Entities;
using ManglerAPI.Infrastructure.Models;
using ManglerAPI.StoryLines.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.StoryLines;

public class StoryLineController : ControllerBase
{
    // /// <summary>
    // /// Write the next line in the given story.  Text is optional and can be added later via a PUT request.
    // /// </summary>
    // public IActionResult PostAsync(StoryLinePostRequest request)
    // {
    //     var validationResult = request.ValidateRequest();
    //
    //     if (validationResult.IsFailure())
    //     {
    //         return UnprocessableEntity(new ErrorResponseModel()
    //         {
    //             Message = validationResult?.Error?.ErrorMessage,
    //         });
    //     }
    //     
    //     
    //     
    //
    // }

}