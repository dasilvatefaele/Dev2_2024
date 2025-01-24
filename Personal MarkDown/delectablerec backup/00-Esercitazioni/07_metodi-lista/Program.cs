// METODI LISTA
/*
i metodi disponibili per manipolare le liste sono:
- Count
- Add
- AddRange
- Clear
- Contains
- IndexOf
- Remove
- RemoveAt
- Sort
- ToArray
- TrimExcess
*/

Console.Clear();

// ESEMPIO DI METODO COUNT
// restituisce il numero di elementi di una lista
List<int> lista1 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
Console.WriteLine(lista1.Count); // stampa il numero di elementi di lista1

// ESEMPIO DI METODO ADD
// aggiunge un elemento alla fine di una lista
List<int> lista2 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
lista2.Add(6); // aggiunge 6 alla fine di lista2
Console.WriteLine(string.Join(", ", lista2)); // stampa lista2

// ESEMPIO DI METODO ADDRANGE
// aggiunge una collezione alla fine di una lista
List<int> lista3 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
List<int> lista4 = new List<int> { 6, 7, 8, 9, 10 }; // dichiara e inizializza una lista di interi
lista3.AddRange(lista4); // aggiunge lista4 alla fine di lista3

// ESEMPIO DI METODO CLEAR
// cancella gli elementi di una lista
List<int> lista5 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
lista5.Clear(); // cancella gli elementi di lista5
Console.WriteLine(string.Join(", ", lista5)); // stampa lista5

// ESEMPIO DI METODO CONTAINS
// restituisce true se una lista contiene un elemento
List<int> lista6 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
Console.WriteLine(lista6.Contains(3)); // stampa true se lista6 contiene 3

// ESEMPIO DI METODO INDEXOF
// restituisce l'indice di un elemento di una lista
List<int> lista7 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
Console.WriteLine(lista7.IndexOf(3)); // stampa l'indice di 3 in lista7 (2) se non c'e restituisce -1

// ESEMPIO DI METODO REMOVE
// cancella la prima occorrenza di un elemento di una lista
List<int> lista8 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
lista8.Remove(3); // cancella la prima occorrenza di 3 in lista8
Console.WriteLine(string.Join(", ", lista8)); // stampa lista8

// ESEMPIO DI METODO REMOVEAT
// cancella un elemento di una lista in base all'indice
List<int> lista9 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
lista9.RemoveAt(2); // cancella l'elemento in posizione 2 di lista9
Console.WriteLine(string.Join(", ", lista9)); // stampa lista9

// ESEMPIO DI METODO SORT
// ordina gli elementi di una lista
List<int> lista10 = new List<int> { 5, 3, 1, 4, 2 }; // dichiara e inizializza una lista di interi
lista10.Sort(); // ordina gli elementi di lista10
Console.WriteLine(string.Join(", ", lista10)); // stampa lista10

// ESEMPIO DI METODO TOARRAY
// restituisce un array a partire da una lista
List<int> lista11 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
int[] array = lista11.ToArray(); // converte lista11 in un array
Console.WriteLine(string.Join(", ", array)); // stampa array

// ESEMPIO DI METODO TRIMEXCESS
// riduce la capacita di una lista al numero di elementi presenti
List<int> lista12 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
lista12.TrimExcess(); // riduce la capacita di lista12 al numero di elementi presenti
Console.WriteLine(lista12.Capacity); // stampa la capacita di lista12