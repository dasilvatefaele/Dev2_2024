# Sorteggio partecipanti con funzioni

## Versione 1

## Obiettivo
- Implementare le funzioni nel programma che simula il sorteggio dei partecipanti.

Programma originale:

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

## Funzioni che e possibile implementare
- `void StampaPartecipanti(List<string> partecipanti)`
- `void InserisciPartecipante(List<string> partecipanti)`
- `void EliminaPartecipante(List<string> partecipanti)`
- `void SorteggiaPartecipanti(List<string> partecipanti, Random random)`
- `void StampaSquadre(List<string>[] squadre)`
- `int ChiediNumeroSquadre()`

## Codice completo

```csharp
// creo la lista dei partecipanti
List<string> partecipanti = new List<string> { "Partecipante 1", "Partecipante 2", "Partecipante 3", "Partecipante 4", "Partecipante 5", "Partecipante 6", "Partecipante 7", "Partecipante 8", "Partecipante 9", "Partecipante 10" };

// creo un oggetto Random per generare numeri casuali
Random random = new Random();

// pulisco la console
Console.Clear();

// stampo la lista dei partecipanti
StampaPartecipanti(partecipanti);

// chiedo all utente se vuole inserire o eliminare un partecipante o sorteggiare i partecipanti
while (true)
{
    Console.WriteLine("Vuoi inserire un partecipante, eliminare un partecipante o sorteggiare i partecipanti? (i/e/s)");
    string risposta = Console.ReadLine();
    // pulisco la console
    Console.Clear();
    if (risposta == "i")
    {
        InserisciPartecipante(partecipanti);
    }
    else if (risposta == "e")
    {
        EliminaPartecipante(partecipanti);
    }
    else if (risposta == "s")
    {
        // chiedo all'utente il numero di squadre
        int numeroSquadre = ChiediNumeroSquadre();

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

        // sorteggio i partecipanti
        SorteggiaPartecipanti(partecipanti, random, squadre, partecipantiPerSquadra, partecipantiInPiu);

        // stampo le squadre
        StampaSquadre(squadre);
        break;
    }
    // stampo la lista dei partecipanti
    StampaPartecipanti(partecipanti);
}

void StampaPartecipanti(List<string> partecipanti)
{
    Console.WriteLine("Partecipanti:");
    foreach (string partecipante in partecipanti)
    {
        Console.WriteLine(partecipante);
    }
}

void InserisciPartecipante(List<string> partecipanti)
{
    Console.WriteLine("Inserisci il nome del partecipante:");
    string partecipante = Console.ReadLine();
    partecipanti.Add(partecipante);
}

void EliminaPartecipante(List<string> partecipanti)
{
    Console.WriteLine("Inserisci il nome del partecipante:");
    string partecipante = Console.ReadLine();
    partecipanti.Remove(partecipante);
}

void SorteggiaPartecipanti(List<string> partecipanti, Random random, List<string>[] squadre, int partecipantiPerSquadra, int partecipantiInPiu)
{
    // per ogni squadra
    for (int i = 0; i < squadre.Length; i++)
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
    }

}

int ChiediNumeroSquadre()
{
    int numeroSquadre = 0;
    bool inputValido = false;
    while (!inputValido)
    {
        try
        {
            Console.Write("Inserisci il numero di squadre: ");
            numeroSquadre = int.Parse(Console.ReadLine());
            inputValido = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserisci un numero valido.");
        }
    }
    return numeroSquadre;
}

void StampaSquadre(List<string>[] squadre)
{
    for (int i = 0; i < squadre.Length; i++)
    {
        Console.WriteLine($"Squadra {i + 1}:");
        foreach (string partecipante in squadre[i])
        {
            Console.WriteLine(partecipante);
        }
        Console.WriteLine();
    }
}
```

## Comandi di versionamento
```bash
git add --all
git commit -m "Implementate funzioni nel programma che simula il sorteggio dei partecipanti"
git push -u origin main
```