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