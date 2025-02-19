namespace _04_webapp_sqlite.Categorie;

public class IndexCategorieModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    #region Proprietà prodotti
    public List<Categoria>? Categorie { get; set; } = new List<Categoria>();
    public PaginatedList<Categoria>? CategoriePaginate { get; set; }
    public int PageSize { get; set; } = 5; // numero di prodotti per pagina

    public int totaleProdotti { get; set; }
    #endregion

    public IndexCategorieModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int? pageIndex)
    {

        int currentpage = pageIndex ?? 1;
        int totalCount = UtilityDB.ExecuteScalar<int>("SELECT COUNT(*) FROM Categorie");
        //calcola l'offest per la query
        int offset = (currentpage - 1) * PageSize;
        try
        {
            Categorie = UtilityDB.ExecuteReader($"SELECT * FROM Categorie LIMIT {PageSize} OFFSET {offset}", reader => new Categoria
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1)
            });
            // CategorieTendina = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new SelectListItem
            // {
            //     Value = reader.GetInt32(0).ToString(),
            //     Text = reader.GetString(1)
            // });
            CategoriePaginate = new PaginatedList<Categoria>(Categorie, totalCount, currentpage, PageSize);

        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        _logger.LogInformation($"Categorie trovate: {Categorie.Count}");
    }
}


