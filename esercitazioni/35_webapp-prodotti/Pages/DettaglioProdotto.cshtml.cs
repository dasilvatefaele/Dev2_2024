using Microsoft.AspNetCore.Mvc.RazorPages;


public class DettaglioProdotto : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;

    public DettaglioProdotto(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public Prodotto Prodotto { get; set; }

    //public void OnGet(string nome, decimal prezzo, string dettaglio)
    public void OnGet(Prodotto prodotto)
    {
        //Prodotto = new Prodotto {Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio};
        Prodotto = prodotto;
        
    }
}

