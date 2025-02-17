using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace _04_webapp_sqlite.Categorie;
public class CreateModel : PageModel
{
    private readonly ILogger<CreateModel> _logger;

    [BindProperty]
    public Categoria Categoria { get; set; }

    public List<SelectListItem> Categorie { get; set; } = new List<SelectListItem>();

    public CreateModel(ILogger<CreateModel> logger)
    {
        _logger = logger;
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
            return Page();
        }

        try
        {
            var sql = @"INSERT INTO Categorie (Nome) VALUES (@nome)";
            UtilityDB.ExecuteNonQuery(sql, command =>
            {
                command.Parameters.AddWithValue("@nome", Categoria.Nome);
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Index");
    }
}

