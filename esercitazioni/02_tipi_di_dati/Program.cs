//      I TIPI DI DATI SEMPLICI

// dichiarazione: definizione del tipo di dato, nome variabile, valore
//[tipo di dato] [nome variabile] = [valore];

int eta = 10;               //      NUMERO INTERO
double altezza = 1.70;      //      NUMERO CON LA VIRGOLA
char iniziale = 'F';        //      CARATTERE - Apice singole
string nome = "Felipe";     //      STRINGA - Apice doppie
bool maggiorenne = true;    //      TRUE / FALSE

DateTime dataNascita = new DateTime(2000,1,1);      //      DATE

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










