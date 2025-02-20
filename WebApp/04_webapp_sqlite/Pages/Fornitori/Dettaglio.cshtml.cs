namespace _04_webapp_sqlite.Fornitori;

public class Dettaglio : PageModel
{
    // private readonly ILogger<Dettaglio> _logger;

    public Fornitore? Fornitore { get; set; } = new();


    [BindProperty(SupportsGet = true)]
    public int Ordine { get; set; }

    public void OnGet(int id)
    {
        try
        {
            var fornitori = UtilityDB.ExecuteReader($"SELECT Id, Nome, Contatto FROM Fornitori f WHERE f.Id = @id", reader => new Fornitore
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Contatto = reader.GetString(2)
            }, cmd => 
            {
                cmd.Parameters.AddWithValue("@id",id);
            });
            Fornitore = fornitori.First();


        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }


    }

    public IActionResult OnPost(string? returnUrl)
    {
        if (!string.IsNullOrEmpty(returnUrl))
        {
            return Redirect(returnUrl);
        }

        return RedirectToPage("Index"); // Se non c'è un URL di ritorno, vai alla home
    }
}


