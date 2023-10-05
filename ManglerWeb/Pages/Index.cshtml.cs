using ManglerAPIClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManglerWeb.Pages;

public class IndexModel : PageModel
{
    public string ApiText { get; set; }
    
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGet()
    {
        var client = new ManglerClient("http://host.docker.internal:50881", new HttpClient());

        try
        {
            var result = await client.GetHelloWorldAsync();
            ApiText = result?.Text ?? "{the api call worked fine but the response was null}";
        }
        catch (ApiException<ErrorResponse> e)
        {
            ApiText = "there was an exception talking to the API. " + e.Message;
        }
        
    }
}

