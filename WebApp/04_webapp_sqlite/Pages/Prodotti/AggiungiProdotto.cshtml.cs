// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using System.Data.SqlClient;
// using System.Data.SQLite;

namespace _04_webapp_sqlite.Prodotti;
public class AggiungiProdottoModel : PageModel
{
    private readonly ILogger<AggiungiProdottoModel> _logger;

    [BindProperty]
    public Prodotto Prodotto { get; set; }

    public List<SelectListItem> Categorie { get; set; } = new List<SelectListItem>();


    public AggiungiProdottoModel()
    {
        Prodotto = new Prodotto();
        //CaricaCategorie();
         try
        {
            Categorie = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new SelectListItem
            {
                Value = reader.GetInt32(0).ToString(),
                Text = reader.GetString(1)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }

    public void OnGet()
    {
        try
        {
            Categorie = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new SelectListItem
            {
                Value = reader.GetInt32(0).ToString(),
                Text = reader.GetString(1)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            try
            {
                Categorie = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new SelectListItem
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

        var sql = @"INSERT INTO Prodotti (Nome, Prezzo, CategoriaId) VALUES (@nome, @prezzo, @categoria)";

        try
        {
            UtilityDB.ExecuteNonQuery(sql, command =>
            {
                command.Parameters.AddWithValue("@nome", Prodotto.Nome);
                command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
                command.Parameters.AddWithValue("@categoria", Prodotto.CategoriaId);
            }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Index");
    }
}

