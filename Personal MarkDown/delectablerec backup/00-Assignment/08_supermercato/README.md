# Supermercato - simulazione

## Obiettivo

Realizzare un programma che simuli il funzionamento di un supermercato

## Versione 1

```csharp
// Prodotti disponibili

// creo una lista di stringhe contenente i prodotti disponibili
List<string> prodotti = new List<string>
{
    "Latte intero", "Pane integrale", "Mela", "Banana", "Acqua naturale",
    "Biscotti al cioccolato", "Riso basmati", "Formaggio grattugiato"
};

// Carrello

// creo un dizionario per tenere traccia dei prodotti nel carrello
Dictionary<string, int> carrello = new Dictionary<string, int>();

// creo una variabile booleana per controllare se il programma deve continuare
bool continua = true;

// Menu
// il while loop permette di continuare a visualizzare il menu finché l'utente non decide di uscire
while (continua)
{
    Console.WriteLine("\nScegli un'opzione:");
    Console.WriteLine("1. Visualizza i prodotti");
    Console.WriteLine("2. Cerca un prodotto");
    Console.WriteLine("3. Aggiungi un prodotto al carrello");
    Console.WriteLine("4. Rimuovi un prodotto dal carrello");
    Console.WriteLine("5. Visualizza il carrello");
    Console.WriteLine("6. Procedi al pagamento");
    Console.WriteLine("0. Esci");

    // chiedo all'utente di inserire la sua scelta
    Console.Write("\nInserisci la tua scelta: ");
    string scelta = Console.ReadLine();

    // utilizzo uno switch statement per eseguire l'azione corrispondente alla scelta dell'utente
    switch (scelta)
    {
        case "1":
            VisualizzaProdotti(prodotti);
            break;
        case "2":
            CercaProdotto(prodotti);
            break;
        case "3":
            AggiungiAlCarrello(prodotti, carrello);
            break;
        case "4":
            RimuoviDalCarrello(carrello);
            break;
        case "5":
            VisualizzaCarrello(carrello);
            break;
        case "6":
            ProcediAlPagamento(carrello);
            continua = false; // Termina il programma dopo il pagamento
            break;
        case "0":
            continua = false;
            break;
        default:
            Console.WriteLine("Scelta non valida. Riprova.");
            break;
    }
}

// Metodo per visualizzare i prodotti si usa static perchè si vuole usarlo nel main
// senza static sarebbe necessario creare un'istanza della classe cosi: Supermercato.VisualizzaProdotti(prodotti); dove supermercato e il nome della classe (in questo caso non c'è)
// invece usando static si può chiamare direttamente VisualizzaProdotti(prodotti);

static void VisualizzaProdotti(List<string> prodotti)
{
    Console.WriteLine("\nProdotti disponibili:");
    foreach (string prodotto in prodotti)
    {
        Console.WriteLine($"- {prodotto}");
    }
}

// Metodo per cercare un prodotto
static void CercaProdotto(List<string> prodotti)
{
    Console.Write("\nInserisci una parola chiave per cercare un prodotto: ");
    string parolaChiave = Console.ReadLine();

    Console.WriteLine("\nRisultati della ricerca:");
    foreach (string prodotto in prodotti)
    {
        if (prodotto.Contains(parolaChiave))
        {
            Console.WriteLine($"- {prodotto}");
        }
    }
}

// Metodo per aggiungere un prodotto al carrello
static void AggiungiAlCarrello(List<string> prodotti, Dictionary<string, int> carrello)
{
    Console.Write("\nInserisci il nome del prodotto da aggiungere al carrello: ");
    string prodotto = Console.ReadLine();

    // Controlla se il prodotto esiste
    if (prodotti.Contains(prodotto))
    {
        Console.Write("Inserisci la quantità: ");
        int quantita = int.Parse(Console.ReadLine());

        if (carrello.ContainsKey(prodotto))
        {
            carrello[prodotto] += quantita;
        }
        else
        {
            carrello[prodotto] = quantita;
        }

        Console.WriteLine($"{quantita}x {prodotto} aggiunto al carrello.");
    }
    else
    {
        Console.WriteLine("Prodotto non trovato. Riprova.");
    }
}

// Metodo per rimuovere un prodotto dal carrello
static void RimuoviDalCarrello(Dictionary<string, int> carrello)
{
    Console.Write("\nInserisci il nome del prodotto da rimuovere dal carrello: ");
    string prodotto = Console.ReadLine();

    if (carrello.ContainsKey(prodotto))
    {
        carrello.Remove(prodotto);
        Console.WriteLine($"{prodotto} rimosso dal carrello.");
    }
    else
    {
        Console.WriteLine("Prodotto non trovato nel carrello.");
    }
}

// Metodo per visualizzare il carrello
static void VisualizzaCarrello(Dictionary<string, int> carrello)
{
    Console.WriteLine("\nIl tuo carrello contiene:");
    foreach (var item in carrello)
    {
        Console.WriteLine($"- {item.Key}: {item.Value}x");
    }
}

// Metodo per procedere al pagamento
static void ProcediAlPagamento(Dictionary<string, int> carrello)
{
    Console.WriteLine("\nRiepilogo del carrello:");
    VisualizzaCarrello(carrello);

    Console.WriteLine("\nPagamento completato! Grazie per il tuo acquisto.");
}

// creo un messaggio di uscita
Console.WriteLine("Grazie per aver visitato il Supermercato!");
```

