// Pulizia Console
Console.Clear();


// Dichiarazione
int numUser;
int randomPC;
int contatoreRound = 5;
int Utente = 1;
int Avversario = 0;
int[] allPunteggio = new int[2];
int dialogoRound = 1;
bool convertito = false;
string sceltaMenu = "";
string manoUser = "";
string manoPC = "";
Random random = new Random();


// Dialogo iniziale
Console.WriteLine("*** SASSO, CARTA FORBICE! ***");
Console.WriteLine("Versione: 2.0");
Console.WriteLine("\nPremi un tasto per giocare...");
Console.ReadKey();


do{     // ! PLAY AGAIN inizia QUI

    // Inizializzazione NEW GAME / PLAY AGAIN
    allPunteggio[0] = 0; // Avversario
    allPunteggio[1] = 0; // Utente
    contatoreRound = 5;
    dialogoRound = 1;
    sceltaMenu = "";
    convertito = false;


    //Menu con controllo inserimento
    do
    {
        // Dialogo
        Console.Clear();
        Console.WriteLine("MENU:");
        Console.WriteLine("Scegliere la modalità di gioco");
        Console.WriteLine("[A] Default: 5 round");
        Console.WriteLine("[B] Custom");
        Console.Write("\n> ");

        // Acquisizione
        sceltaMenu=Console.ReadLine();
        sceltaMenu = sceltaMenu.ToUpper();

    } while (sceltaMenu != "A" && sceltaMenu != "B");


    // Acquisizione numero Round da utente con controllo conversione
    while (sceltaMenu == "B" && convertito == false)
    {

        //Dialogo
        Console.Clear();
        Console.WriteLine("Quanti Round vuoi giocare?");
        convertito = int.TryParse(Console.ReadLine(), out contatoreRound);

    }


    do      // ! ROUND inizia QUI
    {

        // Dialogo Round
        Console.Clear();
        Console.WriteLine($"Round {dialogoRound}\n");


        // Dialogo inserimento
        Console.WriteLine("[1] SASSO\t[2] CARTA\t [3] FORBICE");
        Console.Write("> ");
        numUser = int.Parse(Console.ReadLine());


        // Controllo inserimento
        while (numUser != 1 && numUser != 2 && numUser != 3)
        {

            Console.Clear();
            Console.WriteLine("Inserimento non valido.");
            Console.WriteLine("[1] SASSO\t[2] CARTA\t [3] FORBICE");
            Console.Write("> ");
            numUser = int.Parse(Console.ReadLine());
            
        }


        // Assegnazione mano utente 
        switch (numUser)
        {

            case 1:
                manoUser = "SASSO";  
            break;

            case 2:
                manoUser = "CARTA"; 
            break;

            case 3:
                manoUser = "FORBICE";
            break;

        }


        // Assegnazione mano PC
        randomPC = random.Next(1,4); //
        switch (randomPC)
        {

            case 1:
                manoPC = "SASSO";
            break;

            case 2:
                manoPC = "CARTA"; 
            break;

            case 3:
                manoPC = "FORBICE"; 
            break;

        }


        // Dialogo
        Console.Clear();
        Console.WriteLine("'SASSO, CARTA, FORBICE!'");
        Console.WriteLine("\nPremi un tasto per giocare...");
        Console.ReadKey();


        // Logica di comparazione
        if (manoUser == "CARTA" && manoPC == "SASSO" || manoUser == "FORBICE" && manoPC == "CARTA" || manoUser == "SASSO" && manoPC == "FORBICE")
        {

            // Aggiornamento punteggio vittoria Utente
            allPunteggio[Utente]++;

            // Vittoria
            Console.Clear();
            Console.WriteLine($"Tu({allPunteggio[Utente]})\t\tAvversario({allPunteggio[Avversario]})");
            Console.WriteLine($"{manoUser}\t\t{manoPC}\n");
            Console.WriteLine("Hai vinto!\n");

        }
        else if (manoUser == manoPC)
        {

            // Pareggio
            Console.Clear();
            Console.WriteLine($"Tu({allPunteggio[Utente]})\t\tAvversario({allPunteggio[Avversario]})");
            Console.WriteLine($"{manoUser}\t\t{manoPC}\n");
            Console.WriteLine("Pareggio!\n");

        } 
        else 
        {

            // Aggiornamento punteggio vittori Avversario
            allPunteggio[Avversario]++;

            // Sconfitta
            Console.Clear();
            Console.WriteLine($"Tu({allPunteggio[Utente]})\t\tAvversario({allPunteggio[Avversario]})");
            Console.WriteLine($"{manoUser}\t\t{manoPC}\n");
            Console.WriteLine("Hai perso!\n");

        }


        // Ometti dialogo "Continua" quando c'è l'ultimo Round
        if (contatoreRound-1 != 0)
        {

            // Dialogo
            Console.WriteLine("Continua...");
            Console.ReadKey();

        }


        // Decremento contatore
        contatoreRound--;

        // Incremento dialogoRound
        dialogoRound++;


    } while (contatoreRound != 0);  // ! ROUND finisce QUI

    // Dialogo risultati
    Console.WriteLine("--------------------------");
    Console.WriteLine("Fine partita!\n");
    Console.WriteLine("Ecco i punteggi...");
    Console.WriteLine($"\nTu\t\tAvversario");
    Console.WriteLine($"{allPunteggio[Utente]}\t\t{allPunteggio[Avversario]}\n");


    // Logica di comparazione dei risultati
    if (allPunteggio[Utente] > allPunteggio[Avversario])
    {

        // Hai battuto il tuo avversario!
        Console.WriteLine("CONGRATULAZIONI! HAI BATTUTO IL TUO AVVERSARIO!");

    }
    else if (allPunteggio[Utente] == allPunteggio[Avversario])
    {

        // Avete pareggiato!
        Console.WriteLine("ABBIAMO UN PAREGGIO!");

    }
    else
    {

        Console.WriteLine("MI DISPIACE, SEI STATO SCONFITTO!");

    }


    // Controllo PLAY AGAIN
    do
    {  

        Console.WriteLine("\n\nVuoi giocare di nuovo?");
        Console.WriteLine("[A] SI\t[B] NO");
        Console.Write("> ");
        sceltaMenu = Console.ReadLine();
        sceltaMenu = sceltaMenu.ToUpper();
        
        // Pulizia Console per DISPLAY AGAIN
        if (sceltaMenu != "A" && sceltaMenu != "B")
        {
            Console.Clear();
        }

    } while (sceltaMenu != "A" && sceltaMenu != "B");


} while (sceltaMenu == "A"); // ! PLAY AGAIN finisce QUI

// Dialogo
Console.WriteLine("Grazie per aver giocato!\n");