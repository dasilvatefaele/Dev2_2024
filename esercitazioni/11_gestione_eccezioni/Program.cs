/*=========================================================
                    GESTIONE ECCEZIONI
=========================================================*/
/*
    la gestinazione di accezioni è un meccanismo che permette
    la gestione degli errori che si verificano durante l'esecuzione
    di un programma
*/

//  int number = int.Parse("abc");
//!  Esempio solo col .Parse
//!  in questo caso l'eccezione viene notificata ma non gestita



/* 
// ESEMPIO SEMPLICE 
try
{
    int number2 = int.Parse("abc");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
}
*/
//*  ci sono diversi tipi di costrutto per la gestione delle eccezioni in c#
//*  try-catch
//*  try-catch-finally


Console.Clear();

//! ESEMPIO 1
/*
try
{
    int number3 = int.Parse("abc");
}
catch (FormatException e)
{
    Console.WriteLine($"Errore di formato: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
}
finally
{
    Console.WriteLine("il blocco finally viene sempre eseguito.");
}
*/
//* try-catch crea una variabile TIPO: FormatException NOME VARIABILE: e --> (FormatException e) contenente il nome dell'errore attraverso il metodo .Message (e.Message)
//* si possono usare più catch in un blocco try-catch
//* è possibile usare il blocco try-catch-finally per eseguire un blocco di codice anche se si verifica un errore
//* il blocco finally viene sempre eseguito

//*  è possibile lanciare un'eccezione con il comando throw
//! ESEMPIO 2
/*
try
{
    throw new Exception("Errore generico");
}
catch (Exception e)
{
    Console.WriteLine($"Errore {e.Message}");
}
*/
 
 //! ESEMPIO 3
//*  esempio completo di gestione delle eccezioni con try-catch-throw e finally

try
{
    int number4 = int.Parse("abc");
    //  a cosa serve il throw??? 
    //  throw new Exception ("Errore generico"); // ? FARE RICERCHE
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
    Console.WriteLine(e.HResult);
}
finally
{
    Console.WriteLine("il blocco finally viene sempre eseguito.");
}

// la principale differenza tra try-parse e try-catch è che il 
//* try-parse restituisce solo un valore booleano che indica avvenuta o mancata conversione
//* try-catch genera un'eccezione, è più flessibile perché consente di gestire l'eccezione
//* è possibile usare il Throw per lanciare un'eccezione personalizzata

//* esempio di gestione delle eccezioni

// il programma per funzionare deve avere un file .txt e deve contenere un numero

 //! ESEMPIO 4
 /*
try
{
    string text = File.ReadAllText("file.txt");
    int numero6 = int.Parse(text);
}
catch (FileNotFoundException e)
{
    Console.WriteLine($"File non trovato: {e.Message}");
}
catch (FormatException e)
{
    Console.WriteLine($"Errore di formato: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
}
finally
{
    Console.WriteLine("Il blocco finally viene sempre eseguito.");
}
*/

 //! ESEMPIO 5
/*
 int[] numeri = {1,2,3};
 try
 {
    Console.WriteLine(numeri[3]);
 }
 catch (Exception e)
 {
    Console.WriteLine($"Errore: {e.Message}");
 }
 finally
 {
    Console.WriteLine("Il blocco finally viene sempre eseguito.");
 }
 */

 //! ESEMPIO 6
/*
try
{
    string text2  = null;
    Console.WriteLine(text2.Length);
}
catch (NullReferenceException e)
{
    Console.WriteLine($"Oggetto null: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
    Console.WriteLine("Errore: Oggetto null");

}
finally
{
    Console.WriteLine("Il blocco finally viene sempre eseguito.");
}
*/

 //! ESEMPIO 7
/*
try
{
    string text2  = null;
    Console.WriteLine(text2.Length);
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
    Console.WriteLine("Errore: Oggetto null");
}
finally
{
    Console.WriteLine("Il blocco finally viene sempre eseguito.");
}
*/

//! ESEMPIO 8
// il programma cerca di dividere per 0
/*
try
{
    int number7 = 10;
    int number8 = 0;
    int number9 = number7 / number8;
}
catch (DivideByZeroException e)
{
    Console.WriteLine($"Divisione per zero: {e.Message}");
    // esempio di e.HResult
    Console.WriteLine($"HResult: {e.HResult}");
}
finally
{
    Console.WriteLine("Il blocco finally viene sempre eseguito.");
}
*/
//! ESEMPIO 9
// il programma testa di accedere ad un argomento fuori dal range consentito
/*
try
{
        int numero = int.Parse("1000000000000");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
    Console.WriteLine(e.HResult);
}
*/