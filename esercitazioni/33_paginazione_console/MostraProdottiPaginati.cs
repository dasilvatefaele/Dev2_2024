public static class Paginazione
{
    public static void MostraProdottiPaginati(List<Prodotto> prodotti, int articoliPerPagina)
    {
        // numero totale dei prodotti
        int totaleProdotti = prodotti.Count;

        // calcolo totale delle pagine con totaleProdotti / articoliPerPagina
        int totalePagine = (int)Math.Ceiling((Decimal)totaleProdotti / articoliPerPagina);

        // variabile per rappresentare la pagina corrente
        int paginaCorrente = 1; // pagina iniziale

        ;

        while (true)
        {
            Console.Clear();

            Console.WriteLine($"Prodotti\n{new string('-', 36)}\n");

            // lista di prodotti per fare la paginazione

            //* Logica di paginazione:
            //* Skip: salta i primi n elementi e ci mostra gli articoli successivi
            //* Take: prende i primi n elementi 
            var prodottiPagina = prodotti
                        .Skip((paginaCorrente - 1) * articoliPerPagina) // salta i prodotti delle pagine precedenti
                        .Take(articoliPerPagina); // prende i prodotti della pagina corrente

            foreach (var prodotto in prodottiPagina)
            {
                Console.WriteLine($"ID: {prodotto.Id}\tNome: {prodotto.Nome}\tPrezzo: {prodotto.Prezzo}");
            }


            // stampo i pulsanti di navigazione
            Console.WriteLine("\n<-- | -->");

            // dialogo (mostro in quale pagina mi trovo)
            Console.WriteLine($"Pagina {paginaCorrente} di {totalePagine}");
                        


            var input = Console.ReadKey(true).Key; // il true serve per non mostrare il tasto premuto, il false lo mostra

            if (input == ConsoleKey.RightArrow && paginaCorrente < totalePagine)
            {
                paginaCorrente++; // va avanti avendo come limite il totale delle pagine
            }

            if (input == ConsoleKey.LeftArrow && paginaCorrente > 1)
            {
                paginaCorrente--; // va indietro vando come limite la prima pagina
            }

            if (input == ConsoleKey.E)
            {
                break;
            }



        }

    }
}