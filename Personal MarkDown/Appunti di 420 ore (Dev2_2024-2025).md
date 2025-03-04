# Appunti di 420 ore (Dev2_2024-2025)


<details>

<summary>🖳 Comandi principali da Terminal</summary>

# I PRINCIPALI COMANDI DOTNET

- dotnet new (per creare un nuovo progetto)
- dotnet new console (per creare un nuovo progetto console)
- dotnet new webapp (per creare un nuovo progetto web)
- dotnet new sln (per creare una nuova soluzione)
- dotnet new classlib (per creare una nuova libreria di classi)
- dotnet new mvc (per creare un nuovo progetto MVC)

- dotnet restore (per ripristinare i pacchetti NuGet)
- dotnet build (per compilare il progetto)
- dotnet run (per eseguire il progetto)
- dotnet test (per eseguire i test)
- dotnet publish (per pubblicare il progetto)

- dotnet add reference (per aggiungere un riferimento ad un progetto)
- dotnet add package (per aggiungere un pacchetto NuGet)
- dotnet sln add (per aggiungere un progetto alla soluzione)
- dotnet add webapp (per aggiungere un progetto web alla soluzione)
- dotnet add mvc (per aggiungere un progetto MVC alla soluzione)

IMPORTANTE: per eseguire i comandi dotnet è necessario posizionarsi nella cartella del progetto

# I PRINCIPALI COMANDI POWERSHELL

- cd (per spostarsi in una cartella)
- cd .. (per spostarsi nella cartella superiore)
- mkdir (per creare una cartella)
- dir (per visualizzare i file e le cartelle)
- cls (per pulire la console)
- code . (per aprire Visual Studio Code)
- start . (per aprire Esplora File)
- start chrome "url" (per aprire Chrome)
- start firefox "url" (per aprire Firefox)
- start edge "url" (per aprire Edge)
- start iexplore "url" (per aprire Internet Explorer)
- start microsoft-edge:"url" (per aprire Edge Chromium)
- start microsoft-edge:"url" --inprivate (per aprire Edge Chromium in modalità InPrivate)


# I PRINCIPALI COMANDI GIT

