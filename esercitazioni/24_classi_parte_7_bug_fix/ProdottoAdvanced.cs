using System.ComponentModel.Design;

public class ProdottoAdvanced
{
    // private static ProdottoRepository localRepository = new ProdottoRepository();
    // private static List<ProdottoAdvanced> prodotti = localRepository.CaricaProdotti();

    // private static int ultimoId = 0; // Campo statico per tracciare l'ultimo ID generato
                                     // è privata perché non voglio che venga modificata dall'esterno
                                     // è static perché voglio che sia condiviso con tutte le istanze della classe
    private int id; // campo privato
    
    public int Id 
    { 
        get { return id; } 
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il valore dell'ID deve essere maggiore di zero.");
            }
            id = value; 
        }
    }


    // public int Id 
    // { 
    //     get { return id; } 
    //     set { id = value; } // Rende il setter privato per impedire modifiche manuali all'Id
    //                                 // value è definito implicitamente dal compilatore 
    //                                 // e rappresenta il valore assegnato alla proprietà
    //                                 // value è una variabile locale e non può essere utilizzata nel setter
    //                                 // value è quello che si chiama parametro implicito, 
    //                                 // cioè non lo devo dichiarare io ma è già dichiarato dal compilatore

        
    // }

    // public ProdottoAdvanced()
    // {
    //     Id = GeneraId();
    // }

    // Metodo statico per generare un ID progressivo
    // è statico perché in questo caso mi serve che sia condiviso tra tutte le istanze della classe
    // in modo che l'ID sia univoco per ogni prodotto
    // private static int GeneraId()
    // {
    //     // foreach (var prodotto in prodotti)
    //     // {
    //     //     ultimoId = prodotto.Id;
    //     // }
    //     ultimoId++;
    //     return ultimoId;
    // }

    private bool active = true;

    public bool Active
    {
        get { return active; }
        set { active = value; }
    }

    private string nomeProdotto;  // campo privato
    public string NomeProdotto 
    { 
        get { return nomeProdotto; }
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Il nome del prodotto non può essere vuoto.");
            }
            nomeProdotto = value;
        } 
    }
    
    private decimal prezzoProdotto;  // campo privato
    public decimal PrezzoProdotto 
    { 
        get {return prezzoProdotto;}
        set 
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il prezzo deve essere maggiore di zero");
            }
            prezzoProdotto = value;
        }
    }
    private int giacenzaProdotto;  // campo privato
    public int GiacenzaProdotto 
    { 
        get { return giacenzaProdotto;}
        set 
        { 
            if (value <= 0)
            {
                throw new ArgumentException("La giacenza non può essere negativa");
            }
            giacenzaProdotto = value;
        }
    }

    // Costruttore per generare automaticamente l'Id
    // quando viene creato un nuovo oggetto ProdottoAdvaned con il costruttore vuoto (senza parametri)
    // viene chiamato questo costruttore (cistruttore di default)
    // che genera un nuovo ID e lo assegna all'oggetto usando il metodo GeneraId
    // invece gli altri parametri (NomeProdotto, GiacenzaProdotto, PrezzoProdotto), vengono inizializzati con valori di default (null, 0,0)
    // ed in seguito vengono assegnati i valori inseriti dall'utente
}
