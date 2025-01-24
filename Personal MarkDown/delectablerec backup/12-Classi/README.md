
# CLASSI - 1 PARTE

La classe è un costrutto fondamentale della programmazione orientata agli oggetti (OOP) che permette di definire un tipo di dato personalizzato con attributi e metodi. Le classi sono utilizzate per modellare entità del mondo reale o astratte e rappresentano un modo efficace per organizzare e strutturare il codice.

## Struttura di una Classe

Una classe in C# è definita utilizzando la parola chiave `class` seguita dal nome della classe e da un blocco di codice racchiuso tra parentesi graffe `{}`. All'interno della classe, è possibile definire attributi (campi) e metodi che descrivono il comportamento dell'oggetto.

Esempio di serializzazione e deserializzazione di file JSON in C# usando una classe modello Prodotto


1. Classe Modello Prodotto
```csharp
public class Prodotto
{
    public int Id { get; set; }
    public string NomeProdotto { get; set; }
    public decimal PrezzoProdotto { get; set; }
    public int GiacenzaProdotto { get; set; }
}
```
2. Serializzazione e Deserializzazione
```csharp
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        // Creare una lista di prodotti
        List<Prodotto> prodotti = new List<Prodotto>
        {
            new Prodotto { Id = 1, NomeProdotto = "Prodotto A", PrezzoProdotto = 10.50m, GiacenzaProdotto = 100 },
            new Prodotto { Id = 2, NomeProdotto = "Prodotto B", PrezzoProdotto = 20.75m, GiacenzaProdotto = 50 }
        };

        // Serializzare i dati in un file JSON
        string filePath = "prodotti.json";
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);

        Console.WriteLine($"Dati serializzati e salvati in {filePath}:\n{jsonData}\n");

        // Deserializzare i dati dal file JSON
        string readJsonData = File.ReadAllText(filePath);
        List<Prodotto> prodottiDeserializzati = JsonConvert.DeserializeObject<List<Prodotto>>(readJsonData);

        Console.WriteLine("Dati deserializzati:");
        foreach (var prodotto in prodottiDeserializzati)
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }
    }
}
```
3 Json Prodotti
```json
[
  {
    "Id": 1,
    "NomeProdotto": "Prodotto A",
    "PrezzoProdotto": 10.50,
    "GiacenzaProdotto": 100
  },
  {
    "Id": 2,
    "NomeProdotto": "Prodotto B",
    "PrezzoProdotto": 20.75,
    "GiacenzaProdotto": 50
  }
]
```
## Vantaggi di Usare una Classe Modello

Organizzazione del Codice:

- La classe rappresenta un'entità con tutti i suoi attributi, rendendo il codice più leggibile e strutturato.
Permette di incapsulare il comportamento e le operazioni legate all'entità.

Tipizzazione Forte:

- I tipi di dati definiti nella classe (int, string, decimal, ecc.) riducono gli errori durante lo sviluppo grazie alla verifica a tempo di compilazione.
Ad esempio, se tenti di assegnare un valore di tipo errato, il compilatore segnalerà l'errore.

Manutenzione Facile:

- Se è necessario apportare modifiche alla struttura dell'entità, è sufficiente modificarne la classe, senza dover cercare e modificare manualmente ogni occorrenza nei dati serializzati. Inoltre le modifiche vengono distribuite automaticamente a tutte le parti del codice che utilizzano la classe.

- È più facile aggiornare e comprendere l'impatto delle modifiche.
Compatibilità con Librerie e Framework:

- Librerie come Newtonsoft.Json o System.Text.Json possono lavorare direttamente con le classi per la serializzazione/deserializzazione, eliminando la necessità di scrivere codice manuale.

Validazione e Logica Incorporata:

- Puoi aggiungere logica personalizzata o validazione direttamente nella classe (getters/setters, metodi).
Riusabilità:

- Il modello può essere riutilizzato in altre parti del progetto o in diversi progetti.

Svantaggi di Non Usare una Classe

Codice Disordinato:

- I dati sarebbero rappresentati come dizionari, array, o liste non tipizzate, rendendo il codice meno leggibile e più difficile da mantenere.
Maggiore Possibilità di Errori:

- L'assenza di una tipizzazione forte può portare a errori che si manifestano solo a runtime, anziché essere rilevati a tempo di compilazione.
Meno Flessibilità:

