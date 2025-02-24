DIPENDENZE FREQUENTI

```
dotnet add package Newtonsoft.Json
```

# Strutture Di Dati e Metodi

<details>
<Summary> 💬 </Summary>

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
<summary>📝</summary>

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
<summary>📚</summary>

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
<summary>🔢</summary>

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
<summary>📊</summary>

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
<summary>🕒</summary>

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
<summary>🖥️</summary>

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
<summary>📂</summary>

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

# GIT

1. Clone del repository di partenza (partire dalla versione più aggiornata del repository)

2. Lavorare per `File`, non per Task

3. Scegliere la Task.

4. Creare branch e verificare di essere in un branch

5. Committare le modifiche sul proprio branch 
   
   Merge Individuale: 
- dev si sposta sul main 

- digita il merge del branch modificato

- push 
  
   Pull Request 

- Sul proprio branch, dev fa il pull del main (o del branch da incorporare)

- Commit e Push sul proprio branch proprio branch
  
  Merge (fatto dall'HOST)

- Spostarsi sul main

- Pull origin main per aggiornare il main in locale

- Merge del branch 

- git push -u origin main

# TASK: Elimina

che coinvolge USER CONTROLLER, USER VIEW, interazione con la classe Database

ANDREA : USER CONTROLLER

FELIPE: USER VIEW

DIEGO: README.MD

GIORGIO: DATABASE

Git Shash

comando che consente di saklvare temporaneamente le modifiche non commitate nel repository Git senza applicarle diretamente al branch

(salvato in locale)

utile per passare ad un alro branch senza dover committare modifiche

Salvare il lavoro in corso per risolvere un conflitto o aggiornre il branch

mantenere pulito il tuo storico di commit

comandi di base

``````
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

```

git stash show -p stash@{0}
```