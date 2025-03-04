using System.ComponentModel.DataAnnotations;

// Modello del prodotto
namespace _04_webapp_sqlite.Models;

public class Prodotto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome del prodotto è obbligatorio.")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Necessario inserire il prezzo")]
    [Range (0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di 0")]
    // se contiene una punto stampa il prezzo deve esser separato da una virgola
    // [RegularExpression(@"^\d+(\,\d{1,2})?$", ErrorMessage = "Il prezzo deve essere un numero con al massimo 2 decimali.")]
    public double Prezzo { get; set; }

    [Required(ErrorMessage = "La categoria è obbligatoria.")]
    public int CategoriaId { get; set; }
    [Required(ErrorMessage = "Il fornitore è obbligatorio.")]
    public int FornitoreId { get; set; }
}