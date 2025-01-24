// Math
// La libreria Math in C# è una collezione di metodi statici che forniscono funzionalità matematiche di base, come calcoli su numeri,
// trigonometria, logaritmi, e così via.

// abs
// Il metodo Math.Abs() restituisce il valore assoluto di un numero. Il valore assoluto di un numero è il numero stesso senza il segno meno.
int number1 = -10;
int absNumber = Math.Abs(number1);
Console.WriteLine(absNumber);

// ceiling
// Il metodo Math.Ceiling() restituisce il più piccolo intero maggiore o uguale a un numero decimale.
double number2 = 10.1;
double ceilingNumber = Math.Ceiling(number2);
Console.WriteLine(ceilingNumber);

// floor
// Il metodo Math.Floor() restituisce il più grande intero minore o uguale a un numero decimale.
double number3 = 10.9;
double floorNumber = Math.Floor(number3);
Console.WriteLine(floorNumber);

// round
// Il metodo Math.Round() arrotonda un numero decimale al numero intero più vicino.
double number4 = 10.574;
double intNumber = Math.Round(number4);
double roundNumber = Math.Round(number4 ,2); // posso utilizzare un secondo parametro per specificare il numero di cifre decimali
Console.WriteLine(intNumber);
Console.WriteLine(roundNumber);

// midpointrounding
// il metodo midpointrounding permette di specificare come arrotondare i numeri decimali in caso di arrotondamento a .5
double[] numeri = { 3.5, 4.5, 5.5};
for (int i = 0; i < numeri.Length; i++)
{
    double arrotondatoPerDifetto = Math.Round(numeri[i], MidpointRounding.ToEven); // Arrotonda per difetto
    double arrotondatoPerEccesso = Math.Round(numeri[i], MidpointRounding.AwayFromZero); // Arrotonda per eccesso
    Console.WriteLine($"Arrotondato per difetto: {arrotondatoPerDifetto}");
    Console.WriteLine($"Arrotondato per eccesso: {arrotondatoPerEccesso}");
}

// max
// Il metodo Math.Max() restituisce il numero più grande tra due numeri.
int number5 = 10;
int number6 = 20;
int maxNumber = Math.Max(number5, number6);
Console.WriteLine($"Il numero più grande è {maxNumber}");

// min
// Il metodo Math.Min() restituisce il numero più piccolo tra due numeri.
int number7 = 10;
int number8 = 20;
int minNumber = Math.Min(number7, number8);
Console.WriteLine($"Il numero più piccolo è {minNumber}");

// pow
// Il metodo Math.Pow() restituisce il valore di un numero elevato alla potenza di un altro numero.
double number9 = 2.1;
double number10 = 3;
double powNumber = Math.Pow(number9, number10);
Console.WriteLine(powNumber);
// devo usare un double per il risultato, altrimenti ottengo un errore perche il risultato potrebbe essere un numero decimale

// sqrt
// Il metodo Math.Sqrt() restituisce la radice quadrata di un numero.
double number11 = 17;
double sqrtNumber = Math.Sqrt(number11);
Console.WriteLine(sqrtNumber);

// divrem
// Il metodo Math.DivRem() restituisce il quoziente e il resto di una divisione intera.
int dividendo = 10;
int divisore = 3;
int quoziente = Math.DivRem(dividendo, divisore, out int resto);
Console.WriteLine($"Quoziente: {quoziente}");
Console.WriteLine($"Resto: {resto}");

// cos
// Il metodo Math.Cos() restituisce il coseno di un angolo specificato in radianti.
double angle = 45;
double cosNumber = Math.Cos(angle);
Console.WriteLine(cosNumber);

// sin
// Il metodo Math.Sin() restituisce il seno di un angolo specificato in radianti.
double angle2 = 45;
double sinNumber = Math.Sin(angle2);
Console.WriteLine(sinNumber);

// tan
// Il metodo Math.Tan() restituisce la tangente di un angolo specificato in radianti.
double angle3 = 45;
double tanNumber = Math.Tan(angle3);
Console.WriteLine(tanNumber);

// PI uso di costanti
double raggio = 5;
double area = Math.PI * Math.Pow(raggio, 2);
double circonferenza = 2 * Math.PI * raggio;
Console.WriteLine($"Area: {area}");
Console.WriteLine($"Circonferenza: {circonferenza}");

// ESERCIZI

// Arrotonda un array di numeri decimali alla seconda cifra decimale usando Math.Round
double[] numeri = { 3.14159, 2.71828, 1.61803};
double[] arrotondati = new double[numeri.Length]; // Array per i numeri arrotondati di lunghezza uguale a numeri
for (int i = 0; i < numeri.Length; i++)
{
    arrotondati[i] = Math.Round(numeri[i], 2); // Arrotonda il numero alla seconda cifra decimale
    Console.WriteLine($"Numero arrotondato: {numeri[i]}");
}

// Trova il valore max e min in un array di interi usando Math.Max e Math.Min
int[] numeri2 = { 5, 9, 1, 3, 4};
int min = numeri2[0]; // Inizializza il minimo al primo elemento dell'array in modo che possa essere confrontato
int max = numeri2[0]; // Inizializza il massimo al primo elemento dell'array in modo che possa essere confrontato
for (int i = 1; i < numeri2.Length; i++) // Inizia dal secondo elemento dell'array perche il primo è già stato inizializzato come elemento di confronto
{
    min = Math.Min(min, numeri2[i]); // Trova il minimo tra il minimo attuale e l'elemento corrente
    max = Math.Max(max, numeri2[i]); // Trova il massimo tra il massimo attuale e l'elemento corrente
}
Console.WriteLine($"Il valore minimo è: {min}");
Console.WriteLine($"Il valore massimo è: {max}");

// arrotonda per eccesso e per difetto un array di numeri decimali usando Math.Ceiling e Math.Floor
double[] numeri3 = { 3.14159, 2.71828, 1.61803};
for (int i = 0; i < numeri3.Length; i++)
{
    double perEccesso = Math.Ceiling(numeri3[i]); // Arrotonda per eccesso
    double perDifetto = Math.Floor(numeri3[i]); // Arrotonda per difetto
    Console.WriteLine($"Arrotondato per eccesso: {perEccesso}");
    Console.WriteLine($"Arrotondato per difetto: {perDifetto}");
}