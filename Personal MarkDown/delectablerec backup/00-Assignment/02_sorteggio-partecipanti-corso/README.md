# Sorteggio partecipanti

## Versione 1

## Obiettivo

- Scrivere un programma che permetta di sorteggiare i partecipanti del corso da una lista di nomi.
- I nomi vengono gestiti senza un inserimento da parte dell utente cioe vengono inzializzati nel programma.
- Il programma estrae un partecipante singolo alla volta e lo stampa a video.

```csharp
string[] partecipanti = new string[] { "Partecipante 1", "Partecipante 2", "Partecipante 3" }; //creo un array di stringhe con i nomi dei partecipanti

Random random = new Random(); //creo un oggetto Random per generare numeri casuali
int index = random.Next(partecipanti.Length); //genero un indice casuale
string partecipante = partecipanti[index]; //estraggo il partecipante
Console.WriteLine(partecipante); //stampo il partecipante
```

## Comandi di versionamento

```bash
git add --all
git commit -m "Sorteggia Partecipanti Versione 1"
git push -u origin main
```

## Versione 2

## Obiettivo

- Scrivere un programma che permetta di sorteggiare piu volte i partecipanti del corso da una lista di nomi.
- Il programma deve chiedere all utente se vuole estrarre un altro partecipante.
- I nomi dei partecipanti estratti vengono rimossi dalla lista.

```csharp
// creo la lista dei partecipanti
List<string> partecipanti = new List<string> { "Partecipante 1", "Partecipante 2", "Partecipante 3" };

// creo un oggetto Random per generare numeri casuali
Random random = new Random();

// pulisco la console
Console.Clear();
// ciclo finche l'utente vuole estrarre un partecipante
while (true)
{
    // controllo se ci sono ancora partecipanti
    if (partecipanti.Count == 0)
    {
        Console.WriteLine("Non ci sono piu partecipanti da estrarre");
        break;
    }
    // estraggo un indice casuale
    int index = random.Next(partecipanti.Count);

    // estraggo il partecipante
    string partecipante = partecipanti[index];

    // stampo il partecipante
    Console.WriteLine(partecipante);

    // rimuovo il partecipante dalla lista
    partecipanti.RemoveAt(index);

    // chiedo all'utente se vuole estrarre un altro partecipante
    Console.WriteLine("Vuoi estrarre un altro partecipante? (s/n)");
    string risposta = Console.ReadLine();
    // pulisco la console
    Console.Clear();
    if (risposta != "s")
    {
        break;
    }
}
```

## Comandi di versionamento

```bash
git add --all
git commit -m "Sorteggia Partecipanti Versione 2"
git push -u origin main
```

## Versione 3

## Obiettivo

- Scrivere un programma che permetta di sorteggiare i partecipanti del corso da una lista di nomi dividendoli in gruppi.
- Il programma deve chiedere all utente il numero di squadre.
- Se il numero dei partecipanti non è divisibile per il numero di squadre, i partecipanti rimanenti vengono assegnati ad un gruppo in modo casuale.

```csharp
// creo la lista dei partecipanti
List<string> partecipanti = new List<string> { "Partecipante 1", "Partecipante 2", "Partecipante 3", "Partecipante 4", "Partecipante 5", "Partecipante 6", "Partecipante 7", "Partecipante 8", "Partecipante 9", "Partecipante 10" };

// creo un oggetto Random per generare numeri casuali
Random random = new Random();

// chiedo all'utente il numero di squadre
Console.WriteLine("Inserisci il numero di squadre:");
int numeroSquadre = int.Parse(Console.ReadLine());

// creo un array di liste di stringhe per le squadre
List<string>[] squadre = new List<string>[numeroSquadre];

// per ogni squadra creo una lista vuota
for (int i = 0; i < numeroSquadre; i++)
{
    squadre[i] = new List<string>();
}

// calcolo quanti partecipanti ci sono in ogni squadra
int partecipantiPerSquadra = partecipanti.Count / numeroSquadre;

// se il numero di partecipanti non è divisibile per il numero di squadre, aggiungo un partecipante in piu ad una squadra

// calcolo quanti partecipanti ci sono in piu
int partecipantiInPiu = partecipanti.Count % numeroSquadre;

// per ogni squadra
for (int i = 0; i < numeroSquadre; i++)
{
    // per ogni partecipante della squadra

    for (int j = 0; j < partecipantiPerSquadra; j++)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
    }

    // se ci sono partecipanti in piu, aggiungo un partecipante in piu alla squadra corrente
    if (partecipantiInPiu > 0)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
        // decremento il numero di partecipanti in piu
        partecipantiInPiu--;
    }

    // stampo i partecipanti della squadra
    Console.WriteLine($"Squadra {i + 1}:");
    foreach (string partecipante in squadre[i])
    {
        Console.WriteLine(partecipante);
    }
    Console.WriteLine();
}
```

## Comandi di versionamento

```bash
git add --all
git commit -m "Sorteggia Partecipanti Versione 3"
git push -u origin main
```

## Versione 4

## Obiettivo

- Scrivere un programma che permetta di sorteggiare i partecipanti del corso da una lista di nomi dividendo i partecipanti in gruppi.
- Il programma deve usare un dizionario che ha come chiavi i numeri delle squadre e come valori le liste dei partecipanti di ogni squadra.

