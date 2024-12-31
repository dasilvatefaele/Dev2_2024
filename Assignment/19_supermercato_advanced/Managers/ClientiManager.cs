using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class ClientiManager
{
    private readonly string dirClienti = "data/clienti";
    public List<Cliente> clienti;
    public ClientiRepository repositoryClienti;
    public Cliente nuovoCliente;
    //public ClientiRepository repoClienti = new ClientiRepository();

    public List<Cliente> OttieniClienti()
    {
        return clienti;
    }

    public ClientiManager(List<Cliente> Clienti)
    {
        clienti = Clienti;
        repositoryClienti = new ClientiRepository();
        nuovoCliente = new Cliente();
    }
    public Cliente CreaCliente(string username)
    {
        nuovoCliente = CheckCliente(username);
        if (nuovoCliente != null)
        {
            Console.WriteLine($"BENTORNATO {nuovoCliente.Username}!\n");
            return nuovoCliente;
        }
        else
        {
            Console.WriteLine($"BENVENUTO {username}! Un nuovo account è stato creato!\n");
            nuovoCliente = new Cliente
            {
                Username = username,
                Id = AssegnaId(clienti),
                Cart = new Carrello
                {
                    Cart = new List<ProdottoCarrello>(),
                    Completed = false
                },
                StoricoAcquisti = new List<StoricoAcquisti>(),
                PercentualeSconto = 0,
                Credito = 200.00m
            };

            clienti.Add(nuovoCliente);
            repositoryClienti.SalvaClienti(nuovoCliente);
            return nuovoCliente;
        }
        return null;
    }


    public Cliente CheckCliente(string username)
    {
        if (Directory.Exists(dirClienti))
        {
            string[] files = Directory.GetFiles(dirClienti); // salvo l'elenco di file nella cartella 
            foreach (string file in files) // per ogni file nella cartella 
            {
                string readJsonData = File.ReadAllText(file); // leggo il contenuto del file 
                Cliente cliente = JsonConvert.DeserializeObject<Cliente>(readJsonData)!; // lo deserializzo in un prodotto temporaneo
                if (cliente.Username == username) // se l'id del prodotto temporaneo è uguale all'id inserito dall'utente
                {
                    return cliente;
                }
            }
        }
        else
        {
            Directory.CreateDirectory(dirClienti);
        }

        return null;

    }
    public int AssegnaId(List<Cliente> elencoClienti)
    {
        int prossimoId = 1;
        foreach (var cliente in elencoClienti)
        {
            if (cliente.Id >= prossimoId)
            {
                prossimoId = cliente.Id + 1;
            }
        }
        return prossimoId;
    }

    public void EliminaCliente(int Id)
    {
        Cliente dipendenteDaEliminare = TrovaClientePerId(Id);
        if (dipendenteDaEliminare != null)
        {
            string[] files = Directory.GetFiles(dirClienti); // salvo l'elenco di file nella cartella 
            foreach (string file in files) // per ogni file nella cartella 
            {
                string readJsonData = File.ReadAllText(file); // leggo il contenuto del file 
                Cliente cliente = JsonConvert.DeserializeObject<Cliente>(readJsonData)!; // lo deserializzo in un prodotto temporaneo
                if (cliente.Id == Id) // se l'id del prodotto temporaneo è uguale all'id inserito dall'utente
                {
                    File.Delete(file); // elimina il file 
                                       // repo.SalvaProdotti(prodotti);
                }
            }
            clienti.Remove(dipendenteDaEliminare); ; // rimuovi il prodotto dalla lista runtime
        }
    }

    public Cliente TrovaClientePerId(int Id)
    {
        bool trovato = false;
        foreach (var cliente in clienti)
        {
            if (cliente.Id == Id)
            {
                trovato = true;
                return cliente;
            }
        }
        if (!trovato)
        {
            Console.WriteLine("Cliente non trovato;");
            return null;
        }
        return null;
    }

    public void AggiornaCliente(int Id)
    {
        Cliente cliente = TrovaClientePerId(Id);
        if (cliente == null)
        {
            Console.WriteLine("Cliente non trovato.");
        }
        else
        {
            cliente.Username = InputManager.LeggiStringa("Username > ");
            // cliente.Ruolo = InputManager.LeggiStringa("Ruolo > ");
            repositoryClienti.SalvaClienti(cliente);
        }

    }
}
