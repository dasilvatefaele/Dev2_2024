#### LeetCode Problems

# Group Anagrams:
`Medium`

Given an array of strings strs, group all anagrams together 
into sublists. You may return the output in any order.

An anagram is a string that contains the exact same characters 
as another string, but the order of the characters can be different.

> Example:
```
Input: strs = ["act","pots","tops","cat","stop","hat"]
Output: [["hat"],["act", "cat"],["stop", "pots", "tops"]]
```

> Soluzione:
```csharp
string[] strs = ["pots","tops","cat","stop","hat","act"];
var res = new Dictionary<string,List<string>>(); 

foreach(string word in strs) 
{
    int[] count = new int[26]; 

    foreach(char c in word) 
    {
        count[c-'a']++; 
    } 
    
    string key = string.Join(",",count);

    if (!res.ContainsKey(key))              
    {
        res[key] = new List<string>();    
    }

    res[key].Add(word); 
}

var risultato = res.Values.ToList<List<string>>();

Console.WriteLine(); 
foreach (var lista in risultato) 
{
    foreach (var elemento in lista) 
    {
        Console.WriteLine(elemento); 
    }
    Console.WriteLine(); 
}

//! "risultato" è l'output richiesto 
```

> Analisi Soluzione:
```csharp
string[] strs = ["pots","tops","cat","stop","hat","act"];


var res = new Dictionary<string,List<string>>(); 
// Creo un dizionario in cui ad ogni chiave univoca
// di tipo string, associo una lista di stringhe.


foreach(string word in strs) // per ogni parola nell'array di stringhe
{

    int[] count = new int[26]; // creo un contatore di lettere (26 lettere dell'alfabeto)

    foreach(char c in word) // per ogni carattere nella parola
    {
        count[c-'a']++; 
        // sommo +1 ad ogni posizione. in C# ogni carattere ha un valore numerico (a = 97)
        // dunque per non uscire dall'array dovrò sottrarre 'a'
        // per rimanere tra 0 e 25
    } //> alla fine di ogni parola esce

    
    string key = string.Join(",",count);
    // creo una variabile stringa contenente la chiave della parola
    // la chiave è una mappa numerica. le parole anagrammi dell'altra
    // avranno la stessa chiave numerica


    if (!res.ContainsKey(key))              // se il dizionario non contiene la chiave...
    {
        res[key] = new List<string>();      // allora crea una lista che ha come chiave la mappa
    }

    res[key].Add(word); 
    // se già esiste, aggiungi la parola alla lista corrispondente a quella chiave
    //! Queste operazioni verranno eseguite per ogni parola 

}

var risultato = res.Values.ToList<List<string>>();
// creo una variabile var che diventerà dello stesso TIPO
// di ciò a cui la assegno, in questo caso converto
// i valorid del dizionario in una lista di liste di stringhe

Console.WriteLine(); // vai a capo
foreach (var lista in risultato) // per ogni lista della lista
{
    foreach (var elemento in lista) // per ogni elemento della lista
    {
        Console.WriteLine(elemento); // stampa l'elemento
    }
    Console.WriteLine(); // vai a capo
}

//! "risultato" è l'output richiesto 
```