- Operazioni personalizzate, validazione dei dati o logica di business devono essere gestite separatamente e non possono essere incapsulate nell'entità.
Usare una classe è una buona pratica per rendere il codice più pulito, robusto e facile da mantenere.

# CLASSI - 2 PARTE

## 1. Aggiungere Validazioni nel Modello
Puoi aggiungere validazioni direttamente nella classe Prodotto utilizzando proprietà personalizzate.

```csharp
// esempio di classe con proprietà private rese pubbliche tramite metodi get e set dopo aver applicato delle regole di validazione
public class ProdottoAdvanced
{
    // definisco una variabile privata id
    // la definisco privata in modo che non possa essere modificata direttamente dall'esterno della classe
    // cosi solo la classe ProdottoAdvanced può accedere e modificare la variabile id
    private int id; // campo privato
    
    // definisco una proprietà pubblica Id in modo che possa essere letta e scritta dall'esterno della classe
    // il vantaggio di utilizzare una proprietà è che posso controllare l'accesso alla variabile privata id e applicare delle regole di validazione
    // ad esempio posso controllare che il valore passato come argomento sia maggiore di zero
    public int Id
    {
        get { return id; } // restituisce il valore della variabile privata id richiamata dall'esterno della classe ProdottoAdvanced
        // set { id = value; } // imposta il valore della variabile privata id con il valore passato come argomento
        // implemento la logica di validazione per il valore passato come argomento
        // se il valore passato come argomento è minore o uguale a zero, sollevo un'eccezione
        // l'eccezione interrompe l'esecuzione del programma e mostra un messaggio di errore
        // l'eccezione può essere catturata e gestita da un blocco try-catch
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il valore dell'ID deve essere maggiore di zero.");
            }
            id = value; // imposta il valore della variabile privata id con il valore passato come argomento
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
```
Program.cs
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Creare una lista di prodotti
        List<ProdottoAdvanced> prodotti = new List<ProdottoAdvanced>
        {
            // 10.50m la m sta per decimal (tipo di dato) e indica che il valore è un decimale (numero con la virgola)
            new ProdottoAdvanced { Id = 1, NomeProdotto = "Prodotto A", PrezzoProdotto = 10.50m, GiacenzaProdotto = 100 },
            new ProdottoAdvanced { Id = 2, NomeProdotto = "Prodotto B", PrezzoProdotto = 20.75m, GiacenzaProdotto = 50 }
        };

        // Serializzare i dati in un file JSON
        string filePath = "prodotti.json";
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);

        Console.WriteLine($"Dati serializzati e salvati in {filePath}:\n{jsonData}\n");

        // Deserializzare i dati dal file JSON
        string readJsonData = File.ReadAllText(filePath);
        List<ProdottoAdvanced> prodottiDeserializzati = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData);

        Console.WriteLine("Dati deserializzati:");
        foreach (var prodotto in prodottiDeserializzati)
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }

        // Testare l'eccezione per l'ID
        try
        {
            ProdottoAdvanced prodotto = new ProdottoAdvanced();
            prodotto.Id = 0;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }

        // Testare l'eccezione per il nome del prodotto
        try
        {
            ProdottoAdvanced prodotto = new ProdottoAdvanced();
            prodotto.NomeProdotto = "";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }

        // Testare l'eccezione per il prezzo del prodotto
        try
        {
            ProdottoAdvanced prodotto = new ProdottoAdvanced();
            prodotto.PrezzoProdotto = 0;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }
    }
}
```

# CLASSI - 3 PARTE

Gestire Operazioni CRUD

Implementa operazioni per creare, leggere, aggiornare e eliminare i prodotti.

```csharp
public class ProdottoAdvancedManager
{
    private List<ProdottoAdvanced> prodotti;

    public ProdottoAdvancedManager()
    {
        prodotti = new List<ProdottoAdvanced>();
    }

    public void AggiungiProdotto(ProdottoAdvanced prodotto)
    {
        prodotti.Add(prodotto);
    }

    public List<ProdottoAdvanced> OttieniProdotti()
    {
        return prodotti;
    }

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

    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
        }
    }
}
```
Program.cs
```csharp
using Newtonsoft.Json;

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
```
# CLASSI - 4 PARTE

Persistenza Avanzata dei Dati

Estendi la logica di persistenza dei dati per salvare automaticamente ogni modifica:

```csharp
public class ProdottoRepository
{
    private readonly string filePath = "prodotti.json";

