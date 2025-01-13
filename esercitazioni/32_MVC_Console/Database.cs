using System.Data.SqlClient;
using System.Data.SQLite;

class Database
{
    private SQLiteConnection _connection;
    // connessione al database che è privaata perché non deve essere accessibile dall'esterno
    // utilizziamo _ davanti al nome per indicare che è una variabile privata
    private string path = "database.db";

    public Database() // costruttore della classe database
    {
        if (!File.Exists(path))
        {
            SQLiteConnection.CreateFile(path);
        }

        _connection = new SQLiteConnection($"Data Source={path};Version=3;"); // creiamo una connessione al database
        // _connection = new SQLiteConnection($"Data Source={path};Version=3;"); // creiamo una connessione al database

        _connection.Open();
        string sql = @"
            CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)
        ";
        var command = new SQLiteCommand(sql, _connection);
        command.ExecuteNonQuery();
     
    }

    // aggiunge un nuovo utente (necessita dell'argomento)
    public void AddUser(string nome) // aggiungere un utente
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{nome}')", _connection);
        command.ExecuteNonQuery();

    }

    // ottenere lista utenti, non li stampa, li restituisce solo, perché la stampa appartiene al View
    public List<string> GetUsers() 
    {
        var command = new SQLiteCommand("SELECT name FROM users", _connection);
        var reader = command.ExecuteReader();
        var users = new List<string>();

        while (reader.Read())
        {
            users.Add(reader.GetString(0));
            // Aggiunta del nome dell'utente alla lista, 
            // IMPORTANTE: GetString(0) dove 0 è l'indice della colonna "nome" 

        }
        return users;
    }

    // se la connessione non è chiusa la chiude
    public void CloseConnection()
    {
        if (_connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();
        }
    }

}