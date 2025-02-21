/* dipendenze: */

using System.Net.Sockets;
// da le funzionalità per la comunicazione in rete

using System.Text;
// da le funzionalità per la gestione delle stringhe che vengono inviate/ricevute

public class Client
{
    // metodo per stabilire la connessione con il server
    // argomenti: indirizzo ip del server e la porta
    // su cui il server è in ascolto (cioè sulla quale opera). Usiamo il protocollo TCP

    public void StartClient(string serverIP, int port)
    {
        using (var client = new TcpClient(serverIP, port))
        // TcpClient è la classe che rappresenta un client TCP cioè un client che si connette a un server tramite protocollo TCP

        using (var stream = client.GetStream())
        // restituisce un oggetto NetworkStream
        // che rappresenta il flusso di dati tra client e il server

      
        {
            Console.WriteLine("Connesso al server.");
            string messageToSend = Console.ReadLine();

            while (!string.IsNullOrEmpty(messageToSend))
            {
                byte[] buffer = Encoding.ASCII.GetBytes(messageToSend);
                // converte la stringa in un array di byte

                stream.Write(buffer, 0, buffer.Length);
                // serve indicare al server:
                // memorizza il messaggio
                // indice di partenza [0]
                // indice di fine [buffer.Length]

                messageToSend = Console.ReadLine();
                // legge il messaggio da inviare
            }
        }
    }

    public static void Main (string[] args)
    {
        Client client = new Client();
        // creo un'ostanza della classe Client 
        // in modo da poter chiamare il metodo StartClient

        Console.WriteLine("Inserici l'IP del server: ");
        string serverIP = Console.ReadLine();
        // chiedo l'indirizzo IP del server

        client.StartClient(serverIP, 3000); 
        // avvia il client con l'IP del server e la porta 3000
    }
}
