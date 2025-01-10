using System.Diagnostics;
using System.Diagnostics.Tracing;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Linq;

class Program
{
    static void Main(string[] args) 
    {
        Console.Clear();
        #region Dichiarazione Variabili
        
        // repository - oggetti per caricamento e salvataggio
        ProdottoRepository repositoryProdotti = new ProdottoRepository();
        CarrelloRepository repositoryCarrello = new CarrelloRepository();
        DipendentiRepository repositoryDipendenti = new DipendentiRepository();
        ClientiRepository repositoryClienti = new ClientiRepository();
        CategorieRepository repositoryCategorie = new CategorieRepository();
        PurchaisRepository repostoryPurchase = new PurchaisRepository();
        CasseRepository repositoryCasse = new CasseRepository();

        // oggetti - caricamento da /data tramite repository
        List<Prodotto> prodotti = repositoryProdotti.CaricaProdotti();
        List<Prodotto> carrello = repositoryCarrello.CaricaProdotti();
        List<Dipendente> dipendenti = repositoryDipendenti.CaricaDipendenti();
        List<Cliente> clienti = repositoryClienti.CaricaClienti();
        List<Categoria> listaCategorie = repositoryCategorie.CaricaCategorie();
        List<Purchase> listaPurchase = repostoryPurchase.CaricaPurchases();
        List<Cassa> listaCasse = repositoryCasse.CaricaCasse();
        Cliente cliente = new Cliente();

        // manager - gestione degli oggetti
        PurchaisManager managerPurchase = new PurchaisManager(listaPurchase);
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);
        CarrelloAdvancedManager carrelloManager = new CarrelloAdvancedManager();
        DipendentiManager managerDipendenti = new DipendentiManager(dipendenti);
        ClientiManager clientiManager = new ClientiManager(clienti);
        CategoriaManager managerCategorie = new CategoriaManager(listaCategorie);
        CassaManager managerCasse = new CassaManager(listaCasse);

        // variabili per il controllo dei loop principali
        bool continua = true; 
        bool continuaComeCliente = true;
        bool continuaComeDipendente = true;

        // variabili di servizio
        bool confermaAcquisto = false;
        int idClienteConnesso = -404;
        decimal calcoloTotaleCarrello = 0;

        #endregion

