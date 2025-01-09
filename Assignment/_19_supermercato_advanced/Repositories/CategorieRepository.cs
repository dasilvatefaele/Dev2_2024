using System.Data.Common;
using Newtonsoft.Json;

public class CategorieRepository
{
    private readonly string filePath = "categorie.json"; // percorso in cui memorizzare i dati
    private readonly string dirCategorie = "data/categorie"; // catella

    //metodo per salvare i dati su file 
    public void SalvaCategorie(List<Categoria> categorie)
    {

        string nuovoPercorso = "";
        // creo una variabile per ospitare il nuovo percorso

        if (!Directory.Exists(dirCategorie)) // se non esiste la cartella
        {
            Directory.CreateDirectory(dirCategorie);
            // la creo
        }
        string jsonData = JsonConvert.SerializeObject(categorie, Formatting.Indented);
        // serializzo cioè converto la lista in una stringa indentata 

        string pathCarrello = Path.Combine(dirCategorie, filePath);
        // creo il percorso al file 

        File.WriteAllText(pathCarrello, jsonData);
        // scrivo il file. se esiste lo sovrascrive, se non esiste lo crea
    }

    //metodo per caricare i dati da file 
    public List<Categoria> CaricaCategorie()
    {

        if (Directory.Exists(dirCategorie)) // se la cartella esiste
        {
            string percorsoCategorie = Path.Combine(dirCategorie, filePath);
            // creo il percorso del file

            if (File.Exists(percorsoCategorie))
            {
                string readJsonData = File.ReadAllText(percorsoCategorie);
                // leggo il file e lo salvo in una stringa
                List<Categoria> lettura = JsonConvert.DeserializeObject<List<Categoria>>(readJsonData);


                return lettura;
                // restituisco la stringa deserializzata
            }
            else
            {
                return new List<Categoria>();
            }
        }
        else
        {
            Directory.CreateDirectory(dirCategorie);
            // se non esiste la cartella creala 

            return new List<Categoria>();
            // e restiuisci una lista vuota
        }
    }
}
