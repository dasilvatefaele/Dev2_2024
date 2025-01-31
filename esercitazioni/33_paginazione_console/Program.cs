
class Program
{
    static void Main(string[] args)
    {
        // inizializzazione lista
        var prodotti = new List<Prodotto>
        {
            new Prodotto{Id = 1, Nome = "Prodotto1", Prezzo = 1.0m },
            new Prodotto{Id = 2, Nome = "Prodotto2", Prezzo = 1.5m },
            new Prodotto{Id = 3, Nome = "Prodotto3", Prezzo = 2.0m },
            new Prodotto{Id = 4, Nome = "Prodotto4", Prezzo = 2.5m },
            new Prodotto{Id = 5, Nome = "Prodotto5", Prezzo = 3.0m },
            new Prodotto{Id = 6, Nome = "Prodotto6", Prezzo = 3.5m },
            new Prodotto{Id = 7, Nome = "Prodotto7", Prezzo = 4.0m },
            new Prodotto{Id = 8, Nome = "Prodotto8", Prezzo = 4.5m },
            new Prodotto{Id = 9, Nome = "Prodotto9", Prezzo = 5.0m },
            new Prodotto{Id = 10, Nome = "Prodotto10", Prezzo = 5.5m },
        };

        // numero di articoli per pagina
        int articoliPerPagina = 3;

        // funzione che mostra i prodotti paginati
        Paginazione.MostraProdottiPaginati(prodotti, articoliPerPagina);
    }



}