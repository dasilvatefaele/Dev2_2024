using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace _04_webapp_sqlite.Prodotti;
public class Modifica : PageModel
{
    [BindProperty]
    public Prodotto Prodotto { get; set; }
    public List<SelectListItem> CategoriaSelectList { get; set; } = new List<SelectListItem>();

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

            CaricaCategorie();
        }

        return Page();
    }

    public IActionResult OnPost()
    {

        if (!ModelState.IsValid) // se il modello non è valido
        {
            CaricaCategorie();
            return Page();
        }

        using (var connection = DatabaseInitializer.GetConnection())
        {
            connection.Open();

            // costruisco la query basandomi sull'input dell'utente

            var sql = $"UPDATE Prodotti SET Nome = @nome, Prezzo = @prezzo, CategoriaId = @categoriaid WHERE id = @id";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@nome", Prodotto.Nome);
                command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
                command.Parameters.AddWithValue("@categoriaid", Prodotto.CategoriaId);
                command.Parameters.AddWithValue("@id", Prodotto.Id);
                command.ExecuteNonQuery();
            }
        }
        return RedirectToPage("Index");
    }

    public void CaricaCategorie()
    {
        using (var connection = DatabaseInitializer.GetConnection())
        {
            // aprire la connessione 
            connection.Open();

            // leggere la tabella categorie
            var sql = @" SELECT * FROM Categorie";

            using (var command = new SQLiteCommand(sql, connection))
            {
                // mentre il reader legge
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // aggiungi nuovo oggetto SelectListItem con Value e Text
                        CategoriaSelectList.Add(new SelectListItem
                        {
                            Value = reader.GetInt32(0).ToString(),
                            Text = reader.GetString(1)
                        });
                    }
                }
            }
        }
    }
}