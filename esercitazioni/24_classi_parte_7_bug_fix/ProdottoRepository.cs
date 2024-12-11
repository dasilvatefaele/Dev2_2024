using Newtonsoft.Json;

public class ProdottoRepository
{
    
    private readonly string filePath = "prodotti.json"; // percorso in cui memorizzare i dati

    //metodo per salvare i dati su file 
    public void SalvaProdotti(List<ProdottoAdvanced> prodotti)
    {
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine($"Dati salvati in {filePath}:\n{jsonData}");
    }

    public List<ProdottoAdvanced> CaricaProdotti()
    {
        if(File.Exists(filePath))
        {
            string readJsonData = File.ReadAllText(filePath);
            List<ProdottoAdvanced> prodotti = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData);
            // Console.WriteLine("Dati caricati da file:");
            // foreach (var prodotto in prodotti)
            // {
            //     Console.WriteLine($"ID: {prodotto.Id} - Nome: {prodotto.NomeProdotto} - Prezzo: {prodotto.PrezzoProdotto} - Giacenza: {prodotto.GiacenzaProdotto}");
            // }
            // restituisco la lista di prodotti letti dal file in modo che possa essere utilizzata all'esterno della classe
            return prodotti;
        }
        else
        {
            if (!File.Exists("prodotti.json"))
            {
                File.Create("prodotti.json").Close();
                string importDefault = File.ReadAllText("default.json");
                string newDefault = JsonConvert.SerializeObject(importDefault, Formatting.Indented);
                File.WriteAllText(filePath, newDefault);
            }
            Console.WriteLine("Nessun dato trovato. Inizializzare una nuova lista di prodotti.");
            //File.Copy(filePath, @"default.json");
            // File.Copy(filePath, "default.json");


            // restituisco una lista di prodotti vuota se il file non esisteo è vuoto
            return new List<ProdottoAdvanced>(); 
        }
    }
}
