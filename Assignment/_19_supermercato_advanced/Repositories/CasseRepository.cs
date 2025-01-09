using System.Data.Common;
using Newtonsoft.Json;

public class CasseRepository
{
    private readonly string dirCasse = "data/casse"; //

    //metodo per salvare i dati su file 
    public void SalvaCasse(List<Cassa> casse)
    {
        string nuovoPercorso = ""; // creo una variabile per ospitare il nuovo percorso
        if (!Directory.Exists(dirCasse)) // se non esiste la cartella
        {
            Directory.CreateDirectory(dirCasse); // creala
        }

        foreach (var cassa in casse)
        {
            string jsonData = JsonConvert.SerializeObject(cassa, Formatting.Indented); // serializza il prodotto
            string nuovaCassa = $"{cassa.Id}.json"; // creo il nome del file 
            nuovoPercorso = Path.Combine(dirCasse, nuovaCassa); // creo il percorso
            File.WriteAllText(nuovoPercorso, jsonData); // scrivo il prodotto deserializzato nel percorso
        }
    }

    public void SalvaCassaSingola(Cassa cassa)
    {
        string nuovoPercorso = ""; // creo una variabile per ospitare il nuovo percorso
        if (!Directory.Exists(dirCasse)) // se non esiste la cartella
        {
            Directory.CreateDirectory(dirCasse); // creala
        }
        string jsonData = JsonConvert.SerializeObject(cassa, Formatting.Indented); // serializza il prodotto
        string nuovaCassa = $"{cassa.Id}.json"; // creo il nome del file 
        nuovoPercorso = Path.Combine(dirCasse, nuovaCassa); // creo il percorso
        File.WriteAllText(nuovoPercorso, jsonData); // scrivo il prodotto deserializzato nel percorso
        
    }

    public List<Cassa> CaricaCasse()
    {
        if (Directory.Exists(dirCasse))
        {
            string[] files = Directory.GetFiles(dirCasse);  // carico il contenuto della cartella in una lista di stringhe

            if (files.Length > 0) // controllo che ci siano file nella cartella, se ci sono file
            {
                List<Cassa> listaCasseTemp= new List<Cassa>(); // crea una lista locale
                Cassa letturaCassa; // crea un'istanza temporanea del prodotto
                foreach (string file in files) // per ogni file dentro la cartella
                {
                    string readJsonData = File.ReadAllText(file);  // leggi il file
                    letturaCassa = JsonConvert.DeserializeObject<Cassa>(readJsonData)!; // deserializzo dentro l'istanza temporanea
                    listaCasseTemp.Add(letturaCassa); // aggiungo l'istanza temporanea alla lista locale
                }
                return listaCasseTemp; // restituisco la lista locale
            }
            else
            {
                return new List<Cassa>(); // se la cartella esiste ma non ci sono file restituisci una lista vuota 
            }
        }
        else // se non esiste la cartella creala e restiuisci una lista vuota
        {
            Directory.CreateDirectory(dirCasse);
            return new List<Cassa>();
        }
    }


    public Cassa CaricaCassaSingola(int id)
    {
        if (Directory.Exists(dirCasse))
        {
            string[] files = Directory.GetFiles(dirCasse);  // carico il contenuto della cartella in una lista di stringhe

            if (files.Length > 0) // controllo che ci siano file nella cartella, se ci sono file
            {
                List<Cassa> listaCassaLocale = new List<Cassa>(); // crea una lista locale
                Cassa letturaCassa; // crea un'istanza temporanea del prodotto
                foreach (string file in files) // per ogni file dentro la cartella
                {
                    string readJsonData = File.ReadAllText(file);  // leggi il file
                    letturaCassa = JsonConvert.DeserializeObject<Cassa>(readJsonData)!; // deserializzo dentro l'istanza temporanea
                    if (letturaCassa.Id == id)
                    {
                        return letturaCassa;
                    }
                }
                return null;
            }
            else
            {
                return null; // se la cartella esiste ma non ci sono file restituisci una lista vuota 
            }
        }
        else // se non esiste la cartella creala e restiuisci una lista vuota
        {
            Directory.CreateDirectory(dirCasse);
            return null;
        }
    }


    // public Purchase CaricSingolaPurchase(Cliente cliente)
    // {
    //     List<Cliente> clientiLocale = CaricaClienti();

    //     foreach (var user in clientiLocale)
    //     {
    //         if (user.Username == cliente.Username)
    //         {
    //             return user;
    //         }
    //     }
    //     return null;
    // }
}
