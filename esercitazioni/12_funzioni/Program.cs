/*=========================================================
                        FUNZIONI
=========================================================*/
/*
    Un blocco di codice che esegue un compito specifico.
    Ci sono funzioni che elaborano i dati senza restituire
    risultati (void) e ci sono funzioni che restituiscono
    un valore (int, bool, double, etc.)

    Una funzione è composta da 
    - nome
    - parametri

    un esempio di funzione che non restituisce alcun valore (void)
    ! Sintassi:

    void NomeFunzione (parametri)
    {
        codice
    }

    Le funzioni hanno anche dei modificatori di accesso come 
    "public" e "private"

    - public: chiamabile da qualsiasi parte del programma
    - private: chiamabile solo all'interno del codice della classe in cui è definita

    quindi una funzione completa di modificatore di accesso potrebbe essere così:

    public void NomeFunzione (parametri)
    {
        codice
    }

    Blocco di codice esterno alla funzione che la chiama
*/

Console.Clear();

//* Esempio di una funzione void che stampa un messaggio
void StampaMessaggio()
{
    Console.WriteLine("Funzione void");
}
StampaMessaggio(); //* Utilizzo della funzione


//* Esempio di una funzione void che stampa un messaggio con parametri
void StampaMessaggioConParametro (string messaggio)
{
    Console.WriteLine(messaggio);
}
StampaMessaggioConParametro("Funzione void con parametro"); //* utilizzo della funzione


//* Esempio di funzione con più parametri che stampa un messaggio
void StampaMessaggioConPiuParametri (string messaggio1, string messaggio2)
{
    Console.WriteLine($"{messaggio1} {messaggio2}");
}
StampaMessaggioConPiuParametri("funzione void con", "più parametri"); // * utilizzo della funzione


//* Esempio di funzione che restituisce un valore
//* una funzione che restituisce un valore deve specificare il tipo di quel valore al posto di void
//* poiché prende due interi come parametri e restituisce la loro somma il tipo di ritorno è int anziché void
int Somma(int a, int b)
{
    return a + b;
}
int risultato = Somma(2,3);     //* utilizzo della funzione
Console.WriteLine(risultato);   //* stampa 5


//* esempio di funzione che restituisce una stringa
string Saluta (string nome)
{
    return $"Ciao {nome}!";
}
string saluto = Saluta("Felipe");    //* utilizzo funzione
Console.WriteLine(saluto);           //* stampa Ciao Felipe!


//* esempio di funzione che restituisce un booleano
bool EParolaPari (string parola)
{
    return parola.Length % 2 == 0; // restituisce true se la lunghezza della parola è pari, altrimenti false
}
bool risultatoPari = EParolaPari("cane"); //* utilizzo della funzione 
Console.WriteLine(risultatoPari); //* stampa true

//* esempio di funzione che restituisce più valori
//* può essere void anche se restituisce dei valori perché abbiamo usato i parametri di out
//* in pratica non c'è il return
//* una funzione può restituire più valori utilizzando i parametri out
void Divisione (int dividendo, int divisore, out int quoziente, out int resto)
{
    quoziente = dividendo / divisore;
    resto = dividendo % divisore;
}

int quoziente, resto;
Divisione (10, 3, out quoziente, out resto);
Console.WriteLine ($"Quoziente {quoziente}, Resto {resto}");

int[] NumeriPari (int n)
{
    int[] numeriPari = new int[n];
    for (int i = 0; i < n; i++)
    {
        numeriPari[i] = 2 * i;
    }
    return numeriPari;
}
int[] numeri = NumeriPari(50);
foreach (int numero in numeri)
{
    Console.WriteLine (numero);
    // System.Threading.Thread.Sleep (300); // delay in millisecondi
}


//* esempio di funzioni che restituisce un array di stringhe
string[] ParolePari (string [] parole)
{
    List<string> parolePari = new List<string>();
    
    foreach (string parola in parole)
    {
        if (parola.Length % 2 == 0)
        {
            parolePari.Add(parola);
        }
    }
    
    return parolePari.ToArray();
}

string[] parole = {"cane", "gatto", "topo", "elefante", "cavallo"};
string[] parolePari = ParolePari(parole);

foreach (string parola in parolePari)
{
    Console.WriteLine(parola);
}

