# Mazzo di carte con Dictionary
### Obiettivo:
- Creare un mazzo di carte con una variabile `Dictionary` di nome `mazzoDiCarte`
- Pescare una carta casuale dal dizionario, aggiungerla a `manoGiocatore` e rimuoverla da `mazzoDiCarte`.
- Verificare che non si sia creato un doppione (se ce l'ho in mano, non è più presente nel mazzo)

### Problemi riscontrati:
La variabile `mazzoDiCarte`, quando la si vuole riempire con le carte (numeri e seme), produce un errore poiché non è possibile attribuire ad un valore la stessa chiave.

```csharp
Dictionary<int, string> mazzoDiCarte = new Dictionary<int, string>();


//inizializzazione array carte
int[] numCarte = new int[13];

for (int i = 1; i <= 13; i++){
    numCarte[i-1] = i;
}

//inizializzazione semi carte
string[] semeCarte = new string[4] {"di Cuori", "di Denari", "di Picche", "di Fiori"};


//Inserimento Carte nel mazzo
foreach (int num in numCarte){
    foreach (string seme in semeCarte){
        mazzoDiCarte.Add(num, seme);
    }
}   
```

### Possibile soluzione 1:
Potrebbe essere utile invertire gli elementi nei `foreach`, in modo da avere 4 chiavi (i semi) e 13 valori per chiave (effettivamente sembra molto più sensato, dato che in questo modo le chiavi non si ripetono, mentre i valori sì).

Per fare ciò serve definire diersamente la variabile `mazzoDiCarte`:
```csharp
Dictionary<string, int> mazzoDiCarte = new Dictionary<string, int>();
```

### Il problema persiste

```powershell
Unhandled exception. System.ArgumentException: An item with the same key has already been added. Key: di Cuori
   at System.Collections.Generic.Dictionary`2.TryInsert(TKey key, TValue value, InsertionBehavior behavior)
   at System.Collections.Generic.Dictionary`2.Add(TKey key, TValue value)
   at Program.<Main>$(String[] args) in /Users/felipeconceicao/_Development/Dev2_2024/esercitazioni_mackbook/mazzo_di_carte_dict/Program.cs:line 38
```

Pare che, sebbene i valori possano essere uguali, il dizionario accetta solo **chiavi univoche**. Non permette dunche di avere "1 di Cuori, 2 di Cuori" dove `1` è `Value` e `di Cuori` è la `Key`. La chiave non si può ripetere.

### Possibile soluzione 2:
Provo a creare una lista di 4 dizionari, ogni dizionario col proprio seme, ma dove la chiave è il numero univoco, e il valore è il seme (sempre lo stesso).

>Esempio di codice:
```csharp

using System.Dynamic;

void CustomDebug(){
    Console.WriteLine("Premi per continuare l'esecuzione...");
    Console.ReadKey();
    return;
}

Dictionary<int,string> diCuori = new Dictionary<int,string>();
Dictionary<int,string> diDenari = new Dictionary<int,string>();
Dictionary<int,string> diPicche = new Dictionary<int,string>();
Dictionary<int,string> diFiori = new Dictionary<int,string>();
List<Dictionary<int,string>> mazzoDiCarte = new List<Dictionary<int,string>>();

//inizializzazione array carte
int[] numCarte = new int[13];
for (int i = 1; i <= 13; i++){
    numCarte[i-1] = i;
}
// Console.WriteLine(string.Join(", ", numCarte)); // Controllo inserimento valore carte (riuscito)

// Inizializzazione per ogni seme
foreach (int num in numCarte){
    diCuori.Add(num, "di Cuori");
}

foreach (int num in numCarte){
    diDenari.Add(num, "di Denari");
}

foreach (int num in numCarte){
    diPicche.Add(num, "di Picche");
}

foreach (int num in numCarte){
    diFiori.Add(num, "di Fiori");
}

// Inizializzazione Lista mazzoDiCarte
mazzoDiCarte.Add(diCuori);
mazzoDiCarte.Add(diFiori);
mazzoDiCarte.Add(diDenari);
mazzoDiCarte.Add(diPicche);

// Stampa mazzoDiCarte
foreach (var seme in mazzoDiCarte){
    foreach (var carta in seme){
        Console.WriteLine($"{carta.Key} {carta.Value}");
    }
}

```
>Output:
```powershell
1 di Cuori
2 di Cuori
3 di Cuori
4 di Cuori
5 di Cuori
6 di Cuori
7 di Cuori
8 di Cuori
9 di Cuori
10 di Cuori
11 di Cuori
12 di Cuori
13 di Cuori
1 di Fiori
2 di Fiori
3 di Fiori
4 di Fiori
5 di Fiori
6 di Fiori
7 di Fiori
8 di Fiori
9 di Fiori
10 di Fiori
11 di Fiori
12 di Fiori
13 di Fiori
1 di Denari
2 di Denari
3 di Denari
4 di Denari
5 di Denari
6 di Denari
7 di Denari
8 di Denari
9 di Denari
10 di Denari
11 di Denari
12 di Denari
13 di Denari
1 di Picche
2 di Picche
3 di Picche
4 di Picche
5 di Picche
6 di Picche
7 di Picche
8 di Picche
9 di Picche
10 di Picche
11 di Picche
12 di Picche
13 di Picche
```

### Soluzione raggiunta:
Per risolvere il problema della univocità delle chiavi ho creato 4 variabili di tipo Dizionario (uno per seme) e le ho inserite in una lista che compone il mazzo di chiave. Per estrapolarne il contenuto ho utilizzato due `foreach` dal quale mi è possibile utilizzare i metodi `.Key`e `.Value` sulla variabile "placeholder".

## Nuovi obiettivi alla luce delle nuove conoscenze 
- Pescare una carta casuale dal dizionario, aggiungerla a `manoGiocatore` e rimuoverla da `mazzoDiCarte`.
- Verificare che non si sia creato un doppione (se ce l'ho in mano, non è più presente nel mazzo)

#### Considerazione 1 :
Per interagire con la variabile `mazzoDiCarte`, ed eseguire operazioni con essa, **ipotizzo** che servirà utilizzare una struttura di cicli di questo tipo:
 ```csharp
 foreach (var seme in mazzoDiCarte){
    foreach (var carta in seme){
        //Console.WriteLine($"{carta.Key} {carta.Value}");
        // OPERAZIONI sulla variabile var carta?
    }
}
 ```
#### Considerazione 2:
**Ipotizzo** che anche la variabile `manoGiocatore` debba avere una struttura di tipo `Lista<Dictionary<int,string>>`. 


#### Considerazione 3:
Suppongo che possano esserci modi più furbi di creare un mazzo di carte, ma proseguo con questo approccio per fini didattici.

#### Considerazione 4: 
Servirà un generatore Random da 1 a `totCarte`, dove quest'utilima parte da 52 quando tutte le carte sono presenti, e si decrementa o incrementa quando una carta viene rimossa o aggiunta al mazzo. Nel ciclo `foreach` sarà dunque necessaria una variabile `contatoreMazzo` 

>**Esempio di codice:** 
```csharp
int totCarte = 53;
int contatoreMazzo = 1; // da incrementare dentro il ciclo
Random random = new Random();
pescaRandom = random.Next(1,totCarte); // da 1 a 52
```

Quando il `contatoreMazzo` sarà uguale a `pescaRandom`, la carta corrispondente verrà pescata, e il range di generazione decrementato: `totCarte--;`.

>**Esempio di codice:** 
```csharp
using System.Collections;
using System.Dynamic;

void CustomDebug(){
    Console.WriteLine("CustomDebug: Premi per continuare l'esecuzione...");
    Console.ReadKey();
    return;
}

Dictionary<int,string> diCuori = new Dictionary<int,string>();
Dictionary<int,string> diDenari = new Dictionary<int,string>();
Dictionary<int,string> diPicche = new Dictionary<int,string>();
Dictionary<int,string> diFiori = new Dictionary<int,string>();
List<Dictionary<int,string>> mazzoDiCarte = new List<Dictionary<int,string>>();


//inizializzazione array carte
int[] numCarte = new int[13];
for (int i = 1; i <= 13; i++){
    numCarte[i-1] = i;
}
// Console.WriteLine(string.Join(", ", numCarte)); // Verifico inserimento valore carte (riuscito)

// Inizializzazione per ogni seme
foreach (int num in numCarte){
    diCuori.Add(num, "di Cuori");
}

foreach (int num in numCarte){
    diDenari.Add(num, "di Denari");
}

foreach (int num in numCarte){
    diPicche.Add(num, "di Picche");
}

foreach (int num in numCarte){
    diFiori.Add(num, "di Fiori");
}

// Inizializzazione Lista mazzoDiCarte
mazzoDiCarte.Add(diCuori);
mazzoDiCarte.Add(diFiori);
mazzoDiCarte.Add(diDenari);
mazzoDiCarte.Add(diPicche);

// Verifico presenza delle carte in mazzoDiCarte // riuscito
/*

foreach (var seme in mazzoDiCarte){
    foreach (var carta in seme){
        Console.WriteLine($"{carta.Key} {carta.Value}");
    }
}
*/

CustomDebug();

int totCarte = 53;
int contatoreMazzo = 1; // da incrementare dentro il ciclo
Random random = new Random();
int pescaRandom = random.Next(1,totCarte); // da 1 a 52
List<Dictionary<int,string>> manoGiocatore = new List<Dictionary<int,string>>(){};
Dictionary<int,string> mano = new Dictionary<int,string>();

Console.WriteLine("Pesca una carta...");
Console.ReadKey();

foreach (var seme in mazzoDiCarte){
   foreach (var carta in seme){
       if (contatoreMazzo == pescaRandom){
        mano.Add(carta.Key, carta.Value);
        manoGiocatore.Add(mano);  
        seme.Remove(carta.Key);
        totCarte--;
       }
       contatoreMazzo++;
   }
}

Console.WriteLine("*** La tua mano: ***");
foreach (var seme in manoGiocatore){
    foreach (var cartaInMano in seme){
        Console.WriteLine($"{cartaInMano.Key} {cartaInMano.Value}");
    }
}


Console.WriteLine("*** Il mazzo: ***");
foreach (var seme in mazzoDiCarte){
    foreach (var carta in seme){
        Console.WriteLine($"{carta.Key} {carta.Value}");
    }
}
```

## Soluzione funzionante (per una carta)
L'output di questo codice restituisce la carta casuale in mano al giocatore, e la rimuove dal mazzo di carte. 

### Possibili complicazioni da verificare:
Dato che per poter spostare un elemento del mazzo, anche la mano del giocatore deve avere la stessa struttura di dati del mazzo di carte, potrebbe esserci la possibilità di conflitto tra chiavi e valori come nei primi tentativi? 
Questo possibile problema è da verificare con l'estrazione di più carte. 

### Obiettivo
Verificare:
- Corretto funzionamento sistema di decremento del range random
- Corretta rimozione dal mazzo
- Eventuali conflitti di Chiave/Valore nella mano giocatore

Per testare serviranno:
- Un loop do-while
- variabile di comando del ciclo

```csharp
string comando; 
do{
    /*
    .
    .
    .
    */
    Console.WriteLine("Debug Data *************");
    Console.WriteLine($"Carte nel mazzo: {TotCarte-1}");
    Console.WriteLine("Debug Data *************");
    Console.WriteLine("Continui?");
    comando = Console.ReadLine();
    comando = comando.ToUpper;
}while(comando != "EXIT");
``` 

>Esempio di codice:
```csharp
using System.Collections;
using System.Dynamic;

void CustomDebug(){
    Console.WriteLine("CustomDebug: Premi per continuare l'esecuzione...");
 //   Console.ReadKey();
    return;
}

Dictionary<int,string> diCuori = new Dictionary<int,string>();
Dictionary<int,string> diDenari = new Dictionary<int,string>();
Dictionary<int,string> diPicche = new Dictionary<int,string>();
Dictionary<int,string> diFiori = new Dictionary<int,string>();
List<Dictionary<int,string>> mazzoDiCarte = new List<Dictionary<int,string>>();

Console.Clear();

//inizializzazione array carte
int[] numCarte = new int[13];
for (int i = 1; i <= 13; i++){
    numCarte[i-1] = i;
}
// Console.WriteLine(string.Join(", ", numCarte)); // Verifico inserimento valore carte (riuscito)

// Inizializzazione per ogni seme
foreach (int num in numCarte){
    diCuori.Add(num, "di Cuori");
}

foreach (int num in numCarte){
    diDenari.Add(num, "di Denari");
}

foreach (int num in numCarte){
    diPicche.Add(num, "di Picche");
}

foreach (int num in numCarte){
    diFiori.Add(num, "di Fiori");
}

// Inizializzazione Lista mazzoDiCarte
mazzoDiCarte.Add(diCuori);
mazzoDiCarte.Add(diFiori);
mazzoDiCarte.Add(diDenari);
mazzoDiCarte.Add(diPicche);

// Verifico presenza delle carte in mazzoDiCarte // riuscito
/*

foreach (var seme in mazzoDiCarte){
    foreach (var carta in seme){
        Console.WriteLine($"{carta.Key} {carta.Value}");
    }
}
*/

CustomDebug();

int totCarte = 53;
int contatoreMazzo = 1; // da incrementare dentro il ciclo
Random random = new Random();
int pescaRandom;

List<Dictionary<int,string>> manoGiocatore = new List<Dictionary<int,string>>(){};
Dictionary<int,string> mano = new Dictionary<int,string>();
string comando; 

do{
    pescaRandom = random.Next(1,totCarte); // da 1 a 52
    contatoreMazzo = 1;
    Console.WriteLine("Pesca una carta...");
    //Console.ReadKey();

    foreach (var seme in mazzoDiCarte){
        foreach (var carta in seme){
            if (contatoreMazzo == pescaRandom){
                mano.Add(carta.Key, carta.Value);
                manoGiocatore.Clear();
                manoGiocatore.Add(mano);  
                seme.Remove(carta.Key);
                totCarte--;
                break;
            }
            
            contatoreMazzo++;
        }
        if (contatoreMazzo == pescaRandom){break;}
    }

    Console.WriteLine("*** La tua mano: ***");
    
    foreach (var seme in manoGiocatore){
        foreach (var cartaInMano in seme){
            Console.WriteLine($"{cartaInMano.Key} {cartaInMano.Value}");
        }
    }


    Console.WriteLine("*** Il mazzo: ***");
    foreach (var seme in mazzoDiCarte){
        foreach (var carta in seme){
            Console.Write($"{carta.Key} {carta.Value}\t");
        }
        Console.WriteLine("\n");
    }
    /*
    .
    .
    .
    */
    Console.WriteLine("Debug Data *************");
    Console.WriteLine($"Carte nel mazzo: {totCarte-1}");
    Console.WriteLine("Debug Data *************");
    Console.WriteLine("Continui?");
    comando = Console.ReadLine();
    comando = comando.ToUpper();

}while(comando != "EXIT");
```
>Output dopo 5 cicli
```terminal
Pesca una carta...
*** La tua mano: ***
2 di Picche
11 di Picche
4 di Fiori
10 di Picche
12 di Cuori
*** Il mazzo: ***
1 di Cuori      2 di Cuori      3 di Cuori      4 di Cuori      5 di Cuori      6 di Cuori      7 di Cuori      8 di Cuori      9 di Cuori      10 di Cuori     11 di Cuori     13 di Cuori

1 di Fiori      2 di Fiori      3 di Fiori      5 di Fiori      6 di Fiori      7 di Fiori      8 di Fiori      9 di Fiori      10 di Fiori     11 di Fiori     12 di Fiori     13 di Fiori

1 di Denari     2 di Denari     3 di Denari     4 di Denari     5 di Denari     6 di Denari     7 di Denari     8 di Denari     9 di Denari     10 di Denari    11 di Denari    12 di Denari    13 di Denari

1 di Picche     3 di Picche     4 di Picche     5 di Picche     6 di Picche     7 di Picche     8 di Picche     9 di Picche     12 di Picche    13 di Picche

Debug Data *************
Carte nel mazzo: 47
Debug Data *************
Continui?

Pesca una carta...
Unhandled exception. System.ArgumentException: An item with the same key has already been added. Key: 4
   at System.Collections.Generic.Dictionary`2.TryInsert(TKey key, TValue value, InsertionBehavior behavior)
   at System.Collections.Generic.Dictionary`2.Add(TKey key, TValue value)
   at Program.<Main>$(String[] args) in /Users/felipeconceicao/_Development/Dev2_2024/esercitazioni_mackbook/mazzo_di_carte_dict/Program.cs:line 77
```

### Considerazione 1:
Il programma funziona correttamente fino a quando non viene estratta una carta che ha la stessa chiave (numero della carta). La lista `mazzoDiCarte` usa 4 dizionari (uno per seme) per superare l'ostacolo dell'univocità delle chiavi. 

Mentre la lista `manoGiocatore` acquisisce in un unico dizionario chiamato `mano`, e quando la funzione random estrae una carta corrispondente ad una chiave pre esistente si genera un errore. 

### Considerazione 2:
A meno che io  abbia approcciato il problema in modo incorretto sin dal principio nell'uso dei dizionari e delle liste, penso che una struttura di dati che contenga due valori `<int,string>` ove la chiave (in questo caso `int`) non debba necessariamente essere univoca, si applichi con meno restrizioni al tipo di utilizzo che ne si vuole fare in questo programma. Penso ad una struttura `Tuple<int,string>`.

```bash
git add --all
git commit -m "Studio dei Dizionari - mazzo_di_carte_dict"
git push -u origin main
```

## Nuovo approccio: Array di Dizionari
E' possibile creare array di dizionari. Per ogni indice sarà dunque possibile utilizzare un seme diverso.

>Esempio:
```csharp
// Dichiarazione:
Dictionary<int, string>[] mazzoDiCarte = new Dictionary<int, string>[4];

//inizializzazione:
mazzoDiCarte[0] = new Dictionary<int, string>();  // Cuori
mazzoDiCarte[1] = new Dictionary<int, string>();  // Denari
mazzoDiCarte[2] = new Dictionary<int, string>();  // Picche
mazzoDiCarte[3] = new Dictionary<int, string>();  // Fiori

// Assegnazione:
for (int i = 1; i <= 13; i++){
    mazzoDiCarte[0].Add(i, "di Cuori");
    mazzoDiCarte[1].Add(i, "di Denari");
    mazzoDiCarte[2].Add(i, "di Picche");
    mazzoDiCarte[3].Add(i, "di Fiori");
}
 ```

 ### Considerazione:
 Ora che è stata semplificata la struttura di dati, la stessa struttura va applicata alla mano del giocatore: 
 ```csharp
// Dichiarazione:
Dictionary<int, string>[] mazzoDiCarte = new Dictionary<int, string>[4];

//inizializzazione:
mazzoDiCarte[0] = new Dictionary<int, string>();  // Cuori
mazzoDiCarte[1] = new Dictionary<int, string>();  // Denari
mazzoDiCarte[2] = new Dictionary<int, string>();  // Picche
mazzoDiCarte[3] = new Dictionary<int, string>();  // Fiori
 ```

 >Esempio di codice (funzionante)
 ```csharp
using System.Collections;
using System.Dynamic;

Console.Clear();

void CustomDebug() // funzione per mettere in pausa l'esecuzione
{
    Console.WriteLine("Premi per continuare l'esecuzione...");
    Console.ReadKey();
    return;
}

// Dichiarazione:
Dictionary<int, string>[] mazzoDiCarte = new Dictionary<int, string>[4];

//inizializzazione:
mazzoDiCarte[0] = new Dictionary<int, string>();  // Cuori
mazzoDiCarte[1] = new Dictionary<int, string>();  // Denari
mazzoDiCarte[2] = new Dictionary<int, string>();  // Picche
mazzoDiCarte[3] = new Dictionary<int, string>();  // Fiori

// Assegnazione:
for (int i = 1; i <= 13; i++)
{
    mazzoDiCarte[0].Add(i, "di Cuori");
    mazzoDiCarte[1].Add(i, "di Denari");
    mazzoDiCarte[2].Add(i, "di Picche");
    mazzoDiCarte[3].Add(i, "di Fiori");
}

// Verifico presenza delle carte in mazzoDiCarte via stampa // riuscito
foreach (var seme in mazzoDiCarte)
{
    foreach (var carta in seme)
    {
        Console.Write($"{carta.Key} {carta.Value}\t");
    }
    Console.WriteLine("\n");
}

CustomDebug();

int totCarte = 53;
int contatoreMazzo = 1; // da incrementare dentro il ciclo
Random random = new Random();
int pescaRandom;

Dictionary<int, string>[] manoGiocatore = new Dictionary<int, string>[4];
// Inizializza i dizionari in manoGiocatore
manoGiocatore[0] = new Dictionary<int, string>();  // Cuori
manoGiocatore[1] = new Dictionary<int, string>();  // Denari
manoGiocatore[2] = new Dictionary<int, string>();  // Picche
manoGiocatore[3] = new Dictionary<int, string>();  // Fiori

string comando;

do
{
    //inizializzazioni variabili
    pescaRandom = random.Next(1, totCarte); // da 1 a 52
    contatoreMazzo = 1;

    Console.WriteLine("Pesca una carta...");
    Console.ReadKey();

    foreach (var seme in mazzoDiCarte)
    {
        foreach (var carta in seme)
        {
            if (contatoreMazzo == pescaRandom)
            {
                if (seme.ContainsValue("di Cuori"))
                {
                    manoGiocatore[0].Add(carta.Key, carta.Value);
                }
                else if (seme.ContainsValue("di Denari"))
                {
                    manoGiocatore[1].Add(carta.Key, carta.Value);
                }
                else if (seme.ContainsValue("di Picche"))
                {
                    manoGiocatore[2].Add(carta.Key, carta.Value);
                }
                else if (seme.ContainsValue("di Fiori"))
                {
                    manoGiocatore[3].Add(carta.Key, carta.Value);
                }

                seme.Remove(carta.Key); // rimuovi carta dal mazzo dopo averla copiata
                totCarte--;  // decremento totale carte
                break;
            }

            contatoreMazzo++;
        }
        if (contatoreMazzo == pescaRandom) { break; }
    }

    //stampa Mano Giocatore
    Console.WriteLine("*** La tua mano: ***");
    Console.WriteLine("\n");
    foreach (var seme in manoGiocatore)
    {
        foreach (var carta in seme)
        {
            Console.WriteLine($"{carta.Key} {carta.Value}\t");
        }
        // Console.WriteLine("\n");
    }
    Console.WriteLine("\n");
    //stampa carte restanti nel mazzo
    Console.WriteLine("*** Il mazzo: ***");
    foreach (var seme in mazzoDiCarte)
    {
        foreach (var carta in seme)
        {
            Console.Write($"{carta.Key} {carta.Value}\t");
        }
        Console.WriteLine("\n");
    }

    //messaggi di dialogo
    Console.WriteLine("Debug Data *************");
    Console.WriteLine($"Carte nel mazzo: {totCarte - 1}");
    Console.WriteLine("Debug Data *************");
    Console.WriteLine("Continui?");

    comando = Console.ReadLine();
    comando = comando.ToUpper();

} while (comando != "EXIT");
 ```

### Bug Minore da risolvere:
Può capitare che una pesca vada a vuoto, cioè nessuna carta viene pescata, le carte nel mazzo rimangono dello stesso numero, e nessuna carta viene aggiunta alla mano. In sostanza qualche volta viene eseguito un ciclo a vuoto. Ipotizzo sia per via della comparazione tra `pescaRandom` e `contatoreMazzo`. Da verificare

## Prossimi obiettivi: 
- 11: stampa "Jack"
- 12: stampa "Regina"
- 13: stampa "Re"
- Risoluzione Bug Minore

 > Comandi di versionamento:
 ```bash
git add --all
git commit -m "Studio dei Dizionari - mazzo_di_carte_dict con array (working!)"
git push -u origin main
```
## Update

- [X] 11: stampa "Jack"
- [x] 12: stampa "Regina"
- [x] 13: stampa "Re"
- [ ] Risoluzione Bug Minore

 > Comandi di versionamento:
 ```bash
git add --all
git commit -m "Studio dei Dizionari - Asso, J, Q K (Update)"
git push -u origin main
```