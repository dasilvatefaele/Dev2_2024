# Calcolatrice semplice
Scrivere un programma che simuli una calcolatrice semplice.
## Versione 1
### Obiettivo:
- Utente deve poter inserire due numeri e selezionare un operatore matematico (+,-,*,/)
- Il programma deve eseguire l'operazione e stampare il risultato
- Il programma non gestisce nessun tipo di errore o eccezione


> Esempio di codice
```csharp
//* chiedi all'utente di inserire due numeri
double numero1;
double numero2;
double risultato = -1;

//Dialogo
Console.Clear();
Console.WriteLine("Inserisci numeri:");
Console.Write("> ");
numero1 = double.Parse(Console.ReadLine());
Console.Write("> ");
numero2 = double.Parse(Console.ReadLine());

//* chiedi all'utente di selezionare operatore matematico
Console.WriteLine("Scegli l'operatore:");
Console.WriteLine("\n+\t-\t*\t/\n");
Console.Write("> ");
char operatore = Console.ReadKey().KeyChar; 
// acquisizione char singolo, non richiede l'invio per l'inserimento
Console.WriteLine(); 
// a capo

//* esegui l'operazione selezionata
switch (operatore)
{
    case '+':
        risultato = numero1+numero2;
        break;
    case '-':
        risultato = numero1-numero2;
        break;
    case '*':
        risultato = numero1*numero2;
        break;
    case '/':
        risultato = numero1/numero2;
        break;
    default:
        Console.WriteLine("Operatore non valido");
        break;
}

//* stampa risultato
Console.WriteLine($"= {risultato}");
```

> Comandi di versionamento
```powershell
git add --all
git commit -m "03 calcolatrice v1"
git push -u origin main
```

## Versione 2
### Obiettivo
- Gestione degli errori per evitare crash del programma 
    - se utente inserisce valore non numerico, stampa "inserire valore valido"
    - se utente seleziona operatore non valido, programma stampa "selezionare operatore valido"
    - se utente tenta di dividere per zero, il programma stampa "divisione per zero non consentita"

Inserimento in variabile double:
```
inserimento carattere
- FormatException
```

inserimento in variabile int:
```
divisione per 0
- System.DivideByZeroException:
```

> Esempio di codice
```csharp
double numero1 = 0;
double numero2 = 0;
double risultato = -1;
bool numeroConvertito = true;
bool operatoreValido = true;
bool numero2Valido = true;
char operatore = ' ';

//Dialogo
Console.Clear();
Console.WriteLine("Inserisci numeri:");

// chiedi all'utente di inserire due numeri
//! controllo: numero1
//* che sia un numero con try-catch / do-while
do
{
    Console.Write("n1 => ");
    try
    {
        numero1 = double.Parse(Console.ReadLine());
        numeroConvertito = true;
    }
    catch (FormatException e) // ? andava bene anche (Exception e) generico?
    {
        Console.WriteLine("Errore: inserire valore valido");
        numeroConvertito = false;
    }
}while(!numeroConvertito);

//! controllo: numero2
//* che sia un numero con try-catch / do-while
do
{
    Console.Write("n2 => ");
    try
    {
        numero2 = double.Parse(Console.ReadLine());
        numeroConvertito = true;
    }
    catch (FormatException e)
    {
        Console.WriteLine("Errore: inserire valore valido");
        numeroConvertito = false;
    }
}while(!numeroConvertito);

// chiedi all'utente di selezionare operatore matematico
//! controllo: char operatore
//* inserimento operatore con if-else/do-while
do
{
    Console.WriteLine("Scegli l'operatore:");
    Console.WriteLine("\n+\t-\t*\t/\n");
    Console.Write("> ");
    operatore = Console.ReadKey().KeyChar; 
    if (operatore != '*' && operatore != '+' && operatore != '-' && operatore != '/')
    {
        Console.WriteLine();
        Console.WriteLine("Errore: selezionare operatore valido");
        operatoreValido = false;
    }
    else
    {
        operatoreValido = true;
    }
} while (!operatoreValido);

Console.WriteLine(); // a capo

// esegui l'operazione selezionata
switch (operatore)
{
    case '+':
        risultato = numero1+numero2;
        break;
    case '-':
        risultato = numero1-numero2;
        break;
    case '*':
        risultato = numero1*numero2;
        break;
    case '/':
        //! controllo: double numero2
        //*     if == 0 --> NUMERO NON VALIDO, INSERISCI DI NUOVO FINCHé != 0
        //*     else    --> NUMERO VALIDO, ESEGUI OPERAZIONE
        do
        {
            if (numero2 == 0)
            {
                Console.WriteLine("Errore: Divisione per 0 non consentita");
                numero2Valido = false;
                //! controllo: double numero2
                //* reinserimento e check che sia un numero con try-catch / do-while
                do
                {
                    Console.Write("n2 => ");
                    try
                    {
                        numero2 = double.Parse(Console.ReadLine());
                        numeroConvertito = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Errore: inserire valore valido");
                        numeroConvertito = false;
                    }
                }while(!numeroConvertito);
            }
            else
            {
                risultato = numero1/numero2;
                numero2Valido = true;
            }
        } while (!numero2Valido);
        break;
    default:
        Console.WriteLine("Operatore non valido");
        break;
}

// stampa risultato
Console.WriteLine($"= {risultato}");
```

