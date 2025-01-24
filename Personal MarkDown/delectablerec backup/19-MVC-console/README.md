# MVC

MVC è un pattern architetturale che separa i dati, la logica di business e l'interfaccia utente in tre componenti distinti.

- Model: rappresenta i dati e la logica di business
- View: rappresenta l'interfaccia utente
- Controller: gestisce le interazioni tra l'utente e il modello
In uno scenario lavorativo si potrebbe avere un team di sviluppatori che si occupa del modello, un team che si occupa della vista e un team che si occupa del controller.

## ESEMPIO CLASSICO: App che permette di creare un database SQLite e di visualizzarne il contenuto

- Model: classe che rappresenta il database
- View: interfaccia grafica
- Controller: classe che gestisce le interazioni tra l'utente e il modello

comando dotnet per creare l'app

```bash
dotnet new console -n MvcConsole
```

comando dotnet per installare il pacchetto System.Data.SQLite

```bash
dotnet add package System.Data.SQLite
```

```csharp
using System.Data.SQLite; // Importazione del namespace per utilizzare SQLite

var db = new Database(); // Modello di database in modo che sia possibile utilizzare i metodi per la gestione del database
var view = new View(db); // Modello di vista c e db tra parentesi perche la vista deve avere accesso al database
var controller = new Controller(db, view); // Modello di controller che deve avere accesso al database e alla vista
controller.MainMenu(); // Metodo per gestire il menu principale
```

```csharp
class Database
{
    private SQLiteConnection _connection; // Connessione al database che e private perchè non deve essere accessibile dall'esterno
                                          // utilizziamo l underscore davanti al nome in modo da indicare che è una variabile privata

    public Database() // costruttore della classe database
    {
        _connection = new SQLiteConnection("Data Source=database.db"); // Creazione di una connessione al database
        _connection.Open(); // Apertura della connessione
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)", _connection); // Creazione della tabella users
        command.ExecuteNonQuery(); // Esecuzione del comando
    }

    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection); // Creazione di un comando per inserire un nuovo utente
        command.ExecuteNonQuery(); // Esecuzione del comando
    }
    public List<string> GetUsers() // metodo GetUsers che serve per ottenere la lista degli utenti
    {
        var command = new SQLiteCommand("SELECT name FROM users", _connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader(); // Esecuzione del comando e creazione di un oggetto per leggere i risultati cosi abbiamo caricato i dati nel reader
        var users = new List<string>(); // Creazione di una lista per memorizzare i nomi degli utenti
        while (reader.Read())
        {
            users.Add(reader.GetString(0)); // Aggiunta del nome dell'utente alla lista
                                            // utilizzo (0) perche il nome è il primo campo 
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
```

```csharp
class View
{
    private Database _db; // Riferimento al modello di database
    
    public View(Database db) // costruttore della classe view che prende in input il modello di database
    {
        _db = db; // Inizializzazione del riferimento al modello
    }
    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Esci");
    }

    public void ShowUsers(List<string> users) // Metodo per visualizzare gli utenti
    {
        foreach (var user in users)
        {
            Console.WriteLine(user); // Visualizzazione dei nomi degli utenti
        }
    }
    public string GetUserName()
    {
        Console.WriteLine("Enter user name:");
        return Console.ReadLine();
    }
    public string GetInput()
    {
        return Console.ReadLine(); // Lettura dell'input dell'utente
    }
}
```

```csharp
class Controller
{
    private Database _db; // Riferimento al modello di database
    private View _view; // Riferimento alla view

    public Controller(Database db, View view) // costruttore della classe controller che prende in input il modello di database e la view
    {
         _db = db; // Inizializzazione del riferimento al modello
        _view = view; // Inizializzazione del riferimento alla vista
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu(); // Visualizzazione del menu principale con metodo servito da view
            var input = _view.GetInput(); // Lettura dell'input dell'utente con metodo servito da view
            if (input == "1")
            {
                AddUser(); // Aggiunta di un utente
            }
            else if (input == "2")
            {
                ShowUsers(); // Visualizzazione degli utenti
            }
            else if (input == "3")
            {
                _db.CloseConnection(); // Chiusura della connessione al database
                break; // Uscita dal programma
            }
        }
    }

    private void AddUser()
    {
        var name = _view.GetUserName(); // La vista gestisce la richiesta del nome
        _db.AddUser(name); // Aggiunta dell'utente al database
    }

    private void ShowUsers()
    {
        var users = _db.GetUsers(); // Lettura degli utenti dal database
        _view.ShowUsers(users); // Visualizzazione degli utenti
    }
}
```

## AGGIUNTA DI UN MODELLO

