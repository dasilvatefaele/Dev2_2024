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

// Dichiarazioni
int nSquadre;
int estrazione;
bool convertito;
string[] nomePartecipante = new string[8];
nomePartecipante[0] = "Andrea";
nomePartecipante[1] = "Anita";
nomePartecipante[2] = "Diego";
nomePartecipante[3] = "Felipe";
nomePartecipante[4] = "Giorgio";
nomePartecipante[5] = "Ivan";
nomePartecipante[6] = "Sofia";
nomePartecipante[7] = "Tamer";
Random random = new Random();
List<string> nomePartecipanteList = new List<string>{};
Dictionary<int, List<string>> dictSquadre = new Dictionary<int, List<string>>(); // Creo un dizionario di Squadre


// Converto l'array della versione precedente in una lista
nomePartecipanteList = nomePartecipante.ToList();


// Inizio Dialogo
Console.WriteLine("*** Sorteggio Partecipanti ***");


//Inserimento numero di squadre
do
{
    Console.WriteLine("> Inserisci il numero di quadre: ");
    convertito = int.TryParse(Console.ReadLine(), out  nSquadre);
} while (!convertito);


// Inizializzo Dizionario Squadre
for (int i = 0; i < nSquadre; i++)
{
    dictSquadre.Add(i+1, new List<string>());
}


int partecipantiInPiu = nomePartecipanteList.Count % nSquadre;
int partecipantiPerSquadra = nomePartecipanteList.Count / nSquadre;


for (int i = 0; i < nSquadre; i++)  // ciclo per ogni squadra
{

    for (int j = 0; j < partecipantiPerSquadra; j++)  // ciclo per ogni partecipante per squadra
    {
        estrazione = random.Next(nomePartecipanteList.Count);     
        dictSquadre[i+1].Add(nomePartecipanteList[estrazione]);
        nomePartecipanteList.RemoveAt(estrazione);    
    }

    if (partecipantiInPiu > 0)      // se ci sono partecipanti in più, distribuiscili in un'estrazione dedicata
    {
        estrazione = random.Next(nomePartecipanteList.Count);;
        dictSquadre[i+1].Add(nomePartecipanteList[estrazione]);
        nomePartecipanteList.RemoveAt(estrazione);
        partecipantiInPiu--; 
    }

}


// Pulizia Console
Console.Clear();


// Stampa le squadre
foreach (var squadra in dictSquadre)
{
    Console.Write($"Squadra {squadra.Key}: ");
    Console.WriteLine(string.Join(", ", squadra.Value));
}


Console.WriteLine("Hai estratto tutti i partecipanti.");
```
</details>



> Comandi di versionamento
```powershell
git add --all
git commit -m "Sorteggio Partecipanti v3"
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
