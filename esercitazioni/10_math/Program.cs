/*=========================================================
                            MATH
=========================================================*/

Console.Clear();

/*
    * Libreria di metodi statici con funzionalità matemtiche
    * (calcoli su numeri, trigonometria, logaritmi e così via) 
    
    ? Calcoli su numeri 
    Math.Abs()              -       restituisce il valore assoluto di un numero - senza segno meno
    Math.Max()              -       restituisce il numero più alto
    Math.Min()              -       restituisce il numero più basso
    Math.Pow()              -       potenza
    Math.Sqrt()             -       radice quadrata
    Math.Cos()              -       coseno
    Math.Sin()              -       seno
    Math.Tan()              -       tangente
    Math.DivRem()           -       restituisce quoziente e resto
    .Average()              -       restituisce la media dei valori


    ? Approssimazioni 
    Math.Ceiling()          -       approssimazione all'intero successivo - per eccesso
    Math.Floor()            -       approssimazione all'intero precedente - per difetto
    Math.Round()            -       arrotonda un numero decimale all'intero più vicino
    MidPointRounding        
*/

// ! Math.Abs()
int numero = -10;
// * Console.WriteLine(Math.Abs(numero));
// * oppure
int numeroAssoluto = Math.Abs(numero);
Console.WriteLine(numeroAssoluto);
// stampa 10 (senza -)

// ! Math.Ceiling()
double numero2 = 10.1;
double ceilingNumero = Math.Ceiling(numero2);
Console.WriteLine(ceilingNumero);
// stampa 11 (intero successivo di 10.1)

// ! Math.Floor()
double floorNumero = Math.Floor(numero2);
Console.WriteLine(floorNumero);
// stampa 10 (intero precedente di 10.1)

// ! Math.Round()
double numero3 = 10.572;
double intNumero = Math.Round(numero3);
double roundNumero = Math.Round(numero3,2);
Console.WriteLine(intNumero);
Console.WriteLine(roundNumero);
// stampa 11 ( arrotonda un numero decimale all'intero più vicino )
// stampa 10,57 ( tronca argomento al n del secondo argomento )

//* MidpointRounding

double[] numeri4 = {3.5,4.5,5.5};
for (int i = 0; i < numeri4.Length; i++)
{
    double arrotondatoPerDifetto = Math.Round(numeri4[i], MidpointRounding.ToEven); // arrotonda per difetto
    double arrotondatoPerEccesso = Math.Round(numeri4[i],MidpointRounding.AwayFromZero); // arrotonda per eccesso
}

// ! Math.Max()
int numero4 = 10;
int numero5 = 20;
int maxNumero = Math.Max(numero5, numero4);
Console.WriteLine($"Il numero più alto è {maxNumero}");

// ! Math.Min()
int numero6 = 33;
int numero7 = 66;
int minNumero = Math.Min(numero6, numero7);
Console.WriteLine($"Il numero più basso è {minNumero}");

// ! Math.DivRem()

int dividendo = 10;
int divisore = 3;
int quoziente = Math.DivRem(dividendo, divisore, out int resto);
Console.WriteLine($"Quoziente: {quoziente}");
Console.WriteLine($"Resto: {resto}");

// * Uso di costanti, esempio PI
double raggio = 5;
double circonferenza = 2 * Math.PI * raggio;
double area = Math.PI*Math.Pow(raggio, 2);
Console.WriteLine($"Raggio: {raggio}\nArea: {area}\nCirconferenza: {circonferenza}");

// ! Math.Pow()
double baseNumero = 2;
double potenza = 3;
double risultatoPotenza = Math.Pow(baseNumero,potenza);
Console.WriteLine(risultatoPotenza);

// ! Math.Sqrt()
double numero8 = 16;
double sqrtNumero = Math.Sqrt(numero8);
Console.WriteLine(sqrtNumero);

// ! Math.Sin()

double angle1 = 45;
double sinNumber = Math.Sin(angle1);
Console.WriteLine(sinNumber);

// ! Math.Cos()

double angle2 = 45;
double cosNumber = Math.Cos(angle2);
Console.WriteLine(cosNumber);

// ! Math.Tan()

double angle3 = 45;
double tanNumber = Math.Tan(angle3);
Console.WriteLine(tanNumber);

// TODO: Arrotonda un arrai di numeri decimali alla seconda cifra decimale 

double[] numeri = {3.14150, 2.71828, 1.61803};
Console.Write("Prima della conversione: ");
Console.Write(string.Join(", ",numeri));

for (int i = 0; i < numeri.Length ; i++)
{
    numeri[i] = Math.Round(numeri[i],2);
}

Console.Write("\n");
Console.Write("Dopo della conversione: ");
Console.Write(string.Join(", ",numeri));

// * .Average() 

double media = numeri.Average();
Console.WriteLine($"La media dei nuovi valori è {media}");

// TODO: Trova il valore massimo e minimo di un array di interi usando Math.Max e Math.Min

int[] numeriInt = {5,9,1,3,4};
int massimoInt = numeriInt[0];
int minimoInt = numeriInt[0];
// * NOTA BENE: al metodo .Max di Math servono due argomenti affinchè possa compararli
// *            quindi assegnamo alla variabile massimoInt e minimoInt uno dei valori 
// *            dell'array. tanto nel ciclo for si riconfrontano. in questo modo
// *            non tocchiamo i dentro il for facendo i+1 o i-1 evitando il rischio
// *            di uscire dall'array 

for(int i = 0; i < numeriInt.Length; i++)
{
    massimoInt = Math.Max(massimoInt, numeriInt[i]);
    minimoInt = Math.Min(minimoInt, numeriInt[i]);
} 

Console.WriteLine($"Il numero maggiore è: {massimoInt}\nIl numero minore è: {minimoInt}");

// TODO: arrotonda per eccesso e per difetto un array di numeri decimali usando Math.Ceiling e Math.Floor

double[] numeri3 = {3.14150, 2.71828, 1.61803};
double perEccesso;
double perDifetto;
for(int i = 0; i < numeri3.Length; i++)
{
    Console.WriteLine($"Numero da arrotondare:{numeri3[i]}");
    perEccesso = Math.Ceiling(numeri3[i]);
    perDifetto = Math.Floor(numeri3[i]);
    Console.WriteLine($"Per eccesso:{perEccesso}");
    Console.WriteLine($"Per difetto:{perDifetto}");
}