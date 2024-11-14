# GIOCO DI DADI

## Versione 1

### Obiettivo
- implementare un gioco di dadi umano coontro computer
- il giocatore e il computer lanciano un dado a 6 facce
- il punteggio più alto vince
- il gioco chiede all'utente se vuole continuare a giocare
- il gioco in questa versione viene realizzato senza funzioni

```Mermaid
flowchart 

id0((inizio))-->id1[/UTENTE lancia dado
*random da 1 a 6*/]
id1-->id2[COMPUTER lancia dado 
*random da 1 a 6*]
id2-->id10[STAMPA risultato]
id10-->|confronto|id3{UTENTE > COMPUTER}
id3-->|si|id4[Hai vinto!]
id3-->|no|id5[Hai perso!]
id4-->id6{Giocare di nuovo?}
id5-->id6
id6-->|no|id7((fine))
id6-->|si|id1
```

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