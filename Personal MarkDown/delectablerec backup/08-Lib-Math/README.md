# MATH

> La libreria Math in C# è una collezione di metodi statici che forniscono funzionalità matematiche di base, come calcoli su numeri, trigonometria, logaritmi, e così via.

Ecco una breve panoramica di alcuni dei metodi più utilizzati in questa libreria:

- **Abs**: Calcola il valore assoluto di un numero. Ad esempio, `Math.Abs(-4.7)` restituisce `4.7`.

- **Ceiling**: Arrotonda un numero con la virgola al più piccolo intero non minore del numero stesso. Per esempio, `Math.Ceiling(4.3)` restituisce `5`.

- **Floor**: Arrotonda un numero con la virgola al più grande intero non maggiore del numero stesso. Ad esempio, `Math.Floor(4.7)` restituisce `4`.

- **Max**: Restituisce il maggiore di due numeri. Ad esempio, `Math.Max(4, 5)` restituisce `5`.

- **Min**: Restituisce il minore di due numeri. Ad esempio, `Math.Min(4, 5)` restituisce `4`.

- **Pow**: Eleva un numero a una potenza specificata. Ad esempio, `Math.Pow(2, 3)` restituisce `8`.

- **Round**: Arrotonda un numero a un certo numero di cifre decimali. Il metodo può anche specificare la direzione dell'arrotondamento tramite `MidpointRounding`. Ad esempio, `Math.Round(4.567, 2)` restituisce `4.57`.

- **Sqrt**: Calcola la radice quadrata di un numero. Ad esempio, `Math.Sqrt(16)` restituisce `4`.

- **Sin, Cos, Tan**: Calcolano rispettivamente il seno, il coseno e la tangente di un angolo espresso in radianti. Per esempio, `Math.Sin(Math.PI / 2)` restituisce `1`.

## Esercizio 1: Calcolo Distanza

Problema: Data la coppia di punti (x1, y1) e (x2, y2), calcola la distanza tra di loro.
Metodi Math Utilizzati: Math.Sqrt, Math.Pow

```csharp
double x1 = 3, y1 = 4;
double x2 = 6, y2 = 8;
double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
Console.WriteLine("Distanza: " + distance);
```

## Esercizio 2: Arrotondamento

Problema: Arrotonda un array di numeri decimali alla seconda cifra decimale.
Metodi Math Utilizzati: Math.Round

```csharp
double[] numeri = { 3.14159, 2.71828, 1.61803};
for (int i = 0; i < numeri.Length; i++)
{
    numeri[i] = Math.Round(numeri[i], 2); // Arrotonda il numero alla seconda cifra decimale
    Console.WriteLine($"Numero arrotondato: {numeri[i]}");
}
```
arrotondamento eccesso difetto

```csharp
double[] numeri = { 3.14159, 2.71828, 1.61803};
for (int i = 0; i < numeri.Length; i++)
{
    double arrotondatoPerEccesso = Math.Ceiling(numeri[i]); // Arrotonda per eccesso
    double arrotondatoPerDifetto = Math.Floor(numeri[i]); // Arrotonda per difetto
    Console.WriteLine($"Numero arrotondato per eccesso: {arrotondatoPerEccesso}");
    Console.WriteLine($"Numero arrotondato per difetto: {arrotondatoPerDifetto}");
}
```

arrotondamento MidpointRounding

```csharp
double[] numeri = { 3.5, 4.5, 5.5};
for (int i = 0; i < numeri.Length; i++)
{
    double arrotondatoPerDifetto = Math.Round(numeri[i], MidpointRounding.ToEven); // Arrotonda per difetto
    double arrotondatoPerEccesso = Math.Round(numeri[i], MidpointRounding.AwayFromZero); // Arrotonda per eccesso
    Console.WriteLine($"Numero arrotondato per difetto: {arrotondatoPerDifetto}");
    Console.WriteLine($"Numero arrotondato per eccesso: {arrotondatoPerEccesso}");
}
```

## Esercizio 3: Massimo e Minimo in Array

Problema: Trova il valore massimo e minimo in un array di interi.
Metodi Math Utilizzati: Math.Max, Math.Min

```csharp
int[] numeri = { 5, 9, 1, 3, 4};
int max = numeri[0]; // Inizializza il massimo al primo elemento in modo che possa essere confrontato
int min = numeri[0]; // Inizializza il minimo al primo elemento in modo che possa essere confrontato
for (int i = 1; i < numeri.Length; i++)
{
    max = Math.Max(max, numeri[i]); // Aggiorna il massimo se il numero corrente è maggiore
    min = Math.Min(min, numeri[i]); // Aggiorna il minimo se il numero corrente è minore
}
Console.WriteLine($"Massimo: {max}");
Console.WriteLine($"Minimo: {min}");
```

## Esercizio 4: Calcolo di Angoli

Problema: Data un angolo in gradi, calcola seno, coseno e tangente.
Metodi Math Utilizzati: Math.Sin, Math.Cos, Math.Tan, Math.PI

```csharp
double angoloInGradi = 45;
double angoloInRadianti = angoloInGradi * (Math.PI / 180);
double seno = Math.Sin(angoloInRadianti);
double coseno = Math.Cos(angoloInRadianti);
double tangente = Math.Tan(angoloInRadianti);
Console.WriteLine($"Seno: {seno}");
Console.WriteLine($"Coseno: {coseno}");
Console.WriteLine($"Tangente: {tangente}");
```

## Esercizio 5: Divisione con divrem

```csharp
int dividendo = 10;
int divisore = 3;
int quoziente = Math.DivRem(dividendo, divisore, out int resto);
Console.WriteLine($"Quoziente: {quoziente}");
Console.WriteLine($"Resto: {resto}");
```

## Esercizio 6: Utilizzo di costanti pi greco TT π

```csharp
double raggio = 5;
double area = Math.PI * Math.Pow(raggio, 2);
double circonferenza = 2 * Math.PI * raggio;
Console.WriteLine($"Area: {area}");
Console.WriteLine($"Circonferenza: {circonferenza}");
```

## Esercizio 7: Abs

```csharp
int numero = -5;
int valoreAssoluto = Math.Abs(numero);
Console.WriteLine($"Valore assoluto: {valoreAssoluto}");
```


Questi esercizi forniscono una buona base per esplorare le varie funzioni della libreria Math in C# e applicarle in scenari reali.
Puoi modificare gli input o espandere gli esercizi per esplorare ulteriori capacità della libreria.