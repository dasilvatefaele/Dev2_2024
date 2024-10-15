//  questo è un commento

/*  questo è un commento
    a linea multipla    */

//  Il metodo Console.Writeline(); stampa il video a testo
Console.WriteLine("Ciao! Come ti chiami?"); 

//  il metodo Console.ReadLine(); legge testo dalla tastiera
string? nome = Console.ReadLine();

//  stampo stringhe concatenate (principiante)
Console.WriteLine("Ciao " + nome + " !"); 

//  stampo stringhe concatenate con interpolazione usando il $ prima delle "
Console.WriteLine($"{nome} è proprio un bel nome!"); // interpolazione
Console.WriteLine("Ed il tuo cognome?"); 
string? cognome = Console.ReadLine();
Console.WriteLine($"Allora ciao {nome} {cognome}!"); // interpolazione

//  metodo variabile.ToUpper(); restituisce la stringa in maiuscolo
Console.WriteLine($"Diciamolo più forte: {nome.ToUpper()} {cognome.ToUpper()}");

//  chiedo all'utente l'età in stringa
Console.WriteLine("Quanti anni hai?");
string eta = Console.ReadLine(); 
Console.WriteLine($"Ah! Hai {eta} anni!");
Console.WriteLine($"Ricapitoliamo: ti chiami {nome} {cognome} ed hai {eta} anni...");

//  dichiaro una variabile int di nome etaInt
int etaInt = 12; // ho inizializzato la variabile con un valore
string etaStr = etaInt.ToString(); // conversione int to string

Console.WriteLine($"Sono già {etaStr} che sei nel mondo del lavoro!");

/*  
    i metodi di console gestiscono input-output (dialogo con l'utente)
    attraverso la console:

    Console.ReadLine();   -     ACQUISISCE SOLO STRINGHE
    Console.WriteLine();

    il metodo ToUpper() trasforma la stringa in maiuscolo
    il metodo ToLower() trasforma la stringa in minuscolo

    Ho provato a stampare la variabile int in una stringa ma mi ha dato errore
    Dopo la conversione da int a stringa è stato possibile stamparlo in Console

    Ho acquisito la variabile in stringa
    Ho convertito la variabile in int 

*/







