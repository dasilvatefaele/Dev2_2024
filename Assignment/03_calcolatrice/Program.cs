double numero1 = 0;
double numero2 = 0;
double risultato = -1;
bool numeroConvertito = true;
bool operatoreValido = true;
bool numero2Valido = true;
char operatore = ' ';

//Dialogo
Console.Clear();
Console.WriteLine("Inserisci numeri:");

// chiedi all'utente di inserire due numeri
//! controllo: numero1
//* che sia un numero con try-catch / do-while
do
{
    Console.Write("n1 => ");
    try
    {
        numero1 = double.Parse(Console.ReadLine());
        numeroConvertito = true;
    }
    catch (FormatException e) // ? andava bene anche (Exception e) generico?
    {
        Console.WriteLine("Errore: inserire valore valido");
        numeroConvertito = false;
    }
}while(!numeroConvertito);

//! controllo: numero2
//* che sia un numero con try-catch / do-while
do
{
    Console.Write("n2 => ");
    try
    {
        numero2 = double.Parse(Console.ReadLine());
        numeroConvertito = true;
    }
    catch (FormatException e)
    {
        Console.WriteLine("Errore: inserire valore valido");
        numeroConvertito = false;
    }
}while(!numeroConvertito);

// chiedi all'utente di selezionare operatore matematico
//! controllo: char operatore
//* inserimento operatore con if-else/do-while
do
{
    Console.WriteLine("Scegli l'operatore:");
    Console.WriteLine("\n+\t-\t*\t/\n");
    Console.Write("> ");
    operatore = Console.ReadKey().KeyChar; 
    if (operatore != '*' && operatore != '+' && operatore != '-' && operatore != '/')
    {
        Console.WriteLine();
        Console.WriteLine("Errore: selezionare operatore valido");
        operatoreValido = false;
    }
    else
    {
        operatoreValido = true;
    }
} while (!operatoreValido);

Console.WriteLine(); // a capo

// esegui l'operazione selezionata

try
{


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
            //! controllo: double numero2
            //*     if == 0 --> NUMERO NON VALIDO, INSERISCI DI NUOVO FINCHé != 0
            //*     else    --> NUMERO VALIDO, ESEGUI OPERAZIONE
            do
            {
                if (numero2 == 0)
                {
                    throw new DivideByZeroException ();
                    Console.WriteLine("Errore: Divisione per 0 non consentita");
                    numero2Valido = false;
                    //! controllo: double numero2
                    //* reinserimento e check che sia un numero con try-catch / do-while
                    do
                    {
                        Console.Write("n2 => ");
                        try
                        {
                            numero2 = double.Parse(Console.ReadLine());
                            numeroConvertito = true;
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Errore: inserire valore valido");
                            numeroConvertito = false;
                        }
                    }while(!numeroConvertito);
                }
                else
                {
                    risultato = numero1/numero2;
                    numero2Valido = true;
                }
            } while (!numero2Valido);
            break;
        default:
            Console.WriteLine("Operatore non valido");
            break;
    }
}
catch (DivideByZeroException e)
{
    Console.WriteLine ("Impossibile dividere per 0");

}
// stampa risultato
Console.WriteLine($"= {risultato}");