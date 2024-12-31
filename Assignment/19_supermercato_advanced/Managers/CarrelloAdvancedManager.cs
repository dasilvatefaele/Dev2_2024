using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class CarrelloAdvancedManager
{
    //private List<Prodotto> prodotti; // prodotti e' private perche non voglio che venga modificato dall'esterno
    private List<Prodotto> catalogo; // prodotti e' private perche non voglio che venga modificato dall'esterno
    private readonly string filePath = "Purchase.json"; // percorso in cui memorizzare i dati
    private readonly string dirPurchases = "data/purchases";
    private readonly string dirCarrello = "data/carrello";
    private readonly string dirCatalogo = "data/catalogo";
    private ProdottoRepository repoCatalogo;
    private CarrelloRepository repoCarrello;
    private ClientiRepository repoClienti;
    private ProdottoRepository repoProdotti;
    private Purchase purchase;
    //private int prossimoId;

    // construttore
    // richiede l'argomento dell'oggetto da gestire (in questo caso lista di ProdottiAdvanced)
    public CarrelloAdvancedManager()
    {
        //prodotti = Prodotti;
        repoCatalogo = new ProdottoRepository();
        repoCarrello = new CarrelloRepository();
        repoClienti = new ClientiRepository();
        repoProdotti = new ProdottoRepository();
    }
    public void AggiungiProdotto(string prodottoDaAggiungere, List<Prodotto> carrello, ref Cliente cliente)
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
                    ProdottoCarrello itemDaAggiungere = new ProdottoCarrello();

                    itemDaAggiungere.Id = item.Id;
                    itemDaAggiungere.Nome = item.Nome;
                    itemDaAggiungere.Prezzo = item.Prezzo;
                    itemDaAggiungere.Quantita = quantita;
                    itemDaAggiungere.Categoria = item.Categoria;

                    item.Giacenza -= quantita;
                    cliente.Cart.Cart.Add(itemDaAggiungere);

                    repoClienti.SalvaClienti(cliente);
                    // salvo la persistenza dei dati

                    repoCatalogo.SalvaProdotti(catalogo);
                    // aggiorno la persistenza del catalogo

                    trovato = true;
                    // indico che è stato trovato
                    Console.Clear();
                    Console.WriteLine($"'{prodottoDaAggiungere} x{quantita}' aggiunto al carrello!");

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
                    Console.WriteLine("Premi un tasto per continuare...");
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
    public void RimuoviProdottoDalCarrello(string prodottoDaRimuovere, ref Cliente cliente, List<Prodotto> prodotti)
    {

        // inizilizzo variabili utili per le prossime istruzioni
        bool trovato = false;
        int quantitaIndietro = 0;
        Prodotto prodottoRestituito = new Prodotto();
        ProdottoCarrello prodottoRimosso = new ProdottoCarrello();

        Console.Clear();

        // cerco presenza del nome del prodotto acquisito da tastiera nella lista del carrello
        foreach (var prodotto in cliente.Cart.Cart)
        {
            if (prodotto.Nome == prodottoDaRimuovere)
            {
                trovato = true; // se c'è corrispondenza è trovato
                quantitaIndietro = prodotto.Quantita; // salvo la quantita da restituire
                prodottoRimosso = prodotto; // salvo temporaneamente il prodotto rimosso
            }
        }

        // se presente
        if (trovato)
        {
            // rimuove il prodotto dalla cliente.Carrello
            cliente.Cart.Cart.Remove(prodottoRimosso);
            foreach (var prodotto in prodotti)
            {
                if (prodotto.Id == prodottoRimosso.Id)
                {
                    // e aggiunge la quantità alla giacenza del prodotto in magazzino
                    prodotto.Giacenza += quantitaIndietro;
                }
            }
            Console.WriteLine($"'{prodottoDaRimuovere}' rimosso dal carrello.");

            // aggiorna la persistenza dei dati
            repoProdotti.SalvaProdotti(prodotti);
            repoClienti.SalvaClienti(cliente);
        }

        // se non lo trova ti indica che il prodotto non è stato trovato nel carrello
        // dunque nessuna delle operazioni al di sopra viene eseguita.
        if (!trovato)
        {
            Console.WriteLine($"Errore: '{prodottoDaRimuovere}' non trovato.");
        }


    }

    public decimal CalcolaTotale(List<ProdottoCarrello> carrello)
    {
        decimal subTotale = 0;
        foreach (var prodotto in carrello)
        {
            if (prodotto.Quantita == 1)
            {
                subTotale += prodotto.Prezzo;
            }
            else if (prodotto.Quantita > 1)
            {
                subTotale += (decimal)(prodotto.Prezzo * prodotto.Quantita);
            }
        }
        return subTotale;
    }
}
