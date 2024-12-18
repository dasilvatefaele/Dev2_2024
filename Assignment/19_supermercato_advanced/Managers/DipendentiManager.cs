using Newtonsoft.Json;

public class DipendentiManager
{
    private readonly string dirDipendenti = "data/dipendenti";
    public List<Dipendente> dipendenti;
    public DipendentiRepository repositoryDipendenti;
    private int prossimoId;

    public DipendentiManager(List<Dipendente> Dipendenti)
    {
        dipendenti = Dipendenti;
        repositoryDipendenti = new DipendentiRepository();
        prossimoId = 1;
        foreach (var dipendente in dipendenti)
        {
            if (dipendente.Id >= prossimoId)
            {
                prossimoId = dipendente.Id + 1;
            }
        }
    }
    // public Dipendente CreaDipendente()
    // {
    //     Dipendente nuovoDipendente = new Dipendente();

    //     nuovoDipendente.Username = InputManager.LeggiStringa("Username del nuovo dipendente: ");
    //     nuovoDipendente.Ruolo = InputManager.LeggiStringa("Ruolo: ");
    //     nuovoDipendente.Id = AssegnaId(dipendenti);
    //     Console.WriteLine($"Nuovo dipendente creato! Username:{nuovoDipendente.Username}, Ruolo: {nuovoDipendente.Ruolo}, ID: {nuovoDipendente.Id}");
    //     return nuovoDipendente;
    // }

    public void AggiungiDipendente(Dipendente dipendente)
    {
        dipendente.Id = prossimoId;
        prossimoId++;
        dipendenti.Add(dipendente); // quella private
    }

    public int AssegnaId(List<Dipendente> elencoDipendenti)
    {
        int prossimoId = 1;
        foreach (var dipendente in elencoDipendenti)
        {
            if (dipendente.Id >= prossimoId)
            {
                prossimoId = dipendente.Id + 1;
            }
        }
        return prossimoId;
    }

    public void EliminaDipendente(int Id)
    {
        Dipendente dipendenteDaEliminare = TrovaDipendentePerId(Id);
        if (dipendenteDaEliminare != null)
        {
            string[] files = Directory.GetFiles(dirDipendenti); // salvo l'elenco di file nella cartella 
            foreach (string file in files) // per ogni file nella cartella 
            {
                string readJsonData = File.ReadAllText(file); // leggo il contenuto del file 
                Dipendente dipendente = JsonConvert.DeserializeObject<Dipendente>(readJsonData)!; // lo deserializzo in un prodotto temporaneo
                if (dipendente.Id == Id) // se l'id del prodotto temporaneo è uguale all'id inserito dall'utente
                {
                    File.Delete(file); // elimina il file 
                                       // repo.SalvaProdotti(prodotti);
                }
            }
            dipendenti.Remove(dipendenteDaEliminare); ; // rimuovi il prodotto dalla lista runtime
        }
    }

    public Dipendente TrovaDipendentePerId(int Id)
    {
        bool trovato = false;
        foreach (var dipendente in dipendenti)
        {
            if (dipendente.Id == Id)
            {
                trovato = true;
                return dipendente;
            }
        }
        if (!trovato)
        {
            Console.WriteLine("Cliente non trovato;");
            return null;
        }
        return null;
    }

    public void AggiornaDipendente(int Id)
    {
        Dipendente dipendente = TrovaDipendentePerId(Id);
        if (dipendente == null)
        {
            Console.WriteLine("Dipendente non trovato.");
        }
        else
        {
            dipendente.Username = InputManager.LeggiStringa("Username > ");
            dipendente.Ruolo = InputManager.LeggiStringa("Ruolo > ");
            repositoryDipendenti.SalvaDipendenti(dipendenti);
        }

    }
}