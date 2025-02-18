// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc.Rendering;

namespace _04_webapp_sqlite.Prodotti;

public class Elimina : PageModel
{
    private readonly ILogger<Elimina> _logger;

    [BindProperty]
    public ProdottoViewModel Prodotto { get; set; } = new ProdottoViewModel();

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public Elimina(ILogger<Elimina> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet(int id)
    {
        var sql = "SELECT p.Id, p.Nome, p.Prezzo, c.Nome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.Id = @id ";
        try
        {
            var Prodotti = UtilityDB.ExecuteReader(sql, reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
            },
             command =>
             {
                 command.Parameters.AddWithValue("@id", id);
             });

            Id = Prodotti.First().Id;
            Prodotto = Prodotti.First();
            _logger.LogInformation($"Stai per eliminare ID: {Prodotto.Id}");
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return Page();
    }

    public IActionResult OnPost()
    {
        var sql = $"DELETE FROM Prodotti WHERE id = @id";
        try
        {
            UtilityDB.ExecuteNonQuery(sql, command =>
            {
                command.Parameters.AddWithValue("@id", Id);
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Index");
    }
}
