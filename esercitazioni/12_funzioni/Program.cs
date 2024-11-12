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
