# GESTIONE DELLE ECCEZIONI

in C# le eccezioni sono oggetti che rappresentano errori che si verificano durante l'esecuzione di un programma.

Si possono verificare in due modi:
- eccezioni generate dal sistema
- eccezioni generate dal programmatore

Le eccezioni generate dal sistema sono quelle che si verificano quando il sistema operativo o il runtime .NET Framework rilevano un errore che non può essere gestito dal programma.

Gli esempi più comuni sono:
- System.IO.IOException (si verifica quando si tenta di accedere a un file che non esiste)
- System.IndexOutOfRangeException (si verifica quando si tenta di accedere a un elemento di un array con un indice non valido)
- System.NullReferenceException (si verifica quando si tenta di accedere a un oggetto null)
- System.OutOfMemoryException (si verifica quando non c'è abbastanza memoria disponibile)
- System.StackOverflowException (si verifica quando la pila è piena)

Le eccezioni generate dal programmatore sono quelle che si verificano quando il programmatore genera un'eccezione per segnalare un errore.

Gli esempi più comuni sono:
- System.ArgumentException (si verifica quando un argomento di un metodo non è valido)
- System.ArgumentNullException (si verifica quando un argomento di un metodo è null)
- System.ArgumentOutOfRangeException (si verifica quando un argomento di un metodo è fuori dal range consentito)
- System.DivideByZeroException (si verifica quando si tenta di dividere per zero)
- System.InvalidCastException (si verifica quando si tenta di convertire un tipo in un altro tipo non valido)
- System.NotImplementedException (si verifica quando si tenta di usare un metodo non implementato)

Le eccezioni possono essere gestite con il costrutto try-catch-finally.

Oppure in modo più avanzato con il costrutto try-catch-finally-throw.

Le differenze tra i due costrutti sono:
- try-catch-finally: il blocco finally viene sempre eseguito
- try-catch-finally-throw: il blocco finally viene eseguito solo se non viene generata un'eccezione

Il costrutto try-catch-finally-throw è più efficiente perché il blocco finally viene eseguito solo se necessario.

Ecco un esempio di gestione delle eccezioni con il costrutto try-catch-finally:
```c#
try
{
    // codice che può generare un'eccezione
}
catch (Exception e)
{
    // codice che gestisce l'eccezione
}
finally
{
    // codice che viene sempre eseguito
}
```
Ecco un esempio di gestione delle eccezioni con il costrutto try-catch-finally-throw:
```c#
try
{
    // codice che può generare un'eccezione
}
catch (Exception e)
{
    // codice che gestisce l'eccezione
    throw;
}
finally
{
    // codice che viene eseguito solo se non viene generata un'eccezione
}
```
Il costrutto try-catch-finally-throw può essere usato anche in questo modo:
```c#
try
{
    // codice che può generare un'eccezione
}
catch (Exception e)
{
    // codice che gestisce l'eccezione
    throw new Exception("Messaggio di errore", e);
}
finally
{
    // codice che viene eseguito solo se non viene generata un'eccezione
}
```
In questo modo si può passare un messaggio di errore e l'eccezione generata dal sistema.
La principale differenza tra il metodo TryParse e il costrutto try-catch-finally è che il metodo TryParse non genera un'eccezione ma restituisce un valore booleano che indica se la conversione è andata a buon fine o no.
Il try-catch finally invece genera un'eccezione e la gestisce, ad esempio stampando un messaggio di errore personalizzato.

**Quando si usa il try-parse e quando invece è meglio usare il try-catch-finally?**

Se si vuole gestire l'eccezione con un messaggio di errore personalizzato è meglio usare il try-catch-finally.

Se invece non si vuole gestire l'eccezione ma si vuole solo controllare se la conversione è andata a buon fine o no è meglio usare il try-parse.

## Esempi di gestione delle eccezioni

### Vogliamo gestire System.IO.IOException (si verifica quando si tenta di accedere a un file che non esiste)
```c#

try
{
    string contenuto = File.ReadAllText("file.txt"); // il file deve essere nella stessa cartella del programma
    Console.WriteLine(contenuto);
}
catch (Exception e)
{
    Console.WriteLine("Il file non esiste");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
    
```
### Vogliamo gestire System.IndexOutOfRangeException (si verifica quando si tenta di accedere a un elemento di un array con un indice non valido)
```c#

int[] numeri = { 1, 2, 3 };
try
{
    Console.WriteLine(numeri[3]);
}
catch (Exception e)
{
    Console.WriteLine("Indice non valido");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
    
```
### Vogliamo gestire System.NullReferenceException (si verifica quando si tenta di accedere a un oggetto null)
```c#

string nome = null;
try
{
    Console.WriteLine(nome.Length);
}
catch (Exception e)
{
    Console.WriteLine("Il nome non è valido");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
    
```
### Vogliamo gestire System.OutOfMemoryException (si verifica quando non c'è abbastanza memoria disponibile)
```c#

try
{
    int[] numeri = new int[int.MaxValue]; // int.MaxValue è il valore massimo che può contenere un int (2147483647) perciò il programma si blocca
    // arriva fino a 2147483591
}
catch (Exception e)
{
    Console.WriteLine("Memoria insufficiente");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
    
```
### Vogliamo gestire System.StackOverflowException (si verifica quando la pila è piena)
```c#

    try
    {
        StackOverflow(); // il metodo StackOverflow() viene chiamato ricorsivamente perciò la pila si riempie e il programma si blocca
    }
    catch (Exception e)
    {
        Console.WriteLine("StackOverflow");
        Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
        return;
    }
static void StackOverflow()
{
    StackOverflow();
}

```
### Vogliamo gestire System.ArgumentException (si verifica quando un argomento di un metodo non è valido)
```c#

try
{
    int numero = int.Parse("ciao"); // il metodo int.Parse() genera un'eccezione perché "ciao" non è un numero
}
catch (Exception e)
{
    Console.WriteLine("Il numero non è valido");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
    
```
### Vogliamo gestire System.ArgumentNullException (si verifica quando un argomento di un metodo è null)
```c#

try
{
    int numero = int.Parse(null); // il metodo int.Parse() genera un'eccezione perché null non è un numero
}
catch (Exception e)
{
    Console.WriteLine("Il numero non può essere null");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
    
```
### Vogliamo gestire System.ArgumentOutOfRangeException (si verifica quando un argomento di un metodo è fuori dal range consentito)
```c#

try
{
    int numero = int.Parse("1000000000000"); // il metodo int.Parse() genera un'eccezione perché "1 000 000 000 000" è un numero troppo grosso 
}
catch (Exception e)
{
    Console.WriteLine("Il numero è troppo alto");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    return;
}
    
```
### Vogliamo gestire System.DivideByZeroException (si verifica quando si tenta di dividere per zero)
```c#

try
{
    int zero = 0;
    int numero = 1 / zero; // il programma si blocca perché non si può dividere per zero
}
catch (Exception e)
{
    Console.WriteLine("Divisione per zero");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    return;
}
    
```
### Vogliamo gestire System.IO.IOException (si verifica quando si tenta di accedere a un file che non esiste) utilizzando anche il blocco finally in modo da chiudere il file anche se viene generata un'eccezione:
```c#

try
{
    string contenuto = File.ReadAllText("file.txt"); // il file deve essere nella stessa cartella del programma
    Console.WriteLine(contenuto);
}
catch (Exception e)
{
    Console.WriteLine("Il file non esiste");
    return;
}
finally
{
    Console.WriteLine("Il file è stato chiuso");
}
    
```
### Vogliamo gestire System.IndexOutOfRangeException (si verifica quando si tenta di accedere a un elemento di un array con un indice non valido) utilizzando anche il blocco finally in modo da chiudere il file anche se viene generata un'eccezione:
```c#

int[] numeri = { 1, 2, 3 };
try
{
    Console.WriteLine(numeri[3]);
}
catch (Exception e)
{
    Console.WriteLine("Indice non valido");
    return;
}
finally
{
    Console.WriteLine("Il file è stato chiuso");
}
    
```
### Vogliamo gestire System.NullReferenceException (si verifica quando si tenta di accedere a un oggetto null) utilizzando anche il blocco finally in modo da chiudere il file anche se viene generata un'eccezione:
```c#

string nome = null;
try
{
    Console.WriteLine(nome.Length);
}
catch (Exception e)
{
    Console.WriteLine("Il nome non è valido");
    return;
}
finally
{
    Console.WriteLine("Il file è stato chiuso");
}
    
```
## Vogliano verificare che un numero inserito dall'utente sia compreso un intervallo specifico
```csharp

try
{
    Console.Write("Inserisci un numero tra 1 e 100: ");
    int numero = Convert.ToInt32(Console.ReadLine());

    if (numero < 1 || numero > 100)
    {
        throw new ArgumentOutOfRangeException("Il numero deve essere compreso tra 1 e 100.");
    }

    Console.WriteLine($"Il numero inserito è: {numero}");
}
catch (FormatException)
{
    Console.WriteLine("L'input non è un numero valido.");
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.Message);
}
catch (Exception e)
{
    Console.WriteLine($"Si è verificato un errore imprevisto: {e.Message}");
}
    
```
# STAMPARE INFORMAZIONI AGGIUNTIVE RIGUARDANTI L'ERRORE

Console.WriteLine(e.Message); // messaggio dell'eccezione

Console.WriteLine(e.Data); // dati aggiuntivi dell'eccezione

Console.WriteLine(e.HResult); // codice numerico dell'eccezione