- git init (per inizializzare un repository)
- git status (per visualizzare lo stato del repository)
- git add . (per aggiungere tutti i file alla staging area)
- git commit -m "messaggio" (per eseguire il commit)
- git log (per visualizzare la history dei commit)
- git checkout -b "nome-branch" (per creare un nuovo branch)
- git checkout "nome-branch" (per spostarsi su un branch esistente)
- git branch (per visualizzare i branch esistenti)
- git merge "nome-branch" (per eseguire il merge di un branch)
- git remote add origin "url" (per aggiungere un remote)
- git push -u origin master (per eseguire la prima push)
- git push (per eseguire una push)
- git pull (per eseguire una pull)
- git clone "url" (per clonare un repository)
- git commit --amend -m "Nuovo messaggio del commit" (Questo cambier� il messaggio dell'ultimo commit)
- git rebase -i HEAD~X (apre la procedura per cambiare un commmit specifico cambiare X con 3 per 3 commit precedenti)
Cambia pick in reword accanto al commit che vuoi modificare, poi salva e chiudi l'editor
Completa il rebase con git rebase --continue.
esegui git push origin <nome-del-branch> --force

</details>

---

<details>
<Summary> 💬 String </Summary>

# STRINGHE

### `VARIABILE_STRINGA.Length`

restituisce la lunghezza

```csharp
string nome2 = "abcd";
int lunghezza = nome2.Length; // lunghezza = 4
```

---

### `string.isNullOrWhiteSpace( VARIABILE_STRINGA )`

restituisce booleano se c'è o meno un valore null o uno spazio vuoto

```csharp
string nome3 = "Nome1";
bool check = string.IsNullOrWhiteSpace(nome3); // check = false
```

---

### `VARIABILE_STRINGA.ToLower()`

restituisce stringa in minuscolo

```csharp
string nome4 = "NOME1";
string minuscolo = nome4.ToLower();   //  minuscolo = "nome1"
```

---

### `VARIABILE_STRINGA.ToUpper()`

restituisce stringa in maiuscolo

```csharp
string minuscolo = "nome1";
string maiuscolo = minuscolo.ToUpper();     // maiuscolo = "NOME1"
```

---

### `VARIABILE_STRINGA.Trim()`

rimuove gli spazi bianchi all'inizio e alla fine di una stringa

```csharp
string nome6 = "   Nome1   ";
nome6 = nome6.Trim();        // nome6 = "Nome1"
```

---

### `VARIABILE_STRINGA.Split( 'CARATTERE_CHAR' )`

separa la stringa usando l'argomento come punto di interruzione 

```csharp
string nome7 = "Nome1,Nome2,Nome3";
string[] nomi3 = nome7.Split(',');
foreach (string oggetto in nomi3)
{
    Console.WriteLine(oggetto);
}
```

> output:

```
Nome1
Nome2
Nome3
```

---

### `VARIABILE_STRINGA.Replace( "STRINGA_A","STRINGA_B" )`

sostituisce una sottostringa (STRINGA_A) con un altra sotostringa (STRINGA_B)

```csharp
string nome8 = "Nome1";
Console.WriteLine(nome8.Replace("Nome1","Nome2"));
```

---

### `VARIABILE_STRINGA.SubString( int INDEX_INIZIALE, int LUNGHEZZA_STRINGA )`

restituisce una sottostringa (parte dallo 0 e lo fa per 3 caratteri)

```csharp
string nome9="Nome1";
Console.WriteLine(nome9.Substring(0,3)); //output: Nom
```

---

### `VARIABILE_STRINGA.Contains( "STRINGA_DA_CERCARE" )`

Verifica se una string continuene una sottostringa

```csharp
string nome10 = "Nome1";
bool contiene = nome10.Contains("Nom"); // contiene = true
```

---

### `VARIABILE_STRINGA.IndexOf( "subStringaDaCercare" )`

restituisce l'indice della prima occorrenza di una sottostringa. se lo trova restituisce 0. se non trova la sottostringa restituisce -1

```csharp
string nome11 = "Nome1";
Console.WriteLine(nome10.IndexOf("Nome1")); 
// output: 0
```

---

### `VARIABILE_STRINGA.LastIndexOf("o") `

restituisce l'indice dell'ltima occorrenza di una stringa se non trova la sottostringa -1, parte dalla fine della stringa

```csharp
string nome12 = "Nome1";
int index = nome12.LastIndexOf("o"); 
// index = 3
// in questo caso la "o" si trova in posizione 3 
// partendo dalla fine della stringa
```

---

### `VARIABILE_STRINGA.StartsWith( "C" )`

restituisce true-false se la stringa inizia con la lettera stringa nell'argomento

```csharp
string nome13 = "Nome1";
bool check = nome13.StartsWith("N"); // check = true
```

---

### `VARIABILE_STRINGA.EndsWith( "1" )`

restituisce true-false se l'ultima lettera/substringa della stringa in esame è uguale all'argomento

```csharp
string nome14 = "Nome1";
bool check = nome14.EndsWith("1"); // check = true
```

---

### `VARIABILE_NUMERICA.ToString()`

converte un tipo di dato in stringa. dovrebbe funzionare con int, double, char ecc...

```csharp
int eta3 = 10;
string etaInString = eta3.ToString(); // etaInString = "10"
```

---

### `string.Join("SEPARATORE", DATO_REITERABILE)`

```csharp
Console.WriteLine(string.Join(", ", array));
// stampa tutto il contenuto dell'array

string mappa = string.Join(", ", array);
// creo una stringa formata dal contenuto dell'array separato da una virgola e l'assegno a string mappa
```

---

### `int.Parse( STRINGA_DA_CONVERTIRE )`

converte una stringa in un tipo di dato. se la convertsione non va a buon fine termina il programma con un errore.

```csharp
string eta4 = "10";
Console.WriteLine(int.Parse(eta4));
```

---

### `int.TryParse( STRINGA_DA_CONVERTITRE, out DATO_CONVERTITO )`

converte una stringa in un tipo di dato e restituisce un valore booleano che indica la conversione riuscita. se la conversione è riuscita il valore viene salvata nella variabile di riferimento `datoConvertito`

```csharp
string eta4 = "10";
int etaConvertita;
bool riuscita = int.TryParse (eta4, out etaConvertita) // riuscita = true
```

---

### `Convert.ToInt32( STRINGA_CON_NUMERO_DA_CONVERTIRE )`

converte un tipo di dato in un altro tipo di dato. se la conversione non è riuscita viene generata un'ecezzione di tipo InvalidCastException ed il programma si blocca

```csharp
string eta7 = "10";
int convertito = Convert.ToInt32(eta7); // convertito = 10
```

---

### `conversione implicita` :

possibile da `int` a `double`, non da `double` a `int`

```csharp
int eta8 = 10;
double altezza3 = eta8;
```

### `conversione esplicita (cast)`

```csharp
double altezza4 = 1.70;
int eta9 = (int)altezza4;
```

---

### `tipi e concatenazioni`

```csharp
// posso stampare il tipo della variabile con GetType()
Console.WriteLine($"tipo della var è: {eta8.GetType()}");
Console.WriteLine($"tipo della var è: {altezza.GetType()}");

// concatenazione con string.format
string nome15 = "Nome1";
string cognome1 = "Rossi";
Console.WriteLine(string.Format ("{0} {1}", nome15, cognome1));
```

</details>

---

<details>
<summary>📝 List</summary>

# LISTE

### `VARIABILE_LISTA.Count`

restituisce il numero di elementi di una lista

```csharp
var lista1 = new List<int> { 1, 2, 3, 4, 5 }; 
int numeroDiElementi = lista1.Count; // <--
```

---

### `VARIABILE_LISTA.Add( ELEMENTO_DA_AGGIUNGERE )`

 aggiunge un elemento alla fine di una lista

```csharp
var lista = new List<int> { 1, 2, 3, 4, 5 }; 
lista.Add(6); // aggiunge 6 alla fine di lista2
Console.WriteLine(string.Join(", ", lista2)); // stampa lista2
```

---

### `LISTA_CONTENITORE.AddRange( LISTA_IN_CODA )`

aggiunge una collezione alla fine di una lista

```csharp
var lista3 = new List<int> { 1, 2, 3, 4, 5 }; 
var lista4 = new List<int> { 6, 7, 8, 9, 10 }; 
lista3.AddRange(lista4); 
// lista3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
```

---

### `VARIABILE_LISTA.Clear()`

cancella gli elementi di una lista

```csharp
var lista5 = new List<int> { 1, 2, 3, 4, 5 }; 
lista5.Clear();
// lista5 = { }
```

---

### `VARIABILE_LISTA.Contains( VALORE )`

restituisce true-false se una lista contiene un elemento

```csharp
var lista6 = new List<int> { 1, 2, 3, 4, 5 }; 
bool check = lista6.Contains(3); 
// check = true
```

 ---

### `VARIABILE_LISTA.IndexOf( VALORE )`

restituisce l'indice di un elemento di una lista. se l'elemento non c'è restituisce -1

```csharp
var lista7 = new List<int> { 1, 2, 3, 4, 5 }; 
int index = lista7.IndexOf(3);
// index = 2

int index = lista7.IndexOf(8);
// index = -1
```

---

### `VARIABILE_LISTA.Remove( VALORE )`

cancella la prima occorrenza di un elemento di una lista

```csharp
var lista8 = new List<int> { 1, 2, 3, 4, 5 }; 
lista8.Remove(3); 
// lista8 = { 1, 2, 4, 5 } 
```

---

### `VARIABILE_LISTA.RemoveAt( INDEX )`

cancella un elemento di una lista in base all'indice

```csharp
var lista9 = new List<int> { 1, 2, 3, 4, 5 }; 
lista9.RemoveAt(2); 
// lista9 = { 1, 2, 4, 5}
```

---

### `VARIEBILE_LISTA.Sort();`

ordina gli elementi di una lista

```csharp
var lista10 = new List<int> { 5, 3, 1, 4, 2 }; 
lista10.Sort(); 
// lista10 = { 1, 2, 3, 4, 5}
```

 ---

### `var[] ARRAY = VARIABILE_LISTA.ToArray();`

restituisce un array a partire da una lista

```csharp
var lista11 = new List<int> { 1, 2, 3, 4, 5 }; 
int[] array = lista11.ToArray(); 
// array = [ 1, 2, 3, 4, 5 ]
```

---

### `VARIABILE_LISTA.TrimExcess();`

riduce la capacita di una lista al numero di elementi presenti (poiché a differenza di un array, le liste si possono espandere, prenotandosi degli spazi in memoria)

```csharp
var lista12 = new List<int> { 1, 2, 3, 4, 5 }; 
lista12.TrimExcess(); 
Console.WriteLine(lista12.Capacity); 
```

</details>

---

<details>
<summary>📚 Dictionary</summary>

# DIZIONARI

### `VARIABILE_DIZIONARIO.Count`

Restituisce il numero di coppie chiave-valore in un dizionario.  

```csharp
var dizionario = new Dictionary<string, int> { {"A", 1}, {"B", 2} };
int count = dizionario.Count; // count = 2
```

---

### `VARIABILE_DIZIONARIO.Add( CHIAVE, VALORE )`

Aggiunge una coppia chiave-valore.  

```csharp
var dizionario = new Dictionary<string, int>();
dizionario.Add("C", 3); 
// dizionario = { {"C", 3} }
```

---

### `VARIABILE_DIZIONARIO.Remove( CHIAVE )`

Rimuove una coppia chiave-valore usando la chiave.

```csharp
var dizionario = new Dictionary<string, int> { {"A", 1}, {"B", 2} };
dizionario.Remove("A");
// dizionario = { {"B", 2} }
```

---

### `VARIABILE_DIZIONARIO.ContainsKey( CHIAVE )`

Verifica se una chiave è presente.  

```csharp
bool contiene = dizionario.ContainsKey("B"); // contiene = true
```

---

### `VARIABILE_DIZIONARIO.ContainsValue( VALORE )`

Verifica se un valore è presente.

```csharp
bool contiene = dizionario.ContainsValue(2); // contiene = true
```

---

### `VARIABILE_DIZIONARIO.TryGetValue( CHIAVE, out VALORE )`

Restituisce `true` se trova la chiave, e assegna il valore corrispondente a `VALORE`.

```csharp
int valore;
bool trovato = dizionario.TryGetValue("B", out valore); // trovato = true, valore = 2
```

---

### `VARIABILE_DIZIONARIO.Clear()`

Rimuove tutte le coppie chiave-valore.  

```csharp
dizionario.Clear();
// dizionario = { }
```

</details>

---

<details>
<summary>🔢 Array</summary>

# ARRAY

### `ARRAY.Length`

Restituisce la lunghezza dell'array.  

```csharp
int[] numeri = {1, 2, 3};
int lunghezza = numeri.Length; // lunghezza = 3
```

---

### `ARRAY.GetValue( INDICE )`

Restituisce il valore in un indice specifico.  

```csharp
int valore = numeri.GetValue(1); // valore = 2
```

---

### `ARRAY.SetValue( VALORE, INDICE )`

Assegna un valore a un indice specifico.  

```csharp
numeri.SetValue(10, 1);
// numeri = {1, 10, 3}
```

---

### `Array.Sort( ARRAY )`

Ordina un array in ordine crescente.

```csharp
Array.Sort(numeri);
// numeri = {1, 2, 3}
```

---

### `Array.Reverse( ARRAY )`

Inverte l'ordine degli elementi.  

```csharp
Array.Reverse(numeri);
// numeri = {3, 2, 1}
```

---

### `Array.IndexOf( ARRAY, VALORE )`

Restituisce l'indice della prima occorrenza di un valore.  

```csharp
int index = Array.IndexOf(numeri, 2); // index = 1
```

---

### `Array.Clear( ARRAY, INDICE_INIZIALE, NUM_ELEMENTI )`

Imposta a zero/null un intervallo di elementi.  

```csharp
Array.Clear(numeri, 0, 2);
// numeri = {0, 0, 3}
```

### `ARRAY_DA_COPIARE.CopyTo(ARRAY_DESTINAZIONE, INDEX_di_PARTENZA)`

copia un array in un altro array

```csharp
int[] array1 = { 1, 2, 3, 4, 5 }; 
int[] array2 = new int[array1.Length]; 
array1.CopyTo(array2, 0);
// array2 = { 1, 2, 3, 4, 5 }
```

</details>

---

<details>
<summary>📊 Math</summary>

# MATH

### `Math.Abs( VALORE )`

Restituisce il valore assoluto.  

```csharp
int assoluto = Math.Abs(-5); // assoluto = 5
```

---

### `Math.Pow( BASE, ESPONENTE )`

Restituisce la potenza.  

```csharp
double potenza = Math.Pow(2, 3); // potenza = 8
```

---

### `Math.Sqrt( VALORE )`

Restituisce la radice quadrata.  

```csharp
double radice = Math.Sqrt(16); // radice = 4
```

---

### `Math.Round( VALORE, CIFRE_DECIMALI )`

Arrotonda un valore.  

```csharp
double arrotondato = Math.Round(3.14159, 2); // arrotondato = 3.14
```

---

### `Math.Max( VAL1, VAL2 )` e `Math.Min( VAL1, VAL2 )`

Restituisce il maggiore/minore tra due valori.  

```csharp
int massimo = Math.Max(10, 20); // massimo = 20
int minimo = Math.Min(10, 20);  // minimo = 10
```

</details>

---

<details>
<summary>🕒 DateTime & TimeSpan</summary>

# DATETIME E TIMESPAN

### `DateTime.Now` e `DateTime.Today`

Restituisce l'orario attuale o solo la data.  

```csharp
DateTime now = DateTime.Now;  
DateTime oggi = DateTime.Today;
```

---

### `TimeSpan`

E' una struttura che rappresenta un intervallo di tempo
Sottrazione tra due dati `DateTime` genera un dato `TimeSpan`.

```csharp
DateTime today = DateTime.Today;
DateTime dataDiNascita = new DateTime (1990,2,1)
TimeSpan eta = today - dataDiNascita;
```

---

### `VAR_TIMESPAN.Days`

```csharp
TimeSpan eta = today - dataDiNascita;
int anni = eta.Days/365;

// ALTRI METODI:

// ------------------------

// eta.Days 
// eta.Hours
// eta.Minutes
// eta.Seconds
// eta.Milliseconds
// eta.Ticks    

// restituiscono un int

// ------------------------

// eta.TotalDays
// eta.TotalHours
// eta.TotalMinutes
// eta.TotalSeconds
// eta.TotalMilliseconds
// eta.TotalTicks

// restituiscono un double
```

---

## Formattazione

### `DATE_VAR.ToLongDateString()`

```csharp
Console.WriteLine($"{today.ToLongDateString()}");
// lunedi 18 novembre 2024
```

---

### `DATE_VAR.ToShortDateString()`

```csharp
Console.WriteLine($"{today.ToShortDateString()}");
// 18/11/2024
```

---

### `VARIABILE_DATETIME.ToString( FORMATO )`

Converte una data in stringa con formato specifico.  

```csharp
string formato = oggi.ToString("dd/MM/yyyy");
```

---

### `DATE_VAR.ToString( "FORMATO_PERSONALIZZATO" )`

```
Sintassi:

"MMMM"      ->      gennaio
"MM"        ->      01 
"dddd"      ->      lunedì
"yyyy"      ->      2024
```

```csharp
Console.WriteLine($": {today.ToString("MMMM")}");
// novembre
```

```csharp
Console.WriteLine($"{today.ToString("MM")}");
// 11
```

```csharp
Console.WriteLine($"{today.ToString("dd-MM-yyyy")}");
// 18/11/2024
```

Si può inserire una data e farci restituire il giorno della settimana corrispondente

`.DayOfWeek` restituisce in inglese

```csharp
Console.WriteLine(today.DayOfWeek);
// monday 
```

```csharp
// ESEMPI EXTRA:
Console.WriteLine("Il giorno della settimana è: " + (int)birthDate.DayOfWeek);
// (int)birthDate.DayOfWeek restituisce il numero della settimana 

Console.WriteLine("Il giorno della settimana è: " + (int)birthDate.DayOfYear);
// (int)birthDate.DayOfYear restituisce il numero giorno dell'anno
```

---

### `VARIABILE_DATETIME.AddDays( NUM_di_GIORNI )`

Aggiunge giorni a una data.  

```csharp
DateTime futuro = today.AddDays(5);  
// futuro = oggi + 5 giorni
```

---

### `VARIABILE_DATETIME.AddMonths( NUM_di_MESI )`

Aggiunge mesi a una data.  

```csharp
DateTime traTotMesi = today.AddMonths(3);  
// traTotMesi = oggi + 3 mesi
```

---

### `VARIABILE_DATETIME.AddYears( NUM_di_ANNI )`

Aggiunge anni a una data.  

```csharp
DateTime prossimoCompleanno = compleanno.AddYears(1);  
// prossimoCompleanno = compleanno + 1 anno
```

---

### `DateTime.Compare( DATA1 , DATA2 )`

`DateTime.Compare( DATA1 , DATA2 )` 

restituisce 

`-1` SE `DATA1 < DATA2`

`0` SE `DATA1 == DATA2`

`1` SE `DATA1 > DATA2`

```csharp
DateTime date1 = DateTime.Today; // Oggi
DateTime date2 = new DateTime (2024,12,31); // scegli una data
int result = DateTime.Compare(date1,date2); // confronto tra le date

Console.WriteLine(result);

if (result < 0)
{
    Console.WriteLine("La prima data viene prima della seconda data");
}
else if (result > 0)
{
    Console.WriteLine("La seconda data  viene prima della prima data");
}
else
{
    Console.WriteLine("Le due date sono uguali");
}
```

</details>

---

<details>
<summary>🖥️ Console</summary>

# CONSOLE

### `Console.WriteLine( "MESSAGGIO" )` e `Console.ReadLine()`

Stampa un messaggio o legge un input.

```csharp
Console.WriteLine("Inserisci il tuo nome:");
string nome = Console.ReadLine();
```

---

### `Console.Clear()`

Pulisce la console.  

```csharp
Console.Clear();
```

---

### `Console.ForegroundColor` e `Console.BackgroundColor`

Cambia i colori del testo e dello sfondo.  

```csharp
Console.ForegroundColor = ConsoleColor.Green;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("Testo verde su sfondo nero");
Console.ResetColor();
```

---

### `Console.KeyAvailable` e `Console.ReadKey()`

Rileva se un tasto è stato premuto e legge l'input.  

```csharp
if (Console.KeyAvailable) {
    var key = Console.ReadKey();
    Console.WriteLine($"Hai premuto: {key.Key}");
}
```

</details>

---

<details>
<summary>📂 File & Directory</summary>

# FILE

### Task: Creare, Leggere, Scrivere da un file .txt

NOTA: file deve essere contenuto/viene creato all'interno della directory del progetto

---

## LETTURA DI UN FILE

```csharp
string path = @"test.txt";
// collego ad una variabile stringa il collegamento

string[] lines = File.ReadAllLines(path);
// legge tutte le righe e le mette in un array di stringhe

foreach (string line in lines)
{
    Console.WriteLine(line); // stampo la riga
}
```

<!-- OPPURE creo un nuovo array della stessa lunghezza

```csharp
//OPPURE creo un nuovo array della stessa lunghezza 
string [] nomi = new string[lines.Length]; 
for (int i = 0; i < lines.Length; i++)
{
    nomi[i] = lines[i];
}

foreach (string nome in nomi)
{
    Console.WriteLine(nome);
}
``` -->

---

## METODI DI FILE

#### CREARE UN FILE

### `File.Create(STRINGA_CON_NOME_FILE).Close()`

```csharp
// Creare un file - 
// NOTA: "path" è un nome a qualsiasi che diamo noi a piacere 
// alla nostra variabile stringa che contine il nome vero e proprio del file

string path = @"test.txt"; // come string STRINGA_CON_NOME_FILE = @"test.txt", solo che qui la chiamo path
File.Create(path).Close(); // creo il file chiamato test.txt, perché dentro "path" c'è scritto "text.txt"
```

#### CREARE UN FILE CON UN NOME PERSONALIZZATO

```c#
string nomeUtente = Console.ReadLine();     // leggo inserimento dell'utente e lo salvo in nomeUtente

// ATTENZIONE AI PROSSIMI PASSAGGI: 
string nomeFile = nomeUtente + ".txt"; 
//     nomeFile è il nome della variabile stringa, che contiente nomeUtente (come l'esempio di string path)
//     nomeUtente è il nome del file inserito dall'utente con Console.ReadLine(), poi concatenato con + ".txt"

File.Create(nomeFile).Close(); // <---- creo il file (QuelloCheHaScrittolUtente).txt


// STESSA OPERAZIONE, MODO ALTERNATIVO
string nomeFile2 = $"@{nomeUtente}.txt"     // stessa identica cosa ma con la concatenazione di stringe usando il $
File.Create(nomeFile2).Close();
```

---

#### SOVRASCRIVERE UN FILE

### `File.WriteAllText(STRING_NOME_FILE, VAR_DA_SCRIVERE); `

```c#
string path = @"test.txt";                      // "path" è una stringa che contiene il nome del file
File.Create(path).Close();                      // creo il file chiamato "test.txt"
File.WriteAllText(path, "Hello World!");        // sovrascrivo "Hello World!" dentro "test.txt"
```

#### SCRIVERE ALLA FINE DI UN FILE

### `File.AppendAllText(STRING_NOME_FILE, VAR_DA_SCRIVERE);`

```c#
File.AppendAllText(path, "Hello World! \n" );   

// se voglio AGGIUNGERE un testo alla fine di ciò che c'è già dentro "test.txt"
// uso .AppendAllText
// "\n" è come andare a capo premendo invio
```

#### STESSA OPERAZIONE, MODO ALTERNATIVO

```c#
File.AppendAllText(path, numero + "\n");  

// IN QUESTO CASO viene scritto nel file qualunque numero ci sia scritto dentro la variabile "numero" 
```

---

#### SCRIVO UNA LISTA DENTRO UN FILE

### `File.AppendAllLines(STRING_NOME_FILE, VAR_LISTA);`

```c#
string path = @"test.txt";
File.Create(path).Close();
List<string> elencoDiAnimali = new List<string> { "cane", "gatto", "topo", "gallina", "mucca" };

File.AppendAllLines(path, elencoDiAnimali); // <---
// nel mio file chiamato "text.txt" troverò scritta la lista elencoDiAnimali
```

#### OPERAZIONI CON I FILE

```C#
// Leggere da un file
string content = File.ReadAllText(path);

// Copiare un file 
string path2 = @"test2.txt";

// Eliminare un file
File.Delete(path2);

// Controlla se un file esiste
if(File.Exists(path))
{
    //do this;
}
else
{
    //do that;
}

//Ottenere info su un file
FileInfo info = new FileInfo (path);
Console.WriteLine (info.Lenght);
Console.WriteLine (info.CreationTime);

// fare riferimento solo al nome del file senza il path
string filename = Path.GetFileName(path);
Console.WriteLine (fileName);

// fare riferimento solo all'estensione del file
string extension = Path.GetExtension(path);
Console.WriteLine (extension);

// fare riferimento solo al nome del file senza l'estensione
string fileNameWithouthExtension = Path.GetFileNameWithoutExtension(path);
Console.WriteLine (fileNameWithouthExtension);

// creare la copia di un file
string copyPath = Path.Combine (dir, "text.txt");
File.Copy(path, copyPath);

// spostare un file
string movePath = Path.Combine(dir, "test2.txt");
File.Move(copyPath, movePath);

// Eliminare un file
File.Delete(movePath);

//eliminare una dir e tutti i file e dir che ci sono al suo interno
Directory.Delete(dir, true);

// eliminare tutti i file di una dir
string[] files = Directory.GetFiles(dir);
foreach (string file in files)
{
    File.Delete(file);
}

// eliminare tutti i file e le dir in una dir 
string[] all = Directory.GetFileSystemEntries(dir);
foreach (string a in all)
{
    if (File.Exist(a))
    {
        File.Delete(a);
    }
    else
    {
        Directory.Delete(a,true);
    }
}
```

## METODI DIRECTORY

```csharp
//Ottenere info su una directory
string dir = "."; // parto dalla cartella del progetto dotnet nel quale sono 
DirectoryInfo dirInfo = new DirectoryInfo(dir);
Console.WriteLine(dirInfo.CreationTime);

// Ottenere info su tutti i file in una directory (SOLO FILE)
string[] files = Directory.GetFiles(dir);
foreach(string file in files)
{
    Console.WriteLine(file);
}

// ottenere info su tutti i file e le dir in una dir (FILE E CARTELLE)
string[] all = Directory.GetFileSystemEntries(dir);
foreach( string a in all)
{
    Console.WriteLine(a);
}

// ottenere informazioni su tutti i file e dir in una dir con un filtro
string[] txtFiles = Directory.GetFiles(dir,"*.txt");
foreach (string txtFile in txtFiles)
{
    Console.WriteLine(txtFile);
}
```

## MISH

```C#
// Creare un file
string path = @"test.txt";
File.Create(path).Close();

//Scrivere un file
File.WriteAllText(path, "Hello World!");

// Leggere da un file
string content = File.ReadAllText(path);

// Copiare un file 
string path2 = @"test2.txt";

// Eliminare un file
File.Delete(path2);

// Creare una directory
string dir = @"test";
Directory.CreateDirectory(dir);

// Eliminare una directory
Directory.Delete(dir);

// Crea un file temporaneo
string tempFile = Path.GetTempFileName();
Console.WriteLine(tempFile);

// Creare un file temporaneo in una directory specifica
// Path.Combine unisce i path in questo caso aggiunge "temp alla deirectory temporaena
string tempDir = Path.Combine(Path.GetTempPath(), "temp");
Directory.CreateDirectory(tempDir);
```

</details>

---

<details>
<summary>😺 GitHub </summary>

# GIT

## Best practices:

1. Clone del repository di partenza (partire dalla versione più aggiornata del repository)

2. Lavorare per `File`, non per Task

3. Scegliere la Task.

4. Creare branch e verificare di essere in un branch

5. Committare le modifiche sul proprio branch 
   
# Pull Request 

- Sul proprio branch, dev fa il pull del main (o del branch da incorporare)

- Commit e Push sul proprio branch proprio branch


# Merge Individuale: 

- dev si sposta sul main 

- digita il merge del branch modificato

- push 
  
  
# Merge (fatto dall'HOST)

- Spostarsi sul main

- Pull origin main per aggiornare il main in locale

- Merge del branch 

- git push -u origin main

# Git Shash

comando che consente di saklvare temporaneamente le modifiche non commitate nel repository Git senza applicarle diretamente al branch

(salvato in locale)

utile per passare ad un alro branch senza dover committare modifiche

Salvare il lavoro in corso per risolvere un conflitto o aggiornre il branch

mantenere pulito il tuo storico di commit

comandi di base

```
git stash save "Nome dello stash"
```
non tracciati

```
git stash -u
```

Spplicare uno stash salvato

```
git stash apply
```

rimuovere
```
git stash drop
```

cancellare tutti gli stash

```
git stash clear
```

Procedimento

```
git stash -m "pausa"
git checkout nuovo-branch
git stash pop

```

Visualizzazione delle modifiche dettagliate (patch) salvate nello stash specificato.

Spiegazione dettagliata:

* `git stash show` mostra un riepilogo delle modifiche contenute in uno stash.

* L'opzione `-p (--patch)` fa sì che vengano mostrate le modifiche in formato diff, cioè riga per riga.

* `stash@{0}` si riferisce alla prima voce dello stash (l'ultima aggiunta).

```
git stash show -p stash@{0}
```
</details>

---

<details>
<summary>⛓️ LinQ & Lambda</summary>

# LINQ & LAMBDA

Funzionalità per scrivere query in modo conciso, 
e che funziona con tutte le strutture di dati , come liste, array, database ecc.

NOTA


---

## LINQ

Interamente tipizzato a tempo di compile-time (si usano il `var`, dunque non è neccessario il casting).

In C# interagisce molto bene con EntityFramework, perché semplifica le query.


## LAMBDA EXPRESSIONS


> SENZA LAMBDA
```cs
List <int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
List <int> numeriPari = new List<int>();

foreach (var numero in lista)
{
    if (numero % 2 == 0)
    {
        numeriPari.Add(numero);
    }
}

foreach (var numero in numeriPari)
{
    Console.WriteLine(numero);
}
```

---

> CON LINQ
```cs
List <int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var numPari = from n in lista       // Definiamo la query
              where n % 2 == 0      // Filtriamo i numeri pari
              select n;             // Selezioniamo i numeri che soddisfano la condizione
                                    // n è il nome della variabile che rappresenta l'elemento corrente
foreach (var numero in numPari)
{
    Console.WriteLine(numero);      // Stampa i numeri
}
```

---

> CON LINQ & LAMBDA
```cs
List <int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var numPari = from n in lista       
              where n % 2 == 0      
              select n;                                     
numPari.ToList().ForEach(n => Console.WriteLine(n));    // convertiamo IEnumerable in List per 
                                                        // usare il metodo ForEach 
                                                        // dove => è loperatore LAMBDA (cioè funzione anonima) 
                                                        // n è l'elemento corrente
                                                        // e Console.WriteLine(n); è il corpo della funzione 
```

---
> CON LINQ & LAMBDA avanzato
```cs
List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var numPari = lista.Where(n => n % 2 == 0).ToList();
numPari.ForEach(n => Console.WriteLine(n));
```

Metodi ricorrenti:

`Where()` - filtra gli elementi che soddisfano la condizione

`select()` - seleziona gli elementi che soddisfano la condizione

`ToList()` - converte il risultato in una lista

`ForEach()` - esegue un'azione per ogni elemento della lista

---  

> CON LINQ & LAMBDA combinate 

```cs
List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
lista.Where(n => n % 2 == 0).ToList().ForEach(n => Console.WriteLine(n));
```

---

# Filtrare una lista di oggetti

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

// filtro e salvo in una variabile 
var personeFiltrate = persone.Where(p => p.Eta > 30);

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```

> oppure filtro e stampo senza salvare la lista in una variabile 

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

// stampo i filtrati
persone.Where(p => p.Eta > 30).ToList().ForEach(p => Console.WriteLine($"{p.Nome} - {p.Eta}"));

var ordinatiPerEta = persone.OrderBy(p => p.Eta).ToList();

Console.WriteLine("Ordinati per età");
ordinatiPerEta.ForEach(p => Console.WriteLine($"{p.Nome} - {p.Eta}"));


// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}

// ordinati per età

```


# Order By (ordine crescente-decrescente)

> altro esempio

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

var nomi = persone.Where(p => p.Eta > 25)   // filtriamo le persone con età maggiore di 25
                .OrderBy(p => p.Nome)       // ordiniamo per nome
                .Select(p => p.Nome)        // selezioniamo solo il nome
                .ToList();                  // trasformiamo in lista

nomi.ForEach(n => Console.WriteLine(n));    // stampiamo i nomi

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```


```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

var nomi = persone.Where(p => p.Eta > 25)               // filtriamo le persone con età maggiore di 25
                .OrderByDescending(p => p.Nome)         // ordiniamo per nome (decrescente)
                .Select(p => p.Nome)                    // selezioniamo solo il nome
                .ToList();                              // trasformiamo in lista

nomi.ForEach(n => Console.WriteLine(n));                // stampiamo i nomi

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```

---

> Contare numero di elementi (normale)

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

int conteggio = persone.Count();

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}

```

> Contare numero di elementi (con LINQ e LAMBDA)

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Pietro", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

var conteggio = (from p in persone select p).Count();

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```

> raggruppo per età

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Pietro", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

var stessaEta = persone.GroupBy(p => p.Eta).ToList();

stessaEta.ForEach(p => Console.WriteLine($"Età: {p.Key} Persone: {p.Count()} {string.Join(", ", p.Select(x => x.Nome))}"));

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```

output:

```powershell
Età: 20 Persone: 1 Mario
Età: 30 Persone: 2 Luigi, Pietro
Età: 40 Persone: 1 Paolo
Età: 50 Persone: 1 Giovanni
Età: 60 Persone: 1 Andrea
```

---

# .Take(), .Skip()

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Pietro", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

// prende i primi due
Console.WriteLine("I primi due: ");
var primiDue = (from p in persone select p).Take(2);
primiDue.ToList().ForEach(p => Console.WriteLine(p.Nome));

// esclude i primi due
Console.WriteLine("\nEscludendo i primi due: ");
var esclusi = (from p in persone select p).Skip(2);
esclusi.ToList().ForEach(p => Console.WriteLine(p.Nome));

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```

>output: 
```powershell
I primi due: 
Mario
Luigi
Escludendi i primi due:
Pietro
Paolo
Giovanni
Andrea
```

---

# Join

```cs
var ordini = new List<Ordine> 
{
    new Ordine { ClienteId = 1, Prodotto = "Laptop"},
    new Ordine { ClienteId = 2, Prodotto = "Smartphone"}
};

var clienti = new List<Cliente>
{
    new Cliente { Id = 1 , Nome = "Carlo"},
    new Cliente { Id = 2 , Nome = "Filippo"},
};

var joinQuery = from c in clienti
                join o in ordini
                on c.Id equals o.ClienteId
                select new { Cliente = c.Nome, Prodotto = o.Prodotto };

joinQuery.ToList().ForEach(j => Console.WriteLine($"{j.Cliente} ha acquistato un {j.Prodotto}"));

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

class Ordine
{
    public int ClienteId { get; set; }
    public string Prodotto { get; set; }
}
```
> output 
```
Carlo ha acquistato un Laptop
Filippo ha acquistato un Smartphone
```

> oppure (stesso risultato)

```cs
var ordini = new List<Ordine> 
{
    new Ordine { ClienteId = 1, Prodotto = "Laptop"},
    new Ordine { ClienteId = 2, Prodotto = "Smartphone"}
};

var clienti = new List<Cliente>
{
    new Cliente { Id = 1 , Nome = "Carlo"},
    new Cliente { Id = 2 , Nome = "Filippo"},
};

var joinQueryAlt = clienti.Join(
    ordini, 
    c => c.Id,
    o => o.ClienteId,
    (c, o) => new { Cliente = c.Nome, Prodotto = o.Prodotto });

joinQueryAlt.ToList().ForEach(j => Console.WriteLine($"{j.Cliente} ha acquistato un {j.Prodotto}"));

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

class Ordine
{
    public int ClienteId { get; set; }
    public string Prodotto { get; set; }
}
```
---

> output 
```
Carlo ha acquistato un Laptop
Filippo ha acquistato un Smartphone
```

</details>

---

<details>
<summary>🌐 HTML & Bootstrap </summary>

# HTML 5

L'HTML 5 è dinamico, a differenza dell'HTML normale.

Incorpora componenti aggiuntivi come:

- Il canvas permette di inserire delle grafiche vettoriali (.svg)
- base di dati (.txt, .json)

W3C è un organismo che da direttive/standard che i produttori dei browser vanno a rispettare.
(https://www.w3schools.com/html/default.asp)

> Il nostro obiettivo 2024 è il `mobile-first`, dal momento che la maggior parte degli utenti usano siti da dispositivi mobile.

Dev'essere tutto relativo e non assoluto, come riferimento l'elemento che lo contiene.

## APPUNTI FLEXBOX FROGGY:

`justify-content`

- `flex-start`: Allinea gli elementi alla sinistra del contenitore.
- `flex-end`: Allinea gli elementi alla destra del contenitore.
- `center`: Allinea gli elementi al centro del contenitore.
- `space-between`: Separa gli elementi con uguale spazio tra di loro.
- `space-around`: Separa gli elementi con uguale spazio attorno ad essi.

---

`align-items`

- `flex-start`: Allinea gli elementi all'inizio del loro contenitore.
- `flex-end`: Allinea gli elementi alla fine del loro contenitore.
- `center`: Centra gli elementi verticalmente.
- `baseline`: Gli elementi vengono disposti in modo da allineare le loro linee di base.
- `stretch`: Gli elementi sono allungati per occupare tutto il contenitore.

---

`flex-direction`

- `row`: Gli elementi sono posizionati nella stessa direzione del testo.
- `row-reverse`: Gli elementi sono posizionati nella direzione opposta al testo.
- `column`: Gli elementi sono posizionati dall'alto verso il basso.
- `column-reverse`: Gli elementi sono posizionati dal basso verso l'alto.

---

# Media Query più utilizzate

- 576px: dispositivi mobili (max-width)
- 768px: tablet (min-width: 577px) and (max-width: 768px)
- 992px
- 1400px
- da 1400px (min-width: 1401px;)

---

# Best practice CSS

```css
* {
    margin: 0;
    padding:0;
    box-sizing: border-box;
}
```

# DIVISIONE DEL BODY

```html
<body>
    <header>
        <nav>
            <ul>
                <li><a href="#">esempio<a></li>
                <li><a href="#">esempio<a></li>
                <li><a href="#">esempio<a></li>
                <li><a href="#">esempio<a></li>
            </ul>
        </nav>
    </header>

    <main>
        <!-- HERO PAGE - <section> con CALL TO ACTION - 100% viewport -->
        <!-- DIV INTERNI-->
        <!-- DIV INTERNI-->
        <!-- DIV INTERNI-->
        <!-- DIV INTERNI-->
    </main>

    <footer>
        <!-- DIV INTERNI-->
    </footer>
</body>
```

---

# ATTRIBUTI PERSONALIZZATI CSS

`:nth-child(n)` - selettore dove `n` è l'indice dell'oggetto box (1 è il primo, 2 è il secondo, 3 è il terzo e così via)

```css
.box{
    display: flex;
}

.box:nth-child(1){
    flex: 1;
}

.box:nth-child(2){
    flex: 1.5;
}

.box:nth-child(3){
    flex: 2;
}
```

# BOOTSTRAP

E' un web framework (cioè ambiente di sviluppo dedicato a un task specifico). Ci mette a disposizione una serie di strumenti preformattati affinché la progettazione sia più rapida. **E' da considerare come un gestore di CSS.**

Quando si usa Boostrats la divisione massima è di 12 colonne .

Contiene componenti javascript già pronti ( esempio: menu dinamico e interattivo )

Vantaggi:

- Molto documentato

[Get started with Bootstrap · Bootstrap v5.3](https://getbootstrap.com/docs/5.3/getting-started/introduction/)

### Passo 1: INSERIRE CDN

- inserire i CDN links all'interno del tag `<head>` (versione attuale 5.3.3)
  
  | Description | URL                                                                            |
  | ----------- | ------------------------------------------------------------------------------ |
  | CSS         | `https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css`      |
  | JS          | `https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js` |

Per aggiornare bootstrap serve sostituire manualmente i CDN nell'HTML.

Esistono CDN anche per le icone.

### Da studiarsi:

- Breakpoints

- Grid

- Columns

- Select

- Validation

- Form

---

# PERSONALIZZAZIONE BOOTSTRAP   
La personalizzazione avanzata di **Bootstrap** ti consente di creare un design unico senza rinunciare alla potenza del framework. Ecco una guida dettagliata su come personalizzare i colori e ogni aspetto grafico di Bootstrap:

per avere la priorita sugli stili di bootstrap bisogna inserire !important

```css
body {  
  font-family: 'Roboto', sans-serif !important;  
  font-size: 16px !important;  
  line-height: 1.5 !important;  
}
```
---

## **1\. Approccio Generale**

### **a) Metodi di personalizzazione**

1. **Sovrascrivere gli stili con CSS personalizzati**:  
   * Scrivi un file CSS separato che viene caricato dopo il file CSS di Bootstrap.  
   * Modifica solo le classi necessarie.  
2. **Personalizzare con SCSS** *(opzione avanzata e consigliata)*:  
   * Importa i file SCSS di Bootstrap.  
   * Sovrascrivi le variabili prima di importare i componenti.  
3. **Usare strumenti di personalizzazione online**:  
   * Bootstrap offre strumenti come [Bootstrap Customize](https://bootstrap.build/) per creare una versione personalizzata.

---

## **2\. Personalizzazione dei Colori**

### **a) Utilizzo delle variabili CSS**

Bootstrap usa **variabili CSS** per definire i colori principali (--bs-primary, --bs-secondary, ecc.). Puoi ridefinirle nel tuo file CSS:

```css
:root {  
  --bs-primary: #ff5733;   /* Colore principale */  
  --bs-secondary: #33c1ff; /* Colore secondario */  
  --bs-success: #28a745;   /* Colore per il successo */  
  --bs-info: #17a2b8;      /* Colore per informazioni */  
  --bs-warning: #ffc107;   /* Colore di avviso */  
  --bs-danger: #dc3545;    /* Colore per errori */  
  --bs-light: #f8f9fa;     /* Colore chiaro */  
  --bs-dark: #343a40;      /* Colore scuro */  
}

.btn-primary {  
  background-color: var(--bs-primary);  
  border-color: var(--bs-primary);  
  color: white;  
}
```

```html
<button class="btn btn-primary">Pulsante Personalizzato</button>
```

L'elemento :root è un **selettore CSS** che rappresenta l'elemento radice di un documento HTML. È particolarmente utile quando vuoi definire **variabili CSS globali** (anche chiamate "custom properties") accessibili in tutto il documento.

---

### **Differenza tra :root e html**

Sebbene :root abbia un comportamento simile al selettore html, :root ha una **specificità più alta**, il che significa che gli stili definiti con :root sovrascrivono quelli definiti per html in caso di conflitto.

---

### **3\. Supporto a Temi Dinamici**

Con :root, puoi facilmente implementare temi (ad esempio, modalità chiara/scura o colori personalizzati):

```css
:root {  
  --bs-warning: #ffc107; /* Modalità chiara */  
}

.dark-mode {  
  --bs-warning: #ff5722; /* Modalità scura */  
}
```

Con una sola classe (dark-mode), tutti i colori nel tuo tema si adatteranno automaticamente.

### **Consistenza nei Progetti Complessi**

In progetti grandi con molti componenti (pulsanti, alert, navbar, ecc.), le variabili CSS garantiscono che i colori siano sempre consistenti:

* Ad esempio, --bs-warning può essere usato sia per il colore di sfondo che per il bordo o il testo.  
* Eviti errori dove un componente ha un colore differente solo perché hai dimenticato di aggiornarlo.

### **Compatibilità con JavaScript**

Le variabili definite in :root possono essere facilmente modificate tramite JavaScript per creare funzionalità dinamiche.

Esempio di cambio dinamico del colore:

```javascript    
document.documentElement.style.setProperty('--bs-warning', '#ff5722');
```

Senza variabili CSS, dovresti manipolare direttamente le classi o creare nuovi stili.

---

### **b) Sovrascrivere classi specifiche**

Se vuoi personalizzare direttamente alcune classi, come i pulsanti o la navbar:

```css
.navbar {  
  background-color: #1a1a2e; /* Sfondo personalizzato */  
  color: white;  
}

.btn-primary {  
  background-color: #6a0572;  
  border-color: #6a0572;  
  color: white;  
}

.btn-primary:hover {  
  background-color: #44056e;  
  border-color: #44056e;  
}
```

---

### **c) Aggiungere nuovi colori**

Puoi estendere il sistema di colori aggiungendo variabili personalizzate:

```css
:root {  
  --bs-tertiary: #c700ff; /* Nuovo colore */  
}

.text-tertiary {  
  color: var(--bs-tertiary);  
}

.bg-tertiary {  
  background-color: var(--bs-tertiary);  
}
```

---

## **3\. Tipografia**

### **a) Personalizzare i font**

Possiamo usare i fonts di google inserendo il CDN relativo
    
```html
<link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" rel="stylesheet">
```

Bootstrap usa font-family predefiniti. Puoi sovrascrivere il font globale con una regola CSS:

```css
body {  
  font-family: 'Roboto', sans-serif; /* Usa Google Fonts */  
  font-size: 16px; /* Modifica la dimensione base */  
  line-height: 1.5; /* Modifica l'altezza delle righe */  
}
```

### **b) Modifica dei titoli**

Modifica i titoli specifici:

```css
h1, h2, h3, h4, h5, h6 {  
  font-family: 'Montserrat', sans-serif;  
  font-weight: bold;  
  color: #333;  
}
```

---

## **4\. Layout**

### **a) Personalizzare griglia**

Puoi modificare il comportamento della griglia (gutters, larghezze) usando SCSS o CSS:

#### **CSS**

```css
.container {  
  max-width: 1200px; /* Cambia larghezza massima */  
  padding-left: 15px;  
  padding-right: 15px;  
}

.row {  
  gap: 20px; /* Cambia distanza tra colonne */  
}
```

---

### **b) Navbar e header**

Per personalizzare completamente la navbar:

```css
.navbar {  
  background-color: #212529;  
  padding: 1rem;  
}

.navbar-brand {  
  font-size: 1.5rem;  
  font-weight: bold;  
  color: #ff5733;  
}

.nav-link {  
  color: #f8f9fa;  
  /* tolgo la sottolineatura */
  text-decoration: none;
}

.nav-link:hover {  
  color: #ff5733;  
}
```

---

## **5\. Componenti Personalizzati**

### **a) Modificare pulsanti**

Modifica lo stile dei pulsanti globalmente:

```css
.btn {  
  border-radius: 50px; /* Pulsanti arrotondati */  
  padding: 0.5rem 1.5rem;  
  font-size: 1rem;  
  text-transform: uppercase;  
}
```

---

### **b) Personalizzare modali**

Cambia l’aspetto dei modali:

```css
.modal-content {  
  background-color: #333;  
  color: white;  
  border-radius: 10px;  
}

.modal-header {  
  border-bottom: 1px solid #444;  
}

.modal-footer {  
  border-top: 1px solid #444;  
}
```

---

## **6\. Responsive ed Utilizzo dei mixin responsivi**

Con i mixin di Bootstrap, puoi definire regole personalizzate per breakpoint specifici:

```css
h1 {  
  font-size: 24px;

  @include media-breakpoint-up(sm) {  
    font-size: 28px;  
  }

  @include media-breakpoint-up(md) {  
    font-size: 32px;  
  }

  @include media-breakpoint-up(lg) {  
    font-size: 36px;  
  }  
}
```

Puoi usare beakpoints predefiniti come sm, md, lg, xl per definire regole specifiche per ogni dimensione dello schermo.

```css
/* Mobile (xs) */
.my-element {
  font-size: 14px;
}

/* Small (sm) */
@media (min-width: 480px) {
  .my-element {
    font-size: 16px;
  }
}

/* Medium (md) */
@media (min-width: 768px) {
  .my-element {
    font-size: 18px;
  }
}

/* Large (lg) */
@media (min-width: 1024px) {
  .my-element {
    font-size: 20px;
  }
}

/* Extra-large (xl) */
@media (min-width: 1440px) {
  .my-element {
    font-size: 22px;
  }
}
```

### **c) Testi responsive di Bootstrap**

Bootstrap fornisce classi di utilità come .fs-1, .fs-2, ecc., che puoi combinare con le classi responsive (.d-sm-block, .d-md-block) per creare font-size specifici per ogni breakpoint:

```html
<p class="fs-4 d-sm-block d-md-none">Testo per schermi piccoli</p>  
<p class="fs-2 d-none d-md-block d-lg-none">Testo per schermi medi</p>  
<p class="fs-1 d-none d-lg-block">Testo per schermi grandi</p>
```

In questo esempio:

* Su schermi **piccoli**, il paragrafo ha la classe fs-4.  
* Su schermi **medi**, il paragrafo usa fs-2.  
* Su schermi **grandi**, il paragrafo usa fs-1.

### **1. Configurare colonne per ogni breakpoint**

Bootstrap offre un sistema di griglia che ti permette di definire layout diversi per ogni breakpoint utilizzando le classi col-{breakpoint}-{numero}.

### **Esempio: Visualizzare colonne diverse a seconda del breakpoint**

```html  
<div class="container">  
  <div class="row">  
    <!-- Colonna che occupa tutta la riga su xs, metà su sm, un terzo su md -->  
    <div class="col-12 col-sm-6 col-md-4">Colonna 1</div>  
      
    <!-- Colonna che occupa metà su xs e sm, un quarto su md -->  
    <div class="col-6 col-sm-6 col-md-3">Colonna 2</div>  
      
    <!-- Colonna che è nascosta su xs, visibile su md e occupa metà della riga -->  
    <div class="d-none d-md-block col-md-6">Colonna 3</div>  
  </div>  
</div>
```

#### **Risultato:**

* **XS:** Colonna 1 e Colonna 2 occupano 100% della riga; Colonna 3 è nascosta.  
* **SM:** Colonna 1 e Colonna 2 occupano 50% della riga; Colonna 3 è nascosta.  
* **MD:** Colonna 1 (33%), Colonna 2 (25%) e Colonna 3 (50%) sono visibili.

---

### **2. Mostrare/Nascondere elementi con classi di visibilità**

Puoi usare le classi d-{breakpoint}-{value} per controllare la visibilità degli elementi in base ai breakpoint.

### **Esempio:**

```html  
  <div class="d-block d-sm-none">Visibile solo su XS</div>  
<div class="d-none d-sm-block d-md-none">Visibile solo su SM</div>  
<div class="d-none d-md-block d-lg-none">Visibile solo su MD</div>  
<div class="d-none d-lg-block">Visibile solo su LG e superiori</div>
```

* **d-block:** Mostra l'elemento.  
* **d-none:** Nasconde l'elemento.

---

### **3. Personalizzare layout di colonne dinamiche**

Puoi creare layout fluidi e dinamici definendo il numero di colonne in base al breakpoint.

```html  
  <div class="container">  
  <div class="row">  
    <!-- Colonne dinamiche -->  
    <div class="col-12 col-sm-8 col-md-6 col-lg-4">Colonna 1</div>  
    <div class="col-12 col-sm-4 col-md-6 col-lg-8">Colonna 2</div>  
  </div>  
</div>
```

---

### **4. Controllare il comportamento del contenitore**

Puoi modificare la larghezza del contenitore in base ai breakpoint con classi specifiche.

```html  
  <div class="container-sm">Contenitore piccolo</div>  
<div class="container-md">Contenitore medio</div>  
<div class="container-lg">Contenitore grande</div>  
<div class="container-xl">Contenitore extra-grande</div>
```

* **container:** Adatta automaticamente alle dimensioni dello schermo.  
* **container-fluid:** Larghezza 100% su tutti i breakpoint.

---

### **5. Cambiare l'ordine delle colonne per breakpoint**

Usa le classi di ordine per modificare la posizione delle colonne.

### **Esempio:**

```html  
<div class="row">  
  <div class="col-12 col-md-4 order-md-2">Colonna 1 (mostrata seconda su MD e superiori)</div>  
  <div class="col-12 col-md-8 order-md-1">Colonna 2 (mostrata prima su MD e superiori)</div>  
</div>
```

---

### **6. Allineamento e spaziature responsivi**

### **a) Spaziature**

Usa classi di margine e padding responsivi:

```html  
<div class="p-2 p-md-4">Padding diverso per xs (2) e md (4)</div>  
<div class="m-3 m-lg-5">Margine diverso per xs (3) e lg (5)</div>
```

### **b) Allineamento**

Puoi centrare o allineare gli elementi con classi di utilità:

```html  
<div class="text-start text-md-center text-xl-end">  
  Testo allineato a sinistra su xs, centrato su md, a destra su xl  
</div>
```

---

### **7. Griglie nidificate**

Puoi creare griglie nidificate per gestire layout complessi.

### **Esempio:**

```html  
<div class="container">  
  <div class="row">  
    <div class="col-md-6">  
      Prima colonna  
      <div class="row">  
        <div class="col-6">Subcolonna 1</div>  
        <div class="col-6">Subcolonna 2</div>  
      </div>  
    </div>  
    <div class="col-md-6">Seconda colonna</div>  
  </div>  
</div>
```

---

### **8. Controllare il wrapping delle colonne**

Per prevenire o forzare il wrapping delle colonne, usa le classi flex-nowrap o flex-wrap.

### **Esempio:**

```html  
<div class="row flex-nowrap">  
  <div class="col-4">Colonna 1</div>  
  <div class="col-4">Colonna 2</div>  
  <div class="col-4">Colonna 3</div>  
</div>
```

---

### **Esempio Completo**

```html  
<div class="container">  
  <div class="row">  
    <div class="col-12 col-sm-6 col-md-4 col-lg-3">Colonna 1</div>  
    <div class="col-12 col-sm-6 col-md-4 col-lg-3">Colonna 2</div>  
    <div class="col-12 col-sm-6 col-md-4 col-lg-3 d-none d-md-block">Colonna 3</div>  
    <div class="col-12 col-sm-6 col-md-4 col-lg-3 d-none d-lg-block">Colonna 4</div>  
  </div>  
</div>
```

* **XS:** Tutte le colonne occupano l'intera larghezza.  
* **SM:** Due colonne per riga.  
* **MD:** Tre colonne per riga, la quarta nascosta.  
* **LG:** Quattro colonne per riga.

---

## **7\. Usare Bootstrap Icons**

Per aggiungere icone personalizzate, puoi usare Bootstrap Icons o qualsiasi altra libreria di icone:

```html
<link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet">  
<i class="bi bi-heart-fill"></i>
```

---

## **Personalizzare le icone con il CSS**

### **a) Cambiare dimensioni**

Puoi usare le classi di utilità predefinite di Bootstrap per controllare la dimensione delle icone:

```html
<i class="bi bi-alarm fs-1"></i> <!-- Grande -->  
<i class="bi bi-alarm fs-3"></i> <!-- Medio -->  
<i class="bi bi-alarm fs-5"></i> <!-- Piccolo -->
```

Oppure personalizzare direttamente nel CSS:

```css
.bi {  
  font-size: 24px; /* Personalizza dimensione */  
}

.custom-icon {  
  font-size: 40px; /* Classe personalizzata */  
}
```

Esempio nell'HTML:

```html
<i class="bi bi-alarm custom-icon"></i>  
```

---

# Bootstrap: 

# WEB FRAMEWORKS

# BOOTSTRAP

https://getbootstrap.com/

## Bootstrap 5

### Bootstrap 5 - Introduzione
Bootstrap 5 è un framework front-end open source che consente di creare siti web e applicazioni web con facilità. È un insieme di strumenti di progettazione e sviluppo HTML, CSS e JavaScript. È il framework front-end più popolare al mondo.

### Bootstrap 5 - Installazione
Per installare Bootstrap 5, è possibile utilizzare npm o scaricare i file direttamente dal sito web di Bootstrap.
In alternativa è possibile importare Bootstrap 5 da un CDN

CDN:
```bash
CSS	https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css
JS	https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js
```

Si può importare Bootstrap 5 da un CDN:
```html
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <link href="https:xxxxx.xxxxxxxx.xxxxxxxxxxxxxxxxx@x.x.xxxxxxxxxxxxxxxxxxxx.xxx.xxx" rel="stylesheet">
  <title>Document</title>
</head>
<body>

</body>
</html>
```

### Bootstrap 5 - utilizzo
Per utilizzare Bootstrap 5, è possibile utilizzare le classi predefinite o i componenti predefiniti.

Esempio di utilizzo di una classe predefinita:
```html
<button class="btn btn-primary">Primary</button>
```

Esempio di utilizzo di un componente predefinito:
```html
<div class="alert alert-primary" role="alert">
  A simple primary alert—check it out!
</div>
```

### Bootstrap 5 - grid system
Il sistema di griglie di Bootstrap 5 è basato su 12 colonne. È possibile utilizzare le classi predefinite per creare layout flessibili e reattivi.

Esempio di utilizzo del sistema di griglie:
```html
<div class="container">
  <div class="row">
    <div class="col">
      1 of 2
    </div>
    <div class="col">
      2 of 2
    </div>
  </div>
</div>
```

## Bootstrap 5 - componenti
Bootstrap 5 offre una vasta gamma di componenti predefiniti che possono essere utilizzati per creare interfacce utente reattive e moderne.

I componenti disponibili sono:

- Alerts (Avvisi e notifiche servono a comunicare all'utente informazioni importanti)
- Badge (Badge sono utilizzati per mostrare informazioni aggiuntive)
- Breadcrumb (Breadcrumb sono utilizzati per mostrare la posizione dell'utente all'interno di un sito web)
- Buttons (I pulsanti sono utilizzati per eseguire azioni)
- Button group (I gruppi di pulsanti sono utilizzati per eseguire azioni correlate)
- Card (Le card sono utilizzate per mostrare informazioni)
- Carousel (Il carosello è utilizzato per mostrare immagini o altri contenuti in modo dinamico)
- Collapse (Il collapse è utilizzato per nascondere e mostrare contenuti)
- Dropdowns (I dropdown sono utilizzati per mostrare un elenco di opzioni)
- Forms (I form sono utilizzati per raccogliere informazioni dall'utente)
- Input group (Gli input group sono utilizzati per mostrare un input con un addon)
- List group (I list group sono utilizzati per mostrare un elenco di elementi)
- Modal (I modal sono utilizzati per mostrare un contenuto in sovraimpressione)
- Navs (I navs sono utilizzati per mostrare un elenco di link)
- Navbar (La navbar è utilizzata per mostrare un menu di navigazione)
- Pagination (La pagination è utilizzata per mostrare un elenco di pagine)
- Popovers (I popovers sono utilizzati per mostrare un contenuto in sovraimpressione)
- Progress (Il progress è utilizzato per mostrare un progresso)
- Scrollspy (Lo scrollspy è utilizzato per mostrare un elenco di link in base alla posizione dello scroll)
- Spinners (Gli spinner sono utilizzati per mostrare un caricamento)
- Toasts (I toasts sono utilizzati per mostrare un messaggio temporaneo)
- Tooltips (I tooltips sono utilizzati per mostrare un messaggio in sovraimpressione)

### Alerts
```html
<div class="alert alert-primary" role="alert">
  A simple primary alert—check it out!
</div>
```

### Badge
```html
<span class="badge bg-primary">Primary</span>
```

### Breadcrumb
```html
<nav aria-label="breadcrumb">
  <ol class="breadcrumb">
    <li class="breadcrumb
    -item"><a href="#">Home</a></li>
    <li class="breadcrumb-item"><a href="#">Library</a></li>
    <li class="breadcrumb-item active" aria-current="page">Data</li>
    </ol>
</nav>
```

### Buttons
```html
<button type="button" class="btn btn-primary">Primary</button>
```

### Button group
```html
<div class="btn-group" role="group" aria-label="Basic example">
  <button type="button" class="btn btn-secondary">Left</button>
  <button type="button" class="btn btn-secondary">Middle</button>
  <button type="button" class="btn btn-secondary">Right</button>
</div>
```

### Card
```html
<div class="card" style="width: 18rem;">
  <img src="..." class="card-img-top" alt="...">
  <div class="card-body">
    <h5 class="card-title">Card title</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
    <a href="#" class="btn btn-primary">Go somewhere</a>
  </div>
</div>
```

### Carousel
```html
<div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="..." class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="..." class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="..." class="d-block w-100" alt="...">
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>
```

### Collapse
```html
<button class="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
  Link with href
</button>
<div class="collapse" id="collapseExample">
  <div class="card card-body">
    Some placeholder content for the collapse component. This panel is hidden by default but revealed when the user activates the relevant trigger.
  </div>
</div>
```

### Dropdowns
```html
<div class="dropdown">
  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
    Dropdown button
  </button>
  <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <li><a class="dropdown-item" href="#">Action</a></li>
    <li><a class="dropdown-item" href="#">Another action</a></li>
    <li><a class="dropdown-item" href="#">Something else here</a></li>
  </ul>
</div>
```

### Forms
```html
<form>
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label
    ">Email address</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
    </div>
    <div class="mb-3">

    <label for="exampleInputPassword1" class="form-label
    ">Password</label>
    <input type="password" class="form-control" id="exampleInputPassword1">
    </div>
    <div class="mb-3 form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <label class="form-check-label" for="exampleCheck1">Check me out</label>
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

### Input group
```html
<div class="input-group mb-3">
  <span class="input-group-text" id="basic-addon1">@</span>
  <input type="text" class="form-control" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1">
</div>
```

### List group
```html
<ul class="list-group">
  <li class="list-group-item">Cras justo odio</li>
  <li class="list-group-item">Dapibus ac facilisis in</li>
    <li class="list-group-item">Morbi leo risus</li>
    <li class="list-group-item">Porta ac consectetur ac</li>
    <li class="list-group-item">Vestibulum at eros</li>
</ul>
```

### Modal
```html
<!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
  Launch demo modal
</button>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
        </div>
        <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
        </div>
    </div>
    </div>
</div>
```

### Navs
```html
<nav>
  <div class="nav nav-tabs" id="nav-tab" role="tablist">
    <button class="nav-link active" id="nav-home-tab" data-bs-toggle="tab" data-bs-target="#nav-home" type="button" role="tab" aria-controls="nav-home" aria-selected="true">Home</button>
    <button class="nav-link" id="nav-profile-tab" data-bs-toggle="tab" data-bs-target="#nav-profile" type="button" role="tab" aria-controls="nav-profile" aria-selected="false">Profile</button>
    <button class="nav-link" id="nav-contact-tab" data-bs-toggle="tab" data-bs-target="#nav-contact" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Contact</button>
  </div>
</nav>
<div class="tab-content" id="nav-tabContent">
  <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">...</div>
  <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">...</div>
  <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">...</div>
</div>
```

### Navbar
```html
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Navbar</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="#">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Features</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Pricing</a>
        </li>
        <li class="nav-item">
          <a class="nav-link disabled">Disabled</a>
        </li>
      </ul>
    </div>
  </div>
</nav>
```

### Pagination
```html
<nav aria-label="Page navigation example">
  <ul class="pagination">
        <li class="page-item"><a class="page-link" href="#">Previous</a></li>
        <li class="page-item"><a class="page-link" href="#">1</a></li>
        <li class="page-item"><a class="page-link" href="#">2</a></li>
        <li class="page-item"><a class="page-link" href="#">3</a></li>
        <li class="page-item"><a class="page-link" href="#">Next</a></li>
    </ul>
</nav>

```

### Popovers
```html
<button type="button" class="btn btn-lg btn-danger" data-bs-toggle="popover" title="Popover title" data-bs-content="And here's some amazing content. It's very engaging. Right?">Click to toggle popover</button>
```

### Progress
```html
<div class="progress">
  <div class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
</div>
```

### Scrollspy
```html
<body data-bs-spy="scroll" data-bs-target="#navbar-example2" data-bs-offset="0">
  <div id="navbar-example2">
    <nav class="navbar navbar-light bg-light">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">Navbar</a>
        <ul class="nav nav-pills">
          <li class="nav-item">
            <a class="nav-link" href="#scrollspyHeading1">First</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#scrollspyHeading2">Second</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#scrollspyHeading3">Third</a>
          </li>
        </ul>
      </div>
    </nav>
  </div>
  <div data-bs-spy="scroll" data-bs-target="#navbar-example2" data-bs-offset="0" tabindex="0">
    <h4 id="scrollspyHeading1">First heading</h4>
    <p>...</p>
    <h4 id="scrollspyHeading2">Second heading</h4>
    <p>...</p>
    <h4 id="scrollspyHeading3">Third heading</h4>
    <p>...</p>
  </div>
</body>
```

### Spinners
```html
<div class="spinner-border text-primary" role="status">
  <span class="visually-hidden">Loading...</span>
</div>
```

### Toasts
```html
<div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
  <div class="toast-header">
    <img src="..." class="rounded me-2" alt="...">
    <strong class="me-auto">Bootstrap</strong>
    <small>11 mins ago</small>
    <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
  </div>
  <div class="toast-body">
    Hello, world! This is a toast message.
  </div>
</div>
```

### Tooltips
```html
<button type="button" class="btn btn-secondary" data-bs-toggle="tooltip" data-bs-placement="top" title="Tooltip on top">
  Tooltip on top
</button>
```
## Bootstrap 5 - utilities
Bootstrap 5 offre una vasta gamma di utility classes che possono essere utilizzate per creare interfacce utente reattive e moderne.

Le utility classes disponibili sono:

- Borders (I bordi sono utilizzati per aggiungere bordi a un elemento)
- Clearfix (Il clearfix è utilizzato per pulire il float)
- Close icon (L'icona di chiusura è utilizzata per chiudere un elemento)
- Colors (I colori sono utilizzati per aggiungere colore a un elemento)
- Display (Il display è utilizzato per modificare il comportamento di visualizzazione di un elemento)
- Embed (L'embed è utilizzato per incorporare contenuti multimediali)
- Flex (Il flex è utilizzato per modificare il comportamento di layout di un elemento)
- Float (Il float è utilizzato per modificare il comportamento di posizionamento di un elemento)
- Image replacement (La sostituzione dell'immagine è utilizzata per sostituire un'immagine con un testo)
- Position (La posizione è utilizzata per modificare il comportamento di posizionamento di un elemento)
- Screenreaders (I lettori di schermo sono utilizzati per modificare il comportamento di visualizzazione di un elemento per i lettori di schermo)
- Shadows (Le ombre sono utilizzate per aggiungere ombre a un elemento)
- Sizing (Le dimensioni sono utilizzate per modificare le dimensioni di un elemento)
- Spacing (Lo spazio è utilizzato per aggiungere spazio a un elemento)
- Text (Il testo è utilizzato per modificare il comportamento di visualizzazione del testo)
- Vertical align (L'allineamento verticale è utilizzato per modificare il comportamento di allineamento verticale di un elemento)
- Visibility (La visibilità è utilizzata per modificare il comportamento di visualizzazione di un elemento)

### Borders
```html
<div class="border border-primary"></div>
```

### Clearfix
```html
<div class="clearfix"></div>
```

### Close icon
```html
<button type="button" class="btn-close" aria-label="Close"></button>
```

### Colors
```html
<div class="bg-primary"></div>
```

### Display
```html
<div class="d-flex"></div>
```

### Embed
```html
<iframe src="..." title="..."></iframe>
```

### Flex
```html
<div class="d-flex"></div>
```

### Float
```html
<div class="float-start"></div>
```

### Image replacement
```html
<h1 class="text-indent">Image replacement</h1>
```

### Position
```html
<div class="position-absolute"></div>
```

### Screenreaders
```html
<span class="visually-hidden">Hidden text</span>
```

### Shadows
```html
<div class="shadow"></div>
```

### Sizing
```html
<div class="w-100"></div>
```

### Spacing
```html
<div class="m-3"></div>
```

### Text
```html
<div class="text-center"></div>
```

### Vertical align
```html
<div class="align-items-center"></div>
```

### Visibility
```html
<div class="invisible"></div>
```

## Bootstrap 5 - unità di misura

rem (root em) - unità di misura relativa alla grandezza del carattere del root element es: 1rem = 16px
em - unità di misura relativa alla grandezza del carattere del parent element
% - unità di misura relativa alla grandezza del parent element
vw (viewport width) - unità di misura relativa alla larghezza del viewport
vh (viewport height) - unità di misura relativa all'altezza del viewport
px (pixel) - unità di misura assoluta
pt (point) - unità di misura assoluta
cm (centimeter
fr - unità di misura relativa alla grandezza del container es: 1fr = 1/3 del container
ch - unità di misura relativa alla grandezza del carattere "0" del font del root element

## Bootstrap 5 - colori

I colori di Bootstrap 5 sono definiti da una serie di classi predefinite che possono essere utilizzate per aggiungere colore a un elemento.

I colori disponibili sono:

- Primary (blu)
- Secondary (grigio)
- Success (verde)
- Danger (rosso)
- Warning (giallo)
- Info (azzurro)
- Light (grigio chiaro)
- Dark (grigio scuro)
- White (bianco)
- Muted (grigio chiaro)

Esempio di utilizzo di un colore:
```html
<div class="bg-primary"></div>
```

## Bootstrap 5 - tipografia

La tipografia di Bootstrap 5 è definita da una serie di classi predefinite che possono essere utilizzate per modificare il comportamento di visualizzazione del testo.

Le classi disponibili sono:

- Text color (Il colore del testo è utilizzato per modificare il colore del testo) `text-primary` `text-secondary` `text-success` `text-danger` `text-warning` `text-info` `text-light` `text-dark` `text-white` `text-muted`
- Text size (La dimensione del testo è utilizzata per modificare la dimensione del testo) `text-small` `text-normal` `text-large` `text-xl` `text-xxl` `text-xxxl`
- Text alignment (L'allineamento del testo è utilizzato per modificare l'allineamento del testo) `text-start` `text-center` `text-end` `text-justify`
- Text transformation (La trasformazione del testo è utilizzata per modificare la trasformazione del testo) `text-lowercase` `text-uppercase` `text-capitalize` `text-none`
- Text weight (Il peso del testo è utilizzato per modificare il peso del testo) `text-light` `text-normal` `text-bold` `text-bolder` `text-lighter`
- Text decoration (La decorazione del testo è utilizzata per modificare la decorazione del testo) `text-underline` `text-overline` `text-line-through` `text-none`
- Text wrapping (Il wrapping del testo è utilizzato per modificare il wrapping del testo) `text-wrap` `text-nowrap` `text-truncate`
- Text break (Il break del testo è utilizzato per modificare il break del testo) `text-break` `text-nowrap` `text-truncate`
- Text monospace (Il monospace del testo è utilizzato per modificare il monospace del testo) `text-monospace` `text-proportional`
- Text reset (Il reset del testo è utilizzato per ripristinare il comportamento predefinito del testo) `text-reset`

Esempio di utilizzo di una classe di tipografia:
```html
<div class="text-center"></div>
```

## Bootstrap 5 - immagini

Le immagini di Bootstrap 5 sono definite da una serie di classi predefinite che possono essere utilizzate per modificare il comportamento di visualizzazione delle immagini.

Le classi disponibili sono:

- Image shape (La forma dell'immagine è utilizzata per modificare la forma dell'immagine) `rounded` `circle` `thumbnail`
- Image size (La dimensione dell'immagine è utilizzata per modificare la dimensione dell'immagine) `img-fluid` `img-thumbnail`
- Image float (Il float dell'immagine è utilizzato per modificare il float dell'immagine) `float-start` `float-end` `float-none`
- Image thumbnail (Il thumbnail dell'immagine è utilizzato per mostrare un'immagine in formato thumbnail) `img-thumbnail`
- Image responsive (L'immagine responsive è utilizzata per rendere un'immagine reattiva) `img-fluid`
- Image rounded (L'immagine arrotondata è utilizzata per mostrare un'immagine con i bordi arrotondati) `rounded`

Esempio di utilizzo di una classe di immagine:
```html
<img src="..." class="img-fluid" alt="...">
```

## Bootstrap 5 - tabelle

Le tabelle di Bootstrap 5 sono definite da una serie di classi predefinite che possono essere utilizzate per modificare il comportamento di visualizzazione delle tabelle.

Le classi disponibili sono:

- Table color (Il colore della tabella è utilizzato per modificare il colore della tabella) `table-primary` `table-secondary` `table-success` `table-danger` `table-warning` `table-info` `table-light` `table-dark` `table-white`
- Table size (La dimensione della tabella è utilizzata per modificare la dimensione della tabella) `table-sm` `table-md` `table-lg`
- Table border (Il bordo della tabella è utilizzato per mostrare un bordo intorno alla tabella)
- Table striped (La tabella a righe alternate è utilizzata per mostrare le righe della tabella in modo alternato) `table-striped`
- Table hover (La tabella con hover è utilizzata per mostrare un effetto hover sulle righe della tabella) `table-hover`
- Table responsive (La tabella reattiva è utilizzata per rendere la tabella reattiva) `table-responsive`

Esempio di utilizzo di una classe di tabella:
```html
<table class="table">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">First</th>
      <th scope="col">Last</th>
      <th scope="col">Handle</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>Mark</td>
      <td>Otto</td>
      <td>@mdo</td>
    </tr>
    <tr>
      <th scope="row">2</th>
      <td>Jacob</td>
      <td>Thornton</td>
      <td>@fat</td>
    </tr>
    <tr>
      <th scope="row">3</th>
      <td>Larry</td>
      <td>the Bird</td>
      <td>@twitter</td>
    </tr>
  </tbody>
</table>
```

## Bootstrap 5 - form

Le classi disponibili sono:

- Form color (Il colore del form è utilizzato per modificare il colore del form) `form-primary` `form-secondary` `form-success` `form-danger` `form-warning` `form-info` `form-light` `form-dark` `form-white`
- Form size (La dimensione del form è utilizzata per modificare la dimensione del form) `form-sm` `form-md` `form-lg`
- Form control (Il controllo del form è utilizzato per modificare il comportamento del controllo del form) `form-control`
- Form label (L'etichetta del form è utilizzata per modificare il comportamento dell'etichetta del form) `form-label`
- Form input (L'input del form è utilizzato per modificare il comportamento dell'input del form) `form-input`
- Form select (Il select del form è utilizzato per modificare il comportamento del select del form) `form-select`
- Form textarea (Il textarea del form è utilizzato per modificare il comportamento del textarea del form) `form-textarea`
- Form checkbox (Il checkbox del form è utilizzato per modificare il comportamento del checkbox del form) `form-checkbox`
- Form radio (Il radio del form è utilizzato per modificare il comportamento del radio del form) `form-radio`
- Form switch (Lo switch del form è utilizzato per modificare il comportamento dello switch del form) `form-switch`
- Form file (Il file del form è utilizzato per modificare il comportamento del file del form) `form-file`
- Form range (Il range del form è utilizzato per modificare il comportamento del range del form) `form-range`
- Form input group (Il gruppo di input del form è utilizzato per modificare il comportamento del gruppo di input del form) `form-input-group`
- Form floating label (L'etichetta fluttuante del form è utilizzata per modificare il comportamento dell'etichetta fluttuante del form) `form-floating-label`
- Form validation (La validazione del form è utilizzata per modificare il comportamento della validazione del form) `form-validation`
- Form layout (Il layout del form è utilizzato per modificare il comportamento del layout del form) `form-layout`
- Form grid (La griglia del form è utilizzata per modificare il comportamento della griglia del form) `form-grid`
- Form text (Il testo del form è utilizzato per modificare il comportamento del testo del form) `form-text`
- Form reset (Il reset del form è utilizzato per ripristinare il comportamento predefinito del form) `form-reset`

Esempio di utilizzo di una classe di form:
```html
<form>
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label ">Email address</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
    </div>
    <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label
    ">Password</label>
    <input type="password" class="form-control" id="exampleInputPassword1">
    </div>
    <div class="mb-3 form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <label class="form-check-label" for="exampleCheck1">Check me out</label>
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

</details>

---


<details>
<summary>📋 Persistenza Json</summary>

*Dominio*|*Comando nel terminale*|*C#*
--|--|--
 JSON | `dotnet add package Newtonsoft.Json`| `using Newtonsoft.Json`

# FILE .JSON 

Invece di avere una struttura a matrice (come nel file .csv), abbiamo una coppia di CHIAVE: VALORE

> test.json
```json
{
    "nome":"antonio",
    "cognome":"rossi",
    "eta":20,
    "indirizzo": {
        "via":"via roma",
        "citta": "roma"
    }
}
```

supporta anche gli array (esempio: indirizzo) o elementi multipli (meno utilizzato, ma buono a sapersi):

```json
{
    "nome":"antonio",
    "cognome":"rossi",
    "eta":20,
    "indirizzo": {
        "via":"via roma",
        "citta": "roma"
    }
},
{
    "nome":"antonio",
    "cognome":"rossi",
    "eta":20,
    "indirizzo": {
        "via":"via roma",
        "citta": "roma"
    }
}
```
normalmente il file .json è unico per ogni oggetto (esempio l'oggetto "persona" viene rappresentato con il file persona.json, dove ogni persona diversa ha il proprio file .json).


```json
{
    "nome":"mario",
    "cognome":"verdi",
    "eta":20,
    "indirizzo": {
        "via":"via roma",
        "citta": "milano"
    },
    "NumeroDiTelefono":[
        {"tipo":"casa", "numero": "1234-56789"},
        {"tipo":"cellulare", "numero": "56789-1234"}
    ],
    "LingueParlate": ["italiano", "inglese", "spagnolo"],
    "sposato": false,
    "patente": null
}
```

# Serielizzazione / Deserializzazione 

Dipendenza necessaria per interpretare ed estrapolare informazioni dal file .json. **VA ESEGUITO IN OGNI PROGETTO IN CUI VOGLIAMO USARE**. 

`(Su www.nuget.org possiamo controllare la versione ufficiale o più aggiornato per .NET)`


---
#### Scriviamo del codice: 

```bash
dotnet add package Newtonsoft.Json
```
```csharp
using Newtonsoft.Json;
```


> test.json
```json
{
    "nome":"Felipe",
    "cognome":"Conceicao",
    "eta":20
}
```
> codice c#
```csharp
using Newtonsoft.Json;

Console.Clear();

string path = @"test.json";
string json = File.ReadAllText(path);
dynamic obj = JsonConvert.DeserializeObject(json); // deserializza il file
Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} eta: {obj.eta}");
```
> output console
```powershell
nome: Felipe cognome: Conceicao eta: 20
```
#### !!! NOTA !!!

- la variabile di destinazione del file .json deserializzato è di tipo `dynamic`
affinché cambi in base al valore richiamato.
- possiamo accedere alle informazioni interne attraverso sotto-proprietà o indici in caso di array.

---

# Serializzazione

## Obiettivo:

Chiedere all'utente di inserire in un file `.json` nome, cognome, indirizzo, citta
#### ESEMPIO DI SERIALIZZAZIONE:

```csharp
// chiedo all'utente di inserire i dati
Console.Write("nome > ");
string nome = Console.ReadLine();

Console.Write("cognome > ");
string cognome = Console.ReadLine();

Console.Write("indirizzo > ");
string indirizzo = Console.ReadLine();

Console.Write("citta > ");
string citta = Console.ReadLine();

// creo un oggetto con i dati inseriti
var obj4 = new
{
    nome = nome,
    cognome = cognome,
    indirizzo = indirizzo,
    citta = citta
};

// serializzo l'oggetto nel formato adatto
string json4 = JsonConvert.SerializeObject(obj4, Formatting.Indented);

// scrivo il file (creazione implicita)
File.WriteAllText("test4.json", json4);
```

> output: test4.json (dati inseriti durante il `dotnet run`)
```json
{
  "nome": "carlo",
  "cognome": "magno",
  "indirizzo": "roma",
  "citta": "impero romano"
}
```

### SERIALIZZAZIONE E DESERIALIZZAZIONE

```csharp
// creo un oggetto con i dati inseriti
var obj5 = new
{
    nome = "Mario Rossi",
    eta = 30,
    impiegato = true,
    indirizzo = new
    {
        via = "Via Roma 10",
        citta = "Roma",
        CAP = "00100"
    },
    numeroDiTelefono = new[]
    {
        new { tipo = "casa", numero = "123-5678"},
        new { tipo = "ufficio", numero = "876-54321"}
    },

    lingueparlate = new[] {"italiano", "inglese", "spagnolo"},
    sposato = false,
    patente = (string)null
};

// serializzo l'oggetto nel formato adatto
string json5 = JsonConvert.SerializeObject(obj5, Formatting.Indented);

// scrivo il file (creazione implicita)
File.WriteAllText("test5.json", json5);

string path6 = @"test5.json";
string json6 = File.ReadAllText(path6);
dynamic objNuovo = JsonConvert.DeserializeObject(json6)!;
Console.WriteLine($"Estraggo da {path6} la citta: {objNuovo.indirizzo.citta}");

ACapo();

// ESEMPIO DI SCRITTURA DI PIU OGGETTI IN UN FILE JSON

// creo un array di oggetti
var obj7 = new[]
{
    new { nome = "Mario", cognome = "Rossi"},
    new { nome = "Luca", cognome = "Bianchi"} 
};

//serializzo l'array
string json7 = JsonConvert.SerializeObject(obj7, Formatting.Indented);

// scrivo il file
File.WriteAllText("test6.json", json7);


// deserializzazione

string path8 = @"test6.json";
string newJson = File.ReadAllText(path8);
dynamic objArray = JsonConvert.DeserializeObject(newJson);
Console.WriteLine($"estraggo da {path8} il nome dal secondo array: {objArray[1].nome}");
```

---

# Serializzazione e deserializzazione di modelli


## Classe

```cs
public class Chave
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Codigo { get; set; }
    public string Pagina { get; set; }
}
```

## Json

> esempio path = @"Data/chaves_list.json"
```json
[
    {
        "Id": "1071",
        "Nome": "AGL Fech Elétrica",
        "Codigo": "GYA001071",
        "Pagina": "1.1"
    },
    {
        "Id": "1105",
        "Nome": "AL Fech.",
        "Codigo": "GYA001105",
        "Pagina": "1.1"
    },
    {
        "Id": "31",
        "Nome": "Aliança Gde. L.Y.",
        "Codigo": "GYA000031",
        "Pagina": "1.1"
    },
    {
        "Id": "62",
        "Nome": "Aliança Pacific",
        "Codigo": "GYA000062",
        "Pagina": "1.1"
    }
]
```

## Deserializzazione

```cs
string path = @"Data/chaves_list.json";
var json = File.ReadAllText(path); 
// var json = System.IO.File.ReadAllText(path) // se File è una classe già usata nell'archetipo
var JsonConvert.DeserializeObject<List<Chave>>(json);
```

## Serializzazione

```cs
 string filePath = "categorie.json"; // percorso in cui memorizzare i dati

 string jsonData = JsonConvert.SerializeObject(categorie, Formatting.Indented);
// serializzo cioè converto la lista in una stringa indentata 

string pathCarrello = Path.Combine(dirCategorie, filePath);
// creo il percorso al file 

File.WriteAllText(pathCarrello, jsonData);
// scrivo il file. se esiste lo sovrascrive, se non esiste lo crea
```
</details>


---
<details>
<summary>✂️ Shortcuts</summary>

# VSCODE Shortcuts


🟢|🟡|🟠|🔴
--|--|--|--
Frequenti|Monitoraggio|Navigazione|Sistema

*Funzione* |*Shortcut*| |
--|--|--
Salva file | `ctrl + S`|🟢
Formattazione codice|`alt + shift + F`|🟢
Mostra  /  Nascondi il terminale|`ctrl + J`|🟢
Mostra  /  Nascondi Explorer | `ctrl + B`|🟢
Cerca nel codice | `ctrl + F`|🟢
Commentare blocco di codice selezionato|`ctrl + K + C`|🟢
Decommentare blocco di codice selezionato|`ctrl + K + U`|🟢
Spostare un blocco o una linea di codice | `alt + ↓` `alt + ↑`|🟢
Apri metodo in una nuova scheda| `ctrl + alt + [click sul metodo]`|🟢
Vai a linea di codice con errore da terminale in scheda corrente| `ctrl + [click su errore]`|🟢
Vai a linea di codice con errore da terminale in nuova scheda | `ctrl + alt + [click su errore]`|🟢
Chiusura della scheda corrente | `ctrl + W`|🟢
Zoom In  / Zoom Out | `ctrl + '+'` `ctrl + '-'`|🟢
Spostare cursore a inizio / fine parola|`alt + →` `alt + ←`|🟢
Folding del codice| `ctrl + K + 0`|🟡
Unfolding del codice| `ctrl + K + J`|🟡
Muoversi tra le schede aperte|`ctrl + alt + →` `ctrl + alt + ←`|🟠
Navigazione dei file dalla barra di ricerca| `ctrl + P`|🟠
Ricerca impostazione dalla barra di ricerca| `ctrl + P + > [impostazione]`|🔴


</details>

---

<details>
<summary>🗃️ WebApp .NET & Sqlite</summary>

*Dominio*|*Comando nel terminale*|*C#*
--|--|--
 SQLite | `dotnet add package Microsoft.Data.Sqlite`| `using Microsoft.Data.Sqlite`

 # Data Annotations

- I modelli sono stati aggiornati con attributi di validazione
- Le pagine Razor (Create e Edit) inlcludono gli helperper visualizzare gli errori di validazione.

# Aggiornamento dei Modelli con Data Annotation

Models/Prodotto.cs
Models/Categoria.cs

```c#
using System.ComponentModel.DataAnnotations; // dipendenza DataAnnotations

public class Categoria
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome della categoria è obbligatorio.")]
    // [Required] - è il DataAnnotation , (ErrorMessage = "...") - è il messaggio
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Nome { get; set; }
}
```

- `[Required]` - è il DataAnnotation
- `(ErrorMessage = "...")` - è il messaggio restituito in caso di errato inserimento

Ne esistono diversi, come

- `[Range]`
- `[StringLength]`

ecc...

```c#
namespace _04_webapp_sqlite.Models;

public class Prodotto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome del prodotto è obbligatorio.")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Il prezzo è obbligatorio.")]
    [Range (0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di 0")]
    public double Prezzo { get; set; }

    [Required(ErrorMessage = "La categoria è obbligatoria.")]
    public int CategoriaId { get; set; }
    [Required(ErrorMessage = "Il fornitore è obbligatorio.")]
    public int FornitoreId { get; set; }
}
```

---

# Utilizzo della validazione in HTML

```html
<span asp-validation-for="Prodotto.Nome" class="text-danger"
  ><span></span
></span>
```

e va inserito sotto l'input

```html
<label asp-for="Prodotto.Nome">Nome</label>
<input type="text" class="form-control" asp-for="Prodotto.Nome" />
<span asp-validation-for="Prodotto.Nome" class="text-danger"></span>
```

---

# E' necessario...

## 1. che il modello abbia lo using System.ComponentModel.DataAnnotations

```cs
using System.ComponentModel.DataAnnotations;
```

## 2. che i DataAnnotation siano sopra il campo del modello

```cs
[Required(ErrorMessage = "Il nome del prodotto è obbligatorio.")]
[StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
public string Nome { get; set; }
```

## 3. che nell'html, prima del form ci sia lo script per bypassare i messaggi di validazioni di default

```c#
@section Scripts
{
    <partial name="_ValidationScriptsPartial"/>
}
```

## 4. che nel back-end ci sia nell' OnPost() il controllo della validazione

```cs
if (!ModelState.IsValid) // se il modello non è valido
{
    // operazioni eseguite nel OnGet() per visualizzare la pagina
    return Page(); // reindizzamento alla stessa pagina con i messaggi di errore
}
```

Nel caso di questa WebApp, in `Modifica.cs` e in `AggiungiProdotto.cs` avremo come prima istruzione del `OnPost`:

```cs
if (!ModelState.IsValid)
{
    CaricaCategorie();
    return Page();
}
```

# SQL, Partial, Model (14/02/2025)

### Obiettivo:

Creare una Dashboard `Prodotti Piu Costosi`, `Prodotti Recenti`, `Prodotti in Elettronica` usando le `_PartialView`

---

1. Creare pagina Dashboard.cshtml

```cs
@page
@model Dashboard
@namespace _04_webapp_sqlite.Prodotti
@{
    ViewData["Title"] = "Dashboard";
}
<h1>@ViewData["Title"]</h1>
<div class="container-fluid">
    <div class="row">
        <div class="col-4">
            <partial name="_ProdottiPiuCostosi" model="Model.ProdottiPiuCostosi" />
        </div>
        <div class="col-4">
            <partial name="_ProdottiRecenti" model="Model.ProdottiRecenti" />
        </div>
        <div class="col-4">
            <partial name="_ProdottiCategoriaSpecifica" model="Model.ProdottiCategoria" />
        </div>
    </div>
</div>
```

---

2. Creare i modelli Dashboard.cshtml.cs

```cs
namespace _04_webapp_sqlite.Prodotti;

public class Dashboard : PageModel
{
    private readonly ILogger<Dashboard> _logger;

    // Modelli da trasmettere alle partialView
    public List<ProdottoViewModel>? ProdottiPiuCostosi { get; set; } = new();
    public List<ProdottoViewModel>? ProdottiRecenti { get; set; } = new();
    public List<ProdottoViewModel>? ProdottiCategoria { get; set; } = new();

    public Dashboard(ILogger<Dashboard> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var queryCostosi = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Prezzo DESC LIMIT 5";
                // Usiamo LEFT JOIN invece che JOIN per prendere anche i prodotti che non hanno una categoria associata
        ProdottiPiuCostosi = ExecuteQuery(queryCostosi);

        var queryRecenti = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Id DESC LIMIT 5";

        ProdottiRecenti = ExecuteQuery(queryRecenti);

        var queryCategoria = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                WHERE p.CategoriaId = 11 LIMIT 5";

        ProdottiCategoria = ExecuteQuery(queryCategoria);
    }

    // metodo per ottenere liste filtrate via query
    public List<ProdottoViewModel> ExecuteQuery(string query)
    {
        List<ProdottoViewModel> ProdottiFiltrati = new List<ProdottoViewModel>();
        using (var connection = DatabaseInitializer.GetConnection())
        {

            connection.Open();
            using (var command = new SqliteCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        ProdottiFiltrati?.Add(new ProdottoViewModel
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Prezzo = reader.GetDouble(2),
                            // se la categoria è nulla, restituiamo "Nessuna categoria"
                            CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
                        });
                    }
                }
            }
        };
        return ProdottiFiltrati;
    }
}
```

3. Costruire le \_PartialView

> Prodotti Recenti

```cs
<h3>Prodotti Recenti</h3>

