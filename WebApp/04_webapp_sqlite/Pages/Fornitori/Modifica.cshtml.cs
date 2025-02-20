// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using System.Data.SqlClient;
// using System.Data.SQLite;

namespace _04_webapp_sqlite.Fornitori;
public class Modifica : PageModel
{
    [BindProperty]
    public Fornitore Fornitore { get; set; }

    public IActionResult OnGet(int id)
    {
        try
        {
            var sql = "SELECT Id, Nome, Contatto FROM Fornitori WHERE id = @id";
            var Fornitori = UtilityDB.ExecuteReader(sql, reader => new Fornitore
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Contatto = reader.GetString(2)
            },
            command =>
            {
                command.Parameters.AddWithValue("@id", id);
            }
            );
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
        if (!ModelState.IsValid) 
        {

            return Page();
        }
        
        try{
        var sql = $"UPDATE Fornitori SET Nome = @nome, Contatto = @contatto WHERE id = @id";
        UtilityDB.ExecuteNonQuery(sql, command =>
        {
            command.Parameters.AddWithValue("@nome", Fornitore.Nome);
                command.Parameters.AddWithValue("@id", Fornitore.Id);
                command.Parameters.AddWithValue("@contatto", Fornitore.Contatto);
        });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Index");
    }
}