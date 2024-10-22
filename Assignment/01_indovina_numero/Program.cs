/******************************************************************************/
//                            INDOVINA NUMERO v1.4c
/******************************************************************************/

using System.Security.Principal;

Console.Clear();
Random random = new Random();
 
 // Dichiarazione e inizializzazione
 int numeroDaIndovinare = 0; 
 bool sceltaValida = false;
 double intervallo = 0;
 int sceltaModalita = 0;
List<int> numeriTentati = new List<int>();

// Stampa e acquisisce Modalità di gioco
do{
    Console.WriteLine("Modalità di gioco:\n1 - Facile\n2 - Medio\n3 - Difficile");
    Console.Write("===>");

    do{
        try{
            sceltaModalita = int.Parse(Console.ReadLine());
            sceltaValida = true;
        }
        catch (System.FormatException){
            Console.WriteLine("Serve inserire un valore valido :( riprova...");
            Console.Write("===>");
            sceltaValida = false;
        }
    }while(sceltaValida==false);

    switch (sceltaModalita){
        case 1:
            sceltaValida = true;
            numeroDaIndovinare = random.Next(1,21); 
            intervallo = 19; // da 1 a 20
            Console.Clear();
            Console.WriteLine("Modalità: Facile (penso a un numero tra 1 e 20)");
        break;
        case 2:
            sceltaValida = true;
            numeroDaIndovinare = random.Next(1,51); 
            intervallo = 49; // da 1 a 50
            Console.Clear();
            Console.WriteLine("Modalità: Medio (penso a un numero tra 1 e 50)");
        break;
        case 3:
            sceltaValida = true;
            numeroDaIndovinare = random.Next(1,101); 
            intervallo = 99; // da 1 a 100
            Console.Clear();
            Console.WriteLine("Modalità: Difficile (penso a un numero tra 1 e 100)");
        break;  
        default:
            sceltaValida = false;
            Console.Clear();
            Console.WriteLine("Questa modalità non esiste ancora :) Scegli una delle opzioni disponibili!\n");
        break;
    }
} while (sceltaValida == false);

//Stampa istruzioni di gioco
Console.WriteLine("Istruzioni di gioco: Hai 10 tentativi per indovinare un numero che ho pensato... Cominciamo!\n");
Console.WriteLine("Premere un tasto per iniziare...");
Console.ReadKey();

// Dichiarazione e inizializzazione tentativi
int numeroTentativi = 10;
int numeroUtente = 0;

//Inizio sessione di gioco
Console.Clear();
Console.Write($"Ho in mente un numero... Indovinalo! Hai {numeroTentativi} tentativi\n--> ");

while(true){
     //numeroUtente = int.Parse(Console.ReadLine()); // Acquisizione 


    do{
        try{
            numeroUtente = int.Parse(Console.ReadLine());
            sceltaValida = true;
        }
        catch (System.FormatException){
            Console.WriteLine("Serve inserire un valore valido :( riprova...");
            Console.Write("===>");
            sceltaValida = false;
        }
    }while(sceltaValida==false);


    // confronto numeri
    if (numeroUtente == numeroDaIndovinare){ // "Hai indovinato!" - Fine sessione con vittoria
        Console.WriteLine($"\nHai indovinato! Avevo pensato proprio al {numeroDaIndovinare}\n");
        break;
    } else {    // <----- "Sbagliato :(" - La sessione di gioco si svolge qui 
        
        

        numeroTentativi--; // Decremento tentativi

        Console.Clear(); 
        Console.WriteLine($"Mmm... Sbagliato :( Ora hai {numeroTentativi} tentativi...");

        numeriTentati.Add(numeroUtente);
        Console.Write("I tuoi numeri (");
        Console.Write(string.Join(", ", numeriTentati));
        int diffNumero = Math.Abs(numeroDaIndovinare - numeroUtente);
        Console.Write(")\n");

        if (diffNumero > intervallo / 2){ // differenza > 50% dell'intervallo (molto distanti)
            Console.WriteLine("Indizio: Oceano!");
        } else if (diffNumero < intervallo / 2 && diffNumero > intervallo / 4 ){ // differenza tra 50%  e 25% dell'intervallo (distanti)
            Console.WriteLine("Indizio: Acqua!"); 
        } else if (diffNumero < intervallo / 4){ // differenza < 25% intervallo (vicini)
            Console.WriteLine("Indizio: Fuoco!");
        }else if (diffNumero < intervallo / 10){ // differenza < 10% intervallo (molto vicini)
            Console.WriteLine("Indizio: Fuochissimo!");
        }
        
        if (numeroTentativi == 5) { // Indizio dopo 5 tentativi
            if (numeroDaIndovinare % 2 == 0) {{Console.WriteLine("Indizio: il numero che ho pensato è pari... :)");}}
            else {Console.WriteLine("Indizio: il numero che ho pensato è dispari... :)");}
        }

        if (numeroTentativi < 5 && numeroTentativi > 0){ // Indizio al tentativo 4, 3, 2, 1
            if (numeroUtente > numeroDaIndovinare) {Console.WriteLine("Indizio: il numero che ho pensato è più basso... :)");}
            if (numeroUtente < numeroDaIndovinare) {Console.WriteLine("Indizio: il numero che ho pensato è più alto... :)");}
        }
        
        // Fine sessione di gioco con sconfitta
        if (numeroTentativi == 0){  
            Console.Clear();
            Console.Write($"Mi dispiace... Il numero che avevo pensato era {numeroDaIndovinare}\n\n");
            break;
        }

        Console.Write("===> ");
    }
}




