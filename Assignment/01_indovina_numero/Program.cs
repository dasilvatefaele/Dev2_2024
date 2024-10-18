/******************************************************************************/
//                            INDOVINA NUMERO v1.0
/******************************************************************************/

Console.Clear();
Random random = new Random();
//new è il costruttore della classe Random(); che istanzia un oggetto Random
//random è l'oggetto Random che possiamo utilizzare per generare numeri casuali

int numeroDaIndovinare = random.Next(1,101); // Next è il metodo che genera un numero casuale
//l'intervallo del metodo .Next è semi aperto tra 1 e 101 
//comprende il numero iniziale 1 ma esclude quello finale 101
//dunque l'intervallo è da 1 a 100

//verifico numero - OK
//Console.WriteLine(numeroDaIndovinare);
int numeroTentativi = 10;
Console.Write($"Ho in mente un numero... Indovinalo! Hai {numeroTentativi} tentativi --> ");

while(true){
    int numeroUtente = int.Parse(Console.ReadLine());
//  int numeroUtente = Convert.ToInt32(Console.ReadLine()); conversione alternativa
    if (numeroUtente == numeroDaIndovinare)
    {
        Console.WriteLine($"Hai indovinato! Avevo pensato proprio il {numeroDaIndovinare}");
        break;
    }else{
        numeroTentativi--;
        Console.WriteLine($"Mmm... Sbagliato :( Ora hai {numeroTentativi} tentativi...");
        Console.Write("--> ");
        
        if (numeroTentativi == 0)
        {
            Console.Write($"Mi dispiace... Il numero che avevo pensato era {numeroDaIndovinare}\n\n");
            break;
        }
    }
}