```csharp
class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

```csharp
var db = new Database(); // Modello di database in modo che sia possibile utilizzare i metodi per la gestione del database
var view = new UserView(db); // Modello di vista c e db tra parentesi perche la vista deve avere accesso al database
var controller = new UserController(db, view); // Modello di controller che deve avere accesso al database e alla vista
controller.MainMenu(); // Metodo per gestire il menu principale
```

```csharp
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
```

```csharp
class UserView
{
    private Database _db; // Riferimento al modello di database
    
    public UserView(Database db) // costruttore della classe view che prende in input il modello di database
    {
        _db = db; // Inizializzazione del riferimento al modello
    }
    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Esci");
    }

    public void ShowUsers(List<User> users) // Metodo per visualizzare gli utenti
    {
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id} - {user.Name}"); // Visualizzazione degli utenti
        }
    }
    public string GetUserName()
    {
        Console.WriteLine("Enter user name:");
        return Console.ReadLine();
    }
    public string GetInput()
    {
        return Console.ReadLine(); // Lettura dell'input dell'utente
    }
}
```

```csharp
class UserController
{
    private Database _db; // Riferimento al modello di database
    private UserView _view; // Riferimento alla view

    public UserController(Database db, UserView view) // costruttore della classe controller che prende in input il modello di database e la view
    {
        _db = db; // Inizializzazione del riferimento al modello
        _view = view; // Inizializzazione del riferimento alla vista
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu(); // Visualizzazione del menu principale con metodo servito da view
            var input = _view.GetInput(); // Lettura dell'input dell'utente con metodo servito da view
            if (input == "1")
            {
                AddUser(); // Aggiunta di un utente
            }
            else if (input == "2")
            {
                ShowUsers(); // Visualizzazione degli utenti
            }
            else if (input == "3")
            {
                _db.CloseConnection(); // Chiusura della connessione al database
                break; // Uscita dal programma
            }
        }
    }

    private void AddUser()
    {
        var name = _view.GetUserName(); // La vista gestisce la richiesta del nome
        _db.AddUser(name); // Aggiunta dell'utente al database
    }

    private void ShowUsers()
    {
        var users = _db.GetUsers(); // Ora restituisce List<User>
        _view.ShowUsers(users); // Passa la lista di User alla View
    }
}
```

## VANTAGGI

- Separazione delle responsabilità
- Facilità di manutenzione
- Facilità di test
- Riusabilità del codice
- Scalabilità
- Facilità di sviluppo parallelo
- Facilità di sostituzione di una parte del sistema

# IMPLEMENTAZIONI

# Aggiunta di Funzionalità al Programma Esistente

Introduzione

programma in C# che implementa un semplice sistema CRUD (Create, Read, Update, Delete) per gestire utenti utilizzando una base di dati SQLite. Il programma è strutturato secondo il pattern MVC (Model-View-Controller), con le classi Database, View e Controller.

Attualmente, il programma permette di:

- Aggiungere un nuovo utente.
- Visualizzare la lista degli utenti.

**Obiettivo**

aggiungere ulteriori funzionalità al programma per renderlo più completo e user-friendly.

Ecco alcune idee:

- Modificare un utente esistente.
- Eliminare un utente.
- Visualizzazione dettagliata degli utenti: Mostrare l'ID e il nome degli utenti nella lista.
- Ricerca di un utente: Permettere all'utente di cercare un utente per nome.
- Gestione di input non validi: Aggiungere controlli per garantire che l'input dell'utente sia valido.
- Utilizzo di parametri nei comandi SQL: Prevenire SQL Injection utilizzando parametri nei comandi SQL.
- Chiusura della connessione al database: Assicurarsi che la connessione al database venga chiusa correttamente.

## 1. Ricerca di un Utente

**Modifiche Necessarie:**

- Aggiungere un'opzione nel menu principale per la ricerca.
- Implementare un metodo SearchUser() nel Controller.
- Aggiungere un metodo SearchUserByName() nella classe Database.
- Aggiornare il menu nella classe View.

**Implementazione:**


# 2. Gestione di Input Non Validi

**Modifiche Necessarie:**

Aggiungere controlli per assicurarsi che l'utente non inserisca valori vuoti o nulli.
Fornire messaggi di errore appropriati.

**Implementazione:**



# 3. Utilizzo di Parametri nei Comandi SQL
Per prevenire attacchi di SQL Injection, è buona pratica utilizzare parametri nei comandi SQL.
Gli attacchi di SQL Injection possono verificarsi quando i comandi SQL vengono costruiti concatenando stringhe, consentendo agli utenti malintenzionati di eseguire comandi dannosi sul database.
Utilizzando i parametri nei comandi SQL, si separano i dati dai comandi, impedendo l'iniezione di codice dannoso.

SQL Injection e i Vantaggi dell'Utilizzo dei Parametri nei Comandi SQL

**Introduzione**

La SQL Injection è una delle vulnerabilità più comuni e pericolose nelle applicazioni che interagiscono con database.
Si verifica quando un utente malintenzionato è in grado di inserire codice SQL arbitrario in una query, manipolando l'input fornito all'applicazione.
Questo può portare a conseguenze gravi, come l'accesso non autorizzato ai dati, la modifica o la cancellazione di dati, e in alcuni casi l'esecuzione di comandi sul server.

Utilizzare parametri nei comandi SQL è una pratica fondamentale per prevenire le SQL Injection. Invece di concatenare o interpolare direttamente le variabili nelle query SQL, l'uso di parametri permette al motore del database di gestire correttamente l'input dell'utente, evitando interpretazioni errate o dannose.

Perché l'Interpolazione di Stringhe è Pericolosa
Quando si costruisce una query SQL concatenando o interpolando direttamente le variabili, si espone l'applicazione al rischio di SQL Injection. Ecco un esempio del codice pericoloso:

```csharp
var command = new SQLiteCommand($"SELECT id, name FROM users WHERE name = '{name}'", _connection);
```

Supponiamo che la variabile name sia fornita dall'utente. Se l'utente inserisce un valore come:

```bash
' OR '1'='1
```
La query risultante diventa:

```sql
SELECT id, name FROM users WHERE name = '' OR '1'='1'
```
Questo significa che la condizione OR '1'='1' è sempre vera, e quindi la query restituirà tutti gli utenti nella tabella users, bypassando qualsiasi filtro previsto.

In casi peggiori, un utente malintenzionato potrebbe eseguire comandi distruttivi come:

```bash
'; DROP TABLE users; --
```

La query diventerebbe:

```bash
SELECT id, name FROM users WHERE name = ''; DROP TABLE users; --'
```
Questo potrebbe portare alla cancellazione della tabella users.

**Vantaggi dell'Utilizzo dei Parametri**

Utilizzando i parametri nei comandi SQL, si delega al driver del database il compito di gestire correttamente l'input, evitando che venga interpretato come codice SQL. Ecco come si può riscrivere il comando:

```bash
var command = new SQLiteCommand("SELECT id, name FROM users WHERE name = @name", _connection);
command.Parameters.AddWithValue("@name", name);
```
Vantaggi principali:

Protezione contro SQL Injection:
- I parametri vengono trattati come dati, non come parte del codice SQL. Qualsiasi carattere speciale inserito dall'utente viene automaticamente gestito in modo sicuro.
Miglioramento delle Prestazioni:
- I comandi parametrizzati possono essere compilati una volta dal database e riutilizzati, migliorando le prestazioni per query ripetute.
Manutenzione del Codice:
- Il codice è più leggibile e mantenibile, separando chiaramente la query SQL dai dati.
Tipizzazione Corretta dei Dati:
- I parametri permettono di specificare il tipo di dato, garantendo che il database gestisca correttamente i valori (ad esempio, date, numeri, stringhe).
Esempio Pratico

Senza Parametri (Vulnerabile):

```bash
string name = GetUserInput(); // Supponiamo che l'utente inserisca il proprio nome
var command = new SQLiteCommand($"SELECT id, name FROM users WHERE name = '{name}'", _connection);
var reader = command.ExecuteReader();
```
Se name contiene caratteri speciali o intenzionalmente malevoli, la query può essere compromessa.

Con Parametri (Sicuro):

```bash
string name = GetUserInput();
var command = new SQLiteCommand("SELECT id, name FROM users WHERE name = @name", _connection);
command.Parameters.AddWithValue("@name", name);
var reader = command.ExecuteReader();
```
Indipendentemente dal contenuto di name, il database tratterà il valore come un parametro, non come codice.

Ulteriori Benefici dell'Uso dei Parametri
**Evitare Problemi di Formattazione:**

Non è necessario preoccuparsi di sfuggire manualmente caratteri come apostrofi o virgolette all'interno delle stringhe.
**Internazionalizzazione:**

I parametri gestiscono correttamente i set di caratteri diversi, inclusi quelli Unicode.
**Riutilizzo dei Comandi:**

È possibile creare un comando una volta e modificare solo i valori dei parametri per eseguire la stessa query con dati diversi.
**Separazione tra Codice e Dati:**

Promuove una chiara separazione tra la logica dell'applicazione e i dati dell'utente.
Confronto Diretto tra i Due Approcci
**Approccio Insicuro:**

```bash
string name = GetUserInput();
string query = $"SELECT id, name FROM users WHERE name = '{name}'";
```
**Problemi:**
Vulnerabile a SQL Injection.
Difficile da mantenere se la query diventa complessa.
Necessità di gestire manualmente la formattazione e l'escaping dei caratteri.

**Approccio Sicuro con Parametri:**

```bash
string name = GetUserInput();
string query = "SELECT id, name FROM users WHERE name = @name";
var command = new SQLiteCommand(query, _connection);
command.Parameters.AddWithValue("@name", name);
```
**Vantaggi:**
- Sicuro contro SQL Injection.
- Codice più pulito e leggibile.
- Gestione automatica dei tipi di dato e dell'escaping.
- Considerazioni sull'Utilizzo dei Parametri

**Nomina dei Parametri:**

Utilizza nomi chiari e coerenti per i parametri. Ad esempio, @name, @id, @email.
Tipo di Dati dei Parametri:

Oltre a AddWithValue(), puoi specificare il tipo di dato e la lunghezza del parametro per una maggiore precisione:

command.Parameters.Add("@name", DbType.String, 50).Value = name;

**Parametri Multipli:**

Per query con più parametri, aggiungi ciascuno con il proprio nome e valore:

```bash
var command = new SQLiteCommand("SELECT * FROM users WHERE name = @name AND age = @age", _connection);
command.Parameters.AddWithValue("@name", name);
command.Parameters.AddWithValue("@age", age);
```
Esecuzione di Comandi Non Query:

Anche per comandi INSERT, UPDATE e DELETE, l'uso dei parametri è fondamentale:

```bash
var command = new SQLiteCommand("UPDATE users SET name = @newName WHERE id = @id", _connection);
command.Parameters.AddWithValue("@newName", newName);
command.Parameters.AddWithValue("@id", id);
command.ExecuteNonQuery();
```

Ad esempio invece di costruire un comando SQL in questo modo:

```csharp
var command = new SQLiteCommand($"SELECT id, name FROM users WHERE name = '{name}'", _connection);
```

è preferibile utilizzare parametri come segue:

```csharp
var command = new SQLiteCommand("SELECT id, name FROM users WHERE name = @name", _connection);
command.Parameters.AddWithValue("@name", name);
```

**Modifiche Necessarie:**

Modificare tutti i comandi SQL per utilizzare parametri invece di concatenare stringhe.
**Implementazione:**

Esempio per il metodo AddUser() nella classe Database:

```csharp
public void AddUser(string name)
{
    var command = new SQLiteCommand("INSERT INTO users (name) VALUES (@name)", _connection);
    command.Parameters.AddWithValue("@name", name);
    command.ExecuteNonQuery();
}
```
**Applicare la stessa modifica agli altri metodi:**

- UpdateUser()
- DeleteUser()
Esempio per UpdateUser():

```csharp
public void UpdateUser(int id, string newName)
{
    var command = new SQLiteCommand("UPDATE users SET name = @newName WHERE id = @id", _connection);
    command.Parameters.AddWithValue("@newName", newName);
    command.Parameters.AddWithValue("@id", id);
    command.ExecuteNonQuery();
}
```

Esempio per DeleteUser():

```csharp
public void DeleteUser(int id)
{
    var command = new SQLiteCommand("DELETE FROM users WHERE id = @id", _connection);
    command.Parameters.AddWithValue("@id", id);
    command.ExecuteNonQuery();
}
```
# 5. Chiusura della Connessione al Database
Per evitare perdite di risorse, è importante chiudere la connessione al database quando non è più necessaria.

Implementazione:

Aggiunta di un metodo CloseConnection() nella classe Database:

```csharp
public void CloseConnection()
{
    if (_connection.State != System.Data.ConnectionState.Closed)
    {
        _connection.Close();
    }
}
```
Chiamare CloseConnection() prima di uscire dal programma nel metodo MainMenu() del Controller:

```csharp
else if (input == "6")
{
    _db.CloseConnection();
    break;
}
```

Spiegazione delle Modifiche

- Classe User:** Creata per rappresentare un utente con proprietà Id e Name.
- Uso di Parametri nei Comandi SQL: Tutti i comandi SQL ora utilizzano parametri per prevenire SQL Injection.
- Visualizzazione degli ID degli Utenti: Il metodo ShowUsers() ora mostra anche gli ID.
- Gestione degli Input: Aggiunti controlli per validare l'input dell'utente.
- Ricerca degli Utenti: Implementata la funzionalità di ricerca per nome.
- Chiusura della Connessione: Aggiunto il metodo CloseConnection() per chiudere la connessione al database quando il programma termina

# Vantaggi delle Migliorie

- Sicurezza: Utilizzando parametri nei comandi SQL, si prevengono attacchi di SQL Injection.
- Usabilità: La visualizzazione degli ID e la ricerca degli utenti migliorano l'esperienza dell'utente.
- Robustezza: La gestione degli input non validi riduce la possibilità di errori.
- Manutenibilità: Il codice è più pulito e leggibile grazie alla separazione delle responsabilità.
- Efficienza: La chiusura corretta della connessione al database evita perdite di risorse.
- Scalabilità: Il programma è pronto per l'aggiunta di ulteriori funzionalità in futuro.