using System.ComponentModel.Design;
using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {
        var db = new Database(); // Modello di database in modo che sia possibile utilizare i metodi per la gestione del database
        var view = new View(db); // modello di vista è tra parentesi perché la vista deve avere accesso al database
        var controller = new UserController(db, view); // modello di controller che deve avere accesso al database e alla vista
        bool continua = true;
        while (continua)
        {
            continua = controller.MainMenu(); // Metodo per gestire il menu principale

        }
    }
}