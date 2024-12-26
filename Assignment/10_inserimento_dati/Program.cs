/***********************************************
                INSERIMENTO DATI
***********************************************/
using System.ComponentModel;

int dato = 0;
bool convertito;
double somma = 0;
double media;
var listaSondaggio = new List<int>();

do
{
    convertito = false;
    Console.WriteLine("Inserisci numero:");
    Console.Write("> ");
    //convertito = int.TryParse(Console.ReadLine(), out dato);
    try
    {
        dato = int.Parse(Console.ReadLine());
    }
    catch (OverflowException e)
    {
        convertito = true;
        // error
    }
    catch (FormatException e)
    {
        convertito = true;
        // error
    }
    catch (Exception e)
    {
        convertito = true;
        // error
    }

    if (dato >= 0)
    {
        listaSondaggio.Add(dato);
        convertito = !convertito;
    }
    else if (dato < 0)
    {
        convertito = false;
    }
}
while (convertito);

//listaSondaggio.Sort();
//int maggiore = listaSondaggio[listaSondaggio.Count-1];

int maggiore = 0;
int minore = listaSondaggio[0];
foreach (var numero in listaSondaggio)
{
    maggiore = Math.Max(maggiore, numero);
}

foreach (var numero in listaSondaggio)
{
    minore = Math.Min(minore, numero);
}

foreach (var numero in listaSondaggio)
{
    if (numero >= 0)
    {
        somma += numero;
    }
}

media = listaSondaggio.Average();

Console.WriteLine($"\nSono stati inseriti\t\t{listaSondaggio.Count} elementi\nLa media è:\t\t\t{media}\nIl numero più altro è:\t\t{maggiore}\nIl numero più basso è:\t\t{minore}");
