// todo: ************ SIMULAZIONE SUPERMERCATO Versione 3 ************
//* ------------------------------------------------------------------ 
//* ------------------------------ MAIN ------------------------------ 
//* ------------------------------------------------------------------ 

using Newtonsoft.Json;

// Dichiarazioni 
const int PREZZO = 0;
const int QUANTITA = 1;
int scelta = -1;
bool continua = true;
bool convertito;
bool disponibile;
string prodottoDaCercare;
string passwordAdmin = "admin";
string linkCatalogoSupermercato = @"catalogo supermercato.json";
string linkCarrello = @"carrello Utente.json";
var carrelloSalvato = new List<dynamic>();
var carrello = new Dictionary<string, double[]>();
var prodottiConPrezzo = new Dictionary<string, double[]>
{
    {"LATTE INTERO",            new double [] {2.89,1}},
    {"MELA",                    new double [] {0.89,1}},
    {"PANE INTEGRALE",          new double [] {1.69,1}},
    {"BANANA",                  new double [] {2.19,1}},
    {"ACQUA NATURALE",          new double [] {2.70,1}},
    {"BISCOTTI AL CIOCCOLATO" , new double [] {3.49,1}},
    {"RISO BASMATI",            new double [] {1.99,1}},
    {"FORMAGGIO GRATTUGGIATO",  new double [] {2.89,1}}
};

    string carrelloUtente = @"carrello Utente.json";


Console.Clear();
while (continua)        //* MAIN LOOP {
{
    Console.WriteLine("\n-------------- MENU ---------------");
    Console.WriteLine("1. Visualizza i prodotti");
    Console.WriteLine("2. Cerca un prodotto");
    Console.WriteLine("3. Aggiungi un prodotto al carello");
    Console.WriteLine("4. Rimuovi un prodotto dal carrello");
    Console.WriteLine("5. Visualizza il carrello");
    Console.WriteLine("6. Procedi al pagamento");
    Console.WriteLine("7. ADMIN MODE");
    Console.WriteLine("0. Esci\n");

    // input: scelta
    // Console.Write("> ");
    scelta = NumberInRange(0, 7);

    Console.Clear();
    switch (scelta)
    {
        case 1:
            Console.WriteLine($"-------- COOP: I Nostri Prodotti ---------");
            VisualizzaProdotti(linkCatalogoSupermercato);
            break;
        case 2:
            disponibile = CercaUnPrototto(prodottiConPrezzo, out prodottoDaCercare);
            break;
        case 3:
            Console.WriteLine($"-------- COOP: I Nostri Prodotti ---------");
            AggiungiAlCarrello();
            break;
        case 4:
            RimuoviDalCarrello(carrello);
            break;
        case 5:
            Console.WriteLine($"-------- IL TUO CARRELLO ---------");
            VisualizzaCarrello(linkCarrello);
            break;
        case 6:
            continua = ProcediAlPagamento(continua, carrello);
            break;
        case 7:
            Console.Write("Inserisci il tuo Codice Operatore > ");
            string inputPassword = Console.ReadLine();
            if (inputPassword == passwordAdmin)
            {
                AdminMode();
            }
            else
            {
                Console.WriteLine("ATTENZIONE: Non hai i permessi per accedere.\n");
            }

            break;
        case 0:
            continua = Esci(continua);
            break;
        default:
            Console.WriteLine("Opzione non valida");
            break;
    }
}                       //* MAIN LOOP }

// dialogo finale
Console.WriteLine("L'acquisto è andato a buon fine! Arrivederci!\n");

//* ------------------------------------------------------------------ 
//* ---------------------------- FUNZIONI ---------------------------- 
//* ------------------------------------------------------------------ 

void VisualizzaProdotti(string link)
{

    dynamic localCurrentState = leggiFileJson(link);

    
    foreach (var line in localCurrentState)
    {
        Console.WriteLine($"=====================================");
        Console.WriteLine($"NOME PRODOTTO:\t\t{line.NomeProdotto}");
        Console.WriteLine($"PREZZO:\t\t\t€{line.Prezzo}");
    }
    Console.WriteLine($"------------------------------------------");

    // Console.WriteLine("--- PRODOTTI DISPONIBILI ---");
    // Console.WriteLine("[Prezzo]\t[Prodotto]");
    // foreach (var prodotto in prodottiConPrezzo)
    // {
    //     Console.WriteLine($"€ {prodotto.Value[PREZZO]:F2}\t\t{prodotto.Key}");
    // }
    // Console.WriteLine();


}