## Comandi di versionamento

```bash
git add --all
git commit -m "Versione 1 del programma di simulazione del supermercato"
git push -u origin main
```

## Versione 2

## Obiettivo

- espandere il supermercato con funzionalità extra come prezzi
- riepilogo dettagliato del carrello: Visualizza quantità, prezzo unitario e totale per ogni prodotto.

## 1 Lista dei Prodotti con Prezzi

Utilizzeremo un dizionario per associare i prodotti ai prezzi.

```csharp
Dictionary<string, decimal> prodottiConPrezzi = new Dictionary<string, decimal>
{
    { "Latte intero", 1.50m },
    { "Pane integrale", 2.00m },
    { "Mela", 0.80m },
    { "Banana", 0.70m },
    { "Acqua naturale", 0.50m },
    { "Biscotti al cioccolato", 3.00m },
    { "Riso basmati", 2.50m },
    { "Formaggio grattugiato", 4.00m }
};
```

## 2 Aggiornamento del Carrello

Aggiorniamo il dizionario del carrello per includere i prezzi e calcolare il totale per ogni prodotto.

```csharp
Dictionary<string, (int Quantita, decimal PrezzoUnitario)> carrello = new Dictionary<string, (int Quantita, decimal PrezzoUnitario)>();
```

## 3 Aggiornamento dei Metodi

Aggiorniamo i metodi esistenti per gestire i prezzi e il riepilogo dettagliato del carrello.

