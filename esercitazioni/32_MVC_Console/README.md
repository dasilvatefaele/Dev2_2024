# MVC Console

> Risposta ideale a "CHE COSA AVETE FATTO FINO AD ORA?": Durante il corso abbiamo un pattern di classi che suddivide i compiti che permette di lavorare a un progetto tutti assieme.

#### MVC è un pattern acchitetturale che separa i dati, la logica di business e l'interfaccia in tre componenti distinti.

- Model: classe che rappresenta il tadabase
- View: interfaccia grafica
- Controller: classe che gestisce le interazioni tra l'utente e il modello

> Dipendenze:

```bash
dotnet add package System.Data.SQLite
```

```c#
using System.Data.SQLite;

var db = new Database(); // Modello di database in modo che sia possibile utilizare i metodi per la gestione del database
var view = new View(db); // modello di vista è tra parentesi perché la vista deve avere accesso al database
var controller = new Controller(db, view); // modello di controller che deve avere accesso al database e alla vista

controller.MainMenu(); // Metodo per gestire il menu principale

```





