// Modello del prodotto
namespace WebAppSqlite.Models;
public class Prodotto {
    // proprietà
    public int Id { get; set; }
    public string? Nome { get; set; }
    public double Prezzo { get; set; }
    public int CategoriaId { get; set; }

}
    // aggiungiamo un campo per l'immagine
