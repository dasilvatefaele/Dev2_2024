public class Cliente
{
    public int Id { get; set;}
    public string Username { get; set;}
    public List<ProdottoCarrello> Carrello { get; set;}
    public List<ProdottoCarrello> StoricoAcquisti { get; set;}
    public int PercentualeSconto { get; set;}
    public decimal Credito { get; set;}
}