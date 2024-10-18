// METODI ARRAY
// Blocco di codice che esegue un azione
// Solitamente restituiscono un valore
// SINTASSI: array.metodo();
/*
    I principali metodi per manipolare gli array sono:
    - Length
    - Copy
    - Clear
    - Reverse
    - Sort
*/

//Array.Metodo();

//esempi


// array.length();      restituisce il numero di elementi di un array
Console.Clear();    
int[] array = {1, 2, 3, 4, 5};
Console.WriteLine(array.Length);

// array.CopyTo(arrayOrigine, [indice di inizio copia]);
int[] arrayBackup = new int[array.Length];
arrayBackup.CopyTo(array, 0);
Console.WriteLine(string.Join(", ", arrayBackup));  
// NOTA: string.Join(", ", arrayBackup ----> funzione che reitera e trasforma in stringhe


// CLEAR "cancella" gli elementi di un array
// SINTASSI:
// Array.Clear(nome_array, [index inizio], [index fine])

//array.Reverse


//array.Sort(nome_array)



//array.IndexOf(array, indice)

// DA COMPLETARE