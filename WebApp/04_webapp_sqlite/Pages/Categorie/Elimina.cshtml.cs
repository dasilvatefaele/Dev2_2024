using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _04_webapp_sqlite.Categorie;

public class Elimina : PageModel
{
    private readonly ILogger<Elimina> _logger;

    [BindProperty]
    public Categoria Categoria { get; set; } = new Categoria();

    public Elimina(ILogger<Elimina> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet(int id)
    {
        try
        {
            var sql = "SELECT Id, Nome FROM Categorie WHERE id = @id";
            var Categorie = UtilityDB.ExecuteReader(sql, reader => new Categoria
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
            },
            command =>
            {
                command.Parameters.AddWithValue("@id", id);
            });
            Categoria = Categorie.First();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return Page();
    }


    public IActionResult OnPost()
    {
        var sql = $"DELETE FROM Categorie WHERE id = @id";
        try
        {
            UtilityDB.ExecuteNonQuery(sql, command =>
            {
                command.Parameters.AddWithValue("@id", Categoria.Id);
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
