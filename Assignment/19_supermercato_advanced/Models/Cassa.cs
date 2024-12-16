public class Cassa
{
    public int Id { get; set; } 
    public Dipendente Cassiere { get; set; } 
    public List<Prodotto> Acquisti { get; set; }
    public bool ScontrinoProcessato { get; set; }
}
