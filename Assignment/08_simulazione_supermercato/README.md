# Simulazione supermercato

### Obiettivo

Realizzare un programma che simuli il funzionamento di un supermercato

### Versione 1

- creo una lista di stringhe contente i prodotti disponibili chiamata `prodotti`
- creo un dizionario string-intero per tenere traccia dei prodotti che ho nel carrello
- creare una variabile per continuare o terminare l'acquisto `continua`
- utilizzare un menu 
- visualizzare prodotti
- cercare tramite metodi di stringa
- visualizzare, aggiungere, rimuovere dal carrello
- utilizzare le funzioni

```Mermaid
flowchart

```
> Comandi di versionamento
```
git add --all
git commit -m "08 supermercato v1"
git push -u origin main
```
### Versione 2

### Obiettivo
- espandere l'esercitazione con funzionalità extra come prezzi
 ---
## Analisi struttura di dati:

- Prodotto (string)
    - prezzo (double)
    - numero (double)


- Carrello
    - Prodotto
        - prezzo
        - numero
    - Prodotto
        - prezzo
        - numero
    - Prodotto
        - prezzo
        - numero
---
Ogni prodotto contiene due informazioni numeriche. Un prezzo, che non cambia, e un contatore, che verrà trattato come di tipo intero.

Il carrello dev'essere una lista di prodotti.

Dopo un ripasso sulle strutture di dati convengo che sia sensato utilizzare:

```csharp
//PRODOTTO 
const int PREZZO = 0;
const int QUANTITA = 1;
var prodotti = Dictionary<string, list<double>>();
```

dove:
- la variabile `string` nomeProdotto viene inizializzata col nome prodotto
- la `List<double>` viene inizializzata
    - `info[PREZZO]` = prezzo del prodotto
    - `info[QUANTITA]` = 1

Ad ogni chiave univoca `nomeProdotto` viene associata una lista `info` con indici `PREZZO` e `QUANTITA`

- Prezzo non cambia mai.
- Quantità inizia da 0
- aumenta se la chiave del prodotto è presente nella chiave del carrello
- decrementa se viene rimosso dal carrello
- se quantità arriva a 0, il prodotto viene rimosso dal carrello 
- al pagamento
    - ciò che ha quantità 1 viene sommato alla variabile `double saldoFinale`
    - ciò che ha quantità > 1, moltiplica `QUANTITA * PREZZO` e somma a `double saldoFinale`



#### Perplessità:
- capire come avere accesso e modificare la variabile di info[] dentro il dizionario

> non funzionate

Per incrementare la quantità ipotizzo una struttura di questo tipo:

```csharp
const int QUANTITA = 1;
var prodotti = Dictionary<string, list<double>>();
prodotto["latte"].Value[QUANTITA] = 1;
// incorretto
```
> Codice Versione v2 (Funzionante)
```csharp
// todo: ************ SIMULAZIONE SUPERMERCATO Versione 2 ************
//* ------------------------------------------------------------------ 
//* ------------------------------ MAIN ------------------------------ 
//* ------------------------------------------------------------------ 

// Dichiarazioni 
const int PREZZO = 0;
const int QUANTITA = 1;
int scelta;
bool continua = true;
bool convertito;
bool disponibile;
string prodottoDaCercare;
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
    Console.WriteLine("0. Esci\n");

    // input: scelta
    do
    {
        Console.Write("> ");
        convertito = int.TryParse(Console.ReadLine(), out scelta);
        if (!convertito)
        {
            Console.WriteLine("Inserire un numero presente nel MENU");
        }
    } while (!convertito || scelta > 6 && scelta < 0);

    Console.Clear();
    switch (scelta)
    {
        case 1:
            VisualizzaProdotti(prodottiConPrezzo);
            break;
        case 2:
            disponibile = CercaUnPrototto(prodottiConPrezzo, out prodottoDaCercare);
            break;
        case 3:
            AggiungiAlCarrello(prodottiConPrezzo, carrello);
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
}                       //* MAIN LOOP }

// dialogo finale
Console.WriteLine("L'acquisto è andato a buon fine! Arrivederci!\n");

//* ------------------------------------------------------------------ 
//* ---------------------------- FUNZIONI ---------------------------- 
//* ------------------------------------------------------------------ 

void VisualizzaProdotti(Dictionary<string, double[]> prodottiConPrezzo)
{
    Console.WriteLine("--- PRODOTTI DISPONIBILI ---");
    Console.WriteLine("[Prezzo]\t[Prodotto]");
    foreach (var prodotto in prodottiConPrezzo)
    {
        Console.WriteLine($"€ {prodotto.Value[PREZZO]:F2}\t\t{prodotto.Key}");
    }
    Console.WriteLine();
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

void AggiungiAlCarrello(Dictionary<string, double[]> prodottiConPrezzo, Dictionary<string, double[]> carrello)
{
    string prodottoDaAggiungere;
    Console.WriteLine("--- AGGIUNGI AL CARRELLO ---");
    VisualizzaProdotti(prodottiConPrezzo);
    bool disponibile = CercaUnPrototto(prodottiConPrezzo, out prodottoDaAggiungere);
    int quantitaDiProdotto = 0;

    if (disponibile)
    {
        if (!carrello.ContainsKey(prodottoDaAggiungere))
        {
            quantitaDiProdotto = QuantitaProdotto(quantitaDiProdotto);
            carrello[prodottoDaAggiungere] = prodottiConPrezzo[prodottoDaAggiungere];
            carrello[prodottoDaAggiungere][QUANTITA] = quantitaDiProdotto;
            Console.WriteLine("* AGGIUNTO");
        }
        else
        {
            quantitaDiProdotto = QuantitaProdotto(quantitaDiProdotto);
            carrello[prodottoDaAggiungere][QUANTITA] += quantitaDiProdotto;
        }
    }
}

void RimuoviDalCarrello(Dictionary<string, double[]> carrello)
{
    Console.WriteLine("--- RIMUOVI DAL CARRELLO ---");
    VisualizzaCarrello(carrello);
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

void VisualizzaCarrello(Dictionary<string, double[]> carrello)
{
    Console.WriteLine("--- IL TUO CARRELLO ---");
    Console.WriteLine("QUANTITA:\t\tPROOTTO:");
    foreach (var prodotto in carrello)
    {
        Console.WriteLine($"x{prodotto.Value[QUANTITA]}\t\t\t{prodotto.Key}");
    }
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
    return quantitaDiProdotto;
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
```
> Comandi di versionamento
```
git add --all
git commit -m "08 supermercato v2"
git push -u origin main
```