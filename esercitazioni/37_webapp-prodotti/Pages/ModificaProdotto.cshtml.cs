using Microsoft.AspNetCore.Mvc; // Importa il namespace per la gestione delle azioni e dei risultati nelle pagine Razor.
using Microsoft.AspNetCore.Mvc.RazorPages; // Importa il namespace per la gestione delle Razor Pages.
using Newtonsoft.Json; // Importa il namespace per il supporto alla serializzazione e deserializzazione JSON.

public class ModificaProdottoModel : PageModel
{
    private readonly ILogger<ModificaProdottoModel> _logger;

    public List<string> Categorie {get; set;}

    public ModificaProdottoModel(ILogger<ModificaProdottoModel> logger)
    {
        _logger = logger;
    }

    public Prodotto Prodotto;
    public void OnGet(int id)
    {
        string filePath = "wwwroot/json/prodotti.json";
        var json = System.IO.File.ReadAllText(filePath);
        var prodotti = JsonConvert.DeserializeObject<IEnumerable<Prodotto>>(json);

        // Legge il contenuto del file JSON che contiene i dati dei prodotti.
        var jsonCategorie = System.IO.File.ReadAllText("wwwroot/json/categorie.json");

        // Deserializza il contenuto JSON in una lista di oggetti di tipo Prodotto.
        Categorie = JsonConvert.DeserializeObject<List<string>>(jsonCategorie);
        _logger.LogInformation("Categorie caricate correttamente");

        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto;
                break;
            }
        }

    }

    public IActionResult OnPost(int id, string nome, decimal prezzo, string dettaglio, string immagine, string categoria)
    {
        string filePath = "wwwroot/json/prodotti.json";
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
        prodotto.Categoria = categoria;

        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));

        return RedirectToPage("Prodotti");

    }


}