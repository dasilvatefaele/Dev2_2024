// Modello del prodotto
namespace _04_webapp_sqlite.Models;
public class ProdottoViewModel {
    // proprietà
    public int Id { get; set; }
    public string? Nome { get; set; }
    public double Prezzo { get; set; }
    public string? CategoriaNome { get; set; }
}
