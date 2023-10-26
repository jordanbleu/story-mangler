using ManglerAPI.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ManglerAPI.Infrastructure.Swagger;

/// <summary>
/// Sets the default response type to the error object.  This way we only need
/// to define the success response.  If the API ever returns other error HTTP responses
/// they should be defined here.
/// </summary>
public class ProduceResponseTypeModelProvider : IApplicationModelProvider
{
    public int Order => 1;

    public void OnProvidersExecuted(ApplicationModelProviderContext context)
    {
    }
    
    public void OnProvidersExecuting(ApplicationModelProviderContext context)
    {
        foreach (var controller in context.Result.Controllers)
        {
            foreach (var action in controller.Actions)
            {
                action.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorResponseModel), StatusCodes.Status403Forbidden));
                action.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorResponseModel), StatusCodes.Status404NotFound));
                action.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorResponseModel), StatusCodes.Status422UnprocessableEntity));
                action.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorResponseModel), StatusCodes.Status500InternalServerError));
            }
        }
    }
}