bool CercaUnPrototto(Dictionary<string, double[]> prodottiConPrezzo, out string prodottoDaCercare)
{
    Console.WriteLine("--- SCEGLI IL PRODOTTO ---");
    Console.Write("> ");
    prodottoDaCercare = Console.ReadLine();
    prodottoDaCercare = prodottoDaCercare.ToUpper();

    if (prodottiConPrezzo.ContainsKey(prodottoDaCercare))
    {
        Console.WriteLine("- disponibile");
        return true;
    }
    else
    {
        Console.WriteLine("- non disponibile");
        return false;
    }
}

void AggiungiAlCarrello()
{
    string prodottoDaAggiungere;

    dynamic catalogo = leggiFileJson(linkCatalogoSupermercato);
    List<dynamic> catalogoLocale = catalogo.ToObject<List<dynamic>>();

    dynamic carrelloSalvato = leggiFileJson(linkCarrello);
    List<dynamic> carrelloSalvatoLocale = carrelloSalvato.ToObject<List<dynamic>>();


    Console.WriteLine("--- AGGIUNGI AL CARRELLO ---");
    VisualizzaProdotti(linkCatalogoSupermercato);
    Console.Write("> ");
    prodottoDaAggiungere = Console.ReadLine();
    prodottoDaAggiungere = prodottoDaAggiungere.ToUpper();

    foreach (var prodotto in catalogoLocale) 
    {
        if (prodotto.NomeProdotto == prodottoDaAggiungere)
        {
            Console.Write("Quantita > ");
            int quantita = NumberInRange (1,100);

            if (prodotto.Quantita >= quantita)
            {
                int temp = prodotto.Quantita;
                prodotto.Quantita = quantita;
                carrelloSalvatoLocale.Add(prodotto);
                SalvaSuJson(carrelloSalvatoLocale,linkCarrello);
                prodotto.Quantita = temp - quantita;
                SalvaSuJson(catalogoLocale,linkCatalogoSupermercato);
            }
            else
            {
                Console.WriteLine($"Mi dispiace, la quantità non è disponibile. IN STOCK: {prodotto.Quantita}");
            }
        }

    }
    
    // SalvaSuJson(carrelloSalvatoLocale,linkCarrello);
    

    // bool disponibile = CercaUnPrototto(prodottiConPrezzo, out prodottoDaAggiungere);
    // int quantitaDiProdotto = 0;

    // if (disponibile)
    // {
    //     if (!carrello.ContainsKey(prodottoDaAggiungere))
    //     {
    //         quantitaDiProdotto = QuantitaProdotto(quantitaDiProdotto);
    //         carrello[prodottoDaAggiungere] = prodottiConPrezzo[prodottoDaAggiungere];
    //         carrello[prodottoDaAggiungere][QUANTITA] = quantitaDiProdotto;
    //         Console.WriteLine("* AGGIUNTO");
    //     }
    //     else
    //     {
    //         quantitaDiProdotto = QuantitaProdotto(quantitaDiProdotto);
    //         carrello[prodottoDaAggiungere][QUANTITA] += quantitaDiProdotto;
    //     }
    // }
}

void RimuoviDalCarrello(Dictionary<string, double[]> carrello)
{
    Console.WriteLine("--- RIMUOVI DAL CARRELLO ---");
    VisualizzaCarrello(linkCarrello);
    Console.Write("> ");
    string prodottoDaRimuovere = Console.ReadLine();
    prodottoDaRimuovere = prodottoDaRimuovere.ToUpper();
    int quantitaDiProdotto = 0;
    if (carrello.ContainsKey(prodottoDaRimuovere))
    {
        if (carrello[prodottoDaRimuovere][QUANTITA] > 1)
        {
            quantitaDiProdotto = QuantitaProdotto(quantitaDiProdotto);
            if (carrello[prodottoDaRimuovere][QUANTITA] - quantitaDiProdotto <= 0)
            {
                carrello.Remove(prodottoDaRimuovere);
            }
            else
            {
                carrello[prodottoDaRimuovere][QUANTITA] -= quantitaDiProdotto;
            }
        }
    }
    else
    {
        Console.WriteLine("Questo prodotto non è presente nel tuo carrello");
    }
}

void VisualizzaCarrello(string link)
{

    Console.WriteLine("--- IL TUO CARRELLO ---");
    dynamic localCurrentState = leggiFileJson(linkCarrello);
    double somma = 0;
    
    foreach (var line in localCurrentState)
    {
        Console.WriteLine($"=====================================");
        Console.WriteLine($"NOME PRODOTTO:\t\t{line.NomeProdotto}");
        Console.WriteLine($"PREZZO:\t\t\t€{line.Prezzo}");
        Console.WriteLine($"QNT.:\t\t\tx{line.Quantita}");
        somma += (double)line.Prezzo;
    }

    Console.WriteLine($"------------------------------------------");
    Console.WriteLine($"TOTALE:\t\t\t€{somma:f2}");
}

