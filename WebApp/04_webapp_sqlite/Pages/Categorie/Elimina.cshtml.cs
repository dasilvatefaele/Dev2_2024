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
        using (var connection = DatabaseInitializer.GetConnection())
        {
            connection.Open();

            var sql = "SELECT Id, Nome FROM Categorie WHERE id = @id";

            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Categoria = new Categoria
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                        };
                    }
                    else
                    {
                        return NotFound();

                    }
                }
            }
        }
        return Page();
    }


    public IActionResult OnPost()
    {
        using (var connection = DatabaseInitializer.GetConnection())
        {
            connection.Open();

            // costruisco la query basandomi sull'input dell'utente

            var sql = $"DELETE FROM Categorie WHERE id = @id";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", Categoria.Id);
                command.ExecuteNonQuery();
                _logger.LogInformation("Sto eseguendo il comando");
            }
        }
        return RedirectToPage("Index");
    }
}
