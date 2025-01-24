// questo e un commento a riga singola

/*
questo e un commento a riga multipla
*/

/*
i metodi di console permettono di gestire l output o l input (il dialogo con l utente) attraverso la console
WriteLine() stampa a video una stringa
ReadLine() legge una stringa da tastiera
ReadKey() legge un tasto premuto da tastiera

*/

// il metodo Console.Writeline stampa a video il testo passato come argomento
Console.WriteLine("Hello World!");

// il metodo Console.ReadLine legge una riga di testo da tastiera
string nome = Console.ReadLine(); // legge una riga di testo da tastiera e la assegna alla variabile nome

// stampo il nome concatenato con una stringa
Console.WriteLine("Ciao " + nome + "!"); // con il segno + posso concatenare stringhe con variabili

// stampo il nome concatenato con una stringa utilizzando l interpolazione
Console.WriteLine($"Ciao {nome}!"); // con l'interpolazione posso concatenare stringhe con variabili

// chiedo all utente di inserire il proprio nome
Console.WriteLine("Inserisci il tuo cognome:");
// leggo il cognome da tastiera e lo assegno alla variabile cognome
string cognome = Console.ReadLine();
// stampo il cognome
Console.WriteLine($"Ciao {nome} {cognome}!"); // con l'interpolazione posso concatenare piu variabili in modo semplificato

// dichiaro una variabile intera etaInt
int etaInt = 47; // inizializzo la variabile etaInt con il valore 47

// dichiaro una variabile stringa etaStr
string etaStr = etaInt.ToString();

// concateno etaInt con una stringa
Console.WriteLine($"Hai {etaInt} anni");

// leggo l input dell utente con ReadKey();
Console.ReadKey(); // legge un tasto premuto da tastiera

// se il tasto premuto e uguale a Enter
if (Console.ReadKey().Key == ConsoleKey.Enter)
{
    // stampo un messaggio
    Console.WriteLine("Hai premuto il tasto Enter");
}

// se il tasto premuto e uguale a s esco dal programma
if (Console.ReadKey().Key == ConsoleKey.S)
{
    // stampo un messaggio
    Console.WriteLine("Hai premuto il tasto S");
    // esco dal programma
    return;
}