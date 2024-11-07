# Sasso, Carta, Forbice
Sviluppa un semplice gioco di "Sasso, Carta, Forbici" contro il computer. Genera casualmente la scelta del computer, quindi confrontala con quella del giocatore usando una serie di condizioni per determinare chi vince. Puoi aggiungere un contatore per tenere traccia dei punteggi.
## v1.0
### Passaggi:
- Generare n int random dove n1 = sasso, n2 = carta, n3 = forbice in `randomPC`
- Acquisire `manoUtente`
- Logica di comparazione
    - SASSO batte FORBICE
    - FORBICE batte CARTA
    - CARTA batte SASSO

### Traduzione della logica di comparazione in codice


<details>
<summary>Versione 1.0</summary>


```csharp
Console.Clear();
Random random = new Random();
int numUser;

string manoPC = "";
string manoUser = "";
int randomPC;

randomPC = random.Next(1,4); // da 1 a 3

Console.WriteLine("[1] SASSO\t[2] CARTA\t [3] FORBICE");
Console.WriteLine("Scelta:");
numUser = int.Parse(Console.ReadLine());

switch (numUser){
    case 1:
        manoUser = "SASSO";  
    break;
    case 2:
        manoUser = "CARTA"; 
    break;
    case 3:
        manoUser = "FORBICE";
    break;
}

switch (randomPC){
    case 1:
        manoPC = "SASSO";
    break;
    case 2:
        manoPC = "CARTA"; 
    break;
    case 3:
        manoPC = "FORBICE"; 
    break;
}

if (manoUser == "CARTA" && manoPC == "SASSO" || manoUser == "FORBICE" && manoPC == "CARTA" || manoUser == "SASSO" && manoPC == "FORBICE")
{
    Console.WriteLine($"TU\t\tAVVERSARIO");
    Console.WriteLine($"{manoUser}\t\t{manoPC}\n");
    Console.WriteLine("Hai vinto!");
} else {
    Console.WriteLine($"TU\t\tAVVERSARIO");
    Console.WriteLine($"{manoUser}\t\t{manoPC}\n");
    Console.WriteLine("Hai perso!");
}
```
</details>

> Comandi di versionamento:
``` powershell
git add --all
git commit -m "Sasso, Carta, Forbice (v1.0)"
git push -u origin main
```

#### Aggiornamento v1.09
- Codice più leggibile
- Console più pulita
- Commenti

<details>
<summary>Versione 1.09</summmart>

```csharp
// Pulizia Console
Console.Clear();


// Dichiarazione
int numUser;
int randomPC;
string manoUser = "";
string manoPC = "";
Random random = new Random();


// Dialogo
Console.WriteLine("[1] SASSO\t[2] CARTA\t [3] FORBICE");
Console.Write("> ");
numUser = int.Parse(Console.ReadLine());


// Controllo inserimento
while (numUser != 1 && numUser != 2 && numUser != 3)
{

    Console.Clear();
    Console.WriteLine("Inserimento non valido.");
    Console.WriteLine("[1] SASSO\t[2] CARTA\t [3] FORBICE");
    Console.Write("> ");
    numUser = int.Parse(Console.ReadLine());

}


// Assegnazione mano utente 
switch (numUser)
{

    case 1:
        manoUser = "SASSO";  
    break;

    case 2:
        manoUser = "CARTA"; 
    break;

    case 3:
        manoUser = "FORBICE";
    break;

}


// Assegnazione mano PC
randomPC = random.Next(1,4); //
switch (randomPC)
{

    case 1:
        manoPC = "SASSO";
    break;

    case 2:
        manoPC = "CARTA"; 
    break;

    case 3:
        manoPC = "FORBICE"; 
    break;

}


// Dialogo
Console.Clear();
Console.WriteLine("'SASSO, CARTA, FORBICE!'");
Console.WriteLine("Premi un tasto per giocare...");
Console.ReadKey();


// Logica di comparazione
if (manoUser == "CARTA" && manoPC == "SASSO" || manoUser == "FORBICE" && manoPC == "CARTA" || manoUser == "SASSO" && manoPC == "FORBICE")
{

    // Vittoria
    Console.Clear();
    Console.WriteLine($"Tu\t\tAvversario");
    Console.WriteLine($"{manoUser}\t\t{manoPC}\n");
    Console.WriteLine("Hai vinto!\n");

} 
else 
{

    // Sconfitta
    Console.Clear();
    Console.WriteLine($"Tu\t\tAvversario");
    Console.WriteLine($"{manoUser}\t\t{manoPC}\n");
    Console.WriteLine("Hai perso!\n");

}
```

</details>

> Comandi di versionamento:
``` powershell
git add --all
git commit -m "Sasso, Carta, Forbice (v1.09)"
git push -u origin main
```

---
### Obiettivi per la v1.1
- Considerare la condizione di pareggio. Nessuno vince, nessuno perde.
- Inserire il gioco in un ciclo di 5 round `do{}while(contatoreRound != 0)`
    - Creare `int contatoreRound = 5`
    - `contatoreRound--` alla fine di ogni ciclo.
> Comandi di versionamento:
``` powershell
git add --all
git commit -m "Sasso, Carta, Forbice (v1.1)"
git push -u origin main
```
---
### Obiettivi per la v1.2
- Memorizzare e aggiornare punteggio in un array `int[] allPunteggio = allPunteggio [2]` alla fine di ogni ciclo.
    - In `allPunteggio [0]++;` incremento punteggio Avversario 
    - In `allPunteggio [1]++;` incremento punteggio Utente
> Comandi di versionamento:
``` powershell
git add --all
git commit -m "Sasso, Carta, Forbice (v1.2)"
git push -u origin main
```
---
### Obiettivi per la v1.3
- Mostrare punteggio affianco al giocatore e curare il layout.
```
TU: 3   |   AVVERSARIO: 2
        |    
CARTA   |   SASSO
-------------------------
Hai vinto!
```
> Comandi di versionamento:
``` powershell
git add --all
git commit -m "Sasso, Carta, Forbice (v1.3)"
git push -u origin main
```
---
### Obiettivi per la v1.4
- Quando esce dal ciclo `do{}While();` Compara i risultati per decretare il vincitore.
```csharp
if (allPunteggio[0] > allPunteggio[1])
{
    Console.WriteLine("Il tuo avversario ha vinto più mani, hai perso la sfida");
} 
else if (allPunteggio[0] < allPunteggio[1])
{
    Console.WriteLine("Grande! Hai vinto più mani del tuo avversario");
} else {
    Console.WriteLine ("Abbiamo un pareggio!");
}
```
> Comandi di versionamento:
``` powershell
git add --all
git commit -m "Sasso, Carta, Forbice (v1.4)"
git push -u origin main
```