        while (continua) // PROGRAMMA
        {
            // viene chiesto se loggarsi come cliente [true] o come dipendente [false]

            Color.DarkCyan();
            Console.WriteLine("BENVENUTO AL SUPERMERCATO ADVANCED!");
            Console.WriteLine(new string('-', 35));
            Color.Reset();
            bool scelta = InputManager.LeggiConferma("\nACCEDI COME CLIENTE?");
            Console.Clear();

            switch (scelta)
            {
                case true: // AREA CLIENTI

                    // attraverso lo username il programma determina se 
                    // caricare i dati cliente nella variabile cliente dalla cartella data/clienti 
                    // se già presente o se creare un nuovo file

                    Color.DarkCyan();
                    Console.WriteLine("BENVENUTO AL SUPERMERCATO ADVANCED!");
                    Console.WriteLine(new string('-', 35));
                    Color.Reset();
                    string usernameCliente = "";
                    usernameCliente = InputManager.LeggiStringa("\nInserisci il tuo Username > ");
                    Console.Clear();
                    Cliente nuovoCliente = clientiManager.CheckCliente(usernameCliente);
                    if (nuovoCliente != null)
                    {
                        Color.Green();
                        Console.WriteLine($"BENTORNATO {nuovoCliente.Username}!");
                        Console.WriteLine(new string('-', 31));
                        Console.WriteLine();
                        cliente = nuovoCliente;
                    }
                    else
                    {
                        cliente = clientiManager.CreaCliente(usernameCliente);
                        Color.White();
                        Console.Write($"BENVENUTO ");
                        Color.Green();
                        Console.Write($"{usernameCliente}!\n");
                        Console.WriteLine("Ecco il tuo nuovo account!\n");
                        Color.Reset();
                    }

                    idClienteConnesso = cliente.Id;

                    while (continuaComeCliente) // PROGRAMMA CLIENTE
                    {

                        // visualizza le operazioni eseguibili dal cliente loggato
                        // tutte le voci saranno accessibili fino al completamento
                        // dell'acquisto. il totale del carrello è sempre visibile
                        // in modo chiaro e aggiornato in tempo reale

                        Color.Green();
                        Console.WriteLine("MENU:\n");
                        Color.White();
                        Console.WriteLine("1. Visualizza prodotti");
                        Console.WriteLine("2. Aggiungi al carrello");
                        Console.WriteLine("3. Rimuovi dal prodotto");
                        Console.WriteLine("4. Il tuo carrello");
                        Console.WriteLine("5. Procedi al pagamento");
                        Console.WriteLine("6. Verifica il tuo credito");
                        Console.WriteLine("7. La tua percentuale di sconto");
                        Console.WriteLine("8. Visualizza Storico");
                        Console.WriteLine("9. Prodotti per Categoria");
                        Console.WriteLine("0. Cassa o Esci");

                        NewLine();
                        Color.Green();
                        Console.WriteLine(new string('-', 35));
                        Console.WriteLine(
                            $"{"Totale:",-25}{"€" + carrelloManager.CalcolaTotale(cliente.Cart.Cart).ToString("F2"),-25}"
                        );
                        Console.WriteLine(new string('-', 35));
                        string inserimento = InputManager.LeggiIntero("\n> ", 0, 9).ToString();
                        Console.Clear();

                        // una volta confermati gli acquisti [5]
                        // saranno funzionanti solo le voci [4][6][0]
                        // un messaggio informerà il cliente che 
                        // deve attendere che un cassiere processi 
                        // il suo purchase. fino ad allora
                        // il credito non viene toccato e il carrello
                        // è preservato nel json del cliente
                        
                        if (cliente.Cart.Completed == true)
                        {
                            if (inserimento == "4" || inserimento == "6" || inserimento == "0")
                            {
                                // consenti
                            }
                            else
                            {
                                // nega
                                inserimento = "202";
                            }
                        }

                        // in base allo storico del cliente, se la somma degli
                        // acquisti precedenti > €50 il cliente avrà 5% di sconto
                        // se > €100 avrà il 10% di sconto su ogni prossimo carrello 

                        clientiManager.CalcoloSconto(ref cliente);
                        repositoryClienti.SalvaClienti(cliente);

                        switch (inserimento)
                        {
                            case "1": // CLIENTE > GUARDA I NOSTRI PRODOTTI

                                Color.Green();
                                Console.WriteLine($"{cliente.Username}: GUARDA I NOSTRI PRODOTTI\n");

                                // la stampa è personalizzata per il cliente [nome del prodotto][prezzo]
                                if (prodotti != null) 
                                {
                                    StampaTabella.ComeCliente(prodotti);
                                    NewLine();
                                }
                                else
                                {
                                    Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                                }
                                break;

                            case "2": // CLIENTE > AGGIUNGI AL CARRELLO

                                Console.WriteLine($"{cliente.Username}: AGGIUNGI AL CARRELLO\n");

                                // viene visualizzata la stampa personalizzata
                                // il cliente inserisce nome del prodotto e quantità
                                // che vuole aggiungere. in caso il cliente fosse entrato
                                // per sbaglio in questa modalità, basta inserire '0'
                                // in 'Inserisci il prodotto > ' per tornare indietro

                                StampaTabella.ComeCliente(prodotti);
                                NewLine();
                                Color.DarkGreen();
                                string nomeProdotto = InputManager.LeggiStringa("Inserisci il prodotto > ");

                                if (nomeProdotto != "0")
                                {
                                    // se il prodotto esiste e la giacenza è sufficiente (>=2) lo sposta nel carrello cliente
                                    // e decrementa la giacenza, altrimenti stampa '[articolo] non trovato'
                                    // e ti riporta al menu. infine salvo la persistenza dei dati

                                    carrelloManager.AggiungiProdotto(nomeProdotto, carrello, ref cliente);
                                    cliente = repositoryClienti.CaricaCliente(cliente);
                                    prodotti = repositoryProdotti.CaricaProdotti();
                                    NewLine();
                                }
                                else
                                {
                                    Console.Clear();
                                }
                                break;

                            case "3": // CLIENTE > RIMUOVI DAL CARRELLO

                                prodotti = repositoryProdotti.CaricaProdotti();
                                Console.WriteLine($"{cliente.Username}: RIMUOVI DAL CARRELLO\n");

                                // stampa personalizzata del carrello con 'Qnt. |  Nome | Prezzo'
                                // e 'totale' in modo chiaramente leggibile
                                // infine chiede IN ROSSO di inserire l'elento da eliminare
                                // se acquisisco 0 torno al menu senza far nulla, altrimenti 
                                // procede alla rimozione
                                StampaTabella.Carrello(cliente.Cart.Cart);
                                NewLine();
                                Color.Red();
                                string prodottoDaRimuovere = InputManager.LeggiStringa("Che cosa vuoi rimuovere? > ");
                                
                                if (prodottoDaRimuovere != "0")
                                {
                                    carrelloManager.RimuoviProdottoDalCarrello(prodottoDaRimuovere,ref cliente,prodotti);
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
                                NewLine();
                                break;

                            case "5": // CLIENTE > GENERA ORDINE

                                Console.WriteLine($"{cliente.Username}: GENERA ORDINE\n");

                                // il programma stampa il carrello, il totale e chiede
                                // conferma per creare il purchase, operazione che gli 
                                // impedirà di fare ulteriori acquisti o rimozioni

                                // in caso di mancata conferma, verrà comunicato
                                // 'Acquisto ancora non confermato' e il cliente
                                // potrà continuare come prima ad utilizzare il menu

                                StampaTabella.Carrello(cliente.Cart.Cart);
                                NewLine();
                                Color.DarkYellow();
                                confermaAcquisto = InputManager.LeggiConferma("Confermi l'aquisto?");
                                Color.Reset();
                                calcoloTotaleCarrello = carrelloManager.CalcolaTotale(cliente.Cart.Cart);

                                if (confermaAcquisto)
                                {
                                    // se la percentuale di sconto è diversa da 0 viene
                                    // letta la percentuale di sconto che il cliente ha 
                                    // raggiunto. lo sconto viene comunicato in modo chiaro
                                    // e applicato prima del controllo del credito

                                    if (cliente.PercentualeSconto != 0)
                                    {
                                        NewLine();
                                        Color.Green();
                                        Console.WriteLine("Congratulazioni!");
                                        Color.Reset();
                                        Console.WriteLine($"Per te che sei un cliente fedele,\navraid uno sconto del {cliente.PercentualeSconto}% !");
                                        Console.WriteLine(new string('-', 40));
                                        Color.Red();
                                        Console.WriteLine($"{"Prezzo normale:",-20} €{calcoloTotaleCarrello}");
                                        calcoloTotaleCarrello -= Math.Round(((calcoloTotaleCarrello * cliente.PercentualeSconto) / 100), 2);
                                        Color.Green();
                                        Console.Write($"{"Prezzo scontato:",-20} €{calcoloTotaleCarrello}");
                                        NewLine();
                                        Color.Reset();
                                        Console.WriteLine(new string('-', 40));
                                        Color.Green();
                                        Console.WriteLine("\nPremi un tasto per procedere...");
                                        Console.ReadKey();
                                    }

                                    // se il credito è sufficiente il processo prosegue
                                    // altrimenti viene comunicata la mancanza di fondi
                                    // e si chiede al cliente di rivolgersi a un cassiere
                                    // per ricaricare il credito

                                    if (cliente.Credito >= calcoloTotaleCarrello)
                                    {
                                        managerPurchase.GeneraPurchase(
                                            new Purchase
                                            {
                                                IdCliente = cliente.Id,
                                                NomeCliente = cliente.Username,
                                                MyPurchase = new Carrello
                                                {
                                                    Cart = cliente.Cart.Cart,
                                                    Completed = confermaAcquisto,
                                                },
                                                Data = DateTime.Now.ToString("dd/MM/yyyy alle HH:mm"),
                                                Totale = calcoloTotaleCarrello,
                                                Completed = false,
                                            }
                                        );
                                        listaPurchase = repostoryPurchase.CaricaPurchases();
                                        repostoryPurchase.SalvaPurchase(listaPurchase);
                                        cliente.Cart.Completed = true;
                                        repositoryClienti.SalvaClienti(cliente);
                                        Console.Clear();
                                        Color.DarkYellow();
                                        Console.WriteLine("CI SIAMO QUASI! Il tuo ordine deve essere processato da un cassiere, prego attendere...\n");
                                        Color.Reset();
                                        repositoryProdotti.SalvaProdotti(prodotti);
                                        prodotti = repositoryProdotti.CaricaProdotti();
                                    }
                                    else
                                    {
                                        Color.Red();
                                        Console.WriteLine("\nPurtroppo non hai fondi a sufficienza. Rivolgiti al cassiere per ricaricare il tuo credito e continuare l'acquisto!\n");
                                        Color.Reset();
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Color.Yellow();
                                    Console.WriteLine("Acquisto ancora non confermato\n");
                                }
                                break;

                            case "6": // CLIENTE > VERIFICA IL TUO CREDITO

                                Console.WriteLine($"{cliente.Username}: VERIFICA IL TUO CREDITO\n");
                                Color.White();
                                Console.Write("Credito attuale: ");
                                Color.Green();
                                Console.Write($"€ {cliente.Credito.ToString("F2")}");
                                Color.Reset();
                                NewLine();
                                NewLine();
                                break;

                            case "7": // CLIENTE > LA TUA PERCENTUALE DI SCONTO

                                Console.WriteLine($"{cliente.Username}: LA TUA PERCENTUALE DI SCONTO\n");
                                Console.Write($"{cliente.PercentualeSconto}% ");
                                Color.Reset();
                                Console.Write("sulle tue prossime spese.\n");
                                NewLine();
                                break;

                            case "8": // CLIENTE > I TUOI ULTIMI ACQUISTI

                                // una stampa personalizzata per monitorare lo storico
                                // acquisti del cliente loggato

                                Console.WriteLine($"{cliente.Username}: I TUOI ULTIMI ACQUISTI:\n");
                                StampaTabella.StampaStorico(cliente);
                                break;

                            case "9": // CLIENTE > ESPLORA PER CATEGORIE

                                // selezionata una categoria dall'elenco, il cliente visualizza
                                // solo gli elementi di quella categoria. dunque può decidere se 
                                // scegliere un elemento da quella lista filtrata oppure
                                // tornare indietro

                                List<Categoria> esploraCategorie = repositoryCategorie.CaricaCategorie();
                                string tempNomeCategoria = "";
                                Color.Green();
                                Console.WriteLine($"{cliente.Username}: ESPLORA PER CATEGORIE \n");
                                Color.Reset();

                                foreach (var categoria in esploraCategorie)
                                {
                                    Console.WriteLine($"{categoria.ID}. {categoria.Name}");
                                }

                                Color.Green();
                                int scegliCategoria = InputManager.LeggiIntero("\n> ", 0, esploraCategorie.Count);
                                Console.Clear();

                                List<Prodotto> tempProdotti = new List<Prodotto>();
                                foreach (var prodotto in manager.OttieniProdotti())
                                {
                                    if (prodotto.Categoria.ID == scegliCategoria)
                                    {
                                        tempProdotti.Add(prodotto);
                                        tempNomeCategoria = prodotto.Categoria.Name;
                                    }
                                }

                                Color.Green();
                                Console.WriteLine($"Categoria: {tempNomeCategoria}\n");
                                Color.Reset();
                                StampaTabella.ComeCliente(tempProdotti);
                                NewLine();

                                bool compra = InputManager.LeggiConferma("Desideri acquistare da qui?");

                                if (compra)
                                {
                                    Color.DarkGreen();
                                    string prodottoScelto = InputManager.LeggiStringa("Inserisci il prodotto > ");
                                    carrelloManager.AggiungiProdotto(prodottoScelto, carrello, ref cliente);
                                    cliente = repositoryClienti.CaricaCliente(cliente);
                                    prodotti = repositoryProdotti.CaricaProdotti();
                                    NewLine();
                                }

                                Console.Clear();
                                break;

                            case "202": // IN ATTESA DELLO SBLOCCO DA PARTE DEL CASSIERE

                                // se il cliente risponde [s] a procedi al pagamento
                                // viene reindirizzato qui quando tenta di modificare
                                // il carrello

                                Console.Clear();
                                Color.Yellow();
                                Console.WriteLine("Il tuo ordine sta per essere processato, attendere...\n");
                                Color.Reset();
                                break;

                            case "0": // CLIENTE > SICURO DI USCIRE?

                                // il programma chiede al cliente se e come si desidera uscire.
                                // [1] torna indietro
                                // [2] esce dalla sessione, solo un cassiere può completare l'operazione d'acquisto
                                // [3] termina l'applicazione (nessun dato andrà perduto) 

                                Console.WriteLine($"{cliente.Username}: SICURO DI USCIRE?\n");
                                Color.White();
                                Console.WriteLine("1. Continua l'acquisto");
                                Console.Write("2. Esci dalla sessione ");
                                Color.DarkGray();
                                Console.Write("(I tuoi dati non andranno persi!)");
                                NewLine();
                                Color.Red();
                                Console.WriteLine("3. Chiudi l'applicazione");
                                Color.White();
                                int inserimentoUscita = InputManager.LeggiIntero("\n> ", 1, 3);
                                repositoryClienti.SalvaClienti(cliente);

                                switch (inserimentoUscita)
                                {
                                    case 1: // CONTINUA L'ACQUISTO

                                        Console.Clear();
                                        // torna indietro
                                        break;

                                    case 2: // ESCI DALLA SESSIONE - SPOSTATI AL CASSIERE

                                        // aggiorno la persistenza nel catalogo prima di uscire 
                                        // dal ciclo sessione del cliente, 
                                        // TERMINO PROGRAMMA CLIENTE e torno a PROGRAMMA
                                        
                                        continuaComeCliente = false;
                                        prodotti = repositoryProdotti.CaricaProdotti();
                                        repositoryProdotti.SalvaProdotti(prodotti);
                                        Console.Clear();
                                        break;

                                    case 3: // TERMINA L'APPLICAZIONE

                                        // stampa 'A presto [cliente]!'
                                        // esco dal ciclo della sessione del cliente
                                        // TERMINO PROGRAMMA

                                        continuaComeCliente = false;
                                        continua = false;
                                        Color.Green();
                                        Console.WriteLine($"\nA presto {cliente.Username}!\n");
                                        Color.Reset();
                                        break;

                                }
                                break;
                            default: // default

                                Console.WriteLine("INSERIMENTO MENU NON VALIDO\n");
                                // dato che c'è il controllo di acquisizione nella scelta
                                // questo messaggio non dovrebbe apparire mai
                                break;
                        }
                    }
                    continuaComeCliente = true;
                    break;

                case false: // AREA DIPENDENTI

                    // viene chiesto all'utente di inserire il proprio username
                    // il programma carichera il dipendente corrispondente
                    // 'admin' può ha permessi illimitati
                    // in caso lo username del dipendente non sia presente
                    // verrà negato l'accesso.
                
                    Color.Magenta();
                    Console.WriteLine("AREA DIPENDENTI");
                    Console.WriteLine(new string('-', 35));
                    Color.Reset();
                    string usernameAccesso = InputManager.LeggiStringa("\nInserisci il tuo Username > ");
                    var dipendente = managerDipendenti.AccediComeDipendente(usernameAccesso);
                    Console.Clear();

                    while (continuaComeDipendente) // PROGRAMMA DIPENDENTI
                    {
                        repositoryProdotti.SalvaProdotti(prodotti);
                        prodotti = repositoryProdotti.CaricaProdotti();

                        if (dipendente != null)
                        {
                            Color.Magenta();
                            Console.WriteLine("AREA DIPENDENTI > SELEZIONA RUOLO");

                            // il ruolo del dipendente loggato determina a quali voci 
                            // del menu potrà potrà avere accesso (eccetto 'admin')

                            Console.WriteLine(new string('-', 35));
                            Color.Reset();
                            NewLine();
                            Console.WriteLine("1. Cassiere");
                            Console.WriteLine("2. Magazziniere");
                            Console.WriteLine("3. Amministratore");
                            Console.WriteLine("0. Esci");
                            Color.Magenta();
                            int inserimentoAdmin = InputManager.LeggiIntero("\nSeleziona la tua posizione > ", 0, 3);
                            Color.Reset();
                            Console.Clear();
                            switch (inserimentoAdmin) 
                            {
                                case 1: // MODALITA' CASSIERE

                                    bool continuaComeCassiere = true;
                                    if (!PermessiCassiere(dipendente))
                                    {
                                        Color.Red();
                                        Console.WriteLine("Non hai i permessi per accedere alle Casse\n");
                                        Color.Reset();
                                    }

                                    while (continuaComeCassiere && PermessiCassiere(dipendente)) // PROGRAMMA CASSIERE
                                    {
                                        repositoryProdotti.SalvaProdotti(prodotti);
                                        prodotti = repositoryProdotti.CaricaProdotti();
                                        listaPurchase = repostoryPurchase.CaricaPurchases();

                                        Color.Magenta();
                                        Console.WriteLine("AREA DIPENDENTI > CASSIERE");
                                        Console.WriteLine(new string('-', 35));
                                        NewLine();
                                        Color.Reset();

                                        Console.WriteLine("1. Visualizza Acquisti in attesa");
                                        Console.WriteLine("2. Processa Acquisti");
                                        Console.WriteLine("3. Ricarica credito cliente");
                                        Console.WriteLine("0. Indietro");

                                        Color.Magenta();
                                        string sceltaCassiere = InputManager.LeggiIntero("\n> ", 0, 3).ToString();
                                        Color.Reset();
                                        Console.Clear();

                                        switch (sceltaCassiere)
                                        {
                                            case "1": // MODALITA' CASSIERE > VISUALIZZA

                                                Color.Magenta();
                                                Console.WriteLine("ORDINI IN ATTESA:");
                                                NewLine();

                                                // visualizza tabella dei soli purchase che i clienti
                                                // hanno confermato. la tabella visualizza
                                                // ID-PURCHASE | NOME-CLIENTE | TOTALE-DOVUTO
                                                // dove il TOTALE è già al netto di sconto
                                                // se era presente una % di sconto
                                                // in caso di purchase non confermati dal cliente
                                                // non sarà processato niente

                                                bool acquistiVisualizzabili = false;
                                                foreach (var purchase in listaPurchase)
                                                {
                                                    if (purchase.Completed == false)
                                                    {
                                                        acquistiVisualizzabili = true;
                                                    }
                                                }

                                                if (acquistiVisualizzabili)
                                                {
                                                    StampaTabella.Purchase(listaPurchase);
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Color.Red();
                                                    Console.WriteLine("Nessun purchase da processare\n");
                                                }
                                                Color.Reset();
                                                break;

                                            case "2": // MODALITA' CASSIERE > PROCESSA ACQUISTO

                                                Color.Magenta();
                                                Console.WriteLine("MODALITA' CASSIERE > PROCESSA ACQUISTO\n");
                                                Color.Reset();

                                                // il cassiere ha la possibità di scegliere tramite ID-PURCHASE
                                                // in caso in cui l'ID inserito non è presente gli verrà comunicato
                                                // e dovrà ripetere l'operazione. se inserimento = 0, torna indietro
                                                // dopo la scelta del purchase da processare avviene
                                                // lo scalo e l'aggiornamento del credito del cliente
                                                // inizializzazione del carrello del cliente e del suo stato
                                                // l'aggiornamento del suo storico acquisti e di quello della cassa

                                                listaPurchase = repostoryPurchase.CaricaPurchases();
                                                Cassa cassaSelezionata = new Cassa();
                                                bool acquistiInAttesa = false;
                                                bool casseAperte = false;

                                                //stampa tabella purchase
                                                foreach (var purchase in listaPurchase)
                                                {
                                                    if (purchase.Completed == false)
                                                    {
                                                        acquistiInAttesa = true;
                                                    }
                                                }
                                                if (acquistiInAttesa)
                                                {
                                                    bool idNonTrovato = true;
                                                    int selezionaId = 0;
                                                    do
                                                    {
                                                        // acquisisci ID del prodotto da processare

                                                        StampaTabella.Purchase(listaPurchase);
                                                        Color.Green();
                                                        selezionaId = InputManager.LeggiIntero("\nInserisci l'ordine da processare > ", 0);
                                                        Console.Clear();
                                                        foreach (var purchase in listaPurchase)
                                                        {
                                                            if (purchase.IdPurchase == selezionaId && !purchase.Completed)
                                                            {
                                                                idNonTrovato = false;
                                                            }
                                                        }
                                                        if (idNonTrovato)
                                                        {
                                                            Color.Red();
                                                            Console.WriteLine("Inserire ID dall'elenco\n");
                                                            Color.Reset();
                                                        }
                                                    } while (idNonTrovato);

                                                    if (selezionaId != 0)
                                                    {
                                                        // per ogni singolo purchase nella lista purchase
                                                        foreach (var item in listaPurchase)
                                                        {
                                                            // se l'ID del singolo purchase è uguale a quello inserito
                                                            if (item.IdPurchase == selezionaId)
                                                            {
                                                                // dipendente deve selezionare una cassa aperta.
                                                                // se nessuna cassa è aperta, servirà un amministratore
                                                                // per crearne una

                                                                if (managerCasse.OttieniCasse().Count != 0)
                                                                {
                                                                    casseAperte = true;
                                                                    do
                                                                    {
                                                                        Color.Magenta();
                                                                        Console.WriteLine("VISUALIZZA CASSE \n");
                                                                        StampaTabella.VisualizzaCasse();
                                                                        Color.Reset();
                                                                        int selezioneCassa = InputManager.LeggiIntero("\nSeleziona la Cassa> ", 0);
                                                                        cassaSelezionata = repositoryCasse.CaricaCassaSingola(selezioneCassa);
                                                                    } while (cassaSelezionata == null);
                                                                }

                                                                Console.Clear();

                                                                if (casseAperte)
                                                                {
                                                                    Purchase tempPurchase = repostoryPurchase.CaricaPurchasesSingolo(selezionaId);
                                                                    cliente = clientiManager.CheckCliente(tempPurchase.NomeCliente);
                                                                    var prodottiTemp = cliente.Cart.Cart;
                                                                    StoricoAcquisti tempStoricoAcquisti = new StoricoAcquisti { MyPurchase = cliente.Cart.Cart, Data = item.Data, Totale = item.Totale };

                                                                    cassaSelezionata.Cassiere = dipendente;
                                                                    cassaSelezionata.Acquisti.Add(tempStoricoAcquisti);
                                                                    cassaSelezionata.Fatturato += carrelloManager.CalcolaTotale(cliente.Cart.Cart);
                                                                    cassaSelezionata.ScontrinoProcessato = managerCasse.GeneraScontrino(prodottiTemp, tempPurchase.Totale, cassaSelezionata.Id, tempPurchase.Data, tempPurchase.IdPurchase);
                                                                    cliente.StoricoAcquisti.Add(tempStoricoAcquisti);
                                                                    repositoryCasse.SalvaCassaSingola(cassaSelezionata);

                                                                    cliente.Credito -= carrelloManager.CalcolaTotale(cliente.Cart.Cart);
                                                                    cliente.Cart.Cart = new List<ProdottoCarrello>();
                                                                    cliente.Cart.Completed = false;
                                                                    repositoryClienti.SalvaClienti(cliente);

                                                                    tempPurchase.Completed = true;
                                                                    repostoryPurchase.SalvaPurchaseSingolo(tempPurchase);
                                                                    listaPurchase = repostoryPurchase.CaricaPurchases();
                                                                    Color.Green();
                                                                    Console.WriteLine("Acquisto andato a buon fine! Il cliente può ora ritirare lo scontrino!");
                                                                    Color.Reset();
                                                                    NewLine();
                                                                }
                                                                else
                                                                {
                                                                    Console.Clear();
                                                                    Color.Red();
                                                                    Console.WriteLine("Attendi che un amministratore attivi una cassa.\n");
                                                                    Color.Reset();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Color.Red();
                                                    Console.WriteLine("Nessun purchase da processare\n");
                                                }

                                                break;
                                            case "3": // MODALITA' CASSIERE > RICARICA CREDITO

                                                Color.Magenta();
                                                Console.WriteLine($"RICARICA CREDITO\n");
                                                Color.Reset();

                                                // vengono stampati i clienti in modalità speciale per il cassiere
                                                // affinché veda il credito residuo e possa selezionare tramite
                                                // ID il cliente da selezionare. selezionato il cliente
                                                // viene chiesto l'importo, che si sommerà al credito del cliente
                                                // per tornare indietro si preme senza eseguire operazioni si preme '0'

                                                clienti = repositoryClienti.CaricaClienti();
                                                StampaClienti.Ricarica(clienti);
                                                int idClienteDaRicaricare = 0;
                                                bool idDaRicaricareTrovato = false;

                                                NewLine();

                                                Color.Magenta();
                                                idClienteDaRicaricare = InputManager.LeggiIntero("\nPremi 0 per tornare indietro, oppure ID del cliente da ricaricare> ");
                                                Color.Reset();

                                                if (idClienteDaRicaricare != 0)
                                                {
                                                    foreach (var clientePerRicarica in clienti)
                                                    {
                                                        if (idClienteDaRicaricare == clientePerRicarica.Id)
                                                        {
                                                            idDaRicaricareTrovato = true;
                                                            Color.Green();
                                                            NewLine();
                                                            Console.Write($"{clientePerRicarica.Username}");
                                                            Color.Reset();
                                                            Console.Write(", il tuo credito attuale è di ");
                                                            Color.Green();
                                                            Console.Write($"€ {clientePerRicarica.Credito}");
                                                            NewLine();
                                                            decimal ricarica = InputManager.LeggiDecimale("Inserire importo da ricaricare: € ");
                                                            Console.Clear();
                                                            if (ricarica != 0)
                                                            {
                                                                Color.Green();
                                                                Console.WriteLine("OPERAZIONE ANDATA A BUON FINE!");
                                                                Color.Reset();
                                                                clientePerRicarica.Credito += ricarica;
                                                                Console.Write("\nIl tuo nuovo credito è di ");
                                                                Color.Green();
                                                                Console.Write($"{clientePerRicarica.Credito}!\n");
                                                                NewLine();
                                                                Console.WriteLine("Premi un tasto per continuare...");
                                                                Console.ReadKey();
                                                                Console.Clear();
                                                                repositoryClienti.SalvaClienti(clientePerRicarica);
                                                            }
                                                        }
                                                    }
                                                    
                                                    // in caso di ID errato viene comunicato che non esiste cliente con ID inserito
                                                    if (!idDaRicaricareTrovato)
                                                    {
                                                        Console.Clear();
                                                        Color.Red();
                                                        Console.WriteLine($"'Nessun cliente con ID: {idClienteDaRicaricare}'\n");
                                                        Color.Reset();
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                }
                                                break;

                                            case "0": // MODALITA' CASSIERE > ESCI

                                                // termina il PROGRAMMA CASSIERE
                                                continuaComeCassiere = false;
                                                break;

                                        }
                                    }
                                    break;

                                case 2: // MODALITA' MAGAZZINIERE
                                    bool continuaComeMagazziniere = true;
                                    if (!PermessiMagazziniere(dipendente))
                                    {
                                        Color.Red();
                                        Console.WriteLine("Non hai i permessi per accedere al Magazzino\n");
                                        Color.Reset();
                                    }

                                    while (continuaComeMagazziniere && PermessiMagazziniere(dipendente))
                                    {
                                        Color.Magenta();
                                        Console.WriteLine("MODALITA' MAGAZZINIERE");
                                        Console.WriteLine(new string('-', 30));
                                        NewLine();
                                        Color.Reset();

                                        // magazziniere (o admin) possono manipolare, creare ed eliminare 
                                        // prodotti e categorie

                                        repositoryProdotti.SalvaProdotti(prodotti);
                                        prodotti = repositoryProdotti.CaricaProdotti();

                                        Console.WriteLine("1. Visualizza Prodotto");
                                        Console.WriteLine("2. Aggiungi Prodotto");
                                        Console.WriteLine("3. Trova Prodotto per ID");
                                        Console.WriteLine("4. Modifica Prodotto");
                                        Console.WriteLine("5. Elimina Prodotto");
                                        Console.WriteLine("6. Gestione Categorie");
                                        Console.WriteLine("0. Indietro");

                                        Color.Magenta();
                                        string sceltaMagazziniere = InputManager.LeggiIntero("\n> ", 0, 6).ToString();
                                        Color.Reset();
                                        Console.Clear();
                                        switch (sceltaMagazziniere) // MENU MAGAZZINIERE
                                        {
                                            case "1": // MODALITA' MAGAZZINIERE > VISUALIZZA

                                                Color.Magenta();
                                                Console.WriteLine("PRODOTTI IN MAGAZZINO");

                                                // visualizzazione personalizzata
                                                // che informa delle informazioni complete sul prodotto
                                                // comprese [ID] e [GIACENZA]
                                                // in caso di assenza di prodotti viene comunicato

                                                NewLine();
                                                Color.Reset();

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

                                                Color.Magenta();
                                                Console.WriteLine("MODALITA' MAGAZZINIERE > AGGIUNGI PRODOTTO");
                                                Console.WriteLine(new string('-', 35));
                                                Color.Reset();
                                                NewLine();

                                                // permette di inserire i dati per l'aggiunta di un prodotto
                                                // le categorie sono prestabilite, caricate da /data/categorie
                                                // e selezionabili tramite ID per il completamento dell'inserimento.
                                                // se inserito un ID non esistente, verrà caricato il '10' 
                                                // che continene [SCONOSCIUTO]. Infine viene stampato
                                                // 'nome articolo' 

                                                Color.Green();
                                                string nome = InputManager.LeggiStringa("Nome > ");
                                                decimal prezzo = InputManager.LeggiDecimale("Prezzo > ", 0);
                                                prezzo = Math.Round(prezzo, 2);
                                                int giacenza = InputManager.LeggiIntero("Giacenza > ", 0);

                                                Categoria nuovaCategoria = new Categoria();

                                                NewLine();
                                                Console.WriteLine("Seleziona la categoria:");
                                                NewLine();

                                                // stampa liste categoria
                                                foreach (var categoria in listaCategorie)
                                                {
                                                    Console.WriteLine($"{categoria.ID}. {categoria.Name}");
                                                }

                                                NewLine();
                                                Color.Green();
                                                int sceltaCategoria = InputManager.LeggiIntero("> ", 0);
                                                Color.Reset();

                                                bool categoriaTrovata = false;
                                                foreach (var categoria in listaCategorie)
                                                {
                                                    if (sceltaCategoria == categoria.ID)
                                                    {
                                                        nuovaCategoria = categoria;
                                                        categoriaTrovata = true;
                                                    }
                                                }
                                                if (!categoriaTrovata)
                                                {
                                                    nuovaCategoria.ID = 10;
                                                }

                                                manager.AggiungiProdotto(new Prodotto
                                                {
                                                    Nome = nome,
                                                    Prezzo = prezzo,
                                                    Giacenza = giacenza,
                                                    Categoria = nuovaCategoria,
                                                });

                                                repositoryProdotti.SalvaProdotti(manager.OttieniProdotti());

                                                Console.Clear();
                                                Color.DarkGreen();
                                                Console.Write($"'{nome}' ");
                                                Color.Reset();
                                                Console.WriteLine("Aggiunto correttamente.\n");
                                                Color.Reset();
                                                break;

                                            case "3": // MODALITA' MAGAZZINIERE > TROVA PER ID

                                                Color.Magenta();
                                                Console.WriteLine("TROVA PRODOTTO PER ID\n");
                                                Color.Reset();

                                                // tramite inserimento dell'ID il magazziniere pul richiamare
                                                // la visualizzazione dei dati di quel prodotto, se trovato

                                                prodotti = repositoryProdotti.CaricaProdotti();
                                                
                                                Color.Green();
                                                int idProdotto = InputManager.LeggiIntero("ID > ", 0);
                                                Color.Reset();

                                                Prodotto prodottoTrovato = manager.TrovaProdotto(idProdotto);

                                                if (prodottoTrovato != null)
                                                {
                                                    //Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.Nome}");
                                                    NewLine();
                                                    Color.DarkGray();
                                                    Console.WriteLine($"{"ID",-10}{"Nome",-20}{"Prezzo",-10}{"Giacenza",-10}{"Categoria",-10}");
                                                    Console.WriteLine(new string('-', 65));
                                                    Color.Reset();

                                                    Console.WriteLine($"{prodottoTrovato.Id,-10}{prodottoTrovato.Nome,-20}{prodottoTrovato.Prezzo,-10:0.00}{prodottoTrovato.Giacenza,-10}{prodottoTrovato.Categoria.Name,-10}");
                                                    NewLine();
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                                                }
                                                break;

                                            case "4": // MODALITA' MAGAZZINIERE > MODIFICA PRODOTTO
                                                
                                                Color.Magenta();
                                                Console.WriteLine("INSERIRE ID DEL PRODOTTO DA MODIFICARE\n");
                                                Color.Reset();

                                                // dopo la visualizzazione personalizzata, il magazziniere può selezionare
                                                // tramite ID il prodotto da modificare, con la possibilità di scegliere
                                                // quali voci modificare. se il prodotto non viene trovato viene comunicato
                                                // premere '0' per tornare indietro senza eseguire operazioni

                                                prodotti = repositoryProdotti.CaricaProdotti();
                                                Prodotto prodottoAggiornato = new Prodotto();
                                                string nomeAggiornato;
                                                decimal prezzoAggiornato;
                                                int giacenzaAggiornata;

                                                StampaTabella.ComeAdmin(prodotti);
                                                Color.DarkGray();
                                                Console.WriteLine(new string('-', 65));

                                                Color.Magenta();
                                                int idProdottoDaAggiornare = InputManager.LeggiIntero("\n> ", 0);
                                                NewLine();
                                                Color.Reset();

                                                Prodotto prodottoTrovato2 = manager.TrovaProdotto(idProdottoDaAggiornare);
                                                nuovaCategoria = new Categoria();

                                                if (prodottoTrovato2 != null)
                                                {
                                                    Color.Green();
                                                    Console.WriteLine("AGGIORNA:");

                                                    bool aggiornaNome = InputManager.LeggiConferma("Nome");
                                                    if (aggiornaNome)
                                                    {
                                                        nomeAggiornato = InputManager.LeggiStringa("> ");
                                                    }
                                                    else
                                                    {
                                                        nomeAggiornato = prodottoTrovato2.Nome;
                                                    }
                                                    bool aggiornaPrezzo = InputManager.LeggiConferma("Prezzo");
                                                    if (aggiornaPrezzo)
                                                    {
                                                        prezzoAggiornato = InputManager.LeggiDecimale("> ", 0);
                                                        Math.Round(prezzoAggiornato, 2);
                                                    }
                                                    else
                                                    {
                                                        prezzoAggiornato = prodottoTrovato2.Prezzo;
                                                        Math.Round(prezzoAggiornato, 2);
                                                    }

                                                    bool aggiornaGiacenza = InputManager.LeggiConferma("Giacenza");
                                                    if (aggiornaGiacenza)
                                                    {
                                                        giacenzaAggiornata = InputManager.LeggiIntero("> ");
                                                    }
                                                    else
                                                    {
                                                        giacenzaAggiornata = prodottoTrovato2.Giacenza;
                                                    }
                                                    bool aggiornaCategoria = InputManager.LeggiConferma("Categoria?");
                                                    if (aggiornaCategoria)
                                                    {
                                                        NewLine();
                                                        Console.WriteLine("SELEZIONA:");
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
                                                    }
                                                    else
                                                    {
                                                        nuovaCategoria = prodottoTrovato2.Categoria;
                                                    }
                                                    prodottoAggiornato = new Prodotto
                                                    {
                                                        Nome = nomeAggiornato,
                                                        Prezzo = prezzoAggiornato,
                                                        Giacenza = giacenzaAggiornata,
                                                        Categoria = nuovaCategoria,
                                                    };
                                                    manager.AggiornaProdotto(idProdottoDaAggiornare, prodottoAggiornato);
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"\nProdotto non trovato per ID {idProdottoDaAggiornare}");
                                                }

                                                repositoryProdotti.SalvaProdotti(manager.OttieniProdotti());
                                                prodotti = repositoryProdotti.CaricaProdotti();

                                                Console.Clear();
                                                
                                                if (idProdottoDaAggiornare != 0)
                                                {
                                                    Color.Green();
                                                    Console.Write($"'{prodottoAggiornato.Nome}' ");
                                                    Color.Reset();
                                                    Console.Write("aggiornato correttamente!\n");
                                                    NewLine();
                                                }
                                                break;

                                            case "5": // MODALITA' MAGAZZINIERE > ELIMINA PRODOTTO

                                                Color.Red();
                                                Console.WriteLine("INSERIRE ID DEL PRODOTTO DA ELIMINARE\n");
                                                Color.Reset();

                                                // in seguito alla stampa personalizzata, il magazziniere può
                                                // selezionare tramite ID il prodotto da eliminare

                                                prodotti = repositoryProdotti.CaricaProdotti();
                                                Prodotto prodottoDaEliminareTemp = new Prodotto();

                                                StampaTabella.ComeAdmin(prodotti);
                                                
                                                Color.Red();
                                                int idProdottoDaEliminare = InputManager.LeggiIntero("\n> ", 0);
                                                Color.Reset();
                                                prodottoDaEliminareTemp = manager.TrovaProdotto(idProdottoDaEliminare);
                                                manager.EliminaProdotto(idProdottoDaEliminare);
                                                repositoryProdotti.SalvaProdotti(manager.OttieniProdotti());
                                                prodotti = repositoryProdotti.CaricaProdotti();
                                                Console.Clear();

                                                Color.Red();
                                                Console.Write($"'{prodottoDaEliminareTemp.Nome}' ");
                                                Color.Reset();
                                                Console.Write("eliminato correttamente\n");
                                                NewLine();
                                                break;

                                            case "6": // MODALITA' MAGAZZINIERE > GESTIONE CATEGORIE CATEGORIE

                                                bool continuaInCategorie = true;
                                                while (continuaInCategorie) // PROGRAMMA CATEGORIE
                                                {
                                                    Color.Magenta();
                                                    Console.WriteLine("GESTISCI LE CATEGORIE\n");
                                                    Color.Reset();

                                                    // operazioni CRUD per le categorie, aggiornate in tempo reale in data/categorie

                                                    Console.WriteLine("1. Nuova Categoria");
                                                    Console.WriteLine("2. Modifica Categoria");
                                                    Console.WriteLine("3. Elimina Categoria");
                                                    Console.WriteLine("4. Visualizza Categorie");
                                                    Console.WriteLine("0. Indietro");
                                                    Color.Magenta();
                                                    int sceltaCategorie = InputManager.LeggiIntero("\n> ", 0, 4);
                                                    Color.Reset();
                                                    Console.Clear();
                                                    switch (sceltaCategorie)
                                                    {
                                                        case 1: // NUOVA CATEGORIA

                                                            Color.Magenta();
                                                            Console.WriteLine("NUOVA CATEGORIA \n");
                                                            Color.Green();

                                                            string nomeNuovaCategoria = InputManager.LeggiStringa("\nNuova categoria: ");
                                                            managerCategorie.AggiungiCategoria(new Categoria
                                                            {
                                                                Name = nomeNuovaCategoria,
                                                            });

                                                            repositoryCategorie.SalvaCategorie(listaCategorie);

                                                            Console.Clear();
                                                            Color.Green();
                                                            Console.Write($"'{nomeNuovaCategoria}' ");
                                                            Color.Reset();

                                                            Console.Write("inserita tra le categorie.\n");
                                                            NewLine();
                                                            break;

                                                        case 2: // MODIFICA CATEGORIA TRAMITE ID

                                                            Color.Green();
                                                            Console.WriteLine("MODIFICA CATEGORIA TRAMITE ID\n");

                                                            // stampa delle categorie e acquisizione dell'ID
                                                            // scelto per la modifica. In caso di mancata corrispondenza
                                                            // viene comunicato e nessuna operazione verrà eseguita

                                                            string nomeCategoriaDaModificare;
                                                            bool trovato = false;

                                                            StampaTabella.Categorie(listaCategorie);
                                                            Color.Green();
                                                            int idCategoriaDaModificare = InputManager.LeggiIntero("> ", 0);
                                                            NewLine();

                                                            foreach (var categoria in listaCategorie)
                                                            {
                                                                if (categoria.ID == idCategoriaDaModificare)
                                                                {
                                                                    Color.Red();
                                                                    Console.Write($"Aggiorna da {categoria.Name} a ");
                                                                    Color.Green();
                                                                    nomeCategoriaDaModificare = InputManager.LeggiStringa("");

                                                                    managerCategorie.AggiornaCategoria(idCategoriaDaModificare, new Categoria { Name = nomeCategoriaDaModificare, });
                                                                    repositoryCategorie.SalvaCategorie(listaCategorie);

                                                                    trovato = true;
                                                                    Console.Clear();

                                                                    Console.Write($"'{nomeCategoriaDaModificare}'");
                                                                    Color.Reset();
                                                                    Console.Write($", categoria aggiornata correttamente\n");
                                                                    NewLine();
                                                                }
                                                            }
                                                            if (!trovato)
                                                            {
                                                                Color.Red();
                                                                Console.WriteLine($"Nessuna categoria trovata per ID:{idCategoriaDaModificare}");
                                                            }
                                                            break;

                                                        case 3: // ELIMINA CATEGORIA TRAMITE ID

                                                            Color.Green();
                                                            Console.WriteLine("ELIMINA CATEGORIA TRAMITE ID\n");
                                                            Color.Reset();

                                                            StampaTabella.Categorie(listaCategorie);

                                                            Color.Red();
                                                            int idCategoriaDaEliminare = InputManager.LeggiIntero("Inserisci ID categoria da eliminare> ", 0);
                                                            Color.Reset();

                                                            managerCategorie.EliminaCategoria(idCategoriaDaEliminare);
                                                            repositoryCategorie.SalvaCategorie(listaCategorie);

                                                            Console.Clear();
                                                            StampaTabella.Categorie(listaCategorie);
                                                            break;

                                                        case 4: // TUTTE LE CATEGORIE

                                                            Color.Magenta();
                                                            Console.WriteLine("TUTTE LE CATEGORIE\n");
                                                            Color.Reset();

                                                            // stampa tutte le categorie presenti in data/categorie
                                                            StampaTabella.Categorie(listaCategorie);
                                                            break;

                                                        case 0: // ESCI

                                                            // TERMINA PROGRAMMA CATEGORIE
                                                            continuaInCategorie = false;
                                                            break;

                                                    }
                                                }
                                                break;

                                            case "0": // ESCI

                                                // TERMINA PROGRAMMA MAGAZZINIERE
                                                continuaComeMagazziniere = false;
                                                break;

                                            default:
                                                Console.WriteLine("INSERIMENTO MENU NON VALIDO\n");
                                                break;
                                        }
                                    }
                                    break;

                                case 3: // MODALITA' AMMINISTRATORE

                                    bool continuaComeAmministratore = true;
                                    if (!PermessiAmministratore(dipendente))
                                    {
                                        Color.Red();
                                        Console.WriteLine("Non hai i permessi dell'Amministratore\n");
                                        Color.Reset();
                                    }

                                    while (continuaComeAmministratore && PermessiAmministratore(dipendente)) // PROGRAMMA AMMINISTRATORE
                                    {
                                        Color.Magenta();
                                        Console.WriteLine("MODALITA' AMMINISTRATORE");
                                        Console.WriteLine(new string('-', 48));
                                        NewLine();
                                        Color.Reset();

                                        // amministratore gestisce i dipendenti
                                        // gestisce le casse ed il fatturato di ogni singola cassa
                                        // calcola il fatturato totale, le spese di ogni cliente
                                        // e la data del loro ultimo acquisto

                                        repositoryProdotti.SalvaProdotti(prodotti);
                                        prodotti = repositoryProdotti.CaricaProdotti();

                                        Console.WriteLine("1. Visualizza Dipendenti");
                                        Console.WriteLine("2. Aggiungi Dipendente");
                                        Console.WriteLine("3. Elimina Dipendente");
                                        Console.WriteLine("4. Aggiorna Dipendente");
                                        Console.WriteLine("5. Calcola Fatturato");
                                        Console.WriteLine("6. Visualizza Clienti");
                                        Console.WriteLine("7. Gestione Casse");
                                        Console.WriteLine("0. Indietro");

                                        Color.Magenta();
                                        string sceltaAmministratore = InputManager.LeggiIntero("\n> ", 0, 7).ToString();
                                        Color.Reset();
                                        Console.Clear();

                                        switch (sceltaAmministratore) // MENU AMMINISTRATORE
                                        {
                                            case "1": // MODALITA' AMMINISTRATORE > VISUALIZZA DIPENDENTI

                                                Color.Magenta();
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > VISUALIZZA DIPENDENTI");
                                                NewLine();
                                                Color.Reset();

                                                // visualizzazione personalizzata dei dipendenti
                                                // con ID | USERNAME | RUOLO

                                                StampaDipendenti.Tabella(dipendenti);
                                                NewLine();
                                                break;

                                            case "2": // MODALITA' AMMINISTRATORE > AGGIUNGI DIPENDENTE

                                                Color.Magenta();
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > AGGIUNGI DIPENDENTE");
                                                Console.WriteLine(new string('-', 48));
                                                NewLine();
                                                Color.Reset();

                                                // crea nuovi dipendenti e seleziona il ruolo da una lista prestabilita
                                                // per evitare errori di battitura durante l'inserimento
                                                // infine attraverso una stampa personaizzata visualizza singolarmente
                                                // il nuovo dipendente aggiunto

                                                Dipendente nuovoDipendente = new Dipendente();

                                                Color.Green();
                                                string username = InputManager.LeggiStringa("Username del nuovo dipendente: ");
                                                Console.WriteLine("Ruolo del nuovo dipendente:");
                                                Color.Reset();

                                                Console.WriteLine("\n1. Cassiere\n2. Magazziniere\n3. Amministratore");
                                                string ruolo = "";

                                                Color.DarkGreen();
                                                int selezionaRuolo = InputManager.LeggiIntero("\n> ", 1, 3);

                                                switch (selezionaRuolo)
                                                {
                                                    case 1:
                                                        ruolo = "Cassiere";
                                                        break;
                                                    case 2:
                                                        ruolo = "Magazziniere";
                                                        break;
                                                    case 3:
                                                        ruolo = "Amministratore";
                                                        break;
                                                }

                                                Dipendente tempDipendente = new Dipendente
                                                {
                                                    Username = username,
                                                    Ruolo = ruolo,
                                                };

                                                managerDipendenti.AggiungiDipendente(tempDipendente);
                                                repositoryDipendenti.SalvaDipendenti(dipendenti);
                
                                        
                                                Console.Clear();
                                                Color.Green();
                                                Console.WriteLine("Nuovo dipendente aggiunto\n");
                                                Color.Reset();

                                                StampaDipendenti.Singolo(tempDipendente);
                                                NewLine();
                                                break;

                                            case "3": // MODALITA' AMMINISTRATORE > ELIMINA DIPENDENTE

                                                Color.Magenta();
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > ELIMINA DIPENDENTE");
                                                Console.WriteLine(new string('-', 48));
                                                NewLine();
                                                Color.Reset();

                                                // stampa personalizzata di tutti i dipendenti
                                                // inserimento id del dipendente da eliminare
                                                // conferma operazione completata e visualizzazione 
                                                // dei dati del singolo dipendente
                                            
                                                StampaDipendenti.Tabella(dipendenti);

                                                Color.Red();
                                                int idPerElimina = InputManager.LeggiIntero("\nInserisci ID del dipendente da eliminare > ");
                                                Color.Reset();

                                                Dipendente dipendenteEliminato = managerDipendenti.TrovaDipendentePerId(idPerElimina);
                                                managerDipendenti.EliminaDipendente(idPerElimina);
                                                repositoryDipendenti.SalvaDipendenti(dipendenti);
                                                Console.Clear();

                                                Color.Red();
                                                Console.WriteLine("Dipendente eliminato\n");
                                                Color.Reset();

                                                StampaDipendenti.Singolo(dipendenteEliminato);
                                                NewLine();
                                                break;

                                            case "4": // MODALITA' AMMINISTRATORE > AGGIORNA DIPENDENTE

                                                Color.Magenta();
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > AGGIORNA DIPENDENTE");
                                                NewLine();
                                                Color.Reset();

                                                // stampa personalizzata di tutti i dipendenti
                                                // inserimento id del dipendente da aggiornare
                                                // conferma aggiornamento tramite visualizzazione 
                                                // dei dati del singolo dipendente 

                                                StampaDipendenti.Tabella(dipendenti);

                                                Color.DarkYellow();
                                                int idPerAggiorna = InputManager.LeggiIntero("\nInserisci ID Cliente da aggiornare > ", 0);
                                                Color.Reset();

                                                Dipendente dipendenteDaAggiornare = managerDipendenti.TrovaDipendentePerId(idPerAggiorna);
                                                managerDipendenti.AggiornaDipendente(idPerAggiorna);
                                                repositoryDipendenti.SalvaDipendenti(dipendenti);
                                                Console.Clear();

                                                Color.Green();
                                                Console.WriteLine("Dipendente Aggiornato\n");
                                                Color.Reset();

                                                StampaDipendenti.Singolo(dipendenteDaAggiornare);
                                                NewLine();
                                                break;

                                            case "5": // MODALITA' AMMINISTRATORE > CALCOLA FATTURATO

                                                Color.Magenta();
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > CALCOLA FATTURATO");
                                                NewLine();
                                                Color.Reset();

                                                // prendendo i dati da data/purchase, calcola, visualizza e stampa
                                                // le diverse operazioni e il fatturato raggiunto
                                                // in seguito alla visualizzazione, premere un qualsiasi tasto per 
                                                // tornare al menu

                                                listaPurchase = repostoryPurchase.CaricaPurchases();

                                                decimal totaleFatturato = 0;
                                                Color.DarkGray();
                                                Console.WriteLine($"{"PURCHASE",-15}{"CLIENTE",-15}{"SPESA",-15}{"DATA",-25}{"STATO",-15}");
                                                NewLine();
                                                Color.Reset();

                                                foreach (var purchase in listaPurchase)
                                                {
                                                    if (purchase.Completed)
                                                    {
                                                        Console.WriteLine($"{purchase.IdPurchase,-15}{purchase.NomeCliente,-15}{purchase.Totale.ToString("F2"),-15}{purchase.Data,-25}{purchase.Completed,-15}");
                                                        totaleFatturato += purchase.Totale;
                                                    }
                                                }

                                                NewLine();
                                                Color.DarkGray();
                                                Console.WriteLine(new string('-', 76));
                                                NewLine();

                                                Color.Reset();
                                                Console.Write($"{"TOTALE FATTURATO:",-20}");
                                                Color.Green();
                                                Console.Write($"{totaleFatturato.ToString("F2")}");
                                                Color.Reset();

                                                NewLine();
                                                NewLine();
                                                Color.Magenta();
                                                Console.WriteLine("Premi un tasto per tornare al menu...");
                                                Color.Reset();
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;

                                            case "6": // MODALITA' AMMINISTRATORE > VISUALIZZA CLIENTI

                                                Color.Magenta();
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > VISUALIZZA CLIENTI");
                                                NewLine();
                                                Color.Reset();

                                                // visualizzazione dei clienti
                                                // ID | NOME | TOTALE COMPLESSIVO SPESO | DATA ULTIMO ACQUISTO

                                                clienti = repositoryClienti.CaricaClienti();
                                                StampaClienti.Tabella(clienti);
                                                NewLine();
                                                break;

                                            case "7": // MODALITA' AMMINISTRATORE > GESTIONE CASSE

                                                bool continuaInGestioneCasse = true;
                                                while (continuaInGestioneCasse) // PROGRAMMA GESTIONE CASSE
                                                {
                                                    Color.Magenta();
                                                    Console.WriteLine("GESTIONE CASSE\n");
                                                    Color.Reset();

                                                    // operazioni CRUD semplificate per gestione
                                                    // e monitoraggio dei fatturati delle casse

                                                    Console.WriteLine("1. Nuova Cassa");
                                                    Console.WriteLine("2. Elimina Cassa");
                                                    Console.WriteLine("3. Visualizza Casse");
                                                    Console.WriteLine("0. Indietro");

                                                    Color.Magenta();
                                                    int sceltaGestioneCasse = InputManager.LeggiIntero("\n> ", 0, 3);
                                                    Color.Reset();
                                                    Console.Clear();

                                                    switch (sceltaGestioneCasse) // PROGRAMMA GESTIONE CASSE
                                                    {
                                                        case 1: // NUOVA CASSA

                                                            Color.Magenta();
                                                            Console.WriteLine("NUOVA CASSA \n");
                                                            Color.Green();

                                                            // crea una nuova cassa o torna indietro

                                                            bool confermaCreazioneCassa = InputManager.LeggiConferma("Creare una nuova cassa?");
                                                            if (confermaCreazioneCassa)
                                                            {
                                                                Cassa nuovaCassa = managerCasse.CreaNuovaCassa(new Cassa());
                                                                repositoryCasse.SalvaCassaSingola(nuovaCassa);
                                                                listaCasse = repositoryCasse.CaricaCasse();
                                                                Console.Clear();

                                                                Color.Reset();
                                                                Console.Write("La Cassa 'Numero ");
                                                                Color.Green();
                                                                Console.Write($"{nuovaCassa.Id} ");
                                                                Color.Reset();
                                                                Console.Write("e' stata aggiunta correttamente!\n");
                                                                NewLine();
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                            }
                                                            break;

                                                        case 2: // ELIMINA CASSA TRAMITE ID

                                                            Color.Green();
                                                            Console.WriteLine("ELIMINA CASSA TRAMITE ID\n");

                                                            // visualizza casse e seleziona tramite ID quale eliminare
                                                            // un messaggio conferma la riuscita o meno dell'operazione

                                                            StampaTabella.VisualizzaCasse();

                                                            Color.Green();
                                                            int idCassaDaEliminare = InputManager.LeggiIntero("> ", 0);
                                                            NewLine();

                                                            bool cassaEliminata = managerCasse.EliminaCassaPerId(idCassaDaEliminare);
                                                            if (cassaEliminata)
                                                            {
                                                                Color.Green();
                                                                Console.WriteLine($"La cassa Numero {idCassaDaEliminare} è stata eliminata correttamente!");
                                                                Color.Reset();
                                                            }
                                                            break;

                                                        case 3: // VISUALIZZA CASSE

                                                            Color.Magenta();
                                                            Console.WriteLine("VISUALIZZA CASSE \n");
                                                            StampaTabella.VisualizzaCasse();
                                                            Color.Reset();
                                                            break;
                                                        
                                                        case 0: // ESCI

                                                            // TERMINA PROGRAMMA GESTIONE CASSE
                                                            continuaInGestioneCasse = false;
                                                            break;
                                                    }
                                                }
                                                break;

                                            case "0": // ESCI

                                                // TERMINA PROGRAMMA AMMINISTRATORE
                                                continuaComeAmministratore = false;
                                                break;
                                        }
                                    }
                                    break;
                                case 0: // ESCI

                                    // esce dalla modalità dipententi, ma non termina il programma
                                    // a meno che non venga specificato tramite conferma

                                    Color.Red();
                                    continua = !InputManager.LeggiConferma("Terminare l'applicazione?");
                                    Color.Reset();
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
                            // in caso lo Username inserito tentando di entrare 
                            // nella modalità dipendenti non sia presente
                            Color.Red();
                            Console.WriteLine("ACCESSO NEGATO\n");
                            Color.Reset();
                            continuaComeDipendente = false;
                        }
                    }
                    break;
            }
            continuaComeDipendente = true;
        } 
    } // TERMINA PROGRAMMA

    #region PERMESSI

    // funzioni per la gestione dei permessi
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

    // funzione di servizio
    static void NewLine()
    {
        Console.WriteLine();
    }
}
