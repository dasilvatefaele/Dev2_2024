# Verifica input generico

## Obiettivo

 Programma in C# che contiene una serie di metodi generici per la verifica degli input.

- un metodo per la verifica di un numero intero
- un metodo per la verifica di un numero decimale
- un metodo per la verifica che un numero sia compreso in un intervallo
- un metodo per la verifica di una stringa non vuota
- un metodo per la verifica di un carattere non vuoto

# Versione 1 (solo con do while)

```csharp
// passo a VerificaIntero il messaggio da stampare a video
// restituisce l'intero inserito dall'utente
int numero = VerificaIntero("Inserisci un numero intero: ");
Console.WriteLine($"Hai inserito il numero {numero}");

// passo a VerificaDecimale il messaggio da stampare a video
// restituisce il decimale inserito dall'utente
double numeroDecimale = VerificaDecimale("Inserisci un numero decimale: ");
Console.WriteLine($"Hai inserito il numero {numeroDecimale}");

// passo a VerificaCompreso il messaggio da stampare a video
// restituisce il decimale inserito dall'utente
double numeroCompreso = VerificaCompreso("Inserisci un numero compreso tra 1 e 10: ", 1, 10);
Console.WriteLine($"Hai inserito il numero {numeroCompreso}");

// passo a VerificaStringa il messaggio da stampare a video
// restituisce la stringa inserita dall'utente
string stringa = VerificaStringa("Inserisci una stringa: ");
Console.WriteLine($"Hai inserito la stringa {stringa}");

// passo a VerificaChar il messaggio da stampare a video
// restituisce il carattere inserito dall'utente
char carattere = VerificaChar("Inserisci un carattere: ");
Console.WriteLine($"Hai inserito il carattere {carattere}");

// funzioni di verifica input

// verifica intero con messaggio personalizzato
// prende in input una stringa da stampare a video
// restituisce l'intero inserito
static int VerificaIntero(string messaggio)
{
    int numero; // dichiaro la variabile numero
    bool successo; // dichiaro la variabile successo
    // do while che cicla finchè non si inserisce un numero intero
    do
    {
        Console.Write(messaggio); // stampo il messaggio cioe "Inserisci un numero intero: " che gli passo
        successo = int.TryParse(Console.ReadLine(), out numero); // TryParse tenta di convertire la stringa in un numero intero
    // se non ci riesce restituisce false e continua a ciclare
    } while (!successo);
    return numero; // restituisco la variabile numero
}

// verifica decimale con messaggio personalizzato
// prende in input una stringa da stampare a video
// restituisce il decimale inserito
static double VerificaDecimale(string messaggio)
{
    double numero;
    bool successo;
    do
    {
        Console.Write(messaggio);
        successo = double.TryParse(Console.ReadLine(), out numero);
    } while (!successo);

    return numero;
}

// verifica decimale compreso tra min e max con messaggio personalizzato
// prende in input una stringa da stampare a video, il valore min e il valore max
// restituisce il decimale inserito
static double VerificaCompreso(string messaggio, double min, double max)
{
    double numero;
    bool successo;
    do
    {
        Console.Write(messaggio);
        successo = double.TryParse(Console.ReadLine(), out numero);
    } while (!successo || numero < min || numero > max);

    return numero;
}

// verifica stringa con messaggio personalizzato
// prende in input una stringa da stampare a video
// restituisce la stringa inserita
static string VerificaStringa(string messaggio)
{
    string stringa;
    do
    {
        Console.Write(messaggio);
        stringa = Console.ReadLine();
    } while (string.IsNullOrEmpty(stringa));

    return stringa;
}

// verifica carattere con messaggio personalizzato
// prende in input un carattere da stampare a video
// restituisce il carattere inserito
static char VerificaChar(string messaggio)
{
    char carattere;
    do
    {
        Console.Write(messaggio);
        carattere = Console.ReadKey().KeyChar;
    } while (char.IsWhiteSpace(carattere));

    return carattere;
}
```