@foreach (var prodotto in Model)
{
    <strong class="fs-6" style="text-decoration: underline;">@prodotto.Nome</strong>
    <p class="fs-6" style=" display: inline;">@prodotto.Prezzo.ToString("F2") €</p>
    <p class="fs-6">@prodotto.CategoriaNome</p>

}
```

> Prodotti Più Costosi

```cs
<h3>Prodotti Più Costosi</h3>

@foreach (var prodotto in Model)
{
    <strong class="fs-6" style="text-decoration: underline;">@prodotto.Nome</strong>
    <p class="fs-6" style=" display: inline;">@prodotto.Prezzo.ToString("F2") €</p>
    <p class="fs-6">@prodotto.CategoriaNome</p>
}
```

> Prodotti in @categoria (Elettronica in questo caso)

```cs
@{
        string categoria = null;

        //ciclo per estrapolare nome categoria
        //categoria = Model.First().CategoriaNome
        foreach (var p in Model)
        {
                categoria = p.CategoriaNome;
        }

        <h3>Prodotti in @categoria</h3>

        @foreach (var prodotto in Model)
        {

                <strong class="fs-6" style="text-decoration: underline;">@prodotto.Nome</strong>
                <p class="fs-6" style=" display: inline;">@prodotto.Prezzo.ToString("F2") €</p>
                <p class="fs-6">@prodotto.CategoriaNome</p>
        }
}
```

# Comprensione del codice

Il tag `<partial>` richiede il nome della pagina attraverso `name ="_html"`, e il modello `model = "Model"`.

```cs
<partial name="_ProdottiPiuCostosi" model="Model.ProdottiPiuCostosi" />
```

In Model.ProdottiPiuCostosi, `Model` fa riferimento al modello indicato nella pagina Dashboard.cshtml (in questo caso `@model Dashboard`)

```cs
@page
@model Dashboard
@namespace _04_webapp_sqlite.Prodotti
@{
    ViewData["Title"] = "Dashboard";
}
```

Siccome nel modello `Dashboard.cshtml.cs` abbiamo definito 3 campi public

```cs
    public List<ProdottoViewModel>? ProdottiPiuCostosi { get; set; } = new();
    public List<ProdottoViewModel>? ProdottiRecenti { get; set; } = new();
    public List<ProdottoViewModel>? ProdottiCategoria { get; set; } = new();
