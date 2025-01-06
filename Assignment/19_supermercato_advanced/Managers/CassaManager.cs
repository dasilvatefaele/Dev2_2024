using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class CassaManager
{

    private List<Cassa> _casse;
    private int prossimoId;
    CasseRepository repoCasse;

    private readonly string dirCasse = "data/casse";


    public CassaManager(List<Cassa> casse)
    {
        repoCasse = new CasseRepository();
        _casse = casse;
        prossimoId = 1;
        foreach (var items in _casse)
        {
            if (items.Id >= prossimoId)
            {
                prossimoId = items.Id + 1;
            }
        }
    }

    public Cassa CreaNuovaCassa(Cassa cassa)
    {
        cassa.Id = prossimoId;
        prossimoId++;
        _casse.Add(cassa); // quella private
        repoCasse.SalvaCassaSingola(cassa);
        return cassa;
    }

    // public void AggiungiPurchase(Purchase purchase)
    // {
    //     _purchases.Add(purchase); // quella private
    //     repoPurchase.SalvaPurchaseSingolo(purchase);
    // }

    public List<Cassa> OttieniCasse()
    {
        return _casse;
    }

    public Cassa TrovaCassaPerId(int Id)
    {
        bool trovato = false;
        foreach (var cassa in _casse)
        {
            if (cassa.Id == Id)
            {
                trovato = true;
                return cassa;
            }
        }
        if (!trovato)
        {
            Color.Red();
            Console.WriteLine($"La cassa Numero {Id} non esiste.");
            Color.Reset();
            return null;
        }
        return null;
    }

    public bool EliminaCassaPerId(int id)
    {
        Cassa cassaDaEliminare = TrovaCassaPerId(id);
        if (cassaDaEliminare != null)
        {
            string[] files = Directory.GetFiles(dirCasse); // salvo l'elenco di file nella cartella 
            foreach (string file in files) // per ogni file nella cartella 
            {
                string readJsonData = File.ReadAllText(file); // leggo il contenuto del file 
                Cassa cassa = JsonConvert.DeserializeObject<Cassa>(readJsonData)!; // lo deserializzo in un prodotto temporaneo
                if (cassa.Id == id) // se l'id del prodotto temporaneo è uguale all'id inserito dall'utente
                {
                    File.Delete(file); // elimina il file 
                }
            }
            _casse.Remove(cassaDaEliminare);
            return true;
        }
        return false;
    }
}

