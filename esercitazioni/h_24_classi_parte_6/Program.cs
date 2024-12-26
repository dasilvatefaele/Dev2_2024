using System.Runtime.CompilerServices;
using Newtonsoft.Json;


/*
// boilerplate c#

class Program 
{
    static void Main(string[] args) 
    {
    // ...
    }
}

*/


#region MAIN
class Program // <--- (standard/default)
{
    static void Main(string[] args) // <--- Entry point (standard/default)
    {
        ProdottoRepository repository = new ProdottoRepository();
        List<ProdottoAdvanced> prodotti =  repository.CaricaProdotti();
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager();

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
                    if (manager.OttieniProdotti() != null)
                    {
                        foreach(var prodotto in manager.OttieniProdotti())
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
                    // Console.Write("ID > ");
                    // int id = int.Parse(Console.ReadLine());
                    Console.Write("Nome > ");
                    string nome ="";
                    nome = Console.ReadLine();
                    Console.Write("Prezzo > ");
                    decimal prezzo = decimal.Parse(Console.ReadLine());
                    Console.Write("Giacenza > ");
                    int giacenza = int.Parse(Console.ReadLine());
                    manager.AggiungiProdotto(new ProdottoAdvanced {NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza});
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
                    Console.Write("ID da aggiornare> ");
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
                        manager.AggiungiProdotto(new ProdottoAdvanced {NomeProdotto = nomeAggiornato, PrezzoProdotto = prezzoAggiornato, GiacenzaProdotto = giacenzaAggiornata});
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
#endregion

#region PRODOTTO ADVANCE
public class ProdottoAdvanced
{
    // private static ProdottoRepository localRepository = new ProdottoRepository();
    // private static List<ProdottoAdvanced> prodotti = localRepository.CaricaProdotti();

    

    private static int ultimoId = 0; // Campo statico per tracciare l'ultimo ID generato
                                     // è privata perché non voglio che venga modificata dall'esterno
                                     // è static perché voglio che sia condiviso con tutte le istanze della classe
    private int id; // campo privato
    
    public int Id 
    { 
        get { return id; } 
        private set { id = value; } // Rende il setter privato per impedire modifiche manuali all'Id
                                    // value è definito implicitamente dal compilatore 
                                    // e rappresenta il valore assegnato alla proprietà
                                    // value è una variabile locale e non può essere utilizzata nel setter
                                    // value è quello che si chiama parametro implicito, 
                                    // cioè non lo devo dichiarare io ma è già dichiarato dal compilatore
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

    // Costruttore per generare automaticamente l'Id
    // quando viene creato un nuovo oggetto ProdottoAdvaned con il costruttore vuoto (senza parametri)
    // viene chiamato questo costruttore (cistruttore di default)
    // che genera un nuovo ID e lo assegna all'oggetto usando il metodo GeneraId
    // invece gli altri parametri (NomeProdotto, GiacenzaProdotto, PrezzoProdotto), vengono inizializzati con valori di default (null, 0,0)
    // ed in seguito vengono assegnati i valori inseriti dall'utente
    public ProdottoAdvanced()
    {
        Id = GeneraId();
    }

    // Metodo statico per generare un ID progressivo
    // è statico perché in questo caso mi serve che sia condiviso tra tutte le istanze della classe
    // in modo che l'ID sia univoco per ogni prodotto
    private static int GeneraId()
    {
        // foreach (var prodotto in prodotti)
        // {
        //     ultimoId = prodotto.Id;
        // }
        ultimoId++;
        return ultimoId;
    }
}
#endregion

#region PRODOTTO ADVANCED MANAGER
public class ProdottoAdvancedManager
{  
    private List<ProdottoAdvanced> prodotti; // prodotti e' private perche non voglio che venga modificato dall'esterno
    

    public ProdottoAdvancedManager()
    {
        prodotti = new List<ProdottoAdvanced>(); 
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
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
        }
    }
}

#endregion

#region  REPOSITORY PRODOTTO
public class ProdottoRepository
{
    private readonly string filePath = "prodotti.json"; // percorso in cui memorizzare i dati

    //metodo per salvare i dati su file 
    public void SalvaProdotti(List<ProdottoAdvanced> prodotti)
    {
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine($"Dati salvati in {filePath}:\n{jsonData}");
    }

    public List<ProdottoAdvanced> CaricaProdotti()
    {
        if(File.Exists(filePath))
        {
            string readJsonData = File.ReadAllText(filePath);
            List<ProdottoAdvanced> prodotti = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData);
            Console.WriteLine("Dati caricati da file:");
            foreach (var prodotto in prodotti)
            {
                Console.WriteLine($"ID: {prodotto.Id} - Nome: {prodotto.NomeProdotto} - Prezzo: {prodotto.PrezzoProdotto} - Giacenza: {prodotto.GiacenzaProdotto}");
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

#endregion
// La gestione dei file json è più sicura se il path è privato
// dunque ogni file json avrà la propria Class Repository per salvare e caricare
// la cosa più furba è mantenere i vari blocchi modulari (riutilizzabili)
// piuttosto che fare una classe che fa più cose

