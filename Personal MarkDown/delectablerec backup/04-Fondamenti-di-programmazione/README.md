# Fondamenti della programmazione

Obiettivo: 
Familiarizzare con i concetti di base della programmazione

Imparare i concetti di base: prima di iniziare a scrivere codice, è importante acquisire una conoscenza di base dei concetti
fondamentali della programmazione, come le variabili, gli operatori, i cicli e le strutture dati

# TIPI DI DATI

**in c# i tipi di dato sono divisi in due categorie:**

- tipi di dato semplici
- strutture di dati

## i tipi di dato semplici sono:
- numeri interi (byte, short, int, long)
- numeri reali (float, double, decimal)
- caratteri (char)
- stringhe (string)
- booleani (bool)

## i tipi di strutture di dati sono:
- array (T[])
- liste (List<T>)
- dizionari (Dictionary<K, V>)
- pile (Stack<T>)
- code (Queue<T>)
- alberi (Tree<T>)

>Un array è una struttura dati che contiene un insieme di elementi dello stesso tipo.
Gli elementi di un array sono memorizzati in posizioni consecutive di memoria.
Ogni elemento di un array è identificato da un indice che ne indica la posizione.

esempio di dichiarazione di un array di interi:

int[] numeri = new int[10];

>Una lista è una struttura dati che contiene un insieme di elementi dello stesso tipo.
Gli elementi di una lista sono memorizzati in posizioni non consecutive di memoria.

esempio di dichiarazione di una lista di interi:

List<int> numeri = new List<int>();

>Un dizionario è una struttura dati che contiene un insieme di coppie chiave-valore.
Le coppie chiave-valore di un dizionario sono memorizzate in posizioni non consecutive di memoria.

esempio di dichiarazione di un dizionario di interi:

Dictionary<string, int> numeri = new Dictionary<string, int>();

>Una pila è una struttura dati che contiene un insieme di elementi dello stesso tipo.
Gli elementi di una pila sono memorizzati in posizioni consecutive di memoria.
L'accesso agli elementi di una pila avviene secondo il principio LIFO (Last In First Out).

>Una coda è una struttura dati che contiene un insieme di elementi dello stesso tipo.
Gli elementi di una coda sono memorizzati in posizioni consecutive di memoria.
L'accesso agli elementi di una coda avviene secondo il principio FIFO (First In First Out).

>Un albero è una struttura dati che contiene un insieme di elementi dello stesso tipo.
Gli elementi di un albero sono memorizzati in posizioni non consecutive di memoria.
Gli elementi di un albero sono organizzati in modo gerarchico.

## Si può capire la differenza tra pila e coda pensando ad un supermercato.

**CODA**

In un supermercato ci sono più casse che fanno procedere un cliente alla volta.
Quando un cliente arriva al supermercato si mette in coda alla cassa più vicina.
Quando un cliente arriva alla cassa viene servito e poi se ne va.
Quindi il cliente che è arrivato per primo è anche il primo ad essere servito.
Questo è il principio FIFO (First In First Out).

**PILA**

In un supermercato ogni volta che viene effettuato un acquisto viene emesso uno scontrino.
Gli scontrini vengono impilati uno sopra l'altro.
Quando un controllore arriva al supermercato prende l'ultimo scontrino emesso e lo controlla.
Quindi l'ultimo scontrino emesso è anche l'ultimo ad essere controllato.
Questo è il principio LIFO (Last In First Out).

**DIZIONARIO**

In un supermercato ad ogni cliente viene assegnato un numero.
Il numero del cliente è associato al numero della cassa alla quale il cliente deve recarsi.
Quindi il numero del cliente è la chiave e il numero della cassa è il valore.

**ALBERO**

In un supermercato ci sono più reparti.
Ogni reparto contiene più scaffali.
Ogni scaffale contiene più prodotti.
Ogni prodotto ha un codice a barre.
Quindi il supermercato è un albero.

# VARIABILI E COSTANTI

