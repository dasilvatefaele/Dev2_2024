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
        // Creiamo e apriamo la connessione al database

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


        // if (Prodotti.Count == 0)
        // {
        //     using (var connection = DatabaseInitializer.GetConnection())
        //     {
        //         // apriamo la connessione
        //         connection.Open();

        //         // Occorre creare una query di join con una LEFT JOIN tra la tabella Prodotti e la tabella Categorie
        //         // Usiamo gli alias in SQLite per rendere più leggibile il codice. Useremo p per Prodotti e c per Categorie
        //         var query = @"
        //         SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
        //         FROM Prodotti p
        //         LEFT JOIN Categorie c ON p.CategoriaId = c.Id
        //         ORDER BY p.Nome";

        //         // Creiamo il comando
        //         using (var command = new SQLiteCommand(query, connection))
        //         {
        //             // Eseguiamo il comando
        //             using (var reader = command.ExecuteReader())
        //             {
        //                 // Leggiamo i dati
        //                 while (reader.Read())
        //                 {
        //                     // Creiamo un nuovo prodotto e lo aggiungiamo alla lista
        //                     Prodotti?.Add(new ProdottoViewModel
        //                     {
        //                         Id = reader.GetInt32(0),
        //                         Nome = reader.GetString(1),
        //                         Prezzo = reader.GetDouble(2),
        //                         // se la categoria è nulla, restituiamo "Nessuna categoria"
        //                         CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
        //                     });
        //                 }
        //                 // ordiniamo la lista secondo l'id

        //             }
        //         }
        //         // Chiudiamo la connessione
        //         // connection.Close();
        //     }
        //     ;
        // }
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


