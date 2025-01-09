using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class ProdottoAdvancedManager
{
    private List<Prodotto> prodotti; // prodotti e' private perche non voglio che venga modificato dall'esterno
    private readonly string dirCatalogo = "data/catalogo";
    private int prossimoId;

    public ProdottoAdvancedManager(List<Prodotto> Prodotti)
    {
        prodotti = Prodotti;
        prossimoId = 1;
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id >= prossimoId)
            {
                prossimoId = prodotto.Id + 1;
            }
        }
    }

    // metodo per aggiungere
    public void AggiungiProdotto(Prodotto prodotto)
    {
        prodotto.Id = prossimoId;
        prossimoId++;
        prodotti.Add(prodotto); // quella private
    }

    // metodo per visualizzare 
    public List<Prodotto> OttieniProdotti()
    {
        return prodotti;
    }

    // metodo per cercare un prodotto 
    public Prodotto TrovaProdotto(int id)
    {
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                return prodotto;
            }
        }
        return null;
    }

    // metodo per modificare il prodotto
    public void AggiornaProdotto(int id, Prodotto nuovoProdotto)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotto.Nome = nuovoProdotto.Nome;
            prodotto.Prezzo = nuovoProdotto.Prezzo;
            prodotto.Giacenza = nuovoProdotto.Giacenza;
            prodotto.Categoria = nuovoProdotto.Categoria;

            //? quindi va a cambiare quello che c'è dentro la lista come un ref?
            //? perché qui no?

        }
    }

    // metodo per eliminare un prodotto
    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id); // salvo il prodotto nella variabile se lo trovo, se non lo trova prodotto = null
        if (prodotto != null) // se lo trova
        {
            string[] files = Directory.GetFiles(dirCatalogo); // salvo l'elenco di file nella cartella 
            foreach (string file in files) // per ogni file nella cartella 
            {
                string readJsonData = File.ReadAllText(file); // leggo il contenuto del file 
                Prodotto prodottoTemporaneo = JsonConvert.DeserializeObject<Prodotto>(readJsonData)!; // lo deserializzo in un prodotto temporaneo
                if (prodottoTemporaneo.Id == id) // se l'id del prodotto temporaneo è uguale all'id inserito dall'utente
                {
                    File.Delete(file); // elimina il file 
                }
            }
            prodotti.Remove(prodotto); // rimuovi il prodotto dalla lista runtime
        }
    }
}
