Console.Clear();

int dadoComputer;
int dadoUtente;
int [] punteggio = new int [2];
char risposta = ' ';

bool partitaContinua = true;

const int PUNTEGGIO_INIZIALE = 20;
const int UTENTE = 0;
const int COMPUTER = 1;

punteggio[UTENTE] = PUNTEGGIO_INIZIALE;
punteggio[COMPUTER] = PUNTEGGIO_INIZIALE;

do
{
    Console.Clear();
    risposta = ' '; // inizializzo risposta

    StampaDialogo();
    
    dadoUtente =    LancioDado(); // UTENTE lancia dado
    dadoComputer =  LancioDado(); // COMPUTER lancia dado

    StampaLancio(dadoComputer, dadoUtente);    
    Confronto(dadoComputer, dadoUtente);

    punteggio = AggiornaPunteggio(dadoComputer,dadoUtente,punteggio);
    punteggio = StampaPunteggio(punteggio);

    risposta = PlayAgain(risposta, dadoComputer, dadoUtente);

    Console.ReadKey();
    
}while (partitaContinua);

Console.WriteLine("\nGrazie per aver giocato!");

int LancioDado()
{
    Random random = new Random();
    return random.Next(1,7);
}

void Confronto(int dadoComputer, int dadoUtente)
{
    // CONFRONTO
    if(dadoUtente > dadoComputer)
    {
        Console.WriteLine("Hai vinto!");
    }
    else if (dadoUtente == dadoComputer)
    {
        Console.WriteLine("Pareggio!");
    }
    else
    {
        Console.WriteLine("Hai perso!");
    }
}

void StampaLancio(int dadoComputer, int dadoUtente)
{
    Console.WriteLine($"IL TUO DADO\t\tDADO COMPUTER\n{dadoUtente}\t\t\t{dadoComputer}");
}

char PlayAgain(char risposta, int dadoComputer, int dadoUtente)
{
    if(punteggio[COMPUTER] <= 0 || punteggio[UTENTE] <= 0)
    {
        Console.WriteLine("Fine partita!");
        if (punteggio[COMPUTER] > punteggio[UTENTE])
        {
            Console.WriteLine("Hai finito i punti. IL COMPUTER TI HA BATTUTO!");
        }
        else if(punteggio[UTENTE] > punteggio[COMPUTER])
        {
            Console.WriteLine("Il computer ha finito i punti. CONGRATULAZIONI! HAI VINTO!");
        }

        do
        {
            Console.WriteLine("\nVuoi giocare di nuovo? [s/n]");
            Console.Write("> ");
            risposta = Console.ReadKey().KeyChar;
        }while (risposta != 's' && risposta != 'n');
        

        if (risposta == 's')
        {
            punteggio[COMPUTER] = PUNTEGGIO_INIZIALE;
            punteggio[UTENTE] = PUNTEGGIO_INIZIALE;
            partitaContinua = true;
        }
        else
        {
            partitaContinua = false;
        }
    }
    return risposta;
}

int [] StampaPunteggio(int [] punteggio)
{
    if (punteggio[UTENTE] <= 0)
    {
        punteggio[UTENTE] = 0;
        Console.WriteLine($"\nIL TUO PUNTEGGIO\tPUNTEGGIO COMPUTER\n{punteggio[UTENTE]}\t\t\t{punteggio[COMPUTER]}");
    }
    else if (punteggio[COMPUTER] <= 0)
    {
        punteggio[COMPUTER] = 0;
        Console.WriteLine($"\nIL TUO PUNTEGGIO\tPUNTEGGIO COMPUTER\n{punteggio[UTENTE]}\t\t\t{punteggio[COMPUTER]}");
    }
    else
    {
        Console.WriteLine($"\nIL TUO PUNTEGGIO\tPUNTEGGIO COMPUTER\n{punteggio[UTENTE]}\t\t\t{punteggio[COMPUTER]}");
    }

    return punteggio;
}

int [] AggiornaPunteggio(int dadoComputer, int dadoUtente, int [] punteggio)
{
    int differenza = Math.Abs(dadoComputer - dadoUtente);

    if(dadoUtente > dadoComputer)
    {
        punteggio[UTENTE]   += 10 + differenza;
        punteggio[COMPUTER] -= 10 + differenza;
    }
    else if (dadoUtente < dadoComputer)
    {
        punteggio[UTENTE]   -= 10 + differenza;
        punteggio[COMPUTER] += 10 + differenza;
    }

    if (punteggio[UTENTE] <= 0)
    {
        punteggio[UTENTE] = 0;
    }
    
    if (punteggio[COMPUTER] <= 0)
    {
        punteggio[COMPUTER] = 0;
    }

    return punteggio;
}

void StampaDialogo()
{
    Console.WriteLine("*** GIOCO: LANCIA DADO ***");
    Console.WriteLine("Premi un tasto per lanciare il dado...");
    Console.ReadKey();
}