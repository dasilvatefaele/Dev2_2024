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
        ClientiRepository repositoryClienti = new ClientiRepository();

        List<Prodotto> prodotti = repositoryProdotti.CaricaProdotti();
        List<Prodotto> carrello = repositoryCarrello.CaricaProdotti();
        List<Dipendente> dipendenti = repositoryDipendenti.CaricaDipendenti();
        List<Cliente> clienti = repositoryClienti.CaricaClienti();
        Cliente cliente = new Cliente();

        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);
        CarrelloAdvancedManager carrelloManager = new CarrelloAdvancedManager(carrello);
        DipendentiManager managerDipendenti = new DipendentiManager(dipendenti);
        ClientiManager clientiManager = new ClientiManager(clienti);

        Categoria Carne = new Categoria() { Name = "Carne", ID = 0 };
        Categoria Verdure = new Categoria() { Name = "Verdure", ID = 1 };
        Categoria Pulizia = new Categoria() { Name = "Pulizia", ID = 2 };
        Categoria Bevande = new Categoria() { Name = "Bevande", ID = 3 };

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
                    cliente = clientiManager.CreaCliente();
                    // controllo dell'username: se username già nel database, carica dati di quel cliente, se non esiste, crearne uno nuovo

                    while (continuaComeCliente) // MENU CLIENTI
                    {
                        Console.WriteLine($"BENVENUTO {cliente.Username}!");
                        Console.WriteLine("1. Visualizza prodotti");
                        Console.WriteLine("2. Aggiungi al carrello");
                        Console.WriteLine("3. Rimuovi dal prodotto");
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
                            case "1": // VISUALIZZA PRODOTTI DEL CATALOGO

                                if (prodotti != null) // se ci sono prodotti
                                {
                                    StampaTabella.ComeCliente(prodotti);
                                    // stampa prodotti in modalità cliente
                                    Console.WriteLine();
                                    // spazio
                                }
                                else
                                {
                                    // altrimenti stampa
                                    Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                                }

                                break;
                            case "2": // AGGIUNGE PRODOTTO AL CARRELLO

                                StampaTabella.ComeCliente(prodotti);
                                // stampo il catalogo come cliente
                                Console.WriteLine();
                                // spazio
                                string nomeProdotto = InputManager.LeggiStringa("Inserisci il prodotto > ");
                                // chiedo il nome del prodotto
                                carrelloManager.AggiungiProdotto(nomeProdotto, carrello, ref cliente);
                                // se il prodotto esiste e la giacenza è sufficiente lo salva nel carrello cliente 
                                // e decrementa la giacenza, altrimenti stampa non trovato ed esce
                                cliente = repositoryClienti.CaricaCliente(cliente);
                                prodotti = repositoryProdotti.CaricaProdotti();
                                // salvo la persistenza dei dati 
                                Console.WriteLine();
                                // spazio

                                break;
                            case "3": // RIMUOVE PRODOTTO DAL CARRELLO

                                // inizilizzo variabili utili per le prossime istruzioni
                                bool trovato = false;
                                int quantitaIndietro = 0;
                                Prodotto prodottoRestituito = new Prodotto();
                                ProdottoCarrello prodottoRimosso = new ProdottoCarrello();

                                // stampo il carrello (Qnt. |  Nome | Prezzo)
                                StampaTabella.Carrello(cliente.Carrello);
                                Console.WriteLine();

                                // acquisisco la stringa del nome del prodotto da rimuovere
                                string prodottoDaRimuovere = InputManager.LeggiStringa("Che cosa vuoi rimuovere? > ");
                                Console.Clear();

                                // cerco presenza del nome del prodotto acquisito da tastiera nella lista del carrello
                                foreach (var prodotto in cliente.Carrello)
                                {
                                    if (prodotto.Nome == prodottoDaRimuovere)
                                    {
                                        trovato = true; // se c'è corrispondenza è trovato
                                        quantitaIndietro = prodotto.Quantita; // salvo la quantita da restituire
                                        prodottoRimosso = prodotto; // salvo temporaneamente il prodotto rimosso
                                    }
                                }

                                // se è trovato:
                                // rimuove il prodotto dalla lista cliente
                                // e aggiunge la quantità alla giacenza del prodotto in magazzino
                                if (trovato)
                                {
                                    cliente.Carrello.Remove(prodottoRimosso);
                                    foreach (var prodotto in prodotti)
                                    {
                                        if (prodotto.Id == prodottoRimosso.Id)
                                        {
                                            prodotto.Giacenza += quantitaIndietro;

                                        }
                                    }
                                    Console.WriteLine($"'{prodottoDaRimuovere}' rimosso dal carrello.");

                                    // aggiorna la persistenza dei dati
                                    repositoryProdotti.SalvaProdotti(manager.OttieniProdotti());
                                    repositoryClienti.SalvaClienti(cliente);
                                }

                                // se non lo trova ti indica che il prodotto non è stato trovato nel carrello
                                // dunque nessuna delle operazioni al di sopra viene eseguita.
                                if (!trovato)
                                {
                                    Console.WriteLine($"Errore: '{prodottoDaRimuovere}' non trovato.");
                                }

                                break;
                            case "4": // todo Aggiorna-Modifica prodotti 
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
                            case "5": // VISUALIZZA CARRELLO

                                StampaTabella.Carrello(cliente.Carrello);
                                // stampo il carrello (Qnt. |  Nome | Prezzo)
                                Console.WriteLine();
                                // spazio

                                break;
                            case "6": // todoprocedi al pagamento 
                                break;
                            case "0": // ESCI DA SESSIONE O DA APPLICAZIONE

                                Console.Clear();
                                Console.WriteLine("1. Esci dalla sessione   ");
                                Console.WriteLine("2. Termina l'applicazione");
                                Console.WriteLine("3. Continua l'acquisto...");
                                int inserimentoUscita = InputManager.LeggiIntero("> ", 1, 3);
                                repositoryClienti.SalvaClienti(cliente);

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
                            default:  // DEFAULT (NON ACCESSIBILE)

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
                                while (continuaComeMagazziniere)
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
                                        case "1": // VISUALIZZA
                                            StampaDipendenti.Tabella(dipendenti);
                                            Console.WriteLine();
                                            //Console.WriteLine("Visualizzazione ancora non disponibile");
                                            break;
                                        case "2": // AGGIUNGI

                                            Dipendente nuovoDipendente = new Dipendente();
                                            nuovoDipendente.Username = InputManager.LeggiStringa("Username del nuovo dipendente: ");
                                            nuovoDipendente.Ruolo = InputManager.LeggiStringa("Ruolo: ");
                                            //nuovoDipendente.Id = AssegnaId(dipendenti);
                                            dipendenti.Add(nuovoDipendente);
                                            repositoryDipendenti.SalvaDipendenti(dipendenti);
                                            break;
                                        case "3": // ELIMINA
                                            StampaDipendenti.Tabella(dipendenti);
                                            int idPerElimina = InputManager.LeggiIntero("Inserisci ID del dipendente da eliminare > ");
                                            managerDipendenti.EliminaDipendente(idPerElimina);
                                            break;
                                        case "4": // AGGIORNA
                                            StampaDipendenti.Tabella(dipendenti);
                                            int idPerAggiorna = InputManager.LeggiIntero("Inserisci ID Cliente da aggiornare > ", 0);
                                            managerDipendenti.AggiornaDipendente(idPerAggiorna);
                                            break;
                                        case "0": // ESCI
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

