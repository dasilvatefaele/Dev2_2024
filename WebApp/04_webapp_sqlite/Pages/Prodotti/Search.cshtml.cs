using _04_webapp_sqlite.Prodotti;

public class SearchModel : PageModel
{
    //abbiamo bisogno di una proprieta pubblica
    public string SearchTerm { get; set; }

    [BindProperty(SupportsGet = true)]
    public int pageIndex { get; set; } = 1;
    public PaginatedList<ProdottoViewModel>? Prodotti { get; set; }

    public ProdottoViewModel Prodotto { get; set; } = new();
    public int PageSize { get; set; } = 5; // numero di prodotti per pagina

    public void OnGet(string q, int? pageIndex)
    {

        int currentpage = pageIndex ?? 1;
        int totalCount = UtilityDB.ExecuteScalar<int>("SELECT COUNT(*) FROM Prodotti");
        //calcola l'offest per la query
        int offset = (currentpage - 1) * PageSize;
        //assegno la stringa di ricerca alla proprieta pubblica
        SearchTerm = q;

        //se la stringa di ricerca non è vuota
        if (!string.IsNullOrWhiteSpace(q))
        {
            try
            {
                //Utilizzo di DbUtils per leggere la lista dei prodotti
                var prodotti = UtilityDB.ExecuteReader(
                    "SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.Nome LIKE @searchTerm",

                            reader => new ProdottoViewModel
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Prezzo = reader.GetDouble(2),
                                CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                            },
                             cmd =>
                             {
                                 cmd.Parameters.AddWithValue("@searchTerm", $"%{q}%");
                             }
                );
                Prodotto = prodotti.First();
                Prodotti = new PaginatedList<ProdottoViewModel>(prodotti, totalCount,currentpage,PageSize);

            }
            catch (Exception ex)
            {
                SimpleLogger.Log(ex);
            }

        }
    }
     public IActionResult OnPost(int? pageIndex)
    {
        //_logger.LogInformation($"Categoria scelta: {Prodotti.First().CategoriaNome}");
        return RedirectToPage("Index", new { SearchTerm, pageIndex });
    }
}