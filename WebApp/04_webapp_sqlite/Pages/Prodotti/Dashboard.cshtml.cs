namespace _04_webapp_sqlite.Prodotti;

public class Dashboard : PageModel
{
    private readonly ILogger<Dashboard> _logger;

    #region Proprietà prodotti
    public List<ProdottoViewModel>? ProdottiPiuCostosi { get; set; } = new();
    public List<ProdottoViewModel>? ProdottiRecenti { get; set; } = new();
    public List<ProdottoViewModel>? ProdottiCategoria { get; set; } = new();

    #endregion

    public Dashboard(ILogger<Dashboard> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var queryCostosi = @"
                SELECT p.Id, p.Nome, p.Prezzo, 
                c.Nome as Categoria,
                f.Nome as Fornitore
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                LEFT JOIN Fornitori f ON p.FornitoreId = f.Id
                ORDER BY p.Prezzo DESC LIMIT 5";

        try
        {
            ProdottiPiuCostosi = UtilityDB.ExecuteReader(queryCostosi, reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3),
                FornitoreNome = reader.IsDBNull(4) ? "Nessun fornitore" : reader.GetString(4)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        var queryRecenti = @"
                SELECT p.Id, p.Nome, p.Prezzo, 
                c.Nome as Categoria,
                f.Nome as Fornitore
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                LEFT JOIN Fornitori f ON p.FornitoreId = f.Id
                ORDER BY p.Id DESC LIMIT 5";

        try
        {
            ProdottiRecenti = UtilityDB.ExecuteReader(queryRecenti, reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3),
                FornitoreNome = reader.IsDBNull(4) ? "Nessun fornitore" : reader.GetString(4)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        var queryCategoria = @"SELECT p.Id, p.Nome, p.Prezzo, 
                c.Nome as Categoria,
                f.Nome as Fornitore
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                LEFT JOIN Fornitori f ON p.FornitoreId = f.Id
                WHERE p.CategoriaId = 3 LIMIT 5";

        try
        {
            ProdottiCategoria = UtilityDB.ExecuteReader(queryCategoria, reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3),
                FornitoreNome = reader.IsDBNull(4) ? "Nessun fornitore" : reader.GetString(4)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
}

