using  _04_webapp_sqlite.Utilities;

namespace _04_webapp_sqlite.Prodotti;

public class IndexProdottiModel : PageModel
{
    private readonly ILogger<IndexProdottiModel> _logger;

    public PaginatedList<ProdottoViewModel>? Prodotti { get; set; }

    public PaginatedList<ProdottoViewModel>? ProdottiPerCategoria { get; set; }

    public List<SelectListItem>? CategorieTendina { get; set; } = new List<SelectListItem>();

     public int PageSize { get; set; } = 5; // numero di prodotti per pagina

    

    public int TotaleProdotti { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? IdCategoria { get; set; }

    [BindProperty(SupportsGet = true)]
    public int Ordine { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public int pageIndex { get; set; } = 1;

    public IndexProdottiModel(ILogger<IndexProdottiModel> logger)
    {
        _logger = logger;
       
    }

    public void OnGet(int? IdCategoria, int Ordine, int? pageIndex)
    {
        
        int currentpage = pageIndex ?? 1;
        int totalCount = UtilityDB.ExecuteScalar<int>("SELECT COUNT(*) FROM Prodotti");
        //calcola l'offest per la query
        int offset = (currentpage - 1) * PageSize;
        try
        {
            if (IdCategoria.HasValue)
            {
                List<ProdottoViewModel> items = UtilityDB.ExecuteReader($@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                WHERE c.Id = @id LIMIT {PageSize} OFFSET {offset}", reader => new ProdottoViewModel
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
                Prodotti = new PaginatedList<ProdottoViewModel>(items, totalCount, currentpage, PageSize);
                CategorieTendina = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new SelectListItem
                {
                    Value = reader.GetInt32(0).ToString(),
                    Text = reader.GetString(1)
                });
                _logger.LogInformation($"Categoria scelta: {Prodotti.First().CategoriaNome}");
            }
            else
            {
                List<ProdottoViewModel> items = UtilityDB.ExecuteReader($@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Nome LIMIT {PageSize} OFFSET {offset}", reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    // se la categoria è nulla, restituiamo "Nessuna categoria"
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
                });

                Prodotti = new PaginatedList<ProdottoViewModel>(items, totalCount, currentpage, PageSize);
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
            List<ProdottoViewModel> items = UtilityDB.ExecuteReader($@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Prezzo LIMIT {PageSize} OFFSET {offset}", reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    // se la categoria è nulla, restituiamo "Nessuna categoria"
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
                });

                Prodotti = new PaginatedList<ProdottoViewModel>(items, totalCount, currentpage, PageSize);
        }
        else if (Ordine == 1)
        {
            List<ProdottoViewModel> items = UtilityDB.ExecuteReader($@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Prezzo DESC LIMIT {PageSize} OFFSET {offset}", reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    // se la categoria è nulla, restituiamo "Nessuna categoria"
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
                });

                Prodotti = new PaginatedList<ProdottoViewModel>(items, totalCount, currentpage, PageSize);
        }
        else
        {
            List<ProdottoViewModel> items = UtilityDB.ExecuteReader($@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Id LIMIT {PageSize} OFFSET {offset}", reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    // se la categoria è nulla, restituiamo "Nessuna categoria"
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
                });

                Prodotti = new PaginatedList<ProdottoViewModel>(items, totalCount, currentpage, PageSize);
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

    public IActionResult OnPost(int? pageIndex)
    {
        //_logger.LogInformation($"Categoria scelta: {Prodotti.First().CategoriaNome}");
        return RedirectToPage("Index", new { IdCategoria, Ordine, pageIndex });
    }

}