```

possiamo trasmettere al `<partial>` il campo tramite la dicitura

```cs
Model.ProdottiPiuCostosi
Model.ProdottiRecenti
Model.ProdottiCategoria
```

Dunque ora nella partial ciò che è stato passato come `Model.ProdottiCategoria` va utilizzato come `Model`
Infatti, nel ciclo foreach, ciclo in Model.

```cs
@{
        string categoria = null;

        //Estrapolo CategoriaNome dal primo elemento della lista
        categoria = Model.First().CategoriaNome;

        <h3>Prodotti in @categoria</h3>

        // ciclo dentro Model che in realtà è ProdottiCategoria del modello Dashboard
        @foreach (var prodotto in Model)
        {

                <strong class="fs-6" style="text-decoration: underline;">@prodotto.Nome</strong>
                <p class="fs-6" style=" display: inline;">@prodotto.Prezzo.ToString("F2") €</p>
                <p class="fs-6">@prodotto.CategoriaNome</p>
        }
}
```

### Riassumendo:

1. Gestisco il filtraggio via SQL
2. Salvo le liste filtrate nei campi del modello Dashboard
3. Distribuisco i dati alle \_PartialView richiamando il campo interessato (es. Model.ProdottiPiuCostosi)

---

# UtilityDB.cs

Tre metodi

Esegue una query che non restituisce dati (INSERT, UPDATE, DELETE).

```cs
    public static int ExecuteNonQuery(string sql, Action<SqliteCommand> setupParameters = null)
