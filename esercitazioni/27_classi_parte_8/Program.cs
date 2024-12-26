using System.Runtime.CompilerServices;
using Newtonsoft.Json;
// dipendenze:
// dotnet add package Newtonsoft.Json
#region MAIN
class Program // <--- (standard/default)
{
    static void Main(string[] args) // <--- Entry point (standard/default)
    {
        Console.Clear();
        ProdottoRepository repository = new ProdottoRepository();
        List<ProdottoAdvanced> prodotti =  repository.CaricaProdotti();
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);

        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Visualizza");
            Console.WriteLine("2. Aggiungi");
            Console.WriteLine("3. Trova per ID");
            Console.WriteLine("4. Aggiorna");
            Console.WriteLine("5. Elimina");
            Console.WriteLine("0. Esci");
            // Console.Write("> ");
            // string scelta = Console.ReadLine();
            string scelta = InputManager.LeggiIntero("> ", 0, 5).ToString();
            Console.Clear();

            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nProdotti:");
                    if (prodotti != null)
                    {
                        StampaTabella.ComeAdmin(prodotti);                    
                    }
                    else
                    {
                        Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                    }
                break;
                case "2":
                    string nome = InputManager.LeggiStringa("Nome > ");
                    decimal prezzo = InputManager.LeggiDecimale("Prezzo > ");
                    int giacenza = InputManager.LeggiIntero("Giacenza > ", 0);
                    //Console.Write("Nome > ");
                    // Console.Write("Prezzo > ");
                    //Console.Write("Giacenza > ");
                    manager.AggiungiProdotto(new ProdottoAdvanced {NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza});
                    repository.SalvaProdotti(prodotti);                   
                break;
                case "3":
                    prodotti = repository.CaricaProdotti();
                    // Console.Write("ID > ");
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
                case "4":
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
                case "5":
                    StampaTabella.ComeAdmin(prodotti);
                    //Console.Write("ID > ");
                    // int idProdottoDaEliminare = int.Parse(Console.ReadLine());
                    int idProdottoDaEliminare = InputManager.LeggiIntero("ID > ", 0);
                    manager.EliminaProdotto(idProdottoDaEliminare);
                break;
                case "0":
                    continua = false;
                    repository.SalvaProdotti(manager.OttieniProdotti());
                    Console.WriteLine("Arrivederci!\n");
                break;
                default:
                    Console.WriteLine("INSERIMENTO MENU NON VALIDO\n");
                    // dato che c'è il controllo di acquisizione nella scelta
                    // questo messaggio non dovrebbe apparire mai
                break;
            }
        }
    }
}
#endregion

// La gestione dei file json è più sicura se il path è privato
// dunque ogni file json avrà la propria Class Repository per salvare e caricare
// la cosa più furba è mantenere i vari blocchi modulari (riutilizzabili)
// piuttosto che fare una classe che fa più cose