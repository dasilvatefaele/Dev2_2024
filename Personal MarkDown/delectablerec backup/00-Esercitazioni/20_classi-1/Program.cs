using Newtonsoft.Json;

// comando per installare il pacchetto Newtonsoft.Json
// dotnet add package Newtonsoft.Json
class Program
{
    static void Main(string[] args)
    {
        // Creare una lista di prodotti
        List<Prodotto> prodotti = new List<Prodotto>
        {
            // 10.50m la m sta per decimal (tipo di dato) e indica che il valore è un decimale (numero con la virgola)
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

// il modificatore public significa che la classe è accessibile da qualsiasi codice all'interno dell applicazione
// gli altri tipi di accesso sono private, protected e internal
// la classe Prodotto contiene quattro proprietà: Id, NomeProdotto, PrezzoProdotto e GiacenzaProdotto
// le proprietà sono definite con il modificatore di accesso public, quindi sono accessibili da qualsiasi codice all'interno dell'applicazione
// le proprietà sono definite con il modificatore set, quindi possono essere scritte da qualsiasi codice all'interno dell'applicazione
// le proprietà sono definite con il modificatore get, quindi possono essere lette da qualsiasi codice all'interno dell'applicazione

// esempio di classe con proprietà pubbliche
public class Prodotto
{
    public int Id { get; set; }
    public string NomeProdotto { get; set; }
    public decimal PrezzoProdotto { get; set; }
    public int GiacenzaProdotto { get; set; }
}