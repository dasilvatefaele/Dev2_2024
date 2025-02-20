// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using System.Data.SqlClient;
// using System.Data.Sqlite;

namespace _04_webapp_sqlite.Prodotti;
public class Modifica : PageModel
{
    [BindProperty]
    public Prodotto Prodotto { get; set; }

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public List<SelectListItem> CategoriaSelectList { get; set; } = new List<SelectListItem>();
    public List<SelectListItem> FornitoriSelectList { get; set; } = new List<SelectListItem>();

    public IActionResult OnGet(int id)
    {
        try
        {
            CategoriaSelectList = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new SelectListItem
            {
                Value = reader.GetInt32(0).ToString(),
                Text = reader.GetString(1)
            });

            FornitoriSelectList = UtilityDB.ExecuteReader("SELECT * FROM Fornitori", reader => new SelectListItem
            {
                Value = reader.GetInt32(0).ToString(),
                Text = reader.GetString(1)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        try
        {
            var sql = @"
            SELECT Id, Nome, Prezzo, CategoriaId, FornitoreId
            FROM Prodotti WHERE id = @id";
            var Prodotti = UtilityDB.ExecuteReader(sql, reader => new Prodotto
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaId = reader.GetInt32(3),
                FornitoreId = reader.GetInt32(4)
            },
            command =>
            {
                command.Parameters.AddWithValue("@id", id);
            });
            Prodotto = Prodotti.First();
            Id = Prodotto.Id;
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return Page();
    }



    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) // se il modello non è valido
        {
            //CaricaCategorie();
            try
            {
                CategoriaSelectList = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new SelectListItem
                {
                    Value = reader.GetInt32(0).ToString(),
                    Text = reader.GetString(1)
                });

                FornitoriSelectList = UtilityDB.ExecuteReader("SELECT * FROM Fornitori", reader => new SelectListItem
                {
                    Value = reader.GetInt32(0).ToString(),
                    Text = reader.GetString(1)
                });
            }
            catch (Exception ex)
            {
                SimpleLogger.Log(ex);
            }
            return Page();
        }

        try
        {
            var sql = $"UPDATE Prodotti SET Nome = @nome, Prezzo = @prezzo, CategoriaId = @categoriaid, FornitoreId = @fornitoreid WHERE id = @id";
            UtilityDB.ExecuteNonQuery(sql, command =>
            {
                command.Parameters.AddWithValue("@nome", Prodotto.Nome);
                command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
                command.Parameters.AddWithValue("@categoriaid", Prodotto.CategoriaId);
                command.Parameters.AddWithValue("@id", Prodotto.Id);
                command.Parameters.AddWithValue("@fornitoreid", Prodotto.FornitoreId);
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Index");
    }
}