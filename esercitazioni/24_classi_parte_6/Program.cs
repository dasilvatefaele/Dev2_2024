using System.Runtime.CompilerServices;
using Newtonsoft.Json;

// dipendenze:
// dotnet add package Newtonsoft.Json

class Program // <--- (standard/default)
{
    static void Main(string[] args) // <--- Entry point (standard/default)
    {
        Console.Clear();
        ProdottoRepository repository = new ProdottoRepository();
        List<ProdottoAdvanced> prodotti =  repository.CaricaProdotti();
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);

        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Visualizza");
            Console.WriteLine("2. Aggiungi");
            Console.WriteLine("3. Trova per ID");
            Console.WriteLine("4. Aggiorna");
            Console.WriteLine("5. Elimina");
            Console.WriteLine("0. Esci");
        
            Console.Write("> ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nProdotti:");
                    if (prodotti != null)
                    {
                        foreach(var prodotto in prodotti)
                        {
                            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                    }
                break;
                case "2":
                    Console.Write("ID > ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Nome > ");
                    string nome ="";
                    nome = Console.ReadLine();
                    Console.Write("Prezzo > ");
                    decimal prezzo = decimal.Parse(Console.ReadLine());
                    Console.Write("Giacenza > ");
                    int giacenza = int.Parse(Console.ReadLine());
                    manager.AggiungiProdotto(new ProdottoAdvanced {Id = id, NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza});
                break;
                case "3":
                    Console.Write("ID > ");
                    int idProdotto = int.Parse(Console.ReadLine());
                    ProdottoAdvanced prodottoTrovato = manager.TrovaProdotto(idProdotto);

                    if (prodottoTrovato != null)
                    {
                        Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.NomeProdotto}");
                    }
                    else
                    {
                        Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                    }
                break;
                case "4":
                    Console.Write("ID > ");
                    int idProdottoDaAggiornare = int.Parse(Console.ReadLine());
                    ProdottoAdvanced prodottoTrovato2 = manager.TrovaProdotto(idProdottoDaAggiornare);
                    if (prodottoTrovato2 != null)
                    {
                        int idBackup = prodottoTrovato2.Id;
                        manager.EliminaProdotto(idBackup);
                        Console.Write("Nome > ");
                        string nomeAggiornato = Console.ReadLine();
                        Console.Write("Prezzo > ");
                        decimal prezzoAggiornato = decimal.Parse(Console.ReadLine());
                        Console.Write("Giacenza > ");
                        int giacenzaAggiornata = int.Parse(Console.ReadLine());
                        manager.AggiungiProdotto(new ProdottoAdvanced {Id = idBackup, NomeProdotto = nomeAggiornato, PrezzoProdotto = prezzoAggiornato, GiacenzaProdotto = giacenzaAggiornata});
                    }
                    else
                    {
                        Console.WriteLine($"\nProdotto non trovato per ID {idProdottoDaAggiornare}");
                    }
                break;
                case "5":
                    Console.Write("ID > ");
                    int idProdottoDaEliminare = int.Parse(Console.ReadLine());
                    manager.EliminaProdotto(idProdottoDaEliminare);
                break;
                case "0":
                    continua = false;
                    repository.SalvaProdotti(manager.OttieniProdotti());
                    Console.WriteLine("Arrivederci!\n");
                break;
            }
        }
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
    private readonly string filePath = "prodotti.json"; // percorso in cui memorizzare i dati
    private readonly string dirCatalogo = "catalogo";
    private ProdottoRepository repo;

    public ProdottoAdvancedManager(List<ProdottoAdvanced> Prodotti)
    {
        prodotti = Prodotti;
        repo = new ProdottoRepository(); //! non la sto usando ma è buono sapere che il costruttore inizializzi le variabili dichiarate nella classe
        //this.prodotti = prodotti; //? "collego" la variabile prodotti passata come argomento alla variabile privata

        // inizializzo la lista di prodotti nel costruttore pubblico in modo che sia accessibile all'esterno
        // questo new è necessario affinchè dal dominio privato la classe possa comunicare all'esterno i dati aggiornati/manipolati
        // un modo per rendere pubblico un dato privato
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
        var prodotto = TrovaProdotto(id); // salvo il prodotto nella variabile se lo trovo, se non lo trova prodotto = null
        if (prodotto != null) // se lo trova
        {
            string[] files = Directory.GetFiles(dirCatalogo); // salvo l'elenco di file nella cartella 
            foreach (string file in files) // per ogni file nella cartella 
            {
                string readJsonData = File.ReadAllText (file); // leggo il contenuto del file 
                ProdottoAdvanced prodottoTemporaneo = JsonConvert.DeserializeObject<ProdottoAdvanced>(readJsonData)!; // lo deserializzo in un prodotto temporaneo
                if (prodottoTemporaneo.Id == id) // se l'id del prodotto temporaneo è uguale all'id inserito dall'utente
                {
                    File.Delete(file); // elimina il file 
                }
            }
            prodotti.Remove(prodotto); // rimuovi il prodotto dalla lista runtime
        }
    }
}


// La gestione dei file json è più sicura se il path è privato
// dunque ogni file json avrà la propria Class Repository per salvare e caricare
// la cosa più furba è mantenere i vari blocchi modulari (riutilizzabili)
// piuttosto che fare una classe che fa più cose

