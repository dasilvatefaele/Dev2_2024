using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _34_WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    string errore = "USO UNA VIRIABILEEEE";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        //_logger.LogInformation("Stampo il messaggio: {0}", message);
    }

    public void OnGet()
    {
        ViewData["errore"] = $"Stampo il messaggio: {errore}";
    }
}
