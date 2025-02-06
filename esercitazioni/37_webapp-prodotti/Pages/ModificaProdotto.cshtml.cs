using Microsoft.AspNetCore.Mvc; // Importa il namespace per la gestione delle azioni e dei risultati nelle pagine Razor.
using Microsoft.AspNetCore.Mvc.RazorPages; // Importa il namespace per la gestione delle Razor Pages.
using Newtonsoft.Json; // Importa il namespace per il supporto alla serializzazione e deserializzazione JSON.
using System.Diagnostics; // Importa il namespace per il debugging e il logging (anche se in questo codice non viene utilizzato).


public class ModificaProdottoModel : PageModel
{
    private readonly ILogger<ModificaProdottoModel> _logger;

    public ModificaProdottoModel(ILogger<ModificaProdottoModel> logger)
    {
        _logger = logger;
    }

    public Prodotto Prodotto;
    public void OnGet(int id)
    {
        string filePath = "wwwroot/prodotti.json";
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

    public IActionResult OnPost(int id, string nome, decimal prezzo, string dettaglio, string immagine)
    {
        string filePath = "wwwroot/prodotti.json";
        var json = System.IO.File.ReadAllText(filePath);
        var prodotti = JsonConvert.DeserializeObject<IEnumerable<Prodotto>>(json);
        Prodotto prodotto = null;

        foreach (var p in prodotti)
        {
            if (p.Id == id)
            {
                prodotto = p;
                break;
            }
        }

        prodotto.Nome = nome;
        prodotto.Prezzo = prezzo;
        prodotto.Dettaglio = dettaglio;
        prodotto.Immagine = immagine;

        System.IO.File.WriteAllText("wwwroot/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));

        return RedirectToPage("Prodotti");

    }


}