using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;


class Program // nome del file .cs
{
    static void Main(string[] args) // entry point 
    {
        Console.Clear();
        List <Prodotto> prodotti = new List <Prodotto> 
        {
            // 10.50m la m sta per decimal (tipo di dato) e indica che il valore è n numero con la virgola
            new Prodotto { Id = 1, NomeProdotto = "Prodotto A", PrezzoProdotto = 10.50m, GiacenzaProdotto = 100, DescrizioneProdotto="Questo è il fantastico Prodotto A!"},
            new Prodotto { Id = 2, NomeProdotto = "Prodotto B", PrezzoProdotto = 20.75m , GiacenzaProdotto = 50, DescrizioneProdotto="Affrettatevi! Il Prodotto B sta per terminare le scorte!"}
        };

        // serializzare i dati in un file JSON
        string filePath = "prodotti.json";
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);

        Console.WriteLine($"Dati serializzati e salvati in {filePath}:\n{jsonData}\n");
        string readJsonData = File.ReadAllText(filePath);
        List<Prodotto> prodottiDeserializzati = JsonConvert.DeserializeObject<List<Prodotto>>(readJsonData);

        Console.WriteLine("Dati deserializzati:");
        foreach (var prodotto in prodottiDeserializzati)
        {
            Console.WriteLine($"ID: {prodotto.Id} Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }

        Console.WriteLine();
        foreach (var prodotto in prodottiDeserializzati)
        {
            Console.WriteLine($"ID {prodotto.Id} - Descrizione {prodotto.DescrizioneProdotto}");
        }
    }
}

// il modificatore public significa che la classe è accessibile da qualsiasi codice all'interno dell'applicazione
// gli altri tipi di accesso sono private, proteted e internal
// la classe Prodotto continene quattro proprietà: Id, NomeProdotto, PrezzoProdotto, GiacenzaProdotto
// le proprietà sono sdefinite con il modificatore di accesso public, quindi sono accessibili da qualsiasi codice all'interno dell'appicazione
// le proprietà sono definite con il modificatore set, quindi possono essere scritte da qualsiasi codice
// le proprietà sono definite con il modificatore get, quindi possono essere lette da qualsiasi codice


// esempio di classe con proprietà pubbliche 
public class Prodotto
{
    public int Id { get; set; }
    public string NomeProdotto { get; set; }
    public decimal PrezzoProdotto { get; set; }
    public int GiacenzaProdotto { get; set; }
    public string DescrizioneProdotto { get; set; }

}


// esempio di classe con proprietà private
public class ProdottoAdvanced
{
    // definisco una variabile id privata, in modo che non possa essere modificata dall'esterno
    // solo la classe ProdottoAdvaned può accedere e modificare la bariabile id
    private int id; // campo privato
    
    // definisco una proprietà pubblica Id in modo che possa essere letta e scritta dall'esterno della classe
    // il vantaggio di utilizzare una proprietà è che posso controllare l'accesso alla variabile privata id e applicare le regole di validazione
    // ad esempio posso controllare che il valore passato come argomento sia maggiore di zero

    public int Id 
    { 
        get { return id; } // restituisco il valore della variabile privata id
        // set { id = value; } // imposto il valore della variabile privata id con il valore passato come argomento

        // OPPURE:
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

    private int giacenzaProdotto;
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
    
    public string DescrizioneProdotto { get; set; }

}