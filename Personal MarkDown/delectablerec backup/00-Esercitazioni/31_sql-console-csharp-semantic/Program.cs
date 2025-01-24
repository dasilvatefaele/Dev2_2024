using System.Data.SQLite;
// comando per installare il pacchetto System.Data.SQLite
// dotnet add package System.Data.SQLite

string path = @"database.db"; // il file deve essere nella stessa cartella del programma
if (!File.Exists(path))
{
    SQLiteConnection.CreateFile(path); // crea il file del database se non esiste
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"); // crea la connessione al database se non esiste utilizzando il file appena creato
    connection.Open(); // apre la connessione al database se non è già aperta

    string sql = @"
                    CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                    CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT,
                    prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER,
                    FOREIGN KEY (id_categoria) REFERENCES categorie(id));
                    INSERT INTO categorie (nome) VALUES ('categoria1'), ('categoria2'), ('categoria3');
                    INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('prodotto1', 1, 10, 1), ('prodotto2', 2, 20, 2), ('prodotto3', 3, 30, 3);
                    ";

    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database se non esiste
    command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database se non esiste
    connection.Close(); // chiude la connessione al database se non è già chiusa
}

while (true)
{
    Console.WriteLine("1 - inserisci prodotto");
    Console.WriteLine("2 - visualizza prodotti");
    Console.WriteLine("3 - modifica prodotto");
    Console.WriteLine("4 - elimina prodotto");
    Console.WriteLine("0 - esci");
    Console.WriteLine("scegli un'opzione");
    string scelta = Console.ReadLine()!;
    if (scelta == "1")
    {
        Console.Clear(); // pulisco la console
        // InserisciProdotto();
    }
    else if (scelta == "2")
    {
        Console.Clear(); // pulisco la console
        VisualizzaProdotti();
    }
    else if (scelta == "3")
    {
        Console.Clear(); // pulisco la console
        VisualizzaProdotti();
        Console.WriteLine("");
        // ModificaProdotto();
    }
    else if (scelta == "4")
    {
        Console.Clear(); // pulisco la console
        VisualizzaProdotti();
        Console.WriteLine("");
        // EliminaProdotto();
    }
    else if (scelta == "0")
    {
        break;
    }
}

static void VisualizzaProdotti()
{
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione di nuovo perché è stata chiusa alla fine del while in modo da poter visualizzare i dati aggiornati
connection.Open(); // apre la connessione al database

string sql = @"SELECT prodotti.id, prodotti.nome, prodotti.prezzo, prodotti.quantita,
              categorie.nome AS nome_categoria FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id
              ";
              // AS nome_categoria serve per rinominare la colonna in modo da poterla visualizzare con un nome diverso
              // JOIN serve per unire due tabelle in base a una condizione
              // la condizione è che il campo id_categoria della tabella prodotti sia uguale al campo id della tabella categorie

SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader 

while (reader.Read())
{
    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, categoria: {reader["nome_categoria"]}");
    reader.Close(); // chiude il reader se non è già chiuso
}
connection.Close(); // chiude la connessione al database se non è già chiusa
}