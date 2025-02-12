using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace _04_webapp_sqlite.Prodotti;
public class AggiungiProdottoModel : PageModel
{
    private readonly ILogger<AggiungiProdottoModel> _logger;

    [BindProperty]
    public Prodotto Prodotto { get; set; }

    public List<SelectListItem> Categorie { get; set; } = new List<SelectListItem>();

    public AggiungiProdottoModel(ILogger<AggiungiProdottoModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        CaricaCategorie();
    }

    public IActionResult OnPost()
    {
        using (var connection = DatabaseInitializer.GetConnection())
        {
            // aprire la connessione 
            connection.Open();
            var sql = @"INSERT INTO Prodotti (Nome, Prezzo, CategoriaId) VALUES (@nome, @prezzo, @categoria)";

            using (var command = new SQLiteCommand(sql,connection))
            {
                command.Parameters.AddWithValue("@nome", Prodotto.Nome);
                command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
                command.Parameters.AddWithValue("@categoria", Prodotto.CategoriaId);
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
                        Categorie.Add(new SelectListItem
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

