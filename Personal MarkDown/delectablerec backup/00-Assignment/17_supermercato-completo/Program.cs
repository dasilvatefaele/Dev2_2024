
using Newtonsoft.Json; // libreria per gestire i file JSON

string filePath = "catalogo.json"; // percorso del file JSON

// creo due liste di dizionari per il catalogo e il carrello
// i dizionari contengono le informazioni dei prodotti
// i dizionari sono composti da coppie chiave-valore
// la chiave e una stringa, il valore e un oggetto generico
// il valore è un oggetto generico per poter contenere valori di diversi tipi in questo caso stringhe, decimali e interi
var catalogo = new List<Dictionary<string, object>>(); // lista di dizionari per il catalogo
var carrello = new List<Dictionary<string, object>>(); // lista di dizionari per il carrello

Console.WriteLine("Benvenuto al Supermercato JSON");

while (true)
{
    Console.WriteLine("\nScegli un'opzione:");
    Console.WriteLine("1. Aggiungi un prodotto al catalogo");
    Console.WriteLine("2. Salva il catalogo in JSON");
    Console.WriteLine("3. Carica il catalogo da JSON");
    Console.WriteLine("4. Mostra il catalogo");
    Console.WriteLine("5. Aggiungi prodotti al carrello");
    Console.WriteLine("6. Visualizza carrello e stampa scontrino");
    Console.WriteLine("7. Esci");

    string scelta = Console.ReadLine(); // legge l'input dell'utente

    switch (scelta)
    {
        case "1":
            var prodotto = CreaProdotto(); // crea un nuovo prodotto
            catalogo.Add(prodotto); // aggiunge il prodotto al catalogo lo faccio direttamente senza salvarlo in una variabile perchè non serve
            Console.WriteLine($"Prodotto {prodotto["Nome"]} aggiunto al catalogo."); // conferma l'aggiunta
            break;
        case "2":
            SalvaInJson(catalogo, filePath); // salva il catalogo in JSON
            Console.WriteLine("Catalogo salvato in JSON."); // conferma il salvataggio
            break;
        case "3":
            catalogo = CaricaDaJson(filePath); // carica il catalogo da JSON
            Console.WriteLine("Catalogo caricato da JSON."); // conferma il caricamento
            break;
        case "4":
            MostraCatalogo(catalogo); // mostra il catalogo
            break;
        case "5":
            AggiungiAlCarrello(catalogo, carrello); // aggiunge prodotti al carrello
            break;
        case "6":
            VisualizzaCarrello(carrello); // visualizza il carrello e stampa lo scontrino
            break;
        case "7":
            Console.WriteLine("Grazie da Supermercato JSON"); // messaggio di uscita
            return;
        default:
            Console.WriteLine("Opzione non valida, riprova."); // messaggio di errore
            break;
    }
}

// la funzione crea prodotto permette di creare un nuovo prodotto
// non accetta parametri
// restituisce un dizionario con le informazioni del prodotto
// la funzione e accessibile da tutto il programma in quanto e statica
// la funzione statica permette di accedere alle variabili globali del programma senza doverle passare come parametri
static Dictionary<string, object> CreaProdotto()
{
    var prodotto = new Dictionary<string, object>(); // crea un nuovo dizionario per il prodotto che in questo caso è un oggetto generico che ha
    // come chiave una stringa (Nome, Prezzo, Quantita) e come valore un oggetto generico che può essere di diversi tipi (stringa, decimale, intero)

    Console.Write("Inserisci il nome del prodotto: ");
    // devo mettere prodotto["Nome"] perche il dizionario e di tipo Dictionary<string, object> e non posso usare l'operatore .
    // per accedere ai campi quindi devo usare le parentesi quadre [] ed inserire la chiave
    prodotto["Nome"] = Console.ReadLine();

    Console.Write("Inserisci il prezzo del prodotto: ");
    // converte la stringa in decimale e lo mette nel dizionario come valore decimale quindi devo usare [] per accedere al campo Prezzo
    prodotto["Prezzo"] = decimal.Parse(Console.ReadLine()); 

    Console.Write("Inserisci la quantità disponibile: ");
    prodotto["Quantita"] = int.Parse(Console.ReadLine());

    return prodotto; // restituisce il dizionario con le informazioni del prodotto
}

// la funzione salva in JSON permette di salvare una lista di dizionari in un file JSON
// accetta come parametri la lista di dizionari da salvare e il percorso del file JSON
// la funzione non restituisce nulla
static void SalvaInJson(List<Dictionary<string, object>> catalogo, string filePath)
{
    string json = JsonConvert.SerializeObject(catalogo, Formatting.Indented);
    File.WriteAllText(filePath, json);
}