bool ProcediAlPagamento(bool continua, Dictionary<string, double[]> carrello)
{
    double totale = 0;
    Console.WriteLine("--------------------- CASSA ---------------------");
    Console.WriteLine("PREZZO\t\tQUANTITA\tPRODOTTO");

    foreach (var prodotto in carrello)
    {
        Console.WriteLine($"€ {prodotto.Value[PREZZO]:F2}\t\tx{prodotto.Value[QUANTITA]}\t\t{prodotto.Key}");
        if (prodotto.Value[QUANTITA] == 1)
        {
            totale += prodotto.Value[PREZZO];
        }
        else if (prodotto.Value[QUANTITA] > 1)
        {
            totale += prodotto.Value[PREZZO] * prodotto.Value[QUANTITA];
        }
    }

    Console.WriteLine("--------------------- TOTALE --------------------\n");
    Console.WriteLine($"\t\t     € {totale:F2}\n");
    Console.WriteLine("Prosegui al pagamento...");
    Console.Write("> ");
    Console.ReadKey();
    return !continua;
}

int QuantitaProdotto(int quantitaDiProdotto)
{
    bool check = false;
    while (!check)
    {
        Console.WriteLine("Quanti?");
        Console.Write("> ");
        check = int.TryParse(Console.ReadLine(), out quantitaDiProdotto);
    }
    return quantitaDiProdotto; // ? ottimizzabile
}

bool Esci(bool continua)
{
    //continua = false;
    bool riuscito = true;
    Console.WriteLine("\nSicuro di voler uscire?\n[1] Procedi al pagamento\n[2] Continua la spesa\n[3] Abbandona ed esci");
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

int NumberInRange(int min, int max)
{
    bool repeat = false;
    int num = 0;
    // Console.Write($"Inserisci intero tra {min} e {max} ");
    do
    {
        do
        {
            // Console.Write("> ");
            repeat = false;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("#Errore: dato non corretto");
                repeat = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("#Errore: dato non corretto");
                repeat = true;
            }
        } while (repeat);

        if (num >= min && num <= max)
        {
            //Console.WriteLine("*Numero nel range corretto*");
            return num;
        }
        else
        {
            Console.WriteLine("#Errore: numero fuori dal range");
            repeat = true;
        }
    } while (repeat);
    return -1;
}

double InputDouble()
{
    double numero = 0;
    bool repeat = false;
    string s_numero;
    do
    {
        repeat = false;

        // Console.Write("Inserisci numero decimale > ");
        s_numero = Console.ReadLine();
        s_numero = s_numero.Replace(".", ",");

        try
        {
            numero = Convert.ToDouble(s_numero);
        }
        catch (Exception e)
        {
            Console.WriteLine("#Errore: dato non corretto");
            repeat = true;
        }
    } while (repeat);

    //Console.WriteLine("*Decimale insierito*");
    return numero;
}

string Inserimentofrase()
{

    //Console.Write("Inserisci una stringa > ");
    string frase;
    frase = Console.ReadLine();
    bool ripeti = false;
    do
    {
        ripeti = string.IsNullOrWhiteSpace(frase);

        if (ripeti) // if true
        {
            Console.WriteLine("#Errore: stringa vuota");
            frase = Console.ReadLine();
        }
        else
        {
            //Console.WriteLine("*Stringa inserita*");
            return frase;
        }
    } while (ripeti);
    return frase;
}

//* ------------------------------------------------------------------ 
//* ------------------------------ ADMIN ----------------------------- 
//* ------------------------------------------------------------------ 

void AdminMode()
{
    int sceltaAdmin;

    do
    {
        Console.WriteLine("\n---------- ADMIN -----------");
        Console.WriteLine("\t- [CATALOGO] -");
        Console.WriteLine("1. VISUALIZZA CATALOGO");
        Console.WriteLine("2. AGGIUNGI PRODOTTO");
        Console.WriteLine("3. MODIFICA PRODOTTO");
        Console.WriteLine("4. ELIMINA PRODOTTO");
        Console.WriteLine("\t- [STORE] -");
        Console.WriteLine("5. VISUALIZZA SCONTRINI");
        Console.WriteLine("6. CALCOLA INCASSO");
        Console.WriteLine("0.\t [ ESCI ]\n");

        Console.Write("> ");
        sceltaAdmin = NumberInRange(0, 6);

        switch (sceltaAdmin)
        {
            case 1:
                Console.Clear();
                VisualizzaCatalogoADMIN();
                break;

            case 2:
                Console.Clear();
                AggiungiProdottoADMIN();
                break;

            case 3:
                Console.Clear();
                ModificaProdottoADMIN();
                break;

            case 4:
                Console.Clear();
                EliminaProdottoADMIN();
                break;

            case 5:
                break;

            case 6:
                break;

            case 0:
                break;
        }

    } while (sceltaAdmin != 0);



}

