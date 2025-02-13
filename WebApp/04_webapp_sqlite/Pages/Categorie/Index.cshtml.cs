namespace _04_webapp_sqlite.Categorie;

public class IndexCategorieModel : PageModel {
    private readonly ILogger<PrivacyModel> _logger;

    #region Proprietà prodotti
    public List<Categoria>? Categorie { get; set; } = new List<Categoria>();
    public int totaleProdotti { get; set; }
    #endregion

    public IndexCategorieModel(ILogger<PrivacyModel> logger) {
        _logger = logger;
    }

    public void OnGet() 
    {
        Categorie = GestioneCategorie.LoadFromDatabase();
        _logger.LogInformation($"Categorie trovate: {Categorie.Count}");
    }
}


