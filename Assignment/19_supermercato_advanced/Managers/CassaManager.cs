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
        cassa.Acquisti = new List<StoricoAcquisti>();
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
        _casse = repoCasse.CaricaCasse();
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

    public bool GeneraScontrino(List<ProdottoCarrello> prodotti, decimal totaleSpesa, int numeroCassa, string data, int purchaseNumero)
    {
        try
        {
            string path = "data/scontrini";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string pathScontrino = Path.Combine(path, $"{purchaseNumero}.txt");
            // File.Create(pathScontrino).Close();
            string[] linesPart1 = {
                " ",
                " ",
                " ",
                "SUPERMERCATO ADVANCED",
                "DI TEFH33",
                "VIA BRACELLI 33",
                " ",
                "DOCUMENTO COMMERCIALE",
                "di vendita o prestazione",
                " ",
                $"{"DESCRIZIONE",-28}{"PREZZO"}",
                " "
            };
            List<string> linesTemp = new List<string>();
            foreach (var prodotto in prodotti)
            {
                linesTemp.Add($"x{prodotto.Quantita} {prodotto.Nome,-26} {"€" + prodotto.Prezzo.ToString("F2")}");
            };

            string[] linesPart2 = linesTemp.ToArray();

            // File.AppendAllText(pathScontrino, $"\t\t{prodotto.Nome,-28}{prodotto.Prezzo.ToString("F2"),-10}\n");

            string[] linesPart3 = {
                $"------------------------------------",
                $"{"TOTALE",-29}{"€"+totaleSpesa.ToString("F2")}",
                " ",
                $"CASSA NUMERO: {numeroCassa}",
                $"{data}",
                $"DOCUMENTO N. {purchaseNumero.ToString()}"
            };


            // Larghezza fissa della riga (ad esempio, 50 caratteri)
            int lineWidth = 50;

            string[] scontrino = linesPart1.Concat(linesPart2).Concat(linesPart3).ToArray();

            using (StreamWriter writer = new StreamWriter(pathScontrino))
            {
                foreach (string line in scontrino)
                {
                    // Calcolo degli spazi a sinistra per centrare la stringa
                    int padding = (lineWidth - line.Length) / 2;
                    string centeredLine = line.PadLeft(padding + line.Length).PadRight(lineWidth);
                    writer.WriteLine(centeredLine);
                }
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

}

