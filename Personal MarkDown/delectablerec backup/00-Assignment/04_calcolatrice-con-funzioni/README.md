# Calcolatrice con funzioni

## Versione 1

## Obiettivo
- implementare le funzioni nella versione semplificata della calcolatrice.

Programma originale:

```csharp
// Chiedi all'utente di inserire due numeri
double num1 = 0;
double num2 = 0;
bool inputValido = false;
while (!inputValido)
{
    try
    {
        Console.Write("Inserisci il primo numero: ");
        num1 = Convert.ToDouble(Console.ReadLine());
        inputValido = true;
    }
    catch (FormatException)
    {
        Console.WriteLine("Inserisci un numero valido.");
    }
}
inputValido = false;
while (!inputValido)
{
    try
    {
        Console.Write("Inserisci il secondo numero: ");
        num2 = Convert.ToDouble(Console.ReadLine());
        inputValido = true;
    }
    catch (FormatException)
    {
        Console.WriteLine("Inserisci un numero valido.");
    }
}
// Chiedi all'utente di selezionare un operatore matematico
char operatore = ' ';
inputValido = false;
while (!inputValido)
{
    Console.Write("Seleziona un operatore (+, -, *, /): ");
    operatore = Console.ReadKey().KeyChar;
    Console.WriteLine();
    if (operatore == '+' || operatore == '-' || operatore == '*' || operatore == '/')
    {
        inputValido = true;
    }
    else
    {
        Console.WriteLine("Operatore non valido.");
    }
}
// Esegui l'operazione selezionata
double risultato = 0;
try
{
    switch (operatore)
    {
        case '+':
            risultato = num1 + num2;
            break;
        case '-':
            risultato = num1 - num2;
            break;
        case '*':
            risultato = num1 * num2;
            break;
        case '/':
            if (num2 == 0)
            {
                throw new DivideByZeroException();
            }
            risultato = num1 / num2;
            break;
    }
    // Stampa il risultato
    Console.WriteLine($"Il risultato dell'operazione è: {risultato}");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Impossibile dividere per zero.");
}
```

## Funzioni

```csharp
// chiedi all'utente di inserire due numeri
double num1 = ChiediNumero();
double num2 = ChiediNumero();

// chiedi all'utente di selezionare un operatore matematico
char operatore = ChiediOperatore();

// esegui l'operazione selezionata
double risultato = EseguiOperazione(num1, num2, operatore);

// visualizza il risultato
Console.WriteLine($"Il risultato è: {risultato}");
```

## Codice completo

```csharp
// chiedi all utente di inserire due numeri
double num1 = ChiediNumero();
double num2 = ChiediNumero();

// chiedi all utente di selezionare un operatore matematico
char operatore = ChiediOperatore();

// esegui l operazione selezionata
double risultato = EseguiOperazione(num1, num2, operatore);

// visualizza il risultato
Console.WriteLine($"Il risultato è: {risultato}");

double ChiediNumero()
{
    double num = 0;
    bool inputValido = false;
    while (!inputValido)
    {
        try
        {
            Console.Write("Inserisci un numero: ");
            num = Convert.ToDouble(Console.ReadLine());
            inputValido = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserisci un numero valido.");
        }
    }
    return num;
}

char ChiediOperatore()
{
    char operatore = ' ';
    bool inputValido = false;
    while (!inputValido)
    {
        Console.Write("Seleziona un operatore (+, -, *, /): ");
        operatore = Console.ReadKey().KeyChar;
        Console.WriteLine();
        if (operatore == '+' || operatore == '-' || operatore == '*' || operatore == '/')
        {
            inputValido = true;
        }
        else
        {
            Console.WriteLine("Operatore non valido.");
        }
    }
    return operatore;
}

double EseguiOperazione(double num1, double num2, char operatore)
{
    double risultato = 0;
    switch (operatore)
    {
        case '+':
            risultato = num1 + num2;
            break;
        case '-':
            risultato = num1 - num2;
            break;
        case '*':
            risultato = num1 * num2;
            break;
        case '/':
            risultato = num1 / num2;
            break;
    }
    return risultato;
}
// output atteso
```

## Comandi di versionamento

```bash
git add --all
git commit -m "Implementata la versione 1 della calcolatrice con funzioni"
git push -u origin main
```