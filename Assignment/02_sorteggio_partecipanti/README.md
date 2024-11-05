# Sorteggio Partecipanti
## Versione 1

### Obiettivo
- Scrivere un programma che permetta di sorteggiare i partecipanti del corso da una lista di nomi.

- Il programma estrae un partecipante singolo alla volta e lo stampa a video.

<details>
<summary>Esempio di codice versione 1</summary>

```csharp
Console.Clear();
string[] nomePartecipante = new string [8];
Random random = new Random();
int estrazione;

nomePartecipante [0] = "Andrea";
nomePartecipante [1] = "Anita";
nomePartecipante [2] = "Diego";
nomePartecipante [3] = "Felipe";
nomePartecipante [4] = "Giorgio";
nomePartecipante [5] = "Ivan";
nomePartecipante [6] = "Sofia";
nomePartecipante [7] = "Tamer";

estrazione = random.Next(nomePartecipante.Length);

Console.WriteLine($"Il computer ha estratto... {nomePartecipante[estrazione]}!");
```
</details>

> Comandi di versionamento
```powershell
git add --all
git commit -m "Sorteggio Partecipanti v1.0"
git push -u origin main
```
## Versione 2
### Obiettivo:

- Scrivere un programma che permetta di sorteggiare più volte i partecipanti del corso da una lista di nomi.
- Chiedere all'utente di sorteggiare un nuovo partecipante
- Rimuovere il sorteggiato dalla lista dei partecipanti

<details>
<summary>Esempio di codice versione 2</summary>

```csharp
Console.Clear();
Random random = new Random();
int estrazione;

string[] nomePartecipante = new string [8]; 
nomePartecipante [0] = "Andrea";
nomePartecipante [1] = "Anita";
nomePartecipante [2] = "Diego";
nomePartecipante [3] = "Felipe";
nomePartecipante [4] = "Giorgio";
nomePartecipante [5] = "Ivan";
nomePartecipante [6] = "Sofia";
nomePartecipante [7] = "Tamer";

int nStudenti = nomePartecipante.Length;                // Salvo la lunghezza dell'array in una variabile decrementabile 

Console.WriteLine ("*** Sorteggio Partecipanti ***");

while (nStudenti != 0)                                  // nomePartecipante.Length è sempre 8 !!! andrebbe avanti all'infinito...                   
{
    estrazione = random.Next(nomePartecipante.Length);  
    if (nomePartecipante[estrazione] != null)           // *esegue solo se il nome non è già stato estratto (cioè != null)
    {
        // Console.WriteLine($"DEBUG: {nomePartecipante.Length}"); // sempre 8...
        Console.WriteLine ("Premi un tasto per estrarre...");
        Console.ReadKey ();
        Console.WriteLine($"Il computer ha estratto... {nomePartecipante[estrazione]}!");
        Array.Clear (nomePartecipante, estrazione,1);   // Array.Clear rende "null" l'elemento ma la lunghezza dell'array non varia dunque (riga 22*)
        nStudenti--;                                    // quindi decremento e ripeto while nStudenti != 0 (non stra performante ma funziona LOL)
    }
}

Console.WriteLine ("Hai estratto tutti i partecipanti.");
```
</details>

> Comandi di versionamento
```powershell
git add --all
git commit -m "Sorteggio Partecipanti v2"
git push -u origin main
```

## Versione 3
### Obiettivo:
- Scrivere un programma che permetta di sorteggia i partecipanti del corso da una lista di nomi dividendoli in gruppi.
- Il programma deve chiedere all'utente il numero di quadre.
- Se il numero dei partecipanti non è divisibile per il numero di squadre, i partecipanti rimanenti vengono assegnati ad un gruppo in modo casuale.

<details>
<summary>Esempio di codice versione 3</summary>