    public void SalvaProdotti(List<ProdottoAdvanced> prodotti)
    {
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine($"Dati salvati in {filePath}:\n{jsonData}\n");
    }

    public List<ProdottoAdvanced> CaricaProdotti()
    {
        if (File.Exists(filePath))
        {
            string readJsonData = File.ReadAllText(filePath);
            List<ProdottoAdvanced> prodotti = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData);
            Console.WriteLine("Dati caricati da file:");
            foreach (var prodotto in prodotti)
            {
                Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
            }
            return prodotti;
        }
        else
        {
            Console.WriteLine("Nessun dato trovato. Inizializzare una nuova lista di prodotti.");
            return new List<ProdottoAdvanced>();
        }
    }
}
```
Program.cs
```csharp
using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        // Creare un oggetto di tipo ProdottoRepository per gestire il salvataggio e il caricamento dei dati
        ProdottoRepository repository = new ProdottoRepository();
        
        // Caricare i dati da file con il metodo CaricaProdotti della classe ProdottoRepository (repository)
        List<ProdottoAdvanced> prodotti = repository.CaricaProdotti();

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

        // Salvare i prodotti su file con il metodo SalvaProdotti della classe ProdottoRepository (repository)
        repository.SalvaProdotti(manager.OttieniProdotti());
    }
}
```
# CLASSI - 5 PARTE

Interfaccia Utente

Aggiungi un menu interattivo per eseguire operazioni:

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Creare un oggetto di tipo ProdottoRepository per gestire il salvataggio e il caricamento dei dati
        ProdottoRepository repository = new ProdottoRepository();

        // Caricare i dati da file con il metodo CaricaProdotti della classe ProdottoRepository (repository)
        List<ProdottoAdvanced> prodotti = repository.CaricaProdotti();

        // Creare un oggetto di tipo ProdottoAdvancedManager per gestire i prodotti
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);

        // Menu interattivo per eseguire operazioni CRUD sui prodotti
        
        // variabile per controllare se il programma deve continuare o uscire
        bool continua = true;

        // il ciclo while continua finché la variabile continua è true
        while (continua)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Visualizza Prodotti");
            Console.WriteLine("2. Aggiungi Prodotto");
            Console.WriteLine("3. Trova Prodotto per ID");
            Console.WriteLine("4. Aggiorna Prodotto");
            Console.WriteLine("5. Elimina Prodotto");
            Console.WriteLine("6. Esci");

            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            // switch-case per gestire le scelte dell'utente
            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nProdotti:");

                    // Visualizzare i prodotti con il metodo OttieniProdotti della classe ProdottoAdvancedManager (manager)
                    foreach (var prodotto in manager.OttieniProdotti())
                    {
                        Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
                    }
                    break;
                case "2":
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Prezzo: ");
                    decimal prezzo = decimal.Parse(Console.ReadLine());
                    Console.Write("Giacenza: ");
                    int giacenza = int.Parse(Console.ReadLine());
                    manager.AggiungiProdotto(new ProdottoAdvanced { Id = id, NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza });
                    break;
                case "3":
                    Console.Write("ID: ");
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
                    Console.Write("ID: ");
                    int idProdottoDaAggiornare = int.Parse(Console.ReadLine());
                    Console.Write("Nome: ");
                    string nomeNuovo = Console.ReadLine();
                    Console.Write("Prezzo: ");
                    decimal prezzoNuovo = decimal.Parse(Console.ReadLine());
                    Console.Write("Giacenza: ");
                    int giacenzaNuova = int.Parse(Console.ReadLine());
                    manager.AggiornaProdotto(idProdottoDaAggiornare, new ProdottoAdvanced { Id = idProdottoDaAggiornare, NomeProdotto = nomeNuovo, PrezzoProdotto = prezzoNuovo, GiacenzaProdotto = giacenzaNuova });
                    break;
                case "5":
                    Console.Write("ID: ");
                    int idProdottoDaEliminare = int.Parse(Console.ReadLine());
                    manager.EliminaProdotto(idProdottoDaEliminare);
                    break;
                case "6":
                    repository.SalvaProdotti(manager.OttieniProdotti());
                    continua = false; // imposto la variabile continua a false per uscire dal ciclo while
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprovare.");
                    break;
            }
        }
    }
}
```

# CLASSI - 6 PARTE

Implementazione che salvi in una cartella Prodotti un file json per ciascun prodotto

