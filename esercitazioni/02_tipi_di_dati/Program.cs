//      I TIPI DI DATI SEMPLICI

// dichiarazione: definizione del tipo di dato, nome variabile, valore
//[tipo di dato] [nome variabile] = [valore];

int eta = 10;               //      NUMERO INTERO
double altezza = 1.70;      //      NUMERO CON LA VIRGOLA
char iniziale = 'F';        //      CARATTERE - Apice singole
string nome = "Felipe";     //      STRINGA - Apice doppie
bool maggiorenne = true;    //      TRUE / FALSE

DateTime dataNascita = new DateTime(2000,1,1);      //      DATE

var cognome = "Rossi";
//> var è una parola chiave che deduce il tipo di dato senza senza specificare il tipo
//> ma dev'essere dichiarata e inizializzata nello stesso momento

dynamic altezza2 = 1.70;
//> variabili di tipo dynamic
//> parola chiave che permette di dichiarare una variabili il cui tipo viene determinato a runtime
//> determinato in runtime. questo dato può cambiare durante l'esecuzione del programma

//! DIFFERENZE var / dynamic
//* var determina il tipo a compile time    (la variabile non può cambiare tipo e dev'essere inizializzata al momento della dichiarazione)
//* dybamic determina il tipo a runtime     (la variabile può cambiare tipo)



// Utilizzo variabile attraverso metodo di console e interpolazione:
Console.WriteLine($"Il valore di nome è {nome}");
Console.WriteLine($"Il valore di altezza è {altezza}");
Console.WriteLine($"Il valore di iniziale è {iniziale}");
Console.WriteLine($"Il valore di maggiorenne è {maggiorenne}");
Console.WriteLine($"Il valore di maggiorenne è {dataNascita}");

//  Ricevo INPUT da utente:

Console.WriteLine("Inserisci nome utente: ");
string nomeUtente = Console.ReadLine();     // il valore della variabile viene dall'inserimento


Console.WriteLine($"Il nome utente scelto è: {nomeUtente}");


/****************************************************************/

//      TIPI DI DATI COMPLESSI (o strutture di dati):
//      Sono un insieme di dati dello stesso tipo

/****************************************************************/

// ARRAY - quando il numero di valori è conosciuto
// SINTASSI: tipo[] nome variabile = new tipo[numero elementi]

int[] numeri = new int[5];  // 

// nota: "new" è un COSTRUTTORE, una parola chiave per creare un nuovo oggetto

//inizializzazione
numeri[0] = 10;
numeri[1] = 20;
numeri[2] = 30;
numeri[3] = 40;
numeri[4] = 50;

// inizializzazione alternativa
int[] numeri2 = new int[]{10, 20, 30, 40, 50};

/****************************************************************/

// LISTA - quando la lunghezza della lista è variabile, 
// SINTASSI: List<tipo> nome variabile = new List<tipo>();
List<int> numeri3 = new List<int>();

//inizializzazione -->  inserisco il valore nella lista usando il metodo .Add
numeri3.Add(10);
numeri3.Add(20);
numeri3.Add(30);
numeri3.Add(40);
numeri3.Add(50);

//inizializzazione alternativa

List<int> numero4 = new List<int> {10,20,30,40,50};                         //  Lista di interi
List<string> compagni = new List<string> {"Sofia", "Felipe", "Giorgio"};    //  Lista stringhe

/****************************************************************/

//  DIZIONARIO - Crea corrispondenza tra due tipi di dati <key, value>

// SINTASSI: Dictionary<tipo1, tipo2> nomeVariabile = new Dictionary<tipo1, tipo2>();
Dictionary<string, int> catalogo = new Dictionary<string, int>();


/****************************************************************/
//  METODI DI STRINGA

//Length
//restituisce la lunghezza
string nome2 = "abcd";
Console.WriteLine($"lunghezza codice fiscale {nome2.Length}"); // output 4

//isNullOrWhiteSpace
//restituisce booleano se c'è o meno un valore null o uno spazio vuoto
string nome3 = "Nome1";
Console.WriteLine(string.IsNullOrWhiteSpace(nome3)); // output: false

//ToLower
//restituisce stringa in minuscolo
string nome4 = "Nome1";
Console.WriteLine(nome4.ToLower());     // out: nome1

//ToUpper
//restituisce stringa in maiuscolo
string nome5 = "Nome1";
Console.WriteLine(nome5.ToUpper());     // output: NOME1

