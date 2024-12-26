using System.Runtime.Serialization.Formatters;


void Separatore(){
// stampa separatore ---------
for (int i = 0; i < 10; i++){
    Console.Write("*");
}    
Console.Write("\n");
return;
// stampa separatore ---------
}

/****************************************/
//                CICLI
/****************************************/

/*

- for 
- while
- do while
- foreach

*/

//  Pulizia Console


Console.Clear();

/****************************************/
//                FOR
Separatore();
/****************************************/

for (int i = 0; i < 10; i++){     // inizializzazione ; condizione ; incremento
    Console.WriteLine($"{i}");
}

// stampa separatore ---------
for (int i = 0; i < 10; i++){
    Console.Write("*");
}    
Console.Write("\n");
// stampa separatore ---------


//oppure 
for (int i = 1; i <= 10; i++){     // inizializzazione ; condizione ; incremento
    Console.WriteLine($"{i}");
}

/****************************************/
//                WHILE
Separatore();
/****************************************/

int j = 0;
while(j<=10){
    Console.WriteLine(j);
    j++;
}

//oppure

while(true){
    Console.WriteLine("Inserisci un numero");
    string s = Console.ReadLine();
    if (s == "exit"){
        break; //esci dal ciclo
    }
}

/****************************************/
//                DO-WHILE
Separatore();
/****************************************/

int numero = 10;
do{ //esegue almeno una volta
    Console.WriteLine(numero);
    numero--;
}while (numero > 0); // finché la condizione é true

/****************************************/
//                FOREACH
Separatore();
/****************************************/

//esegue un blocco di codice per ogni elemento di una collezione
//come un array o una lista

string[] nomi = {"mario","luigi","principessa"};
foreach(string nome in nomi){
    Console.WriteLine(nome);
}