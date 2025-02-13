using System.Data.SqlClient;
using System.Data.SQLite;

public static class GestioneCategorie
{
    // metodo per caricare le categorie da database
    public static List<Categoria> LoadFromDatabase()
    {
        List<Categoria> Categorie = new List<Categoria>();
        using (var connection = DatabaseInitializer.GetConnection())
        {
            // aprire la connessione 
            connection.Open();

            // leggere la tabella categorie
            var sql = @" SELECT * FROM Categorie";

            using (var command = new SQLiteCommand(sql, connection))
            {
                // mentre il reader legge
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // aggiungi nuovo oggetto SelectListItem con Value e Text
                        Categorie.Add(new Categoria
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1)
                        });
                    }
                }
            }
        }
        return Categorie;
    }
}