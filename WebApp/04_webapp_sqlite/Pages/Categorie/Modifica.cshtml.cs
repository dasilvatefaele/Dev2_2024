// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using System.Data.SqlClient;
// using System.Data.SQLite;

namespace _04_webapp_sqlite.Categorie;
public class Modifica : PageModel
{
    [BindProperty]
    public Categoria Categoria { get; set; }

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
            }
            );
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
        if (!ModelState.IsValid) 
        {

            return Page();
        }
        
        try{
        var sql = $"UPDATE Categorie SET Nome = @nome WHERE id = @id";
        UtilityDB.ExecuteNonQuery(sql, command =>
        {
            command.Parameters.AddWithValue("@nome", Categoria.Nome);
                command.Parameters.AddWithValue("@id", Categoria.Id);
        });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Index");
    }
}