using System.Data.Common;
using Newtonsoft.Json;

public class PurchaisRepository
{
    private readonly string dirPurchases = "data/purchases"; //

    //metodo per salvare i dati su file 
    public void SalvaPurchase(List<Purchase> purchase)
    {
        string nuovoPercorso = ""; // creo una variabile per ospitare il nuovo percorso
        if (!Directory.Exists(dirPurchases)) // se non esiste la cartella
        {
            Directory.CreateDirectory(dirPurchases); // creala
        }

        foreach (var purchaseItem in purchase)
        {
            string jsonData = JsonConvert.SerializeObject(purchaseItem, Formatting.Indented); // serializza il prodotto
            string nuovoPurchase = $"{purchaseItem.Id}.json"; // creo il nome del file 
            nuovoPercorso = Path.Combine(dirPurchases, nuovoPurchase); // creo il percorso
            File.WriteAllText(nuovoPercorso, jsonData); // scrivo il prodotto deserializzato nel percorso
        }
    }

    public List<Purchase> CaricaPurchases()
    {
        if (Directory.Exists(dirPurchases))
        {
            string[] files = Directory.GetFiles(dirPurchases);  // carico il contenuto della cartella in una lista di stringhe

            if (files.Length > 0) // controllo che ci siano file nella cartella, se ci sono file
            {
                List<Purchase> listaPurchasesLocale = new List<Purchase>(); // crea una lista locale
                Purchase letturaPurchase; // crea un'istanza temporanea del prodotto
                foreach (string file in files) // per ogni file dentro la cartella
                {
                    string readJsonData = File.ReadAllText(file);  // leggi il file
                    letturaPurchase = JsonConvert.DeserializeObject<Purchase>(readJsonData)!; // deserializzo dentro l'istanza temporanea
                    listaPurchasesLocale.Add(letturaPurchase); // aggiungo l'istanza temporanea alla lista locale
                }
                return listaPurchasesLocale; // restituisco la lista locale
            }
            else
            {
                return new List<Purchase>(); // se la cartella esiste ma non ci sono file restituisci una lista vuota 
            }
        }
        else // se non esiste la cartella creala e restiuisci una lista vuota
        {
            Directory.CreateDirectory(dirPurchases);
            return new List<Purchase>();
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
