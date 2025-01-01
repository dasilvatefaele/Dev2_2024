using System.Diagnostics;
using System.Diagnostics.Tracing;
using Newtonsoft.Json;

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
        CategorieRepository repositoryCategorie = new CategorieRepository();
        PurchaisRepository repostoryPurchase = new PurchaisRepository();

        List<Prodotto> prodotti = repositoryProdotti.CaricaProdotti();
        List<Prodotto> carrello = repositoryCarrello.CaricaProdotti();
        List<Dipendente> dipendenti = repositoryDipendenti.CaricaDipendenti();
        List<Cliente> clienti = repositoryClienti.CaricaClienti();
        List<Categoria> listaCategorie = repositoryCategorie.CaricaCategorie();
        List<Purchase> listaPurchase = repostoryPurchase.CaricaPurchases();
        Cliente cliente = new Cliente();

        PurchaisManager managerPurchase = new PurchaisManager(listaPurchase);
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);
        CarrelloAdvancedManager carrelloManager = new CarrelloAdvancedManager();
        DipendentiManager managerDipendenti = new DipendentiManager(dipendenti);
        ClientiManager clientiManager = new ClientiManager(clienti);
        CategoriaManager managerCategorie = new CategoriaManager(listaCategorie);

        decimal subTotal = 0;

        // entrambi i costruttori dei manager richiedono l'argomento dell'oggetto da gestire 
        bool continua = true;
        bool continuaComeCliente = true;
        bool continuaComeDipendente = true;
        bool confermaAcquisto = false;
        bool attendoIlCassiere = false;
        decimal calcoloTotaleCarrello = 0;
        #endregion

        while (continua)
        {
            bool scelta = InputManager.LeggiConferma("Sei un cliente?");
            Console.Clear();
            switch (scelta)
            {
                case true:  //* AREA CLIENTI
                    string usernameCliente = InputManager.LeggiStringa("Inserisci il tuo Username > ");
                    Console.Clear();
                    cliente = clientiManager.CreaCliente(usernameCliente);
                    // controllo dell'username: se username già nel database, carica dati di quel cliente, se non esiste, crearne uno nuovo

                    while (continuaComeCliente) //* MENU CLIENTI
                    {
                        Console.WriteLine("MENU:\n");
                        Console.WriteLine("1. Visualizza prodotti");
                        Console.WriteLine("2. Aggiungi al carrello");
                        Console.WriteLine("3. Rimuovi dal prodotto");
                        Console.WriteLine("4. Il tuo carrello");
                        Console.WriteLine("5. Procedi al pagamento");
                        Console.WriteLine("6. Verifica il tuo credito");
                        Console.WriteLine("7. La tua percentuale di sconto");
                        Console.WriteLine("0. Annulla ed Esci");

                        string inserimento = InputManager.LeggiIntero("\n> ", 0, 7).ToString();
                        Console.Clear();

                        if (attendoIlCassiere)
                        {
                            if (inserimento == "4" || inserimento == "6" || inserimento == "0")
                            {
                                // accetta 4, 6, 0 
                            }
                            else
                            {
                                inserimento = "202";
                            }
                        }

                        switch (inserimento)
                        {
                            case "1": // CLIENTE > GUARDA I NOSTRI PRODOTTI
                                Console.WriteLine($"{cliente.Username}: GUARDA I NOSTRI PRODOTTI\n");
                                if (prodotti != null) // se ci sono prodotti
                                {
                                    // stampa prodotti in modalità cliente
                                    StampaTabella.ComeCliente(prodotti);
                                    NewLine();
                                }
                                else
                                {
                                    // altrimenti avvisa assenza di prodotti
                                    Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                                }
                                break;
                            case "2": // CLIENTE > AGGIUNGI AL CARRELLO
                                Console.WriteLine($"{cliente.Username}: AGGIUNGI AL CARRELLO\n");
                                // stampo il catalogo come cliente
                                StampaTabella.ComeCliente(prodotti);
                                NewLine();

                                // chiedo il nome del prodotto
                                string nomeProdotto = InputManager.LeggiStringa("Inserisci il prodotto > ");

                                // se il prodotto esiste e la giacenza è sufficiente lo salva nel carrello cliente 
                                // e decrementa la giacenza, altrimenti stampa non trovato ed esce
                                carrelloManager.AggiungiProdotto(nomeProdotto, carrello, ref cliente);

                                // salvo la persistenza dei dati 
                                cliente = repositoryClienti.CaricaCliente(cliente);
                                prodotti = repositoryProdotti.CaricaProdotti();
                                NewLine();
                                Console.Clear();
                                break;
                            case "3": // CLIENTE > RIMUOVI DAL CARRELLO
                                Console.WriteLine($"{cliente.Username}: RIMUOVI DAL CARRELLO\n");

                                // stampo il carrello (Qnt. |  Nome | Prezzo)
                                StampaTabella.Carrello(cliente.Cart.Cart);
                                NewLine();

                                // acquisisco la stringa del nome del prodotto da rimuovere
                                string prodottoDaRimuovere = InputManager.LeggiStringa("Che cosa vuoi rimuovere? > ");

                                // se acquisisco 0 torno al menu senza far nulla, altrimenti procede
                                if (!(prodottoDaRimuovere == "0"))
                                {
                                    carrelloManager.RimuoviProdottoDalCarrello(prodottoDaRimuovere, ref cliente, manager.OttieniProdotti());
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Nessun prodotto rimosso dal carrello.");
                                }
                                break;
                            case "4": // CLIENTE > GUARDA IL TUO CARRELLO
                                Console.WriteLine($"{cliente.Username}: GUARDA IL TUO CARRELLO\n");
                                StampaTabella.Carrello(cliente.Cart.Cart);
                                // stampo il carrello (Qnt. |  Nome | Prezzo)
                                NewLine();
                                // spazio
                                break;
                            case "5": // CLIENTE > GENERA ORDINE
                                Console.WriteLine($"{cliente.Username}: GENERA ORDINE\n");
                                StampaTabella.Carrello(cliente.Cart.Cart);
                                NewLine();
                                confermaAcquisto = InputManager.LeggiConferma("Confermi l'aquisto?");
                                Console.Clear();

                                calcoloTotaleCarrello = carrelloManager.CalcolaTotale(cliente.Cart.Cart);
                                if (confermaAcquisto)
                                {

                                    if (cliente.PercentualeSconto != 0)
                                    {
                                        calcoloTotaleCarrello -= (calcoloTotaleCarrello * cliente.PercentualeSconto) / 100;
                                    }

                                    if (cliente.Credito >= calcoloTotaleCarrello)
                                    {
                                        managerPurchase.GeneraPurchase(new Purchase
                                        {
                                            IdCliente = cliente.Id,
                                            NomeCliente = cliente.Username,
                                            MyPurchase = new Carrello
                                            {
                                                Cart = cliente.Cart.Cart,
                                                Completed = confermaAcquisto
                                            },
                                            Data = DateTime.Now.ToString("dd/MM/yyyy alle HH:mm"),
                                            Totale = calcoloTotaleCarrello,
                                            Completed = false,
                                        });
                                        listaPurchase = repostoryPurchase.CaricaPurchases();
                                        repostoryPurchase.SalvaPurchase(listaPurchase);
                                        cliente.Cart.Completed = true;
                                        repositoryClienti.SalvaClienti(cliente);
                                        Console.Clear();
                                        Console.WriteLine("Il tuo ordine sta per essere processato, attendere...\n");
                                        attendoIlCassiere = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Acquisto ancora non confermato");
                                }

                                break;
                            case "6": // CLIENTE > VERIFICA IL TUO CREDITO
                                Console.WriteLine($"{cliente.Username}: VERIFICA IL TUO CREDITO\n");
                                Console.WriteLine($"Credito attuale: € {cliente.Credito.ToString()}");
                                NewLine();
                                break;
                            case "7": // CLIENTE > LA TUA PERCENTUALE DI SCONTO
                                clientiManager.CalcoloSconto(ref cliente);
                                repositoryClienti.SalvaClienti(cliente);
                                Console.WriteLine($"{cliente.Username}: LA TUA PERCENTUALE DI SCONTO\n");
                                Console.WriteLine($"è del %{cliente.PercentualeSconto} sulle tue prossime spese.\n");
                                break;
                            case "202": // IN ATTESA DELLO SBLOCCO DA PARTE DEL CASSIERE
                                Console.Clear();
                                Console.WriteLine("Il tuo ordine sta per essere processato, attendere...\n");
                                break;
                            case "0": // CLIENTE > SICURO DI USCIRE?
                                Console.WriteLine($"{cliente.Username}: SICURO DI USCIRE?\n");
                                Console.Clear();
                                Console.WriteLine("1. Esci dalla sessione   ");
                                Console.WriteLine("2. Termina l'applicazione");
                                Console.WriteLine("3. Continua l'acquisto...");
                                int inserimentoUscita = InputManager.LeggiIntero("\n> ", 1, 3);
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
                                        Console.WriteLine("\nArrivederci!\n");
                                        // stampo

                                        break;
                                    case 3:

                                        Console.Clear();
                                        // Non fa nulla, quindi torna indietro

                                        break;
                                }
                                break;
                            default:  // default
                                Console.WriteLine("INSERIMENTO MENU NON VALIDO\n");
                                // dato che c'è il controllo di acquisizione nella scelta
                                // questo messaggio non dovrebbe apparire mai
                                break;
                        }
                    }
                    continuaComeCliente = true;
                    break;
                case false: //* AREA DIPENDENTI
                    Console.WriteLine("Accedi come dipendente.");
                    string usernameAccesso = InputManager.LeggiStringa("Inserisci il tuo Username > ");
                    var dipendente = managerDipendenti.AccediComeDipendente(usernameAccesso);
                    Console.Clear();

                    while (continuaComeDipendente)                               // SCELTA RUOLO
                    {
                        repositoryProdotti.SalvaProdotti(prodotti);
                        prodotti = repositoryProdotti.CaricaProdotti();

                        if (dipendente != null)
                        {
                            Console.WriteLine("AREA DIPENDENTI\n");
                            Console.WriteLine("1. Cassiere");
                            Console.WriteLine("2. Magazziniere");
                            Console.WriteLine("3. Amministratore");
                            Console.WriteLine("0. Esci");
                            int inserimentoAdmin = InputManager.LeggiIntero("\nSeleziona la tua posizione > ", 0, 3);
                            Console.Clear();
                            switch (inserimentoAdmin)
                            {
                                case 1: //* MODALITA' CASSIERE  
                                    bool continuaComeCassiere = true;
                                    if (!PermessiCassiere(dipendente))
                                    {
                                        Console.WriteLine("Non hai i diritti per accedere al terminale del Cassiere\n");
                                    }

                                    while (continuaComeCassiere && PermessiCassiere(dipendente))
                                    {
                                        Console.WriteLine("MODALITA' CASSIERE\n");
                                        Console.WriteLine("1. Visualizza Acquisti in attesa");
                                        Console.WriteLine("2. Processa Acquisti");
                                        Console.WriteLine("3. Ricarica credito cliente");
                                        Console.WriteLine("0. Indietro");
                                        listaPurchase = repostoryPurchase.CaricaPurchases();
                                        string sceltaCassiere = InputManager.LeggiIntero("\n> ", 0, 3).ToString();
                                        Console.Clear();
                                        switch (sceltaCassiere)
                                        {
                                            case "1": // MODALITA' CASSIERE > VISUALIZZA
                                                Console.WriteLine("MODALITA' CASSIERE > VISUALIZZA\n");
                                                StampaTabella.Purchase(listaPurchase);
                                                break;
                                            case "2": // MODALITA' CASSIERE > PROCESSA ACQUISTO
                                                Console.WriteLine("MODALITA' CASSIERE > PROCESSA ACQUISTO\n");
                                                listaPurchase = repostoryPurchase.CaricaPurchases();
                                                //stampa tabella purchase
                                                StampaTabella.Purchase(listaPurchase);

                                                // acquisisci ID del prodotto da processare
                                                int selezionaId = InputManager.LeggiIntero("\nInserisci l'ordine da processare > ", 0);
                                                Console.Clear();

                                                // se inserimento = 0, torna indietro, altrimenti seleziona
                                                if (selezionaId != 0)
                                                {
                                                    // per ogni singolo purchase nella lista purchase
                                                    foreach (var item in listaPurchase)
                                                    {

                                                        // se l'ID del singolo purchase è uguale a quello inserito
                                                        if (item.IdPurchase == selezionaId)
                                                        {
                                                            Purchase tempPurchase = repostoryPurchase.CaricaPurchasesSingolo(selezionaId);

                                                            StoricoAcquisti tempStoricoAcquisti = new StoricoAcquisti
                                                            {
                                                                MyPurchase = cliente.Cart.Cart,
                                                                Data = item.Data,
                                                                CreditoResiduo = cliente.Credito,
                                                                Totale = item.Totale,
                                                            };

                                                            cliente.StoricoAcquisti.Add(tempStoricoAcquisti);
                                                            
                                                            tempPurchase.Completed = true;
                                                            repostoryPurchase.SalvaPurchaseSingolo(tempPurchase);


                                                            cliente.Credito -= calcoloTotaleCarrello;
                                                            cliente.Cart.Cart = new List<ProdottoCarrello>();
                                                            cliente.Cart.Completed = false;
                                                            repositoryClienti.SalvaClienti(cliente);
                                                            attendoIlCassiere = false;
                                                            Console.WriteLine("\nAcquisto andato a buon fine! Il cliente può ora ritirare lo scontrino!");



                                                        }
                                                    }
                                                }
                                                break;
                                            case "3": // MODALITA' CASSIERE > RICARICA CREDITO
                                                Console.WriteLine("MODALITA' CASSIERE > RICARICA CREDITO\n");
                                                Console.WriteLine($"{cliente.Username}, il tuo credito attuale è di € {cliente.Credito}");
                                                NewLine();
                                                decimal ricarica = InputManager.LeggiDecimale("Inserire importo da ricaricare: € ");
                                                Console.Clear();
                                                if (ricarica != 0)
                                                {
                                                    cliente.Credito += ricarica;
                                                    Console.WriteLine($"{cliente.Username}, il tuo nuovo credito è di {cliente.Credito}!");
                                                    Console.WriteLine("Premi un tasto per continuare...");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    repositoryClienti.SalvaClienti(cliente);
                                                    cliente = repositoryClienti.CaricaCliente(cliente);
                                                }
                                                break;
                                            case "0": // MODALITA' CASSIERE > ESCI
                                                continuaComeCassiere = false;
                                                break;
                                        }
                                    }

                                    break;
                                case 2: //* MODALITA' MAGAZZINIERE 
                                    bool continuaComeMagazziniere = true;
                                    if (!PermessiMagazziniere(dipendente))
                                    {
                                        Console.WriteLine("Non hai i diritti per accedere al terminale del Magazziniere\n");
                                    }

                                    while (continuaComeMagazziniere && PermessiMagazziniere(dipendente))
                                    {
                                        Console.WriteLine("MODALITA' MAGAZZINIERE\n");
                                        Console.WriteLine("1. Visualizza Prodotto");
                                        Console.WriteLine("2. Aggiungi Prodotto");
                                        Console.WriteLine("3. Trova Prodotto per ID");
                                        Console.WriteLine("4. Modifica Prodotto");
                                        Console.WriteLine("5. Elimina Prodotto");
                                        Console.WriteLine("6. Gestione Categorie");
                                        Console.WriteLine("0. Indietro");

                                        string sceltaMagazziniere = InputManager.LeggiIntero("\n> ", 0, 6).ToString();
                                        Console.Clear();
                                        switch (sceltaMagazziniere) // MENU MAGAZZINIERE
                                        {
                                            case "1": // MODALITA' MAGAZZINIERE > VISUALIZZA
                                                prodotti = repositoryProdotti.CaricaProdotti();
                                                Console.WriteLine("MODALITA' MAGAZZINIERE > VISUALIZZA\n");
                                                if (prodotti != null)
                                                {
                                                    StampaTabella.ComeAdmin(prodotti);
                                                    NewLine();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                                                    NewLine();
                                                }
                                                break;
                                            case "2": // MODALITA' MAGAZZINIERE > AGGIUNGI PRODOTTO
                                                Console.WriteLine("MODALITA' MAGAZZINIERE > AGGIUNGI PRODOTTO\n");
                                                Categoria assegnaCategoria = new Categoria();
                                                string nome = InputManager.LeggiStringa("Nome > ");
                                                decimal prezzo = InputManager.LeggiDecimale("Prezzo > ");
                                                int giacenza = InputManager.LeggiIntero("Giacenza > ", 0);
                                                Categoria nuovaCategoria = new Categoria();
                                                foreach (var categoria in listaCategorie)
                                                {
                                                    Console.WriteLine($"{categoria.ID} {categoria.Name}");
                                                }
                                                int sceltaCategoria = InputManager.LeggiIntero("Scegli la categoria > ", 0);
                                                foreach (var categoria in listaCategorie)
                                                {
                                                    if (sceltaCategoria == categoria.ID)
                                                    {
                                                        nuovaCategoria = categoria;
                                                    }
                                                }
                                                manager.AggiungiProdotto(new Prodotto { Nome = nome, Prezzo = prezzo, Giacenza = giacenza, Categoria = nuovaCategoria });
                                                repositoryProdotti.SalvaProdotti(manager.OttieniProdotti());
                                                Console.Clear();

                                                Console.WriteLine($"'{nome}' Aggiunto al correttamente catalogo.\n");
                                                break;
                                            case "3": // MODALITA' MAGAZZINIERE > TROVA PER ID
                                                Console.WriteLine("MODALITA' MAGAZZINIERE > TROVA PER ID\n");
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
                                            case "4": // MODALITA' MAGAZZINIERE > MODIFICA PRODOTTO
                                                      // Console.Write("ID > ");
                                                Console.WriteLine("MODALITA' MAGAZZINIERE > MODIFICA PRODOTTO\n");
                                                StampaTabella.ComeAdmin(prodotti);
                                                int idProdottoDaAggiornare = InputManager.LeggiIntero("\nID > ", 0);
                                                Prodotto prodottoTrovato2 = manager.TrovaProdotto(idProdottoDaAggiornare);
                                                nuovaCategoria = new Categoria();
                                                if (prodottoTrovato2 != null)
                                                {
                                                    string nomeAggiornato = InputManager.LeggiStringa("Nome > ");
                                                    decimal prezzoAggiornato = InputManager.LeggiDecimale("Prezzo > ");
                                                    int giacenzaAggiornata = InputManager.LeggiIntero("Giacenza > ");
                                                    Console.WriteLine("Seleziona la categoria:\n");
                                                    foreach (var categoria in listaCategorie)
                                                    {
                                                        Console.WriteLine($"{categoria.ID}. {categoria.Name}");
                                                    }
                                                    sceltaCategoria = InputManager.LeggiIntero("\nScegli la categoria > ", 0);
                                                    foreach (var categoria in listaCategorie)
                                                    {
                                                        if (sceltaCategoria == categoria.ID)
                                                        {
                                                            nuovaCategoria = categoria;
                                                        }
                                                    }

                                                    manager.AggiornaProdotto(idProdottoDaAggiornare, new Prodotto { Nome = nomeAggiornato, Prezzo = prezzoAggiornato, Giacenza = giacenzaAggiornata, Categoria = nuovaCategoria });
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"\nProdotto non trovato per ID {idProdottoDaAggiornare}");
                                                }
                                                repositoryProdotti.SalvaProdotti(manager.OttieniProdotti());
                                                prodotti = repositoryProdotti.CaricaProdotti();

                                                break;
                                            case "5": // MODALITA' MAGAZZINIERE > ELIMINA PRODOTTO
                                                Console.WriteLine("MODALITA' MAGAZZINIERE > ELIMINA PRODOTTO\n");
                                                StampaTabella.ComeAdmin(prodotti);
                                                //Console.Write("ID > ");
                                                // int idProdottoDaEliminare = int.Parse(Console.ReadLine());
                                                int idProdottoDaEliminare = InputManager.LeggiIntero("ID > ", 0);
                                                manager.EliminaProdotto(idProdottoDaEliminare);
                                                repositoryProdotti.SalvaProdotti(manager.OttieniProdotti());
                                                break;
                                            case "6": // MODALITA' MAGAZZINIERE > GESTIONE CATEGORIE CATEGORIE
                                                bool continuaInCategorie = true;
                                                while (continuaInCategorie)
                                                {

                                                    Console.WriteLine("MODALITA' MAGAZZINIERE > GESTIONE CATEGORIE\n");
                                                    Console.WriteLine("1. Nuova Categoria");
                                                    Console.WriteLine("2. Modifica Categoria");
                                                    Console.WriteLine("3. Elimina Categoria");
                                                    Console.WriteLine("4. Visualizza Categorie");
                                                    Console.WriteLine("0. Indietro");
                                                    int sceltaCategorie = InputManager.LeggiIntero("\n> ", 0, 4);
                                                    Console.Clear();
                                                    switch (sceltaCategorie)
                                                    {
                                                        case 1:
                                                            Console.WriteLine("MODALITA' MAGAZZINIERE > GESTIONE CATEGORIE > NUOVA CATEGORIA \n");
                                                            string nomeNuovaCategoria = InputManager.LeggiStringa("\nInserisci il nome della nuova categoria: ");
                                                            managerCategorie.AggiungiCategoria(new Categoria { Name = nomeNuovaCategoria });
                                                            repositoryCategorie.SalvaCategorie(listaCategorie);
                                                            Console.Clear();
                                                            Console.WriteLine($"Categoria '{nomeNuovaCategoria}' inserita correttamente.\n");

                                                            break;
                                                        case 2:
                                                            StampaTabella.Categorie(listaCategorie);
                                                            int idCategoriaDaModificare = InputManager.LeggiIntero("Inserisci ID categoria da modificare> ", 0);
                                                            string nomeCategoriaDaModificare = InputManager.LeggiStringa("Rinomina ID selezionato: ");
                                                            managerCategorie.AggiornaCategoria(idCategoriaDaModificare, new Categoria { Name = nomeCategoriaDaModificare });
                                                            repositoryCategorie.SalvaCategorie(listaCategorie);
                                                            break;
                                                        case 3:
                                                            StampaTabella.Categorie(listaCategorie);
                                                            int idCategoriaDaEliminare = InputManager.LeggiIntero("Inserisci ID categoria da eliminare> ", 0);
                                                            managerCategorie.EliminaCategoria(idCategoriaDaEliminare);
                                                            Console.Clear();
                                                            repositoryCategorie.SalvaCategorie(listaCategorie);
                                                            StampaTabella.Categorie(listaCategorie);
                                                            break;
                                                        case 4:
                                                            Console.WriteLine("MODALITA' MAGAZZINIERE > GESTIONE CATEGORIE > VISUALIZZA CATEGORIE\n");
                                                            StampaTabella.Categorie(listaCategorie);
                                                            break;
                                                        case 0:
                                                            continuaInCategorie = false;
                                                            break;
                                                    }


                                                }


                                                break;
                                            case "0": // ESCI
                                                continuaComeMagazziniere = false;
                                                break;
                                            default:
                                                Console.WriteLine("INSERIMENTO MENU NON VALIDO\n");
                                                break;
                                        }
                                    }

                                    break;
                                case 3: //* MODALITA' AMMINISTRATORE
                                    bool continuaComeAmministratore = true;
                                    if (!PermessiAmministratore(dipendente))
                                    {
                                        Console.WriteLine("Non hai i diritti per accedere al terminale dell'Amministratore\n");
                                    }
                                    while (continuaComeAmministratore && PermessiAmministratore(dipendente))
                                    {
                                        Console.WriteLine("MODALITA' AMMINISTRATORE\n");
                                        Console.WriteLine("1. Visualizza Dipendenti");
                                        Console.WriteLine("2. Aggiungi Dipendente");
                                        Console.WriteLine("3. Elimina Dipendente");
                                        Console.WriteLine("4. Aggiorna Dipendente");
                                        Console.WriteLine("5. Calcola Fatturato");
                                        Console.WriteLine("0. Indietro");

                                        string sceltaAmministratore = InputManager.LeggiIntero("\n> ", 0, 5).ToString();
                                        Console.Clear();

                                        switch (sceltaAmministratore) // MENU AMMINISTRATORE
                                        {
                                            case "1": // MODALITA' AMMINISTRATORE > VISUALIZZA DIPENDENTI
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > VISUALIZZA DIPENDENTI\n");
                                                StampaDipendenti.Tabella(dipendenti);
                                                NewLine();
                                                //Console.WriteLine("Visualizzazione ancora non disponibile");
                                                break;
                                            case "2": // MODALITA' AMMINISTRATORE > AGGIUNGI DIPENDENTE
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > AGGIUNGI DIPENDENTE\n");
                                                Dipendente nuovoDipendente = new Dipendente();
                                                string username = InputManager.LeggiStringa("Username del nuovo dipendente: ");
                                                string ruolo = InputManager.LeggiStringa("Ruolo: ");
                                                managerDipendenti.AggiungiDipendente(new Dipendente { Username = username, Ruolo = ruolo });
                                                repositoryDipendenti.SalvaDipendenti(dipendenti);
                                                break;
                                            case "3": // MODALITA' AMMINISTRATORE > ELIMINA DIPENDENTE
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > ELIMINA DIPENDENTE\n");
                                                StampaDipendenti.Tabella(dipendenti);
                                                int idPerElimina = InputManager.LeggiIntero("\nInserisci ID del dipendente da eliminare > ");
                                                managerDipendenti.EliminaDipendente(idPerElimina);
                                                repositoryDipendenti.SalvaDipendenti(dipendenti);
                                                Console.Clear();
                                                StampaDipendenti.Tabella(dipendenti);
                                                NewLine();

                                                break;
                                            case "4": // MODALITA' AMMINISTRATORE > AGGIORNA DIPENDENTE
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > AGGIORNA DIPENDENTE\n");
                                                StampaDipendenti.Tabella(dipendenti);
                                                int idPerAggiorna = InputManager.LeggiIntero("\nInserisci ID Cliente da aggiornare > ", 0);
                                                managerDipendenti.AggiornaDipendente(idPerAggiorna);
                                                repositoryDipendenti.SalvaDipendenti(dipendenti);
                                                Console.Clear();
                                                StampaDipendenti.Tabella(dipendenti);
                                                NewLine();
                                                break;
                                            case "5": // MODALITA' AMMINISTRATORE > CALCOLA FATTURATO
                                                listaPurchase = repostoryPurchase.CaricaPurchases();
                                                decimal totaleFatturato = 0;
                                                Console.WriteLine($"{"ID PURCHASE",-20}{"CLIENTE",-20}{"SPESA",-20}{"DATA",-20}");
                                                Console.WriteLine(new string('-', 80));
                                                foreach (var purchase in listaPurchase)
                                                {
                                                    Console.WriteLine($"{purchase.IdPurchase,-20}{purchase.NomeCliente,-20}{purchase.Totale,-20}{purchase.Data,-20}");
                                                    totaleFatturato += purchase.Totale;
                                                }
                                                Console.WriteLine(new string('-', 81));
                                                NewLine();
                                                Console.Write($"{"TOTALE FATTURATO:",-20}");
                                                Console.Write($"{totaleFatturato}");
                                                NewLine();
                                                NewLine();
                                                Console.WriteLine("Premi un tasto per tornare indietro...");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;
                                            case "0": // ESCI
                                                continuaComeAmministratore = false;
                                                break;
                                        }
                                    }
                                    break;
                                case 0: //* ESCI                     
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
                        else
                        {
                            Console.WriteLine("Dipendente non trovato.");
                            Console.WriteLine("Non sei un dipendente di questo supermercato.");
                            continuaComeDipendente = false;
                        }
                    }
                    break;
            }
            continuaComeDipendente = true;
        } // chiusa switch (scelta)
    } // chiusa while (continua)


    #region PERMESSI
    static bool PermessiMagazziniere(Dipendente dipendente)
    {
        if (dipendente.Ruolo == "Magazziniere" || dipendente.Ruolo == "admin")
        {
            return true;
        }
        return false;
    }
    static bool PermessiAmministratore(Dipendente dipendente)
    {
        if (dipendente.Ruolo == "Amministratore" || dipendente.Ruolo == "admin")
        {
            return true;
        }
        return false;
    }
    static bool PermessiCassiere(Dipendente dipendente)
    {
        if (dipendente.Ruolo == "Cassiere" || dipendente.Ruolo == "admin")
        {
            return true;
        }
        return false;
    }
    #endregion

    static void NewLine()
    {
        Console.WriteLine();
    }
}