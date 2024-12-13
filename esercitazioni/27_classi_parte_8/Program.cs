using System.Runtime.CompilerServices;
using Newtonsoft.Json;

// dipendenze:
// dotnet add package Newtonsoft.Json

#region MAIN
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
            // Console.Write("> ");
            // string scelta = Console.ReadLine();
            string scelta = InputManager.LeggiIntero("> ", 0, 5).ToString();
            Console.Clear();

            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nProdotti:");
                    if (prodotti != null)
                    {
                        StampaTabella.ComeAdmin(prodotti);                    
                    }
                    else
                    {
                        Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                    }
                break;
                case "2":
                    string nome = InputManager.LeggiStringa("Nome > ");
                    decimal prezzo = InputManager.LeggiDecimale("Prezzo > ");
                    int giacenza = InputManager.LeggiIntero("Giacenza > ", 0);
                    //Console.Write("Nome > ");
                    // Console.Write("Prezzo > ");
                    //Console.Write("Giacenza > ");
                    manager.AggiungiProdotto(new ProdottoAdvanced {NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza});
                    repository.SalvaProdotti(prodotti);                   
                break;
                case "3":
                    prodotti = repository.CaricaProdotti();
                    // Console.Write("ID > ");
                    int idProdotto = InputManager.LeggiIntero("ID > ", 0);
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
                    // Console.Write("ID > ");
                    StampaTabella.ComeAdmin(prodotti);
                    int idProdottoDaAggiornare = InputManager.LeggiIntero("ID > ", 0);
                    ProdottoAdvanced prodottoTrovato2 = manager.TrovaProdotto(idProdottoDaAggiornare);
                    if (prodottoTrovato2 != null)
                    {
                        string nomeAggiornato = InputManager.LeggiStringa("Nome > ");
                        decimal prezzoAggiornato = InputManager.LeggiDecimale("Prezzo > ");
                        int giacenzaAggiornata = InputManager.LeggiIntero("Giacenza > ");
                        //int idBackup = prodottoTrovato2.Id;
                        //Console.Write("Nome > ");
                        //Console.Write("Prezzo > ");
                        //Console.Write("Giacenza > ");
                        manager.AggiornaProdotto(idProdottoDaAggiornare, new ProdottoAdvanced {NomeProdotto = nomeAggiornato, PrezzoProdotto = prezzoAggiornato, GiacenzaProdotto = giacenzaAggiornata});
                    }
                    else
                    {
                        Console.WriteLine($"\nProdotto non trovato per ID {idProdottoDaAggiornare}");
                    }
                break;
                case "5":
                    StampaTabella.ComeAdmin(prodotti);
                    //Console.Write("ID > ");
                    // int idProdottoDaEliminare = int.Parse(Console.ReadLine());
                    int idProdottoDaEliminare = InputManager.LeggiIntero("ID > ", 0);
                    manager.EliminaProdotto(idProdottoDaEliminare);
                break;
                case "0":
                    continua = false;
                    repository.SalvaProdotti(manager.OttieniProdotti());
                    Console.WriteLine("Arrivederci!\n");
                break;
                default:
                    Console.WriteLine("INSERIMENTO MENU NON VALIDO\n");
                    // dato che c'è il controllo di acquisizione nella scelta
                    // questo messaggio non dovrebbe apparire mai
                break;
            }
        }
    }
}
#endregion
#region PRODOTTOADVANCED
public class ProdottoAdvanced
{
    private int id; // campo privato
    private string nomeProdotto;  // campo privato
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
#endregion
#region MANAGER
public class ProdottoAdvancedManager
{  
    private List<ProdottoAdvanced> prodotti; // prodotti e' private perche non voglio che venga modificato dall'esterno
    private readonly string filePath = "prodotti.json"; // percorso in cui memorizzare i dati
    private readonly string dirCatalogo = "catalogo";
    // private ProdottoRepository repo;
    private int prossimoId;
    public ProdottoAdvancedManager(List<ProdottoAdvanced> Prodotti)
    {
        prodotti = Prodotti;
        // repo = new ProdottoRepository(); //! non la sto usando ma è buono sapere che il costruttore inizializzi le variabili dichiarate nel campo della classe

        prossimoId = 1;
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id >= prossimoId)
            {
                prossimoId = prodotto.Id + 1;
            }
        }

