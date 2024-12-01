/*
QUESTO E' UN PROGETTO ESEMPIO
IL PROGRAMMA NON HA ALCUNA UTILITA' SPECIFICA SE NON QUELLO DI 
FAR VEDERE COME:

    1. CREARE - SCRIVERE - LEGGERE DA UN FILE
    2. UTILIZZARE IL CONTENUTO DI UN FILE ALL'INTERNO DEL PROGRAMMA 
*/

Console.Clear();


//
Console.WriteLine("Impariamo a creare un file...(premi un tasto per continuare)");
Console.ReadLine();
//


string ilNomeCheVuoi = @"animali della fattoria.txt";
// il prof l'ha chiamato path, qui si chiama "ilNomeCheVuoi" proprio per sottolineare
// che può essere davvero il nome più utile a te leggere meglio il tuo programma :)
// la cosa importante è che DENTRO ci sia il nome del file.txt

File.Create(ilNomeCheVuoi).Close();


// CREO "animali della fattoria.txt" per ora VUOTO.
Console.WriteLine("Ho creato il file!\nE' ancora vuoto ma controlla la Cartella... (premi un tasto per continuare)");
Console.ReadKey();
// 


// CREO una List<string> con dentro degli animali, che per ora sono salvati solo nel programma
Console.WriteLine("Ora creo una lista di stringhe con dentro degli animali, e salvo la lista nel file... (premi un tasto per continuare)");
Console.ReadKey();
// 


List<string> elencoDiAnimali = new List<string> { "cane", "gatto", "topo", "gallina", "mucca" };
File.AppendAllLines(ilNomeCheVuoi, elencoDiAnimali);
// SCRIVO la lista dentro il file "animali della fattoria.txt".
// ho scritto "ilNomeCheVuoi" perché CONTIENE il nome del file "animali della fattoria.txt" !!! (linea 10)

// dopo il dotnet run, si crea un file chiamato "animali della fattoria.txt"
// che continene la lista di animali

// Leggo e salvo quello che c'è nel file "animali della fattoria.txt" e lo scrivo dentro "contenutoDelFile"

// CREO una List<string> con dentro degli animali, che per ora sono salvati solo nel programma
Console.WriteLine("Fatto! Controlla il file... (premi un tasto per continuare)");
Console.ReadKey();
// 

// 
Console.WriteLine("Ora inserisci tu il nome di un animale, così lo scrivo sul file");
Console.Write("> ");
// 
string inserimentoUtente = Console.ReadLine();

// ora aggiungo inserimento NEL FILE "animali della fattoria.txt"
File.AppendAllText(ilNomeCheVuoi, inserimentoUtente);

// CREO una List<string> con dentro degli animali, che per ora sono salvati solo nel programma
Console.WriteLine("Fatto! Controlla il file ;) (premi un tasto per continuare)");
Console.ReadKey();
// 

//
Console.WriteLine("Ora mettiamo che tu non voglia aprire il file per controllare...\nImportiamo il contenuto del file nel programma... (premi un tasto per continuare)");
Console.ReadKey();
// 

string contenutoDelFile = File.ReadAllText(ilNomeCheVuoi);

//
Console.WriteLine("Bene! Ora che ho salvato il contenuto del file lo stampo con Console.WriteLine()\n");

// stampo il contenuto del file:
Console.WriteLine(contenutoDelFile);
Console.WriteLine();