using System.Data.Common;
using Newtonsoft.Json;

public class ProdottoRepository
{
    private readonly string dirCatalogo = "data/catalogo"; //

    //metodo per salvare i dati su file 
    public void SalvaProdotti(List<Prodotto> prodotti)
    {

        string nuovoPercorso = ""; // creo una variabile per ospitare il nuovo percorso
        if (!Directory.Exists(dirCatalogo)) // se non esiste la cartella
        {
            Directory.CreateDirectory(dirCatalogo); // creala
        }

        foreach (var prodotto in prodotti) // per ogni prodotto nella lista argomento
        {
            string jsonData = JsonConvert.SerializeObject(prodotto, Formatting.Indented); // serializza il prodotto
            string nomeProdotto = $"{prodotto.Id}.json"; // creo il nome del file 
            nuovoPercorso = Path.Combine(dirCatalogo,nomeProdotto); // creo il percorso
            File.WriteAllText(nuovoPercorso, jsonData); // scrivo il prodotto deserializzato nel percorso
        }
        
        // Console.WriteLine($"Dati salvati nella cartella '/{dirCatalogo}'\n"); // stampo il percorso 
    }

    public List<Prodotto> CaricaProdotti()
    {
        // string nuovoPercorso = Path.Combine(dirCatalogo, prodo)
        if (Directory.Exists(dirCatalogo))
        {
            string[] files = Directory.GetFiles(dirCatalogo);  // carico il contenuto della cartella in una lista di stringhe
            
            if (files.Length > 0) // controllo che ci siano file nella cartella, se ci sono file
            {
                List<Prodotto> catalogoLocale = new List<Prodotto>(); // crea una lista locale
                Prodotto prodottoLocale; // crea un'istanza temporanea del prodotto
                foreach(string file in files) // per ogni file dentro la cartella
                {
                    string readJsonData = File.ReadAllText(file);  // leggi il file
                    prodottoLocale = JsonConvert.DeserializeObject<Prodotto>(readJsonData)!; // deserializzo dentro l'istanza temporanea
                    catalogoLocale.Add(prodottoLocale); // aggiungo l'istanza temporanea alla lista locale
                }
                return catalogoLocale; // restituisco la lista locale
            }
            else
            {
                return new List<Prodotto>(); // se la cartella esiste ma non ci sono file restituisci una lista vuota 
            }
        }
        else // se non esiste la cartella creala e restiuisci una lista vuota
        {
            Directory.CreateDirectory(dirCatalogo); 
            return new List<Prodotto>(); 
        }
    }
}
