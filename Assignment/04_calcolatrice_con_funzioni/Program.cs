//! Funzioni
double Somma (double n1, double n2)
{
    return n1 + n2;
}
double Moltiplica (double n1, double n2)
{
    return n1 * n2;
}
double Sottrai (double n1, double n2)
{
    return n1 - n2;
}
double Dividi (double n1, double n2)
{

    return n1/n2;
}
double InserisciNumero (double numero1, bool valido)
{
    do
    {
        Console.Write("> ");
        try
        {
            numero1 = double.Parse(Console.ReadLine());
            valido = true;
        }
        catch (FormatException e) // ? andava bene anche (Exception e) generico?
        {
            Console.WriteLine("Errore: inserire valore valido");
            valido = false;
        }
    }while(!valido);

    return numero1;

}
char SelezionaOperatore (char operatore, bool valido)
{
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
            valido = false;
        }
        else
        {
            valido = true;
        }
    } while (!valido);

    return operatore;
}
double EseguiOperazione(char operatore,double numero1, double numero2, bool valido)
{
    bool numero2Valido = false;
    double risultato = 0;
    try
    {
        switch (operatore)
        {
            case '+':
                risultato = Somma(numero1,numero2);
                break;
            case '-':
                risultato = Sottrai(numero1,numero2);
                break;
            case '*':
                risultato = Moltiplica(numero1,numero2);
                break;
            case '/':
                //! controllo: double numero2
                //*     if == 0 --> NUMERO NON VALIDO, INSERISCI DI NUOVO FINCHé != 0
                //*     else    --> NUMERO VALIDO, ESEGUI OPERAZIONE
                do
                {
                    if (numero2 == 0)
                    {
                        valido = !valido;
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
                                valido = true;
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Errore: inserire valore valido");
                                valido = false;
                            }
                        }while(!valido);
                    }
                    else
                    {
                        risultato = Dividi(numero1, numero2);
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
        valido = false;
    }
   
    return risultato;

}


//!  Main
double numero1 = 0;
double numero2 = 0;
double risultato = 0;
bool numero2Valido = true;
bool valido = true;
char operatore = ' ';

//Dialogo
Console.Clear();
Console.WriteLine("Inserisci numeri:");

// chiedi all'utente di inserire due numeri
numero1 = InserisciNumero (numero1,valido);
numero2 = InserisciNumero (numero2,valido);

// chiedi all'utente di selezionare operatore matematico
operatore = SelezionaOperatore(operatore,valido);

Console.WriteLine(); // a capo

// esegui l'operazione selezionata
risultato = EseguiOperazione(operatore,numero1,numero2, valido);

// stampa
if (valido)
{
    Console.WriteLine($"= {risultato}");
}