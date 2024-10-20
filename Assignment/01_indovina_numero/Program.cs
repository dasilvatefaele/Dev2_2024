/******************************************************************************/
//                            INDOVINA NUMERO v1.1
/******************************************************************************/
// v1.1 : pulizia codice, console più pulita, formattazione più omogenea
// v1.2 : possibilità di scegliere Facile (1-20), Medio (1-50), Difficile (1-100)
// v1.3 : dopo 5 tentativi sbagliati propone 3 indizi (maggiore o minore, pari o dispari)

Console.Clear();
Random random = new Random();
/*
//new è il costruttore della classe Random(); che istanzia un oggetto Random
//random è l'oggetto Random che possiamo utilizzare per generare numeri casuali
*/
int numeroDaIndovinare = random.Next(1,101); 
/*
// Next è il metodo che genera un numero casuale
//l'intervallo del metodo .Next è semi aperto tra 1 e 101 
//comprende il numero iniziale 1 ma esclude quello finale 101
//dunque l'intervallo è da 1 a 100

//verifico numero - OK
//Console.WriteLine(numeroDaIndovinare);
*/
int numeroTentativi = 10;
Console.Write($"Ho in mente un numero... Indovinalo! Hai {numeroTentativi} tentativi\n--> ");

while(true){
    int numeroUtente = int.Parse(Console.ReadLine());
//  int numeroUtente = Convert.ToInt32(Console.ReadLine()); conversione alternativa
    if (numeroUtente == numeroDaIndovinare){
        Console.WriteLine($"Hai indovinato! Avevo pensato proprio il {numeroDaIndovinare}");
        break;
    } else {    // <----- più probabilmente esegue da qui
        Console.Clear(); 
        numeroTentativi--;
        Console.WriteLine($"Mmm... Sbagliato :( Ora hai {numeroTentativi} tentativi...");
        Console.Write("--> ");

        if (numeroTentativi == 0){
            Console.Clear();
            Console.Write($"Mi dispiace... Il numero che avevo pensato era {numeroDaIndovinare}\n\n");
            break;
        }
    }
}




