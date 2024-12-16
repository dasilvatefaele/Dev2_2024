using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class CarrelloAdvancedManager
{
    private List<Prodotto> prodotti; // prodotti e' private perche non voglio che venga modificato dall'esterno
    private List<Prodotto> catalogo; // prodotti e' private perche non voglio che venga modificato dall'esterno
    private readonly string filePath = "Purchase.json"; // percorso in cui memorizzare i dati
    private readonly string dirCarrello = "data/carrello";
    private readonly string dirCatalogo = "data/catalogo";
    private ProdottoRepository repoCatalogo;
    private CarrelloRepository repoCarrello;
    private Purchase purchase;
    private int prossimoId;

    // construttore
    // richiede l'argomento dell'oggetto da gestire (in questo caso lista di ProdottiAdvanced)
    public CarrelloAdvancedManager(List<Prodotto> Prodotti)
    {
        prodotti = Prodotti;
        repoCatalogo = new ProdottoRepository();
        repoCarrello = new CarrelloRepository();
        prossimoId = 1;
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id >= prossimoId)
            {
                prossimoId = prodotto.Id + 1;
            }
        }
    }
    public void AggiungiProdotto(string prodottoDaAggiungere, List<Prodotto> carrello)
    {
        catalogo = repoCatalogo.CaricaProdotti();
        // carico i prodotti aggiornati

        bool trovato = false;
        // abbasso il flag

        foreach (var item in catalogo)
        {
            if (item.Nome.ToString() == prodottoDaAggiungere)
            {
                int quantita = InputManager.LeggiIntero("Quantita > ", 0);
                // acquisisco la quantita desiderata

                if (item.Giacenza > quantita) // in la giacenza sia 1 non lo rende disponibile all'acquisto
                {
                    int temp = item.Giacenza;
                    // salvo la giacenza 

                    item.Giacenza = quantita;
                    // attribuisco la quantità desiderata al prodotto

                    carrello.Add(item);
                    // salvo il prodotto nel carrello

                    purchase = new Purchase { MyPurchase = carrello, Id = 1, Stato = false };
                    // salvo il carrello nel purchase

                    repoCarrello.SalvaProdotti(purchase);
                    // aggiorno la persistenza dei dati

                    carrello = repoCarrello.CaricaProdotti();
                    // ricarico il carrello in locale altrimenti rimane salvata ultima giacenza

                    item.Giacenza = temp - quantita;
                    // sottraggo la quantità alla giacenza e la attribuisco al prodotto

                    repoCatalogo.SalvaProdotti(catalogo);
                    // aggiorno la persistenza del catalogo

                    // purchase = new Purchase( carrello );

                    trovato = true;
                    // indico che è stato trovato

                    break;
                    // termina esecuzione del blocco di codice
                }
                else if (quantita == 0)
                {
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
        if (!trovato)
        {
            Console.Clear();
            Console.WriteLine($"'{prodottoDaAggiungere}': non trovato");
        }
    }


    // metodo per visualizzare 
    public List<Prodotto> OttieniProdotti()
    {
        return prodotti;
    }

    // metodo per cercare un prodotto 
    public Prodotto TrovaProdotto(int id)
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
    public void AggiornaProdotto(int id, Prodotto nuovoProdotto)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotto.Nome = nuovoProdotto.Nome;
            prodotto.Prezzo = nuovoProdotto.Prezzo;
            prodotto.Giacenza = nuovoProdotto.Giacenza;
        }
    }

    // metodo per eliminare un prodotto
    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id); // salvo il prodotto nella variabile se lo trovo, se non lo trova prodotto = null
        if (prodotto != null) // se lo trova
        {
            string[] files = Directory.GetFiles(dirCarrello); // salvo l'elenco di file nella cartella 
            foreach (string file in files) // per ogni file nella cartella 
            {
                string readJsonData = File.ReadAllText(file); // leggo il contenuto del file 
                Prodotto prodottoTemporaneo = JsonConvert.DeserializeObject<Prodotto>(readJsonData)!; // lo deserializzo in un prodotto temporaneo
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