```

Esegue una query che restituisce un valore scalare (esempio un Count) (valori singoli )

> Ambito di utilizzo: restituire un solo valore

```cs
    public static T ExecuteScalar<T>(string sql, Action<SqliteCommand> setupParameters = null)
```

Esegue una query che restituisce più righe e le converte in una lista di oggetti di tipo T.

```cs
    public static List<T> ExecuteReader<T>(string sql, Func<Sqlitereader, T> converter, Action<SqliteCommand> setupParameters)
```

### Delegati

Uso Action per passare un metodo come parametri (in questo caso`Action<SqliteCommand> setupParameters`).

`Invoke()` invoca il metodo passando come parametro il comando.

```cs
using Microsoft.Data.Sqlite;

public static class UtilityDB
{
    /// <summary>
    /// Esegue una query che non restituisce dati (INSERT, UPDATE, DELETE).
    /// </summary>
    /// <param name="sql">La query SQL.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Il numero di righe interessate.</returns>
    public static int ExecuteNonQuery(string sql, Action<SqliteCommand> setupParameters = null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        using var command = new SqliteCommand(sql, connection);
        setupParameters?.Invoke(command); // Il metodo Invoke esegue il delegate setupParameters, cioè la funzione che gli passiamo

        return command.ExecuteNonQuery();
    }
    /// <summary>
    /// Esegue una query che restituisce un valore scalare.
    /// </summary>
    /// <typeparam name="T">Il tipo del valore atteso.</typeparam>
    /// <param name="sql">La query SQL.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Il valore restituito convertito al tipo T.</returns>
    public static T ExecuteScalar<T>(string sql, Action<SqliteCommand> setupParameters = null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        using var command = new SqliteCommand(sql, connection);
        setupParameters?.Invoke(command);

        var result = command.ExecuteScalar();
        if (result == null || result == DBNull.Value)
            return default(T);

        return (T)Convert.ChangeType(result, typeof(T));
    }
    /// <summary>
    /// Esegue una query che restituisce più righe e le converte in una lista di oggetti di tipo T.
    /// </summary>
    /// <typeparam name="T">Il tipo di oggetto da restituire per ogni riga.</typeparam>
    /// <param name="sql">La query SQL.</param>
    /// <param name="converter">Funzione per convertire una riga (<see cref="SqliteDataReader"/>) in un oggetto di tipo T.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Una lista di oggetti di tipo T.</returns>
    public static List<T> ExecuteReader<T>(string sql, Func<Sqlitereader, T> converter, Action<SqliteCommand> setupParameters)
    {
        var list = new List<T>();
        using var connection = DatabaseInitializer.GetConnection();
        using var command = new SqliteCommand(sql, connection);
        setupParameters?.Invoke(command);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(converter(reader));
        }
        return list;
    }
}

