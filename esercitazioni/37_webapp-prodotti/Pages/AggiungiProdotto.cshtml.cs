using Microsoft.AspNetCore.Mvc; // Importa il namespace per la gestione delle azioni e dei risultati nelle pagine Razor.
using Microsoft.AspNetCore.Mvc.RazorPages; // Importa il namespace per la gestione delle Razor Pages.
using Newtonsoft.Json; // Importa il namespace per il supporto alla serializzazione e deserializzazione JSON.
using System.Diagnostics; // Importa il namespace per il debugging e il logging (anche se in questo codice non viene utilizzato).

// Definizione della classe AggiungiProdottoModel che eredita da PageModel
public class AggiungiProdottoModel : PageModel
{
    // Inizializzazione della variabile _logger per il logging delle informazioni (non viene usata nel codice fornito).
    private readonly ILogger<AggiungiProdottoModel> _logger;

    public AggiungiProdottoModel(ILogger<AggiungiProdottoModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }


    // Metodo che viene eseguito quando si invia un modulo (POST) con nome, prezzo e dettaglio del prodotto.
    public IActionResult OnPost(string nome, decimal prezzo, string dettaglio)
    {

        // Legge il contenuto del file JSON che contiene i dati dei prodotti.
        var json = System.IO.File.ReadAllText("wwwroot/prodotti.json");

        // Deserializza il contenuto JSON in una lista di oggetti di tipo Prodotto.
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        // Calcola Id incrementando di 1 da quello precedente
        var id = 1;
        if (prodotti.Count > 0)
        {
            id = prodotti[prodotti.Count-1].Id +1;
        }

        // Aggiunge un nuovo prodotto alla lista con i valori passati tramite il form (nome, prezzo, dettaglio).
        prodotti.Add(new Prodotto { Id = id, Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio });

        // Scrive la lista aggiornata di prodotti nel file JSON, serializzandola di nuovo in formato JSON.
        System.IO.File.WriteAllText("wwwroot/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));

        // Reindirizza l'utente alla pagina "Prodotti" dopo aver aggiunto il nuovo prodotto.
        return RedirectToPage("Prodotti");
    }
}

