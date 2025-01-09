using System.Data.Common;
using Newtonsoft.Json;

public class ClientiRepository
{
    private readonly string dirCatalogo = "data/clienti"; //

    //metodo per salvare i dati su file 
    public void SalvaClienti(Cliente cliente)
    {
        string nuovoPercorso = ""; // creo una variabile per ospitare il nuovo percorso
        if (!Directory.Exists(dirCatalogo)) // se non esiste la cartella
        {
            Directory.CreateDirectory(dirCatalogo); // creala
        }
        string jsonData = JsonConvert.SerializeObject(cliente, Formatting.Indented); // serializza il prodotto
        string nomeCliente = $"{cliente.Id}.json"; // creo il nome del file 
        nuovoPercorso = Path.Combine(dirCatalogo, nomeCliente); // creo il percorso
        File.WriteAllText(nuovoPercorso, jsonData); // scrivo il prodotto deserializzato nel percorso
        //Console.WriteLine($"Dati salvati in '{nuovoPercorso}'\n"); // stampo il percorso 
    }

    public List<Cliente> CaricaClienti()
    {
        if (Directory.Exists(dirCatalogo))
        {
            string[] files = Directory.GetFiles(dirCatalogo);  // carico il contenuto della cartella in una lista di stringhe

            if (files.Length > 0) // controllo che ci siano file nella cartella, se ci sono file
            {
                List<Cliente> listaClientiLocale = new List<Cliente>(); // crea una lista locale
                Cliente letturaCliente; // crea un'istanza temporanea del prodotto
                foreach (string file in files) // per ogni file dentro la cartella
                {
                    string readJsonData = File.ReadAllText(file);  // leggi il file
                    letturaCliente = JsonConvert.DeserializeObject<Cliente>(readJsonData)!; // deserializzo dentro l'istanza temporanea
                    listaClientiLocale.Add(letturaCliente); // aggiungo l'istanza temporanea alla lista locale
                }
                return listaClientiLocale; // restituisco la lista locale
            }
            else
            {
                return new List<Cliente>(); // se la cartella esiste ma non ci sono file restituisci una lista vuota 
            }
        }
        else // se non esiste la cartella creala e restiuisci una lista vuota
        {
            Directory.CreateDirectory(dirCatalogo);
            return new List<Cliente>();
        }
    }

    public Cliente CaricaCliente(Cliente cliente)
    {
        List<Cliente> clientiLocale = CaricaClienti();

        foreach (var user in clientiLocale)
        {
            if (user.Username == cliente.Username)
            {
                return user;
            }
        }
        return null;
    }
}
