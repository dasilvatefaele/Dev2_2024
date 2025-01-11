using System.Data.SQLite;


// rotta del file database
string path = "database.db";

Console.Clear();

// se non esiste crealo
if (!File.Exists(path))
{
    // crea l file el database
    SQLiteConnection.CreateFile(path);
    // creo la connessione al database, la versione 3 è un indicicazione della versione del database
    // e può essere personalizzata
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;");

    connection.Open(); // apre la connessione

    string sql = @"
                CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, prezzo REAL, quantita INTEGER);
                INSERT INTO prodotti (id, nome,prezzo,quantita) VALUES (0,'default',0,0);
                ";

    // creiamo il comando per eseguire lo script su quella connessione a quel database
    SQLiteCommand command = new SQLiteCommand(sql, connection);

    // esegue la Query senza ricevere un ritorno (.ExecuteNonQuery)
    command.ExecuteNonQuery();

    //chiudiamo la connessione (! MOLTO IMPORTANTE: ogni azione  )

    connection.Close();
}

bool run = true;
while (run)
{
    Console.WriteLine("1. Inserisci prodotto");
    Console.WriteLine("2. Visualizza prodott1");
    Console.WriteLine("3. Elimina prodotti");
    Console.WriteLine("4. Modifica prodotti");
    Console.WriteLine("0. Esci");

    string scelta = InputManager.LeggiIntero("\n> ", 0, 4).ToString();

    switch (scelta)
    {
        case "1":
            Console.Clear();
            InserisciProdotto(path);
            break;
        case "2":
            Console.Clear();
            VisualizzaProdotti(path);
            break;
        case "3":
            Console.Clear();
            VisualizzaProdotti(path);
            EliminaProdotti(path);
            break;
        case "4":
            Console.Clear();
            VisualizzaProdotti(path);
            ModificaProdotto(path);
            break;
        case "0":
            run = false;
            break;
    }

}

// CREA - VISUALIZZA - MODIFICA - ELIMINA (O CRUD)

static void InserisciProdotto(string path)
{


    //acquisizione
    string nomeNuovoProdotto = InputManager.LeggiStringa("Nome > ");
    string prezzoNuovoProdotto = InputManager.LeggiReal("Prezzo > ");
    string quantitaNuovoProdotto = InputManager.LeggiStringa("Quantita > ");

    // creo la connessione
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3");

    // apro la connessione
    connection.Open();

    // creo la query
    string sql = $"INSERT INTO prodotti (nome,prezzo,quantita) VALUES ('{nomeNuovoProdotto}',{prezzoNuovoProdotto},{quantitaNuovoProdotto})";

    // creo l'oggetto per eseguire il comando
    SQLiteCommand command = new SQLiteCommand(sql, connection);

    // eseguo il comando
    command.ExecuteNonQuery();

    // chiudo la connessione
    connection.Close();

    Console.WriteLine();
}

static void VisualizzaProdotti(string path)
{



    // creo la connessione
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3");

    // apro la connessione
    connection.Open();

    // creo la query
    string sql = $"SELECT * FROM prodotti WHERE (id > 0)";

    // creo l'oggetto per eseguire il comando
    SQLiteCommand command = new SQLiteCommand(sql, connection);

    // eseguo il comando (QUESTA VOLTA ABBIAMO UN RITORNO)
    // quindi usiamo .ExecuteReader(); che esegue il comando sulla connessione al database 
    // e salva i dati in reader che è un oggetto di tipo SQLiteDataReader
    SQLiteDataReader reader = command.ExecuteReader();

    // finché legge
    while (reader.Read())
    {
        Console.WriteLine($"id: {reader["id"]}, nome {reader["nome"]}, prezzo {reader["prezzo"]}, quantita {reader["quantita"]}");
    }

    // chiudo la connessione
    reader.Close();
    connection.Close();

    Console.WriteLine();
}

static void EliminaProdotti(string path)
{



    int idDaEliminare = InputManager.LeggiIntero("ID da eliminare > ");

    string sql = $"DELETE FROM prodotti WHERE id='{idDaEliminare}'";

    // creo la connessione
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3");
    // apro la connessione
    connection.Open();
    // creo l'oggetto per eseguire il comando
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    // eseguo il comando
    command.ExecuteNonQuery();
    // chiudo la connessione
    connection.Close();

    Console.WriteLine();
}

static void ModificaProdotto(string path)
{



    string id = InputManager.LeggiStringa("Inserisci ID del prodotto da modificare > ");



    // creo la connessione
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3");
    // apro la connessione
    connection.Open();

    string sql = $"SELECT * FROM prodotti WHERE id = '{id}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SQLiteDataReader reader = command.ExecuteReader();

    if (reader.Read())
    {
        Console.WriteLine($"id: {reader["id"]}, nome {reader["nome"]}, prezzo {reader["prezzo"]}, quantita {reader["quantita"]}");
        string nuovoNome = InputManager.LeggiStringa("Nome > ");
        string nuovoPrezzo = InputManager.LeggiReal("Prezzo > ");
        string nuovoQuantita = InputManager.LeggiStringa("Quantita > ");

        sql = $"UPDATE prodotti SET nome = '{nuovoNome}' , prezzo = {nuovoPrezzo} , quantita = {nuovoQuantita} WHERE id = {id}";
        command = new SQLiteCommand(sql, connection);

        // eseguo il comando
        command.ExecuteNonQuery();
    }

    reader.Close();
    connection.Close();

    Console.WriteLine();

}