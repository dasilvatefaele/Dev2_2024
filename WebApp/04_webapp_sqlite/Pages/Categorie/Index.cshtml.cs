namespace _04_webapp_sqlite.Categorie;

public class IndexCategorieModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    #region Proprietà prodotti
    public List<Categoria>? Categorie { get; set; } = new List<Categoria>();

    public int totaleProdotti { get; set; }
    #endregion

    public IndexCategorieModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        try
        {
            Categorie = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new Categoria
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1)
            });
            // CategorieTendina = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new SelectListItem
            // {
            //     Value = reader.GetInt32(0).ToString(),
            //     Text = reader.GetString(1)
            // });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        _logger.LogInformation($"Categorie trovate: {Categorie.Count}");
    }
}


