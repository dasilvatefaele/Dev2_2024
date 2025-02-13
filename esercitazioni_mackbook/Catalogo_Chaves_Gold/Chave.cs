public class Chave
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Codigo { get; set; }
    public string Pagina { get; set; }
    
    public Chave() {}
    
    public Chave(string id, string nome, string codigo, string pagina)
    {
        Id = id;
        Nome = nome;
        Codigo = codigo;
        Pagina = pagina;
    }
}
