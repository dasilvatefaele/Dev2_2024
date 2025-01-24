using Newtonsoft.Json;

// comando per installare il pacchetto Newtonsoft.Json
// dotnet add package Newtonsoft.Json
class Program
{
    static void Main(string[] args)
    {
        // Creare un oggetto di tipo ProdottoAdvancedManager per gestire i prodotti
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager();

        // Aggiungere prodotti alla lista con il metodo AggiungiProdotto della classe ProdottoAdvancedManager (manager)
        manager.AggiungiProdotto(new ProdottoAdvanced { Id = 1, NomeProdotto = "Prodotto A", PrezzoProdotto = 10.50m, GiacenzaProdotto = 100 });
        manager.AggiungiProdotto(new ProdottoAdvanced { Id = 2, NomeProdotto = "Prodotto B", PrezzoProdotto = 20.75m, GiacenzaProdotto = 50 });

        // Visualizzare i prodotti con il metodo OttieniProdotti della classe ProdottoAdvancedManager (manager)
        Console.WriteLine("Prodotti:");
        foreach (var prodotto in manager.OttieniProdotti())
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }

        // Trovare un prodotto per ID con il metodo TrovaProdotto della classe ProdottoAdvancedManager (manager)
        int idProdotto = 1;
        ProdottoAdvanced prodottoTrovato = manager.TrovaProdotto(idProdotto);
        if (prodottoTrovato != null)
        {
            Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: \n{prodottoTrovato.NomeProdotto}");
        }
        else
        {
            Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
        }

        // Aggiornare un prodotto con il metodo AggiornaProdotto della classe ProdottoAdvancedManager (manager)
        int idProdottoDaAggiornare = 2;
        ProdottoAdvanced nuovoProdotto = new ProdottoAdvanced { Id = 2, NomeProdotto = "Prodotto C", PrezzoProdotto = 30.25m, GiacenzaProdotto = 75 };
        manager.AggiornaProdotto(idProdottoDaAggiornare, nuovoProdotto);

        // Visualizzare i prodotti aggiornati con il metodo OttieniProdotti della classe ProdottoAdvancedManager (manager)
        Console.WriteLine("\nProdotti aggiornati:");
        foreach (var prodotto in manager.OttieniProdotti())
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }

        // Eliminare un prodotto con il metodo EliminaProdotto della classe ProdottoAdvancedManager (manager)
        int idProdottoDaEliminare = 1;
        manager.EliminaProdotto(idProdottoDaEliminare);

        // Visualizzare i prodotti rimanenti con il metodo OttieniProdotti della classe ProdottoAdvancedManager (manager)
        Console.WriteLine("\nProdotti rimanenti:");
        foreach (var prodotto in manager.OttieniProdotti())
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }
    }
}

public class ProdottoAdvanced

{
    private int id;  
    public int Id
    {
        get { return id; }    
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il valore dell'ID deve essere maggiore di zero.");
            }
            id = value;
        }
    }

    private string nomeProdotto;
    public string NomeProdotto
    {
        get { return nomeProdotto; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Il nome del prodotto non può essere vuoto.");
            }
            nomeProdotto = value;
        }
    }

    private decimal prezzoProdotto;
    public decimal PrezzoProdotto
    {
        get { return prezzoProdotto; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il prezzo deve essere maggiore di zero.");
            }
            prezzoProdotto = value;
        }
    }

    private int giacenzaProdotto;
    public int GiacenzaProdotto
    {
        get { return giacenzaProdotto; }
        set { giacenzaProdotto = value; }
    }
}

public class ProdottoAdvancedManager
{
    private List<ProdottoAdvanced> prodotti; // prodotti e private perche non voglio che venga modificato dall'esterno

    public ProdottoAdvancedManager()
    {
        prodotti = new List<ProdottoAdvanced>(); // inizializzo la lista di prodotti nel costruttore pubblco in modo che sia accessibile all'esterno
    }

    // metodo per aggiungere un prodotto alla lista
    public void AggiungiProdotto(ProdottoAdvanced prodotto)
    {
        prodotti.Add(prodotto);
    }

    // metodo per visualizzare la lista di prodotti
    public List<ProdottoAdvanced> OttieniProdotti()
    {
        return prodotti;
    }

    // metodo per cercare un prodotto
    public ProdottoAdvanced TrovaProdotto(int id)
    {
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                return prodotto;
            }
        }
        return null;
    }

    // metodo per mpdificare un prodotto esistente
    public void AggiornaProdotto(int id, ProdottoAdvanced nuovoProdotto)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotto.NomeProdotto = nuovoProdotto.NomeProdotto;
            prodotto.PrezzoProdotto = nuovoProdotto.PrezzoProdotto;
            prodotto.GiacenzaProdotto = nuovoProdotto.GiacenzaProdotto;
        }
    }

    // metodo per eliminare un prodotto
     public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
        }
    }
}