```csharp
// visualizza i prodotti con i relativi prezzi
static void VisualizzaProdotti(List<string> prodotti, Dictionary<string, decimal> prodottiConPrezzi)
{
    Console.WriteLine("\nProdotti disponibili:");
    foreach (string prodotto in prodotti)
    {
        Console.WriteLine($"- {prodotto} - Prezzo: {prodottiConPrezzi[prodotto]:C}");
    }
}

static void CercaProdotto(List<string> prodotti)
{
    Console.Write("\nInserisci una parola chiave per cercare un prodotto: ");
    string parolaChiave = Console.ReadLine();

    Console.WriteLine("\nRisultati della ricerca:");
    foreach (string prodotto in prodotti)
    {
        if (prodotto.Contains(parolaChiave, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"- {prodotto}");
        }
    }
}

static void AggiungiAlCarrello(List<string> prodotti, Dictionary<string, decimal> prodottiConPrezzi, Dictionary<string, (int Quantita, decimal PrezzoUnitario)> carrello)
{
    Console.Write("\nInserisci il nome del prodotto da aggiungere al carrello: ");
    string prodotto = Console.ReadLine();

    if (prodotti.Contains(prodotto))
    {
        Console.Write("Inserisci la quantità: ");
        if (int.TryParse(Console.ReadLine(), out int quantita) && quantita > 0)
        {
            if (carrello.ContainsKey(prodotto))
            {
                carrello[prodotto] = (carrello[prodotto].Quantita + quantita, carrello[prodotto].PrezzoUnitario);
            }
            else
            {
                carrello[prodotto] = (quantita, prodottiConPrezzi[prodotto]);
            }

            Console.WriteLine($"{quantita}x {prodotto} aggiunto al carrello.");
        }
        else
        {
            Console.WriteLine("Quantità non valida.");
        }
    }
    else
    {
        Console.WriteLine("Prodotto non trovato. Riprova.");
    }
}

static void RimuoviDalCarrello(Dictionary<string, (int Quantita, decimal PrezzoUnitario)> carrello)
{
    Console.Write("\nInserisci il nome del prodotto da rimuovere dal carrello: ");
    string prodotto = Console.ReadLine();

    if (carrello.ContainsKey(prodotto))
    {
        carrello.Remove(prodotto);
        Console.WriteLine($"{prodotto} rimosso dal carrello.");
    }
    else
    {
        Console.WriteLine("Prodotto non trovato nel carrello.");
    }
}

static void VisualizzaCarrello(Dictionary<string, (int Quantita, decimal PrezzoUnitario)> carrello)
{
    Console.WriteLine("\nIl tuo carrello contiene:");
    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto.");
    }
    else
    {
        foreach (var item in carrello)
        {
            decimal totale = item.Value.Quantita * item.Value.PrezzoUnitario;
            Console.WriteLine($"- {item.Key}: {item.Value.Quantita}x - Prezzo Unitario: {item.Value.PrezzoUnitario:C} - Totale: {totale:C}");
        }
    }
}

static void ProcediAlPagamento(Dictionary<string, (int Quantita, decimal PrezzoUnitario)> carrello)
{
    Console.WriteLine("\nRiepilogo del carrello:");
    VisualizzaCarrello(carrello);

    decimal totaleCarrello = 0;
    foreach (var item in carrello)
    {
        totaleCarrello += item.Value.Quantita * item.Value.PrezzoUnitario;
    }

    Console.WriteLine($"\nTotale da pagare: {totaleCarrello:C}");

    Console.WriteLine("\nPagamento completato! Grazie per il tuo acquisto.");
}
```

Program.cs completo:

