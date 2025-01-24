// chiedi all utente di inserire due numeri
double num1 = ChiediNumero();
double num2 = ChiediNumero();

// chiedi all utente di selezionare un operatore matematico
char operatore = ChiediOperatore();

// esegui l operazione selezionata
double risultato = EseguiOperazione(num1, num2, operatore);

// visualizza il risultato
Console.WriteLine($"Il risultato è: {risultato}");

double ChiediNumero()
{
    double num = 0; // dichiarazione e inizializzazione di una variabile che conterra il numero inserito dall utente
    bool inputValido = false; // dichiarazione e inizializzazione di una variabile booleana che controlla se l input e valido
    while (!inputValido)
    {
        try
        {
            Console.Write("Inserisci un numero: "); // richiesta di inserimento di un numero all utente
            num = Convert.ToDouble(Console.ReadLine()); // acquisizione del numero inserito dall utente
            inputValido = true; // se l input e valido, il ciclo termina
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserisci un numero valido."); // messaggio di errore se l utente inserisce un valore non numerico
        }
    }
    return num; // restituzione del numero inserito dall utente alla funzione chiamante (nel caso specifico, al main)
}

char ChiediOperatore()
{
    char operatore = ' '; // dichiarazione e inizializzazione di una variabile che conterra l operatore inserito dall utente
    bool inputValido = false; // dichiarazione e inizializzazione di una variabile booleana che controlla se l input e valido
    while (!inputValido) // ciclo che continua finche l input non e valido
    {
        Console.Write("Seleziona un operatore (+, -, *, /): "); // richiesta di selezione di un operatore all utente
        operatore = Console.ReadKey().KeyChar; // acquisizione dell operatore inserito dall utente
        Console.WriteLine(); // andare a capo
        if (operatore == '+' || operatore == '-' || operatore == '*' || operatore == '/') // controllo se l operatore e valido
        {
            inputValido = true; // se l input e valido, il ciclo termina
        }
        else
        {
            Console.WriteLine("Operatore non valido."); // messaggio di errore se l utente inserisce un operatore non valido
        }
    }
    return operatore; // restituzione dell operatore inserito dall utente alla funzione chiamante (nel caso specifico, al main)
}

double EseguiOperazione(double num1, double num2, char operatore)
{
    double risultato = 0; // dichiarazione e inizializzazione di una variabile che conterra il risultato dell operazione
    switch (operatore)
    {
        case '+':
            risultato = num1 + num2; // somma dei due numeri
            break;
        case '-':
            risultato = num1 - num2; // differenza dei due numeri
            break;
        case '*':
            risultato = num1 * num2; // prodotto dei due numeri
            break;
        case '/':
            risultato = num1 / num2; // divisione dei due numeri
            break;
    }
    return risultato; // restituzione del risultato dell operazione alla funzione chiamante (nel caso specifico, al main)
}