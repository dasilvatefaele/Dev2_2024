
// Ogni campo utilizza il formato {Campo, -Larghezza} dove:
// Campo è il valore da stampare
// -Larghezza specifica la larghezza del campo; il segno - allinea il testo a sinistra
// {"Nome",-20} significa che il nome del dipendente avrà una larghezza fissa di 20 caratteri, allineato a sinistra
// Formato dei numero:
// Per i prezzi viene usato il formato 0.00 per mostrare sempre due cifre decimali
// Linea spaziatrice:
// La riga Console.WriteLine(new string ('-', 50)); stampa una linea divisoria lunga 50 caratteri per migliorare la leggibilità
static public class StampaClienti
{
    const int COLONNA_XSMALL = -5;
    const int COLONNA_SMALL = -10;
    const int COLONNA_MEDIUM = -20;
    const int COLONNA_LARGE = -50;

    static public void Tabella(List<Cliente> clienti)
    {
        const int LUNGHEZZA_BR = 71;
        if (clienti.Count > 0)
        {
            Color.DarkGray();
            Console.WriteLine($"{"ID",COLONNA_SMALL}{"Nome",COLONNA_MEDIUM}{"Spesa Totale",COLONNA_MEDIUM}{"Data Ultimo Acquisto",COLONNA_MEDIUM}");
            Console.WriteLine(new string('-', LUNGHEZZA_BR));
            Color.Reset();
            decimal spesaCliente = 0;
            string dataUltimoAcquisto = "";
            foreach (var cliente in clienti)
            {
                if (cliente.StoricoAcquisti.Count == 0)
                {
                    spesaCliente = 0;
                    dataUltimoAcquisto = "Mai Acquistato";
                }
                else
                {
                    foreach (var spesa in cliente.StoricoAcquisti)
                    {
                        spesaCliente += spesa.Totale;
                        dataUltimoAcquisto = spesa.Data;
                    }
                }
                Console.WriteLine($"{cliente.Id,COLONNA_SMALL}{cliente.Username,COLONNA_MEDIUM}{"€" + spesaCliente.ToString("F2"),COLONNA_MEDIUM}{dataUltimoAcquisto,COLONNA_MEDIUM}");
                spesaCliente = 0;
            }
        }
        else
        {
            Console.WriteLine("Non ci sono clienti.\n");
        }
    }

        static public void Ricarica(List<Cliente> clienti)
    {
        const int LUNGHEZZA_BR = 38;
        if (clienti.Count > 0)
        {
            Color.DarkGray();
            Console.WriteLine($"{"ID",COLONNA_SMALL}{"Nome",COLONNA_MEDIUM}{"Credito",COLONNA_MEDIUM}");
            Console.WriteLine(new string('-', LUNGHEZZA_BR));
            Color.Reset();
            foreach (var cliente in clienti)
            {
                Console.WriteLine($"{cliente.Id,COLONNA_SMALL}{cliente.Username,COLONNA_MEDIUM}{"€" + cliente.Credito.ToString("F2")}");
            }
        }
        else
        {
            Console.WriteLine("Non ci sono clienti.\n");
        }
    }


    // static public void Singolo(Dipendente dipendente)
    // {
    //     const int LUNGHEZZA_BR = 48;
    //     Color.DarkGray();
    //     Console.WriteLine($"{"ID",COLONNA_SMALL}{"Nome",COLONNA_MEDIUM}{"Ruolo",COLONNA_SMALL}");
    //     Console.WriteLine(new string('-', LUNGHEZZA_BR));
    //     Color.Reset();
    //     Console.WriteLine($"{dipendente.Id,COLONNA_SMALL}{dipendente.Username,COLONNA_MEDIUM}{dipendente.Ruolo,COLONNA_SMALL}");
    // }
}
