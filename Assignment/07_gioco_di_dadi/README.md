# GIOCO DI DADI

## Versione 1

```Mermaid
flowchart LR

id0((inizio Dialogo))-->id1[/UTENTE lancia dado
*random da 1 a 6*/]
id1-->id2[COMPUTER lancia dado 
*random da 1 a 6*]
id2-->id10[STAMPA lancio]
id10-->|confronto|id3{UTENTE > COMPUTER}
id3-->|si|id4[Hai vinto!]
id3-->|no|id5[Hai perso!]
id4-->id6{Giocare di nuovo?}
id5-->id6
id6-->|no|id7((fine))
id6-->|si|id1
```


### Obiettivo
- implementare un gioco di dadi umano coontro computer
- il giocatore e il computer lanciano un dado a 6 facce
- il punteggio più alto vince
- il gioco chiede all'utente se vuole continuare a giocare
- il gioco in questa versione viene realizzato senza funzioni


> Codice:
```csharp
Console.Clear();

Random random = new Random();
int dadoComputer;
int dadoUtente;
char risposta = ' ';

do
{
    Console.Clear();

    // DIALOGO
    Console.WriteLine("*** GIOCO: LANCIA DADO ***");
    Console.WriteLine("Premi un tasto per lanciare il dado...");
    Console.ReadKey();
    risposta = ' '; // inizializzo risposta

    dadoUtente = random.Next(1,7); // UTENTE lancia dado
    dadoComputer = random.Next(1,7); // COMPUTER lancia dado
    
    // DISPLAY DADI
    Console.WriteLine($"IL TUO DADO\t\tDADO COMPUTER\n{dadoUtente}\t\t\t{dadoComputer}");
    
    // CONFRONTO
    if(dadoUtente > dadoComputer)
    {
        Console.WriteLine("Hai vinto!");
    }
    else if (dadoUtente == dadoComputer)
    {
        Console.WriteLine("Pareggio!");
    }
    else
    {
        Console.WriteLine("Hai perso!");
    }

    do
    {
        Console.WriteLine("\nVuoi giocare di nuovo? [s/n]");
        Console.Write("> ");
        risposta = Console.ReadKey().KeyChar;
    }while (risposta != 's' && risposta != 'n');

}while (risposta == 's');

Console.WriteLine("\nGrazie per aver giocato!");
```



## Versione 2

### Obiettivi

- Semplificare codice con funzioni

> Codice:
```csharp

Console.Clear();

int dadoComputer;
int dadoUtente;
char risposta = ' ';

do
{
    Console.Clear();
    risposta = ' '; // inizializzo risposta

    // DIALOGO
    Console.WriteLine("*** GIOCO: LANCIA DADO ***");
    Console.WriteLine("Premi un tasto per lanciare il dado...");
    Console.ReadKey();
    
    dadoUtente = LancioDado(); // UTENTE lancia dado
    dadoComputer = LancioDado(); // COMPUTER lancia dado

    StampaLancio(dadoComputer, dadoUtente);    
    Confronto(dadoComputer, dadoUtente);
    risposta = PlayAgain(risposta);
    
}while (risposta == 's');

Console.WriteLine("\nGrazie per aver giocato!");

int LancioDado()
{
    Random random = new Random();
    return random.Next(1,7);
}

void Confronto(int dadoComputer, int dadoUtente)
{
    // CONFRONTO
    if(dadoUtente > dadoComputer)
    {
        Console.WriteLine("Hai vinto!");
    }
    else if (dadoUtente == dadoComputer)
    {
        Console.WriteLine("Pareggio!");
    }
    else
    {
        Console.WriteLine("Hai perso!");
    }

}

void StampaLancio(int dadoComputer, int dadoUtente)
{
    Console.WriteLine($"IL TUO DADO\t\tDADO COMPUTER\n{dadoUtente}\t\t\t{dadoComputer}");
}

char PlayAgain(char risposta)
{
    do
    {
        Console.WriteLine("\nVuoi giocare di nuovo? [s/n]");
        Console.Write("> ");
        risposta = Console.ReadKey().KeyChar;
    }while (risposta != 's' && risposta != 'n');
    return risposta;
}

```

> Comandi di versionamento:
```powershell
git add --all
git commit -m "07 Gioco di dadi v2"
git push -u origin main
```

## Versione 3

> Flowchart aggiornato Versione 3

