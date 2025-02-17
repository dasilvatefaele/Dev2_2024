namespace _04_webapp_sqlite.Prodotti;

public class IndexProdottiModel : PageModel
{
    // private readonly ILogger<PrivacyModel> _logger;

    #region Proprietà prodotti
    public List<ProdottoViewModel>? Prodotti { get; set; } = new();
    public int totaleProdotti { get; set; }
    #endregion

    [BindProperty(SupportsGet = true)]
    public int Ordine { get; set; }

    public IndexProdottiModel()
    {
        //_logger = logger;
        OnGet();
    }

    public void OnGet()
    {
        try
        {
            Prodotti = UtilityDB.ExecuteReader(@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Nome", reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
            });
        }
        catch(Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        // todo: filtri lambda (da implementare in SQL)
        if (Ordine == 0)
        {
            Prodotti = Prodotti?.OrderBy(p => p.Prezzo).ToList();
        }
        else if (Ordine == 1)
        {
            Prodotti = Prodotti?.OrderByDescending(p => p.Prezzo).ToList();
        }
        else
        {
            Prodotti = Prodotti?.OrderBy(p => p.Id).ToList();
        }
    }

    public IActionResult OnPost()
    {

        return RedirectToPage("Index", new { Ordine });
    }

}


