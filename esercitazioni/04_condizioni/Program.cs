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