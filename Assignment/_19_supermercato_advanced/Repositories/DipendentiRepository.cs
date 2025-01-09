using System.Data.Common;
using Newtonsoft.Json;

public class DipendentiRepository
{
    private readonly string dirCatalogo = "data/dipendenti";

    public void SalvaDipendenti(List<Dipendente> dipendenti)
    {
        string nuovoPercorso = ""; // creo una variabile per ospitare il nuovo percorso
        if (!Directory.Exists(dirCatalogo)) // se non esiste la cartella
        {
            Directory.CreateDirectory(dirCatalogo); // creala
        }

        foreach (var dipendente in dipendenti) // per ogni dipendente nella lista dell argomento
        {
            string jsonData = JsonConvert.SerializeObject(dipendente, Formatting.Indented); // serializza il prodotto
            string nomeProdotto = $"{dipendente.Id}.json"; // creo il nome del file 
            nuovoPercorso = Path.Combine(dirCatalogo, nomeProdotto); // creo il percorso
            File.WriteAllText(nuovoPercorso, jsonData); // scrivo il prodotto deserializzato nel percorso
        }
        //Console.WriteLine($"Dati salvati in '{nuovoPercorso}'\n"); // stampo il percorso 
    }

    public List<Dipendente> CaricaDipendenti()
    {
        if (Directory.Exists(dirCatalogo))
        {
            string[] files = Directory.GetFiles(dirCatalogo);  // carico il contenuto della cartella in una lista di stringhe

            if (files.Length > 0) // controllo che ci siano file nella cartella, se ci sono file
            {
                List<Dipendente> acquisizioneDipendenti = new List<Dipendente>(); // crea una lista locale
                Dipendente letturaDipendente; // crea un'istanza temporanea del prodotto
                foreach (string file in files) // per ogni file dentro la cartella
                {
                    string readJsonData = File.ReadAllText(file);  // leggi il file
                    letturaDipendente = JsonConvert.DeserializeObject<Dipendente>(readJsonData)!; // deserializzo dentro l'istanza temporanea
                    acquisizioneDipendenti.Add(letturaDipendente); // aggiungo l'istanza temporanea alla lista locale
                }
                return acquisizioneDipendenti; // restituisco la lista locale
            }
            else
            {
                return new List<Dipendente>(); // se la cartella esiste ma non ci sono file restituisci una lista vuota 
            }
        }
        else // se non esiste la cartella creala e restiuisci una lista vuota
        {
            Directory.CreateDirectory(dirCatalogo);
            return new List<Dipendente>();
        }
    }
}
