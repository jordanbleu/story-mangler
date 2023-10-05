using ManglerAPIClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManglerWeb.Pages;

public class IndexModel : PageModel
{
    public string Title { get; set; }
    
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGet()
    {
        var client = new ManglerClient("asdf", new HttpClient());
        var result = await client.GetHelloWorldAsync();
        
        // //var client = new ManglerAPIClient.ManglerClient();
        // var data = client.StoryAsync(555);
    }
}