> comandi di versionamento:
```powershell
git add --all
git commit -m "03 calcolatrice v2"
git push -u origin main
```

## Versione 2.1 try-catch-throw

### Esempio di utilizzo del throw 

```csharp
double numero1 = 0;
double numero2 = 0;
double risultato = -1;
bool numeroConvertito = true;
bool operatoreValido = true;
bool numero2Valido = true;
char operatore = ' ';

//Dialogo
Console.Clear();
Console.WriteLine("Inserisci numeri:");

// chiedi all'utente di inserire due numeri
//! controllo: numero1
//* che sia un numero con try-catch / do-while
do
{
    Console.Write("n1 => ");
    try
    {
        numero1 = double.Parse(Console.ReadLine());
        numeroConvertito = true;
    }
    catch (FormatException e) // ? andava bene anche (Exception e) generico?
    {
        Console.WriteLine("Errore: inserire valore valido");
        numeroConvertito = false;
    }
}while(!numeroConvertito);

//! controllo: numero2
//* che sia un numero con try-catch / do-while
do
{
    Console.Write("n2 => ");
    try
    {
        numero2 = double.Parse(Console.ReadLine());
        numeroConvertito = true;
    }
    catch (FormatException e)
    {
        Console.WriteLine("Errore: inserire valore valido");
        numeroConvertito = false;
    }
}while(!numeroConvertito);

// chiedi all'utente di selezionare operatore matematico
//! controllo: char operatore
//* inserimento operatore con if-else/do-while
do
{
    Console.WriteLine("Scegli l'operatore:");
    Console.WriteLine("\n+\t-\t*\t/\n");
    Console.Write("> ");
    operatore = Console.ReadKey().KeyChar; 
    if (operatore != '*' && operatore != '+' && operatore != '-' && operatore != '/')
    {
        Console.WriteLine();
        Console.WriteLine("Errore: selezionare operatore valido");
        operatoreValido = false;
    }
    else
    {
        operatoreValido = true;
    }
} while (!operatoreValido);

Console.WriteLine(); // a capo

// esegui l'operazione selezionata

try
{


    switch (operatore)
    {
        case '+':
            risultato = numero1+numero2;
            break;
        case '-':
            risultato = numero1-numero2;
            break;
        case '*':
            risultato = numero1*numero2;
            break;
        case '/':
            //! controllo: double numero2
            //*     if == 0 --> NUMERO NON VALIDO, INSERISCI DI NUOVO FINCHé != 0
            //*     else    --> NUMERO VALIDO, ESEGUI OPERAZIONE
            do
            {
                if (numero2 == 0)
                {
                    throw new DivideByZeroException ();
                    Console.WriteLine("Errore: Divisione per 0 non consentita");
                    numero2Valido = false;
                    //! controllo: double numero2
                    //* reinserimento e check che sia un numero con try-catch / do-while
                    do
                    {
                        Console.Write("n2 => ");
                        try
                        {
                            numero2 = double.Parse(Console.ReadLine());
                            numeroConvertito = true;
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Errore: inserire valore valido");
                            numeroConvertito = false;
                        }
                    }while(!numeroConvertito);
                }
                else
                {
                    risultato = numero1/numero2;
                    numero2Valido = true;
                }
            } while (!numero2Valido);
            break;
        default:
            Console.WriteLine("Operatore non valido");
            break;
    }
}
catch (DivideByZeroException e)
{
    Console.WriteLine ("Impossibile dividere per 0");

}
// stampa risultato
Console.WriteLine($"= {risultato}");
```

> comandi di versionamento:
```powershell
git add --all
git commit -m "03 calcolatrice v2.1 try-catch-throw"
git push -u origin main
```
