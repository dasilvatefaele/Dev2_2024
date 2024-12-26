using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class ProdottoAdvancedManager
{  
    private List<ProdottoAdvanced> prodotti; // prodotti e' private perche non voglio che venga modificato dall'esterno
    private readonly string filePath = "prodotti.json"; // percorso in cui memorizzare i dati
    private readonly string dirCatalogo = "catalogo";
    // private ProdottoRepository repo;
    private int prossimoId;
    public ProdottoAdvancedManager(List<ProdottoAdvanced> Prodotti)
    {
        prodotti = Prodotti;
        // repo = new ProdottoRepository(); //! non la sto usando ma è buono sapere che il costruttore inizializzi le variabili dichiarate nel campo della classe

        prossimoId = 1;
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id >= prossimoId)
            {
                prossimoId = prodotto.Id + 1;
            }
        }

        //this.prodotti = prodotti; //? "collego" la variabile prodotti passata come argomento alla variabile privata

        // inizializzo la lista di prodotti nel costruttore pubblico in modo che sia accessibile all'esterno
        // questo new è necessario affinchè dal dominio privato la classe possa comunicare all'esterno i dati aggiornati/manipolati
        // un modo per rendere pubblico un dato privato
    }

    // metodo per aggiungere
    public void AggiungiProdotto (ProdottoAdvanced prodotto)
    {
        prodotto.Id = prossimoId;
        prossimoId++;
        prodotti.Add(prodotto); // quella private
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
            string[] files = Directory.GetFiles(dirCatalogo); // salvo l'elenco di file nella cartella 
            foreach (string file in files) // per ogni file nella cartella 
            {
                string readJsonData = File.ReadAllText (file); // leggo il contenuto del file 
                ProdottoAdvanced prodottoTemporaneo = JsonConvert.DeserializeObject<ProdottoAdvanced>(readJsonData)!; // lo deserializzo in un prodotto temporaneo
                if (prodottoTemporaneo.Id == id) // se l'id del prodotto temporaneo è uguale all'id inserito dall'utente
                {
                    File.Delete(file); // elimina il file 
                    // repo.SalvaProdotti(prodotti);
                }
            }
            prodotti.Remove(prodotto); // rimuovi il prodotto dalla lista runtime
        }
    }
}
