using Microsoft.AspNetCore.Mvc; // Importa il namespace per la gestione delle azioni e dei risultati nelle pagine Razor.
using Microsoft.AspNetCore.Mvc.RazorPages; // Importa il namespace per la gestione delle Razor Pages.
using Newtonsoft.Json; // Importa il namespace per il supporto alla serializzazione e deserializzazione JSON.

// Definizione della classe AggiungiProdottoModel che eredita da PageModel
public class AggiungiProdottoModel : PageModel
{
    // Inizializzazione della variabile _logger per il logging delle informazioni (non viene usata nel codice fornito).
    private readonly ILogger<AggiungiProdottoModel> _logger;

    public List<string> Categorie {get; set;}

    [TempData]
    public string ConfermaAggiunta { get; set;} = null;

    public AggiungiProdottoModel(ILogger<AggiungiProdottoModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
         // Legge il contenuto del file JSON che contiene i dati dei prodotti.
        var json = System.IO.File.ReadAllText("wwwroot/json/categorie.json");

        // Deserializza il contenuto JSON in una lista di oggetti di tipo Prodotto.
        Categorie = JsonConvert.DeserializeObject<List<string>>(json);
        _logger.LogInformation("Categorie caricate correttamente");
    }

    // Metodo che viene eseguito quando si invia un modulo (POST) con nome, prezzo e dettaglio del prodotto.
    public IActionResult OnPost(string nome, decimal prezzo, string dettaglio, string categoria)
    {
        
        // Legge il contenuto del file JSON che contiene i dati dei prodotti.
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");

        // Deserializza il contenuto JSON in una lista di oggetti di tipo Prodotto.
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        // Calcola Id incrementando di 1 da quello precedente
        var id = 1;
        if (prodotti.Count > 0)
        {
            id = prodotti[prodotti.Count - 1].Id + 1;
        }

        // Aggiunge un nuovo prodotto alla lista con i valori passati tramite il form (nome, prezzo, dettaglio).
        prodotti.Add(new Prodotto
        {
            Id = id,
            Nome = nome,
            Prezzo = prezzo,
            Dettaglio = dettaglio,
            Immagine = "img/img_demo.webp",
            Categoria = categoria,
            Data = DateTime.Now.ToString("dd/MM/yy at HH:mm")
            
        });

        // Scrive la lista aggiornata di prodotti nel file JSON, serializzandola di nuovo in formato JSON.
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        ConfermaAggiunta = "Aggiunto correttamente";
        // Reindirizza l'utente alla pagina "Prodotti" dopo aver aggiunto il nuovo prodotto.
        return RedirectToPage();
    }
}