//Trim
string nome6 = "Nome1 ";
Console.WriteLine(nome6.Trim());        // output: Nome1
// rimuove gli spazi bianchi all'inizio e alla fine di una stringa

//Split
string nome7 = "Nome1,Nome2,Nome3";
string[] nomi3 = nome7.Split(',');
foreach (string oggetto in nomi3)
{
    Console.WriteLine(oggetto);
}
// output:
// Nome1
// Nome2
// Nome3

// replace
// sostituisce una sottostringa con un altra sotostringa
string nome8 = "Nome1";
Console.WriteLine(nome8.Replace("Nome1","Nome2"));

// SubString
// restituisce una sottostringa
string nome9="Nome1";
Console.WriteLine(nome9.Substring(0,3)); //output: Nom
// parte dallo 0 e lo fa per 3 caratteri

// Contains
// Verifica se una string continuene una sottostringa
string nome10 = "Nome1";
Console.WriteLine(nome9.Contains("Nom")); // output: true

// IndexOf
// restituisce l'indice della prima occorrenza di una sottostringa
// se lo trova restituisce 0
// se non trova la sottostringa restituisce -1
//?  se trova più occorrenze restituisce l'indice della prima occorrenza (per ora prendila per buona)
string nome11 = "Nome1";
Console.WriteLine(nome10.IndexOf("Nome1")); //output: 0

// LastIndexOf
// restituisce l'indice dell'ltima occorrenza di una stringa
// se non trova la sottostringa -1
// parte dalla fine della stringa
string nome12 = "Nome1";
Console.WriteLine(nome12.LastIndexOf("o")); // output 3
// in questo caso la "o" si trova in posizione 3 partendo dalla fine della stringa

// StartWith
string nome13 = "Nome1";
Console.WriteLine(nome13.StartsWith("N")); // output: true

// EndWith
string nome14 = "Nome1";
Console.WriteLine(nome14.EndsWith("1"));

// ToString
// converte un tipo di dato in stringa
// dovrebbe funzionare con int, double, char ecc...
int eta3 = 10;
Console.WriteLine(eta3.ToString());

// Parse
// converte una stringa in un tipo di dato
//! se la convertsione non va a buon fine termina il programma con un errore
string eta4 = "10";
Console.WriteLine(int.Parse(eta4));

// tryparse
// converte una stringa in un tipo di dato e restituisce un valore booleano che indica la conversione riuscita
// se la conversione è riuscita il valore viene salvata nella variabile di riferimento
// se la conversione non è riuscita il valore convertito è 0

string eta5 = "10";
int eta6;
if (int.TryParse(eta5, out eta6))
{
    Console.WriteLine(eta6);
}
else
{
    Console.WriteLine("Conversione non riuscita");
}

// Convert
// converte un tipo di dato in un altro tipo di dato
// se la conversione non è riuscita viene generata un'ecezzione di tipo InvalidCastException ed il programma si blocca
string eta7 = "10";
Console.Write(Convert.ToInt32(eta7));

// concatenazione con string.format
string nome15 = "Nome1";
string cognome1 = "Rossi";
Console.WriteLine(string.Format ("{0} {1}", nome15, cognome1));

// conversione implicita
// possibile da int a double, non da double a int
int eta8 = 10;
double altezza3 = eta8;

// conversione esplicita (cast)
double altezza4 = 1.70;
int eta9 = (int)altezza4;

// posso stampare il tipo della variabile con GetType()
Console.WriteLine($"tipo della var è: {eta8.GetType()}");
Console.WriteLine($"tipo della var è: {altezza.GetType()}");

/****************************************************************/


// ALTRI TIPI DI DATI COMPLESSI: CODE, PILE, ALBERI

// CODA: (First in, First Out) Struttura di dati simile ad ARRAY/LISTA, ordina i dati nell'ordine di inserimento
// PILE: (Last In, First Out)
// ALBERO: Struttura di dati a diramazioni

/****************************************************************/


// BEST PRACTICES: Come dichiarare le variabili

// DICHIARARE LE VARIABILI IN MODO SPECIFICO 
// DICHIARARE LE VARIABILI CON LA NOTAZIONE CamelCase o PascalCase
// ESEMPIO CamelCase:    etaStudente
// ESEMPIO PascalCase:   EtaStudente










