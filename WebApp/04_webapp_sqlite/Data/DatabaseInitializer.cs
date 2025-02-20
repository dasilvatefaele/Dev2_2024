// classe di gestione del database
namespace _04_webapp_sqlite.Data;

public static class DatabaseInitializer
{

    // proprietà del modello
    // stringa di connessione, che deve essere statica e readonly. Statica per poterla usare in un metodo statico e readonly per non poterla modificare
    private static readonly string _connectionString = "Data Source=Database.db";

    // metodo statico per creare il database
    public static void InitializeDatabase()
    {
        // creiamo un'istanza del database usando il metodo GetConnection() creato sotto
        // using (var connection = GetConnection())
        // {

            // apriamo la connessione
            // connection.Open();

            // creiamo il comando per creare la tabella Categoria. La @ serve per non dover fare l'escape dei caratteri speciali
            var createCategorieTabella = @"
                CREATE TABLE IF NOT EXISTS Categorie (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL
                );";

            // Se la tabella non esistente creo la tabella la creo tramite query e ExecuteNonQuery
            string createFornitoriTabella = @"
                CREATE TABLE IF NOT EXISTS Fornitori (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Contatto TEXT NOT NULL
                );";


            var createProdottiTabella = @"
                CREATE TABLE IF NOT EXISTS Prodotti (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Prezzo REAL NOT NULL,
                CategoriaId INTEGER NOT NULL,
                FornitoreId INTEGER NOT NULL,
                FOREIGN KEY(CategoriaId) REFERENCES Categorie(Id),
                FOREIGN KEY(FornitoreId) REFERENCES Fornitori(Id)
                );";

            // lanciare il comando sulla connessione
            UtilityDB.ExecuteNonQuery(createCategorieTabella);
            // using (var command = new SQLiteCommand(createCategorieTabella, connection))
            // {
            //     // eseguiamo il comando
            //     command.ExecuteNonQuery();
            // }
            // ;

            // lanciare il comando sulla connessione tramite UtilityDB
            UtilityDB.ExecuteNonQuery(createFornitoriTabella);

            // lanciare il comando sulla connessione
            UtilityDB.ExecuteNonQuery(createProdottiTabella);
            // using (var command = new SQLiteCommand(createProdottiTabella, connection))
            // {
            //     // eseguiamo il comando
            //     command.ExecuteNonQuery();
            // }




            // seeding delle Categorie (se non ci sono categorie)
            var selectCategorie = "SELECT COUNT(*) FROM Categorie";
            // creiamo il comando
            //var countCommand = 
            // eseguiamo il comando che restituirà una reader che poi andrà convertito in un intero con il metodo ExecuteScalar.
            // Questo metodo restituisce il valore della prima colonna della prima riga del risultato della query.
            // inizialmente dichiariamo la variabile come var perché non sappiamo cosa ci restituisce. Pertanto occorre fare il cast a int di tipo long per convertirlo.
            var count = UtilityDB.ExecuteScalar<int>(selectCategorie);
            // se non ci sono categorie le creiamo
            if (count == 0)
            {
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
                UtilityDB.ExecuteNonQuery(insertCategorie);
                // using (var command = new SQLiteCommand(insertCategorie, connection))
                // {
                //     command.ExecuteNonQuery();
                // }
            }


            // seeding dei Fornitori (se non ci sono fornitori)
            var countFornitori = UtilityDB.ExecuteScalar<int>("SELECT COUNT (*) FROM Fornitori");
            // Se la tabella è vuota eseguo il seeding dei Fornitori
            if (countFornitori == 0)
            {
                string seedingFornitori = @"
                INSERT INTO Fornitori (Nome, Contatto) VALUES
                ('Nike', 'fornitore@nike.com'),
                ('Ikea', 'fornitore@ikea.com'),
                ('Apple', 'fornitore@apple.com'),
                ('Mulino Bianco', 'fornitore@mulinobianco.com'),
                ('Brico', 'fornitore@brico.com'),
                ('Samsung', 'fornitore@samsung.com'),
                ('Zara', 'fornitore@zara.com')
                ";
                // Eseguo il comando SQL
                UtilityDB.ExecuteNonQuery(seedingFornitori);
            }

            // seeding dei Prodotti (se non ci sono prodotti)
            var selectProdotti = "SELECT COUNT(*) FROM Prodotti";
            // creiamo il comando
            // var countProdottiCommand = new SQLiteCommand(selectProdotti, connection);
            // eseguiamo il comando
            var countProdotti = UtilityDB.ExecuteScalar<int>(selectProdotti);
            // se non ci sono prodotti li creiamo
            if (countProdotti == 0)
            {
                // creiamo il comando per inserire i prodotti. L'id della categoria lo recuperiamo con una sotto query 1
                // nel posto della categoria. In questo modo non dobbiamo conoscere l'id della categoria ma solo il nome e simula il menu a tendina della vista.
                var insertProdotti = @"
                    INSERT INTO Prodotti (Nome, Prezzo, CategoriaId, FornitoreId) VALUES
                    ('Smartphone', 500, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica'), (SELECT Id FROM Fornitori WHERE Nome = 'Apple')),
                    ('Tablet', 300, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica'), (SELECT Id FROM Fornitori WHERE Nome = 'Apple')),
                    ('TV', 700, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica'), (SELECT Id FROM Fornitori WHERE Nome = 'Samsung')),
                    ('Cuffie', 100, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica'), (SELECT Id FROM Fornitori WHERE Nome = 'Samsung')),
                    ('Maglietta', 20, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento'), (SELECT Id FROM Fornitori WHERE Nome = 'Zara')),
                    ('Pantaloni', 40, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento'), (SELECT Id FROM Fornitori WHERE Nome = 'Zara')),
                    ('Scarpe', 50, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento'), (SELECT Id FROM Fornitori WHERE Nome = 'Zara')),
                    ('Cappotto', 100, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento'), (SELECT Id FROM Fornitori WHERE Nome = 'Zara')),
                    ('Divano', 300, (SELECT Id FROM Categorie WHERE Nome = 'Casa'), (SELECT Id FROM Fornitori WHERE Nome = 'Ikea')),
                    ('Tavolo', 150, (SELECT Id FROM Categorie WHERE Nome = 'Casa'), (SELECT Id FROM Fornitori WHERE Nome = 'Ikea')),
                    ('Sedia', 50, (SELECT Id FROM Categorie WHERE Nome = 'Casa'), (SELECT Id FROM Fornitori WHERE Nome = 'Ikea')),
                    ('Letto', 200, (SELECT Id FROM Categorie WHERE Nome = 'Casa'), (SELECT Id FROM Fornitori WHERE Nome = 'Ikea')),
                    ('Rasaerba', 200, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio'), (SELECT Id FROM Fornitori WHERE Nome = 'Brico')),
                    ('Soffiatore', 100, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio'), (SELECT Id FROM Fornitori WHERE Nome = 'Brico')),
                    ('Tagliaerba', 150, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio'), (SELECT Id FROM Fornitori WHERE Nome = 'Brico')),
                    ('Tosaerba', 250, (SELECT Id FROM Categorie WHERE Nome = 'Giardinaggio'), (SELECT Id FROM Fornitori WHERE Nome = 'Brico')),
                    ('Pallone', 10, (SELECT Id FROM Categorie WHERE Nome = 'Sport'), (SELECT Id FROM Fornitori WHERE Nome = 'Nike')),
                    ('Scarpe da calcio', 50, (SELECT Id FROM Categorie WHERE Nome = 'Sport'), (SELECT Id FROM Fornitori WHERE Nome = 'Nike')),
                    ('Rete da calcio', 100, (SELECT Id FROM Categorie WHERE Nome = 'Sport'), (SELECT Id FROM Fornitori WHERE Nome = 'Nike')),
                    ('Pallavolo', 20, (SELECT Id FROM Categorie WHERE Nome = 'Sport'), (SELECT Id FROM Fornitori WHERE Nome = 'Nike'));
                ";
                // lanciamo il comando
                UtilityDB.ExecuteNonQuery(insertProdotti);
                // using (var command = new SQLiteCommand(insertProdotti, connection))
                // {
                //     command.ExecuteNonQuery();
                // }
            }
            // chiudiamo la connessione
            // connection.Close();
        //}
    }

    // metodo per ottenere la connessione al database da usare all'interno dell'applicazione per eseguire le query
    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(_connectionString);
    }
}