```

SimpleLogger.cs

```cs
public static class SimpleLogger
{
    // Percorso del file di log (puoi modificare il percorso se necessario)
    private static readonly string logFilePath = "log.txt";

    /// <summary>
    /// Registra un messaggio nel file di log con data e ora.
    /// </summary>
    /// <param name="message">Il messaggio da loggare.</param>
    public static void Log(string message)
    {
        try
        {
            using StreamWriter writer = new StreamWriter(logFilePath, append: true);
            writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }
        catch (Exception)
        {
            // Se il logging fallisce, l'errore viene ignorato.
        }
    }

    /// <summary>
    /// Registra un'eccezione nel file di log.
    /// </summary>
    /// <param name="ex">L'eccezione da loggare.</param>
    public static void Log(Exception ex)
    {
        Log($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");
    }
}
```

# 17/02/2025

Utilizzo della classe UtilityDB (esempio lettura `List<Categoria>`)

```cs
try
{
    Categorie = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new Categoria
    {
        Id = reader.GetInt32(0),
        Nome = reader.GetString(1)
    });
}
catch (Exception ex)
{
    SimpleLogger.Log(ex);
}
```

Utilizzo della classe UtilityDB (esempio lettura `List<ProdottoViewModel>`):

```cs
try
{
    Prodotti = UtilityDB.ExecuteReader(@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
    FROM Prodotti p
    LEFT JOIN Categorie c ON p.CategoriaId = c.Id
    WHERE c.Id = @id", reader => new ProdottoViewModel
    {
        Id = reader.GetInt32(0),
        Nome = reader.GetString(1),
        Prezzo = reader.GetDouble(2),
        // se la categoria è nulla, restituiamo "Nessuna categoria"
        CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
    },
    command =>
    {
        command.Parameters.AddWithValue("@id", IdCategoria);
    }
    );
}
catch (Exception ex)
{
    SimpleLogger.Log(ex);
}
```

Esempio Inserimento prodotto (scrittura con passaggio di parametri):

```cs
var sql = @"INSERT INTO Prodotti (Nome, Prezzo, CategoriaId) VALUES (@nome, @prezzo, @categoria)";
try
{
    UtilityDB.ExecuteNonQuery(sql, command =>
    {
        command.Parameters.AddWithValue("@nome", Prodotto.Nome);
        command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
        command.Parameters.AddWithValue("@categoria", Prodotto.CategoriaId);
    }
    );
}
catch (Exception ex)
{
    SimpleLogger.Log(ex);
        }
```

Dettaglio prodotto (leggendo una lista e associando al modello il singolo oggetto):

```cs
public ProdottoViewModel? Prodotto { get; set; } = new();
```

```cs
try
{
    var prodotti = UtilityDB.ExecuteReader(@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
        FROM Prodotti p
        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
        WHERE p.Id = @id", reader => new ProdottoViewModel
    {
        Id = reader.GetInt32(0),
        Nome = reader.GetString(1),
        Prezzo = reader.GetDouble(2),
        // se la categoria è nulla, restituiamo "Nessuna categoria"
        CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
    },
    command =>
    {
        command.Parameters.AddWithValue("@id", id);
    }
    );

    // inizializzo il campo 'Prodotto' della classe Dettaglio.cshtml.cs
    // con il primo (e unico elemento) della lista 'var prodotti' attraverso
    // il metodo .First()
    Prodotto = prodotti.First();
}
catch (Exception ex)
{
    SimpleLogger.Log(ex);
}
```

---

### Da testare (NON FUNZIONA)

Estrazione di un singolo elemento attraverso ExecuteScalar:

```cs
Prodotto = UtilityDB.ExecuteScalar<ProdottoViewModel>(@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
        FROM Prodotti p
        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
        WHERE p.Id = @id", reader => new ProdottoViewModel
    {
        Id = reader.GetInt32(0),
        Nome = reader.GetString(1),
        Prezzo = reader.GetDouble(2),
        // se la categoria è nulla, restituiamo "Nessuna categoria"
        CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
    },
    command =>
    {
        command.Parameters.AddWithValue("@id", id);
    }
    );