Nella classe ProdottoRepository, modifica i metodi SalvaProdotti e CaricaProdotti per salvare e caricare i prodotti in file JSON separati per ciascun prodotto.

```csharp
public class ProdottoRepository
{
    private readonly string folderPath = "Prodotti"; // cartella per i file JSON

    // Metodo per salvare i prodotti in file JSON
    public void SalvaProdotti(List<ProdottoAdvanced> prodotti)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath); // crea la cartella se non esiste
        }

        foreach (var prodotto in prodotti)
        {
            string filePath = Path.Combine(folderPath, $"{prodotto.Id}.json"); // percorso del file JSON
            string jsonData = JsonConvert.SerializeObject(prodotto, Formatting.Indented); // serializza il prodotto in JSON
            File.WriteAllText(filePath, jsonData); // scrive il JSON nel file
            Console.WriteLine($"Prodotto salvato in {filePath}:\n{jsonData}\n"); // stampa il percorso e i dati del file
        }
    }

    public List<ProdottoAdvanced> CaricaProdotti()
    {
        List<ProdottoAdvanced> prodotti = new List<ProdottoAdvanced>(); // lista di prodotti
        if (Directory.Exists(folderPath))
        {
            foreach (var file in Directory.GetFiles(folderPath, "*.json"))
            {
                string readJsonData = File.ReadAllText(file); // legge il contenuto del file JSON
                ProdottoAdvanced prodotto = JsonConvert.DeserializeObject<ProdottoAdvanced>(readJsonData); // deserializza il JSON in un oggetto ProdottoAdvanced
                prodotti.Add(prodotto); // aggiunge il prodotto alla lista
            }
        }
        return prodotti; // restituisce la lista di prodotti
    }
}
```
Nella classe ProdottoAdvancedManager, modifica il costruttore per caricare i prodotti dal repository e aggiungi al metodo EliminaProdotto la cancellazione del file JSON corrispondente al prodotto.

```csharp
public class ProdottoAdvancedManager
{
    // Lista di prodotti di tipo ProdottoAdvanced per memorizzare i prodotti
    private List<ProdottoAdvanced> prodotti;
    
    // Oggetto di tipo ProdottoRepository per salvare i dati su file
    private ProdottoRepository repository;

    // Costruttore per inizializzare la lista prodotti con i prodotti passati come argomento
    // la differenza tra un costruttore ed un metodo è che il costruttore viene chiamato automaticamente quando si crea un'istanza della classe
    // il compilatore capisce che e un costruttore perche ha lo stesso nome della classe
    // uso la maiuscola per il nome del parametro per distinguerlo dal campo
    // il parametro è una lista di prodotti di tipo ProdottoAdvanced (Prodotti)
    // il campo prodotti è un riferimento alla lista di prodotti passata come argomento (prodotti)
    public ProdottoAdvancedManager(List<ProdottoAdvanced> Prodotti)
    {
        // Inizializzare la lista prodotti con i prodotti passati come argomento
        prodotti = Prodotti;
        // inizializzare l'oggetto repository per gestire il salvataggio e il caricamento dei dati
        repository = new ProdottoRepository();
    }

    public void AggiungiProdotto(ProdottoAdvanced prodotto)
    {
        prodotti.Add(prodotto);
    }

    public List<ProdottoAdvanced> OttieniProdotti()
    {
        return prodotti;
    }

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

    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
            // elimina il file JSON corrispondente al prodotto
            string filePath = Path.Combine("Prodotti", $"{id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Prodotto eliminato: {filePath}");
        }
    }

    public void SalvaProdotti()
    {
        repository.SalvaProdotti(prodotti);
    }
}
```
Nel programma principale, aggiungi

```csharp
// Creare un oggetto di tipo ProdottoAdvancedManager per gestire i prodotti
ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);
```
Esempio di files json

1.json
```json
{
  "Id": 1,
  "NomeProdotto": "Prodotto A",
  "PrezzoProdotto": 10.50,
  "GiacenzaProdotto": 100
}
```
2.json
```json
{
  "Id": 2,
  "NomeProdotto": "Prodotto B",
  "PrezzoProdotto": 20.75,
  "GiacenzaProdotto": 50
}
```

# CLASSI - 7 PARTE

Implementazione di id automatici

## Dettagli delle modifiche:

Inizializzazione di prossimoId:

