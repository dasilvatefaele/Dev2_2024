List<string> prodotti = new List<string>
{
    "Latte intero", "Pane Integrale", "Mela", "Banana", "Acqua Naturale",
    "Biscotti al cioccolato", "Riso Basmati", "Formaggio Grattuggiato"
};

var carrello = new Dictionary<string, int>();
bool continua = true;
int scelta;
bool disponibile;
string prodottoDaCercare;

Console.Clear();
while (continua)
{
    Console.WriteLine("\n--- MENU ---:");
    Console.WriteLine("1. Visualizza i prodotti");
    Console.WriteLine("2. Cerca un prodotto");
    Console.WriteLine("3. Aggiungi un prodotto al carello");
    Console.WriteLine("4. Rimuovi un prodotto dal carrello");
    Console.WriteLine("5. Visualizza il carrello");
    Console.WriteLine("6. Procedi al pagamento");
    Console.WriteLine("0. Esci\n");
    Console.Write("> ");
    scelta = int.Parse(Console.ReadLine());
    Console.Clear();

    switch (scelta)
    {
        case 1:
            VisualizzaProdotti(prodotti);
            break;
        case 2:
            disponibile = CercaUnPrototto(prodotti, out prodottoDaCercare);
            break;
        case 3:
            AggiungiAlCarrello(prodotti, carrello);
            break;
        case 4:
            RimuoviDalCarrello(carrello);
            break;
        case 5:
            VisualizzaCarrello(carrello);
            break;
        case 6:
            continua = ProcediAlPagamento(continua, carrello);
            break;
        case 0:
            continua = Esci(continua);
            break;
        default:
            Console.WriteLine("Opzione non valida");
            break;
    }
}

void VisualizzaProdotti(List<string> prodotti)
{
    Console.WriteLine("--- PRODOTTI DISPONIBILI ---");
    foreach (var prodotto in prodotti)
    {
        Console.WriteLine(prodotto);
    }
    Console.WriteLine();
}

bool CercaUnPrototto(List<string> prodotti, out string prodottoDaCercare)
{
    Console.WriteLine("--- SCEGLI IL PRODOTTO ---");
    Console.Write("> ");
    prodottoDaCercare = Console.ReadLine();
    prodottoDaCercare = prodottoDaCercare.ToLower();
    var prodottiToLower = new List<string>();
    foreach (var prodotto in prodotti)
    {
        prodottiToLower.Add(prodotto.ToLower());
    }

    if (prodottiToLower.Contains(prodottoDaCercare))
    {
        Console.WriteLine("Il prodotto è disponibile.");
        return prodottiToLower.Contains(prodottoDaCercare);
    }
    else
    {
        Console.WriteLine("Il prodotto non è disponibile.");
        return prodottiToLower.Contains(prodottoDaCercare);
    }
}

void AggiungiAlCarrello(List<string> prodotti, Dictionary<string, int> carrello)
{
    string prodottoDaAggiungere;
    Console.WriteLine("--- AGGIUNGI AL CARRELLO ---");
    VisualizzaProdotti(prodotti);
    bool disponibile = CercaUnPrototto(prodotti, out prodottoDaAggiungere);

    if (disponibile)
    {
        if (!carrello.ContainsKey(prodottoDaAggiungere.ToUpper()))
        {
            carrello[prodottoDaAggiungere.ToUpper()] = 0;
        }
        carrello[prodottoDaAggiungere.ToUpper()]++;
        Console.WriteLine("--- AGGIUNTO AL CARRELLO ---");
    }
    else
    {
        Console.WriteLine("Prodotto non disponibile.");
    }
    //return carrello;
}

void RimuoviDalCarrello(Dictionary<string, int> carrello)
{
    Console.WriteLine("--- RIMUOVI DAL CARRELLO ---");
    VisualizzaCarrello(carrello);
    Console.Write("> ");
    string prodottoDaRimuovere = Console.ReadLine();

    if (carrello.ContainsKey(prodottoDaRimuovere.ToUpper()))
    {
        carrello.Remove(prodottoDaRimuovere.ToUpper());
    }
    else
    {
        Console.WriteLine("Questo prodotto non è nel tuo carrello.");
    }
    //return carrello;
}

void VisualizzaCarrello(Dictionary<string, int> carrello)
{
    Console.WriteLine("--- IL TUO CARRELLO ---");

    Console.WriteLine("PROOTTO:\t\tQUANTITA:");
    foreach (var prodotto in carrello)
    {
        Console.WriteLine($"{prodotto.Key}\t\t\t{prodotto.Value}");
    }
}

bool ProcediAlPagamento(bool continua, Dictionary<string, int> carrello)
{
    Console.WriteLine("Sei Arrivato al pagamento.");
    return !continua;
}

bool Esci(bool continua)
{
    //continua = false;
    bool riuscito = true;
    Console.WriteLine();
    Console.WriteLine("Sicuro di voler uscire?\n[1] Procedi al pagamento\n[2] Continua la spesa\n[3] Abbandona ed esci");
    do
    {
        Console.Write("> ");
        try
        {
            riuscito = int.TryParse(Console.ReadLine(), out scelta);
        }
        catch (Exception e)
        {
            Console.WriteLine("Inserimento non valido");
        }
        if (scelta > 4 || scelta <= 0)
        {
            Console.WriteLine("Inserimento non valido");
            riuscito = false;
        }
    } while (!riuscito);

    switch (scelta)
    {
        case 1:
            return ProcediAlPagamento(continua, carrello);
            //continua = !continua;
            break;
        case 2:
            //continua = !continua;
            return continua;
            break;
        case 3:
            //continua = !continua;
            return !continua;
            break;
    }
    return !continua;
}