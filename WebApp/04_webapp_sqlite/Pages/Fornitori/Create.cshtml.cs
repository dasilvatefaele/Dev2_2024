using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace _04_webapp_sqlite.Fornitori;
public class CreateModel : PageModel
{
    private readonly ILogger<CreateModel> _logger;

    [BindProperty]
    public Fornitore Fornitore { get; set; }

    public List<SelectListItem> FornitoriSelectList { get; set; } = new List<SelectListItem>();

    public CreateModel(ILogger<CreateModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        try
        {
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
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            //CaricaFornitori();
            try
            {
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
            var sql = @"INSERT INTO Fornitori (Nome, Contatto) VALUES (@nome, @contatto)";
            UtilityDB.ExecuteNonQuery(sql, command =>
            {
                command.Parameters.AddWithValue("@nome", Fornitore.Nome);
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

