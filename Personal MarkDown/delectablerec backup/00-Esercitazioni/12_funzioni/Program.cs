// FUNZIONI

// una funzione e un blocco di codice che esegue un compito specifico
// ci sono funzioni che elaborano i dati ma non restituiscono alcun valore
// ci sono funzioni che restituiscono un valore

// una funzione e composta da:
// - nome
// - parametri

// un esempio di funzione che non restituisce alcun valore (void)
// void NomeFunzione(parametri)
// {
//     codice
// }
// blocco di codice esterno alla funzione che la chiama

// esempio di funzione void che stampa un messaggio
void StampaMessaggio()
{
    Console.WriteLine("funzione void");
}
StampaMessaggio(); // utilizzo della funzione

// esempio di funzione void che stampa un messaggio con parametro
void StampaMessaggioConParametro(string messaggio)
{
    Console.WriteLine(messaggio);
}
StampaMessaggioConParametro("funzione void con parametro");// utilizzo della funzione

// esempio di funzione che stampa un messaggio con piu parametri
void StampaMessaggioConPiuParametri(string messaggio1, string messaggio2)
{
    Console.WriteLine($"{messaggio1} {messaggio2}");
}
StampaMessaggioConPiuParametri("funzione void con", "piu parametri");// utilizzo della funzione

// esempio di funzione che restituisce un valore
// una funzione che restituisce un valore deve specificare il tipo di quel valore al posto di void
// poiche prende due interi come parametri e restituisce la loro somma, il tipo di ritorno e int anziche void
int Somma(int a, int b)
{
    return a + b; // restituisce la somma di a e b
}
int risultato = Somma(2, 3); // utilizzo della funzione
Console.WriteLine(risultato); // stampa 5

// esempio di funzione che restituisce una stringa
string Saluta(string nome)
{
    return $"Ciao {nome}!"; // restituisce una stringa con il nome passato come parametro
}
string saluto = Saluta("studente"); // utilizzo della funzione
Console.WriteLine(saluto); // stampa Ciao studente

// esempio di funzione che restituisce un booleano
bool ParolaPari(string parola)
{
    return parola.Length % 2 == 0; // restituisce true se la lunghezza della parola e un intero pari, false altrimenti
}
bool risultatoPari = ParolaPari("cane"); // utilizzo della funzione
Console.WriteLine(risultatoPari); // stampa true

// esempio di funzione che restituisce piu valori
// puo essere void anche se restituisce dei valori perche abbiamo usato i parametri out
// in pratica non c e il return
// una funzione puo restituire piu valori utilizzando i parametri out
void Divisione(int dividendo, int divisore, out int quoziente, out int resto)
{
    quoziente = dividendo / divisore; // calcola il quoziente
    resto = dividendo % divisore; // calcola il resto
    // non posso fare un return di due valori, quindi utilizzo i parametri out
}
int q, r; // dichiaro le variabili che conterranno i valori restituiti dalla funzione
Divisione(10, 3, out q, out r);
Console.WriteLine($"Quoziente: {q}, Resto: {r}"); // stampa Quoziente: 3, Resto: 1

// esempio di funzione che restituisce piu valori con ref
// ref e out sono simili ma con una differenza fondamentale
// ref deve essere inizializzato prima di essere passato alla funzione
// out non deve essere inizializzato prima di essere passato alla funzione
// quindi out e piu flessibile
void DivisioneConRef(int dividendo, int divisore, ref int quoziente, ref int resto)
{
    quoziente = dividendo / divisore; // calcola il quoziente
    resto = dividendo % divisore; // calcola il resto
}
int q1 = 0, r1 = 0; // dichiaro le variabili che conterranno i valori restituiti dalla funzione
DivisioneConRef(10, 3, ref q1, ref r1);
Console.WriteLine($"Quoziente: {q1}, Resto: {r1}"); // stampa Quoziente: 3, Resto: 1

// esempio di funzione che restituisce un array
// in questo caso viene restituito un array contenente i primi n numeri pari
int[] NumeriPari(int n) // n sta per il numero di elementi dell'array
{
    int[] numeriPari = new int[n]; // dichiaro un array di interi di lunghezza n
    for (int i = 0; i < n; i++)
    {
        numeriPari[i] = 2 * i; // assegno ad ogni elemento dell'array il doppio di i in modo da ottenere i numeri pari
    }
    return numeriPari; // restituisco l'array
}
int[] numeri = NumeriPari(50); // utilizzo della funzione
foreach (int numero in numeri)
{
    Console.WriteLine(numero); // stampa 0 2 4 6 8
    // stampo con delay di un secondo
    // System.Threading.Thread.Sleep(300);
}

// esempio di funzione che restituisce un array di stringhe
// in questo caso viene restituito un array contenente le parole di lunghezza pari
string[] ParolePari(string[] parole)
{
    List<string> parolePari = new List<string>(); // dichiaro una lista di stringhe
    foreach (string parola in parole)
    {
        if (parola.Length % 2 == 0) // se la lunghezza della parola e un intero pari
        {
            parolePari.Add(parola); // aggiungo la parola alla lista
        }
    }
    return parolePari.ToArray(); // restituisco la lista convertita in array
}
string[] parole = { "cane", "gatto", "topo", "elefante", "cavallo" }; // dichiaro un array di stringhe
string[] parolePari = ParolePari(parole); // utilizzo della funzione in modo da caricare l'array con le parole di lunghezza pari
foreach (string parola in parolePari)
{
    Console.WriteLine(parola); // stampa cane topo elefante
}

