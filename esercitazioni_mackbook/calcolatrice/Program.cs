/**************************************************************/
//                  CALCOLATRICE SEMPLICE
/**************************************************************/

/*

STAMPA
**************************************************************

    CALCOLA
    Numero: (inserisci)  
    Numero: (inserisci)
    //acquisizione double

    SELEZIONA OPERAZIONE:
    1 - ADDIZIONE
    2 - SOTTRAZIONE
    3 - MOLTIPLICAZIONE
    4 - DIVISIONE
    //controllo selezione, 
    //se la selezione non è tra 1 e 4 
    //chiedi nuovamente fino alla scelta corretta


    //se fattibile esegui calcolo
    RISULTATO = (risultato)
    //altrimenti rimanda errore
    //fine esecuzione

**************************************************************

*/
using System.Collections;

 void StampaMenu(){
    Console.WriteLine("\nSELEZIONA OPERAZIONE");
    Console.WriteLine("1 - ADDIZIONE\n2 - SOTTRAZIONE\n3 - MOLTIPLICAZIONE\n4 - DIVISIONE");
    return;
}

Console.WriteLine("CALCOLA");
Console.Write("Numero: ");
string stringaOperando1 = Console.ReadLine();
Console.Write("Numero: ");
string stringaOperando2 = Console.ReadLine();

//abbiamo stampato e acquisito le due variabili di tipo string
//proseguiamo con la conversione

double numOperando1 = double.Parse(stringaOperando1);
double numOperando2 = double.Parse(stringaOperando2);

//abbiamo due nuove variabili sostitutive
//che possiamo usare aritmicamente
//fine acquisizione

StampaMenu();

bool sceltaValida = false;
double risultatoCalcolo = 0;
// testiamo la selezione finché 

do{
    Console.Write("SELEZIONE: ");
    //stampo menu di scelta

    int sceltaUtente = int.Parse(Console.ReadLine());

    //provo ad acquisire il dato direttamente
    //in variabile int

    // test acquisizione
    // Console.WriteLine($"Hai digitato: {sceltaUtente}");
    // acquisizione riuscita

    switch (sceltaUtente){
        case 1:
            sceltaValida = true;
            risultatoCalcolo = numOperando1 + numOperando2;
        break;
        case 2:
            sceltaValida = true;
            risultatoCalcolo = numOperando1 - numOperando2;
        break;
        case 3:
            sceltaValida = true;
            risultatoCalcolo = numOperando1 * numOperando2;
        break;
        case 4:
            if (numOperando2 == 0){
                Console.Clear();
                Console.WriteLine("\nIMPOSSIBILE DIVIDERE PER 0");
                sceltaValida = false;
                break;
            } else {
                sceltaValida = true;
                risultatoCalcolo = numOperando1 / numOperando2;
            }
        break;
        default:
            sceltaValida = false;
            Console.Clear();
            Console.WriteLine("SELEZIONE NON VALIDA");
            StampaMenu();
        break;
    }

}while(sceltaValida==false && numOperando2 != 0);

//eseguo calcolo e salvo in risultatoCalcolo

if (sceltaValida == true){
    Console.WriteLine($"\nRISULTATO = {risultatoCalcolo:F2}");
}












