public class ProdottoAdvancedManager
{  
    private List<ProdottoAdvanced> prodotti; // prodotti e' private perche non voglio che venga modificato dall'esterno
    
    // public ProdottoAdvancedManager()
    public ProdottoAdvancedManager(List<ProdottoAdvanced> prodotti)
    {
        // versione Tamer
        this.prodotti = prodotti; //? perché funziona?


        // versione personale
        // ProdottoRepository repository = new ProdottoRepository();
        // prodotti = repository.CaricaProdotti();

        // versione Prof.
        // if (prodotti != null)
        // {
        //     prodotti = prodottiIniziali;
        // }
        // else
        // {
        //     prodotti = new List<ProdottoAdvanced>();
        // }

        // inizializzo la lista di prodotti nel costruttore pubblico in modo che sia accessibile all'esterno
        // questo new è necessario affinchè dal dominio privato la classe possa comunicare all'esterno i dati aggiornati/manipolati
        // un modo per rendere pubblico un dato privato
    }

    // metodo per aggiungere
    public void AggiungiProdotto (ProdottoAdvanced prodotto)
    {
        prodotti.Add(prodotto); // quella private

    }

    // metodo per visualizzare 
    public List<ProdottoAdvanced> OttieniProdotti()
    {
        return prodotti;
    }

    // metodo per cercare un prodotto 
    public ProdottoAdvanced TrovaProdotto(int id)
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
    public void AggiornaProdotto(int id, ProdottoAdvanced nuovoProdotto)
    {
        var prodotto = TrovaProdotto (id);
        if (prodotto != null)
        {
            prodotto.NomeProdotto = nuovoProdotto.NomeProdotto;
            prodotto.PrezzoProdotto = nuovoProdotto.PrezzoProdotto;
            prodotto.GiacenzaProdotto = nuovoProdotto.GiacenzaProdotto;
        }
    }

    // metodo per eliminare un prodotto
    public void EliminaProdotto (int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            // prodotti.Remove(prodotto);
            foreach(var item in prodotti)
            {
                if (item == prodotto)
                {
                    item.Active = false;
                }
            }

        }
    }


    public int GetLastId (List<ProdottoAdvanced> prodotti)
    {
        int max = 0;
        foreach(var item in prodotti)
        {
            max = item.Id;
            if (item.Id > max)
            {
                max = item.Id;
            }
        }
        return max;
    }
}
