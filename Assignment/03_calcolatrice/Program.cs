//* chiedi all'utente di inserire due numeri
double numero1;
double numero2;
double risultato = -1;

//Dialogo
Console.Clear();
Console.WriteLine("Inserisci numeri:");
Console.Write("> ");
numero1 = double.Parse(Console.ReadLine());
Console.Write("> ");
numero2 = double.Parse(Console.ReadLine());

//* chiedi all'utente di selezionare operatore matematico
Console.WriteLine("Scegli l'operatore:");
Console.WriteLine("\n+\t-\t*\t/\n");
Console.Write("> ");
char operatore = Console.ReadKey().KeyChar; 
// acquisizione char singolo, non richiede l'invio per l'inserimento
Console.WriteLine(); 
// a capo

//* esegui l'operazione selezionata
switch (operatore)
{
    case '+':
        risultato = numero1+numero2;
        break;
    case '-':
        risultato = numero1-numero2;
        break;
    case '*':
        risultato = numero1*numero2;
        break;
    case '/':
        risultato = numero1/numero2;
        break;
    default:
        Console.WriteLine("Operatore non valido");
        break;
}

//* stampa risultato
Console.WriteLine($"= {risultato}");