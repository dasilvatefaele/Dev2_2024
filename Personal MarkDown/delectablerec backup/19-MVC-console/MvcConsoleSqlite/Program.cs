using System.Data.SQLite;
// comando installare il pacchetto System.Data.SQLite
// dotnet add package System.Data.SQLite
class Program
{
    static void Main(string[] args)
    {
        var db = new Database();
        var view = new View(db);
        var controller = new Controller(db, view);
        controller.MainMenu();
    }
}

class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Database
{
    private SQLiteConnection _connection;

    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db");
        _connection.Open();
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)", _connection);
        command.ExecuteNonQuery();
    }

    public void AddUser(string name)
    {
        /* vecchio metodo AddUser senza parameters
            var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection);
            command.ExecuteNonQuery();
        */
        var command = new SQLiteCommand("INSERT INTO users (name) VALUES (@name)", _connection);
        command.Parameters.AddWithValue("@name", name);
        command.ExecuteNonQuery();
    }

    /* vecchio metodo GetUsers
        public List<string> GetUsers()
        {
            var command = new SQLiteCommand("SELECT name FROM users", _connection);
            var reader = command.ExecuteReader();
            var users = new List<string>();
            while (reader.Read())
            {
                users.Add(reader.GetString(0));
            }
            return users;
        }
    */
    public List<User> GetUsers()
    {
        var command = new SQLiteCommand("SELECT id, name FROM users", _connection);
        var reader = command.ExecuteReader();
        var users = new List<User>();
        while (reader.Read())
        {
            users.Add(new User
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
        return users;
    }

    public void UpdateUser(int id, string newName)
    {
        /* vecchio metodo UpdateUser senza parameters
            var command = new SQLiteCommand($"UPDATE users SET name = '{newName}' WHERE name = '{oldName}'", _connection);
            command.ExecuteNonQuery();
        */
        var command = new SQLiteCommand("UPDATE users SET name = @newName WHERE id = @id", _connection);
        command.Parameters.AddWithValue("@newName", newName);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    public void DeleteUser(int id)
    {
        /* vecchio metodo DeleteUser senza parameters
            var command = new SQLiteCommand($"DELETE FROM users WHERE name = '{name}'", _connection);
            command.ExecuteNonQuery();
        */
        var command = new SQLiteCommand("DELETE FROM users WHERE id = @id", _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }
    public List<User> SearchUserByName(string name)
    {
        // var command = new SQLiteCommand("SELECT id, name FROM users WHERE name LIKE @name", _connection);
        // command.Parameters.AddWithValue("@name", "%" + name + "%");
        // oppure facendo la ricerca esatta
        var command = new SQLiteCommand($"SELECT id, name FROM users WHERE name = '{name}'", _connection);
        var reader = command.ExecuteReader();
        var users = new List<User>();
        while (reader.Read())
        {
            users.Add(new User
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
        return users;
    }
    public void CloseConnection()
    {
        if (_connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();
        }
    }
}

class View
{
    private Database _db;

    public View(Database db)
    {
        _db = db;
    }
    /* vecchio metodo ShowMainMenu
        public void ShowMainMenu()
        {
            Console.WriteLine("1. Aggiungi user");
            Console.WriteLine("2. Leggi users");
            Console.WriteLine("3. Modifica user"); // Aggiunta di una nuova funzionalità
            Console.WriteLine("4. Elimina user"); // Aggiunta di una nuova funzionalità
            Console.WriteLine("5. Esci");
        }
    */
    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Modifica user");
        Console.WriteLine("4. Elimina user");
        Console.WriteLine("5. Cerca user"); // Nuova funzionalità
        Console.WriteLine("6. Esci");
    }

    /* vecchio metodo ShowUsers
        public void ShowUsers(List<string> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    */
    public void ShowUsers(List<User> users)
    {
        Console.WriteLine("ID\tName");
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id}\t{user.Name}");
        }
    }

    public string GetInput()
    {
        return Console.ReadLine();
    }
}

class Controller
{
    private Database _db;
    private View _view;

    public Controller(Database db, View view)
    {
        _db = db;
        _view = view;
    }
    /* vecchio metodo MainMenu
        public void MainMenu()
        {
            while (true)
            {
                _view.ShowMainMenu();
                var input = _view.GetInput();
                if (input == "1")
                {
                    AddUser();
                }
                else if (input == "2")
                {
                    ShowUsers();
                }
                else if (input == "3")
                {
                    UpdateUser(); // Aggiunta di una nuova funzionalità
                }
                else if (input == "4")
                {
                    DeleteUser(); // Aggiunta di una nuova funzionalità
                }
                else if (input == "5")
                {
                    break;
                }
            }
        }
    */
    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();
            var input = _view.GetInput();
            if (input == "1")
            {
                AddUser();
            }
            else if (input == "2")
            {
                ShowUsers();
            }
            else if (input == "3")
            {
                UpdateUser();
            }
            else if (input == "4")
            {
                DeleteUser();
            }
            else if (input == "5")
            {
                SearchUser(); // Nuova funzionalità
            }
            else if (input == "6")
            {
                _db.CloseConnection();
                break;
            }
            else
            {
                Console.WriteLine("Opzione non valida. Per favore, riprova.");
            }
        }
    }
    /* vecchio metodo AddUser
        private void AddUser()
        {
            Console.WriteLine("Enter user name:");
            var name = _view.GetInput();
            _db.AddUser(name);
        }
    */
    private void AddUser()
    {
        Console.WriteLine("Inserisci il nome dell'utente:");
        var name = _view.GetInput();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Il nome non può essere vuoto.");
            return;
        }
        _db.AddUser(name);
        Console.WriteLine("Utente aggiunto con successo.");
    }

    private void ShowUsers()
    {
        var users = _db.GetUsers();
        _view.ShowUsers(users);
    }

    /* vecchio metodo UpdateUser
        private void UpdateUser()
        {
            Console.WriteLine("Enter user name:");
            var oldName = _view.GetInput(); // Aggiunta di una nuova funzionalità
            Console.WriteLine("Enter new user name:");
            var newName = _view.GetInput(); // Aggiunta di una nuova funzionalità
            _db.UpdateUser(oldName, newName);
        }
    */
    private void UpdateUser()
    {
        Console.WriteLine("Inserisci l'ID dell'utente da modificare:");
        var idInput = _view.GetInput();
        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("ID non valido.");
            return;
        }

        Console.WriteLine("Inserisci il nuovo nome dell'utente:");
        var newName = _view.GetInput();
        if (string.IsNullOrWhiteSpace(newName))
        {
            Console.WriteLine("Il nome non può essere vuoto.");
            return;
        }

        _db.UpdateUser(id, newName);
        Console.WriteLine("Utente aggiornato con successo.");
    }

    /* vecchio metodo DeleteUser
        private void DeleteUser()
        {
            Console.WriteLine("Enter user name:");
            var name = _view.GetInput(); // Aggiunta di una nuova funzionalità
            _db.DeleteUser(name);
        }
    */
    private void DeleteUser()
    {
        Console.WriteLine("Inserisci l'ID dell'utente da eliminare:");
        var idInput = _view.GetInput();
        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("ID non valido.");
            return;
        }

        _db.DeleteUser(id);
        Console.WriteLine("Utente eliminato con successo.");
    }
    /* Nuova funzionalità
        private void SearchUser()
        {
            Console.WriteLine("Enter user name to search:");
            var name = _view.GetInput();
            var users = _db.SearchUserByName(name);
            _view.ShowUsers(users);
        }
    */
    private void SearchUser()
    {
        Console.WriteLine("Inserisci il nome da cercare:");
        var name = _view.GetInput();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Il nome non può essere vuoto.");
            return;
        }

        var users = _db.SearchUserByName(name);
        _view.ShowUsers(users);
    }
}