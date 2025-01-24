# Gioco di dadi

## Versione 1

## Obiettivo
- implementare un gioco di dadi umano contro computer.
- il giocatore ed il computer lanciano un dado a 6 facce.
- il punteggio più alto vince.
- il gioco deve chiedere all'utente se vuole continuare a giocare.
- il gioco in questa versione viene realizzato senza funzioni.

```csharp
// gioco di dadi

/*
- implementare un gioco di dadi umano contro computer.
- il giocatore ed il computer lanciano un dado a 6 facce.
- il punteggio più alto vince.
- il gioco deve chiedere all'utente se vuole continuare a giocare.
- il gioco in questa versione viene realizzato senza funzioni.
*/

// pulisco la console
Console.Clear();

// generatore di numeri casuali
Random rnd = new Random();

// creo le variabili per i dadi
int dadoGiocatore;
int dadoComputer;

// continuare a giocare
char giocareAncora;

// inizia il gioco
do
{
    // lancio dei dadi per il giocatore e per il computer
    dadoGiocatore = rnd.Next(1, 7);
    dadoComputer = rnd.Next(1, 7);

    // stampa dei risultati
    Console.WriteLine($"Il giocatore ha lanciato il dado ed ha ottenuto {dadoGiocatore}");
    Console.WriteLine($"Il computer ha lanciato il dado ed ha ottenuto {dadoComputer}");

    // determinazione del vincitore
    if (dadoGiocatore > dadoComputer)
    {
        Console.WriteLine("Il giocatore ha vinto!");
    }
    else if (dadoGiocatore < dadoComputer)
    {
        Console.WriteLine("Il computer ha vinto!");
    }
    else
    {
        Console.WriteLine("Pareggio!");
    }

    // chiedere all'utente se vuole continuare a giocare
    Console.WriteLine("Vuoi giocare ancora? (s/n)");
    // leggo la risposta
    giocareAncora = Console.ReadKey().KeyChar;

    // a capo
    Console.WriteLine();

    // pulisco la console
    Console.Clear();
} while (giocareAncora == 's' || giocareAncora == 'S');
```

## Versione 2

## Obiettivo
- implementare l uso delle funzioni.

## Funzioni che e possibile implementare

- `int LancioDado()` che restituisce un numero casuale tra 1 e 6.
-'void StampaRisultatoLancio(int dadoGiocatore, int dadoComputer)` che stampa il risultato del lancio dei dadi.
- `void DeterminaVincitore(int dadoGiocatore, int dadoComputer)` che determina il vincitore tra il giocatore ed il computer.
- `char VuoiGiocareAncora()` che chiede all'utente se vuole continuare a giocare.

```csharp
// gioco di dadi

/*
- implementare un gioco di dadi umano contro computer.
- il giocatore ed il computer lanciano un dado a 6 facce.
- il punteggio più alto vince.
- il gioco deve chiedere all'utente se vuole continuare a giocare.
- il gioco in questa versione viene realizzato con funzioni.
*/

// pulisco la console
Console.Clear();

// generatore di numeri casuali
Random rnd = new Random();

// funzione per il lancio del dado
int LancioDado()
{
    return rnd.Next(1, 7);
}

// funzione per stampare il risultato del lancio
void StampaRisultatoLancio(int dadoGiocatore, int dadoComputer)
{
    Console.WriteLine($"Il giocatore ha lanciato il dado ed ha ottenuto {dadoGiocatore}");
    Console.WriteLine($"Il computer ha lanciato il dado ed ha ottenuto {dadoComputer}");
}

// funzione per determinare il vincitore
void DeterminaVincitore(int dadoGiocatore, int dadoComputer)
{
    if (dadoGiocatore > dadoComputer)
    {
        Console.WriteLine("Il giocatore ha vinto!");
    }
    else if (dadoGiocatore < dadoComputer)
    {
        Console.WriteLine("Il computer ha vinto!");
    }
    else
    {
        Console.WriteLine("Pareggio!");
    }
}

// funzione per chiedere all'utente se vuole continuare a giocare
char VuoiGiocareAncora()
{
    Console.WriteLine("Vuoi giocare ancora? (s/n)");
    return Console.ReadKey().KeyChar;
}

// continuare a giocare
char giocareAncora;

// inizia il gioco
do
{
    // lancio dei dadi per il giocatore e per il computer
    int dadoGiocatore = LancioDado();
    int dadoComputer = LancioDado();

    // stampa dei risultati
    StampaRisultatoLancio(dadoGiocatore, dadoComputer);

    // determinazione del vincitore
    DeterminaVincitore(dadoGiocatore, dadoComputer);

    // chiedere all'utente se vuole continuare a giocare
    giocareAncora = VuoiGiocareAncora();

    // a capo
    Console.WriteLine();

    // pulisco la console
    Console.Clear();
} while (giocareAncora == 's' || giocareAncora == 'S');
```

