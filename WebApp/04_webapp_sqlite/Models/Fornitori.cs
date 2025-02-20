namespace _04_webapp_sqlite.Models;

public class Fornitori
{
    public int Id { get; set; }
    public string Nome { get; set; }
    [Required]
    [EmailAddress]
    public string Contatto { get; set; }
}