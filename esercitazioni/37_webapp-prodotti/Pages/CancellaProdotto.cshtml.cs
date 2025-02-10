using Microsoft.AspNetCore.Mvc; // Importa il namespace per la gestione delle azioni e dei risultati nelle pagine Razor.
using Microsoft.AspNetCore.Mvc.RazorPages; // Importa il namespace per la gestione delle Razor Pages.
using Newtonsoft.Json; // Importa il namespace per il supporto alla serializzazione e deserializzazione JSON.
using System.Diagnostics; // Importa il namespace per il debugging e il logging (anche se in questo codice non viene utilizzato).


public class CancellaProdottoModel : PageModel
{
    private readonly ILogger<CancellaProdottoModel> _logger;

    public CancellaProdottoModel(ILogger<CancellaProdottoModel> logger)
    {
        _logger = logger;
    }

    public Prodotto Prodotto;
    public void OnGet(int id)
    {
        string filePath = "wwwroot/json/prodotti.json";
        var json = System.IO.File.ReadAllText(filePath);
        var prodotti = JsonConvert.DeserializeObject<IEnumerable<Prodotto>>(json);

        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto;
                break;
            }
        }
    }

    public IActionResult OnPost(int id)
    {
        string filePath = "wwwroot/json/prodotti.json";
        var json = System.IO.File.ReadAllText(filePath);
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        for (int i = 0; i < prodotti.Count; i++)
        {
            if (prodotti[i].Id == id)
            {
                prodotti.RemoveAt(i);
                break;
            }
        }

        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("Prodotti");
    }
}


