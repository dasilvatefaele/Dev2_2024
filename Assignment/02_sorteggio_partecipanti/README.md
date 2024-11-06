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


## Versione 4

### Obiettivo:

- Il programma deve chiedere all utente di inserire o eliminare un partecipante presente nella lista iniziale o fare il sorteggio
- Il programma deve stampare la lista dei partecipanti


> Passaggi:
1. Visualizzare la lista di partecipanti.
2. Chiedere all'utente se vuole modificare la lista (aggiungere o rimuovere)
    - Aggiungi e aggiorna
    - Rimuovi e aggiorna
3. avvia sorteggio


<details>
<summary>Esempio di codice versione 4</summary>

```csharp
using System.Threading.Tasks.Dataflow;

// Dichiarazioni
int nSquadre;
int estrazione;
string risposta;
string editLista;
bool convertito;
bool esci = false;
bool ritenta = false;
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
Console.WriteLine("Premi un tasto per continuare...");
Console.ReadKey();
Console.Clear();


// Stampo lista partecipanti
Console.WriteLine("Lista partecipanti:\n");
foreach(var partecipante in nomePartecipanteList)
{
    Console.WriteLine(partecipante);
}


do
{

    Console.WriteLine("\nVuoi modificare la lista? [si/no]");
    Console.Write("> ");
    risposta = Console.ReadLine();
    risposta = risposta.ToUpper();

    //Console.WriteLine(risposta);


    if (risposta != "SI" && risposta != "NO")
    {
        Console.WriteLine("Risposta non valida.");
    }

}while (risposta != "SI" && risposta != "NO");


if (risposta == "SI")
{

    do
    {

        //Dialogo
        Console.WriteLine("\nVuoi INSERIRE o ELIMINARE dalla lista?");
        Console.Write("> ");
        risposta = Console.ReadLine();
        risposta = risposta.ToUpper();

        if (risposta != "INSERIRE" && risposta != "ELIMINARE")
        {

            do
            {
                Console.WriteLine("Risposta non valida.");
                Console.WriteLine("\nVuoi INSERIRE o ELIMINARE dalla lista?");
                Console.Write("> ");
                risposta = Console.ReadLine();
                risposta = risposta.ToUpper();
            } while (risposta != "INSERIRE" && risposta != "ELIMINARE");

        }

        switch (risposta)
        {

            case "INSERIRE":

                Console.Clear();
                // Stampo lista partecipanti
                Console.WriteLine("Lista partecipanti:\n");
                foreach(var partecipante in nomePartecipanteList)
                {
                    Console.WriteLine(partecipante);
                }

                // Dialogo
                Console.WriteLine("\nInserisci il nome del nuovo partecipante:");
                Console.Write("> ");
                string nuovoPartecipante = Console.ReadLine();
                nomePartecipanteList.Add(nuovoPartecipante);

            break;

            case "ELIMINARE":

                Console.Clear();
                // Stampo lista partecipanti
                Console.WriteLine("Lista partecipanti:\n");
                foreach(var partecipante in nomePartecipanteList)
                {
                    Console.WriteLine(partecipante);
                }

                do
                {
                    // Dialogo
                    Console.WriteLine("\nInserisci il nome del partecipante da eliminare:");
                    Console.Write("> ");
                    string partecipante = Console.ReadLine();

                    if (nomePartecipanteList.Contains(partecipante))
                    {
                        nomePartecipanteList.Remove(partecipante);
                        Console.WriteLine($"{partecipante} è stato eliminato dalla lista.");
                    }
                    else
                    {
                        Console.WriteLine($"{partecipante} non c'è nella lista.");
                        Console.WriteLine("Vuoi riprovare?[si/no]");
                        Console.Write("> ");
                        string risposta2 = Console.ReadLine();
                        risposta2 = risposta2.ToUpper();
                        if (risposta2 == "SI")
                        {
                            ritenta = true;
                        }
                        else
                        {
                            ritenta = false;
                        }
                    }
                }while(ritenta==true);
            break;

            default:
            break;
            
        }

        

        // Dialogo
        Console.WriteLine("Vuoi continuare ad editare la lista?");
        Console.Write("> ");
        string risposta3 = Console.ReadLine();
        risposta3 = risposta3.ToUpper();
        

        if (risposta3 == "SI")
        {
            esci = true;
            Console.Clear();


            // Stampo lista partecipanti
            Console.WriteLine("Lista partecipanti:\n");
            foreach(var partecipante in nomePartecipanteList)
            {
                Console.WriteLine(partecipante);
            }
        }
        else
        {
            esci = false;
        }


    }while (risposta != "INSERIRE" && risposta != "ELIMINARE" || esci == true);
    
}

Console.Clear();

// Stampo lista partecipanti
Console.WriteLine("Lista partecipanti:\n");
foreach(var partecipante in nomePartecipanteList)
{
    Console.WriteLine(partecipante);
}

//Inserimento numero di squadre
do
{
    Console.WriteLine("\nInserisci il numero di quadre: ");
    Console.Write("> ");
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
git commit -m "Sorteggio Partecipanti v4"
git push -u origin main
```