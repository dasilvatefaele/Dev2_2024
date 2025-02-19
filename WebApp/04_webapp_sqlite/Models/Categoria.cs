using System.ComponentModel.DataAnnotations; // dipendenza DataAnnotations

namespace _04_webapp_sqlite.Models;

public class Categoria
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome della categoria è obbligatorio.")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Nome { get; set; }
}