public static class UtilityDB
{
    /// <summary>
    /// Esegue una query che non restituisce dati (INSERT, UPDATE, DELETE).
    /// </summary>
    /// <param name="sql">La query SQL.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Il numero di righe interessate.</returns>
    public static int ExecuteNonQuery(string sql, Action<SqliteCommand> setupParameters = null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        using var command = new SqliteCommand(sql, connection);
        setupParameters?.Invoke(command);

        return command.ExecuteNonQuery();
    }

    /// <summary>
    /// Esegue una query che restituisce un valore scalare.
    /// </summary>
    /// <typeparam name="T">Il tipo del valore atteso.</typeparam>
    /// <param name="sql">La query SQL.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Il valore restituito convertito al tipo T.</returns>
    public static T ExecuteScalar<T>(string sql, Action<SqliteCommand> setupParameters = null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        using var command = new SqliteCommand(sql, connection);
        setupParameters?.Invoke(command);

        var result = command.ExecuteScalar();
        if (result == null || result == DBNull.Value)
            return default(T);

        return (T)Convert.ChangeType(result, typeof(T));
    }

    /// <summary>
    /// Esegue una query che restituisce più righe e le converte in una lista di oggetti di tipo T.
    /// </summary>
    /// <typeparam name="T">Il tipo di oggetto da restituire per ogni riga.</typeparam>
    /// <param name="sql">La query SQL.</param>
    /// <param name="converter">Funzione per convertire una riga (<see cref="SqliteDataReader"/>) in un oggetto di tipo T.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Una lista di oggetti di tipo T.</returns>
    public static List<T> ExecuteReader<T>(string sql, Func<SqliteDataReader, T> converter, Action<SqliteCommand> setupParameters = null)
    {
        var list = new List<T>();
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        
        using var command = new SqliteCommand(sql, connection);
        setupParameters?.Invoke(command);
        
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(converter(reader));
        }
        return list;
    }
}
