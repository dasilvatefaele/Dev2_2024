/**************************************************************/
//                  CALCOLATRICE SEMPLICE v2
/**************************************************************/

/*

OBIETTIVO
**************************************************************

    - Ottimizza il codice in funzioni per prendere
      la funzione main più snella

      void StampaMenu();
      void AcquisizioneNumeri();
      void AcquisizioneRichiesta;


**************************************************************

*/
using System.Collections;
using System.Security.Cryptography.X509Certificates;

void StampaMenu(){
    Console.WriteLine("\nSELEZIONA OPERAZIONE");
    Console.WriteLine("1 - ADDIZIONE\n2 - SOTTRAZIONE\n3 - MOLTIPLICAZIONE\n4 - DIVISIONE");
    return;
}
double AcquisizioneNumeri(){
    Console.Write("Numero: ");
    double n1 = double.Parse(Console.ReadLine());
    return n1;
}


Console.WriteLine("\n\nCALCOLA");
//double[] numArray = new double[10];
double numOperando1 = AcquisizioneNumeri();
double numOperando2 = AcquisizioneNumeri();

StampaMenu();

bool sceltaValida = false;      // la scelta diventa true solo attraverso il giusto switch case
double risultatoCalcolo = 0;    // inizializzo varabile del risultato

/* testiamo la selezione con switchcase fino a selezione corretta 
// rimani nel loop seguendo la condizione del do-while
//          DO(il loop) 
//          WHILE (sceltaValida non valida? Allora DO) */

do{
    Console.Write("SELEZIONE: ");
    int sceltaUtente = int.Parse(Console.ReadLine());
    /* provo ad acquisire il dato direttamente in int usando il metodo int.Parse()
    // CHECK:
    // Console.WriteLine($"Hai digitato: {sceltaUtente}");
    // acquisizione riuscita */

    switch (sceltaUtente){      // IN: int sceltaUtente, bool sceltaValida // OUT: double risultatoColcolo, bool sceltaValida
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
                StampaMenu();
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

}while(sceltaValida==false); // && numOperando2 != 0

if (sceltaValida == true){
    Console.WriteLine($"\nRISULTATO = {risultatoCalcolo:F2}");
}