```csharp
Dictionary<string, decimal> prodottiConPrezzi = new Dictionary<string, decimal>
{
    { "Latte intero", 1.50m },
    { "Pane integrale", 2.00m },
    { "Mela", 0.80m },
    { "Banana", 0.70m },
    { "Acqua naturale", 0.50m },
    { "Biscotti al cioccolato", 3.00m },
    { "Riso basmati", 2.50m },
    { "Formaggio grattugiato", 4.00m }
};

// Carrello
Dictionary<string, (int Quantita, decimal PrezzoUnitario)> carrello = new Dictionary<string, (int Quantita, decimal PrezzoUnitario)>();

// Variabile per controllare il ciclo
bool continua = true;

// Menu principale
while (continua)
{
    Console.WriteLine("\nScegli un'opzione:");
    Console.WriteLine("1. Visualizza i prodotti");
    Console.WriteLine("2. Cerca un prodotto");
    Console.WriteLine("3. Aggiungi un prodotto al carrello");
    Console.WriteLine("4. Rimuovi un prodotto dal carrello");
    Console.WriteLine("5. Visualizza il carrello");
    Console.WriteLine("6. Procedi al pagamento");
    Console.WriteLine("0. Esci");

    Console.Write("\nInserisci la tua scelta: ");
    string scelta = Console.ReadLine();

    switch (scelta)
    {
        case "1":
            VisualizzaProdotti(prodotti, prodottiConPrezzi);
            break;
        case "2":
            CercaProdotto(prodotti);
            break;
        case "3":
            AggiungiAlCarrello(prodotti, prodottiConPrezzi, carrello);
            break;
        case "4":
            RimuoviDalCarrello(carrello);
            break;
        case "5":
            VisualizzaCarrello(carrello);
            break;
        case "6":
            ProcediAlPagamento(carrello);
            continua = false;
            break;
        case "0":
            continua = false;
            break;
        default:
            Console.WriteLine("Scelta non valida. Riprova.");
            break;
    }
}

Console.WriteLine("Grazie per aver visitato il Supermercato!");

static void VisualizzaProdotti(List<string> prodotti, Dictionary<string, decimal> prodottiConPrezzi)
{
    Console.WriteLine("\nProdotti disponibili:");
    foreach (string prodotto in prodotti)
    {
        Console.WriteLine($"- {prodotto} - Prezzo: {prodottiConPrezzi[prodotto]:C}");
    }
}

static void CercaProdotto(List<string> prodotti)
{
    Console.Write("\nInserisci una parola chiave per cercare un prodotto: ");
    string parolaChiave = Console.ReadLine();

    Console.WriteLine("\nRisultati della ricerca:");
    foreach (string prodotto in prodotti)
    {
        if (prodotto.Contains(parolaChiave, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"- {prodotto}");
        }
    }
}

static void AggiungiAlCarrello(List<string> prodotti, Dictionary<string, decimal> prodottiConPrezzi, Dictionary<string, (int Quantita, decimal PrezzoUnitario)> carrello)
{
    Console.Write("\nInserisci il nome del prodotto da aggiungere al carrello: ");
    string prodotto = Console.ReadLine();

    if (prodotti.Contains(prodotto))
    {
        Console.Write("Inserisci la quantità: ");
        if (int.TryParse(Console.ReadLine(), out int quantita) && quantita > 0)
        {
            if (carrello.ContainsKey(prodotto))
            {
                carrello[prodotto] = (carrello[prodotto].Quantita + quantita, carrello[prodotto].PrezzoUnitario);
            }
            else
            {
                carrello[prodotto] = (quantita, prodottiConPrezzi[prodotto]);
            }

            Console.WriteLine($"{quantita}x {prodotto} aggiunto al carrello.");
        }
        else
        {
            Console.WriteLine("Quantità non valida.");
        }
    }
    else
    {
        Console.WriteLine("Prodotto non trovato. Riprova.");
    }
}

static void RimuoviDalCarrello(Dictionary<string, (int Quantita, decimal PrezzoUnitario)> carrello)
{
    Console.Write("\nInserisci il nome del prodotto da rimuovere dal carrello: ");
    string prodotto = Console.ReadLine();

    if (carrello.ContainsKey(prodotto))
    {
        carrello.Remove(prodotto);
        Console.WriteLine($"{prodotto} rimosso dal carrello.");
    }
    else
    {
        Console.WriteLine("Prodotto non trovato nel carrello.");
    }
}

static void VisualizzaCarrello(Dictionary<string, (int Quantita, decimal PrezzoUnitario)> carrello)
{
    Console.WriteLine("\nIl tuo carrello contiene:");
    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto.");
    }
    else
    {
        foreach (var item in carrello)
        {
            decimal totale = item.Value.Quantita * item.Value.PrezzoUnitario;
            Console.WriteLine($"- {item.Key}: {item.Value.Quantita}x - Prezzo Unitario: {item.Value.PrezzoUnitario:C} - Totale: {totale:C}");
        }
    }
}

static void ProcediAlPagamento(Dictionary<string, (int Quantita, decimal PrezzoUnitario)> carrello)
{
    Console.WriteLine("\nRiepilogo del carrello:");
    VisualizzaCarrello(carrello);

    decimal totaleCarrello = 0;
    foreach (var item in carrello)
    {
        totaleCarrello += item.Value.Quantita * item.Value.PrezzoUnitario;
    }

    Console.WriteLine($"\nTotale da pagare: {totaleCarrello:C}");

    Console.WriteLine("\nPagamento completato! Grazie per il tuo acquisto.");
}
```

## Comandi di versionamento

```bash
git add --all
git commit -m "Aggiunta funzionalità extra al supermercato: prezzi e riepilogo dettagliato del carrello"
git push -u origin main
```