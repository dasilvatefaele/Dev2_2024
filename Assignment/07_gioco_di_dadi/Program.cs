Console.Clear();

int dadoUtente;
int dadoComputer;
int [] punteggio = new int [2];
bool partitaContinua = true;

const int UTENTE = 0;
const int COMPUTER = 1;
const int PUNTEGGIO_INIZIALE = 20;

List<int[]> storicoPunteggi = new List<int[]> ();

punteggio[UTENTE] = PUNTEGGIO_INIZIALE;
punteggio[COMPUTER] = PUNTEGGIO_INIZIALE;

do
{
    Console.Clear();

    StampaDialogo();
    
    dadoUtente =    LancioDado(); 
    dadoComputer =  LancioDado(); 

    StampaLancio(dadoComputer, dadoUtente);    
    Confronto(dadoComputer, dadoUtente);

    punteggio = AggiornaPunteggio(dadoComputer,dadoUtente,punteggio);
    StampaPunteggio(punteggio);

    storicoPunteggi.Add((int[])punteggio.Clone()); // Salva il punteggio nello storico
     
    partitaContinua = PlayAgain(punteggio, storicoPunteggi);

    Console.ReadKey();
    
}while (partitaContinua);

Console.WriteLine("\nGrazie per aver giocato!");
Console.WriteLine();

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

bool PlayAgain( int[] punteggio, List<int[]> storicoPunteggi) //storicoPunteggi mi serve in caso di inizializzazione
{
    if(punteggio[COMPUTER] <= 0 || punteggio[UTENTE] <= 0)
    {
        char risposta = ' ';

        Console.WriteLine("Fine partita!");
        if (punteggio[COMPUTER] > punteggio[UTENTE])
        {
            Console.WriteLine("Hai finito i punti. IL COMPUTER TI HA BATTUTO!");
            Console.WriteLine();
            StampaStorico(storicoPunteggi);

        }
        else if(punteggio[UTENTE] > punteggio[COMPUTER])
        {
            Console.WriteLine("Il computer ha finito i punti. CONGRATULAZIONI! HAI VINTO!");
            Console.WriteLine();
            StampaStorico(storicoPunteggi);

        }

        Console.WriteLine("===================================");

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
            storicoPunteggi.Clear();
            return true;
        }
        else
        {
            return false;
        }
    }
    return partitaContinua;
}

void StampaPunteggio(int [] punteggio)
{
    Console.WriteLine("===================================");
    Console.WriteLine($"\nIL TUO PUNTEGGIO\tPUNTEGGIO COMPUTER\n{punteggio[UTENTE]}\t\t\t{punteggio[COMPUTER]}");
    Console.WriteLine();
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
    Console.WriteLine();
    Console.ReadKey();
}

void StampaStorico(List<int[]>storicoPunteggi)
{
    Console.WriteLine();
    Console.WriteLine("\tStorico punteggi:");
    Console.WriteLine();
    Console.WriteLine("\t\tTU\tCOMPUTER");
    for (int i = 0; i < storicoPunteggi.Count; i++)
    {
        Console.Write($"Partita {i+1}:\t");
        Console.WriteLine(string.Join("\t", storicoPunteggi[i]));
    }
}