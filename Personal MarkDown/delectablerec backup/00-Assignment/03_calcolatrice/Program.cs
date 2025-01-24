// Chiedi all'utente di inserire due numeri
double num1 = 0; // Inizializzo le variabili num1 e num2 a 0
double num2 = 0; // Inizializzo le variabili num1 e num2 a 0

// primo blocco try-catch per gestire l'eccezione FormatException
bool inputValido = false; // Inizializzo la variabile inputValido a false
while (!inputValido)
{
    try
    {
        Console.Write("Inserisci il primo numero: ");
        num1 = Convert.ToDouble(Console.ReadLine());
        inputValido = true;
    }
    catch (FormatException)
    {
        Console.WriteLine("Inserisci un numero valido.");
    }
}

// secondo blocco try-catch per gestire l'eccezione FormatException
inputValido = false;
while (!inputValido)
{
    try
    {
        Console.Write("Inserisci il secondo numero: ");
        num2 = Convert.ToDouble(Console.ReadLine());
        inputValido = true;
    }
    catch (FormatException)
    {
        Console.WriteLine("Inserisci un numero valido.");
    }
}
// Chiedi all'utente di selezionare un operatore matematico
char operatore = ' ';
inputValido = false;
while (!inputValido)
{
    Console.Write("Seleziona un operatore (+, -, *, /): ");
    operatore = Console.ReadKey().KeyChar;
    Console.WriteLine();
    if (operatore == '+' || operatore == '-' || operatore == '*' || operatore == '/')
    {
        inputValido = true;
    }
    else
    {
        Console.WriteLine("Operatore non valido.");
    }
}
// Esegui l'operazione selezionata
double risultato = 0;
try
{
    switch (operatore)
    {
        case '+':
            risultato = num1 + num2;
            break;
        case '-':
            risultato = num1 - num2;
            break;
        case '*':
            risultato = num1 * num2;
            break;
        case '/':
            if (num2 == 0)
            {
                throw new DivideByZeroException();
            }
            risultato = num1 / num2;
            break;
    }
    // Stampa il risultato
    Console.WriteLine($"Il risultato dell'operazione è: {risultato}");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Impossibile dividere per zero.");
}