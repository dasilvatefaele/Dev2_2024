// classe di gestione del database
namespace _04_webapp_sqlite.Data;

public static class DatabaseInitializer {

    // proprietà del modello
    // stringa di connessione, che deve essere statica e readonly. Statica per poterla usare in un metodo statico e readonly per non poterla modificare
    private static readonly string _connectionString = "Data Source=Database.db";

    // metodo statico per creare il database
    public static void InitializeDatabase() {
        // creiamo un'istanza del database usando il metodo GetConnection() creato sotto
        using (var connection = GetConnection()) {

            // apriamo la connessione
            connection.Open();

            // creiamo il comando per creare la tabella Categoria. La @ serve per non dover fare l'escape dei caratteri speciali
            var createCategorieTabella = @"
                CREATE TABLE IF NOT EXISTS Categorie (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL
                );";

            var createProdottiTabella = @"
                CREATE TABLE IF NOT EXISTS Prodotti (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Prezzo REAL NOT NULL,
                    CategoriaId INTEGER NOT NULL,
                    FOREIGN KEY(CategoriaId) REFERENCES Categorie(Id)
                );";

            // lanciare il comando sulla connessione
            using (var command = new SQLiteCommand(createCategorieTabella, connection)) {
                // eseguiamo il comando
                command.ExecuteNonQuery();
            };

            // lanciare il comando sulla connessione
            using (var command = new SQLiteCommand(createProdottiTabella, connection)) {
                // eseguiamo il comando
                command.ExecuteNonQuery();
            }

            // seeding delle Categorie
            // solo se non ci sono categorie le creiamo. Per farlo possiamo usare il comando SELECT COUNT(*) FROM Categorie che restituisce il numero di record presenti
            var selectCategorie = "SELECT COUNT(*) FROM Categorie";
            // creiamo il comando
            var countCommand = new SQLiteCommand(selectCategorie, connection);
            // eseguiamo il comando che restituirà una reader che poi andrà convertito in un intero con il metodo ExecuteScalar. 
            // Questo metodo restituisce il valore della prima colonna della prima riga del risultato della query. 
            // inizialmente dichiariamo la variabile come var perché non sappiamo cosa ci restituisce. Pertanto occorre fare il cast a int di tipo long per convertirlo.
            var count = (long)countCommand.ExecuteScalar();
            // se non ci sono categorie le creiamo
            if (count == 0) {
                // creiamo il comando per inserire le categorie
                var insertCategorie = @"
                    INSERT INTO Categorie (Nome) VALUES
                    ('Elettronica'),
                    ('Abbigliamento'),
                    ('Casa'),
                    ('Giardinaggio'),
                    ('Sport');
                ";
                // lanciamo il comando
                using (var command = new SQLiteCommand(insertCategorie, connection)) {
                    command.ExecuteNonQuery();
                }
            }

            // seeding dei Prodotti se non esistono già
            // controlliamo se ci sono prodotti
            var selectProdotti = "SELECT COUNT(*) FROM Prodotti";
            // creiamo il comando
            var countProdottiCommand = new SQLiteCommand(selectProdotti, connection);
            // eseguiamo il comando
            var countProdotti = (long)countProdottiCommand.ExecuteScalar();
            // se non ci sono prodotti li creiamo
            if (countProdotti == 0){
                // creiamo il comando per inserire i prodotti. L'id della categoria lo recuperiamo con una sotto query 1
                // nel posto della categoria. In questo modo non dobbiamo conoscere l'id della categoria ma solo il nome e simula il menu a tendina della vista.
                var insertProdotti = @"
                    INSERT INTO Prodotti (Nome, Prezzo, CategoriaId) VALUES
                    ('Smartphone', 500, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica')),
                    ('Tablet', 300, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica')),
                    ('TV', 700, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica')),
                    ('Cuffie', 100, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica')),
                    ('Maglietta', 20, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento')),
                    ('Pantaloni', 40, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento')),
                    ('Scarpe', 50, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento')),
                    ('Cappotto', 100, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento')),
                    ('Divano', 300, (SELECT Id FROM Categorie WHERE Nome = 'Casa')),
                    ('Tavolo', 150, (SELECT Id FROM Categorie WHERE Nome = 'Casa')),
                    ('Sedia', 50, (SELECT Id FROM Categorie WHERE Nome = 'Casa')),
                    ('Letto', 200, (SELECT Id FROM Categorie WHERE Nome = 'Casa')),
                    ('Rasaerba', 200, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio')),
                    ('Soffiatore', 100, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio')),
                    ('Tagliaerba', 150, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio')),
                    ('Tosaerba', 250, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio')),
                    ('Pallone', 10, (SELECT Id FROM Categorie WHERE Nome = 'Sport')),
                    ('Scarpe da calcio', 50, (SELECT Id FROM Categorie WHERE Nome = 'Sport')),
                    ('Rete da calcio', 100, (SELECT Id FROM Categorie WHERE Nome = 'Sport')),
                    ('Pallavolo', 20, (SELECT Id FROM Categorie WHERE Nome = 'Sport'));
                ";
                // lanciamo il comando
                using (var command = new SQLiteCommand(insertProdotti, connection)) {
                    command.ExecuteNonQuery();                
                }
            }

            // chiudiamo la connessione
            connection.Close();
        }
    }

    // metodo per ottenere la connessione al database da usare all'interno dell'applicazione per eseguire le query
    public static SQLiteConnection GetConnection() {
        return new SQLiteConnection(_connectionString);
    }
}