In ProdottoAdvancedManager, aggiungi una variabile prossimoId per tenere traccia del prossimo ID da assegnare:

```csharp
// variabile prossimo Id
    private int prossimoId;
```

Modifica il costruttore per inizializzare prossimoId con il valore piu alto di ID + 1:

```csharp
public ProdottoAdvancedManager(List<ProdottoAdvanced> Prodotti)
    {
        prodotti = Prodotti;
        repository = new ProdottoRepository();
        prossimoId = 1; // ID iniziale di default
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id >= prossimoId)
            {
                prossimoId = prodotto.Id + 1;
            }
        }
    }
```

Modifica il metodo AggiungiProdotto per assegnare automaticamente un nuovo ID:

```csharp
public void AggiungiProdotto(ProdottoAdvanced prodotto)
    {
        // Assegna automaticamente un ID univoco
        prodotto.Id = prossimoId;
        prossimoId++;
        prodotti.Add(prodotto);
        Console.WriteLine($"Prodotto aggiunto con ID: {prodotto.Id}");
    }
```

Modifica nel menu interattivo:

Rimuovi il prompt per inserire l'ID durante l'aggiunta di un prodotto, poiché ora viene assegnato automaticamente:

```csharp
case "2":
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Prezzo: ");
    decimal prezzo = decimal.Parse(Console.ReadLine());
    Console.Write("Giacenza: ");
    int giacenza = int.Parse(Console.ReadLine());
    manager.AggiungiProdotto(new ProdottoAdvanced { NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza });
    break;
```
Rimuovi il prompt per inserire l'ID durante l'aggiornamento di un prodotto:

```csharp
case "4":
    Console.Write("ID: ");
    int idProdottoDaAggiornare = int.Parse(Console.ReadLine());
    Console.Write("Nome: ");
    string nomeNuovo = Console.ReadLine();
    Console.Write("Prezzo: ");
    decimal prezzoNuovo = decimal.Parse(Console.ReadLine());
    Console.Write("Giacenza: ");
    int giacenzaNuova = int.Parse(Console.ReadLine());
    manager.AggiornaProdotto(idProdottoDaAggiornare, new ProdottoAdvanced { NomeProdotto = nomeNuovo, PrezzoProdotto = prezzoNuovo, GiacenzaProdotto = giacenzaNuova });
    break;
```

# CLASSI - 8 PARTE

Implementazione di una classe che gestisca gli input dell utente

```csharp
// classe di gestione degli input (InputManager) che può essere integrata per semplificare e standardizzare l'acquisizione e la validazione degli input
// dell'utente. Questa classe aiuta a gestire i casi di errore e fornisce metodi per acquisire input di diversi tipi.
// uso int-MinValue ed int.MaxValue per dare dei valori di default
// Quando chiami il metodo, puoi specificare solo i valori che ti interessano e ignorare gli altri
// Quando chiami il metodo con un solo valore (ad esempio 0 per min), non devi preoccuparti di specificare anche max se non è necessario
// come succede con il random che non ha un valore min prende 0 di default
// es int risultato = InputManager.LeggiIntero("Inserisci un valore: ", 0);
public static class InputManager
{
     // il metodo LeggiIntero accetta un messaggio da visualizzare all'utente e un intervallo di valori interi consentiti
     // MinValue ed MaxValue sono i metodi di int che rappresentano il valore minimo e massimo di un intero
     public static int LeggiIntero(string messaggio, int min = int.MinValue, int max = int.MaxValue)
    {
         int valore; // variabile per memorizzare il valore intero acquisito
         // while che continua finche l'utente non fornisce un input valido
         while (true)
        {
            Console.Write($"{messaggio} "); // messaggio e la variabile di input che dovro passare al metodo
            string input = Console.ReadLine(); // acquisire l'input dell'utente come stringa
            // try parse per convertire la stringa in un intero e controllare se l'input è valido
            if (int.TryParse(input, out valore) && valore >= min && valore <= max) // devo verificarte se il valore e tra min e max e se e un intero
            {
                return valore; // restituire il valore intero se è valido
            }
            else
            {
                Console.WriteLine($"Inserire un valore intero compreso tra {min} e {max}."); // messaggio di errore
            }
        }
    }

    public static decimal LeggiDecimale(string messaggio, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
    {
        decimal valore; // variabile per memorizzare il valore decimale acquisito
        while (true)
        {
            Console.Write($"{messaggio} ");
            string input = Console.ReadLine();

            // sostituisco il punto con la virgola se l'input contiene il punto
            if (input.Contains(".")) // se l'input contiene la virgola e non contiene il punto
            {
                input = input.Replace(".", ","); // sostituire la virgola con il punto
            }

            // try parse per convertire la stringa in un decimale e controllare se l'input è valido
            if (decimal.TryParse(input, out valore) && valore >= min && valore <= max)
            {
                return valore;
            }
            Console.WriteLine($"Errore: Inserire un numero decimale compreso tra {min} e {max}.");
        }
    }

    public static string LeggiStringa(string messaggio, bool obbligatorio = true)
    {
        while (true)
        {
            Console.Write($"{messaggio} "); // messaggio e la variabile di input che dovro passare al metodo
            string input = Console.ReadLine(); // acquisire l'input dell'utente come stringa
            if (!string.IsNullOrWhiteSpace(input) || !obbligatorio) // se l'input non e vuoto o non e obbligatorio
            {
                return input; // restituire il valore della stringa
            }
            Console.WriteLine("Errore: Il valore non può essere vuoto."); // messaggio di errore
        }
    }

    public static bool LeggiConferma(string messaggio)
    {
        while (true)
        {
            Console.Write($"{messaggio} (s/n): ");
            string input = Console.ReadLine().ToLower();
            if (input == "s" || input == "si")
            {
                return true;
            }
            if (input == "n" || input == "no")
            {
                return false;
            }
            Console.WriteLine("Errore: Rispondere con 's' o 'n'.");
        }
    }
}
```

