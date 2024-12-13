using System.Data.Common;
using Newtonsoft.Json;

public class CarrelloRepository
{
    private readonly string filePath = "Purchase.json"; // percorso in cui memorizzare i dati
    private readonly string dirCarrello = "carrello"; // catella

    //metodo per salvare i dati su file 
    public void SalvaProdotti(List<ProdottoAdvanced> prodotti)
    {

        string nuovoPercorso = "";
        // creo una variabile per ospitare il nuovo percorso

        if (!Directory.Exists(dirCarrello)) // se non esiste la cartella
        {
            Directory.CreateDirectory(dirCarrello);
            // la creo
        }
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        // serializzo cioè converto la lista in una stringa indentata 

        string pathCarrello = Path.Combine(dirCarrello, filePath);
        // creo il percorso al file 

        File.WriteAllText(pathCarrello, jsonData);
        // scrivo il file. se esiste lo sovrascrive, se non esiste lo crea
    }

    //metodo per caricare i dati da file 
    public List<ProdottoAdvanced> CaricaProdotti()
    {

        if (Directory.Exists(dirCarrello)) // se la cartella esiste
        {
            string percorsoCarrello = Path.Combine(dirCarrello, filePath);
            // creo il percorso del file

            if (File.Exists(percorsoCarrello))
            {
                string readJsonData = File.ReadAllText(percorsoCarrello);
                // leggo il file e lo salvo in una stringa

                return JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData);
                // restituisco la stringa deserializzata
            }
            else
            {
                return new List<ProdottoAdvanced>();
            }
        }
        else
        {
            Directory.CreateDirectory(dirCarrello);
            // se non esiste la cartella creala 

            return new List<ProdottoAdvanced>();
            // e restiuisci una lista vuota
        }
    }
}
