
// METODI DI STRINGA
// i tipi di dato stringa hanno dei metodi che permettono di eseguire delle operazioni su di essi o di ottenere informazioni su di essi

// lenght
// prende la lunghezza di una stringa
string nome2 = "Nome1";
Console.WriteLine(nome2.Length); // output: 5

// isnullorwhitespace
// verifica se una stringa e nulla o vuota
string nome3 = "Nome1";
Console.WriteLine(string.IsNullOrWhiteSpace(nome3)); // output: False

// tolower
// converte una stringa in minuscolo
string nome4 = "Nome1";
Console.WriteLine(nome4.ToLower()); // output: nome1

// toupper
// converte una stringa in maiuscolo
string nome5 = "Nome1";
Console.WriteLine(nome5.ToUpper()); // output: NOME1

// trim
// rimuove gli spazi bianchi all inizio e alla fine di una stringa
string nome6 = " Nome1 ";
Console.WriteLine(nome6.Trim()); // output: Nome1

// split
// divide una stringa in base a un separatore
string nomi2 = "Nome1,Nome2,Nome3";
string[] nomi3 = nomi2.Split(',');
foreach (string nome in nomi3)
{
    Console.WriteLine(nome);
}
// output:
// Nome1
// Nome2
// Nome3

// replace
// sostituisce una sottostringa con un altra sottostringa
string nome7 = "Nome1";
Console.WriteLine(nome7.Replace("Nome1", "Nome2")); // output: Nome2

// substring
// restituisce una sottostringa usando un indice iniziale e una lunghezza
string nome8 = "Nome1";
Console.WriteLine(nome8.Substring(0, 3)); // output: Nom

// contains
// verifica se una stringa contiene una sottostringa
string nome9 = "Nome1";
Console.WriteLine(nome9.Contains("Nom")); // output: True

// indexof
// restituisce l indice della prima occorrenza di una sottostringa
// se non trova la sottostringa restituisce -1
// se trova piu occorrenze restituisce l indice della prima occorrenza
string nome10 = "Nome1";
Console.WriteLine(nome10.IndexOf("Nome1")); // output: 0

// lastindexof
// restituisce l indice dell ultima occorrenza di una sottostringa
// se non trova la sottostringa restituisce -1
// parte dalla fine della stringa in questo caso la "o" si trova in posizione 3
string nome11 = "Nome1";
Console.WriteLine(nome11.LastIndexOf("o")); // output: 3

// startswith
// verifica se una stringa inizia con una sottostringa
string nome12 = "Nome1";
Console.WriteLine(nome12.StartsWith("N")); // output: True

// endswith
// verifica se una stringa finisce con una sottostringa
string nome13 = "Nome1";
Console.WriteLine(nome13.EndsWith("1")); // output: True

// tostring
// converte un tipo di dato in una stringa
// funziona con int double char ed altri tipi di dato
int eta3 = 10;
Console.WriteLine(eta3.ToString()); // output: 10

// parse
// converte una stringa in un tipo di dato
// se la conversione non e riuscita viene generata un eccezione di tipo FormatException ed il programma si blocca
string eta4 = "10";
Console.WriteLine(int.Parse(eta4)); // output: 10

// tryparse
// converte una stringa in un tipo di dato e restituisce un valore booleano che indica se la conversione e riuscita
// se la conversione e riuscita il valore convertito viene salvato in una variabile passata per riferimento
// se la conversione non e riuscita il valore convertito e 0
string eta5 = "10";
int eta6;
if (int.TryParse(eta5, out eta6))
{
    Console.WriteLine(eta6); // output: 10
}
else
{
    Console.WriteLine("Conversione non riuscita");
}

// convert
// converte un tipo di dato in un altro tipo di dato
// se la conversione non e riuscita viene generata un eccezione di tipo InvalidCastException ed il programma si blocca
string eta7 = "10";
Console.WriteLine(Convert.ToInt32(eta7)); // output: 10

// concatenazione di stringhe
string nome14 = "Nome1";
string cognome2 = "Rossi";
Console.WriteLine(nome14 + " " + cognome2); // output: Nome1 Rossi

// concatenazione con interpolazione
string nome15 = "Nome1";
string cognome3 = "Rossi";
Console.WriteLine($"{nome15} {cognome3}"); // output: Nome1 Rossi

// concatenazione con string.format
string nome16 = "Nome1";
string cognome4 = "Rossi";
Console.WriteLine(string.Format("{0} {1}", nome16, cognome4)); // output: Nome1 Rossi

// METODI DI CONVERSIONE
// convertire un tipo di dato in un altro tipo di dato

// conversione implicita
// la conversione implicita e possibile solo se non c e perdita di dati ad esempio da int a double ma non da double a int
int eta8 = 10;
double altezza3 = eta8; // conversione implicita da int a double

// conversione esplicita (cast)
double altezza4 = 1.70;
int eta9 = (int)altezza4; // conversione esplicita da double a int

// conversione con metodi
int eta10 = 10;
string eta11 = eta10.ToString(); // conversione da int a stringa

// posso stampare il tipo della variabile con GetType()
Console.WriteLine($"Il tipo della variabile eta e {eta10.GetType()}"); // output: Il tipo della variabile eta e System.Int32
Console.WriteLine($"Il tipo della variabile eta e {eta11.GetType()}"); // output: Il tipo della variabile eta e System.String