/***********************************/
//            CONDIZIONI
/***********************************/
    /*
    le principali istruzioni di controllo sono:

    - if
    - else
    - else if
    - switch

    */

// ESEMPIO DI IF 
// se una condizione viene soddisfatta esegue un blocco di codice 
// una parte di codice scritta tra le {}

//Clean console
Console.Clear();

int v = 10;
int w = 4;
int x = 5;

/************************************************/
if (v > 5){
    Console.WriteLine("v è maggiore di 5");
}

/************************************************/
if (w > 5){
    Console.WriteLine("w è maggiore di 5");
} else {
    Console.WriteLine("w è minore di 5");
}

/************************************************/
if (x > 5){
    Console.WriteLine("x è maggiore di 5");
} else if ( x == 5 ){
    Console.WriteLine("x è uguale di 5");
} else {
    Console.WriteLine("x è minore di 5");
}



/*

IF condizione
    fai questo;

***************************

IF condizione
    fai questo;
ELSE
    fai quest'altro;

****************************

IF condizione
    fai questo;
ELSE IF condizione
    fai questo;
ELSE
    fai questo; 

*/

// modifica arbitraria

/***********************************/
//           SWITCH CASE
/***********************************/

int y = 10;

switch (v){
    case 5:
        Console.WriteLine("La variabile è 5");
        break;
    case 10:
        Console.WriteLine("La variabile è 10");
        break;
    case 15:
        Console.WriteLine("La variabile è 15");
        break;
    default: // quando nessuna delle condizioni è soddisfatta esegue default
        Console.WriteLine("La variabile è non è presente nel menù");
        break;
}

// il switch case è utilizzabile con ogni tipo di variabile, (int, bool, string, char)