// la funzione carica da JSON permette di caricare una lista di dizionari da un file JSON
// accetta come parametro il percorso del file JSON
// restituisce la lista di dizionari caricata o una lista vuota se il file non esiste
static List<Dictionary<string, object>> CaricaDaJson(string filePath)
{
    if (!File.Exists(filePath)) // se il file non esiste
    {
        Console.WriteLine("Nessun file JSON trovato!");
        return new List<Dictionary<string, object>>(); // crea una lista vuota e la restituisce
    }

    string json = File.ReadAllText(filePath);
    return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
}

// la funzione mostra catalogo permette di visualizzare il catalogo dei prodotti
// accetta come parametro la lista di dizionari del catalogo
// la funzione non restituisce nulla cioe non restituisce nessun valore da essere usato fuori dalla funzione
static void MostraCatalogo(List<Dictionary<string, object>> catalogo)
{
    if (catalogo.Count == 0) // se il catalogo e vuoto
    {
        Console.WriteLine("Il catalogo è vuoto.");
        return; // esce dalla funzione
    }

    Console.WriteLine("\n--- Catalogo Prodotti ---");
    foreach (var prodotto in catalogo)
    {
        Console.WriteLine($"{prodotto["Nome"]} - Prezzo: €{prodotto["Prezzo"]} - Quantità: {prodotto["Quantita"]}");
    }
}

// la funzione aggiungi al carrello permette di aggiungere prodotti al carrello
// accetta come parametri la lista di dizionari del catalogo e la lista di dizionari del carrello
// la funzione non restituisce nulla
static void AggiungiAlCarrello(List<Dictionary<string, object>> catalogo, List<Dictionary<string, object>> carrello)
{
    if (catalogo.Count == 0)
    {
        Console.WriteLine("Il catalogo è vuoto, carica prima i prodotti!");
        return; // esco dalla funzione se il catalogo è vuoto
    }

    Console.Write("Inserisci il nome del prodotto da acquistare: ");
    string nome = Console.ReadLine();

    Dictionary<string, object> prodotto = null; // inizializzo il prodotto a null in modo da poter controllare se è stato trovato
    foreach (var p in catalogo)
    {
        if (p["Nome"].ToString().Equals(nome, StringComparison.OrdinalIgnoreCase))
        // uso [] per accedere al campo Nome del prodotto perchè il dizionario è di tipo Dictionary<string, object>
        // quindi non posso usare l'operatore . per accedere ai campi
        // StringComparison.OrdinalIgnoreCase serve per ignorare le maiuscole e minuscole
        // Equals restituisce true se le due stringhe sono uguali in quanto non possiamo usare l'operatore == per confrontare stringhe
        {
            prodotto = p; // assegno il prodotto trovato alla variabile prodotto in modo da poterlo usare fuori dal ciclo
            break; // esco dal ciclo dato che ho trovato il prodotto
        }
    }
    if (prodotto == null)
    {
        Console.WriteLine("Prodotto non trovato.");
        return; // esco dalla funzione se il prodotto non è stato trovato
    }

    Console.Write("Inserisci la quantità da acquistare: ");
    int quantita = int.Parse(Console.ReadLine());

    if (quantita > int.Parse(prodotto["Quantita"].ToString())) // controllo se la quantità richiesta è disponibile nel catalogo
    {
        Console.WriteLine("Quantità non disponibile.");
        return; // esco dalla funzione se la quantità non è disponibile
    }

    prodotto["Quantita"] = int.Parse(prodotto["Quantita"].ToString()) - quantita; // aggiorno la quantità disponibile nel catalogo

    carrello.Add(new Dictionary<string, object> // aggiungo il prodotto al carrello con la quantità scelta
    {
        { "Nome", prodotto["Nome"] },
        { "Prezzo", prodotto["Prezzo"] },
        { "Quantita", quantita } // aggiungo la quantità al carrello non metto ["Quantita"] perche la quantità nel carrello è quella che l'utente ha scelto
    });

    Console.WriteLine($"{quantita} x {prodotto["Nome"]} aggiunti al carrello.");
}

// la funzione visualizza carrello permette di visualizzare il carrello e stampare lo scontrino
// accetta come parametro la lista di dizionari del carrello
// la funzione non restituisce nulla
static void VisualizzaCarrello(List<Dictionary<string, object>> carrello)
{
    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto.");
        return;
    }

    Console.WriteLine("\n--- Carrello ---");

    decimal totale = 0; // inizializzo il totale a 0 per calcolare il costo totale del carrello se non lo inizializzo il valore di default è 0
    // quindi posso anche non scriverlo
    
    foreach (var prodotto in carrello)
    {
        decimal costo = decimal.Parse(prodotto["Prezzo"].ToString()) * int.Parse(prodotto["Quantita"].ToString()); // calcolo il costo del prodotto
        Console.WriteLine($"{prodotto["Quantita"]} x {prodotto["Nome"]} - €{costo}");
        totale += costo; // aggiorno il totale con il costo del prodotto acquistato
    }

    Console.WriteLine($"\nTotale: €{totale}");
}