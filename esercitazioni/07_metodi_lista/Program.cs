// METODI LISTE
/*
    i metodi disponibili per manipolare le liste sono:

    -Count (ok)
    -Add (ok)
    -AddRange
    -Clear (meh)
    -Contains
    -IndexOf
    -Insert
    -Remove
    -RemoveAt
    -Sort
    -ToArray
    -TrimExcess
*/

Console.Clear();

List<int> varLista = new List<int> {10,20,30,40};


// metodo Add
varLista.Add(50);

//metodo count
Console.WriteLine(varLista.Count);
Console.WriteLine(string.Join(", ", varLista));

//metodo AddRange // aggiunge una collezione alla fine di una lista
List<int> varListb = new List<int>{60,70,80,90};
varLista.AddRange(varListb);

Console.WriteLine(string.Join(", ", varLista));

//metodo clear

varLista.Clear(); // cancella elementi di una lista
Console.WriteLine(string.Join(", ", varLista));


//metodo contains // restituisce un bool
List<int> varListc = new List<int>{1,2,3,4,5,6};
Console.WriteLine(varListc.Contains(3));

//metodo indexOf // Restituisce index di un elemento 
// se non c'è un elemento restituisce -1
Console.WriteLine(varListc.IndexOf(3));
Console.WriteLine(varListc.IndexOf(18));

// metodo remove
varListb.Remove(90);  // .remove([Elemento])
Console.WriteLine(string.Join(", ", varListb));

varListb.RemoveAt(2); // .Remove([Indice])

// metodo sort
varLista.Sort(); // ordina la vista

// metodo toArray
int[] array = varListb.ToArray(); // converte una lista in un array

// metodo trimexcess - riduce la capacità di una lista al numero di elementi

varListb.TrimExcess();


// DA COMPLETARE