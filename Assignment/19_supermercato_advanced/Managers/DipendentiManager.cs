using System.Diagnostics.Tracing;
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

    public void AggiungiDipendente(Dipendente dipendente)
    {
        dipendente.Id = prossimoId;
        prossimoId++;
        dipendenti.Add(dipendente); // quella private
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

    public Dipendente TrovaDipendentePerUsername(string username)
    {
        bool trovato = false;
        foreach (var dipendente in dipendenti)
        {
            if (dipendente.Username == username)
            {
                trovato = true;
                return dipendente;
            }
        }
        if (!trovato)
        {
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
            Color.DarkYellow();
            bool risposta = InputManager.LeggiConferma("Modificare Username?");
            if (risposta)
            {
                dipendente.Username = InputManager.LeggiStringa("Username > ");
            }
            risposta = InputManager.LeggiConferma("Modificare Ruolo?");
            if (risposta)
            {
                Console.WriteLine("Nuobo ruolo del dipendente:");
                Color.Reset();

                Console.WriteLine("\n1. Cassiere\n2. Magazziniere\n3. Amministratore");
                string ruolo = "";

                Color.DarkGreen();
                int selezionaRuolo = InputManager.LeggiIntero("\n> ", 1, 3);

                switch (selezionaRuolo)
                {
                    case 1:
                        ruolo = "Cassiere";
                        break;
                    case 2:
                        ruolo = "Magazziniere";
                        break;
                    case 3:
                        ruolo = "Amministratore";
                        break;
                }
                dipendente.Ruolo = ruolo;

            }
            repositoryDipendenti.SalvaDipendenti(dipendenti);
        }

    }

    public Dipendente AccediComeDipendente(string username)
    {


        var nuovoDipendente = TrovaDipendentePerUsername(username);

        if (nuovoDipendente != null)
        {
            return nuovoDipendente;
        }
        else
        {
            return null;

        }
    }



}