>Sia le variabili che le costanti sono utilizzate per memorizzare dati.
Le variabili e le costanti sono dichiarate utilizzando una parola chiave.
Le variabili e le costanti sono dichiarate utilizzando un nome.
Le variabili e le costanti sono dichiarate utilizzando un tipo di dato.
Le variabili e le costanti sono dichiarate utilizzando un operatore di assegnazione.
Le variabili e le costanti sono dichiarate utilizzando un valore.

Le variabili e le costanti possono essere dichiarate in due modi:

- dichiarazione
- dichiarazione e inizializzazione

è importante scegliere quando utilizzare una variabile e quando utilizzare una costante perchè le variabili e le costanti hanno caratteristiche diverse.

Una variabile può essere modificata durante l'esecuzione del programma.
Una costante non può essere modificata durante l'esecuzione del programma.

Una variabile può essere dichiarata senza inizializzarla.
Una costante deve essere dichiarata e inizializzata.

Una variabile può essere dichiarata e inizializzata in due istruzioni separate.
Una costante deve essere dichiarata e inizializzata in un'unica istruzione.

Inoltre viene allocata una nuova area di memoria per ogni variabile dichiarata.
Invece viene allocata una sola area di memoria per tutte le costanti dichiarate.

**esempio di dichiarazione di una variabile:**

>int numero;

**esempio di dichiarazione e inizializzazione di una variabile:**

>int numero = 10;

**esempio di dichiarazione e inizializzazione di una costante:**

>const int numero = 10;

Le variabili possono essere dichiarate con la parola chiave var.

**esempio di dichiarazione e inizializzazione di una variabile con la parola chiave var:**

>var numero = 10;

La differenza tra la dichiarazione di una variabile con la parola chiave var e la dichiarazione di una variabile con un tipo di dato è che la variabile dichiarata con la parola chiave var può essere inizializzata con un valore di un tipo di dato diverso da quello utilizzato per dichiarare la variabile.
Questo rappresenta un vantaggio in quanto non è necessario conoscere il tipo di dato della variabile.

Lo svantaggio è che non è possibile dichiarare una variabile senza inizializzarla.

**In c# il nome di una variabile o di una costante può essere scritto in due modi:**

- Pascal Case
- Camel Case

PASCAL CASE

Nel Pascal Case la prima lettera di ogni parola è maiuscola.

**esempio di Pascal Case:**

>NumeroIntero

CAMEL CASE

Nel Camel Case la prima lettera di ogni parola è minuscola.

**esempio di Camel Case:**

>numeroIntero

# i valori di default delle variabili quando non vengono inizializzate

**0. Variabile dentro il metodo main**

Le variabili locali in C# non vengono inizializzate automaticamente.

Il compilatore richiede che una variabile locale venga esplicitamente inizializzata prima di essere utilizzata.

Tentare di accedere a una variabile locale non inizializzata genera un errore di compilazione.

```csharp
int numero; // Dichiarata ma non inizializzata
Console.WriteLine(numero); // ERRORE: 'numero' potrebbe non essere inizializzata
```

**1. Variabili di istanza (campi di una classe):**

Se una variabile è un campo di una classe o di una struct, viene automaticamente inizializzata con il valore predefinito del suo tipo.

- Tipi numerici (int, float, double, ecc.): 0 (o 0.0 per i numeri con virgola).
- bool: false.
- char: '\0' (carattere nullo).
- string e tipi di riferimento: null.

**Esempio:**

```csharp
class MyClass
{
    int numero;         // Inizializzato automaticamente a 0
    bool flag;          // Inizializzato automaticamente a false
    string testo;       // Inizializzato automaticamente a null
}
```

**2. Variabili locali (dentro un metodo):**

Le variabili locali non sono inizializzate automaticamente, e il compilatore C# richiede che vengano inizializzate prima dell'uso.
Tentare di accedere a una variabile locale non inizializzata genera un errore di compilazione.

**Esempio:**

