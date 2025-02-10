using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

// CAMPO di una classe, se vogliamo PROPRIETA' di una classe

public class ProdottiModel : PageModel // Questo "ProdottiModel" è lo stesso che usamo nella view @model ProdottiModel
{


    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    // questi "VARIABILI" sono propriamente detti "CAMPI" di una classe, se vogliamo "PROPRIETA" di una classe - "ATTRIBUTO" è un termine più generico
    public int numeroPagine { get; set; }
    public IEnumerable<Prodotto> Prodotti { get; set; }
    string filePath;
    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
    {
        filePath = "wwwroot/json/prodotti.json";
        string json = System.IO.File.ReadAllText(filePath);
        Prodotti = JsonConvert.DeserializeObject<IEnumerable<Prodotto>>(json);

      
        _logger.LogInformation("Prodotti caricati");

        //inizializimo la lista filtrata
        var prodottiFiltrati = new List<Prodotto>();

        foreach (var prodotto in Prodotti)
        {
            bool aggiungi = true;

            if (minPrezzo.HasValue) // se usimo HasValue vuol dire che il tipo è nullable (in pratica, SE HA VALORE)
            {
                if (prodotto.Prezzo < minPrezzo.Value) // .Value restituisce il valore di un tipo nullable (in pratica, RESTITUISCIMI IL VALORE)
                {
                    aggiungi = false; // se il prezzo del prodotto è minore del prezzo minimo, non lo aggiungiamo alla lista
                }
            }

            // stessa cosa per il prezzo massimo
            if (maxPrezzo.HasValue)
            {
                if (prodotto.Prezzo > maxPrezzo.Value)
                {
                    aggiungi = false;
                }
            }

            if (aggiungi)
            {
                prodottiFiltrati.Add(prodotto);
            }
        }
        Prodotti = prodottiFiltrati;

        numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0);
        // calcola il numero di pagine Math.eiling arrotonda il numero di pagine all'interno del pià vicino 
        // Prodotti,Count restituisc il numero di elementi nella lista Prodotti
        // 6.0 è il numero di prodotti per pagina

        Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6); // qui viene inizializzato pageIndex a 1 

        // se pageIndex è null o indefinito, restituisce 1
        // esegue la paginazione
        // skip salta i primi ((pageIndex ?? 1) - 1) * 6 elementi
        // take prende i successivi 6 prodotti
        // i ?? restituisce 1 se pageIndex è null o indefinito
        // facciamo -1 in modo che pageIndex inizi da 1 unvece ghe da 0.
        // questo ci permette di avere pPageIndex = 1 come prima pagina
        // perché non facciamo pageIndex + 1 ?? perch se paageIndex è null o indefinito
        // quindi bisogna fare pageIndex -1
    }
}

// Eredita metodi e attributi da PageModel dall'archetipo che abbiam creato. 
// Logger è un oggetto utile per segnalare tramite console eventuali
// eventi che si verificano durante l'esecuzione dell'applicazione.
// attraverso metodi specifici come LogInformation, LogError, LogWarning ecc.

// OnGet è il metodo che viene chiamato all'apertura della pagina
// richiama i dati che verranno visualizzati nella pagina.
// in questo caso inizializziamo una lista locale in runtime,
// ma in un contesto professionale i dati potrebbero essere serviti da un 
// database / un repository o da un metodo che carica liste di dati da un file.

// Prodotti è una lista di oggetti di tipo "Prodotto"  "Prodotto.cs". 
// La differenza tra "Prodotto.cs" e "ProdottiModel.cs"
// è che la prima rappresenta il modello di un singolo prodotto, mentre la seconda
// la distribuizione attiva degli oggetti di tipo "Prodotto"