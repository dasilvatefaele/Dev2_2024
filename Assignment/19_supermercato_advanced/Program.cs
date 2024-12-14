using Newtonsoft.Json;

//? Chiedo se sei cliente o dipentente (scelta)
//! scelta 1

//* Cliente
//todo: menu
// Gestione del prodotti:
// può aggiungere
// rimuovere 
// visualizzare
// cambiare lo stato dell'ordine
class Program // <--- (standard/default)
{

    static void Main(string[] args) // <--- Entry point (standard/default)
    {
        Console.Clear();

        ProdottoRepository repositoryProdotti = new ProdottoRepository();
        CarrelloRepository repositoryCarrello = new CarrelloRepository();

        List<ProdottoAdvanced> prodotti = repositoryProdotti.CaricaProdotti();
        List<ProdottoAdvanced> carrello = repositoryCarrello.CaricaProdotti();

        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);
        CarrelloAdvancedManager carrelloManager = new CarrelloAdvancedManager(carrello);

        int IDTEST = 202;

        Cliente cliente;
        // entrambi i costruttori dei manager richiedono l'argomento dell'oggetto da gestire 

        bool continua = true;
        bool continuaComeCliente = true;
        bool continuaComeDipendente = true;



        while (continua)
        {
            bool scelta = InputManager.LeggiConferma("Sei un cliente?");



            Console.Clear();
            switch (scelta)
            {
                case true:
                    string accesso = InputManager.LeggiStringa("Inserisci il tuo Username > ");
                    //todo creare un controllo dell'username: se username già nel database, carica dati di quel cliente, se non esiste, crearne uno nuovo
                    //todo se username esiste, carica lo storico di quel cliente
                    cliente = new Cliente { Id = 1, Username = accesso, Carrello = carrello, StoricoAcquisti = carrello, PercentualeSconto = 100 };

                    while (continuaComeCliente)
                    {
                        Console.WriteLine($"BENVENUTO {cliente.Username}!");
                        Console.WriteLine("1. Visualizza prodotti");
                        Console.WriteLine("2. Aggiungi al carrello");
                        //Console.WriteLine("3. Rimuovi dal prodotti");
                        //Console.WriteLine("4. Modifica prodotti");
                        Console.WriteLine("5. Il tuo carrello");
                        //Console.WriteLine("6. Procedi al pagamento"); // cambia stato dell'ordine
                        Console.WriteLine("0. Annulla ed Esci"); // cambia stato dell'ordine
                                                                 // Console.Write("> ");
                                                                 // string scelta = Console.ReadLine();
                        string inserimento = InputManager.LeggiIntero("> ", 0, 5).ToString();
                        Console.Clear();

                        switch (inserimento)
                        {
                            case "1": //* OK - Visualizza Prodotti
                                // 
                                if (prodotti != null) // se ci sono prodotti
                                {
                                    StampaTabella.ComeCliente(prodotti);
                                    // stampa prodotti in modalità cliente

                                    Console.WriteLine();
                                    // a capo
                                }
                                else
                                {
                                    Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                                }
                                break;
                            case "2": //* OK - Aggiungi Prodotti

                                StampaTabella.ComeCliente(prodotti);
                                // stampo il catalogo del supermercato (visualizzazione cliente senza ID e Giacenza)

                                Console.WriteLine();
                                // a capo

                                string nomeProdotto = InputManager.LeggiStringa("Inserisci il prodotto > ");
                                // chiedo il nome del prodotto

                                carrelloManager.AggiungiProdotto(nomeProdotto, carrello);
                                // se il prodotto esiste lo aggiungo al carrello, altrimenti comunico che non esiste

                                Console.WriteLine();
                                // a capo

                                cliente.Carrello = carrello;
                                //aggiorno cliente

                                break;
                            case "3": // Elimina-Rimuovi dal carrello //! NOPE
                                prodotti = repositoryProdotti.CaricaProdotti();
                                int idProdotto = InputManager.LeggiIntero("ID > ", 0);
                                ProdottoAdvanced prodottoTrovato = manager.TrovaProdotto(idProdotto);
                                if (prodottoTrovato != null)
                                {
                                    Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.NomeProdotto}");
                                }
                                else
                                {
                                    Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                                }
                                break;
                            case "4": // Aggiorna-Modifica prodotti //! NOPE
                                      // Console.Write("ID > ");
                                StampaTabella.ComeAdmin(prodotti);
                                int idProdottoDaAggiornare = InputManager.LeggiIntero("ID > ", 0);
                                ProdottoAdvanced prodottoTrovato2 = manager.TrovaProdotto(idProdottoDaAggiornare);
                                if (prodottoTrovato2 != null)
                                {
                                    string nomeAggiornato = InputManager.LeggiStringa("Nome > ");
                                    decimal prezzoAggiornato = InputManager.LeggiDecimale("Prezzo > ");
                                    int giacenzaAggiornata = InputManager.LeggiIntero("Giacenza > ");
                                    //int idBackup = prodottoTrovato2.Id;
                                    //Console.Write("Nome > ");
                                    //Console.Write("Prezzo > ");
                                    //Console.Write("Giacenza > ");
                                    manager.AggiornaProdotto(idProdottoDaAggiornare, new ProdottoAdvanced { NomeProdotto = nomeAggiornato, PrezzoProdotto = prezzoAggiornato, GiacenzaProdotto = giacenzaAggiornata });
                                }
                                else
                                {
                                    Console.WriteLine($"\nProdotto non trovato per ID {idProdottoDaAggiornare}");
                                }
                                break;
                            case "5": //* OK - Visualizza Carrello

                                carrello = repositoryCarrello.CaricaProdotti();
                                // aggiorno carrello prima della visualizzazione

                                cliente.Carrello = carrello;
                                // aggiorno cliente

                                StampaTabella.Carrello(carrello);
                                // stampo il carrello (Qnt. |  Nome | Prezzo)

                                Console.WriteLine();
                                // a capo

                                break;
                            case "6": // procedi al pagamento //! NOPE
                                break;
                            case "0": //* OK - Esci

                                Console.Clear();

                                Console.WriteLine("1. Esci dalla sessione       [Conserva il Carrello]");
                                Console.WriteLine("2. Termina l'applicazione    [Elimina il Carrello]");
                                Console.WriteLine("3. Continua l'acquisto...    [Torna Indietro]");

                                int inserimentoUscita = InputManager.LeggiIntero("> ", 1, 3);

                                switch (inserimentoUscita)
                                {
                                    case 1:

                                        continuaComeCliente = false;
                                        // esco dal ciclo della sessione del cliente

                                        repositoryProdotti.SalvaProdotti(manager.OttieniProdotti());
                                        // aggiorno la persistenza nel catalogo prima di uscire dal ciclo sessione del cliente

                                        Console.Clear();

                                        break;

                                    case 2:

                                        continuaComeCliente = false;
                                        // esco dal ciclo della sessione del cliente

                                        continua = false;
                                        // esco dal ciclo principale per terminare 'applicazione

                                        Console.WriteLine("Arrivederci!\n");
                                        // stampo

                                        break;

                                    case 3:

                                        Console.Clear();

                                        // Non fa nulla, quindi torna indietro

                                        break;
                                }
                                break;
                            default:  //* OK - Default

                                Console.WriteLine("INSERIMENTO MENU NON VALIDO\n");
                                // dato che c'è il controllo di acquisizione nella scelta
                                // questo messaggio non dovrebbe apparire mai
                                break;
                        } // switch (inserimento) 
                    } // while (continuaComeCliente)
                    continuaComeCliente = true;
                    break;
                case false:
                    while (continuaComeDipendente)
                    {
                        Console.WriteLine("MODALITA' ADMIN");
                        Console.WriteLine("1. Cassiere");
                        Console.WriteLine("2. Magazziniere");
                        Console.WriteLine("3. Amministratore");
                        Console.WriteLine("0. Esci");
                        int inserimentoAdmin = InputManager.LeggiIntero("Seleziona la tua posizione > ", 0, 3);
                        Console.Clear();
                        switch (inserimentoAdmin)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 0:
                                continua = !InputManager.LeggiConferma("Terminare l'applicazione?");
                                Console.Clear();
                                continuaComeDipendente = false;
                                if (!continua)
                                {
                                    Console.WriteLine("Arrivederci!\n");
                                }
                                break;
                        }
                    }
                    continuaComeDipendente = true;
                    break;
            } // switch (scelta)
        } // while (continua)


    }
}


