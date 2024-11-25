/***************************************************************
                    FUNZIONI DI INSERIMENTO
***************************************************************/

Console.Clear();
int inputSceltaMenu = NumberInRange(1, 8);
int inputNumeroIntero = InputInt();
double inputNumeroConLaVirgola = InputDouble();
string inputfrase = Inserimentofrase();

Console.WriteLine($"Input nel range: {inputSceltaMenu}");
Console.WriteLine($"input numero intero: {inputNumeroIntero}");
Console.WriteLine($"Input con la virgola: {inputNumeroConLaVirgola:F2}");
Console.WriteLine($"Input frase: {inputfrase}");

int InputInt()
{
    int numero = 0;
    bool repeat = false;
    do
    {
        repeat = false;
        try
        {
            Console.Write("Inserisci numero intero > ");
            numero = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine("#Errore: dato non corretto");
            repeat = true;
        }
    } while (repeat);
    return numero;
}

int NumberInRange(int min, int max)
{
    bool repeat = false;
    int num = 0;
    Console.Write($"Inserisci intero tra {min} e {max} ");
    do
    {
        do
        {
            Console.Write("> ");
            repeat = false;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("#Errore: dato non corretto");
                repeat = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("#Errore: dato non corretto");
                repeat = true;
            }
        } while (repeat);

        if (num >= min && num <= max)
        {
            //Console.WriteLine("*Numero nel range corretto*");
            return num;
        }
        else
        {
            Console.WriteLine("#Errore: numero fuori dal range");
            repeat = true;
        }
    } while (repeat);
    return -1;
}

double InputDouble()
{
    double numero = 0;
    bool repeat = false;
    string s_numero;
    do
    {
        repeat = false;

        Console.Write("Inserisci numero decimale > ");
        s_numero = Console.ReadLine();
        s_numero = s_numero.Replace(".", ",");

        try
        {
            numero = Convert.ToDouble(s_numero);
        }
        catch (Exception e)
        {
            Console.WriteLine("#Errore: dato non corretto");
            repeat = true;
        }
    } while (repeat);

    //Console.WriteLine("*Decimale insierito*");
    return numero;
}

string Inserimentofrase()
{

    Console.Write("Inserisci una stringa > ");
    string frase;
    frase = Console.ReadLine();
    bool ripeti = false;
    do
    {
        ripeti = string.IsNullOrWhiteSpace(frase);

        if (ripeti) // if true
        {
            Console.WriteLine("#Errore: stringa vuota");
            frase = Console.ReadLine();
        }
        else
        {
            //Console.WriteLine("*Stringa inserita*");
            return frase;
        }
    } while (ripeti);
    return frase;
}



