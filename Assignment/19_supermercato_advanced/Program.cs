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
        #region Dichiarazione Variabili
        ProdottoRepository repositoryProdotti = new ProdottoRepository();
        CarrelloRepository repositoryCarrello = new CarrelloRepository();
        DipendentiRepository repositoryDipendenti = new DipendentiRepository();

        List<Prodotto> prodotti = repositoryProdotti.CaricaProdotti();
        List<Prodotto> carrello = repositoryCarrello.CaricaProdotti();
        List<Dipendente> dipendenti = repositoryDipendenti.CaricaDipendenti();

        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);
        CarrelloAdvancedManager carrelloManager = new CarrelloAdvancedManager(carrello);
        DipendentiManager managerDipendenti = new DipendentiManager(dipendenti);

        Categoria Carne = new Categoria() { Name = "Carne", ID = 0 };
        Categoria Verdure = new Categoria() { Name = "Verdure", ID = 1 };
        Categoria Pulizia = new Categoria() { Name = "Pulizia", ID = 2 };
        Categoria Bevande = new Categoria() { Name = "Bevande", ID = 3 };

        int IDTEST = 202;

        Cliente cliente;
        // entrambi i costruttori dei manager richiedono l'argomento dell'oggetto da gestire 
        bool continua = true;
        bool continuaComeCliente = true;
        bool continuaComeDipendente = true;
        #endregion

        while (continua)
        {
            bool scelta = InputManager.LeggiConferma("Sei un cliente?");
            Console.Clear();
            switch (scelta)
            {
                case true:                                                       // AREA CLIENTI
                    string accesso = InputManager.LeggiStringa("Inserisci il tuo Username > ");
                    cliente = new Cliente { Id = 1, Username = accesso, Carrello = carrello, StoricoAcquisti = carrello, PercentualeSconto = 100 };
                    // creare un controllo dell'username: se username già nel database, carica dati di quel cliente, se non esiste, crearne uno nuovo
                    // se username esiste, carica lo storico di quel cliente

                    while (continuaComeCliente) // MENU CLIENTI
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
                                Prodotto prodottoTrovato = manager.TrovaProdotto(idProdotto);
                                if (prodottoTrovato != null)
                                {
                                    Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.Nome}");
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
                                Prodotto prodottoTrovato2 = manager.TrovaProdotto(idProdottoDaAggiornare);
                                if (prodottoTrovato2 != null)
                                {
                                    string nomeAggiornato = InputManager.LeggiStringa("Nome > ");
                                    decimal prezzoAggiornato = InputManager.LeggiDecimale("Prezzo > ");
                                    int giacenzaAggiornata = InputManager.LeggiIntero("Giacenza > ");
                                    //int idBackup = prodottoTrovato2.Id;
                                    //Console.Write("Nome > ");
                                    //Console.Write("Prezzo > ");
                                    //Console.Write("Giacenza > ");
                                    manager.AggiornaProdotto(idProdottoDaAggiornare, new Prodotto { Nome = nomeAggiornato, Prezzo = prezzoAggiornato, Giacenza = giacenzaAggiornata });
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
                                        prodotti = repositoryProdotti.CaricaProdotti();
                                        repositoryProdotti.SalvaProdotti(prodotti);
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
                case false:                                                      // AREA DIPENDENTI
                    while (continuaComeDipendente)                               // SCELTA RUOLO
                    {
                        repositoryProdotti.SalvaProdotti(prodotti);
                        prodotti = repositoryProdotti.CaricaProdotti();
                        Console.WriteLine("MODALITA' ADMIN");
                        Console.WriteLine("1. Cassiere");
                        Console.WriteLine("2. Magazziniere");
                        Console.WriteLine("3. Amministratore");
                        Console.WriteLine("0. Esci");
                        int inserimentoAdmin = InputManager.LeggiIntero("Seleziona la tua posizione > ", 0, 3);
                        Console.Clear();
                        switch (inserimentoAdmin)                               //
                        {
                            case 1: // todo MODALITA' CASSIERE
                                break;
                            case 2: // MODALITA' MAGAZZINIERE   //* OK
                                
                                bool continuaComeMagazziniere = true;
                                while(continuaComeMagazziniere)
                                {
                                    Console.WriteLine("MODALITA' MAGAZZINIERE");
                                    Console.WriteLine("1. Visualizza");
                                    Console.WriteLine("2. Aggiungi");
                                    Console.WriteLine("3. Trova per ID");
                                    Console.WriteLine("4. Aggiorna");
                                    Console.WriteLine("5. Elimina");
                                    Console.WriteLine("0. Esci");

                                    string sceltaMagazziniere = InputManager.LeggiIntero("> ", 0, 5).ToString();
                                    Console.Clear();
                                    switch (sceltaMagazziniere) // MENU MAGAZZINIERE
                                    {
                                        case "1": // VISUALIZZA
                                            Console.WriteLine("\nProdotti:");
                                            if (prodotti != null)
                                            {
                                                StampaTabella.ComeAdmin(prodotti);
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                                                Console.WriteLine();
                                            }
                                            break;
                                        case "2": // AGGIUNGI
                                            Categoria assegnaCategoria = new Categoria();
                                            string nome = InputManager.LeggiStringa("Nome > ");
                                            decimal prezzo = InputManager.LeggiDecimale("Prezzo > ");
                                            int giacenza = InputManager.LeggiIntero("Giacenza > ", 0);
                                            Console.WriteLine("0. Carne");
                                            Console.WriteLine("1. Verdure");
                                            Console.WriteLine("2. Pulizia");
                                            Console.WriteLine("3. Bevande");
                                            int sceltaCategoria = InputManager.LeggiIntero("Scegli la categoria > ", 0);
                                            switch (sceltaCategoria)
                                            {
                                                case 0:
                                                    assegnaCategoria = Carne;
                                                    break;
                                                case 1:
                                                    assegnaCategoria = Verdure;
                                                    break;
                                                case 2:
                                                    assegnaCategoria = Pulizia;
                                                    break;
                                                case 3:
                                                    assegnaCategoria = Bevande;
                                                    break;
                                            }
                                            manager.AggiungiProdotto(new Prodotto { Nome = nome, Prezzo = prezzo, Giacenza = giacenza, Categoria = assegnaCategoria });
                                            repositoryProdotti.SalvaProdotti(prodotti);
                                            break;
                                        case "3": // TROVA PER ID
                                            prodotti = repositoryProdotti.CaricaProdotti();
                                            // Console.Write("ID > ");
                                            int idProdotto = InputManager.LeggiIntero("ID > ", 0);
                                            Prodotto prodottoTrovato = manager.TrovaProdotto(idProdotto);

                                            if (prodottoTrovato != null)
                                            {
                                                Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.Nome}");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                                            }
                                            break;
                                        case "4": // AGGIORNA
                                            // Console.Write("ID > ");
                                            StampaTabella.ComeAdmin(prodotti);
                                            int idProdottoDaAggiornare = InputManager.LeggiIntero("ID > ", 0);
                                            Prodotto prodottoTrovato2 = manager.TrovaProdotto(idProdottoDaAggiornare);
                                            if (prodottoTrovato2 != null)
                                            {
                                                string nomeAggiornato = InputManager.LeggiStringa("Nome > ");
                                                decimal prezzoAggiornato = InputManager.LeggiDecimale("Prezzo > ");
                                                int giacenzaAggiornata = InputManager.LeggiIntero("Giacenza > ");
                                                string nuovaCategoria = InputManager.LeggiStringa("Categoria > ");
                                                //int idBackup = prodottoTrovato2.Id;
                                                //Console.Write("Nome > ");
                                                //Console.Write("Prezzo > ");
                                                //Console.Write("Giacenza > ");
                                                manager.AggiornaProdotto(idProdottoDaAggiornare, new Prodotto { Nome = nomeAggiornato, Prezzo = prezzoAggiornato, Giacenza = giacenzaAggiornata });
                                            }
                                            else
                                            {
                                                Console.WriteLine($"\nProdotto non trovato per ID {idProdottoDaAggiornare}");
                                            }
                                            break;
                                        case "5": // ELIMINA
                                            StampaTabella.ComeAdmin(prodotti);
                                            //Console.Write("ID > ");
                                            // int idProdottoDaEliminare = int.Parse(Console.ReadLine());
                                            int idProdottoDaEliminare = InputManager.LeggiIntero("ID > ", 0);
                                            manager.EliminaProdotto(idProdottoDaEliminare);
                                            break;
                                        case "0": // ESCI
                                            continuaComeMagazziniere = false;
                                            repositoryProdotti.SalvaProdotti(manager.OttieniProdotti());
                                            break;
                                        default:  // non dovrebbe mai entrare in questo blocco di codice
                                            Console.WriteLine("INSERIMENTO MENU NON VALIDO\n");
                                            // dato che c'è il controllo di acquisizione nella scelta
                                            // questo messaggio non dovrebbe apparire mai
                                            break;
                                    }
                                }
                                break;
                            case 3: // MODALITA' AMMINISTRATORE //* OK
                                bool continuaComeAmministratore = true;
                                while (continuaComeAmministratore)
                                {
                                    Console.WriteLine("MODALITA' AMMINISTRATORE");
                                    Console.WriteLine("1. Visualizza Dipendenti");
                                    Console.WriteLine("2. Aggiungi Dipendente");
                                    Console.WriteLine("3. Elimina Dipendente");
                                    Console.WriteLine("4. Aggiorna Dipendente");
                                    Console.WriteLine("0. Esci");

                                    string sceltaAmministratore = InputManager.LeggiIntero("> ", 0, 4).ToString();
                                    Console.Clear();

                                    switch (sceltaAmministratore) // MENU AMMINISTRATORE
                                    {
                                        case "1":
                                            StampaDipendenti.Tabella(dipendenti);
                                            Console.WriteLine();
                                            //Console.WriteLine("Visualizzazione ancora non disponibile");
                                            break;
                                        case "2":
                                            dipendenti.Add(managerDipendenti.CreaDipendente());
                                            repositoryDipendenti.SalvaDipendenti(dipendenti);
                                            break;
                                        case "3":
                                            StampaDipendenti.Tabella(dipendenti);
                                            int idPerElimina = InputManager.LeggiIntero("Inserisci ID del dipendente da eliminare > ");
                                            managerDipendenti.EliminaDipendente(idPerElimina);
                                            break;
                                        case "4":
                                            StampaDipendenti.Tabella(dipendenti);
                                            int idPerAggiorna = InputManager.LeggiIntero("Inserisci ID Cliente da aggiornare > ", 0);
                                            managerDipendenti.AggiornaDipendente(idPerAggiorna);
                                            break;
                                        case "0":
                                            continuaComeAmministratore = false;
                                            break;
                                    }
                                }
                                break;
                            case 0: // ESCI                     //* OK
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
                    break;
            }
            continuaComeDipendente = true;
        } // chiusa switch (scelta)
    } // chiusa while (continua)
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