```

### NON FUNZIONA: motivo

`ExecuteScalar` non contiene il `ExecuteReader()` ma esegue il comando di Sqlite `ExecuteScalar()`, che attraverso la Query restituisce un valore numerico, tipo `int`.

# USO CORRETTO:

```cs
public int TotaleProdotti { get; set; }
```

```cs
try
        {
            TotaleProdotti = UtilityDB.ExecuteScalar<int>("SELECT COUNT (*) FROM Prodotti");
        }
        catch(Exception ex)
        {
            SimpleLogger.Log(ex);
        }
```

---

Nuova classe Dashboard che esegue le query attraverso le UtilityDB:

```cs
public void OnGet()
    {
        var queryCostosi = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Prezzo DESC LIMIT 5";
        try
        {
            ProdottiPiuCostosi = UtilityDB.ExecuteReader(queryCostosi, reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        var queryRecenti = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Id DESC LIMIT 5";
        try
        {
            ProdottiRecenti = UtilityDB.ExecuteReader(queryRecenti, reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        var queryCategoria = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                WHERE p.CategoriaId = 11 LIMIT 5";
        try
        {
            ProdottiCategoria = UtilityDB.ExecuteReader(queryCategoria, reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
```

---

## Implementazione Extra:

Da pagina Dettaglio, il tasto `Indietro` fa tornare alla pagina precedente alla relativa

Esempio:

> Front-End

```html
<form method="post">
  <input type="hidden" name="returnUrl"
  value="@HttpContext.Request.Headers["Referer"]" />
  <button type="submit" class="btn btn-primary">Indietro</button>
</form>
```

> Back-End

```cs
public IActionResult OnPost(string? returnUrl)
    {
        if (!string.IsNullOrEmpty(returnUrl))
        {
            return Redirect(returnUrl);
        }

        return RedirectToPage("Index"); // Se non c'è un URL di ritorno, vai a Index
    }
```

### Spiegazione:

Nel tag `<form method="post">`, attraverso un input nascosto

```html
<input type="hidden" name="returnUrl"
value="@HttpContext.Request.Headers["Referer"]" />
```

passiamo alla variabile stringa `returnUrl` il valore `@HttpContext.Request.Headers["Referer"]`, dove `"Referer"` contiene l'URL della pagina da cui proviene l'utente.

Se `returnUrl` NON è `Null` o `Empty` reindirizza verso la relativa pagina precedente:

```cs
return Redirect(returnUrl);
```

Nel caso invece la stringa sia vuota, reindizza all'index:

```cs
return RedirectToPage("Index");
```

# 18/02/2025

Necessita di:

```cs
using System.Globalization;
```

PriceFormatter.cs

```cs
/// <summary>
///  Formatta un valore double come valuta.
/// </summary>
/// <param name="price">Il prezzo da formattare.</param>
/// <returns>Una stringa formattata come valuta.</returns
public static class PriceFormatter
{
    public static string Format (double price)
    {
        return price.ToString("C", CultureInfo.CurrentCulture);
    }
}
```

Esempio di utilizzo:

```html
<td>@PriceFormatter.Format(prodotto.Prezzo)</td>
```

---

# Paginazione

## Classe della paginazione

PaginatedList.cs

```cs
public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count/(double)pageSize);
        this.AddRange(items); // Aggiunge gli elementi alla lista usando 'this'
        // che si riferisce alla lista stessa
    }

    public bool HasPreviewPage => PageIndex >1; // restituisce true
    // se c'è una pagina precedente
    public bool HasNextPage => PageIndex < TotalPages; // restituisce true
    // se c'è una pagina successiva
}
```

## Modello della paginazione

PaginationModel.cs

Questo modello viene usato nelle partial view per generare i link di paginazione. Include le informazioni sulla pagina corrente, sul numero totale di pagine e una funzione per generare l'URL di ciascuna pagina.

```cs
public class PaginationModel
{
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviewPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
    public Func<int, string> PageUrl { get; set; }
}
```

## Front-End della partial

Creiamo una partial per la paginazione

```html
@model PaginationModel
<nav aria-label="Page navigation">
  <ul class="pagination">
    @if (Model.HasPreviewPage) {
    <li class="page-item">
      <a
        class="page-link"
        href="@Model.PageUrl(Model.PageIndex - 1)"
        aria-label="Previous">
        <span aria-hidden="true">&laquo;</span>
      </a>
    </li>
    } else {
    <li class="page-item disabled">
      <span aria-hidden="true" aria-label="Previous">&laquo;</span>
    </li>
    } @for (int i = 1; i <= Model.TotalPages; i++) { if (i == Model.PageIndex) {
    <li class="page-item active">
      <span class="page-link">@i</span>
    </li>
    } else {
    <li class="page-item">
      <a class="page-link" href="@Model.PageUrl(i)"></a>
    </li>
    } } @if (Model.HasNextPage) {
    <li class="page-item">
      <a
        class="page-link"
        href="@Model.PageUrl(Model.PageIndex + 1)"
        aria-label="Next">
        <span aria-hidden="true">&raquo;</span>
      </a>
    </li>
    } else {
    <li class="page-item disabled">
      <span class="page-link" aria-label="Next">
        <span aria-hidden="true" aria-label="Previous">&raquo;</span>
      </span>
    </li>
    }
  </ul>
</nav>
```

#

PaginatedIndex.cshtml.cs

```cs
namespace _04_webapp_sqlite.Prodotti;

public class PaginatedIndexModel : PageModel
{
    public PaginatedList<ProdottoViewModel> Products { get; set; }
    public int PageSize { get; set; } = 5; // numero di prodotti per pagina
    public void OnGet(int? pageIndex)
    {
        // L'espressione sotto equivale a:

        // int currentPage;
        // if (pageIndex != null)
        // {
        //     currentPage = pageIndex.Value; // Estrai il valore dall'Nullable<int>
        // }
        // else
        // {
        //     currentPage = 1;
        // }

        int currentpage = pageIndex ?? 1;

        //recupera il numero totale di prodotti
        int totalCount = UtilityDB.ExecuteScalar<int>("SELECT COUNT(*) FROM Prodotti");
        //calcola l'offest per la query
        int offset = (currentpage - 1) * PageSize;

        // Recupera i prodotti per la pagina corrente
        // in Sqlite si usa LIMIT  e OFFSET per la paginazione
        // limit = quanti elementi voglio
        // offset = da dove voglio partire
        // offset = (pagina corrente - 1) * elementi per pagina
        // LIMIT 5 OFFSET 0 -> 5 elementi a partire dall'elemento 0

        string sql = $@"
                        SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
                        FROM Prodotti p
                        LEFT JOIN Categorie c ON p.Categorie = c.Id
                        ORDER BY p.Id
                        LIMIR {PageSize} OFFSET {offset}
                        ";

        var items = UtilityDB.ExecuteReader(sql, reader => new ProdottoViewModel
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Prezzo = reader.GetDouble(2),
            // se la categoria è nulla, restituiamo "Nessuna categoria"
            CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
        });

        Products = new PaginatedList<ProdottoViewModel>(items, totalCount, currentpage, PageSize);
    }
}
```

## Front-end della pagina

PaginatedIndex.cshtml

```html
@page "PaginatedIndex"
@model PaginatedIndexModel
@namespace _04_webapp_sqlite.Prodotti
@{
    ViewData["Title"] = "Prodotti impaginati";
    // configuriamo il modello per la paginazione
    PaginationModel paginationModel = new PaginationModel
    {
        PageIndex = Model.Products.PageIndex,
        TotalPages = Model.Products.TotalPages,
        PageUrl = page => Url.Page("PaginatedIndex", new { pageIndex = page })
    };
}

<div class="container">
    <table class="table">
        <thead>
            <tr>
                <th class="">Nome</th>
                <th class="" style="display:block">Prezzo</th>
                <th class="">Categoria</th>
                <th class="">Actions</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var prodotto in Model.Products)
            {
                <tr>
                    <td class="">
                        <a asp-page="Dettaglio" asp-route-id="@prodotto.Id">
                            @prodotto.Nome
                        </a>
                    </td>
                    <td>@PriceFormatter.Format(prodotto.Prezzo)</td>
                    <td class="">@prodotto.CategoriaNome</td>

                    <td><a asp-route-id="@prodotto.Id" asp-page="Modifica">
                            <div class="btn green"><i class="fa-solid fa-pen-to-square" style="color:white"></i>
                            </div>
                        </a>

                        <a asp-page="Elimina" asp-route-id="@prodotto.Id">
                            <div class="btn red"><i class="fa-solid fa-trash" style="color:white"></i></div>
                        </a>
                    </td>
                </tr>
            }

        </tbody>
    </table>
    <partial name="_Pagination" model="paginationModel">
</div>
```

# 19/02/2025

Utility che restituisce un `.css` a seconda delle condizioni.

```cs
///<summary>
/// Restituisce "active" se currentPage è uguale a expectedPage (ignorano il case), altrimenti una stringa vuota.
///</summary>
public static class FrontendUtil
{
    public static string ActiveClass(string currentPage, string expectedPage)
    {
        return currentPage.Equals(expectedPage, StringComparison.OrdinalIgnoreCase) ? "active" : "";
    }
}
```

Utilizzo:

```html
 <li class="nav-item">
    <a class="nav-link @FrontendUtil.ActiveClass(ViewContext.RouteData.Values["page"]?.ToString() ?? "", "/Index")" asp-area="" asp-page="/Index">Home</a>
</li>
```

```css
.active{
  text-decoration: underline;
  color: white;
}
```


# 20/02/2025

Implementazione fornitori:

> Note: non essendo stati esplicitati i campi necessari, la classe fornitori conterrà 
solo i campi Id, Nome, Contatto

+ 1 Creazione del modello

Modello fornitori `Fornitori.cs`
```cs
namespace _04_webapp_sqlite.Models;

public class Fornitori
{
    public int Id { get; set; }
    public string Nome { get; set; }
    [Required]
    [EmailAddress]
    public string Contatto { get; set; }
}
```

Modifico modello Prodotti e ProdottoViewModel per contenere anche Id del fornitore

Prodotto.cs

```cs
using System.ComponentModel.DataAnnotations;

// Modello del prodotto
namespace _04_webapp_sqlite.Models;

public class Prodotto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome del prodotto è obbligatorio.")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Il prezzo è obbligatorio.")]
    [Range (0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di 0")]
    public double Prezzo { get; set; }

    [Required(ErrorMessage = "La categoria è obbligatoria.")]
    public int CategoriaId { get; set; }
    public int FornitorieId { get; set; }
}
```

ProdottoViewModel.cs

```cs
namespace _04_webapp_sqlite.Models;
public class ProdottoViewModel {
    // proprietà
    public int Id { get; set; }
    public string? Nome { get; set; }
    public double Prezzo { get; set; }
    public string? CategoriaNome { get; set; }
    // Attraverso la LEFT JOIN sarà collegato il nome del fornitore
    // attraverso il suo Id
    public string? FornitoreNome { get; set; } 
}
```

+ 2 Creazione della tabella Fornitori in `DatabaseInitializer.cs`

```cs
// Se la tabella non esistente creo la tabella la creo tramite query e ExecuteNonQuery
string createFornitoriTabella = @"CREATE TABLE IF NOT EXISTS Fornitori (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nome TEXT NOT NULL,
    Contatto TEXT NOT NULL";
    
// Eseguo il comando SQL
UtilityDB.ExecuteNonQuery(createFornitoriTabella);
```

Modifico la query di creazione dei prodotti per ospitare i fornitori (sarà necessario eliminare il Database per re-Inizializzarlo con le nuove tabelle)

```cs
var createProdottiTabella = @"
                CREATE TABLE IF NOT EXISTS Prodotti (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Prezzo REAL NOT NULL,
                CategoriaId INTEGER NOT NULL,
                FornitoreId INTEGER NOT NULL,
                FOREIGN KEY(CategoriaId) REFERENCES Categorie(Id),
                FOREIGN KEY(FornitoreId) REFERENCES Fornitori(Id)
                );";

// lanciare il comando sulla connessione
using (var command = new SqliteCommand(createCategorieTabella, connection)) {
    // eseguiamo il comando
    command.ExecuteNonQuery();
};
```

> NOTA: necessario creare prima la tabella dei fornitori e delle categorie dal momento
che i prodotti faranno riferimento all'Id delle due tabelle

+ 3 Seeding dei fornitori

```cs
// Leggo il numero di elementi nella tabella Fornitori del DB
var countFornitori = UtilityDB.ExecuteScalar<int>("SELECT COUNT (*) FROM Fornitori");
// Se la tabella è vuota eseguo il seeding
if (countFornitori == 0)
{
   string seedingFornitori = @"
    INSERT INTO Fornitori (Nome, Contatto) VALUES
    ('Nike', 'fornitore@nike.com'),
    ('Ikea', 'fornitore@ikea.com'),
    ('Apple', 'fornitore@apple.com'),
    ('Mulino Bianco', 'fornitore@mulinobianco.com'),
    ('Brico', 'fornitore@brico.com'),
    ('Samsung', 'fornitore@samsung.com'),
    ('Zara', 'fornitore@zara.com')
    ";
    // Eseguo il comando SQL
    UtilityDB.ExecuteNonQuery(seedingFornitori); 
}

+ 4 Seeding dei prodotti con collegamento alla tabella fornitori

```cs

var countProdotti = (long)countProdottiCommand.ExecuteScalar();
// se non ci sono prodotti li creiamo
if (countProdotti == 0){
    var insertProdotti = @"
        INSERT INTO Prodotti (Nome, Prezzo, CategoriaId, FornitoreId) VALUES
        ('Smartphone', 500, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica'), (SELECT Id FROM Fornitori WHERE Nome = 'Apple')),
        ('Tablet', 300, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica'), (SELECT Id FROM Fornitori WHERE Nome = 'Apple')),
        ('TV', 700, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica'), (SELECT Id FROM Fornitori WHERE Nome = 'Samsung')),
        ('Cuffie', 100, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica'), (SELECT Id FROM Fornitori WHERE Nome = 'Samsung')),
        ('Maglietta', 20, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento'), (SELECT Id FROM Fornitori WHERE Nome = 'Zara')),
        ('Pantaloni', 40, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento'), (SELECT Id FROM Fornitori WHERE Nome = 'Zara')),
        ('Scarpe', 50, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento'), (SELECT Id FROM Fornitori WHERE Nome = 'Zara')),
        ('Cappotto', 100, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento'), (SELECT Id FROM Fornitori WHERE Nome = 'Zara')),
        ('Divano', 300, (SELECT Id FROM Categorie WHERE Nome = 'Casa'), (SELECT Id FROM Fornitori WHERE Nome = 'Ikea')),
        ('Tavolo', 150, (SELECT Id FROM Categorie WHERE Nome = 'Casa'), (SELECT Id FROM Fornitori WHERE Nome = 'Ikea')),
        ('Sedia', 50, (SELECT Id FROM Categorie WHERE Nome = 'Casa'), (SELECT Id FROM Fornitori WHERE Nome = 'Ikea')),
        ('Letto', 200, (SELECT Id FROM Categorie WHERE Nome = 'Casa'), (SELECT Id FROM Fornitori WHERE Nome = 'Ikea')),
        ('Rasaerba', 200, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio'), (SELECT Id FROM Fornitori WHERE Nome = 'Brico')),
        ('Soffiatore', 100, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio'), (SELECT Id FROM Fornitori WHERE Nome = 'Brico')),
        ('Tagliaerba', 150, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio'), (SELECT Id FROM Fornitori WHERE Nome = 'Brico')),
        ('Tosaerba', 250, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio'), (SELECT Id FROM Fornitori WHERE Nome = 'Brico')),
        ('Pallone', 10, (SELECT Id FROM Categorie WHERE Nome = 'Sport'), (SELECT Id FROM Fornitori WHERE Nome = 'Nike')),
        ('Scarpe da calcio', 50, (SELECT Id FROM Categorie WHERE Nome = 'Sport'), (SELECT Id FROM Fornitori WHERE Nome = 'Nike')),
        ('Rete da calcio', 100, (SELECT Id FROM Categorie WHERE Nome = 'Sport'), (SELECT Id FROM Fornitori WHERE Nome = 'Nike')),
        ('Pallavolo', 20, (SELECT Id FROM Categorie WHERE Nome = 'Sport'), (SELECT Id FROM Fornitori WHERE Nome = 'Nike'));
    ";
    using (var command = new SqliteCommand(insertProdotti, connection)) {
        command.ExecuteNonQuery();                
    }
}
```

+ 5 Distrubuzione dei dati

Distribuzione dei dati del modello aggiornato da DB in Index.cshtml.cs 

```cs
List<ProdottoViewModel> items = UtilityDB.ExecuteReader($@"
                SELECT p.Id, p.Nome, p.Prezzo, 
                c.Nome as Categoria,
                f.Nome as Fornitore
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                LEFT JOIN Fornitori f ON p.FornitoreId = f.Id
                ORDER BY p.Nome LIMIT {PageSize} OFFSET {offset}", reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    // se la categoria è nulla, restituiamo "Nessuna categoria"
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3),
                    FornitoreNome = reader.IsDBNull(4) ? "Nessun fornitore" : reader.GetString(4),
                });

Prodotti = new PaginatedList<ProdottoViewModel>(items, totalCount, currentpage, PageSize);
```

+ 6 Visualizzazione del campo fornitore in `Prodotti/Index`

Aggiungo la colonna Fornitori alla tabella 

```html
<th class="">Fornitore</th>
```

Aggiungo il campo alla colonna 

```html
@foreach (var prodotto in Model.Prodotti)
{
    <tr>
        ...
        <td class="">@prodotto.FornitoreNome</td>
        ...
    </tr>
}
```

---

# TODO:

- [x] Gestione CRUD dei prodotti <u>considerando la modifica ai due modelli</u> (`Prodotto.cs` e `ProdottoView.cs`)

- [x] Creazione di una pagina `Dettaglio Fornitore` che esporrà il contatto del fornitore. 
- [x] Creazione di una pagina `Lista Fornitori`, con link a `Dettaglio Fornitore`
- [x] Implementae operazioni CRUD sui Fornitori


- [x] La pagina deve essere accessibile tramite link da Prodotti/Index. 
*NOTA* : il modello ProdottoViewModel possiede il `Nome` del fornitore ma non il suo `Id`
chè è richiesto per eseguire la query di `Fornitori/Dettaglio.cshtmlcs`.

*Possibile Patch*: discrinare nell OnGet se Id è null, esegui una query che cerca per nome
e espone i dati dell'oggetto trovato

#### SOLUZIONE:

Link e passaggio della variabile per l'OnGet

```html
<a asp-page="/Fornitori/Dettaglio" asp-route-nomefornitore="@prodotto.FornitoreNome">
    @prodotto.FornitoreNome
</a> 
```

Dettaglio.cs di Fornitori

```cs
public void OnGet(int id = -1, string nomefornitore = null)
    {
        if (id != -1)
        {
            try
            {
                var fornitori = UtilityDB.ExecuteReader($"SELECT Id, Nome, Contatto FROM Fornitori f WHERE f.Id = @id", reader => new Fornitore
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Contatto = reader.GetString(2)
                }, cmd =>
                {
                    cmd.Parameters.AddWithValue("@id", id);
                });
                Fornitore = fornitori.First();
            }
            catch (Exception ex)
            {
                SimpleLogger.Log(ex);
            }
        }
        else if (nomefornitore != null)
        {
            try
            {
                var fornitori = UtilityDB.ExecuteReader($"SELECT Id, Nome, Contatto FROM Fornitori f WHERE f.Nome = @Nome", reader => new Fornitore
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Contatto = reader.GetString(2)
                }, cmd =>
                {
                    cmd.Parameters.AddWithValue("@Nome", nomefornitore);
                });
                Fornitore = fornitori.First();
            }
            catch (Exception ex)
            {
                SimpleLogger.Log(ex);
            }
        }
    }
```

</details>

---

<details>
<summary>📱 Protocolli (teoria)</summary>


# Protocollo
Insieme di regole che gestisce la trasmissione di dati.

## Il più classico è il TCP/IP:

Protocollo di rete che permette la connessione tra due computer che utilizza due protocolli

## TCP 

Transmission Control Protocol: si occupa trasmissione del messaggio

## IP 

Protocollo di rete: identificazione dell'indirizzo del computer tramite schede di rete, normalmente è dinamico

# HTTP (HyperText Transfer Protocol)

Permette di trasmettere documenti html tra un Client e un Server


# HTTPS

HyperText Transfer Protocol Secure.
Ha un layer (strato) aggiuntivo di sicurezza.


# FTP

File Transfer Protocol
Permettono di inviare e riceve file al/dal server.
Protocollo per trasferire i file 

# Client FTP

E' uno spazio remoto che permette di salvare i file in remoto, in modo che sia accessibile sempre da qualsiasi computer. I file vengono immagazzinati come in un computer
è un programma simile ad un browser che vede i file 

# SMTP

Simple mail transfer protocol

Permette di trasmettere mail tra Client e un Server. Il più complesso di tutti perché protegge la perdita di pacchetti di dati.

# SMTPS

Simple mail transfer protocol secure

# POP3

Protocollo per riceve le mail 

# PORTE

#### Porte standard:

Le porte sono in linea di massima maggiormente hardware.

- 3000, 80, 443, 21, 25 ecc...

> Esempi:

PROTOCOLLO|PORTA
-|-
HTTP    |   80
HTTPS   |   443
FTP     |   21
SMTP    |   25
POP3    |   110
SMTPS   |   550
WEBAPP  |   3000

#### EndPoint: 
Indirizzi ai quali posso recuperare delle informazioni (il server mi rende disponibile dei dati)

#### PortForwarding:

Permette l'accesso a servizi di rete da remoto (tunneling tra due computer per permettere l'accesso ai servizi di rete da remoto). Negli anni 90', `Naspter` o `SoulSeek` erano applicazione che, sempre passando attraverso un server, permettevano la comunicazione `Peer to Peer`. 