Console.WriteLine();
Console.WriteLine("Nomi abbreviati:");
//* Esempio di funzione che restituisce una lista
List<string> NomiAbbreviati(List<string> nomi)
{
    List<string> nomiAbbreviati = new List<string>();
    foreach(string nome in nomi)
    {
        string[] parti = nome.Split(' '); 
        //* metodo .Split, splitta la stringa nel punto dell'argomento, argomento escluso
        string abbreviato = $"{parti[0]} {parti[1][0]}."; 
        // creo una stringa col nome abbreviato
        //* parti[index = 0] rappresenta la prima parola, parti[index = 1] rappresenta la seconda parola
        //* parti [index = 1][index = 0] rappresenta la prima lettera della seconda parola.
        nomiAbbreviati.Add(abbreviato); // aggiungoil nome abbreviato alla lista
    }
    return nomiAbbreviati;
}
List<string> nomiCompleti = new List<string>{"Mario Rossi","Luca Bianchi", "Paolo Verdi"};
List<string> nomiAbbreviati = NomiAbbreviati(nomiCompleti);
foreach (string nome in nomiAbbreviati)
{
    Console.WriteLine(nome);
}

Console.WriteLine();
Console.WriteLine("Nomi abbreviati con input:");
//* Esempio di funzione che restituisce una lista
List<string> NomiAbbreviatiConInput(List<string> nomi, int lunghezza)
{
    List<string> nomiAbbreviati = new List<string>();
    foreach(string nome in nomi)
    {
        string[] parti = nome.Split(' '); 
        //* metodo .Split, splitta la stringa nel punto dell'argomento, argomento escluso
        string abbreviato = $"{parti[0]} {parti[1].Substring(0,lunghezza)}."; 
        //* metodo .Substring(START_INDEX, LUNGHEZZA) restituisce Numero_LUNGHEZZA della stringa
        // creo una stringa col nome abbreviato
        //* parti[index = 0] rappresenta la prima parola, parti[index = 1] rappresenta la seconda parola
        //* parti [index = 1][index = 0] rappresenta la prima lettera della seconda parola.
        nomiAbbreviati.Add(abbreviato); // aggiungoil nome abbreviato alla lista
    }
    return nomiAbbreviati;
}
List<string> nomiCompletiConInput = new List<string>{"Mario Rossi","Luca Bianchi", "Paolo Verdi"};
List<string> nomiAbbreviatiConInput = NomiAbbreviatiConInput(nomiCompletiConInput, 2);
foreach (string nome in nomiAbbreviatiConInput)
{
    Console.WriteLine(nome);
}

Console.WriteLine();
Console.WriteLine("Funzione che restituisce un dizionario:");
//* esempio di una funzione che restituisce un dizionario
//* in questo caso viene restituito un dizionario contenente i valori che corrispondono ad una chiave specifica
Dictionary<string,int> ValoriSpecifici (Dictionary<string,int> dizionario, List<string> chiavi)
{
    
    Dictionary<string,int> valori = new Dictionary<string,int>();
    foreach (string chiave in chiavi)
    {    
        if (dizionario.ContainsKey(chiave)) // se il dizionario contiene la chiave specifica
        {
            valori.Add(chiave, dizionario[chiave]); 
            // aggiungo la chiave e il valore corrispondente al nuovo dizionario
        }
    }
    return valori;
}
Dictionary<string,int> dizionario = new Dictionary<string,int>{{"uno", 1}, {"due", 2}, {"tre", 3}, {"quattro", 4}};
List<string> chiavi = new List<string> {"uno", "tre", "cinque", "otto"};
Dictionary<string,int> valori = ValoriSpecifici(dizionario,chiavi);
foreach(KeyValuePair<string,int> coppia in valori)
{
    Console.WriteLine($"{coppia.Key}: {coppia.Value}");
}

//* esempio di funzione che trasmette un valore ad unaltra funzione
int Doppio (int n)
{
    return n*2; // arriva qui esegue n*2, e ritorna il risultato a Quadruplo (*C)
}

int Quadruplo (int n)
{
    return Doppio(n) *2; 
    // arriva qui (*B) chiama la funzione Doppio(int)
    // riceve return da Doppio(int), esegue Doppio(int)*2 e restituisce alla chiamata (*D)
}

int quadruplo = Quadruplo(5); // chiamo la funzione qui (*A) - assegna return finale a variabile (*E)
Console.WriteLine(quadruplo);