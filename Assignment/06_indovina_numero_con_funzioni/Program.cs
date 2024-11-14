/******************************************************************************/
//                      INDOVINA NUMERO v1.8 con funzioni
/******************************************************************************/

using System.Security.Principal;

//! MAIN
Console.Clear();


// Dichiarazione e inizializzazione
int numeroDaIndovinare = 0;
int sommaNumeroDiTentativi = 0;
int bonus = 0;
int selezioneOpzione = 0;
int punteggioGiocatore = 0;
int punteggioTemp = 0;
int nRound = 0;
bool valido = false;
bool roundFinito = false;
bool successoNumeroUtente = false;
double intervallo = 0;
string risposta = "";
List<int> numeriTentatiSbagliati = new List<int>();
List<int> tuttiTentativi = new List<int>();
Dictionary<string, int> Score = new Dictionary<string, int>();
Dictionary<int, int> ScoreTentativi = new Dictionary<int, int>();
Dictionary<string, List<int>> playerElencoNumeriSbagliati = new Dictionary<string, List<int>>();

do //>  LOOP MAIN
{ 
    Console.Clear();
    tuttiTentativi.Clear();


    Console.WriteLine("****************************************");
    Console.WriteLine("             INDOVINA NUMERO!");
    Console.Write("\n****************************************");
    Console.ReadKey();
    Console.Clear();


    Console.Write("Player: ");
    string nomePlayer = Console.ReadLine();
  
    do   
    {
        SelezioneDifficoltà(out selezioneOpzione, out valido);
    } while (!valido);


    do //> LOOP DEL ROUND 'n'
    {
        switch (selezioneOpzione) //* INIZIALIZZO NUOVO NUMERO DA INDOVINARE
        {
            case 1:
                numeroDaIndovinare = NumeroCasualeFinoA(21);
                intervallo = 19;
                bonus = 50;
                break;
            case 2:
                numeroDaIndovinare = NumeroCasualeFinoA(51);
                intervallo = 49;
                bonus = 100;
                break;
            case 3:
                numeroDaIndovinare = NumeroCasualeFinoA(101);
                intervallo = 99;
                bonus = 200;
                break;
            default:
                break;
        }

        // Console.WriteLine($"Debug: {numeroDaIndovinare}"); //* Esponi numero da indovinare per Debug

        //Stampa istruzioni di gioco
        Console.WriteLine($"*** Round {nRound + 1} ***");
        Console.WriteLine("Istruzioni: Hai 10 tentativi per indovinare un numero che ho pensato... Cominciamo!\n");
        Console.WriteLine("Premere un tasto per iniziare...");
        Console.ReadKey();

        // Inizializzazione tentativi
        int numeroTentativi = 10;
        int numeroUtente = 0;

        Console.Clear();
        Console.Write($"Ho in mente un numero... Indovinalo! Hai {numeroTentativi} tentativi\n--> ");

        while (true) //> LOOP DEI TENTATIVI
        {
            InserimentoNumeroUtente(out numeroUtente, out successoNumeroUtente);

            if (numeroUtente == numeroDaIndovinare)
            {
                // Stampa messaggio - "Hai indovinato!" - Fine sessione con vittoria
                Console.WriteLine($"\nHai indovinato! Avevo pensato proprio al {numeroDaIndovinare}\n");
                sommaNumeroDiTentativi = sommaNumeroDiTentativi + (10 - numeroTentativi);
                tuttiTentativi.AddRange(numeriTentatiSbagliati);
                punteggioTemp += numeroTentativi * 10 + bonus;
                break;
            }
            else
            {
                // Decremento tentativi
                numeroTentativi--;

                Console.Clear();
                Console.WriteLine($"Mmm... Sbagliato :( Ora hai {numeroTentativi} tentativi...");

                // Aggiungi numero alla lista dei numeri tentati e stampa 
                numeriTentatiSbagliati.Add(numeroUtente);

                StampaNumeriSbagliati(numeriTentatiSbagliati);
                IndizioFuocoAcqua(numeroDaIndovinare, numeroUtente, intervallo);

                if (numeroTentativi == 5)
                {
                    IndizioPariDispari(numeroDaIndovinare);
                }

                if (numeroTentativi < 5 && numeroTentativi > 0) // Indizio al tentativo 4, 3, 2, 1
                {
                    IndizioMaggioreMinore(numeroUtente, numeroDaIndovinare);
                }

                if (numeroTentativi == 0) // Solo quando finiscono i tentativi: Sconfitta
                {
                    Console.Clear();
                    Console.Write($"Mi dispiace... Il numero che avevo pensato era {numeroDaIndovinare}\n\n");
                    break;
                }
                Console.Write("===> "); // Stampa indicatore inserimento
            }
        }

        Console.WriteLine($"Hai totalizzato {punteggioTemp} punti nel {nRound + 1}^ round");
        playerElencoNumeriSbagliati.Add(nomePlayer, tuttiTentativi);

        foreach (var score in playerElencoNumeriSbagliati)
        {
            Console.WriteLine($"\nPlayer: {score.Key}\nHai provato: [{string.Join(", ", score.Value)}]\n");
        }

        playerElencoNumeriSbagliati.Clear();

        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
        Console.Clear();

        punteggioGiocatore += punteggioTemp;
        punteggioTemp = 0;
        numeriTentatiSbagliati.Clear();

        nRound++;
        if (nRound == 3)
        {
            roundFinito = true;
        }

    } while (!roundFinito); //> FINE ROUND

    Console.WriteLine($"Fine del gioco! {nomePlayer} ha totalizzato {punteggioGiocatore} punti!\n");

    Score.Add(nomePlayer, punteggioGiocatore);
    ScoreTentativi.Add(punteggioGiocatore, sommaNumeroDiTentativi);
   
    StampaScore(ScoreTentativi);
    Console.WriteLine("\nVuoi giocare di nuovo? s/n");

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
    roundFinito = false;
    numeriTentatiSbagliati.Clear();
    punteggioGiocatore = 0;
    punteggioTemp = 0;
    sommaNumeroDiTentativi = 0;

} while (risposta == "S"); //> FINE MAIN LOOP