        //this.prodotti = prodotti; //? "collego" la variabile prodotti passata come argomento alla variabile privata

        // inizializzo la lista di prodotti nel costruttore pubblico in modo che sia accessibile all'esterno
        // questo new è necessario affinchè dal dominio privato la classe possa comunicare all'esterno i dati aggiornati/manipolati
        // un modo per rendere pubblico un dato privato
    }

    // metodo per aggiungere
    public void AggiungiProdotto (ProdottoAdvanced prodotto)
    {
        prodotto.Id = prossimoId;
        prossimoId++;
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
                    // repo.SalvaProdotti(prodotti);
                }
            }
            prodotti.Remove(prodotto); // rimuovi il prodotto dalla lista runtime
        }
    }
}
#endregion
#region INPUTMANAGER
// classe di gestione degli input per semplificare l'acquisizione e la 
// validazione degli input. Questa classe aiuta a gestire i casi di errore e 
// fornisce metodi per acquisire input di diversi tipi
//* int min = int.MinValue è la costante minima dei valori interi. 
//* int max = int.MaxValue è la costante massima dei valori interi
//* quando chiamiamo il metodo, se inseriamo l'argomento, lo sovrascrive
//* se non lo inseriamo, la variabile avrà il valore dichiarato 
//* nella definizione del metodo
public static class InputManager
{
    public static int LeggiIntero(string messaggio, int min = int.MinValue, int max = int.MaxValue)
    {
        int valore; // per memorizzare intero acquisito
        while (true)
        {
            Console.Write($"{messaggio}"); // messaggio è la variabile di input
            string input = Console.ReadLine(); // acquisisco input come stringa
            // provo a convertire 
            if (int.TryParse(input, out valore) && valore >= min && valore <= max)
            {
                return valore; 
                // restituisce ed esce dal ciclo quando trova il valore
            }
            else
            {
                Console.WriteLine($"Inserire un valore intero compreso tra {min} e {max}");
            }
        }
    }
    public static decimal LeggiDecimale (string messaggio, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
    {
        decimal valore;
        while(true)
        {
            Console.Write($"{messaggio}"); // messaggio è la variabile di input
            string input = Console.ReadLine(); // acquisisco input come stringa

            // sostituisco la virgola con il punto
            if (input.Contains(".")) //(input.Contains(",") && !input.Contains("."))
            {
                input = input.Replace(".", ","); // sostituire la virgola con il punto
            }
            // provo a convertire 
            if (decimal.TryParse(input, out valore) && valore >= min && valore <= max)
            {
                return valore; 
                // restituisce ed esce dal ciclo quando trova il valore
            }
            else
            {
                Console.WriteLine($"Inserire un valore intero compreso tra {min} e {max}");
            }
        }
    }
    public static string LeggiStringa (string messaggio, bool obbligatorio = true)
    {
        string valore;
        while(true)
        {
            Console.Write($"{messaggio}"); // messaggio è la variabile di input
            string input = Console.ReadLine(); // acquisisco input come stringa
            // provo a convertire 
            if (!string.IsNullOrWhiteSpace(input) || !obbligatorio)
            {
                return input; 
            }
            Console.WriteLine($"Errore: il valore non può essere vuoto");          
        }
    }
    public static bool LeggiConferma (string messaggio)
    {
        while(true)
        {
            Console.Write($"{messaggio} (s/n): ");
            string input = Console.ReadLine().ToLower();
            if (input == "s" || input == "si")
            {
                return true;
            }
            else if (input == "n" || input == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Inserire un valore valido");
            }
        }
    }
}
#endregion
// La gestione dei file json è più sicura se il path è privato
// dunque ogni file json avrà la propria Class Repository per salvare e caricare
// la cosa più furba è mantenere i vari blocchi modulari (riutilizzabili)
// piuttosto che fare una classe che fa più cose