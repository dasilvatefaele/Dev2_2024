using System.Runtime.CompilerServices;
using Newtonsoft.Json;

class Program // <--- (standard/default)
{
    static void Main(string[] args) // <--- Entry point (standard/default)
    {
        ProdottoRepository repository = new ProdottoRepository();
        List<ProdottoAdvanced> prodotti =  repository.CaricaProdotti();
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);
        //ProdottoAdvancedManager manager = new ProdottoAdvancedManager();

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
            Console.Write("> ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nProdotti:");
                    if (prodotti != null)
                    //if (manager.OttieniProdotti()!= null)
                    {
                        foreach(var prodotto in prodotti)
                        //foreach(var prodotto in manager.OttieniProdotti())
                        {
                            if (prodotto.Active == true)
                            {
                                Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNon c'è ancora nessun prodotto.\n");
                    }
                break;
                case "2":
                    // Console.Write("ID > ");
                    // int id = int.Parse(Console.ReadLine());
                    Console.Write("Nome > ");
                    string nome ="";
                    nome = Console.ReadLine();
                    Console.Write("Prezzo > ");
                    decimal prezzo = decimal.Parse(Console.ReadLine());
                    Console.Write("Giacenza > ");
                    int giacenza = int.Parse(Console.ReadLine());

                    manager.AggiungiProdotto(new ProdottoAdvanced {Id = manager.GetLastId(prodotti)+1, NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza});
                    // repository.SalvaProdotti();
                break;
                case "3":
                    Console.Write("ID > ");
                    int idProdotto = int.Parse(Console.ReadLine());
                    ProdottoAdvanced prodottoTrovato = manager.TrovaProdotto(idProdotto);

                    if (prodottoTrovato != null && prodottoTrovato.Active == true)
                    {
                        Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.NomeProdotto}");
                    }
                    else
                    {
                        Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                    }
                break;
                case "4":
                    Console.Write("ID da aggiornare> ");
                    int idProdottoDaAggiornare = int.Parse(Console.ReadLine());
                    ProdottoAdvanced prodottoTrovato2 = manager.TrovaProdotto(idProdottoDaAggiornare);
                    if (prodottoTrovato2 != null && prodottoTrovato2.Active == true)
                    {
                        int idBackup = prodottoTrovato2.Id;
                        manager.EliminaProdotto(idBackup);
                        Console.Write("Nome > ");
                        string nomeAggiornato = Console.ReadLine();
                        Console.Write("Prezzo > ");
                        decimal prezzoAggiornato = decimal.Parse(Console.ReadLine());
                        Console.Write("Giacenza > ");
                        int giacenzaAggiornata = int.Parse(Console.ReadLine());
                        manager.AggiungiProdotto(new ProdottoAdvanced {NomeProdotto = nomeAggiornato, PrezzoProdotto = prezzoAggiornato, GiacenzaProdotto = giacenzaAggiornata});
                    }
                    else
                    {
                        Console.WriteLine($"\nProdotto non trovato per ID {idProdottoDaAggiornare}");
                    }
                break;
                case "5":
                    Console.Write("ID > ");
                    int idProdottoDaEliminare = int.Parse(Console.ReadLine());
                    manager.EliminaProdotto(idProdottoDaEliminare);
                break;
                case "0":
                    continua = false;
                    repository.SalvaProdotti(manager.OttieniProdotti());
                    Console.WriteLine("Arrivederci!\n");
                break;
            }
        }

        // void InitDefault ()
        // {
        //     if (!File.Exists("prodotti.json"))
        //     {
        //         File.Create("prodotti.json").Close();
        //         string importDefault = File.ReadAllText("default.json");
        //         string newDefault = JsonConvert.SerializeObject(importDefault, Formatting.Indented);
        //         File.WriteAllText(filePath, newDefautl);
        //     }
        // }

        // int GetLastId (List<ProdottoAdvanced> prodotti)
        // {
        //     int max = 0;
        //     foreach(var item in prodotti)
        //     {
        //         max = item.Id;
        //         if (item.Id > max)
        //         {
        //             max = item.Id;
        //         }
        //     }
        //     return max;
        // }

    }
}




// La gestione dei file json è più sicura se il path è privato
// dunque ogni file json avrà la propria Class Repository per salvare e caricare
// la cosa più furba è mantenere i vari blocchi modulari (riutilizzabili)
// piuttosto che fare una classe che fa più cose

