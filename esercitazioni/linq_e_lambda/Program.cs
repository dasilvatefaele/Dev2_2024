var ordini = new List<Ordine> 
{
    new Ordine { ClienteId = 1, Prodotto = "Laptop"},
    new Ordine { ClienteId = 2, Prodotto = "Smartphone"}
};

var clienti = new List<Cliente>
{
    new Cliente { Id = 1 , Nome = "Carlo"},
    new Cliente { Id = 2 , Nome = "Filippo"},
};

var joinQuery = from c in clienti
                join o in ordini
                on c.Id equals o.ClienteId
                select new { Cliente = c.Nome, Prodotto = o.Prodotto };

// oppure
var joinQueryAlt = clienti.Join(
    ordini, 
    c => c.Id,
    o => o.ClienteId,
    (c, o) => new { Cliente = c.Nome, Prodotto = o.Prodotto });

joinQueryAlt.ToList().ForEach(j => Console.WriteLine($"{j.Cliente} ha acquistato un {j.Prodotto}"));

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

class Ordine
{
    public int ClienteId { get; set; }
    public string Prodotto { get; set; }
}