using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _04_webapp_sqlite.Fornitori;

public class Elimina : PageModel
{
    private readonly ILogger<Elimina> _logger;

    [BindProperty]
    public Fornitore Fornitore { get; set; } = new Fornitore();

    public Elimina(ILogger<Elimina> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet(int id)
    {
        try
        {
            var sql = "SELECT Id, Nome FROM Fornitori WHERE id = @id";
            var Fornitori = UtilityDB.ExecuteReader(sql, reader => new Fornitore
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
            },
            command =>
            {
                command.Parameters.AddWithValue("@id", id);
            });
            Fornitore = Fornitori.First();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return Page();
    }


    public IActionResult OnPost()
    {
        var sql = $"DELETE FROM Fornitori WHERE id = @id";
        try
        {
            UtilityDB.ExecuteNonQuery(sql, command =>
            {
                command.Parameters.AddWithValue("@id", Fornitore.Id);
                command.ExecuteNonQuery();
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Index");
    }
}
