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

        ProdottoRepository repository = new ProdottoRepository();
        ClienteRepository clienteRepo= new ClienteRepository();

        List<ProdottoAdvanced> prodotti =  repository.CaricaProdotti();
        List<ProdottoAdvanced> carrello =  clienteRepo.CaricaProdotti();

        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);
        CarrelloAdvancedManager carrelloManager = new CarrelloAdvancedManager(carrello);

        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Visualizza prodotti");
            Console.WriteLine("2. Aggiungi al prodotti");
            //Console.WriteLine("3. Rimuovi dal prodotti");
            //Console.WriteLine("4. Modifica prodotti");
            Console.WriteLine("5. Il tuo carrello");
            //Console.WriteLine("6. Procedi al pagamento"); // cambia stato dell'ordine
            Console.WriteLine("0. Esci"); // cambia stato dell'ordine
            // Console.Write("> ");
            // string scelta = Console.ReadLine();
            string scelta = InputManager.LeggiIntero("> ", 0, 5).ToString();
            Console.Clear();

            switch (scelta)
            {
                case "1": // Visualizza prodotti DEL SUPERMERCATO //* DONE
                    Console.WriteLine("\nPRODOTTI DEL SUPERMERCATO:");
                    if (prodotti != null)
                    {
                        StampaTabella.ComeCliente(prodotti);                    
                    }
                    else
                    {
                        Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                    }
                break;
                case "2": // Aggiung al prodotti 
                    StampaTabella.ComeCliente(prodotti);
                    string nomeProdotto = InputManager.LeggiStringa("Inserisci il prodotto > ");
                    carrelloManager.AggiungiProdotto(nomeProdotto, carrello);
                    //repository.SalvaProdotti(prodotti);                   
                break;
                case "3": // Rimuovi dal prodotti
                    prodotti = repository.CaricaProdotti();
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
                        manager.AggiornaProdotto(idProdottoDaAggiornare, new ProdottoAdvanced {NomeProdotto = nomeAggiornato, PrezzoProdotto = prezzoAggiornato, GiacenzaProdotto = giacenzaAggiornata});
                    }
                    else
                    {
                        Console.WriteLine($"\nProdotto non trovato per ID {idProdottoDaAggiornare}");
                    }
                break;
                case "5": // Visualizza IL TUO CARRELLO //* DONE
                    StampaTabella.ComeCliente(carrello);
                break;
                case "6": // procedi al pagamento
                break;
                case "0": // Esci //* DONE
                    continua = false;
                    repository.SalvaProdotti(manager.OttieniProdotti());
                    Console.WriteLine("Arrivederci!\n");
                break;
                default:  // Questo messaggio non dovrebbe apparire mai
                    Console.WriteLine("INSERIMENTO MENU NON VALIDO\n");
                    // dato che c'è il controllo di acquisizione nella scelta
                    // questo messaggio non dovrebbe apparire mai
                break;
            }
        }
    }
}


public class Cliente 
{
    private int id;
    public int Id { get; set;}

    private string username;
    public string Username { get; set;}

    private List<ProdottoAdvanced> carrello;
    public List<ProdottoAdvanced> Carrello { get; set;}

    private List<ProdottoAdvanced> storicoAcquisti;
    public List<ProdottoAdvanced> StoricoAcquisti { get; set;}

    private int percentualeSconto;
    public int PercentualeSconto { get; set;}
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