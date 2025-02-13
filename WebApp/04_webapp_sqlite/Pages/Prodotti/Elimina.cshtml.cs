using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _04_webapp_sqlite.Prodotti;

public class Elimina : PageModel
{
    private readonly ILogger<Elimina> _logger;

    [BindProperty]
    public Prodotto Prodotto { get; set; } = new Prodotto();

    public Elimina(ILogger<Elimina> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet(int id)
    {
        using (var connection = DatabaseInitializer.GetConnection())
        {
            connection.Open();

            var sql = "SELECT Id, Nome, Prezzo, CategoriaId FROM Prodotti WHERE id = @id";

            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Prodotto = new Prodotto
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Prezzo = reader.GetDouble(2),
                            CategoriaId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
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

            var sql = $"DELETE FROM Prodotti WHERE id = @id";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", Prodotto.Id);
                command.ExecuteNonQuery();
                _logger.LogInformation("Sto eseguendo il comando");
            }
        }
        return RedirectToPage("Index");
    }
}
