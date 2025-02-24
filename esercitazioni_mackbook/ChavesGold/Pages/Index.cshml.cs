using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Nodes;

namespace ChavesGold.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public List<Chave> Chaves { get; set; } = new();
    public List<Chave> ChavesFound { get; set; } = new();

    [BindProperty]
    public string SearchTerm { get; set; }

    bool found = false;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(string? searchTerm)
    {
        Chaves = LoadChaves();
        _logger.LogInformation($"Found key: {Chaves.Count}");
        if (!string.IsNullOrEmpty(searchTerm))
        {
            ChavesFound = Chaves.Where(chave => chave.Id == searchTerm).ToList();
        }

         _logger.LogInformation($"Total keys loaded: {Chaves.Count}");
        _logger.LogInformation($"Keys found: {ChavesFound.Count}");
      
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("Index", new { searchTerm = SearchTerm });
    }

    public static List<Chave> LoadChaves()
    {
        string path = @"Data/chaves_list.json";
        var json = System.IO.File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<Chave>>(json);
    }
}
