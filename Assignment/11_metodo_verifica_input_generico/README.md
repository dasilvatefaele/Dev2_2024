# Verifica input generico

## Obiettivo:
Programma in C# che contiene una serie di metodi generici per la verifica degli input

- [x]  un metodo per la verifica di un numero intero

- [x] un metodo per la verifica di un numero decimale

- [x] un metodo per la verifica di un numero double

- [x] un metodo per la verifica che un numero sia compreso in un intervallo

- [x] uno per una stringa non vuota 

- [ ] metodo per la verifica di un char non vuoto

---

# FUNZIONI DI INSERIMENTO


###### FUNZIONE DI CONTROLLO INSERIMENTO NUMERICO IN UN RANGE:

```csharp
int NumberInRange (int min, int max)
```

### Informazioni rapide:

- Ha come argomenti un valore `int min` e `int max`. La funzione restituisce un intero contenuto tra questi due valori, altrimenti chiede un nuovo inserimento
  
- La funzione gestisce le eccezioni di formato o di inserimento di spazi vuoti.
  

### Come utilizzarla:

```csharp
int input; 
// creo una variabile che userò ad esempio, in un futuro switch

input = NumberInRange (1, 4);
// sapendo che il mio menù ha solo 4 voci, inserirsco in NumberInRange
// il range accettato. Non è possibile uscire dalla funzione finché
// i requisiti non sono soddisfatti ed il giusto valore viene assegnato
// alla variabile inputcsharp
```

### Il corpo del codice:

```csharp
int NumberInRange(int min, int max)
{
    bool repeat = false;
    int num = 0;
    Console.Write($"Inserisci intero tra {min} e {max} ");
    do
    {
        do
        {
            Console.Write("> ");
            repeat = false;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("#Errore: dato non corretto");
                repeat = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("#Errore: dato non corretto");
                repeat = true;
            }
        } while (repeat);

        if (num >= min && num <= max)
        {
            //Console.WriteLine("*Numero nel range corretto*");
            return num;
        }
        else
        {
            Console.WriteLine("#Errore: numero fuori dal range");
            repeat = true;
        }
    } while (repeat);
    return -1;
}
```

---

###### INSERIMENTO DI UN INTERO:

```csharp
int InputInt()
```

Informazioni rapide:

- La funzioe non ha argomenti. Restituisce un intero e gestisce le eccezioni di formato o di inserimento di spazi vuoti.
  

### Come utilizzarla:

```csharp
int input; 
// creo una variabile di tipo int

input = InputInt ();
// Non è possibile uscire dalla funzione finché
// non si inserisce un intero
```

### Il corpo del codice:

```csharp
int InputInt()
{
    int numero = 0;
    bool repeat = false;
    do
    {
        repeat = false;
        try
        {
            Console.Write("Inserisci numero intero > ");
            numero = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine("#Errore: dato non corretto");
            repeat = true;
        }
    } while (repeat);
    return numero;
}
```

---

###### INSERIMENTO DI UN NUMERO CON LA VIRGOLA:

```csharp
double InputDouble()
```

Informazioni rapide:

- La funzioe non ha argomenti. Restituisce un numero con la virgola (sia che inserito con `.` che con `,` . Inoltre gestisce le eccezioni di formato o di inserimento di spazi vuoti.
- Se si inserisce un numero intero verrà convertito in double

### Come utilizzarla:

```csharp
double misura; 
// creo una variabile di tipo double

misura = InputDouble();
// Non è possibile uscire dalla funzione finché
// non si inserisce un numero valido
```

### Il corpo del codice:

```csharp
double InputDouble()
{
    double numero = 0;
    bool repeat = false;
    string s_numero;
    do
    {
        repeat = false;

        Console.Write("Inserisci numero decimale > ");
        s_numero = Console.ReadLine();
        s_numero = s_numero.Replace(",", ".");

        try
        {
            numero = Convert.ToDouble(s_numero);
        }
        catch (Exception e)
        {
            Console.WriteLine("#Errore: dato non corretto");
            repeat = true;
        }
    } while (repeat);

    //Console.WriteLine("*Decimale insierito*");
    return numero;
}
```

---

###### INSERIMENTO DI UNA STRINGA:

```csharp
string InserimentoFrase();
```

Informazioni rapide:

- La funzioe non ha argomenti. Restituisce una <u>stringa</u> e gestisce l'eccezione per l'inserimento di spazi vuoti.

### Come utilizzarla:

```csharp
string inputFrase; 
// creo una variabile di tipo string

inputFrase = InserimentoFrase();
// Accetta qualunque stringa, a patto che non sia vuota
```

### Il corpo del codice:

```csharp
string Inserimentofrase()
{
    Console.Write("Inserisci una stringa > ");
    string frase;
    frase = Console.ReadLine();
    bool ripeti = false;
    do
    {
        ripeti = string.IsNullOrWhiteSpace(frase);

        if (ripeti) // if true
        {
            Console.WriteLine("#Errore: stringa vuota");
            frase = Console.ReadLine();
        }
        else
        {
            //Console.WriteLine("*Stringa inserita*");
            return frase;
        }
    } while (ripeti);
    return frase;
}
```

> Versionamento:
```bash
git add --all
git commit -m "Verifica input generico"
git push -u origin main
```