# Versione 2 (con try catch ed eccezioni personalizzate)

```csharp
// passo a VerificaIntero il messaggio da stampare a video
// restituisce l'intero inserito dall'utente
int numero = VerificaInteroAdv("Inserisci un numero intero: ");
Console.WriteLine($"Hai inserito il numero {numero}");

// passo a VerificaDecimale il messaggio da stampare a video
// restituisce il decimale inserito dall'utente
double numeroDecimale = VerificaDecimaleAdv("Inserisci un numero decimale: ");
Console.WriteLine($"Hai inserito il numero {numeroDecimale}");

// passo a VerificaCompreso il messaggio da stampare a video
// restituisce il decimale inserito dall'utente
double numeroCompreso = VerificaCompresoAdv("Inserisci un numero compreso tra 1 e 10: ", 1, 10);
Console.WriteLine($"Hai inserito il numero {numeroCompreso}");

// passo a VerificaStringa il messaggio da stampare a video
// restituisce la stringa inserita dall'utente
string stringa = VerificaStringaAdv("Inserisci una stringa: ");
Console.WriteLine($"Hai inserito la stringa {stringa}");

// passo a VerificaChar il messaggio da stampare a video
// restituisce il carattere inserito dall'utente
char carattere = VerificaCharAdv("Inserisci un carattere: ");
Console.WriteLine($"Hai inserito il carattere {carattere}");

// funzioni di verifica input

// verifica intero con messaggio personalizzato
// prende in input una stringa da stampare a video
// restituisce l'intero inserito
static int VerificaInteroAdv(string messaggio)
{
    int numero2;
    do
    {
        Console.Write(messaggio);
        try
        {
            numero = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Errore: non hai inserito un numero intero");
            continue;
        }
        break;
    } while (true);

    return numero;
}

// verifica decimale con messaggio personalizzato
// prende in input una stringa da stampare a video
// verifica che il numero contenga una virgola
// restituisce il decimale inserito
static double VerificaDecimaleAdv(string messaggio)
{
    double numero;
    do
    {
        Console.Write(messaggio);
        try
        {
            numero = double.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Errore: non hai inserito un numero decimale");
            continue;
        }
        if (!numero.ToString().Contains(","))
        {
            Console.WriteLine("Errore: il numero deve contenere una virgola");
            continue;
        }
        break;
    } while (true);

    return numero;
}

// verifica decimale compreso tra min e max con messaggio personalizzato
// prende in input una stringa da stampare a video, il valore min e il valore max
// restituisce il decimale inserito
static double VerificaCompresoAdv(string messaggio, double min, double max)
{
    double numero;
    do
    {
        Console.Write(messaggio);
        try
        {
            numero = double.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Errore: non hai inserito un numero decimale");
            continue;
        }
        if (numero < min || numero > max)
        {
            Console.WriteLine($"Errore: il numero deve essere compreso tra {min} e {max}");
            continue;
        }
        break;
    } while (true);

    return numero;
}

// verifica stringa con messaggio personalizzato
// prende in input una stringa da stampare a video
// restituisce la stringa inserita
static string VerificaStringaAdv(string messaggio)
{
    string stringa;
    do
    {
        Console.Write(messaggio);
        stringa = Console.ReadLine();
        if (string.IsNullOrEmpty(stringa))
        {
            Console.WriteLine("Errore: la stringa non può essere vuota");
            continue;
        }
        break;
    } while (true);

    return stringa;
}

// verifica carattere con messaggio personalizzato
// prende in input un carattere da stampare a video
// verifica che il carattere non sia vuoto come ad esempio un invio uno spazio o un tab
// restituisce il carattere inserito
static char VerificaCharAdv(string messaggio)
{
    char carattere;
    do
    {
        Console.Write(messaggio);
        carattere = Console.ReadKey().KeyChar;
        if (char.IsWhiteSpace(carattere))
        {
            Console.WriteLine("\nErrore: il carattere non può essere vuoto");
            continue;
        }
        break;
    } while (true);

    return carattere;
}
```