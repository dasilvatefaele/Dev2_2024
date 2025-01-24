using System.Data.SQLite;
// comando installazione pacchetto System.Data.SQLite
// dotnet add package System.Data.SQLite


string path = @"database.db"; // la rotta del file del database

if (!File.Exists(path)) // se il file del database non esiste
{
    SQLiteConnection.CreateFile(path); // crea il file del database

    // crea la connessione al database la versione 3 è un indicazione della versione del database e può esser personalizzata
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;");

    connection.Open(); // apre la connessione al database

    string sql = @"
                CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0));
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto1', 1, 10);
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto2', 2, 20);
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto3', 3, 30);
                ";
    // opure insert multiplo cosi
    // INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto1', 1, 10), ('prodotto2', 2, 20), ('prodotto3', 3, 30);

    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database sql è la stringa che contiene il comando sql
    command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database nonquery significa che non si aspetta un risultato
    connection.Close(); // chiude la connessione al database
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
        InserisciProdotto();
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
        ModificaProdotto();
    }
    else if (scelta == "4")
    {
        Console.Clear(); // pulisco la console
        VisualizzaProdotti();
        Console.WriteLine("");
        EliminaProdotto();
    }
    else if (scelta == "0")
    {
        break;
    }
}

static void InserisciProdotto()
{
    Console.WriteLine("inserisci il nome del prodotto");
    string nome = Console.ReadLine();
    Console.WriteLine("inserisci il prezzo del prodotto");
    string prezzo = Console.ReadLine();
    Console.WriteLine("inserisci la quantità del prodotto");
    string quantita = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
    connection.Open(); // apre la connessione al database
    string sql = $"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}', {prezzo}, {quantita})";
    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
    command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
    connection.Close(); // chiude la connessione al database
}

static void VisualizzaProdotti()
{
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
    connection.Open(); // apre la connessione al database
    string sql = "SELECT * FROM prodotti";
    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
    SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e
                                                       // salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
    while (reader.Read()) // legge i dati dal reader finche ce ne sono
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
        reader.Close(); // chiude il reader se non è già chiuso
    }
    connection.Close(); // chiude la connessione al database
}

static void ModificaProdotto()
{
    Console.WriteLine("inserisci il nome del prodotto da modificare");
    string nome = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
    connection.Open(); // apre la connessione al database
    string sql = $"SELECT * FROM prodotti WHERE nome = '{nome}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
    SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e
                                                       // salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
    if (reader.Read())
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
        Console.WriteLine("inserisci il nuovo nome del prodotto");
        string nuovoNome = Console.ReadLine();
        Console.WriteLine("inserisci il nuovo prezzo del prodotto");
        string nuovoPrezzo = Console.ReadLine();
        Console.WriteLine("inserisci la nuova quantità del prodotto");
        string nuovaQuantita = Console.ReadLine();
        
        sql = $"UPDATE prodotti SET nome = '{nuovoNome}', prezzo = {nuovoPrezzo}, quantita = {nuovaQuantita} WHERE nome = '{nome}'";
        command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
        reader.Close(); // chiude il reader se non è già chiuso
    }
    connection.Close(); // chiude la connessione al database
}

static void EliminaProdotto()
{
    Console.WriteLine("inserisci il nome del prodotto");
    string nome = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
    connection.Open(); // apre la connessione al database
    string sql = $"DELETE FROM prodotti WHERE nome = '{nome}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
    command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
    connection.Close(); // chiude la connessione al database
}