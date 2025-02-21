/* dipendenze: */

using System.Net;
using System.Net.Sockets;
// da le funzionalità per la comunicazione in rete

using System.Text;
// da le funzionalità per la gestione delle stringhe 
// che vengono inviate/ricevute

using System.Threading;
// da le funzionalità per la gestione dei 
// thread: flussi di esecuzione separati

public class Server
{
    private TcpListener listener;
    // oggetto che rappresenta un serve TCP
    private List<TcpClient> clients = new List<TcpClient>();

    private object lockObject = new Object();
    // proprietà Lock per evitare problemi di concorrenza


    public static void Main(string[] args)
    {
        Server server = new Server();
        // creo un'istanza della classe Server

        server.StartServer(3000);
        // avvio il server sulla porta 3000
    }

    public void StartServer(int port)
    {
        listener = new TcpListener(IPAddress.Any, port);
        // avrà bisogno degli IP che si connettono al server
        // bisogna indicare quali IP vanno bene (oppure tutti gli IP)
        // IPAddress.Any indica che il server accetta le connessioni
        // su tutte le interfacce di rete

        listener.Start();
        // avvia il server

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            // accetta una connessione da un client e
            // restituisce un oggetto TcpClient che rappresenta
            // il client connesso

            lock (lockObject)
            {
                //lock è una parola chiave che consente di sincronizzare 
                // l'accesso a una risorsa condivisa 
                // tra più thread lockObject e un oggetto
                clients.Add(client);
            }

            Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
            // crea un nuovo thread per gestire il client connesso

            clientThread.Start(client);
            // avvia il thread per gestire il client connesso, in questo caso thread
        }
    }

    private void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj;
        // converte l'oggetto passato come argomento 
        // in un oggetto TcpClient

        NetworkStream stream = client.GetStream();
        // ottiene il flusso di dati tra l client e il server networkstream

        byte[] buffer = new byte[1024];
        // creiamo un buffer per convertire la stringa in byte


        try
        {
            int byteCount;
            // memorizza il numero di byte che sono stati letti.
            // while(byteCount != 0)

            while ((byteCount = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string message = Encoding.ASCII.GetString(buffer, 0, byteCount);
                // converto i byte in una stringa

                Console.WriteLine($"Messaggio ricevuto: {message}");

                Broadcast(message);
                // Invia il messaggio a tutti i client connessi
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Un client si è disconnesso");
        }
        finally
        {
            lock (lockObject)
            {
                clients.Remove(client);
            }
        }
        client.Close();
    }

    private void Broadcast(string message)
    {
        foreach (TcpClient client in clients) // per ogni client connesso
        {
            NetworkStream stream = client.GetStream();
            // ottiene il flusso di dati tra client e server

            byte[] buffer = Encoding.ASCII.GetBytes(message);
            // converte la stringa in byte

            stream.Write(buffer, 0, buffer.Length);
            // invia il messaggio al client
        }
    }
}