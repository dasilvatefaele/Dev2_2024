using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class CategoriaManager
{
    private List<Categoria> _categoria; // prodotti e' private perche non voglio che venga modificato dall'esterno
    private readonly string dirCategorie = "data/categorie";
    private readonly string filePath = "categorie.json";
    private int prossimoId;

    public CategoriaManager(List<Categoria> Categoria)
    {
        _categoria = Categoria;
        prossimoId = 1;
        foreach (var items in _categoria)
        {
            if (items.ID >= prossimoId)
            {
                prossimoId = items.ID + 1;
            }
        }
    }

    // metodo per aggiungere
    public void AggiungiCategoria(Categoria categoria)
    {
        categoria.ID = prossimoId;
        prossimoId++;
        _categoria.Add(categoria); // quella private
    }

    // metodo per visualizzare 
    public List<Categoria> OttieniCategoria()
    {
        return _categoria;
    }

    // metodo per cercare un prodotto 
    public Categoria TrovaCategoria(int id)
    {
        foreach (var item in _categoria)
        {
            if (item.ID == id)
            {
                return item;
            }
        }
        return null;
    }

    // metodo per modificare il prodotto
    public void AggiornaCategoria(int id, Categoria nuovaCategoria)
    {
        var categoria = TrovaCategoria(id);
        if (categoria != null)
        {
            categoria.Name = nuovaCategoria.Name;
            //? quindi va a cambiare quello che c'è dentro la lista come un ref?
        }
    }

    // metodo per eliminare un prodotto
    public void EliminaCategoria(int id)
    {
        var categoria = TrovaCategoria(id); // salvo il prodotto nella variabile se lo trovo, se non lo trova prodotto = null
        if (categoria != null) // se lo trova
        {

            _categoria.Remove(categoria);

            // string[] files = Directory.GetFiles(dirCategorie); // salvo l'elenco di file nella cartella 
            // foreach (string file in files) // per ogni file nella cartella 
            // {
            //     string readJsonData = File.ReadAllText (file); // leggo il contenuto del file 
            //     Prodotto prodottoTemporaneo = JsonConvert.DeserializeObject<Prodotto>(readJsonData)!; // lo deserializzo in un prodotto temporaneo
            //     if (prodottoTemporaneo.Id == id) // se l'id del prodotto temporaneo è uguale all'id inserito dall'utente
            //     {
            //         File.Delete(file); // elimina il file 
            //     }
            // }
            // prodotti.Remove(prodotto); // rimuovi il prodotto dalla lista runtime
        }
    }
}
