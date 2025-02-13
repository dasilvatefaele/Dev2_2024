using System.ComponentModel.DataAnnotations;

// Modello del prodotto
namespace WebAppSqlite.Models;

public class Prodotto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome del prodotto è obbligatorio.")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Il prezzo è obbligatorio.")]
    [Range (0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di 0")]
    public double Prezzo { get; set; }

    [Required(ErrorMessage = "La categoria è obbligatoria.")]
    public int CategoriaId { get; set; }
}