```csharp
// creo la lista dei partecipanti
List<string> partecipanti = new List<string> { "Partecipante 1", "Partecipante 2", "Partecipante 3", "Partecipante 4", "Partecipante 5", "Partecipante 6", "Partecipante 7", "Partecipante 8", "Partecipante 9", "Partecipante 10" };

// creo un oggetto Random per generare numeri casuali
Random random = new Random();

// chiedo all'utente il numero di squadre
Console.WriteLine("Inserisci il numero di squadre:");
int numeroSquadre = int.Parse(Console.ReadLine());

// creo un dizionario per le squadre
Dictionary<int, List<string>> squadre = new Dictionary<int, List<string>>();

// per ogni squadra
for (int i = 0; i < numeroSquadre; i++)
{
    // aggiungo la squadra al dizionario
    squadre.Add(i + 1, new List<string>());
}

// calcolo quanti partecipanti ci sono in ogni squadra
int partecipantiPerSquadra = partecipanti.Count / numeroSquadre;

// se il numero di partecipanti non è divisibile per il numero di squadre, aggiungo un partecipante in piu ad una squadra
int partecipantiInPiu = partecipanti.Count % numeroSquadre;

// per ogni squadra
for (int i = 0; i < numeroSquadre; i++)
{
    // aggiungo i partecipanti
    for (int j = 0; j < partecipantiPerSquadra; j++)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i + 1].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
    }

    // se ci sono partecipanti in piu, aggiungo un partecipante in piu alla squadra corrente
    if (partecipantiInPiu > 0)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i + 1].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
        // decremento il numero di partecipanti in piu
        partecipantiInPiu--;
    }

    // stampo i partecipanti della squadra
    Console.WriteLine($"Squadra {i + 1}:");
    foreach (string partecipante in squadre[i + 1])
    {
        Console.WriteLine(partecipante);
    }
    Console.WriteLine();
}
```

## Comandi di versionamento

```bash
git add --all
git commit -m "Sorteggia Partecipanti Versione 4"
git push -u origin main
```

## Versione 5

## Obiettivo

- Scrivere un programma che permetta di sorteggiare i partecipanti del corso da una lista di nomi dividendo i partecipanti in gruppi.
- Il programma deve stampare la lista dei partecipanti
- Il programma deve chiedere all utente di inserire o eliminare un partecipante presente nella lista iniziale o fare il sorteggio

```csharp
// creo la lista dei partecipanti
List<string> partecipanti = new List<string> { "Partecipante 1", "Partecipante 2", "Partecipante 3", "Partecipante 4", "Partecipante 5", "Partecipante 6", "Partecipante 7", "Partecipante 8", "Partecipante 9", "Partecipante 10" };

// creo un oggetto Random per generare numeri casuali
Random random = new Random();

// pulisco la console
Console.Clear();

// stampo la lista dei partecipanti
Console.WriteLine("Partecipanti:");
foreach (string partecipante in partecipanti)
{
    Console.WriteLine(partecipante);
}

// chiedo all utente se vuole inserire o eliminare un partecipante o sorteggiare i partecipanti
while (true)
{
    Console.WriteLine("Vuoi inserire un partecipante, eliminare un partecipante o sorteggiare i partecipanti? (i/e/s)");
    string risposta = Console.ReadLine();
    // pulisco la console
    Console.Clear();
    if (risposta == "i")
    {
        Console.WriteLine("Inserisci il nome del partecipante:");
        string partecipante = Console.ReadLine();
        partecipanti.Add(partecipante);
    }
    else if (risposta == "e")
    {
        Console.WriteLine("Inserisci il nome del partecipante:");
        string partecipante = Console.ReadLine();
        partecipanti.Remove(partecipante);
    }
    else if (risposta == "s")
    {
        // chiedo all'utente il numero di squadre
        Console.WriteLine("Inserisci il numero di squadre:");
        int numeroSquadre = int.Parse(Console.ReadLine());

        // creo una lista per ogni squadra
        List<string>[] squadre = new List<string>[numeroSquadre];
        for (int i = 0; i < numeroSquadre; i++)
        {
            squadre[i] = new List<string>();
        }

        // calcolo quanti partecipanti ci sono in ogni squadra
        int partecipantiPerSquadra = partecipanti.Count / numeroSquadre;

        // se il numero di partecipanti non è divisibile per il numero di squadre, aggiungo un partecipante in piu ad una squadra
        int partecipantiInPiu = partecipanti.Count % numeroSquadre;

        // per ogni squadra
        for (int i = 0; i < numeroSquadre; i++)
        {
            // aggiungo i partecipanti
            for (int j = 0; j < partecipantiPerSquadra; j++)
            {
                // genero un numero casuale tra 0 e il numero di partecipanti rimasti
                int index = random.Next(partecipanti.Count);
                // aggiungo il partecipante alla squadra
                squadre[i].Add(partecipanti[index]);
                // rimuovo il partecipante dalla lista dei partecipanti
                partecipanti.RemoveAt(index);
            }

            // se ci sono partecipanti in piu, aggiungo un partecipante in piu alla squadra corrente
            if (partecipantiInPiu > 0)
            {
                // genero un numero casuale tra 0 e il numero di partecipanti rimasti
                int index = random.Next(partecipanti.Count);
                // aggiungo il partecipante alla squadra
                squadre[i].Add(partecipanti[index]);
                // rimuovo il partecipante dalla lista dei partecipanti
                partecipanti.RemoveAt(index);
                // decremento il numero di partecipanti in piu
                partecipantiInPiu--;
            }

            // stampo i partecipanti della squadra
            Console.WriteLine($"Squadra {i + 1}:");
            foreach (string partecipante in squadre[i])
            {
                Console.WriteLine(partecipante);
            }
            Console.WriteLine();
        }
        break;
    }
    // stampo la lista dei partecipanti
    Console.WriteLine("Partecipanti:");
    foreach (string partecipante in partecipanti)
    {
        Console.WriteLine(partecipante);
    }
}
```

## Comandi di versionamento

```bash
git add --all
git commit -m "Sorteggia Partecipanti Versione 5"
git push -u origin main
```