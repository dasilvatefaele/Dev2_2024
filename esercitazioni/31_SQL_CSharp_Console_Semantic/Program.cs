using System.Data.SQLite;

// rotta del file database
string path = "database.db";

Console.Clear();

// se non esiste crealo
if (!File.Exists(path))
{
    SQLiteConnection.CreateFile(path);

    //* --------- CONNECTION: ------------
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;");
    //* OPEN ---------------------------
    connection.Open(); // apre la connessione

    // Query SQL
    string sql = @"
                    CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                    CREATE TABLE prodotti ( id INTEGER PRIMARY KEY AUTOINCREMENT, nome Text, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
                    INSERT INTO categorie (nome) VALUES ('cat1'), ('cat2'), ('cat3');
                    INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('prodotto1', 1, 10,1), ('prodotto2', 2, 20, 2),  ('prodotto3', 3, 30, 3);
                ";

    // creiamo il comando per eseguire lo script su quella connessione a quel database
    SQLiteCommand command = new SQLiteCommand(sql, connection);

    // esegue la Query senza ricevere un ritorno (.ExecuteNonQuery)
    command.ExecuteNonQuery();

    //chiudiamo la connessione (! MOLTO IMPORTANTE: ogni azione  )

    connection.Close();
    //! ---------------------------- CLOSED
}


bool run = true;
while (run)
{
    Console.WriteLine("1. Visualizza categorie");
    Console.WriteLine("2. Visualizza prodotti");
    Console.WriteLine("3. Modifica categorie");
    Console.WriteLine("4. Modifica prodotti");
    Console.WriteLine("5. Aggiungi prodotti");
    Console.WriteLine("6. Ordina per Prezzo DESC");
    Console.WriteLine("0. Esci");

    string scelta = InputManager.LeggiIntero("\n> ", 0, 6).ToString();

    switch (scelta)
    {
        case "1":
            Console.Clear();
            StampaCategorie(path);
            break;
        case "2":
            Console.Clear();
            VisualizzaProdotti(path);
            break;
        case "3":
            Console.Clear();
            StampaCategorie(path);
            ModificaCategorie(path);
            break;
        case "4":
            Console.Clear();
            VisualizzaProdotti(path);
            ModificaProdotto(path);
            break;
        case "5":
            Console.Clear();
            InserisciProdotto(path);
            break;
        case "6":
            Console.Clear();
            VisualizzaProdottiDesc(path);
            break;
        case "0":
            run = false;
            break;
    }
}

static void StampaCategorie(string path)
{
    //* --------- CONNECTION: ------------
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3");
    //* OPEN ---------------------------
    connection.Open();

    string sql = "SELECT * FROM categorie";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SQLiteDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine($"{reader["id"]}\t{reader["nome"]}");
    }
    Console.WriteLine();
    reader.Close();
    connection.Close();
    //! ---------------------------- CLOSED
}

static void ModificaCategorie(string path)
{
    string id = InputManager.LeggiStringa("Inserisci ID della categoria da modificare > ");

    //* --------- CONNECTION: ------------
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3");
    //* OPEN ---------------------------
    connection.Open();

    string sql = $"SELECT * FROM categorie WHERE id = '{id}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SQLiteDataReader reader = command.ExecuteReader();

    if (reader.Read())
    {

        string nuovoNome = InputManager.LeggiStringa("Nuova categoria > ");

        sql = $"UPDATE categorie SET nome = '{nuovoNome}' WHERE id = {id}";
        command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
    }
    reader.Close();
    connection.Close();
    //! ---------------------------- CLOSED
}

