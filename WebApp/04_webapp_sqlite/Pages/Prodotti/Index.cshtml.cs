namespace _04_webapp_sqlite.Prodotti;

public class IndexProdottiModel : PageModel
{
    // private readonly ILogger<PrivacyModel> _logger;

    public List<ProdottoViewModel>? Prodotti { get; set; } = new();

    public List<ProdottoViewModel>? ProdottiPerCategoria { get; set; } = new();

    public List<SelectListItem>? CategorieTendina { get; set; } = new List<SelectListItem>();

    public int TotaleProdotti { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? IdCategoria { get; set; }

    [BindProperty(SupportsGet = true)]
    public int Ordine { get; set; }

    public IndexProdottiModel()
    {
        //_logger = logger;
        OnGet(IdCategoria, Ordine);
    }

    public void OnGet(int? IdCategoria, int Ordine)
    {
        try
        {
            if (IdCategoria.HasValue)
            {
                Prodotti = UtilityDB.ExecuteReader(@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                WHERE c.Id = @id", reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    // se la categoria è nulla, restituiamo "Nessuna categoria"
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
                },
                command =>
                {
                    command.Parameters.AddWithValue("@id", IdCategoria);
                }
                );
            }
            else
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
                CategorieTendina = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new SelectListItem
                {
                    Value = reader.GetInt32(0).ToString(),
                    Text = reader.GetString(1)
                });
            }
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        // todo: filtri lambda (da implementare in SQL)
        #region lambda
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
#endregion
        try
        {
            TotaleProdotti = UtilityDB.ExecuteScalar<int>("SELECT COUNT (*) FROM Prodotti");
        }

        catch(Exception ex)
        {
            SimpleLogger.Log(ex);
        }


    }

    public IActionResult OnPost()
    {
        return RedirectToPage("Index", new { IdCategoria, Ordine });
    }

}


