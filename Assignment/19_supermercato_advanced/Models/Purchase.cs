public class Purchase
{
    public int Id { get; set; }
    public Cliente PurchaseCliente { get; set; }
    public List<ProdottoCarrello> MyPurchase { get; set; }
    public string Data { get; set; }
    public bool Stato { get; set; }
}