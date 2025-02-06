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
            new Prodotto { Nome = "Carote", Prezzo = 1.30m, Dettaglio = "Confezione da 250gr" },
            new Prodotto { Nome = "Avocado", Prezzo = 2.20m, Dettaglio = "Da piantagioni siciliane" },
            new Prodotto { Nome = "Acqua", Prezzo = 0.99m, Dettaglio = "Confezione da 500ml" }
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
    }
}

