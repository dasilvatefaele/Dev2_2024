public class Cliente
{
    public int Id { get; set;}
    public string Username { get; set;}
    public List<ProdottoCarrello> Carrello { get; set;}
    public List<ProdottoCarrello> StoricoAcquisti { get; set;}
    public int PercentualeSconto { get; set;}
    public decimal Credito { get; set;}
    // private int _id;
    // public int Id
    // {
    //     get { return _id; }
    //     set
    //     {
    //         _id = value;
    //     }
    // }

    // private string _username;
    // public string Username
    // {
    //     get { return _username; }
    //     set
    //     {
    //         _username = value;
    //     }
    // }

    // private List<Prodotto> _carrello;
    // public List<Prodotto> Carrello
    // {
    //     get { return _carrello; }
    //     set
    //     {
    //         _carrello = value;
    //     }
    // }

    // private List<Prodotto> _storicoAcquisti;
    // public List<Prodotto> StoricoAcquisti
    // {
    //     get { return _storicoAcquisti; }
    //     set
    //     {
    //         _storicoAcquisti = value;
    //     }
    // }

    // private int _percentualeSconto;
    // public int PercentualeSconto
    // {
    //     get { return _percentualeSconto; }
    //     set
    //     {
    //         _percentualeSconto = value;
    //     }
    // }

    // private decimal _credito;
    // public decimal Credito
    // {
    //     get { return _credito; }
    //     set
    //     {
    //         _credito = value;
    //     }
    // }
}