Console.Clear();

int dadoComputer;
int dadoUtente;
char risposta = ' ';

do
{
    Console.Clear();
    risposta = ' '; // inizializzo risposta

    // DIALOGO
    Console.WriteLine("*** GIOCO: LANCIA DADO ***");
    Console.WriteLine("Premi un tasto per lanciare il dado...");
    Console.ReadKey();
    
    dadoUtente = LancioDado(); // UTENTE lancia dado
    dadoComputer = LancioDado(); // COMPUTER lancia dado

    StampaLancio(dadoComputer, dadoUtente);    
    Confronto(dadoComputer, dadoUtente);
    risposta = PlayAgain(risposta);
    
}while (risposta == 's');

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

char PlayAgain(char risposta)
{
    do
    {
        Console.WriteLine("\nVuoi giocare di nuovo? [s/n]");
        Console.Write("> ");
        risposta = Console.ReadKey().KeyChar;
    }while (risposta != 's' && risposta != 'n');
    return risposta;
}