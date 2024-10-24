/******************************************************************************/
//                            INDOVINA NUMERO v1.7
/******************************************************************************/

using System.Security.Principal;

Console.Clear();
Random random = new Random();

// Dichiarazione e inizializzazione
int numeroDaIndovinare = 0;
bool sceltaValida = false;
double intervallo = 0;
int sceltaModalita = 0;
int punteggioGiocatore = 0;
int punteggioTemp = 0;
int nRound = 0;
bool fineRound = false;
string risposta = "";
List<int> numeriTentati = new List<int>();


do{ // Gioca

    Console.Clear();

    Console.WriteLine("****************************************");
    Console.WriteLine("             INDOVINA NUMERO!");
    Console.Write("\n****************************************");

    Console.ReadKey();
    Console.Clear();

// Gestione Modalità
    do
    {
        // Stampa Modalità di gioco
        Console.WriteLine("Modalità di gioco:\n1 - Facile\n2 - Medio\n3 - Difficile");
        Console.Write("===>");

        // Acquisizione Modalità di gioco e controllo validità inserimento
        /*
        do
        {
            try
            {
                sceltaModalita = int.Parse(Console.ReadLine());
                sceltaValida = true;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Serve inserire un valore valido :( riprova...");
                Console.Write("===>");
                sceltaValida = false;
            }
        } while (sceltaValida == false);
        */
        do{
            bool successo = int.TryParse(Console.ReadLine(), out sceltaModalita);
            if(successo == true){
                sceltaValida = true;
            }
            else{
                Console.WriteLine("Serve inserire un valore valido :( riprova...");
                    Console.Write("===>");
                    sceltaValida = false;
            }
        }while(sceltaValida==false);

        // Stampo e imposto la modalità (Facile, Medio, Difficile)
        switch (sceltaModalita)
        {
            case 1:
                sceltaValida = true;
                Console.Clear();
                Console.WriteLine("Modalità: Facile (penso a un numero tra 1 e 20)");
                break;
            case 2:
                sceltaValida = true;
                Console.Clear();
                Console.WriteLine("Modalità: Medio (penso a un numero tra 1 e 50)");
                break;
            case 3:
                sceltaValida = true;
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

// Sessione di Gioco (3 Round)
    do
    {
        switch (sceltaModalita)
        {
            case 1:
                numeroDaIndovinare = random.Next(1, 21);
                intervallo = 19;
                break;
            case 2:
                
                numeroDaIndovinare = random.Next(1, 51);
                intervallo = 49;
                break;
            case 3: 
                numeroDaIndovinare = random.Next(1, 101);
                intervallo = 99;
                break;
            default:
                break;
        }

        // Console.WriteLine(numeroDaIndovinare); // Esponi numero da indovinare per Debug
        Console.WriteLine($"*** Round {nRound+1} ***");
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
        Console.Clear();


        //Stampa istruzioni di gioco
        Console.WriteLine("Istruzioni di gioco: Hai 10 tentativi per indovinare un numero che ho pensato... Cominciamo!\n");
        Console.WriteLine("Premere un tasto per iniziare...");
        Console.ReadKey();

        //Inizio sessione di gioco   <==========================

        // Dichiarazione e inizializzazione tentativi
        int numeroTentativi = 10;
        int numeroUtente = 0;

        Console.Clear();
        Console.Write($"Ho in mente un numero... Indovinalo! Hai {numeroTentativi} tentativi\n--> ");

        // Ciclo sessioni di gioco
        while (true)
        {

            // Acquisizione numeroUtente e controllo validità
            do
            {
                /*
                try
                {
                    numeroUtente = int.Parse(Console.ReadLine());
                    sceltaValida = true;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Serve inserire un valore valido :( riprova...");
                    Console.Write("===>");
                    sceltaValida = false;
                }
                */
                bool successoNumeroUtente = int.TryParse(Console.ReadLine(),out numeroUtente);
                if (successoNumeroUtente == true && numeroUtente >= 1 && numeroUtente <= intervallo+1){
                    sceltaValida = true;
                }else{
                    Console.WriteLine("Serve inserire un valore valido :( riprova...");
                    Console.Write("===>");
                    sceltaValida = false;
                }

            } while (sceltaValida == false);
            // FINE Acquisizione numeroUtente e controllo validità

            // Confronto numeri ---> UGUALE
            if (numeroUtente == numeroDaIndovinare)
            {
                // Stampa messaggio - "Hai indovinato!" - Fine sessione con vittoria
                Console.WriteLine($"\nHai indovinato! Avevo pensato proprio al {numeroDaIndovinare}\n");
                punteggioTemp += numeroTentativi * 10;
                break;

                // Confronto numero ---> DIVERSO 
                // La sessione di gioco si svolge qui <==========================
            }
            else
            {

                // Decremento tentativi
                numeroTentativi--;

                // Decremento punteggio
                //punteggioGiocatore--;

                // Stampa messaggio  "Sbagliato :(" 
                Console.Clear();
                //Console.WriteLine($"Punteggio: {punteggioGiocatore}\n");
                Console.WriteLine($"Mmm... Sbagliato :( Ora hai {numeroTentativi} tentativi...");

                // Aggiungi numero alla lista dei numeri tentati e stampa 
                numeriTentati.Add(numeroUtente);
                Console.Write("I tuoi numeri (");
                Console.Write(string.Join(", ", numeriTentati));
                Console.Write(")\n");

                // Calcolo Differenza 
                int diffNumero = Math.Abs(numeroDaIndovinare - numeroUtente);

                if (diffNumero > intervallo / 2)
                {                                           // differenza > 50% dell'intervallo (molto distanti)
                    Console.WriteLine("Indizio: Oceano!");
                }
                else if (diffNumero < intervallo / 2 && diffNumero > intervallo / 4)
                {    // differenza tra 50%  e 25% dell'intervallo (distanti)
                    Console.WriteLine("Indizio: Acqua!");
                }
                else if (diffNumero < intervallo / 4 && diffNumero > intervallo / 10)
                {                                    // differenza < 25% intervallo (vicini)
                    Console.WriteLine("Indizio: Fuoco!");
                }
                else if (diffNumero < intervallo / 10)
                {                                    // differenza < 10% intervallo (molto vicini)
                    Console.WriteLine("Indizio: Fuochissimo!");
                }

                // Indizio dopo 5 tentativi
                if (numeroTentativi == 5)
                {
                    if (numeroDaIndovinare % 2 == 0) { { Console.WriteLine("Indizio: il numero che ho pensato è pari... :)"); } }
                    else { Console.WriteLine("Indizio: il numero che ho pensato è dispari... :)"); }
                }

                // Indizio al tentativo 4, 3, 2, 1
                if (numeroTentativi < 5 && numeroTentativi > 0)
                {
                    if (numeroUtente > numeroDaIndovinare) { Console.WriteLine("Indizio: il numero che ho pensato è più basso... :)"); }
                    if (numeroUtente < numeroDaIndovinare) { Console.WriteLine("Indizio: il numero che ho pensato è più alto... :)"); }
                }

                // Solo quando finiscono i tentativi: Sconfitta
                if (numeroTentativi == 0)
                {
                    Console.Clear();
                    Console.Write($"Mi dispiace... Il numero che avevo pensato era {numeroDaIndovinare}\n\n");
                    break;
                }

                // Stampa indicatore inserimento
                Console.Write("===> ");
            }
        }

        Console.WriteLine($"Hai totalizzato {punteggioTemp} punti nel {nRound+1}^ round");
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
        Console.Clear();
        punteggioGiocatore += punteggioTemp;
        punteggioTemp = 0;
        numeriTentati.Clear();

        nRound++;
        if (nRound == 3)
        {
            fineRound = true;
        }

    } while (fineRound == false);

// Fine dei Round
    Console.WriteLine($"Fine del gioco! Hai totalizzato {punteggioGiocatore} punti");
    Console.WriteLine("Vuoi giocare di nuovo? s/n");
    
    risposta = Console.ReadLine();

    while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
    {
        Console.Clear();
        Console.WriteLine("Risposta non valida :(");
        Console.WriteLine("Vuoi giocare di nuovo? s/n");
        risposta = Console.ReadLine();
    }

    risposta = risposta.ToUpper();
    nRound = 0;
    fineRound = false;
    numeriTentati.Clear();
    punteggioGiocatore = 0;
    punteggioTemp = 0;
    
} while (risposta == "S");
Console.Clear();
Console.WriteLine("Grazie per aver giocato!");
Console.ReadKey();