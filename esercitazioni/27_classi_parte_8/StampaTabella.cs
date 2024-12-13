
// Ogni campo utilizza il formato {Campo, -Larghezza} dove:
// Campo è il valore da stampare
// -Larghezza specifica la larghezza del campo; il segno - allinea il testo a sinistra
// {"Nome",-20} significa che il nome del prodotto avrà una larghezza fissa di 20 caratteri, allineato a sinistra
// Formato dei numero:
// Per i prezzi viene usato il formato 0.00 per mostrare sempre due cifre decimali
// Linea spaziatrice:
// La riga Console.WriteLine(new string ('-', 50)); stampa una linea divisoria lunga 50 caratteri per migliorare la leggibilità
static public class StampaTabella
{
        const int COLONNA_XSMALL = -5;
        const int COLONNA_SMALL = -10;
        const int COLONNA_MEDIUM = -20;
        const int COLONNA_LARGE = -30;
        const int LUNGHEZZA_BR = 50;
        
    static public void ComeAdmin(List<ProdottoAdvanced> prodotti)
    {
        if (prodotti.Count > 0)
        {
            Console.WriteLine($"{"ID",COLONNA_SMALL}{"Nome",COLONNA_MEDIUM}{"Prezzo",COLONNA_SMALL}{"Giacenza",COLONNA_SMALL}");
            Console.WriteLine(new string('-',LUNGHEZZA_BR));
            foreach(var prodotto in prodotti)
            {
                Console.WriteLine($"{prodotto.Id,COLONNA_SMALL}{prodotto.NomeProdotto,COLONNA_MEDIUM}{prodotto.PrezzoProdotto,COLONNA_SMALL:0.00}{prodotto.GiacenzaProdotto,COLONNA_SMALL}");
            }
        }
        else
        {
            Console.WriteLine("Non ci sono prodotti.");
        }
    }
    static public void ComeCliente(List<ProdottoAdvanced> prodotti)
    {
        if (prodotti.Count > 0)
        {
            Console.WriteLine($"{"Nome",COLONNA_MEDIUM}{"Prezzo",COLONNA_XSMALL}");
            Console.WriteLine(new string ('-',LUNGHEZZA_BR));
            foreach(var prodotto in prodotti)
            {
                Console.WriteLine($"{prodotto.NomeProdotto,COLONNA_MEDIUM}{prodotto.PrezzoProdotto,COLONNA_XSMALL}");
            }
        }
        else
        {
            Console.WriteLine("Non ci sono prodotti.");
        }
    }
}
