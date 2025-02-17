using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        var sql = "SELECT Id, Nome, Prezzo, CategoriaId FROM Prodotti WHERE id = @id";
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
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        // using (var connection = DatabaseInitializer.GetConnection())
        // {
        //     connection.Open();

        // using (var command = new SQLiteCommand(sql, connection))
        // {
        //     command.Parameters.AddWithValue("@id", id);

        //     using (var reader = command.ExecuteReader())
        //     {
        //         if (reader.Read())
        //         {
        //             Prodotto = new Prodotto
        //             {
        //                 Id = reader.GetInt32(0),
        //                 Nome = reader.GetString(1),
        //                 Prezzo = reader.GetDouble(2),
        //                 CategoriaId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
        //             };
        //         }
        //         else
        //         {
        //             return NotFound();

        //         }
        //     }
        // }
        //}
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


        // using (var connection = DatabaseInitializer.GetConnection())
        // {
        //     connection.Open();

        //     // costruisco la query basandomi sull'input dell'utente

        //     var sql = $"DELETE FROM Prodotti WHERE id = @id";


        //     using (var command = new SQLiteCommand(sql, connection))
        //     {
        //         command.Parameters.AddWithValue("@id", Prodotto.Id);
        //         command.ExecuteNonQuery();
        //         _logger.LogInformation("Sto eseguendo il comando");
        //     }
        // }
        return RedirectToPage("Index");
    }
}
