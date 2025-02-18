using  _04_webapp_sqlite.Utilities;
namespace _04_webapp_sqlite.Prodotti;

public class PaginatedIndexModel : PageModel
{
     private readonly ILogger<PaginatedIndexModel> _logger;
    public PaginatedList<ProdottoViewModel> Products { get; set; }

    public int PageSize { get; set; } = 5; // numero di prodotti per pagina


    public PaginatedIndexModel( ILogger<PaginatedIndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int? pageIndex)
    {
      
        // L'espressione sotto equivale a:

        // int currentpage = 0;
        // if (pageIndex != null)
        // {
        //     currentpage = pageIndex.Value; // Estrai il valore dall'Nullable<int>
        // }
        // else
        // {
        //     currentpage = 1;
        // }
        
        int currentpage = pageIndex ?? 1;

        //recupera il numero totale di prodotti
        int totalCount = UtilityDB.ExecuteScalar<int>("SELECT COUNT(*) FROM Prodotti");
        //calcola l'offest per la query
        int offset = (currentpage - 1) * PageSize;

        // Recupera i prodotti per la pagina corrente
        // in SQLite si usa LIMIT  e OFFSET per la paginazione
        // limit = quanti elementi voglio
        // offset = da dove voglio partire
        // offset = (pagina corrente - 1) * elementi per pagina
        // LIMIT 5 OFFSET 0 -> 5 elementi a partire dall'elemento 0     

        string sql = $@"
                        SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
                        FROM Prodotti p
                        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                        ORDER BY p.Id
                        LIMIT {PageSize} OFFSET {offset}
                        ";

        List<ProdottoViewModel> items = UtilityDB.ExecuteReader(sql, reader => new ProdottoViewModel
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Prezzo = reader.GetDouble(2),
            // se la categoria è nulla, restituiamo "Nessuna categoria"
            CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
        });

        Products = new PaginatedList<ProdottoViewModel>(items, totalCount, currentpage, PageSize);

        //   _logger.LogInformation($"Prossima pagina: {Products.HasNextPage}, la lista ha {Products.Count} prodotti");
    }
}