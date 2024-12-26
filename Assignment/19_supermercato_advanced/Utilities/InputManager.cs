// classe di gestione degli input per semplificare l'acquisizione e la 
// validazione degli input. Questa classe aiuta a gestire i casi di errore e 
// fornisce metodi per acquisire input di diversi tipi
//* int min = int.MinValue è la costante minima dei valori interi. 
//* int max = int.MaxValue è la costante massima dei valori interi
//* quando chiamiamo il metodo, se inseriamo l'argomento, lo sovrascrive
//* se non lo inseriamo, la variabile avrà il valore dichiarato 
//* nella definizione del metodo
public static class InputManager
{
    public static int LeggiIntero(string messaggio, int min = int.MinValue, int max = int.MaxValue)
    {
        int valore; // per memorizzare intero acquisito
        while (true)
        {
            Console.Write($"{messaggio}"); // messaggio è la variabile di input
            string input = Console.ReadLine(); // acquisisco input come stringa
            // provo a convertire 
            if (int.TryParse(input, out valore) && valore >= min && valore <= max)
            {
                return valore;
                // restituisce ed esce dal ciclo quando trova il valore
            }
            else
            {
                Console.WriteLine($"Inserire un valore intero compreso tra {min} e {max}");
            }
        }
    }
    public static decimal LeggiDecimale(string messaggio, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
    {
        decimal valore;
        while (true)
        {
            Console.Write($"{messaggio}"); // messaggio è la variabile di input
            string input = Console.ReadLine(); // acquisisco input come stringa

            // sostituisco la virgola con il punto
            if (input.Contains(".")) //(input.Contains(",") && !input.Contains("."))
            {
                input = input.Replace(".", ","); // sostituire la virgola con il punto
            }
            // provo a convertire 
            if (decimal.TryParse(input, out valore) && valore >= min && valore <= max)
            {
                return valore;
                // restituisce ed esce dal ciclo quando trova il valore
            }
            else
            {
                Console.WriteLine($"Inserire un valore intero compreso tra {min} e {max}");
            }
        }
    }
    public static string LeggiStringa(string messaggio, bool obbligatorio = true)
    {
        string valore;
        while (true)
        {
            Console.Write($"{messaggio}"); // messaggio è la variabile di input
            string input = Console.ReadLine(); // acquisisco input come stringa
            // provo a convertire 
            if (!string.IsNullOrWhiteSpace(input) || !obbligatorio)
            {
                return input;
            }
            Console.WriteLine($"Errore: il valore non può essere vuoto");
        }
    }
    public static bool LeggiConferma(string messaggio)
    {
        while (true)
        {
            Console.Write($"{messaggio} (s/n): ");
            string input = Console.ReadLine().ToLower();
            if (input == "s" || input == "si")
            {
                return true;
            }
            else if (input == "n" || input == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Inserire un valore valido");
            }
        }
    }
}
