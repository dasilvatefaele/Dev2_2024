
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
    const int COLONNA_LARGE = -50;



    static public void ComeAdmin(List<Prodotto> prodotti)
    {
        const int LUNGHEZZA_BR = 65;
        if (prodotti.Count > 0)
        {
            Console.WriteLine($"{"ID",COLONNA_SMALL}{"Nome",COLONNA_MEDIUM}{"Prezzo",COLONNA_SMALL}{"Giacenza",COLONNA_SMALL}{"Categoria",COLONNA_SMALL}");
            Console.WriteLine(new string('-', LUNGHEZZA_BR));
            foreach (var prodotto in prodotti)
            {
                Console.WriteLine($"{prodotto.Id,COLONNA_SMALL}{prodotto.Nome,COLONNA_MEDIUM}{prodotto.Prezzo,COLONNA_SMALL:0.00}{prodotto.Giacenza,COLONNA_SMALL}{prodotto.Categoria.Name, COLONNA_SMALL}");
            }
        }
        else
        {
            Console.WriteLine("Non ci sono prodotti.\n");
        }
    }
    static public void ComeCliente(List<Prodotto> prodotti)
    {
        const int LUNGHEZZA_BR = 40;
        if (prodotti.Count > 0)
        {
            Console.WriteLine($"{"Nome",COLONNA_MEDIUM}{"Prezzo",COLONNA_MEDIUM}");
            Console.WriteLine(new string('-', LUNGHEZZA_BR));
            foreach (var prodotto in prodotti)
            {
                Console.WriteLine($"{prodotto.Nome,COLONNA_MEDIUM}{prodotto.Prezzo,COLONNA_MEDIUM}");
            }
        }
        else
        {
            Console.WriteLine("Non ci sono prodotti.\n");
        }
    }
    static public void Carrello(List<ProdottoCarrello> carrello)
    {
        const int LUNGHEZZA_BR = 40;
        if (carrello.Count > 0)
        {
            Console.WriteLine($"{"Qnt.",COLONNA_SMALL}{"Nome",COLONNA_MEDIUM}{"Prezzo",COLONNA_MEDIUM}");
            Console.WriteLine(new string('-', LUNGHEZZA_BR));
            foreach (var item in carrello)
            {
                Console.WriteLine($"{"x" + item.Quantita,COLONNA_SMALL}{item.Nome,COLONNA_MEDIUM}{item.Prezzo,COLONNA_MEDIUM}");
            }
        }
        else
        {
            Console.WriteLine("Non ci sono prodotti.\n");
        }
    }
}