```Mermaid
flowchart LR

id0((inizio Dialogo))
id1[/UTENTE LancioDado
*random da 1 a 6*/]

id0-->id20[punteggi = PUNTEGGIO_INIZIALE]
id20-->id1
id1-->id2[COMPUTER LancioDado 
*random da 1 a 6*]
id2-->id10[StampaLancio]
id10-->|confronto|id3{UTENTE > COMPUTER}
id3-->|si|id4[Hai vinto!]

id3-->|no|id5[Hai perso!]

id4-->id11[AggiornaPunteggio]
id5-->id11
id11-->id12[StampaPunteggio]
id12-->id6{punteggi finiti?}

id6-->|no - partitaContinua|id1

id6-->|si|id22[Stampa Vincitore]
id22-->id21

id21{PlayAgain}
id21-->|si|id20
id21-->|no
Grazie per aver giocato!|id23((Fine))

```


### Obiettivo
- implementare un sistema di punteggio
    - il giocatore e il computer partono da un punteggio di 100 punti
    - al perdente vengono sottratti 10 punti più la differenza fra i lanci dei dadi 
    - al vincitore vengono assegnati 10 punti più la differenza fra i lanci dei dadi
    
 
> Esempio:
```
utente: 6, computer 3 

punti utente:     6-3 = 3 --> 3 + 10 = 13 --> 100 + 13 = 113
punti computer:   6-3 = 3 --> 3 + 10 = 13 --> 100 - 13 = 87
```
> Codice:
```csharp
Console.Clear();

int dadoComputer;
int dadoUtente;
int [] punteggio = new int [2];
char risposta = ' ';

bool partitaContinua = true;

const int PUNTEGGIO_INIZIALE = 20;
const int UTENTE = 0;
const int COMPUTER = 1;

punteggio[UTENTE] = PUNTEGGIO_INIZIALE;
punteggio[COMPUTER] = PUNTEGGIO_INIZIALE;

do
{
    Console.Clear();
    risposta = ' '; // inizializzo risposta

    StampaDialogo();
    
    dadoUtente =    LancioDado(); // UTENTE lancia dado
    dadoComputer =  LancioDado(); // COMPUTER lancia dado

    StampaLancio(dadoComputer, dadoUtente);    
    Confronto(dadoComputer, dadoUtente);

    punteggio = AggiornaPunteggio(dadoComputer,dadoUtente,punteggio);
    punteggio = StampaPunteggio(punteggio);

    risposta = PlayAgain(risposta, dadoComputer, dadoUtente);

    Console.ReadKey();
    
}while (partitaContinua);

Console.WriteLine("\nGrazie per aver giocato!");

int LancioDado()
{
    Random random = new Random();
    return random.Next(1,7);
}

void Confronto(int dadoComputer, int dadoUtente)
{
    // CONFRONTO
    if(dadoUtente > dadoComputer)
    {
        Console.WriteLine("Hai vinto!");
    }
    else if (dadoUtente == dadoComputer)
    {
        Console.WriteLine("Pareggio!");
    }
    else
    {
        Console.WriteLine("Hai perso!");
    }
}

void StampaLancio(int dadoComputer, int dadoUtente)
{
    Console.WriteLine($"IL TUO DADO\t\tDADO COMPUTER\n{dadoUtente}\t\t\t{dadoComputer}");
}

char PlayAgain(char risposta, int dadoComputer, int dadoUtente)
{
    if(punteggio[COMPUTER] <= 0 || punteggio[UTENTE] <= 0)
    {
        Console.WriteLine("Fine partita!");
        if (punteggio[COMPUTER] > punteggio[UTENTE])
        {
            Console.WriteLine("Hai finito i punti. IL COMPUTER TI HA BATTUTO!");
        }
        else if(punteggio[UTENTE] > punteggio[COMPUTER])
        {
            Console.WriteLine("Il computer ha finito i punti. CONGRATULAZIONI! HAI VINTO!");
        }

        do
        {
            Console.WriteLine("\nVuoi giocare di nuovo? [s/n]");
            Console.Write("> ");
            risposta = Console.ReadKey().KeyChar;
        }while (risposta != 's' && risposta != 'n');
        

        if (risposta == 's')
        {
            punteggio[COMPUTER] = PUNTEGGIO_INIZIALE;
            punteggio[UTENTE] = PUNTEGGIO_INIZIALE;
            partitaContinua = true;
        }
        else
        {
            partitaContinua = false;
        }
    }
    return risposta;
}

int [] StampaPunteggio(int [] punteggio)
{
    if (punteggio[UTENTE] <= 0)
    {
        punteggio[UTENTE] = 0;
        Console.WriteLine($"\nIL TUO PUNTEGGIO\tPUNTEGGIO COMPUTER\n{punteggio[UTENTE]}\t\t\t{punteggio[COMPUTER]}");
    }
    else if (punteggio[COMPUTER] <= 0)
    {
        punteggio[COMPUTER] = 0;
        Console.WriteLine($"\nIL TUO PUNTEGGIO\tPUNTEGGIO COMPUTER\n{punteggio[UTENTE]}\t\t\t{punteggio[COMPUTER]}");
    }
    else
    {
        Console.WriteLine($"\nIL TUO PUNTEGGIO\tPUNTEGGIO COMPUTER\n{punteggio[UTENTE]}\t\t\t{punteggio[COMPUTER]}");
    }

    return punteggio;
}

int [] AggiornaPunteggio(int dadoComputer, int dadoUtente, int [] punteggio)
{
    int differenza = Math.Abs(dadoComputer - dadoUtente);

    if(dadoUtente > dadoComputer)
    {
        punteggio[UTENTE]   += 10 + differenza;
        punteggio[COMPUTER] -= 10 + differenza;
    }
    else if (dadoUtente < dadoComputer)
    {
        punteggio[UTENTE]   -= 10 + differenza;
        punteggio[COMPUTER] += 10 + differenza;
    }

    if (punteggio[UTENTE] <= 0)
    {
        punteggio[UTENTE] = 0;
    }
    
    if (punteggio[COMPUTER] <= 0)
    {
        punteggio[COMPUTER] = 0;
    }

    return punteggio;
}

void StampaDialogo()
{
    Console.WriteLine("*** GIOCO: LANCIA DADO ***");
    Console.WriteLine("Premi un tasto per lanciare il dado...");
    Console.ReadKey();
}
```

