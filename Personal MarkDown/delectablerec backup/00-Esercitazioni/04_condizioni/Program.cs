// CONDIZIONI
/*
le principali istruzioni di controllo sono:
- if
- else
- else if
- switch
*/

// pulisce la console
Console.Clear();
// ESEMPIO DI IF
// se una condizione viene soddisfatta esegue un blocco di codice
int v = 10;
if (v > 5)
{
    Console.WriteLine("v e maggiore di 5");
}

// ESEMPIO DI IF ELSE
// se una condizione viene soddisfatta esegue un blocco di codice altrimenti un altro
int w = 10;
if (w > 5)
{
    Console.WriteLine("w e maggiore di 5");
}
else
{
    Console.WriteLine("w e minore o uguale a 5");
}

// ESEMPIO DI IF ELSE IF
// se una condizione viene soddisfatta esegue un blocco di codice altrimenti un altro altrimenti un altro se nessuna consizione e vera
int x = 10;
if (x > 5)
{
    Console.WriteLine("x e maggiore di 5");
}
else if (x == 5)
{
    Console.WriteLine("x e uguale a 5");
}
else
{
    Console.WriteLine("x e minore di 5");
}
// else if va messo tra if e else perche se messo dopo else non verrebbe mai eseguito

// ESEMPIO DI SWITCH
// esegue un blocco di codice in base al valore di una variabile
int y = 10;
switch (y)
{
    case 5:
        Console.WriteLine("y e uguale a 5");
        break; // break serve per uscire dallo switch
    case 10:
        Console.WriteLine("y e uguale a 10");
        break;
    default: // se nessun caso e soddisfatto esegue il blocco di codice di default
        Console.WriteLine("y non e nè 5 nè 10");
        break;
}
// esempio di switch con stringhe
string z = "ciao";
switch (z)
{
    case "ciao":
        Console.WriteLine("z e uguale a ciao");
        break;
    case "mondo":
        Console.WriteLine("z e uguale a mondo");
        break;
    default:
        Console.WriteLine("z non e nè ciao nè mondo");
        break;
}
// esempio di switch con bool
bool a = true;
switch (a)
{
    case true:
        Console.WriteLine("a e true");
        break;
    case false:
        Console.WriteLine("a e false");
        break;
    default:
        Console.WriteLine("a non e nè true nè false");
        break;
}