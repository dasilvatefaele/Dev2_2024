Console.Clear();

Random random = new Random();
int dadoComputer;
int dadoUtente;
char risposta = ' ';


do
{
    Console.Clear();

    // DIALOGO
    Console.WriteLine("*** GIOCO: LANCIA DADO ***");
    Console.WriteLine("Premi un tasto per lanciare il dado...");
    Console.ReadKey();
    risposta = ' '; // inizializzo risposta

    dadoUtente = random.Next(1,7);
    // UTENTE lancia dado

    dadoComputer = random.Next(1,7);
    // COMPUTER lancia dado

    Console.WriteLine($"IL TUO DADO\t\tDADO COMPUTER\n{dadoUtente}\t\t\t{dadoComputer}");
    // DISPLAY DADI

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

    do
    {
        Console.WriteLine("\nVuoi giocare di nuovo? [s/n]");
        Console.Write("> ");
        risposta = Console.ReadKey().KeyChar;
    }while (risposta != 's' && risposta != 'n');


}while (risposta == 's');

Console.WriteLine("\nGrazie per aver giocato!");


