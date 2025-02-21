# 20/02/2025 parte 2

# Protocollo

Insieme di regole che gestisce la trasmissione di dati.

## Il più classico è il TCP/IP:

Protocollo di rete che permette la connessione tra due computer che utilizza due protocolli

## TCP

Transmission Control Protocol: si occupa trasmissione del messaggio

## IP

Protocollo di rete: identificazione dell'indirizzo del computer tramite schede di rete, normalmente è dinamico

# HTTP (HyperText Transfer Protocol)

Permette di trasmettere documenti html tra un Client e un Server

# HTTPS

HyperText Transfer Protocol Secure.
Ha un layer (strato) aggiuntivo di sicurezza.

# FTP

File Transfer Protocol
Permettono di inviare e riceve file al/dal server.
Protocollo per trasferire i file

# Client FTP

E' uno spazio remoto che permette di salvare i file in remoto, in modo che sia accessibile sempre da qualsiasi computer. I file vengono immagazzinati come in un computer
è un programma simile ad un browser che vede i file

# SMTP

Simple mail transfer protocol

Permette di trasmettere mail tra Client e un Server. Il più complesso di tutti perché protegge la perdita di pacchetti di dati.

# SMTPS

Simple mail transfer protocol secure

# POP3

Protocollo per riceve le mail

# PORTE

#### Porte standard:

Le porte sono in linea di massima maggiormente hardware.

- 3000, 80, 443, 21, 25 ecc...

> Esempi:

| PROTOCOLLO | PORTA |
| ---------- | ----- |
| HTTP       | 80    |
| HTTPS      | 443   |
| FTP        | 21    |
| SMTP       | 25    |
| POP3       | 110   |
| SMTPS      | 550   |
| WEBAPP     | 3000  |

#### EndPoint:

Indirizzi ai quali posso recuperare delle informazioni (il server mi rende disponibile dei dati)

#### PortForwarding:

Permette l'accesso a servizi di rete da remoto (tunneling tra due computer per permettere l'accesso ai servizi di rete da remoto). Negli anni 90', `Naspter` o `SoulSeek` erano applicazione che, sempre passando attraverso un server, permettevano la comunicazione `Peer to Peer`.

---

Attraverso terminale

```bash
ipconfig
```

```
...
Scheda LAN wireless Wi-Fi:

   Suffisso DNS specifico per connessione:
   Indirizzo IPv6 locale rispetto al collegamento . : fe80::2178:1555:8e83:7cdd%9
   Indirizzo IPv4. . . . . . . . . . . . : 192.168.201.16
   Subnet mask . . . . . . . . . . . . . : 255.255.255.0
   Gateway predefinito . . . . . . . . . : 192.168.201.1
```

dove

```
Indirizzo IPv6 locale rispetto al collegamento . : fe80::2178:1555:8e83:7cdd%9
Indirizzo IPv4. . . . . . . . . . . . : 192.168.201.16
```

---

`Indirizzo IPv6` - identifica la scheda della macchina, creato per sopperire alla mancanza di IP

`Indirizzo IPv4` - identifica i computer all'interno di una rete locale (generato da DHCP)

#### DHCP

Dynamic Host Configuration Protocol - Assegna dinamicamente gli indirizzi IP (assegna quelli liberi)

```
Subnet mask . . . . . . . . . . . . . : 255.255.255.0
```

---

`Subnet mask` - serve per ottimizzare l'utilizzo degli indirizzi IP (in caso di )

```
 Gateway predefinito . . . . . . . . . : 192.168.201.1
```

`Gateway predefinito` - Eredita i primi 3 blocchi dell'indirizzo IP.
Viene ricevuto tramite un servizio `DHCP` Dynamic Host Configuration Protocol

`DNS` - trasforma/converte un indirizzo "www.abcd.com" ad un indirizzo numerico

`ISP` - (Internet Server Provider)

`192.168.0.1` o
`192.168.1.1` indirizzo del router

#### NAT

Serve per mappare degli indirizzi (Network Address Translation)

---

# Ping

Serve per testare la comunicazione tra due computer attraverso server.

in questo

```bash
ping 192.168.201.28
```

Risposta

```
Esecuzione di Ping 192.168.201.28 con 32 byte di dati:
Risposta da 192.168.201.28: byte=32 durata=3ms TTL=128
Risposta da 192.168.201.28: byte=32 durata=4ms TTL=128
Risposta da 192.168.201.28: byte=32 durata=3ms TTL=128
Risposta da 192.168.201.28: byte=32 durata=4ms TTL=128

Statistiche Ping per 192.168.201.28:
    Pacchetti: Trasmessi = 4, Ricevuti = 4,
    Persi = 0 (0% persi),
Tempo approssimativo percorsi andata/ritorno in millisecondi:
    Minimo = 3ms, Massimo =  4ms, Medio =  3ms
```

# 21/02/2025

# Chat / Chat Server

Comunicazione attraverso la porta 3000

```## Il più classico è il TCP/IP:

Protocollo di rete che permette la connessione tra due computer che utilizza due protocolli

## TCP

Transmission Control Protocol: si occupa trasmissione del messaggio

## IP

Protocollo di rete: identificazione dell'indirizzo del computer tramite schede di rete, normalmente è dinamico
```

Chat > Program.cs

```cs
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
```

Chat_Server > Program.cs

```cs
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

    public void StartServer(int port)
    {
        listener = new TcpListener (IPAddress.Any, port);
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

            Thread clientThread = new Thread (new ParameterizedThreadStart(HandleClient));
            // crea un nuovo thread per gestire il client connesso

            clientThread.Start(client); 
            // avvia il thread per gestire il client connesso, in questo caso thread
        }
    }

    private void HandleClient (object obj)
    {
        TcpClient client = (TcpClient)obj; 
        // converte l'oggetto passato come argomento 
        // in un oggetto TcpClient

        NetworkStream stream = client.GetStream();
        // ottiene il flusso di dati tra l client e il server networkstream

        byte[] buffer = new byte[1024];
        // creiamo un buffer per convertire la stringa in byte

        int byteCount; 
        // memorizza il numero di byte che sono stati letti.
        // while(byteCount != 0)

        while ((byteCount = stream.Read(buffer, 0 , buffer.Length)) != 0)
        {
            string message = Encoding.ASCII.GetString(buffer, 0, byteCount);
            // converto i byte in una stringa

            Console.WriteLine($"Messaggio ricevuto: {message}");

            Broadcast(message);
            // Invia il messaggio a tutti i client connessi
        }
        client.Close();
    }

    private List<TcpClient> clients = new List<TcpClient>();

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

    public static void Main (string[] args)
    {
        Server server = new Server();
        // creo un'istanza della classe Server

        server.StartServer(3000);
        // avvio il server sulla porta 3000
    }
}```
---

# Definizioni

#### THREAD

Canale di trasmissione - Flusso di esecuzione <u>separato</u>.

#### DELEGATO

Il delegato è l'argomento (metodo) in questo caso un costruttore. 

```cs
new ParameterizedThread(HandleClient)
```


Metodo che accetta un metodo come argomento