```csharp
using System.Threading.Tasks.Dataflow;

Console.Clear();
Random random = new Random();
int estrazione;

string[] nomePartecipante = new string[8];
nomePartecipante[0] = "Andrea";
nomePartecipante[1] = "Anita";
nomePartecipante[2] = "Diego";
nomePartecipante[3] = "Felipe";
nomePartecipante[4] = "Giorgio";
nomePartecipante[5] = "Ivan";
nomePartecipante[6] = "Sofia";
nomePartecipante[7] = "Tamer";

int nStudenti = nomePartecipante.Length;                // Salvo la lunghezza dell'array in una variabile decrementabile 
Dictionary<int, List<string>> dictSquadre = new Dictionary<int, List<string>>();

Console.WriteLine("*** Sorteggio Partecipanti ***");
//Console.ReadKey();
Console.WriteLine("> Inserisci il numero di quadre: ");
int nSquadre = int.Parse(Console.ReadLine());

while (nStudenti != 0)                                  // nomePartecipante.Length è sempre 8 !!! andrebbe avanti all'infinito...                   
{
    // Console.WriteLine($"DEBUG: {nomePartecipante.Length}"); // sempre 8...
    for (int i = 0; i < nSquadre; i++)
    {
        estrazione = random.Next(nomePartecipante.Length);
        if (nomePartecipante[estrazione] != null)           // *esegue solo se il nome non è già stato estratto (cioè != null)
        {
            Console.WriteLine($"Il computer ha estratto... {nomePartecipante[estrazione]}!");
            if (!dictSquadre.ContainsKey(i))
            {
                List<string> temp = new List<string>();
                temp.Add(nomePartecipante[estrazione]);
                dictSquadre.Add(i, temp);
                temp.Clear ();
            }
            else
            {
                dictSquadre[i].Add(nomePartecipante[estrazione]);
            }
            Array.Clear(nomePartecipante, estrazione, 1);   // Array.Clear rende "null" l'elemento ma la lunghezza dell'array non varia dunque (riga 22*)
            nStudenti--;
        }                                  // quindi decremento e ripeto while nStudenti != 0 (non stra performante ma funziona LOL)
    }
}

foreach (var squadra in dictSquadre)
{
    Console.WriteLine(string.Join(",", squadra.Value));
}
Console.WriteLine("Hai estratto tutti i partecipanti.");
```
</details>



> Comandi di versionamento
```powershell
git add --all
git commit -m "Sorteggio Partecipanti v3 (ancora non funzionante)"
git push -u origin main
```


<!--
## Versione 2b (alternativa)
### Obiettivo:

- Scrivere un programma che permetta di sorteggiare più volte i partecipanti del corso da una lista di nomi.
-
- Scegliere casualmente due caposquadra tramite due invii e memorizzarli.

<details>
<summary>Esempio di codice versione 2b (alternativa)</summary>

```csharp
Console.Clear();
Random random = new Random();
int estrazione;
string[] nomeCapoSquadra = new string [2];

// array per operazioni
string[] nomePartecipante = new string [8]; 
nomePartecipante [0] = "Andrea";
nomePartecipante [1] = "Anita";
nomePartecipante [2] = "Diego";
nomePartecipante [3] = "Felipe";
nomePartecipante [4] = "Giorgio";
nomePartecipante [5] = "Ivan";
nomePartecipante [6] = "Sofia";
nomePartecipante [7] = "Tamer";

// backup
string [] listaClasse = new string [nomePartecipante.Length];
nomePartecipante.CopyTo (listaClasse, 0); 

//  estrazione nomeCaposquadra index 0
estrazione = random.Next(0,nomePartecipante.Length);
Console.WriteLine ("*** Sorteggio Partecipanti ***");
Console.WriteLine ("Premi un tasto per iniziare l'estrazione del primo caposquadra...");
Console.ReadKey ();
Console.Clear ();
Console.WriteLine($"Il computer ha estratto... {nomePartecipante[estrazione]}!");

nomeCapoSquadra[0] = nomePartecipante[estrazione];

//  rimozione dalla lista temporanea
Array.Clear (nomePartecipante, estrazione,1);

//  estrazione nomeCaposquadra index 1
Console.WriteLine ("Premi un tasto per iniziare l'estrazione del secondo caposquadra...");
Console.ReadKey ();
estrazione = random.Next(0,nomePartecipante.Length);
Console.WriteLine($"Il computer ha estratto... {nomePartecipante[estrazione]}!");
nomeCapoSquadra[1] = nomePartecipante[estrazione];
Array.Clear (nomePartecipante, estrazione,1);
Console.WriteLine ("Premi un tasto per continuare...");
Console.ReadKey();
Console.Clear();

Console.WriteLine($"{nomeCapoSquadra[0]}\t\t\t{nomeCapoSquadra[1]}");
//Console.WriteLine("");
```
</details>

> Comandi di versionamento
```powershell
git add --all
git commit -m "Sorteggio Partecipanti v2b"
git push -u origin main
```
-->