```csharp
void Metodo()
{
    int numero;
    Console.WriteLine(numero); // ERRORE: 'numero' potrebbe non essere inizializzata
}
```

**Array e collezioni:**

Quando si crea un array, i suoi elementi vengono inizializzati automaticamente al valore predefinito del tipo degli elementi.

Esempio:

```csharp
int[] numeri = new int[5]; // Ogni elemento è inizializzato a 0
bool[] flags = new bool[3]; // Ogni elemento è inizializzato a false
string[] nomi = new string[2]; // Ogni elemento è inizializzato a null
```

**4. Variabili statiche:**

Le variabili statiche (di una classe) seguono le stesse regole dei campi di istanza: vengono inizializzate automaticamente al valore predefinito del loro tipo.

Esempio:

```csharp
static class MyClass
{
    static int numero; // Inizializzato automaticamente a 0
}
```

# GLI OPERATORI

Gli operatori sono utilizzati per eseguire operazioni su uno o più operandi.

**Gli operatori possono essere:**

- operatori aritmetici
- operatori di confronto
- operatori logici
- operatori di assegnazione

## OPERATORI ARITMETICI

Gli operatori aritmetici sono utilizzati per eseguire operazioni aritmetiche.

Gli operatori aritmetici possono essere:

- addizione (+)
- sottrazione (-)
- moltiplicazione (*)
- divisione (/)
- modulo (%)

**esempio di utilizzo degli operatori aritmetici:**

int numero1 = 10;
int numero2 = 20;

int somma = numero1 + numero2;
int differenza = numero1 - numero2;
int prodotto = numero1 * numero2;
int quoziente = numero1 / numero2;
int resto = numero1 % numero2;

## OPERATORI DI CONFRONTO

Gli operatori di confronto sono utilizzati per confrontare due operandi.

**Gli operatori di confronto possono essere:**

- uguaglianza (==)
- disuguaglianza (!=)
- maggiore (>)
- minore (<)
- maggiore o uguale (>=)
- minore o uguale (<=)

esempio di utilizzo degli operatori di confronto:

int numero1 = 10;
int numero2 = 20;

```c#
bool uguaglianza = numero1 == numero2;
bool disuguaglianza = numero1 != numero2;
bool maggiore = numero1 > numero2;
bool minore = numero1 < numero2;
bool maggioreOuguale = numero1 >= numero2;
bool minoreOuguale = numero1 <= numero2;
```
## OPERATORI LOGICI

Gli operatori logici sono utilizzati per eseguire operazioni logiche.

**Gli operatori logici possono essere:**

- and (&&)
- or (||)
- not (!)

esempio di utilizzo degli operatori logici:

bool and = true && false;
bool or = true || false;
bool not = !true;

## OPERATORI DI ASSEGNAZIONE

Gli operatori di assegnazione sono utilizzati per assegnare un valore ad una variabile.

**Gli operatori di assegnazione possono essere:**

- assegnazione (=)
- assegnazione con addizione (+=)
- assegnazione con sottrazione (-=)
- assegnazione con moltiplicazione (*=)
- assegnazione con divisione (/=)
- assegnazione con modulo (%=)

esempio di utilizzo degli operatori di assegnazione:

int numero = 10;

numero += 10;
numero -= 10;
numero *= 10;
numero /= 10;
numero %= 10;

## OPERATORI DI INCREMENTO E DECREMENTO

Gli operatori di incremento e decremento sono utilizzati per incrementare o decrementare il valore di una variabile.

**Gli operatori di incremento e decremento possono essere:**

- incremento (++)
- decremento (--)

esempio di utilizzo degli operatori di incremento e decremento:

int numero = 10;

numero++;
numero--;

## OPERATORI DI CONCATENAZIONE

Gli operatori di concatenazione sono utilizzati per concatenare due stringhe.

**Gli operatori di concatenazione possono essere:**

- concatenazione (+)

esempio di utilizzo degli operatori di concatenazione:

