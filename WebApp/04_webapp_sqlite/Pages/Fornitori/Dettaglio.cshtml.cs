namespace _04_webapp_sqlite.Fornitori;

public class Dettaglio : PageModel
{
    // private readonly ILogger<Dettaglio> _logger;
    public Fornitore? Fornitore { get; set; } = new();

    public void OnGet(int id = -1, string nomefornitore = null)
    {
        if (id != -1)
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
                    cmd.Parameters.AddWithValue("@id", id);
                });
                Fornitore = fornitori.First();
            }
            catch (Exception ex)
            {
                SimpleLogger.Log(ex);
            }
        }
        else if (nomefornitore != null)
        {
            try
            {
                var fornitori = UtilityDB.ExecuteReader($"SELECT Id, Nome, Contatto FROM Fornitori f WHERE f.Nome = @Nome", reader => new Fornitore
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Contatto = reader.GetString(2)
                }, cmd =>
                {
                    cmd.Parameters.AddWithValue("@Nome", nomefornitore);
                });
                Fornitore = fornitori.First();
            }
            catch (Exception ex)
            {
                SimpleLogger.Log(ex);
            }
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