// esempio di funzione che restituisce una lista
// in questo caso viene restituita una lista contenente la versione abbraviata di una serie di nomi
List<string> NomiAbbreviati(List<string> nomi)
{
    List<string> nomiAbbreviati = new List<string>(); // dichiaro una lista di stringhe
    foreach (string nome in nomi)
    {
        string[] parti = nome.Split(' '); // divido il nome in parti separate dallo spazio
        string abbreviato = $"{parti[0]} {parti[1][0]}."; // creo una stringa con il nome abbreviato
        nomiAbbreviati.Add(abbreviato); // aggiungo il nome abbreviato alla lista
    }
    return nomiAbbreviati; // restituisco la lista
}
List<string> nomiCompleti = new List<string> { "Mario Rossi", "Luca Bianchi", "Paolo Verdi" }; // dichiaro una lista di stringhe
List<string> nomiAbbreviati = NomiAbbreviati(nomiCompleti); // utilizzo della funzione in modo da caricare la lista con i nomi abbreviati
foreach (string nome in nomiAbbreviati)
{
    Console.WriteLine(nome); // stampa Mario R. Luca B. Paolo V.
}

// esempio di funzione che restituisce una lista
// in questo caso viene restituita una lista contenente la versione abbraviata di una serie di nomi
// l utente puo specificare quanti caratteri vuole visualizzare
List<string> NomiAbbreviatiConInput(List<string> nomi, int lunghezza)
{
    List<string> nomiAbbreviati = new List<string>(); // dichiaro una lista di stringhe
    foreach (string nome in nomi)
    {
        string[] parti = nome.Split(' '); // divido il nome in parti separate dallo spazio
        string abbreviato = $"{parti[0]} {parti[1].Substring(0, lunghezza)}."; // creo una stringa con il nome abbreviato
        nomiAbbreviati.Add(abbreviato); // aggiungo il nome abbreviato alla lista
    }
    return nomiAbbreviati; // restituisco la lista
}
List<string> nomiCompletiConInput = new List<string> { "Mario Rossi", "Luca Bianchi", "Paolo Verdi" }; // dichiaro una lista di stringhe
List<string> nomiAbbreviatiConInput = NomiAbbreviatiConInput(nomiCompleti, 2); // utilizzo della funzione in modo da caricare la lista con i nomi abbreviati
                                                                               // con un parametro aggiuntivo
foreach (string nome in nomiAbbreviatiConInput)
{
    Console.WriteLine(nome); // stampa Mario Ro. Luca Bi. Paolo Ve.
}

// esempio di funzione che restituisce un dizionario
// in questo caso viene restituito un dizionario contenente i valori che corrispondono ad una chiave specifica
Dictionary<string, int> ValoriSpecifici(Dictionary<string, int> dizionario, List<string> chiavi)
{
    Dictionary<string, int> valori = new Dictionary<string, int>(); // dichiaro un dizionario di stringhe e interi
    foreach (string chiave in chiavi)
    {
        if (dizionario.ContainsKey(chiave)) // se il dizionario contiene la chiave specificata
        {
            valori.Add(chiave, dizionario[chiave]); // aggiungo la chiave e il valore corrispondente al nuovo dizionario
        }
    }
    return valori; // restituisco il dizionario
}
Dictionary<string, int> dizionario = new Dictionary<string, int> { { "uno", 1 }, { "due", 2 }, { "tre", 3 }, { "quattro", 4 } }; // dichiaro un dizionario di stringhe e interi
List<string> chiavi = new List<string> { "uno", "tre", "cinque", "otto" }; // dichiaro una lista di stringhe con le chiavi specifiche che voglio cercare
Dictionary<string, int> valori = ValoriSpecifici(dizionario, chiavi); // utilizzo della funzione in modo da caricare il dizionario con i valori specifici
foreach (KeyValuePair<string, int> coppia in valori)
{
    Console.WriteLine($"{coppia.Key}: {coppia.Value}"); // stampa uno: 1 tre: 3
}

// esempio di funzione che trasmette un valore ad un altra funzione
// in questo caso viene restituito un valore che viene passato ad un altra funzione
int Doppio(int n)
{
    return n * 2; // restituisce il doppio di n
                  // il primo return e il valore che viene passato alla funzione Quadruplo
}
int Quadruplo(int n)
{
    return Doppio(n) * 2; // restituisce il quadruplo di n
                          // utilizza n restituito da Doppio
}
int quadruplo = Quadruplo(5); // utilizzo della funzione
Console.WriteLine(quadruplo); // stampa 20

// esempio di funzione che utilizza ref
// in questo caso viene restituito un valore che viene passato ad un altra funzione utilizzando ref cioe come riferimento
// il vantaggio di ref e che non crea una copia del valore ma passa direttamente il riferimento quindi non consuma memoria
int DoppioConRef(ref int n)
{
    n *= 2; // raddoppia n
    return n; // restituisce il valore di n
}
int n = 5; // dichiaro una variabile intera
int doppioConRef = DoppioConRef(ref n); // utilizzo della funzione
Console.WriteLine(doppioConRef); // stampa 10
Console.WriteLine(n); // stampa 10