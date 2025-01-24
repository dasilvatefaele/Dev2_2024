# Generatore di password

## Obiettivo

 Programma in C# che genera una password sicura basata sui seguenti criteri:

- La lunghezza della password deve essere compresa tra 8 e 20 caratteri (scelta dall'utente).
- La password deve contenere almeno:

    - 1 lettera maiuscola
    - 1 lettera minuscola
    - 1 numero
    - 1 carattere speciale (es: @, #, !, ecc.).

- La password generata non deve contenere spazi.

## Suggerimenti

- Usa la classe Random per generare caratteri casuali.
- Puoi creare gruppi di caratteri (lettere maiuscole, minuscole, numeri e caratteri speciali) e selezionare casualmente un carattere da ciascun gruppo.

## Versione 1

```csharp
Console.WriteLine("Inserisci la lunghezza della password (tra 8 e 20 caratteri):");

// leggo l input dell utente usando un metodo VerificaInput che verifica che l input sia un numero che sia un numero valido tra 8 ed 20 e che sia un numero intero
int lunghezza = VerificaInput();

// genero la password e la stampo
string password = GeneraPassword(lunghezza);
Console.WriteLine($"Password generata: {password}");

// stampo i criteri della password della funzione ControllaPassword se sono rispettati o meno
if (ControllaPassword(password))
{
    Console.WriteLine("La password generata rispetta i criteri richiesti.");
}
else
{
    Console.WriteLine("La password generata non rispetta i criteri richiesti.");
}

// stampo il numero di maiuscole minuscole numeri e caratteri speciali presenti nella password
ContaCaratteri(password);

// metodo che genera una password usando come input la lunghezza della password inserita dall'utente
static string GeneraPassword(int lunghezza)
{
    string lettereMaiuscole = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string lettereMinuscole = "abcdefghijklmnopqrstuvwxyz";
    string numeri = "0123456789";
    string caratteriSpeciali = "@#$%^&*";

    Random rnd = new Random(); // creo un oggetto Random per generare numeri casuali
    string password = ""; // inizializzo la password come stringa vuota la inizializzo perchè devo concatenare caratteri quindi devo partire da una stringa vuota

    // aggiungo un carattere casuale per ciascun gruppo
    password += lettereMaiuscole[rnd.Next(lettereMaiuscole.Length)];
    password += lettereMinuscole[rnd.Next(lettereMinuscole.Length)];
    password += numeri[rnd.Next(numeri.Length)];
    password += caratteriSpeciali[rnd.Next(caratteriSpeciali.Length)];

    // aggiungo caratteri casuali fino a raggiungere la lunghezza richiesta
    for (int i = 4; i < lunghezza; i++)
    {
        string gruppoCasuale = "";
        switch (rnd.Next(4)) // genero un numero casuale tra 0 e 3 per selezionare casualmente un gruppo di caratteri
        {
            case 0:
                gruppoCasuale = lettereMaiuscole;
                break;
            case 1:
                gruppoCasuale = lettereMinuscole;
                break;
            case 2:
                gruppoCasuale = numeri;
                break;
            case 3:
                gruppoCasuale = caratteriSpeciali;
                break;
        }
        password += gruppoCasuale[rnd.Next(gruppoCasuale.Length)]; // aggiungo un carattere casuale del gruppo selezionato
    }

    // controllo che la password generata rispetti i criteri richiesti
    if (!ControllaPassword(password))
    {
        // se la password non rispetta i criteri genero una nuova password
        password = GeneraPassword(lunghezza);
    }
    return password;
}

// metodo che controlla che la password generata rispetti i criteri richiesti
static bool ControllaPassword(string password)
{
    bool maiuscola = false;
    bool minuscola = false;
    bool numero = false;
    bool speciale = false;

    foreach (char c in password)
    {
        if (char.IsUpper(c))
        {
            maiuscola = true;
        }
        else if (char.IsLower(c))
        {
            minuscola = true;
        }
        else if (char.IsDigit(c))
        {
            numero = true;
        }
        else if (char.IsSymbol(c) || char.IsPunctuation(c))
        {
            speciale = true;
        }
    }

    return maiuscola && minuscola && numero && speciale; // restituisco true se tutti i criteri sono soddisfatti
}

// metodo che conta quanti caratteri minuscoli maiuscoli numeri caratteri specili ci sono nella password
static void ContaCaratteri(string password)
{
    int maiuscole = 0;
    int minuscole = 0;
    int numeri = 0;
    int speciali = 0;

    foreach (char c in password)
    {
        if (char.IsUpper(c))
        {
            maiuscole++;
        }
        else if (char.IsLower(c))
        {
            minuscole++;
        }
        else if (char.IsDigit(c))
        {
            numeri++;
        }
        else if (char.IsSymbol(c) || char.IsPunctuation(c))
        {
            speciali++;
        }
    }

    Console.WriteLine($"Maiuscole: ({maiuscole}) Minuscole: ({minuscole}) Numeri: ({numeri}) Speciali: ({speciali})");
}

// metodo che fa i controlli necessari sull input dell utente
static int VerificaInput()
{
    int lunghezza = 0; // inizializzo la lunghezza a 0
    bool success = false; // inizializzo la variabile success a false
    while (!success)
    {
        string input = Console.ReadLine(); // leggo l input dell utente
        success = int.TryParse(input, out lunghezza); // controllo che l input sia un numero intero
        if (!success)
        {
            Console.WriteLine("Devi inserire un numero intero. Riprova:");
        }
        else if (lunghezza < 8 || lunghezza > 20)
        {
            Console.WriteLine("La lunghezza della password deve essere compresa tra 8 e 20 caratteri. Riprova:");
            success = false;
        }
    }
    return lunghezza; // restituisco la lunghezza in modo da essere usata come input per il metodo GeneraPassword
}
```

## Versione 2 minimal

```csharp
Console.Write("Inserisci la lunghezza della password (tra 8 e 20): ");
if (!int.TryParse(Console.ReadLine(), out int lunghezza) || lunghezza < 8 || lunghezza > 20)
{
    Console.WriteLine("Lunghezza non valida."); // Se l'input non è valido, esce dal programma
    return;
}

string caratteri = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#*!$%&";
Random random = new Random();

char[] password = new char[lunghezza];
// uso il random in modo da prendere un carattere tra i primi 26 che so che sono le lettere maiuscole
password[0] = caratteri[random.Next(26)]; // Aggiungi una lettera maiuscola alla password
password[1] = caratteri[random.Next(26, 52)]; // Aggiungi una lettera minuscola alla password
password[2] = caratteri[random.Next(52, 62)]; // Aggiungi un numero alla password
password[3] = caratteri[random.Next(62, caratteri.Length)]; // Aggiungi un carattere speciale alla password

for (int i = 4; i < lunghezza; i++) // Riempi il resto della password
    password[i] = caratteri[random.Next(caratteri.Length)]; // Aggiungi caratteri casuali alla password fino a raggiungere la lunghezza richiesta

// Mischia i caratteri
for (int i = password.Length - 1; i > 0; i--)
    (password[i], password[random.Next(i + 1)]) = (password[random.Next(i + 1)], password[i]); // Mischia i caratteri della password
// la sintassi (a, b) = (b, a) scambia i valori di a e b dove a e b sono variabili dello stesso tipo
// in questo caso scambia i caratteri della password associando a ogni carattere un altro carattere casuale

Console.WriteLine($"La tua password generata è: {new string(password)}");
```