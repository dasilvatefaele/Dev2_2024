Console.Clear();

int[] array3 = { 1, 2, 3, 4, 5 }; // dichiara e inizializza un array di interi
Array.Clear(array3, 0, 5); // cancella gli elementi di array3 da 0 a array3.Length
Console.WriteLine($"Lunghezza Array {array3.Length}"); // 5

// lunghezza array = 5, ma gli indici sono 0, 1, 2, 3, 4 
// quindi Array.Clear(array3, 0, array3.Length);   gli argomenti sono ([nome_array],[index di inizio],[???QUANTO CANCELLARE])

Console.WriteLine(string.Join(", ", array3));


// LISTA - ESEMPIO DI METODO TRIMEXCESS
// riduce la capacita di una lista al numero di elementi presenti
List<int> lista12 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi

Console.WriteLine(lista12.Capacity); // stampa la capacita di lista12

// La capacità non è una caratteristica degli ARRAY dato che la lunghezza della lista è variabile?
// La lista ha 5 elementi ma capacità 8 [???]


lista12.TrimExcess(); // riduce la capacita di lista12 al numero di elementi presenti
Console.WriteLine(lista12.Capacity); // stampa la capacita di lista12