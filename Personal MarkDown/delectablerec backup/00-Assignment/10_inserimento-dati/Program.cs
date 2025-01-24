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