using System.Data.SQLite;

class Controller
{

    private Database _db; // riferimento al modello
    private View _view; // riferimento alla vista

    public Controller(Database db, View view) // costruttore con inizializzazione riferimenti
    {
        _db = db;
        _view = view;
    }

    // Menu
    public bool MainMenu()
    {
        _view.ShowMainMenu();
        var input = _view.GetInput();

        switch (input)
        {
            case "1":
                AddUser();
                return true;
                break;
            case "2":
                ShowUsers();
                return true;
                break;
            case "0":
                _db.CloseConnection();
                return false;

                break;
            default:
                Console.WriteLine("\nErrore di input.");
                return true;
                break;
        }
    }

    // CRUD: ---------------------------------------
    private void AddUser()
    {
        _db.AddUser(_view.AddUser());
    }

    private void ShowUsers()
    {
        var user = _db.GetUsers();
        _view.MostraUsers(user);
    }
}