static void ModificaProdotto(string path)
{
    string id = InputManager.LeggiStringa("Inserisci ID del prodotto da modificare > ");

    //* --------- CONNECTION: ------------
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3");
    //* OPEN ---------------------------
    connection.Open();

    string sql = $"SELECT * FROM prodotti WHERE id = '{id}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SQLiteDataReader reader = command.ExecuteReader();

    if (reader.Read())
    {
        // Console.WriteLine($"id:\n{reader["id"]}\n\nnome:\n{reader["nome"]}\n\nprezzo:\n{reader["prezzo"]}\n\nquantita:\n{reader["quantita"]}\n\ncategoria:\n{reader["nome_categoria"]}\n\n");


        string nuovoNome = InputManager.LeggiStringa("Nome > ");
        string nuovoPrezzo = InputManager.LeggiReal("Prezzo > ");
        string nuovoQuantita = InputManager.LeggiStringa("Quantita > ");

        StampaCategorie(path);
        Console.WriteLine();

        string nuovaCategoria = InputManager.LeggiStringa("Scegli Categoria > ");

        sql = $"UPDATE prodotti SET nome = '{nuovoNome}' , prezzo = {nuovoPrezzo} , quantita = {nuovoQuantita}, id_categoria = {nuovaCategoria} WHERE id = {id}";

        command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
    }
    reader.Close();
    connection.Close();
    //! ---------------------------- CLOSED
}


static void VisualizzaProdotti(string path)
{
    //* --------- CONNECTION: ------------
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3");

    //* OPEN ----------------------------
    connection.Open();

    string sql = "SELECT prodotti.id, prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome AS nome_categoria FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SQLiteDataReader reader = command.ExecuteReader();

    Console.WriteLine($"{"id",-5}{"Album",-25}{"Prezzo",-10}{"Qnt.",-10}{"Genere",-5}");
    Console.WriteLine(new string('-', 60));

    while (reader.Read())
    {
        Console.WriteLine();
        Console.WriteLine($"{reader["id"],-5} {reader["nome"],-25} {"€" + reader["prezzo"],-10}{reader["quantita"],-10}{reader["nome_categoria"],-5}");

    }
    Console.WriteLine();
    reader.Close();
    connection.Close();
    //! ---------------------------- CLOSED


}

static void InserisciProdotto(string path)
{


    //acquisizione
    string nomeNuovoProdotto = InputManager.LeggiStringa("Nome > ");
    string prezzoNuovoProdotto = InputManager.LeggiReal("Prezzo > ");
    string quantitaNuovoProdotto = InputManager.LeggiStringa("Quantita > ");

    StampaCategorie(path);


    string nuovaCategoria = InputManager.LeggiStringa("\n>");

    // creo la connessione
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3");

    // apro la connessione
    connection.Open();

    // creo la query
    string sql = $"INSERT INTO prodotti (nome,prezzo,quantita,id_categoria) VALUES ('{nomeNuovoProdotto}',{prezzoNuovoProdotto},{quantitaNuovoProdotto},{nuovaCategoria})";

    // creo l'oggetto per eseguire il comando
    SQLiteCommand command = new SQLiteCommand(sql, connection);

    // eseguo il comando
    command.ExecuteNonQuery();

    // chiudo la connessione
    connection.Close();

    Console.WriteLine();
}

static void VisualizzaProdottiDesc(string path)
{
    //* --------- CONNECTION: ------------
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3");
    connection.Open();

    // creo la query
    string sql = "SELECT * FROM prodotti ORDER BY prezzo DESC";
    SQLiteCommand command = new SQLiteCommand(sql, connection);

    SQLiteDataReader reader = command.ExecuteReader();

    Console.WriteLine($"{"id",-5}{"Album",-25}{"Prezzo",-10}{"Qnt.",-10}{"Genere",-5}");
    Console.WriteLine(new string('-', 60));

    while (reader.Read())
    {
        Console.WriteLine();
        Console.WriteLine($"{reader["id"],-5} {reader["nome"],-25} {"€" + reader["prezzo"],-10}{reader["quantita"],-10}{reader["nome_categoria"],-5}");
    }

    reader.Close();
    connection.Close();

}