> Comandi di versionamento:
```powershell
git add --all
git commit -m "07 Gioco di dadi v3"
git push -u origin main
```

## Versione 4

> Flowchart aggiornato Versione 4

```Mermaid
flowchart LR

id0((inizio Dialogo))
id1[/UTENTE LancioDado
*random da 1 a 6*/]

id0-->id20[punteggi = PUNTEGGIO_INIZIALE]
id20-->id1
id1-->id2[COMPUTER LancioDado 
*random da 1 a 6*]
id2-->id10[StampaLancio]
id10-->|confronto|id3{UTENTE > COMPUTER}
id3-->|si|id4[Hai vinto!]

id3-->|no|id5[Hai perso!]

id4-->id11[AggiornaPunteggio]
id5-->id11
id11-->id12[StampaPunteggio]

id12-->id24[Aggiungi storico]
id24-->id6{punteggi finiti?}

id6-->|no - partitaContinua|id1

id6-->|si|id22[Stampa Vincitore]

id22-->id42
id42[Stampa storico]-->id21

id21{PlayAgain}-->|no - Grazie per aver giocato|id23((fine))
id21-->|si - Pulisci Storico|id20

```

### Obiettivo

- implementare lo storico dei punteggi 
- a fine partita viene stampato lo storico dei punteggi del giocatore e del computer 
- Mostra lo storico solo dell'ultima partita

**Migliorie Aggiuntive**

- Migliorate visualizzazioni 

#### Elenco Funzioni:
```csharp
int LancioDado()
void Confronto(int dadoComputer, int dadoUtente)
void StampaLancio(int dadoComputer, int dadoUtente)
char PlayAgain(char risposta, int[] punteggio, List<int[]> storicoPunteggi)
void StampaPunteggio(int [] punteggio)
int [] AggiornaPunteggio(int dadoComputer, int dadoUtente, int [] punteggio)
void StampaDialogo()
void StampaStorico(List<int[]>storicoPunteggi) // Implementazione v4
```

#### Main:
```csharp
Console.Clear();

char risposta = ' ';
int dadoUtente;
int dadoComputer;
int [] punteggio = new int [2];
bool partitaContinua = true;

const int UTENTE = 0;
const int COMPUTER = 1;
const int PUNTEGGIO_INIZIALE = 20;

List<int[]> storicoPunteggi = new List<int[]> ();

punteggio[UTENTE] = PUNTEGGIO_INIZIALE;
punteggio[COMPUTER] = PUNTEGGIO_INIZIALE;

do
{
    Console.Clear();
    risposta = ' '; 

    StampaDialogo();
    
    dadoUtente =    LancioDado(); 
    dadoComputer =  LancioDado(); 

    StampaLancio(dadoComputer, dadoUtente);    
    Confronto(dadoComputer, dadoUtente);

    punteggio = AggiornaPunteggio(dadoComputer,dadoUtente,punteggio);
    StampaPunteggio(punteggio);

    storicoPunteggi.Add((int[])punteggio.Clone()); // Salva il punteggio nello storico
     
    risposta = PlayAgain(risposta,  punteggio, storicoPunteggi);

    Console.ReadKey();
    
}while (partitaContinua);

StampaStorico(storicoPunteggi);

Console.WriteLine("\nGrazie per aver giocato!");
Console.WriteLine();
```

