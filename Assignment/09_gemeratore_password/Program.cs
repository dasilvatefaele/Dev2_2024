//! MAIN
using System.ComponentModel;

bool converted = false;
int lunghezza= 5 ;
string passwordGenerata;
do
{
    Console.WriteLine("Genera una nuova password [8 - 20]");
    Console.Write("> ");
    converted = int.TryParse(Console.ReadLine(), out  lunghezza);
}while (converted  && lunghezza < 8 && lunghezza > 20);

string output;
Console.Write("> GENERA PASSWORD:");
output = GeneraPassword (lunghezza);
Console.WriteLine("* PASSWORD GENERATA *");
Console.WriteLine("> Mostra la password > ");
Console.WriteLine(output);

//!FUNZIONIA

static string GeneraPassword (int lunghezza)
{
    Console.WriteLine("sei entrato nel genera password");
    int index;
    string alfabetoMinuscolo = "abcdefghijklmnopqrstuvwxyz";
    string alfabetoMaiuscolo = alfabetoMinuscolo.ToUpper();
    string numeriPerPassword = "0123456789";
    string caratteriSpeciali = "!£$%&/)(=?@#*";
    string passwordGenerata= "";
    var rnd = new Random();
    Console.WriteLine("sto per creare la password");
    do 
    {
        index = rnd.Next(alfabetoMinuscolo.Length);
        //Console.WriteLine($"debug: {index}");

        passwordGenerata += alfabetoMinuscolo[index]; 
        //Console.WriteLine($"debug: {passwordGenerata}");

        if (passwordGenerata.Length == lunghezza)
        {
            return passwordGenerata;
        }

        index = rnd.Next(alfabetoMaiuscolo.Length);
        passwordGenerata += alfabetoMaiuscolo[index]; 
        if (passwordGenerata.Length == lunghezza)
        {
            return passwordGenerata;
        }

        index = rnd.Next(numeriPerPassword.Length);
        passwordGenerata += numeriPerPassword[index]; 
        if (passwordGenerata.Length == lunghezza)
        {
            return passwordGenerata;
        }

        index = rnd.Next(caratteriSpeciali.Length);
        passwordGenerata += caratteriSpeciali[index]; 
        if (passwordGenerata.Length == lunghezza)
        {
            return passwordGenerata;
        }
    } while (passwordGenerata.Length <= lunghezza);
    
    return passwordGenerata;
  
}