public class Cliente
{

    // static Cliente()
    // {
    //     _id = id;
    //     _username = username;
    //     _carrello = carrello;
    //     _storicoAcquisti = storicoAcquisti;
    // }
    private int _id;
    public int Id
    {
        get { return _id; }
        set
        {
            _id = value;
        }
    }

    private string _username;
    public string Username
    {
        get { return _username; }
        set
        {
            _username = value;
        }
    }

    private List<ProdottoAdvanced> _carrello;
    public List<ProdottoAdvanced> Carrello
    {
        get { return _carrello; }
        set
        {
            _carrello = value;
        }
    }

    private List<ProdottoAdvanced> _storicoAcquisti;
    public List<ProdottoAdvanced> StoricoAcquisti
    {
        get { return _storicoAcquisti; }
        set
        {
            _storicoAcquisti = value;
        }
    }

    private int _percentualeSconto;
    public int PercentualeSconto
    {
        get { return _percentualeSconto; }
        set
        {
            _percentualeSconto = value;
        }
    }
}


//! scelta 2
//? Quale Dipentente (scelta)

//? scelta 1
//* Amministratore
//todo: menu
//Può visualizzare ed impostare il ruolo dei dipendenti.

//? scelta 2
//* Cassiere
//todo: menu
// Può registrare i prodotti acquistati da un cliente 
// e calcolare il totale da pagare generando lo scontrino.

//? scelta 3
//* Magazziniere
//todo: menu
// Può viualizzare, aggiungere, rimuovere o 
// modificare prodotti dal magazzino.