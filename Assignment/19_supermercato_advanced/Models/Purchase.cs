public class Purchase
{
    public int IdPurchase { get; set; } // automatico
    public int IdCliente { get; set; }
    public string NomeCliente { get; set; }
    public Carrello MyPurchase { get; set; }
    public string Data { get; set; }
    public decimal Totale { get; set; }
    public bool Completed { get; set; }
}