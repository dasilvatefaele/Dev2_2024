// classe di gestione degli input per semplificare l'acquisizione e la 
// validazione degli input. Questa classe aiuta a gestire i casi di errore e 
// fornisce metodi per acquisire input di diversi tipi
//* int min = int.MinValue è la costante minima dei valori interi. 
//* int max = int.MaxValue è la costante massima dei valori interi
//* quando chiamiamo il metodo, se inseriamo l'argomento, lo sovrascrive
//* se non lo inseriamo, la variabile avrà il valore dichiarato 
//* nella definizione del metodo
public static class Color
{
   public static void Black()
    {
        Console.ForegroundColor = ConsoleColor.Black;
    }

    public static void DarkBlue()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
    }

    public static void DarkGreen()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
    }

    public static void DarkCyan()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public static void DarkRed()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
    }

    public static void DarkMagenta()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
    }

    public static void DarkYellow()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
    }

    public static void Gray()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void DarkGray()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }

    public static void Blue()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }

    public static void Green()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }

    public static void Cyan()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    public static void Red()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    public static void Magenta()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
    }

    public static void Yellow()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }

    public static void White()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Reset()
    {
        Console.ResetColor();
    }




}
