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
                    while (continuaComeCliente)
                    {
                        Console.WriteLine("BENVENUTO!");
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
                            case "1": // Visualizza prodotti DEL SUPERMERCATO //* OK
                                if (prodotti != null)
                                {
                                    StampaTabella.ComeCliente(prodotti);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                                }
                                break;
                            case "2": // Aggiungi al prodotti 
                                StampaTabella.ComeCliente(prodotti);
                                Console.WriteLine();
                                string nomeProdotto = InputManager.LeggiStringa("Inserisci il prodotto > ");
                                carrelloManager.AggiungiProdotto(nomeProdotto, carrello);
                                Console.WriteLine();
                                //repositoryProdotti.SalvaProdotti(prodotti);                   
                                break;
                            case "3": // Rimuovi dal carrello
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
                            case "4": // Modifica prodotti
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
                            case "5": // Visualizza IL TUO CARRELLO //* OK
                                carrello = repositoryCarrello.CaricaProdotti();
                                StampaTabella.Carrello(carrello);
                                Console.WriteLine();
                                break;
                            case "6": // procedi al pagamento
                                break;
                            case "0": // Esci //* OK
                                Console.Clear();
                                Console.WriteLine("1. Esci dalla sessione       [Conserva il Carrello]");
                                Console.WriteLine("2. Termina l'applicazione    [Elimina il Carrello]");
                                Console.WriteLine("3. Continua l'acquisto...    [Torna Indietro]");
                                int inserimentoUscita = InputManager.LeggiIntero("> ", 1, 3);
                                switch (inserimentoUscita)
                                {
                                    case 1:
                                        continuaComeCliente = false;
                                        repositoryProdotti.SalvaProdotti(manager.OttieniProdotti());
                                        Console.Clear();
                                        break;
                                    case 2:
                                        continuaComeCliente = false;
                                        continua = false;
                                        Console.WriteLine("Arrivederci!\n");
                                        break;
                                    case 3:
                                        // continua...
                                        Console.Clear();
                                        break;
                                }
                                break;
                            default:  // Questo messaggio non dovrebbe apparire mai
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


static public class Cliente
{
    static private int id;
    static public int Id
    {
        get { return id; }
        set
        {
            id = value;
        }
    }

    static private string username;
    static public string Username
    {
        get { return username; }
        set
        {
            username = value;
        }
    }

    static private List<ProdottoAdvanced> carrello;
    static public List<ProdottoAdvanced> Carrello
    {
        get { return carrello; }
        set
        {
            carrello = value;
        }
    }

    static private List<ProdottoAdvanced> storicoAcquisti;
    static public List<ProdottoAdvanced> StoricoAcquisti
    {
        get { return storicoAcquisti; }
        set
        {
            storicoAcquisti = value;
        }
    }

    static private int percentualeSconto;
    static public int PercentualeSconto
    {
        get { return percentualeSconto; }
        set
        {
            percentualeSconto = value;
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