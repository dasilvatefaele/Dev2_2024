//  METODI DIZIONARIO
/*
I metodi dispoibili per manipolare i dizionari sono:
- Add
- Clear
- ContainsKey
- ContainsValue
- Remove
- TryGetValue
*/

//NOTA: \t -nella stringa fa tabulazione

using System.Runtime.CompilerServices;

Console.Clear();
Console.WriteLine("Vedi Add");
//Metodo .Add
// aggiunge un elemento a un dizionario 
Dictionary<string,int> dizionario1 = new Dictionary<string,int>{
{"uno",1},
{"due",2},
{"tre",3}
};

dizionario1.Add("quattro", 4);

foreach (var coppia in dizionario1){
    Console.WriteLine($"{coppia.Key}: {coppia.Value}");
}

Console.WriteLine("Vedi Remove");
Console.ReadKey();
//Metodo .Remove
// aggiunge un elemento a un dizionario 

dizionario1.Remove("due");

foreach (var coppia in dizionario1){
    Console.WriteLine($"{coppia.Key}: {coppia.Value}");
}

Console.WriteLine("Vedi ContainsKey");
Console.ReadKey();
//Metodo .ContainsKey

Console.WriteLine(dizionario1.ContainsKey("uno"));
Console.WriteLine(dizionario1.ContainsKey("due"));

//Metodo .ContainsValue
Console.WriteLine("Vedi ContainsValue");
Console.ReadKey();

Console.WriteLine(dizionario1.ContainsValue(1));
Console.WriteLine(dizionario1.ContainsValue(2));

//Metodo .TryGetValue
Console.WriteLine("Vedi TryGetValue");
Console.ReadKey();

int valore;

if(dizionario1.TryGetValue("tre", out valore)){
    Console.WriteLine(valore);
} else{
    Console.WriteLine("Chiave non trovata.");
}

//Metodo .Clear
Console.WriteLine("Vedi Clear");
Console.ReadKey();

dizionario1.Clear();

foreach (var coppia in dizionario1){
    Console.WriteLine($"{coppia.Key}: {coppia.Value}");
}

//Dizionario con 1 Key e 2 Value

Dictionary<string, List<int>> dizionario2 = new Dictionary<string, List<int>>(){

    {"uno", new List<int> {1,2,3}},
    {"due", new List<int> {4,5,6}},
    {"tre", new List<int> {7,8,9}},
};

foreach (var coppia in dizionario2){
    Console.WriteLine($"{string.Join(", ", coppia.Key)}\t{coppia.Value}");
}

