
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

    static CarrelloAdvancedManager managerCarrello = new CarrelloAdvancedManager();


    static public void ComeAdmin(List<Prodotto> prodotti)
    {
        const int LUNGHEZZA_BR = 65;
        if (prodotti.Count > 0)
        {
            Color.DarkGray();
            Console.WriteLine($"{"ID",COLONNA_SMALL}{"Nome",COLONNA_MEDIUM}{"Prezzo",COLONNA_SMALL}{"Giacenza",COLONNA_SMALL}{"Categoria",COLONNA_SMALL}");
            Console.WriteLine(new string('-', LUNGHEZZA_BR));
            Color.Reset();
            foreach (var prodotto in prodotti)
            {
                Console.WriteLine($"{prodotto.Id,COLONNA_SMALL}{prodotto.Nome,COLONNA_MEDIUM}{prodotto.Prezzo.ToString("F2"),COLONNA_SMALL}{prodotto.Giacenza,COLONNA_SMALL}{prodotto.Categoria.Name,COLONNA_SMALL}");
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
            Color.White();
            Console.WriteLine($"{"Nome",COLONNA_MEDIUM}{"Prezzo",COLONNA_MEDIUM}");
            Console.WriteLine(new string('-', LUNGHEZZA_BR));
            foreach (var prodotto in prodotti)
            {
                Console.WriteLine($"{prodotto.Nome,COLONNA_MEDIUM}{prodotto.Prezzo.ToString("F2"),COLONNA_MEDIUM}");
            }
        }
        else
        {
            Console.WriteLine("Non ci sono prodotti.\n");
        }
    }
    static public void Carrello(List<ProdottoCarrello> carrello)
    {
        Color.Reset();
        const int LUNGHEZZA_BR = 40;
        if (carrello.Count > 0)
        {
            Console.WriteLine($"{"Qnt.",COLONNA_SMALL}{"Nome",COLONNA_MEDIUM}{"Prezzo",COLONNA_MEDIUM:0.00}");
            Console.WriteLine(new string('-', LUNGHEZZA_BR));
            foreach (var item in carrello)
            {
                Console.WriteLine($"{"x" + item.Quantita,COLONNA_SMALL}{item.Nome,COLONNA_MEDIUM}{"€" + item.Prezzo.ToString("F2"),COLONNA_MEDIUM}");

            }
            Console.WriteLine(new string('-', LUNGHEZZA_BR));
            Color.DarkYellow();
            Console.WriteLine($"{"SubTotal:",-30}{"€" + managerCarrello.CalcolaTotale(carrello).ToString("F2")}");
            Color.Reset();
        }
        else
        {
            Console.WriteLine("Non ci sono prodotti.\n");
        }
    }

    static public void Categorie(List<Categoria> listaCategorie)
    {
        Color.DarkGray();
        Console.WriteLine($"{"ID",-10} {"Categoria",-20}");
        Console.WriteLine(new string('-', 24));
        Color.Reset();
        foreach (var categorie in listaCategorie)
        {
            Console.WriteLine($"{categorie.ID,-10}{categorie.Name,-20}");
        }
        Console.WriteLine();
    }

    static public void Purchase(List<Purchase> listaPurchase)
    {
        CarrelloAdvancedManager carrelloManager = new CarrelloAdvancedManager();
        Color.DarkGray();
        Console.WriteLine($"{"ID",-10}{"Cliente",-20}{"Totale",-10}");
        Console.WriteLine(new string('-', 40));
        Color.DarkYellow();
        foreach (var item in listaPurchase)
        {

            if (item.Completed == false)
            {
                Console.WriteLine($"{item.IdPurchase,-10}{item.NomeCliente,-20}{item.Totale.ToString("F2"),-10}");
            }
        }
        Console.WriteLine();
    }
}
