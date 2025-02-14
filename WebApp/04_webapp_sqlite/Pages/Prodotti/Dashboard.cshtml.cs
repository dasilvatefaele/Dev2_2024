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
        // se i prodotti non sono caricati li carico

        var queryCostosi = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Prezzo DESC LIMIT 5";

        ProdottiPiuCostosi = ExecuteQuery(queryCostosi);

        var queryRecenti = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Id DESC LIMIT 5";

        ProdottiRecenti = ExecuteQuery(queryRecenti);

        var queryCategoria = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                WHERE p.CategoriaId = 11 LIMIT 5";

        ProdottiCategoria = ExecuteQuery(queryCategoria);

    }

    public List<ProdottoViewModel> ExecuteQuery(string query)
    {
        List<ProdottoViewModel> ProdottiFiltrati = new List<ProdottoViewModel>();
        using (var connection = DatabaseInitializer.GetConnection())
        {
            // apriamo la connessione
            connection.Open();

            // Occorre creare una query di join con una LEFT JOIN tra la tabella Prodotti e la tabella Categorie
            // Usiamo gli alias in SQLite per rendere più leggibile il codice. Useremo p per Prodotti e c per Categorie

            // Creiamo il comando
            using (var command = new SQLiteCommand(query, connection))
            {
                // Eseguiamo il comando
                using (var reader = command.ExecuteReader())
                {
                    // Leggiamo i dati
                    while (reader.Read())
                    {
                        // Creiamo un nuovo prodotto e lo aggiungiamo alla lista
                        ProdottiFiltrati?.Add(new ProdottoViewModel
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Prezzo = reader.GetDouble(2),
                            // se la categoria è nulla, restituiamo "Nessuna categoria"
                            CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
                        });
                    }
                    // ordiniamo la lista secondo l'id

                }
            }
        }
        ;
        return ProdottiFiltrati;
    }
}


