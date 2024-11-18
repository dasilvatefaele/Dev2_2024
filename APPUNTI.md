# METODI DI STRINGA

`nomevariabile.Length` restituisce la lunghezza

```csharp
string nome2 = "abcd";
int lunghezza = nome2.Length; // lunghezza = 4
```
---
`string.isNullOrWhiteSpace(argomentoStringa)` restituisce booleano se c'è o meno un valore null o uno spazio vuoto

```csharp
string nome3 = "Nome1";
bool check = string.IsNullOrWhiteSpace(nome3); // check = false
```
---
`nomeStringa.ToLower()` restituisce stringa in minuscolo
```csharp
string nome4 = "NOME1";
string minuscolo = nome4.ToLower();   //  minuscolo = "nome1"
```
---
`nomeStringa.ToUpper()` restituisce stringa in maiuscolo
```csharp
string minuscolo = "nome1";
string maiuscolo = minuscolo.ToUpper();     // maiuscolo = "NOME1"
```
---
`nomeStringa.Trim()` rimuove gli spazi bianchi all'inizio e alla fine di una stringa
```csharp
string nome6 = "   Nome1   ";
nome6 = nome6.Trim());        // nome6 = "Nome1"
```
---
`nomeStringa.Split('char')` separa la stringa usando l'argomento come punto di interruzione 
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
`nomeStringa.Replace("A","B")` sostituisce una sottostringa (A) con un altra sotostringa (B)

```csharp
string nome8 = "Nome1";
Console.WriteLine(nome8.Replace("Nome1","Nome2"));
```
---
`nomeStringa.SubString(int indexIniziale, int lunghezzaString)` restituisce una sottostringa (parte dallo 0 e lo fa per 3 caratteri)

```csharp
string nome9="Nome1";
Console.WriteLine(nome9.Substring(0,3)); //output: Nom
```
---



// Contains
// Verifica se una string continuene una sottostringa
string nome10 = "Nome1";
Console.WriteLine(nome9.Contains("Nom")); // output: true

// IndexOf
// restituisce l'indice della prima occorrenza di una sottostringa
// se lo trova restituisce 0
// se non trova la sottostringa restituisce -1
//?  se trova più occorrenze restituisce l'indice della prima occorrenza (per ora prendila per buona)
string nome11 = "Nome1";
Console.WriteLine(nome10.IndexOf("Nome1")); //output: 0

// LastIndexOf
// restituisce l'indice dell'ltima occorrenza di una stringa
// se non trova la sottostringa -1
// parte dalla fine della stringa
string nome12 = "Nome1";
Console.WriteLine(nome12.LastIndexOf("o")); // output 3
// in questo caso la "o" si trova in posizione 3 partendo dalla fine della stringa

// StartWith
string nome13 = "Nome1";
Console.WriteLine(nome13.StartsWith("N")); // output: true

// EndWith
string nome14 = "Nome1";
Console.WriteLine(nome14.EndsWith("1"));

// ToString
// converte un tipo di dato in stringa
// dovrebbe funzionare con int, double, char ecc...
int eta3 = 10;
Console.WriteLine(eta3.ToString());

// Parse
// converte una stringa in un tipo di dato
//! se la convertsione non va a buon fine termina il programma con un errore
string eta4 = "10";
Console.WriteLine(int.Parse(eta4));

// tryparse
// converte una stringa in un tipo di dato e restituisce un valore booleano che indica la conversione riuscita
// se la conversione è riuscita il valore viene salvata nella variabile di riferimento
// se la conversione non è riuscita il valore convertito è 0

string eta5 = "10";
int eta6;
if (int.TryParse(eta5, out eta6))
{
    Console.WriteLine(eta6);
}
else
{
    Console.WriteLine("Conversione non riuscita");
}

// Convert
// converte un tipo di dato in un altro tipo di dato
// se la conversione non è riuscita viene generata un'ecezzione di tipo InvalidCastException ed il programma si blocca
string eta7 = "10";
Console.Write(Convert.ToInt32(eta7));

// concatenazione con string.format
string nome15 = "Nome1";
string cognome1 = "Rossi";
Console.WriteLine(string.Format ("{0} {1}", nome15, cognome1));

// conversione implicita
// possibile da int a double, non da double a int
int eta8 = 10;
double altezza3 = eta8;

// conversione esplicita (cast)
double altezza4 = 1.70;
int eta9 = (int)altezza4;

// posso stampare il tipo della variabile con GetType()
Console.WriteLine($"tipo della var è: {eta8.GetType()}");
Console.WriteLine($"tipo della var è: {altezza.GetType()}");
