# Inserimento dati

## Obiettivo

 Programma in C# che calcola alcune statistiche sui punteggi inseriti dall’utente.

 - L'utente deve poter inserire una serie di punteggi (numeri interi).
 - Il programma deve terminare l'inserimento dei punteggi quando l'utente inserisce un numero negativo.

 Dopo l’inserimento, il programma deve calcolare e mostrare:

- Il numero totale di punteggi inseriti.
- Il punteggio più alto.
- Il punteggio più basso.
- La media dei punteggi.

Se l'utente inserisce solo un numero negativo, il programma deve stampare un messaggio di errore e terminare.

## Suggerimenti

- Usa una lista per memorizzare i punteggi inseriti dall'utente.
- Controlla come vengon gestiti gli input
- Usa i metodi della libreria Math

## Versione 1

```csharp
Console.WriteLine("Inserisci i punteggi del test (termina con un numero negativo):");
List<int> punteggi = new List<int>();

while (true)
{
    if (!int.TryParse(Console.ReadLine(), out int punteggio) || punteggio < 0) break;
    punteggi.Add(punteggio);
}

if (punteggi.Count == 0)
{
    Console.WriteLine("Errore: nessun punteggio valido inserito.");
    return;
}

int max = int.MinValue;
int min = int.MaxValue;
int somma = 0;

foreach (int p in punteggi)
{
    if (p > max) max = p;
    if (p < min) min = p;
    somma += p;
}

Console.WriteLine("Statistiche:");

Console.WriteLine($"Totale punteggi: {punteggi.Count}"); // punteggi.Count restituisce il numero di elementi nella lista
Console.WriteLine($"Punteggio max: {max}"); // max e min sono le variabili che contengono i valori max e min
Console.WriteLine($"Punteggio min: {min}"); // max e min sono le variabili che contengono i valori max e min
// media usando somma
Console.WriteLine($"Media: {(double)somma / punteggi.Count:F2}"); // somma è la variabile che contiene la somma di tutti i punteggi
// media usando average di math
Console.WriteLine($"Media: {punteggi.Average():F2}"); // punteggi.Average() restituisce la media dei punteggi
```