Console.Clear();
StampaScore(ScoreTentativi);
Console.WriteLine("\nGrazie per aver giocato!");
Console.ReadKey();

//! FUNZIONI
void SelezioneDifficoltà(out int selezioneOpzione, out bool valido)
{
    valido = false;
    Console.WriteLine("Modalità di gioco:\n[1] Facile\t[2] Medio\t[3] Difficile");
    Console.Write("===>");
    do
    {
        bool successo = int.TryParse(Console.ReadLine(), out selezioneOpzione);
        if (successo == true)
        {
            valido = true;
        }
        else
        {
            Console.WriteLine("Serve inserire un valore valido :( riprova...");
            Console.Write("===>");
            valido = false;
        }
    } while (valido == false);

    // Stampo e imposto la modalità (Facile, Medio, Difficile)
        switch (selezioneOpzione)
        {
            case 1:
                valido = true;
                Console.Clear();
                Console.WriteLine("Modalità: Facile (penso a un numero tra 1 e 20)");
                break;
            case 2:
                valido = true;
                Console.Clear();
                Console.WriteLine("Modalità: Medio (penso a un numero tra 1 e 50)");
                break;
            case 3:
                valido = true;
                Console.Clear();
                Console.WriteLine("Modalità: Difficile (penso a un numero tra 1 e 100)");
                break;
            default:
                valido = false;
                Console.Clear();
                Console.WriteLine("Questa modalità non esiste ancora :) Scegli una delle opzioni disponibili!\n");
                break;
        }

}

void IndizioFuocoAcqua(int numeroDaIndovinare, int numeroUtente, double intervallo)
{
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
}

void IndizioPariDispari (int numeroDaIndovinare)
{
    if (numeroDaIndovinare % 2 == 0) { { Console.WriteLine("Indizio: il numero che ho pensato è pari... :)"); } }
    else { Console.WriteLine("Indizio: il numero che ho pensato è dispari... :)"); }
}

void IndizioMaggioreMinore( int numeroUtente, int numeroDaIndovinare)
{
    if (numeroUtente > numeroDaIndovinare) 
    { 
        Console.WriteLine("Indizio: il numero che ho pensato è più basso... :)"); 
    }
   
    if (numeroUtente < numeroDaIndovinare) 
    { 
        Console.WriteLine("Indizio: il numero che ho pensato è più alto... :)"); 
    }
}

void StampaScore(Dictionary<int, int> ScoreTentativi)
{
    Console.WriteLine("******************************************");
    Console.WriteLine("                SCORE:");
    Console.WriteLine("PUNTEGGIO\t\tTENTATIVI");
    foreach (var player in ScoreTentativi)
    {
        Console.WriteLine($"{player.Key}\t\t\t{player.Value}");
    }
    Console.WriteLine("******************************************");
}

void InserimentoNumeroUtente(out int numeroUtente, out bool successoNumeroUtente)
{
            do // Acquisizione numeroUtente e controllo validità
            {
                successoNumeroUtente = int.TryParse(Console.ReadLine(), out numeroUtente);
                if (successoNumeroUtente == true && numeroUtente >= 1 && numeroUtente <= intervallo + 1)
                {
                    valido = true;
                }
                else
                {
                    Console.WriteLine("Serve inserire un valore valido :( riprova...");
                    Console.Write("===>");
                    valido = false;
                }
            } while (valido == false);
}

int NumeroCasualeFinoA(int estremo)
{
    Random random = new Random();
    return random.Next(1, estremo);
}

void StampaNumeriSbagliati(List<int> numeriTentatiSbagliati)
{
    Console.Write("I tuoi numeri (");
    Console.Write(string.Join(", ", numeriTentatiSbagliati));
    Console.Write(")\n");
}