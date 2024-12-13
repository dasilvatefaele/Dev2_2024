using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class CarrelloAdvancedManager
{  
    private List<ProdottoAdvanced> prodotti; // prodotti e' private perche non voglio che venga modificato dall'esterno
    private List<ProdottoAdvanced> catalogoSupermercato; // prodotti e' private perche non voglio che venga modificato dall'esterno
    private readonly string filePath = "Purchase.json"; // percorso in cui memorizzare i dati
    private readonly string dirCarrello = "carrello";
    private readonly string dirCatalogo = "catalogo";
    private ProdottoRepository repoCatalogo;
    private ClienteRepository repoCarrello;
    private int prossimoId;
    
    public CarrelloAdvancedManager(List<ProdottoAdvanced> Prodotti)
    {
        prodotti = Prodotti;
        repoCatalogo = new ProdottoRepository(); 
        repoCarrello = new ClienteRepository();
        prossimoId = 1;
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id >= prossimoId)
            {
                prossimoId = prodotto.Id + 1;
            }
        }
    }
    public void AggiungiProdotto (string prodottoDaAggiungere, List<ProdottoAdvanced> carrello)
    {

        catalogoSupermercato = repoCatalogo.CaricaProdotti();
        bool trovato = false;

        foreach (var item in catalogoSupermercato)
        {
            if (item.NomeProdotto.ToString() == prodottoDaAggiungere)
            {
                int quantita = InputManager.LeggiIntero("Quantita > ", 0);

                if (item.GiacenzaProdotto > quantita)
                {
                    int temp = item.GiacenzaProdotto;
                    item.GiacenzaProdotto = quantita;
                    carrello.Add(item);
                    repoCarrello.SalvaProdotti(carrello); // aggiorno
                    repoCatalogo.SalvaProdotti(carrello);
                    trovato = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"Mi dispiace, Il prodotto non è più disponibile");
                    Console.WriteLine("Premi un tasto per uscire...");
                    Console.ReadLine();
                    Console.Clear();
                    trovato = true;
                }
            }
        }
    }


    // metodo per visualizzare 
    public List<ProdottoAdvanced> OttieniProdotti()
    {
        return prodotti;
    }

    // metodo per cercare un prodotto 
    public ProdottoAdvanced TrovaProdotto(int id)
    {
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                return prodotto;
            }
        }
        return null;
    }

    // metodo per modificare il prodotto
    public void AggiornaProdotto(int id, ProdottoAdvanced nuovoProdotto)
    {
        var prodotto = TrovaProdotto (id);
        if (prodotto != null)
        {
            prodotto.NomeProdotto = nuovoProdotto.NomeProdotto;
            prodotto.PrezzoProdotto = nuovoProdotto.PrezzoProdotto;
            prodotto.GiacenzaProdotto = nuovoProdotto.GiacenzaProdotto;
        }
    }

    // metodo per eliminare un prodotto
    public void EliminaProdotto (int id)
    {
        var prodotto = TrovaProdotto(id); // salvo il prodotto nella variabile se lo trovo, se non lo trova prodotto = null
        if (prodotto != null) // se lo trova
        {
            string[] files = Directory.GetFiles(dirCarrello); // salvo l'elenco di file nella cartella 
            foreach (string file in files) // per ogni file nella cartella 
            {
                string readJsonData = File.ReadAllText (file); // leggo il contenuto del file 
                ProdottoAdvanced prodottoTemporaneo = JsonConvert.DeserializeObject<ProdottoAdvanced>(readJsonData)!; // lo deserializzo in un prodotto temporaneo
                if (prodottoTemporaneo.Id == id) // se l'id del prodotto temporaneo è uguale all'id inserito dall'utente
                {
                    File.Delete(file); // elimina il file 
                    // repoCatalogo.SalvaProdotti(prodotti);
                }
            }
            prodotti.Remove(prodotto); // rimuovi il prodotto dalla lista runtime
        }
    }
}
