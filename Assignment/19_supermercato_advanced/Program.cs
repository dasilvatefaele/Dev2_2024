using System.Diagnostics;
using System.Diagnostics.Tracing;
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
        CategorieRepository repositoryCategorie = new CategorieRepository();

        List<Prodotto> prodotti = repositoryProdotti.CaricaProdotti();
        List<Prodotto> carrello = repositoryCarrello.CaricaProdotti();
        List<Dipendente> dipendenti = repositoryDipendenti.CaricaDipendenti();
        List<Cliente> clienti = repositoryClienti.CaricaClienti();
        List<Categoria> listaCategorie = repositoryCategorie.CaricaCategorie();
        Cliente cliente = new Cliente();

        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);
        CarrelloAdvancedManager carrelloManager = new CarrelloAdvancedManager(carrello);
        DipendentiManager managerDipendenti = new DipendentiManager(dipendenti);
        ClientiManager clientiManager = new ClientiManager(clienti);
        CategoriaManager managerCategorie = new CategoriaManager(listaCategorie);




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
                        Console.WriteLine("4. Il tuo carrello");
                        Console.WriteLine("5. Procedi al pagamento"); // cambia stato dell'ordine
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
                            case "4": // VISUALIZZA CARRELLO

                                StampaTabella.Carrello(cliente.Carrello);
                                // stampo il carrello (Qnt. |  Nome | Prezzo)
                                Console.WriteLine();
                                // spazio

                                break;
                            case "5": // todo procedi al pagamento 
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
                case false:

                    Console.WriteLine("Accedi come dipendente.");

                    string usernameAccesso = InputManager.LeggiStringa("Inserisci il tuo Username > ");
                    var dipendente = managerDipendenti.AccediComeDipendente(usernameAccesso);
                    Console.Clear();

                    // AREA DIPENDENTI
                    while (continuaComeDipendente)                               // SCELTA RUOLO
                    {
                        repositoryProdotti.SalvaProdotti(prodotti);
                        prodotti = repositoryProdotti.CaricaProdotti();

                        if (dipendente != null)
                        {
                            Console.WriteLine("MODALITA' ADMIN\n");
                            Console.WriteLine("1. Cassiere");
                            Console.WriteLine("2. Magazziniere");
                            Console.WriteLine("3. Amministratore");
                            Console.WriteLine("0. Esci");
                            int inserimentoAdmin = InputManager.LeggiIntero("\nSeleziona la tua posizione > ", 0, 3);
                            Console.Clear();
                            switch (inserimentoAdmin)                               //
                            {
                                case 1: // todo MODALITA' CASSIERE
                                    bool continuaComeCassiere = true;
                                    if (!PermessiCassiere(dipendente))
                                    {
                                        Console.WriteLine("Non hai i diritti per accedere al terminale del Cassiere\n");
                                    }

                                    while (continuaComeCassiere && PermessiCassiere(dipendente))
                                    {
                                        Console.WriteLine("Sei entrato nel menu del cassiere. Lavori in corso, premi un tasto per uscire...");
                                        Console.ReadKey();
                                        continuaComeCassiere = false;
                                    }

                                    break;
                                case 2: // MODALITA' MAGAZZINIERE   //* OK
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
                                            case "1": // VISUALIZZA
                                                prodotti = repositoryProdotti.CaricaProdotti();
                                                Console.WriteLine("MODALITA' MAGAZZINIERE > VISUALIZZA\n");
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
                                            case "3": // TROVA PER ID
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
                                            case "4": // MODIFICA
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
                                                break;
                                            case "5": // ELIMINA
                                                Console.WriteLine("MODALITA' MAGAZZINIERE > ELIMINA PRODOTTO\n");
                                                StampaTabella.ComeAdmin(prodotti);
                                                //Console.Write("ID > ");
                                                // int idProdottoDaEliminare = int.Parse(Console.ReadLine());
                                                int idProdottoDaEliminare = InputManager.LeggiIntero("ID > ", 0);
                                                manager.EliminaProdotto(idProdottoDaEliminare);
                                                repositoryProdotti.SalvaProdotti(manager.OttieniProdotti());
                                                break;
                                            case "6": // GESTIONE CATEGORIE
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
                                        Console.WriteLine("0. Indietro");

                                        string sceltaAmministratore = InputManager.LeggiIntero("\n> ", 0, 4).ToString();
                                        Console.Clear();

                                        switch (sceltaAmministratore) // MENU AMMINISTRATORE
                                        {
                                            case "1": // VISUALIZZA
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > VISUALIZZA DIPENDENTI\n");
                                                StampaDipendenti.Tabella(dipendenti);
                                                Console.WriteLine();
                                                //Console.WriteLine("Visualizzazione ancora non disponibile");
                                                break;
                                            case "2": // AGGIUNGI
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > AGGIUNGI DIPENDENTE\n");
                                                Dipendente nuovoDipendente = new Dipendente();
                                                string username = InputManager.LeggiStringa("Username del nuovo dipendente: ");
                                                string ruolo = InputManager.LeggiStringa("Ruolo: ");
                                                managerDipendenti.AggiungiDipendente(new Dipendente { Username = username, Ruolo = ruolo });
                                                repositoryDipendenti.SalvaDipendenti(dipendenti);
                                                break;
                                            case "3": // ELIMINA
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > ELIMINA DIPENDENTE\n");
                                                StampaDipendenti.Tabella(dipendenti);
                                                int idPerElimina = InputManager.LeggiIntero("\nInserisci ID del dipendente da eliminare > ");
                                                managerDipendenti.EliminaDipendente(idPerElimina);
                                                repositoryDipendenti.SalvaDipendenti(dipendenti);
                                                Console.Clear();
                                                StampaDipendenti.Tabella(dipendenti);
                                                Console.WriteLine();

                                                break;
                                            case "4": // AGGIORNA
                                                Console.WriteLine("MODALITA' AMMINISTRATORE > AGGIORNA DIPENDENTE\n");
                                                StampaDipendenti.Tabella(dipendenti);
                                                int idPerAggiorna = InputManager.LeggiIntero("\nInserisci ID Cliente da aggiornare > ", 0);
                                                managerDipendenti.AggiornaDipendente(idPerAggiorna);
                                                repositoryDipendenti.SalvaDipendenti(dipendenti);
                                                Console.Clear();
                                                StampaDipendenti.Tabella(dipendenti);
                                                Console.WriteLine();

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



}

