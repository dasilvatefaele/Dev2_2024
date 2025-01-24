using System.Data.SQLite; // Importazione del namespace per utilizzare SQLite
class Database
{
    private SQLiteConnection _connection; // Connessione al database che e private perchè non deve essere accessibile dall'esterno
                                          // utilizziamo l underscore davanti al nome in modo da indicare che è una variabile privata

    public Database() // costruttore della classe database
    {
        // path al files databse nella cartella data
        string path = Path.Combine(Environment.CurrentDirectory, "Data");
        _connection = new SQLiteConnection($"Data Source={path}/database.db"); // Creazione della connessione al database
        _connection.Open(); // Apertura della connessione
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)", _connection); // Creazione della tabella users
        command.ExecuteNonQuery(); // Esecuzione del comando
    }

    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection); // Creazione di un comando per inserire un nuovo utente
        command.ExecuteNonQuery(); // Esecuzione del comando
    }
    public List<User> GetUsers() // metodo GetUsers che serve per ottenere la lista degli utenti
    {
        var command = new SQLiteCommand("SELECT * FROM users", _connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader(); // Esecuzione del comando e creazione di un oggetto per leggere i risultati cosi abbiamo caricato i dati nel reader
        var users = new List<User>();
        while (reader.Read())
        {
            try
            {
                users.Add(new User
                {
                    Id = reader.GetInt32(0),  // Primo campo: id
                    Name = reader.GetString(1) // Secondo campo: name
                });
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Errore nel leggere un utente: {ex.Message}");
                continue; // Salta l'elemento con dati non validi
            }
        }
        return users; // Restituzione della lista degli utenti
    }
    public void CloseConnection()
    {
        if (_connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();
        }
    }
}