---

Attraverso terminale 

```bash
ipconfig
```

```
...
Scheda LAN wireless Wi-Fi:

   Suffisso DNS specifico per connessione:
   Indirizzo IPv6 locale rispetto al collegamento . : fe80::2178:1555:8e83:7cdd%9
   Indirizzo IPv4. . . . . . . . . . . . : 192.168.201.16
   Subnet mask . . . . . . . . . . . . . : 255.255.255.0
   Gateway predefinito . . . . . . . . . : 192.168.201.1
```

dove 
```
Indirizzo IPv6 locale rispetto al collegamento . : fe80::2178:1555:8e83:7cdd%9
Indirizzo IPv4. . . . . . . . . . . . : 192.168.201.16
```

---

`Indirizzo IPv6` - identifica la scheda della macchina, creato per sopperire alla mancanza di IP 

`Indirizzo IPv4` - identifica i computer all'interno di una rete locale (generato da DHCP)

#### DHCP 

Dynamic Host Configuration Protocol - Assegna dinamicamente gli indirizzi IP (assegna quelli liberi)

```
Subnet mask . . . . . . . . . . . . . : 255.255.255.0
```
---

`Subnet mask` - serve per ottimizzare l'utilizzo degli indirizzi IP (in caso di )


```
 Gateway predefinito . . . . . . . . . : 192.168.201.1
 ```

 `Gateway predefinito` - Eredita i primi 3 blocchi dell'indirizzo IP.
 Viene ricevuto tramite un servizio `DHCP` Dynamic Host Configuration Protocol

 `DNS` - trasforma/converte un indirizzo "www.abcd.com" ad un indirizzo numerico

 `ISP` - (Internet Server Provider)

`192.168.0.1` o
 `192.168.1.1` indirizzo del router

#### NAT 

Serve per mappare degli indirizzi (Network Address Translation)

---

# Ping 

Serve per testare la comunicazione tra due computer attraverso server.

in questo

```bash
ping 192.168.201.28
```

Risposta

```
Esecuzione di Ping 192.168.201.28 con 32 byte di dati:
Risposta da 192.168.201.28: byte=32 durata=3ms TTL=128
Risposta da 192.168.201.28: byte=32 durata=4ms TTL=128
Risposta da 192.168.201.28: byte=32 durata=3ms TTL=128
Risposta da 192.168.201.28: byte=32 durata=4ms TTL=128       

Statistiche Ping per 192.168.201.28:
    Pacchetti: Trasmessi = 4, Ricevuti = 4,
    Persi = 0 (0% persi),
Tempo approssimativo percorsi andata/ritorno in millisecondi:
    Minimo = 3ms, Massimo =  4ms, Medio =  3ms
```





</details>

---


<details>
<summary>🔨 Utilities (public static class)</summary>

# InputManager.cs

```c#
// classe di gestione degli input per semplificare l'acquisizione e la 
// validazione degli input. Questa classe aiuta a gestire i casi di errore e 
// fornisce metodi per acquisire input di diversi tipi
//* int min = int.MinValue è la costante minima dei valori interi. 
//* int max = int.MaxValue è la costante massima dei valori interi
//* quando chiamiamo il metodo, se inseriamo l'argomento, lo sovrascrive
//* se non lo inseriamo, la variabile avrà il valore dichiarato 
//* nella definizione del metodo
public static class InputManager
{
    public static int LeggiIntero(string messaggio, int min = int.MinValue, int max = int.MaxValue)
    {
        int valore; // per memorizzare intero acquisito
        while (true)
        {
            Console.Write($"{messaggio}"); // messaggio è la variabile di input
            string input = Console.ReadLine(); // acquisisco input come stringa
            // provo a convertire 
            if (int.TryParse(input, out valore) && valore >= min && valore <= max)
            {
                return valore;
                // restituisce ed esce dal ciclo quando trova il valore
            }
            else
            {
                Console.WriteLine($"Inserire un valore intero compreso tra {min} e {max}");
            }
        }
    }
    public static decimal LeggiDecimale(string messaggio, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
    {
        decimal valore;
        while (true)
        {
            Console.Write($"{messaggio}"); // messaggio è la variabile di input
            string input = Console.ReadLine(); // acquisisco input come stringa

            // //! in windows
            // // sostituisco la virgola con il punto
            // if (input.Contains(".")) //(input.Contains(",") && !input.Contains("."))
            // {
            //     input = input.Replace(".", ","); // sostituire la virgola con il punto
            // }


            //! in mac 
            // sostituisco la virgola con il punto
            if (input.Contains(",")) //(input.Contains(",") && !input.Contains("."))
            {
                input = input.Replace(",", "."); // sostituire la virgola con il punto
            }


            // provo a convertire 
            if (decimal.TryParse(input, out valore) && valore >= min && valore <= max)
            {
                return valore;
                // restituisce ed esce dal ciclo quando trova il valore
            }
            else
            {
                Console.WriteLine($"Inserire un valore intero compreso tra {min} e {max}");
            }
        }
    }
    public static string LeggiStringa(string messaggio, bool obbligatorio = true)
    {
        string valore;
        while (true)
        {
            Console.Write($"{messaggio}"); // messaggio è la variabile di input
            string input = Console.ReadLine(); // acquisisco input come stringa
            // provo a convertire 
            if (!string.IsNullOrWhiteSpace(input) || !obbligatorio)
            {
                return input;
            }
            Console.WriteLine($"Errore: il valore non può essere vuoto");
        }
    }
    public static bool LeggiConferma(string messaggio)
    {
        while (true)
        {
            Console.Write($"{messaggio} (S/N): ");
            string input = Console.ReadLine().ToLower();
            if (input == "s" || input == "si")
            {
                return true;
            }
            else if (input == "n" || input == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Inserire un valore valido");
            }
        }
    }
}
```

# ProdottoRepository.cs (blueprint per gestione Json)

```cs
using Newtonsoft.Json;

public class ProdottoRepository
{
    private readonly string dirCatalogo = "data/catalogo"; //

    //metodo per salvare i dati su file 
    public void SalvaProdotti(List<Prodotto> prodotti)
    {

        string nuovoPercorso = ""; // creo una variabile per ospitare il nuovo percorso
        if (!Directory.Exists(dirCatalogo)) // se non esiste la cartella
        {
            Directory.CreateDirectory(dirCatalogo); // creala
        }

        foreach (var prodotto in prodotti) // per ogni prodotto nella lista argomento
        {
            string jsonData = JsonConvert.SerializeObject(prodotto, Formatting.Indented); // serializza il prodotto
            string nomeProdotto = $"{prodotto.Id}.json"; // creo il nome del file 
            nuovoPercorso = Path.Combine(dirCatalogo,nomeProdotto); // creo il percorso
            File.WriteAllText(nuovoPercorso, jsonData); // scrivo il prodotto deserializzato nel percorso
        }
        
        // Console.WriteLine($"Dati salvati nella cartella '/{dirCatalogo}'\n"); // stampo il percorso 
    }

    public List<Prodotto> CaricaProdotti()
    {
        // string nuovoPercorso = Path.Combine(dirCatalogo, prodo)
        if (Directory.Exists(dirCatalogo))
        {
            string[] files = Directory.GetFiles(dirCatalogo);  // carico il contenuto della cartella in una lista di stringhe
            
            if (files.Length > 0) // controllo che ci siano file nella cartella, se ci sono file
            {
                List<Prodotto> catalogoLocale = new List<Prodotto>(); // crea una lista locale
                Prodotto prodottoLocale; // crea un'istanza temporanea del prodotto
                foreach(string file in files) // per ogni file dentro la cartella
                {
                    string readJsonData = File.ReadAllText(file);  // leggi il file
                    prodottoLocale = JsonConvert.DeserializeObject<Prodotto>(readJsonData)!; // deserializzo dentro l'istanza temporanea
                    catalogoLocale.Add(prodottoLocale); // aggiungo l'istanza temporanea alla lista locale
                }
                return catalogoLocale; // restituisco la lista locale
            }
            else
            {
                return new List<Prodotto>(); // se la cartella esiste ma non ci sono file restituisci una lista vuota 
            }
        }
        else // se non esiste la cartella creala e restiuisci una lista vuota
        {
            Directory.CreateDirectory(dirCatalogo); 
            return new List<Prodotto>(); 
        }
    }
}
```

# UtilityDB.cs

```c#
public static class UtilityDB
{
    /// <summary>
    /// Esegue una query che non restituisce dati (INSERT, UPDATE, DELETE).
    /// </summary>
    /// <param name="sql">La query SQL.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Il numero di righe interessate.</returns>
    public static int ExecuteNonQuery(string sql, Action<SqliteCommand> setupParameters = null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        using var command = new SqliteCommand(sql, connection);
        setupParameters?.Invoke(command);

        return command.ExecuteNonQuery();
    }

    /// <summary>
    /// Esegue una query che restituisce un valore scalare.
    /// </summary>
    /// <typeparam name="T">Il tipo del valore atteso.</typeparam>
    /// <param name="sql">La query SQL.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Il valore restituito convertito al tipo T.</returns>
    public static T ExecuteScalar<T>(string sql, Action<SqliteCommand> setupParameters = null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        using var command = new SqliteCommand(sql, connection);
        setupParameters?.Invoke(command);

        var result = command.ExecuteScalar();
        if (result == null || result == DBNull.Value)
            return default(T);

        return (T)Convert.ChangeType(result, typeof(T));
    }

    /// <summary>
    /// Esegue una query che restituisce più righe e le converte in una lista di oggetti di tipo T.
    /// </summary>
    /// <typeparam name="T">Il tipo di oggetto da restituire per ogni riga.</typeparam>
    /// <param name="sql">La query SQL.</param>
    /// <param name="converter">Funzione per convertire una riga (<see cref="SqliteDataReader"/>) in un oggetto di tipo T.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Una lista di oggetti di tipo T.</returns>
    public static List<T> ExecuteReader<T>(string sql, Func<SqliteDataReader, T> converter, Action<SqliteCommand> setupParameters = null)
    {
        var list = new List<T>();
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        
        using var command = new SqliteCommand(sql, connection);
        setupParameters?.Invoke(command);
        
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(converter(reader));
        }
        return list;
    }
}
```

# SimpleLogger.cs

```cs
using System;
using System.IO;

public static class SimpleLogger
{
    // Percorso del file di log (puoi modificare il percorso se necessario)
    private static readonly string logFilePath = "log.txt";

    /// <summary>
    /// Registra un messaggio nel file di log con data e ora.
    /// </summary>
    /// <param name="message">Il messaggio da loggare.</param>
    public static void Log(string message)
    {
        try
        {
            using StreamWriter writer = new StreamWriter(logFilePath, append: true);
            writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }
        catch (Exception)
        {
            // Se il logging fallisce, l'errore viene ignorato.
        }
    }

    /// <summary>
    /// Registra un'eccezione nel file di log.
    /// </summary>
    /// <param name="ex">L'eccezione da loggare.</param>
    public static void Log(Exception ex)
    {
        Log($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");
    }
}
```

# PriceFormatter.cs

```cs
/// <summary>
///  Formatta un valore double come valuta.
/// </summary>
/// <param name="price">Il prezzo da formattare.</param>
/// <returns>Una stringa formattata come valuta.</returns

/*
Windows:
public static class PriceFormatter
{
    public static string Format (double price)
    {
        return price.ToString("C", CultureInfo.CurrentCulture);
    }
}
*/

// Mac:
public static class PriceFormatter
{
    public static string Format(double price)
    {
        var euroCulture = new CultureInfo("it-IT");
        string formattedPrice = price.ToString("N2", euroCulture); // Formatta il numero con 2 decimali
        return "€ " + formattedPrice; // Aggiunge il simbolo dell'euro davanti
    }
}

/*

esempio di utilizzo
<td>@PriceFormatter.Format(prodotto.Prezzo)</td>

*/
```

</details>

---



# Risorse e documentazioni:
* https://getbootstrap.com/
* https://www.w3schools.com/
* https://fonts.google.com/
* https://fontawesome.com/
* https://www.nuget.org/PACKAGES
* https://www.bytehide.com/


