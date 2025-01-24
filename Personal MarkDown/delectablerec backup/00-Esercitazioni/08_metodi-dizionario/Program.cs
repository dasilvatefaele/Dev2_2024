// METODI DIZIONARIO
/*
i metodi disponibili per manipolare i dizionari sono:
- Add
- Clear
- ContainsKey
- ContainsValue
- Remove
- TryGetValue
*/

Console.Clear();

// ESEMPIO DI METODO ADD
// aggiunge un elemento a un dizionario

// dichiara e inizializza un dizionario di stringhe e interi
Dictionary<string, int> dizionario1 = new Dictionary<string, int>
{
     { "uno", 1 },
     { "due", 2 },
     { "tre", 3 }
};

dizionario1.Add("quatt", 4); // aggiunge "quattro" con valore 4 a dizionario1

// ESEMPIO DI METODO REMOVE
// rimuove un elemento da un dizionario

// rimuove l'elemento con chiave "due" da dizionario1
dizionario1.Remove("due");

// ESEMPIO DI METODO CONTAINSKEY
// restituisce true se un dizionario contiene una chiave

// restituisce true se dizionario1 contiene la chiave "uno"
Console.WriteLine(dizionario1.ContainsKey("due"));

// ESEMPIO DI METODO CONTAINSVALUE
// restituisce true se un dizionario contiene un valore

// restituisce true se dizionario1 contiene il valore 3
Console.WriteLine(dizionario1.ContainsValue(2));

// ESEMPIO DI METODO CLEAR
// cancella gli elementi di un dizionario

// cancella gli elementi di dizionario1
dizionario1.Clear();

// stampo il dizionario aggiornato
foreach (var coppia in dizionario1)
{
    Console.WriteLine($"{coppia.Key}\t{coppia.Value}");
}

// ESEMPIO DI DIZIONARIO CON UNA COPPIA CON UNA CHIAVE E DUE VALORI

// dichiara e inizializza un dizionario di stringhe e liste di interi
Dictionary<string, List<int>> dizionario2 = new Dictionary<string, List<int>>
{
    { "uno", new List<int> { 1, 2, 3 } },
    { "due", new List<int> { 4, 5, 6 } },
    { "tre", new List<int> { 7, 8, 9 } }
};

// aggiunge 10 alla lista di valori associata alla chiave "uno"
dizionario2["uno"].Add(10);

// stampo il dizionario aggiornato
foreach (var coppia in dizionario2)
{
    Console.WriteLine($"{coppia.Key}\t{string.Join(", ", coppia.Value)}");
}

// ESEMPIO DI DIZIONARIO CON UNA COPPIA CON PIU CHIAVI ASSOCIATE AD UN VALORE

// dichiara e inizializza un dizionario di liste di stringhe e interi
Dictionary<List<string>, int> dizionario3 = new Dictionary<List<string>, int>
{
    { new List<string> { "uno", "due", "tre" }, 1 },
    { new List<string> { "quattro", "cinque", "sei" }, 2 },
    { new List<string> { "sette", "otto", "nove" }, 3 }
};

// stampo il dizionario
foreach (var coppia in dizionario3)
{
    Console.WriteLine($"{string.Join(", ", coppia.Key)}\t{coppia.Value}");
}

// posso stampare una chiave specifica ad esempio la seconda chiave della prima coppia
Console.WriteLine(dizionario3.Keys.ElementAt(0)[1]);

// ESEMPIO DI METODO TRYGETVALUE
// cerca un elemento in un dizionario e restituisce il valore associato

// dichiara e inizializza un dizionario di stringhe e interi
Dictionary<string, int> dizionario4 = new Dictionary<string, int>
{
    { "uno", 1 },
    { "due", 2 },
    { "tre", 3 }
};

int valore;
// cerca l'elemento con chiave "due" in dizionario4 e restituisce il valore associato
if (dizionario4.TryGetValue("due", out valore))
{
    Console.WriteLine(valore);
}
else
{
    Console.WriteLine("Chiave non trovata.");
}