## Versione 3

## Obiettivo

- implementare un sistema di punteggio.
- il giocatore ed il computer partono da un punteggio di 100 punti
- al vincitore vengono assegnati 10 pumnti piu la differenza fra il lancio del dado del giocatore e del computer.
- al perdente vengono sottratti 10 punti piu la differenza fra il lancio del dado del giocatore e del computer.
- ad esempio se il giocatore fa 6 ed il computer fa 3 il giocatore vince e guadagna 10 + 3 andando a 113 punti mentre il computer perde 10 + 3 andando a 87 punti.
- il gioco termina quando il giocatore o il computer raggiungono 0 punti o va sotto zero.

```csharp
// gioco di dadi

/*
- implementare un sistema di punteggio.
- il giocatore ed il computer partono da un punteggio di 100 punti
- al vincitore vengono assegnati 10 pumnti piu la differenza fra il lancio del dado del giocatore e del computer.
- al perdente vengono sottratti 10 punti piu la differenza fra il lancio del dado del giocatore e del computer.
- ad esempio se il giocatore fa 6 ed il computer fa 3 il giocatore vince e guadagna 10 + 3 andando a 113 punti mentre il computer perde 10 + 3 andando a 87 punti.
- il gioco termina quando il giocatore o il computer raggiungono 0 punti o va sotto zero.
*/

// pulisco la console
Console.Clear();

// generatore di numeri casuali
Random rnd = new Random();

// continuare a giocare
char giocareAncora;

// punteggio del giocatore e del computer
int punteggioGiocatore = 100;
int punteggioComputer = 100;

// inizia il gioco
do
{
    // lancio dei dadi per il giocatore e per il computer
    int dadoGiocatore = LancioDado();
    int dadoComputer = LancioDado();

    // stampa dei risultati
    StampaRisultatoLancio(dadoGiocatore, dadoComputer);

    // determinazione vincitore con out
    DeterminaVincitore(dadoGiocatore, dadoComputer, out punteggioGiocatore, out punteggioComputer);

    // stampa del punteggio
    StampaPunteggio(punteggioGiocatore, punteggioComputer);

    // chiedere all'utente se vuole continuare a giocare
    giocareAncora = VuoiGiocareAncora();

    // a capo
    Console.WriteLine();

    // pulisco la console
    Console.Clear();
} while (punteggioGiocatore > 0 && punteggioComputer > 0 && (giocareAncora == 's' || giocareAncora == 'S'));

// funzione per determinare il vincitore con out
void DeterminaVincitore(int dadoGiocatore, int dadoComputer, out int punteggioGiocatore, out int punteggioComputer)
{
    punteggioGiocatore = 100;
    punteggioComputer = 100;

    if (dadoGiocatore > dadoComputer)
    {
        punteggioGiocatore += 10 + (dadoGiocatore - dadoComputer);
        punteggioComputer -= 10 + (dadoGiocatore - dadoComputer);
        Console.WriteLine("Il giocatore ha vinto!");
    }
    else if (dadoGiocatore < dadoComputer)
    {
        punteggioGiocatore -= 10 + (dadoComputer - dadoGiocatore);
        punteggioComputer += 10 + (dadoComputer - dadoGiocatore);
        Console.WriteLine("Il computer ha vinto!");
    }
    else
    {
        Console.WriteLine("Pareggio!");
    }
}

// funzione per stampare il punteggio
void StampaPunteggio(int punteggioGiocatore, int punteggioComputer)
{
    Console.WriteLine($"Il punteggio del giocatore è {punteggioGiocatore}");
    Console.WriteLine($"Il punteggio del computer è {punteggioComputer}");
}

// funzione per chiedere all'utente se vuole continuare a giocare
char VuoiGiocareAncora()
{
    Console.WriteLine("Vuoi giocare ancora? (s/n)");
    return Console.ReadKey().KeyChar;
}

// funzione per stampare i risultati del lancio
void StampaRisultatoLancio(int dadoGiocatore, int dadoComputer)
{
    Console.WriteLine($"Il giocatore ha lanciato {dadoGiocatore}");
    Console.WriteLine($"Il computer ha lanciato {dadoComputer}");
}

// funzione per il lancio del dado
int LancioDado()
{
    return rnd.Next(1, 7);
}
```

