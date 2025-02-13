using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace _04_webapp_sqlite.Categorie;
public class Modifica : PageModel
{
    [BindProperty]
    public Categoria Categoria { get; set; }

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
        if (!ModelState.IsValid) // se il modello non è valido
        {
         
            return Page();
        }

        using (var connection = DatabaseInitializer.GetConnection())
        {
            connection.Open();

            // costruisco la query basandomi sull'input dell'utente

            var sql = $"UPDATE Categorie SET Nome = @nome WHERE id = @id";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@nome", Categoria.Nome);
                command.Parameters.AddWithValue("@id", Categoria.Id);
                command.ExecuteNonQuery();
            }
        }
        return RedirectToPage("Index");
    }
}