Nel metodo main del programma principale, sostituisci le chiamate a Console.ReadLine con i metodi di InputManager:

```csharp
case "2":
    string nome = InputManager.LeggiStringa("Nome:");
    decimal prezzo = InputManager.LeggiDecimale("Prezzo:", 0);
    int giacenza = InputManager.LeggiIntero("Giacenza:", 0);
    manager.AggiungiProdotto(new ProdottoAdvanced { NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza });
    break;
case "4":
    int idProdottoDaAggiornare = InputManager.LeggiIntero("ID:", 1);
    string nomeNuovo = InputManager.LeggiStringa("Nome:");
    decimal prezzoNuovo = InputManager.LeggiDecimale("Prezzo:", 0);
    int giacenzaNuova = InputManager.LeggiIntero("Giacenza:", 0);
    manager.AggiornaProdotto(idProdottoDaAggiornare, new ProdottoAdvanced { NomeProdotto = nomeNuovo, PrezzoProdotto = prezzoNuovo, GiacenzaProdotto = giacenzaNuova });
    break;
```

# CLASSI - 9 PARTE

Implementazione di un metodo che gestisca la stampa dei prodotti in colonna

Nella classe ProdottoAdvancedManager, aggiungi un metodo StampaProdottiIncolonnati per visualizzare i prodotti in una tabella con colonne allineate:

```csharp
// Ogni campo utilizza il formato {Campo,-Larghezza} dove:
// Campo è il valore da stampare
// -Larghezza specifica la larghezza del campo; il segno - allinea il testo a sinistra.
//{"Nome",-20} significa che il nome del prodotto avrà una larghezza fissa di 20 caratteri, allineato a sinistra
// Formato dei numeri:
// Per i prezzi, viene usato il formato 0.00 per mostrare sempre due cifre decimali
// Linea separatrice:
// La riga Console.WriteLine(new string('-', 50)); stampa una linea divisoria lunga 50 caratteri per migliorare la leggibilità
public void StampaProdottiIncolonnati()
{
    // Intestazioni con larghezza fissa
    Console.WriteLine(
        $"{"ID",-5} {"Nome",-20} {"Prezzo",-10} {"Giacenza",-10}"
    );
    Console.WriteLine(new string('-', 50)); // Linea separatrice

    // Stampa ogni prodotto con larghezza fissa
    foreach (var prodotto in prodotti)
    {
        Console.WriteLine(
            $"{prodotto.Id,-5} {prodotto.NomeProdotto,-20} {prodotto.PrezzoProdotto,-10:0.00} {prodotto.GiacenzaProdotto,-10}"
        );
    }
}
```

Nel programma principale chiama il metodo StampaProdottiIncolonnati

```csharp
case "1":
    Console.WriteLine("\nProdotti:");
    manager.StampaProdottiIncolonnati();
    break;
```