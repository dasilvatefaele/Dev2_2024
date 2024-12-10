using System.Runtime.CompilerServices;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        // creare un oggetto di tipo ProdottoAdvancedManager per gestire i prodotti
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager();

        // creo un oggetto per gestire il salvataggio e il caricamento dei dati su json
        ProdottoRepository repository = new ProdottoRepository();

        List<ProdottoAdvanced> prodotti = repository.CaricaProdotti();

        // aggiungere i prodotti alla lista con il metodo aggiungi prodotto della classe ProdottoAdvancedManager (ovvero manager)
        manager.AggiungiProdotto(new ProdottoAdvanced { Id = 1, NomeProdotto ="esempio" , PrezzoProdotto = 12.50m, GiacenzaProdotto = 100});
        manager.AggiungiProdotto(new ProdottoAdvanced { Id = 2, NomeProdotto ="esempio2", PrezzoProdotto = 19.99m, GiacenzaProdotto = 150});
       
        //visualizzo i prodotti attraverso il metodo Ottieni prodotti
        foreach (var prodotto in manager.OttieniProdotti())
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }
        
        int idProdotto = 2;
        ProdottoAdvanced prodottoTrovato = manager.TrovaProdotto(idProdotto);
        if (prodottoTrovato != null)
        {
            Console.WriteLine($"Prodotto trovato per {idProdotto}: {prodottoTrovato.NomeProdotto}");
        }
        else
        {
            Console.WriteLine($"Prodotto non trovato per ID {idProdotto}");
        }

        // Aggiornare un prodotto con il metodo AggiornaProdotto della classe ProdottoAdvancedManager
        int idProdottoDaAggiornare = 2;
        ProdottoAdvanced nuovoProdotto = new ProdottoAdvanced { Id = 2, NomeProdotto ="esempio3", PrezzoProdotto = 29.99m, GiacenzaProdotto = 250};
        manager.AggiornaProdotto(idProdottoDaAggiornare, nuovoProdotto);

        // visualizzare i prodotti aggiornati
       foreach (var prodotto in manager.OttieniProdotti())
       {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza:  {prodotto.GiacenzaProdotto}");
       }
        
        // Elimina un prodotto
        int idDaEliminare = 1;
        manager.EliminaProdotto(idDaEliminare);

        // visualizza prodotti rimanenti
        Console.WriteLine("");
        foreach (var prodotto in manager.OttieniProdotti())
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza {prodotto.GiacenzaProdotto}");
        }

        // salvare i prodotti su file json con il metodo SalvaProdotti
        repository.SalvaProdotti(manager.OttieniProdotti());
        prodotti = repository.CaricaProdotti(); 

        // TODO : metodi per la serializzazione e deserializzazione !!!
    }
}

public class ProdottoAdvanced
{
    private int id; // campo privato
    
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

    private string nomeProdotto;  // campo privato
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
    
    private decimal prezzoProdotto;  // campo privato
    public decimal PrezzoProdotto 
    { 
        get {return prezzoProdotto;}
        set 
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il prezzo deve essere maggiore di zero");
            }
            prezzoProdotto = value;
        }
    }
    private int giacenzaProdotto;  // campo privato
    public int GiacenzaProdotto 
    { 
        get { return giacenzaProdotto;}
        set 
        { 
            if (value <= 0)
            {
                throw new ArgumentException("La giacenza non può essere negativa");
            }
            giacenzaProdotto = value;
        }
    }
}

public class ProdottoAdvancedManager
{
    private List<ProdottoAdvanced> prodotti; // prodotti e' private perche non voglio che venga modificato dall'esterno

    public ProdottoAdvancedManager()
    {
        prodotti = new List<ProdottoAdvanced>(); // inizializzo la lista di prodotti nel costruttore pubblico in modo che sia accessibile all'esterno
    }

    // metodo per aggiungere
    public void AggiungiProdotto (ProdottoAdvanced prodotto)
    {
        prodotti.Add(prodotto); // quella private
    }

    // metodo per visualizzare 
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

    // metodo per modificare il prodotto
    public void AggiornaProdotto(int id, ProdottoAdvanced nuovoProdotto)
    {
        var prodotto = TrovaProdotto (id);
        if (prodotto != null)
        {
            prodotto.NomeProdotto = nuovoProdotto.NomeProdotto;
            prodotto.PrezzoProdotto = nuovoProdotto.PrezzoProdotto;
            prodotto.GiacenzaProdotto = nuovoProdotto.GiacenzaProdotto;
        }
    }

    // metodo per eliminare un prodotto
    public void EliminaProdotto (int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
        }
    }
}

public class ProdottoRepository
{
    // la classe i occupa di gestire la persistenza dei dati in modo centralizzato
    // i vantaggi sono
    // - centralizzazioni della logica
    // - facilità di manutenzione
    // - falicità di test
    // - possibilità di cambiare il tipo di persistenza senza dover modificare il codice che utilizza la classe
    // - possibilità di aggiungere una logica di caching (memorizzazione temporanea dei dati) senza dover modificare il codice che utilizza la classe

    // filePath è il percorso e ha il modificatore private 
    // perché non vogliamo venga modificato dall'esterno della classe prima di essere utilizzato

    private readonly string filePath = "prodotti.json"; // percorso in cui memorizzare i dati

    //metodo per salvare i dati su file 
    public void SalvaProdotti(List<ProdottoAdvanced> prodotti)
    {
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine($"Dati salvati in {filePath}:\n{jsonData}");
    }

    // metodo per caricare i dati da file
    // restituisce una lista di prodotti se il file esiste e contiene dati

    public List<ProdottoAdvanced> CaricaProdotti()
    {
        if(File.Exists(filePath))
        {
            string readJsonData = File.ReadAllText(filePath);
            List<ProdottoAdvanced> prodotti = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData);
            Console.WriteLine("Dati caricati da file:");
            foreach (var prodotto in prodotti)
            {
                Console.WriteLine($"ID: {prodotto.Id}, Nome {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
            }
            // restituisco la lista di prodotti letti dal file in modo che possa essere utilizzata all'esterno della classe
            return prodotti;
        }
        else
        {
            Console.WriteLine("Nessun dato trovato. Inizializzare una nuova lista di prodotti.");
            // restituisco una lista di prodotti vuota se il file non esisteo è vuoto
            return new List<ProdottoAdvanced>(); 
        }
    }
}