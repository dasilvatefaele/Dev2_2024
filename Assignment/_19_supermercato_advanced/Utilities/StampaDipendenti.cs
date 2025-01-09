
// Ogni campo utilizza il formato {Campo, -Larghezza} dove:
// Campo è il valore da stampare
// -Larghezza specifica la larghezza del campo; il segno - allinea il testo a sinistra
// {"Nome",-20} significa che il nome del dipendente avrà una larghezza fissa di 20 caratteri, allineato a sinistra
// Formato dei numero:
// Per i prezzi viene usato il formato 0.00 per mostrare sempre due cifre decimali
// Linea spaziatrice:
// La riga Console.WriteLine(new string ('-', 50)); stampa una linea divisoria lunga 50 caratteri per migliorare la leggibilità
static public class StampaDipendenti
{
    const int COLONNA_XSMALL = -5;
    const int COLONNA_SMALL = -10;
    const int COLONNA_MEDIUM = -20;
    const int COLONNA_LARGE = -50;

    static public void Tabella(List<Dipendente> dipendenti)
    {
        const int LUNGHEZZA_BR = 48;
        if (dipendenti.Count > 0)
        {
            Color.DarkGray();
            Console.WriteLine($"{"ID",COLONNA_SMALL}{"Nome",COLONNA_MEDIUM}{"Ruolo",COLONNA_SMALL}");
            Console.WriteLine(new string('-', LUNGHEZZA_BR));
            Color.Reset();
            foreach (var dipendente in dipendenti)
            {
                Console.WriteLine($"{dipendente.Id,COLONNA_SMALL}{dipendente.Username,COLONNA_MEDIUM}{dipendente.Ruolo,COLONNA_SMALL}");
            }
        }
        else
        {
            Console.WriteLine("Non ci sono dipendenti.\n");
        }
    }

    static public void Singolo(Dipendente dipendente)
    {
        const int LUNGHEZZA_BR = 48;
        Color.DarkGray();
        Console.WriteLine($"{"ID",COLONNA_SMALL}{"Nome",COLONNA_MEDIUM}{"Ruolo",COLONNA_SMALL}");
        Console.WriteLine(new string('-', LUNGHEZZA_BR));
        Color.Reset();
        Console.WriteLine($"{dipendente.Id,COLONNA_SMALL}{dipendente.Username,COLONNA_MEDIUM}{dipendente.Ruolo,COLONNA_SMALL}");
    }
}
