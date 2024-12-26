using System.Data.Common;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        List<ProdottoAdvanced> prodottiAvanzati = new List<ProdottoAdvanced>
        {
            new ProdottoAdvanced { Id = 1, NomeProdotto="esempio", PrezzoProdotto = 12.50m, GiacenzaProdotto=100},
            new ProdottoAdvanced { Id = 2, NomeProdotto="esempio2", PrezzoProdotto = 19.99m, GiacenzaProdotto=150}
        };
        string filePath = "catalogoAvanzato.json";
        string jsonData = JsonConvert.SerializeObject(prodottiAvanzati, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine($"Ho scritto in {filePath} questi prodotti:\n{jsonData}");
        List<ProdottoAdvanced> datiDeserializzati = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(jsonData);
        foreach (var prodotto in datiDeserializzati)
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}");
        }
        foreach (var prodotto in datiDeserializzati)
        {
            if (prodotto.Id == 1)
            {
                Console.WriteLine($"Inserisci nuova giacenza:");
                try
                {
                    prodotto.GiacenzaProdotto = int.Parse(Console.ReadLine()); 
                    // TEST giacenza = 0 
                    // se inserisco "0" esegue il blocco di codice del catch
                    // che in questo caso stampa il messaggio dell'errore impostato nel throw
                    // lo stesso esempio può essere fatto con le altre variabili
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"{e.Message}");
                }                   
            }
        }
        foreach (var prodotto in datiDeserializzati)
        {
            Console.WriteLine($"giacenze: {prodotto.GiacenzaProdotto}");
        }

        // Test completo
        ProdottoAdvanced test = new ProdottoAdvanced();

        try
        {
            test = new ProdottoAdvanced();
            test.NomeProdotto = "";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

        try
        {
            test = new ProdottoAdvanced();
            test.Id = 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

        try
        {
            test = new ProdottoAdvanced();
            test.PrezzoProdotto = -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

        Console.WriteLine($"{test.NomeProdotto}");
    }
}

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
}