namespace _04_webapp_sqlite.Prodotti;

public class Dettaglio : PageModel
{
    // private readonly ILogger<PrivacyModel> _logger;

    #region Proprietà prodotti
    public ProdottoViewModel? Prodotto { get; set; } = new();
    public int totaleProdotti { get; set; }
    #endregion

    [BindProperty(SupportsGet = true)]
    public int Ordine { get; set; }

    // public Dettaglio()
    // {
    //     //_logger = logger;
    //     OnGet();
    // }

    public void OnGet(int id)
    {
        try
        {
            var prodotti = UtilityDB.ExecuteReader(@"
                SELECT p.Id, p.Nome, p.Prezzo, 
                c.Nome as Categoria,
                f.Nome as Fornitore
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                LEFT JOIN Fornitori f ON p.FornitoreId = f.Id
                WHERE p.Id = @id", reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3),
                FornitoreNome = reader.IsDBNull(4) ? "Nessun fornitore" : reader.GetString(4)

            },
            command =>
            {
                command.Parameters.AddWithValue("@id", id);
            }
            );
            Prodotto = prodotti.First();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }


    }

    public IActionResult OnPost(string? returnUrl)
    {
        if (!string.IsNullOrEmpty(returnUrl))
        {
            return Redirect(returnUrl);
        }

        return RedirectToPage("Index"); // Se non c'è un URL di ritorno, vai alla home
    }
}