void AggiungiProdottoADMIN()
{
    dynamic localCurrentState = leggiFileJson(linkCatalogoSupermercato);

    Console.WriteLine("--- ADMIN [ INSERISCI PRODOTTO ] ---");

    Console.Write("ID > ");
    string newId = Console.ReadLine();
    newId = newId.ToUpper();

    Console.Write("Nome Prodotto > ");
    string newProdotto = Console.ReadLine();
    newProdotto = newProdotto.ToUpper();

    Console.Write("Quantità > ");
    int newQuantita = NumberInRange(1, 10000);

    Console.Write("Prezzo > ");
    double newPrezzo = InputDouble();

    var newItem = new
    {
        ID = newId,
        NomeProdotto = newProdotto,
        Quantita = newQuantita,
        Prezzo = newPrezzo
    };

    List<dynamic> localList = localCurrentState.ToObject<List<dynamic>>();
    localList.Add(newItem);
    SalvaSuJson(localList, linkCatalogoSupermercato);
}

void ModificaProdottoADMIN()
{
    dynamic localCurrentState = leggiFileJson(linkCatalogoSupermercato);
    Console.WriteLine("--- [ADMIN] : MODIFICA PRODOTTO ---");
    VisualizzaCatalogoADMIN();

    bool repeat = false;

    List<dynamic> prodottiEdit = localCurrentState.ToObject<List<dynamic>>();

    do
    {
        Console.Write("Inserisci ID prodotto da editare > ");
        string editProdotto = Console.ReadLine();
        editProdotto = editProdotto.ToUpper();
        foreach (var line in prodottiEdit)
        {
            if (line.ID == editProdotto)
            {
                Console.WriteLine("Seleziona");
                Console.WriteLine("1. ID");
                Console.WriteLine("2. Nome Prodotto");
                Console.WriteLine("3. Quantita");
                Console.WriteLine("4. Prezzo");
                Console.WriteLine("5. Continua modifica");
                Console.WriteLine("0. Esci");
                Console.Write("> ");
                int scelta = NumberInRange(0, 5);
                switch (scelta)
                {
                    case 1:
                        Console.Write("nuovo ID > ");
                        line.ID = Inserimentofrase();
                        break;
                    case 2:
                        Console.Write("nuovo NOME PRODOTTO > ");
                        line.NomeProdotto = Inserimentofrase();
                        break;
                    case 3:
                        Console.WriteLine("nuova QUANTITA > ");
                        line.Quantita = NumberInRange(1, 10000);
                        break;
                    case 4:
                        Console.WriteLine("nuovo PREZZO > ");
                        line.Quantita = InputDouble();
                        break;
                    case 5:
                        repeat = true;
                        break;
                    case 0:
                        repeat = false;
                        continue;
                        break;
                }

            }
        }

    } while (repeat);

    SalvaSuJson(prodottiEdit, linkCatalogoSupermercato);
}

void VisualizzaCatalogoADMIN()
{
    dynamic localCurrentState = leggiFileJson(linkCatalogoSupermercato);

    Console.WriteLine($"-------- [ CATALOGO ADMIN ] ---------");
    foreach (var line in localCurrentState)
    {
        Console.WriteLine($"=====================================");
        Console.WriteLine($"ID:\t\t\t{line.ID}");
        Console.WriteLine($"NOME PRODOTTO:\t\t{line.NomeProdotto}");
        Console.WriteLine($"QUANTITA:\t\t{line.Quantita}");
        Console.WriteLine($"PREZZO:\t\t\t€{line.Prezzo}");
    }
    Console.WriteLine($"-------------------------------------");
}

void EliminaProdottoADMIN()
{
    dynamic localCurrentState = leggiFileJson(linkCatalogoSupermercato);
    List<dynamic> localList = localCurrentState.ToObject<List<dynamic>>();
    var newList = new List<dynamic>();
    bool trovato = false;

    Console.Write("inserire ID da ELIMINARE> ");
    string elimina = Inserimentofrase();
    elimina = elimina.ToUpper();

    foreach (var line in localList)
    {
        if (line.ID != elimina)
        {
            newList.Add(line);
            trovato = true;
        }
    }

    if (trovato)
    {
        SalvaSuJson(newList, linkCatalogoSupermercato);
    }
}

//* ------------------------------------------------------------------ 
//* ------------------------------- JSON ----------------------------- 
//* ------------------------------------------------------------------ 

void SalvaSuJson(List<dynamic> list, string link)
{
    string item = JsonConvert.SerializeObject(list, Formatting.Indented);
    File.WriteAllText(link, item);
}

dynamic leggiFileJson(string linkCatalogoSupermercato)
{
    string currentState = File.ReadAllText(linkCatalogoSupermercato);
    dynamic localCurrentState = JsonConvert.DeserializeObject(currentState)!;
    return localCurrentState;
}