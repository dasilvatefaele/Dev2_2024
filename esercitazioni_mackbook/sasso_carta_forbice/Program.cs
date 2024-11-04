Console.Clear();
Random random = new Random();
int numUser;

string manoPC = "";
string manoUser = "";
int randomPC;

randomPC = random.Next(1,4); // da 1 a 3

Console.WriteLine("[1] SASSO\t[2] CARTA\t [3] FORBICE");
Console.WriteLine("Scelta:");
numUser = int.Parse(Console.ReadLine());

switch (numUser){
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

switch (randomPC){
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

if (manoUser == "CARTA" && manoPC == "SASSO" || manoUser == "FORBICE" && manoPC == "CARTA" || manoUser == "SASSO" && manoPC == "FORBICE")
{
    Console.WriteLine($"TU\t\tAVVERSARIO");
    Console.WriteLine($"{manoUser}\t\t{manoPC}\n");
    Console.WriteLine("Hai vinto!");
} else {
    Console.WriteLine($"TU\t\tAVVERSARIO");
    Console.WriteLine($"{manoUser}\t\t{manoPC}\n");
    Console.WriteLine("Hai perso!");
}