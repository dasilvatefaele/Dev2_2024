public class Cliente
{
    public int Id { get; set; }
    public string Username { get; set; }
    public Carrello Cart { get; set; }
    public List<StoricoAcquisti> StoricoAcquisti { get; set; }
    public int PercentualeSconto { get; set; }
    public decimal Credito { get; set; }
}