string stringa1 = "ciao";
string stringa2 = "mondo";

string concatenazione = stringa1 + stringa2;

è anche possibile concatenare una stringa con un numero.

esempio di utilizzo degli operatori di concatenazione:

string stringa = "ciao";
int numero = 10;

string concatenazione = stringa + numero;

Si può concatenare una stringa con un numero perchè il numero viene convertito in una stringa.

è inoltre possibile concatenare due variabili  utilizzando il segno ? dopo la prima variabile.

esempio di utilizzo degli operatori di concatenazione:

string stringa1 = "ciao";
string stringa2 = "mondo";

string concatenazione = stringa1 ? stringa2;

# LE CONDIZIONI

Le condizioni sono utilizzate per eseguire un blocco di codice solo se una condizione è vera.

**Le condizioni possono essere:**

- if
- if-else
- if-else if-else
- switch

## IF

L'istruzione if è utilizzata per eseguire un blocco di codice solo se una condizione è vera.

**esempio di utilizzo dell'istruzione if:**
```c#
int numero = 10;

if (numero == 10)
{
    Console.WriteLine("Il numero è 10");
}
```
## IF-ELSE

L'istruzione if-else è utilizzata per eseguire un blocco di codice se una condizione è vera e un altro blocco di codice se una condizione è falsa.

**esempio di utilizzo dell'istruzione if-else:**
```c#
int numero = 10;

if (numero == 10)
{
    Console.WriteLine("Il numero è 10");
}
else
{
    Console.WriteLine("Il numero non è 10");
}
```
## IF-ELSE IF-ELSE

L'istruzione if-else if-else è utilizzata per eseguire un blocco di codice se una condizione è vera, un altro blocco di codice se un'altra condizione è vera e un altro blocco di codice se nessuna condizione è vera.

esempio di utilizzo dell'istruzione if-else if-else:
```c#
int numero = 10;

if (numero == 10)
{
    Console.WriteLine("Il numero è 10");
}
else if (numero == 20)
{
    Console.WriteLine("Il numero è 20");
}
else
{
    Console.WriteLine("Il numero non è 10 e non è 20");
}
```
## SWITCH

L'istruzione switch è utilizzata per eseguire un blocco di codice in base al valore di una variabile.

**esempio di utilizzo dell'istruzione switch:**
```c#
int numero = 10;

switch (numero)
{
    case 10:
        Console.WriteLine("Il numero è 10");
        break;
    case 20:
        Console.WriteLine("Il numero è 20");
        break;
    default:
        Console.WriteLine("Il numero non è 10 e non è 20");
        break;
}
```

# I CICLI DI ITERAZIONE

I cicli di iterazione sono utilizzati per eseguire un blocco di codice più volte.

**I cicli di iterazione possono essere:**

- while
- do-while
- for
- foreach

# WHILE

Il ciclo while è utilizzato per eseguire un blocco di codice finchè una condizione è vera.

esempio di utilizzo del ciclo while:
```c#
int numero = 10;

while (numero > 0)
{
    Console.WriteLine(numero);
    numero--;
}
```
## DO-WHILE

Il ciclo do-while è utilizzato per eseguire un blocco di codice finchè una condizione è vera.

esempio di utilizzo del ciclo do-while:
```c#
int numero = 10;

do
{
    Console.WriteLine(numero);
    numero--;
}
while (numero > 0);
```
## FOR

Il ciclo for è utilizzato per eseguire un blocco di codice un numero di volte noto.

**esempio di utilizzo del ciclo for:**
```c#
for (int numero = 10; numero > 0; numero--)
{
    Console.WriteLine(numero);
}
```
## FOREACH

Il ciclo foreach è utilizzato per eseguire un blocco di codice per ogni elemento di una struttura dati.

**esempio di utilizzo del ciclo foreach:**
```c#
string scritta = "ciao";
foreach (char lettera in scritta)
{
    Console.WriteLine(lettera);
}
```