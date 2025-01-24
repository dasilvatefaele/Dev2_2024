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