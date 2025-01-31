using Microsoft.AspNetCore.Mvc.RazorPages;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public IEnumerable<Prodotto> Prodotti { get; set; } // una sequenza di elementi che non supporta la modifica
    public string Ricerca { get; set; }

    public void OnGet(string ricerca)
    {
        Ricerca = ricerca;
        Prodotti = new List<Prodotto>
        {
            new Prodotto { Nome = "Prodotto 1", Prezzo = 10, Dettaglio = "Dettaglio 1" },
            new Prodotto { Nome = "Prodotto 2", Prezzo = 20, Dettaglio = "Dettaglio 2" },
            new Prodotto { Nome = "Prodotto 3", Prezzo = 30, Dettaglio = "Dettaglio 3" }
        };

        List<Prodotto> prodottiFiltrati = new List<Prodotto>();

        if (!string.IsNullOrEmpty(Ricerca))
        {
            foreach (Prodotto prodotto in Prodotti)
            {
                if (prodotto.Nome.Contains(Ricerca, StringComparison.OrdinalIgnoreCase))
                {
                    prodottiFiltrati.Add(prodotto);
                }
            }
            Prodotti = prodottiFiltrati;
        }
        else 
        {
            Prodotti = Prodotti;
        }
    }
}