## Versione 4

## Obiettivo

- implementare lo storico dei punteggi
- a fine partita viene stampato lo storico dei punteggi del giocatore e del computer.
- lo storico comprende solamente i punteggi della partita in corso.

```csharp
// gioco di dadi

/*
- implementare lo storico dei punteggi
- a fine partita viene stampato lo storico dei punteggi del giocatore e del computer.
- lo storico comprende solamente i punteggi della partita in corso.
*/

// pulisco la console
Console.Clear();

// generatore di numeri casuali
Random rnd = new Random();

// continuare a giocare
char giocareAncora;

// punteggio del giocatore e del computer
int punteggioGiocatore = 100;
int punteggioComputer = 100;

// storico dei punteggi
List<int> storicoGiocatore = new List<int>();
List<int> storicoComputer = new List<int>();

// inizia il gioco
do
{
    // lancio dei dadi per il giocatore e per il computer
    int dadoGiocatore = LancioDado();
    int dadoComputer = LancioDado();

    // stampa dei risultati
    StampaRisultatoLancio(dadoGiocatore, dadoComputer);

    // determinazione vincitore con out
    DeterminaVincitore(dadoGiocatore, dadoComputer, out punteggioGiocatore, out punteggioComputer);

    // stampa del punteggio
    StampaPunteggio(punteggioGiocatore, punteggioComputer);

    // aggiungo i punteggi allo storico
    storicoGiocatore.Add(punteggioGiocatore);
    storicoComputer.Add(punteggioComputer);

    // chiedere all'utente se vuole continuare a giocare
    giocareAncora = VuoiGiocareAncora();

    // a capo
    Console.WriteLine();

    // pulisco la console
    Console.Clear();
} while (punteggioGiocatore > 0 && punteggioComputer > 0 && (giocareAncora == 's' || giocareAncora == 'S'));

// stampa dello storico
Console.WriteLine("Storico dei punteggi:");
for (int i = 0; i < storicoGiocatore.Count; i++)
{
    Console.WriteLine($"Lancio {i + 1}: Giocatore {storicoGiocatore[i]} - Computer {storicoComputer[i]}");
}

// funzione per determinare il vincitore con out
void DeterminaVincitore(int dadoGiocatore, int dadoComputer, out int punteggioGiocatore, out int punteggioComputer)
{
    punteggioGiocatore = 100;
    punteggioComputer = 100;

    if (dadoGiocatore > dadoComputer)
    {
        punteggioGiocatore += 10 + (dadoGiocatore - dadoComputer);
        punteggioComputer -= 10 + (dadoGiocatore - dadoComputer);
        Console.WriteLine("Il giocatore ha vinto!");
    }
    else if (dadoGiocatore < dadoComputer)
    {
        punteggioGiocatore -= 10 + (dadoComputer - dadoGiocatore);
        punteggioComputer += 10 + (dadoComputer - dadoGiocatore);
        Console.WriteLine("Il computer ha vinto!");
    }
    else
    {
        Console.WriteLine("Pareggio!");
    }
}

// funzione per stampare il punteggio
void StampaPunteggio(int punteggioGiocatore, int punteggioComputer)
{
    Console.WriteLine($"Il punteggio del giocatore è {punteggioGiocatore}");
    Console.WriteLine($"Il punteggio del computer è {punteggioComputer}");
}

// funzione per chiedere all'utente se vuole continuare a giocare
char VuoiGiocareAncora()
{
    Console.WriteLine("Vuoi giocare ancora? (s/n)");
    return Console.ReadKey().KeyChar;
}

// funzione per stampare i risultati del lancio
void StampaRisultatoLancio(int dadoGiocatore, int dadoComputer)
{
    Console.WriteLine($"Il giocatore ha lanciato {dadoGiocatore}");
    Console.WriteLine($"Il computer ha lanciato {dadoComputer}");
}

// funzione per il lancio del dado
int LancioDado()
{
    return rnd.Next(1, 7);
}
```