**NOTE**:
```csharp
// Corretto:
storicoPunteggi.Add((int[])punteggio.Clone());

// Non corretto:
storicoPunteggi.Add(punteggio);
```

Per il corretto funzionamento è stato necessario `(int[])punteggio.Clone()` affinché il metodo `.Add` salvasse
uno screenshot della variabile `int punteggio[]`.


#### Funzioni:

```csharp
int LancioDado()
{
    Random random = new Random();
    return random.Next(1,7);
}

void Confronto(int dadoComputer, int dadoUtente)
{
    // CONFRONTO
    if(dadoUtente > dadoComputer)
    {
        Console.WriteLine("Hai vinto!");
    }
    else if (dadoUtente == dadoComputer)
    {
        Console.WriteLine("Pareggio!");
    }
    else
    {
        Console.WriteLine("Hai perso!");
    }
}

void StampaLancio(int dadoComputer, int dadoUtente)
{
    Console.WriteLine($"IL TUO DADO\t\tDADO COMPUTER\n{dadoUtente}\t\t\t{dadoComputer}");
}

char PlayAgain(char risposta, int[] punteggio, List<int[]> storicoPunteggi)
{
    if(punteggio[COMPUTER] <= 0 || punteggio[UTENTE] <= 0)
    {
        Console.WriteLine("Fine partita!");
        if (punteggio[COMPUTER] > punteggio[UTENTE])
        {
            Console.WriteLine("Hai finito i punti. IL COMPUTER TI HA BATTUTO!");
            Console.WriteLine();
        }
        else if(punteggio[UTENTE] > punteggio[COMPUTER])
        {
            Console.WriteLine("Il computer ha finito i punti. CONGRATULAZIONI! HAI VINTO!");
            Console.WriteLine();
        }

        Console.WriteLine("===================================");

        do
        {
            Console.WriteLine("\nVuoi giocare di nuovo? [s/n]");
            Console.Write("> ");
            risposta = Console.ReadKey().KeyChar;
        }while (risposta != 's' && risposta != 'n');
        

        if (risposta == 's')
        {
            punteggio[COMPUTER] = PUNTEGGIO_INIZIALE;
            punteggio[UTENTE] = PUNTEGGIO_INIZIALE;
            storicoPunteggi.Clear();
            partitaContinua = true;
        }
        else
        {
            partitaContinua = false;
        }
    }
    return risposta;
}

void StampaPunteggio(int [] punteggio)
{
    Console.WriteLine("===================================");
    Console.WriteLine($"\nIL TUO PUNTEGGIO\tPUNTEGGIO COMPUTER\n{punteggio[UTENTE]}\t\t\t{punteggio[COMPUTER]}");
    Console.WriteLine();
}

int [] AggiornaPunteggio(int dadoComputer, int dadoUtente, int [] punteggio)
{
    int differenza = Math.Abs(dadoComputer - dadoUtente);

    if(dadoUtente > dadoComputer)
    {
        punteggio[UTENTE]   += 10 + differenza;
        punteggio[COMPUTER] -= 10 + differenza;
    }
    else if (dadoUtente < dadoComputer)
    {
        punteggio[UTENTE]   -= 10 + differenza;
        punteggio[COMPUTER] += 10 + differenza;
    }

    if (punteggio[UTENTE] <= 0)
    {
        punteggio[UTENTE] = 0;
    }
    
    if (punteggio[COMPUTER] <= 0)
    {
        punteggio[COMPUTER] = 0;
    }

    return punteggio;
}

void StampaDialogo()
{
    Console.WriteLine("*** GIOCO: LANCIA DADO ***");
    Console.WriteLine("Premi un tasto per lanciare il dado...");
    Console.WriteLine();
    Console.ReadKey();
}

void StampaStorico(List<int[]>storicoPunteggi)
{
    Console.WriteLine();
    Console.WriteLine("\tStorico punteggi:");
    Console.WriteLine();
    Console.WriteLine("\t\tTU\tCOMPUTER");
    for (int i = 0; i < storicoPunteggi.Count; i++)
    {
        Console.Write($"Partita {i+1}:\t");
        Console.WriteLine(string.Join("\t", storicoPunteggi[i]));
    }
}
```



> Comandi di versionamento:
```powershell
git add --all
git commit -m "07 Gioco di dadi v4"
git push -u origin main
```


