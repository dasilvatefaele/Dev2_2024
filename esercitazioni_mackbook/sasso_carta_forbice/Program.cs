// Pulizia Console
Console.Clear();


// Dichiarazione
int numUser;
int randomPC;
string manoUser = "";
string manoPC = "";
Random random = new Random();


// Dialogo
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
Console.WriteLine("Premi un tasto per giocare...");
Console.ReadKey();


// Logica di comparazione
if (manoUser == "CARTA" && manoPC == "SASSO" || manoUser == "FORBICE" && manoPC == "CARTA" || manoUser == "SASSO" && manoPC == "FORBICE")
{

    // Vittoria
    Console.Clear();
    Console.WriteLine($"Tu\t\tAvversario");
    Console.WriteLine($"{manoUser}\t\t{manoPC}\n");
    Console.WriteLine("Hai vinto!\n");

} 
else 
{

    // Sconfitta
    Console.Clear();
    Console.WriteLine($"Tu\t\tAvversario");
    Console.WriteLine($"{manoUser}\t\t{manoPC}\n");
    Console.WriteLine("Hai perso!\n");

}
