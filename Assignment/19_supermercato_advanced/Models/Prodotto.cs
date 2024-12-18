public class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Prezzo { get; set; }
    public int Giacenza {get; set; }
    public Categoria Categoria { get; set; }
}