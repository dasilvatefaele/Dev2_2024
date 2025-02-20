namespace _04_webapp_sqlite.Fornitori;

public class IndexFornitoriModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    #region Proprietà prodotti
    public List<Fornitore>? Fornitori { get; set; } = new List<Fornitore>();
    public PaginatedList<Fornitore>? FornitoriPaginate { get; set; }
    public int PageSize { get; set; } = 5; // numero di prodotti per pagina

    public int totaleProdotti { get; set; }
    #endregion

    public IndexFornitoriModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int? pageIndex)
    {

        int currentpage = pageIndex ?? 1;
        int totalCount = UtilityDB.ExecuteScalar<int>("SELECT COUNT(*) FROM Fornitori");
        //calcola l'offest per la query
        int offset = (currentpage - 1) * PageSize;
        try
        {
            Fornitori = UtilityDB.ExecuteReader($"SELECT * FROM Fornitori LIMIT {PageSize} OFFSET {offset}", reader => new Fornitore
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Contatto = reader.GetString(2)
            });
            // FornitoriTendina = UtilityDB.ExecuteReader("SELECT * FROM Fornitori", reader => new SelectListItem
            // {
            //     Value = reader.GetInt32(0).ToString(),
            //     Text = reader.GetString(1)
            // });
            FornitoriPaginate = new PaginatedList<Fornitore>(Fornitori, totalCount, currentpage, PageSize);

        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        _logger.LogInformation($"Fornitori trovate: {Fornitori.Count}");
    }
}


