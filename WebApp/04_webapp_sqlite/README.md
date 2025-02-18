# Data Annotations

- I modelli sono stati aggiornati con attributi di validazione
- Le pagine Razor (Create e Edit) inlcludono gli helperper visualizzare gli errori di validazione.

# Aggiornamento dei Modelli con Data Annotation

Models/Prodotto.cs
Models/Categoria.cs

```c#
using System.ComponentModel.DataAnnotations; // dipendenza DataAnnotations

public class Categoria
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome della categoria è obbligatorio.")]
    // [Required] - è il DataAnnotation , (ErrorMessage = "...") - è il messaggio
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Nome { get; set; }
}
```

- `[Required]` - è il DataAnnotation
- `(ErrorMessage = "...")` - è il messaggio restituito in caso di errato inserimento

Ne esistono diversi, come

- `[Range]`
- `[StringLength]`

ecc...

```c#
public class Prodotto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome del prodotto è obbligatorio.")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Il prezzo è obbligatorio.")]
    [Range (0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggioe di ")]
    public double Prezzo { get; set; }

    [Required(ErrorMessage = "La categoria è obbligatoria.")]
    public int CategoriaId { get; set; }
}
```

---

# Utilizzo della validazione in HTML

```html
<span asp-validation-for="Prodotto.Nome" class="text-danger"
  ><span></span
></span>
```

e va inserito sotto l'input

```html
<label asp-for="Prodotto.Nome">Nome</label>
<input type="text" class="form-control" asp-for="Prodotto.Nome" />
<span asp-validation-for="Prodotto.Nome" class="text-danger"></span>
```

---

# E' necessario...

## 1. che il modello abbia lo using System.ComponentModel.DataAnnotations

```cs
using System.ComponentModel.DataAnnotations;
```

## 2. che i DataAnnotation siano sopra il campo del modello

```cs
[Required(ErrorMessage = "Il nome del prodotto è obbligatorio.")]
[StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
public string Nome { get; set; }
```

## 3. che nell'html, prima del form ci sia lo script per bypassare i messaggi di validazioni di default

```c#
@section Scripts
{
    <partial name="_ValidationScriptsPartial"/>
}
```

## 4. che nel back-end ci sia nell' OnPost() il controllo della validazione

```cs
if (!ModelState.IsValid) // se il modello non è valido
{
    // operazioni eseguite nel OnGet() per visualizzare la pagina
    return Page(); // reindizzamento alla stessa pagina con i messaggi di errore
}
```

Nel caso di questa WebApp, in `Modifica.cs` e in `AggiungiProdotto.cs` avremo come prima istruzione del `OnPost`:

```cs
if (!ModelState.IsValid)
{
    CaricaCategorie();
    return Page();
}
```

# SQL, Partial, Model (14/02/2025)

### Obiettivo:

Creare una Dashboard `Prodotti Piu Costosi`, `Prodotti Recenti`, `Prodotti in Elettronica` usando le `_PartialView`

---

1. Creare pagina Dashboard.cshtml

```cs
@page
@model Dashboard
@namespace _04_webapp_sqlite.Prodotti
@{
    ViewData["Title"] = "Dashboard";
}
<h1>@ViewData["Title"]</h1>
<div class="container-fluid">
    <div class="row">
        <div class="col-4">
            <partial name="_ProdottiPiuCostosi" model="Model.ProdottiPiuCostosi" />
        </div>
        <div class="col-4">
            <partial name="_ProdottiRecenti" model="Model.ProdottiRecenti" />
        </div>
        <div class="col-4">
            <partial name="_ProdottiCategoriaSpecifica" model="Model.ProdottiCategoria" />
        </div>
    </div>
</div>
```

---

2. Creare i modelli Dashboard.cshtml.cs

```cs
namespace _04_webapp_sqlite.Prodotti;

public class Dashboard : PageModel
{
    private readonly ILogger<Dashboard> _logger;

    // Modelli da trasmettere alle partialView
    public List<ProdottoViewModel>? ProdottiPiuCostosi { get; set; } = new();
    public List<ProdottoViewModel>? ProdottiRecenti { get; set; } = new();
    public List<ProdottoViewModel>? ProdottiCategoria { get; set; } = new();

    public Dashboard(ILogger<Dashboard> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var queryCostosi = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Prezzo DESC LIMIT 5";

        ProdottiPiuCostosi = ExecuteQuery(queryCostosi);

        var queryRecenti = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Id DESC LIMIT 5";

        ProdottiRecenti = ExecuteQuery(queryRecenti);

        var queryCategoria = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                WHERE p.CategoriaId = 11 LIMIT 5";

        ProdottiCategoria = ExecuteQuery(queryCategoria);
    }

    // metodo per ottenere liste filtrate via query
    public List<ProdottoViewModel> ExecuteQuery(string query)
    {
        List<ProdottoViewModel> ProdottiFiltrati = new List<ProdottoViewModel>();
        using (var connection = DatabaseInitializer.GetConnection())
        {

            connection.Open();
            using (var command = new SQLiteCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        ProdottiFiltrati?.Add(new ProdottoViewModel
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Prezzo = reader.GetDouble(2),
                            // se la categoria è nulla, restituiamo "Nessuna categoria"
                            CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
                        });
                    }
                }
            }
        };
        return ProdottiFiltrati;
    }
}
```

3. Costruire le \_PartialView

> Prodotti Recenti

```cs
<h3>Prodotti Recenti</h3>

@foreach (var prodotto in Model)
{
    <strong class="fs-6" style="text-decoration: underline;">@prodotto.Nome</strong>
    <p class="fs-6" style=" display: inline;">@prodotto.Prezzo.ToString("F2") €</p>
    <p class="fs-6">@prodotto.CategoriaNome</p>

}
```

> Prodotti Più Costosi

```cs
<h3>Prodotti Più Costosi</h3>

@foreach (var prodotto in Model)
{
    <strong class="fs-6" style="text-decoration: underline;">@prodotto.Nome</strong>
    <p class="fs-6" style=" display: inline;">@prodotto.Prezzo.ToString("F2") €</p>
    <p class="fs-6">@prodotto.CategoriaNome</p>
}
```

> Prodotti in @categoria (Elettronica in questo caso)

```cs
@{
        string categoria = null;

        //ciclo per estrapolare nome categoria
        //categoria = Model.First().CategoriaNome
        foreach (var p in Model)
        {
                categoria = p.CategoriaNome;
        }

        <h3>Prodotti in @categoria</h3>

        @foreach (var prodotto in Model)
        {

                <strong class="fs-6" style="text-decoration: underline;">@prodotto.Nome</strong>
                <p class="fs-6" style=" display: inline;">@prodotto.Prezzo.ToString("F2") €</p>
                <p class="fs-6">@prodotto.CategoriaNome</p>
        }
}
```

# Comprensione del codice

Il tag `<partial>` richiede il nome della pagina attraverso `name ="_html"`, e il modello `model = "Model"`.

```cs
<partial name="_ProdottiPiuCostosi" model="Model.ProdottiPiuCostosi" />
```

In Model.ProdottiPiuCostosi, `Model` fa riferimento al modello indicato nella pagina Dashboard.cshtml (in questo caso `@model Dashboard`)

```cs
@page
@model Dashboard
@namespace _04_webapp_sqlite.Prodotti
@{
    ViewData["Title"] = "Dashboard";
}
```

Siccome nel modello `Dashboard.cshtml.cs` abbiamo definito 3 campi public

```cs
    public List<ProdottoViewModel>? ProdottiPiuCostosi { get; set; } = new();
    public List<ProdottoViewModel>? ProdottiRecenti { get; set; } = new();
    public List<ProdottoViewModel>? ProdottiCategoria { get; set; } = new();
```

possiamo trasmettere al `<partial>` il campo tramite la dicitura

```cs
Model.ProdottiPiuCostosi
Model.ProdottiRecenti
Model.ProdottiCategoria
```

Dunque ora nella partial ciò che è stato passato come `Model.ProdottiCategoria` va utilizzato come `Model`
Infatti, nel ciclo foreach, ciclo in Model.

```cs
@{
        string categoria = null;

        //Estrapolo CategoriaNome dal primo elemento della lista
        categoria = Model.First().CategoriaNome;

        <h3>Prodotti in @categoria</h3>

        // ciclo dentro Model che in realtà è ProdottiCategoria del modello Dashboard
        @foreach (var prodotto in Model)
        {

                <strong class="fs-6" style="text-decoration: underline;">@prodotto.Nome</strong>
                <p class="fs-6" style=" display: inline;">@prodotto.Prezzo.ToString("F2") €</p>
                <p class="fs-6">@prodotto.CategoriaNome</p>
        }
}
```

### Riassumendo:

1. Gestisco il filtraggio via SQL
2. Salvo le liste filtrate nei campi del modello Dashboard
3. Distribuisco i dati alle \_PartialView richiamando il campo interessato (es. Model.ProdottiPiuCostosi)

---

# UtilityDB.cs

Tre metodi

Esegue una query che non restituisce dati (INSERT, UPDATE, DELETE).

```cs
    public static int ExecuteNonQuery(string sql, Action<SqliteCommand> setupParameters = null)
```

Esegue una query che restituisce un valore scalare (esempio un Count) (valori singoli )

> Ambito di utilizzo: restituire un solo valore

```cs
    public static T ExecuteScalar<T>(string sql, Action<SqliteCommand> setupParameters = null)
```

Esegue una query che restituisce più righe e le converte in una lista di oggetti di tipo T.

```cs
    public static List<T> ExecuteReader<T>(string sql, Func<Sqlitereader, T> converter, Action<SQLiteCommand> setupParameters)
```

```cs
using Microsoft.Data.Sqlite;

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
        setupParameters?.Invoke(command); // Il metodo Invoke esegue il delegate setupParameters, cioè la funzione che gli passiamo

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
    public static List<T> ExecuteReader<T>(string sql, Func<Sqlitereader, T> converter, Action<SQLiteCommand> setupParameters)
    {
        var list = new List<T>();
        using var connection = DatabaseInitializer.GetConnection();
        using var command = new SQLiteCommand(sql, connection);
        setupParameters?.Invoke(command);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(converter(reader));
        }
        return list;
    }
}

```

SimpleLogger.cs

```cs
public static class SimpleLogger
{
    // Percorso del file di log (puoi modificare il percorso se necessario)
    private static readonly string logFilePath = "log.txt";

    /// <summary>
    /// Registra un messaggio nel file di log con data e ora.
    /// </summary>
    /// <param name="message">Il messaggio da loggare.</param>
    public static void Log(string message)
    {
        try
        {
            using StreamWriter writer = new StreamWriter(logFilePath, append: true);
            writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }
        catch (Exception)
        {
            // Se il logging fallisce, l'errore viene ignorato.
        }
    }

    /// <summary>
    /// Registra un'eccezione nel file di log.
    /// </summary>
    /// <param name="ex">L'eccezione da loggare.</param>
    public static void Log(Exception ex)
    {
        Log($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");
    }
}
```

# 17/02/2025

Utilizzo della classe UtilityDB (esempio lettura `List<Categoria>`)

```cs
try
{
    Categorie = UtilityDB.ExecuteReader("SELECT * FROM Categorie", reader => new Categoria
    {
        Id = reader.GetInt32(0),
        Nome = reader.GetString(1)
    });
}
catch (Exception ex)
{
    SimpleLogger.Log(ex);
}
```

Utilizzo della classe UtilityDB (esempio lettura `List<ProdottoViewModel>`):
```cs
try
{
    Prodotti = UtilityDB.ExecuteReader(@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
    FROM Prodotti p
    LEFT JOIN Categorie c ON p.CategoriaId = c.Id
    WHERE c.Id = @id", reader => new ProdottoViewModel
    {
        Id = reader.GetInt32(0),
        Nome = reader.GetString(1),
        Prezzo = reader.GetDouble(2),
        // se la categoria è nulla, restituiamo "Nessuna categoria"
        CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
    },
    command =>
    {
        command.Parameters.AddWithValue("@id", IdCategoria);
    }
    );      
}
catch (Exception ex)
{
    SimpleLogger.Log(ex);
}
```

Esempio Inserimento prodotto (scrittura con passaggio di parametri):

```cs
var sql = @"INSERT INTO Prodotti (Nome, Prezzo, CategoriaId) VALUES (@nome, @prezzo, @categoria)";
try
{
    UtilityDB.ExecuteNonQuery(sql, command =>
    {
        command.Parameters.AddWithValue("@nome", Prodotto.Nome);
        command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
        command.Parameters.AddWithValue("@categoria", Prodotto.CategoriaId);
    }
    );
}
catch (Exception ex)
{
    SimpleLogger.Log(ex);
        }
```

Dettaglio prodotto (leggendo una lista e associando al modello il singolo oggetto):

```cs
public ProdottoViewModel? Prodotto { get; set; } = new();
```

```cs
try
{
    var prodotti = UtilityDB.ExecuteReader(@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
        FROM Prodotti p
        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
        WHERE p.Id = @id", reader => new ProdottoViewModel
    {
        Id = reader.GetInt32(0),
        Nome = reader.GetString(1),
        Prezzo = reader.GetDouble(2),
        // se la categoria è nulla, restituiamo "Nessuna categoria"
        CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
    },
    command =>
    {
        command.Parameters.AddWithValue("@id", id);
    }
    );

    // inizializzo il campo 'Prodotto' della classe Dettaglio.cshtml.cs 
    // con il primo (e unico elemento) della lista 'var prodotti' attraverso 
    // il metodo .First()
    Prodotto = prodotti.First(); 
}
catch (Exception ex)
{
    SimpleLogger.Log(ex);
}
```

---

Estrazione di un singolo elemento attraverso ExecuteScalar (da testare):

```cs
Prodotto = UtilityDB.ExecuteScalar<ProdottoViewModel>(@"SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
        FROM Prodotti p
        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
        WHERE p.Id = @id", reader => new ProdottoViewModel
    {
        Id = reader.GetInt32(0),
        Nome = reader.GetString(1),
        Prezzo = reader.GetDouble(2),
        // se la categoria è nulla, restituiamo "Nessuna categoria"
        CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
    },
    command =>
    {
        command.Parameters.AddWithValue("@id", id);
    }
    );
```

---


Nuova classe Dashboard che esegue le query attraverso le UtilityDB:

```cs
public void OnGet()
    {
        var queryCostosi = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Prezzo DESC LIMIT 5";
        try
        {
            ProdottiPiuCostosi = UtilityDB.ExecuteReader(queryCostosi, reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        var queryRecenti = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                ORDER BY p.Id DESC LIMIT 5";
        try
        {
            ProdottiRecenti = UtilityDB.ExecuteReader(queryRecenti, reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        var queryCategoria = @"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as Categoria
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                WHERE p.CategoriaId = 11 LIMIT 5";
        try
        {
            ProdottiCategoria = UtilityDB.ExecuteReader(queryCategoria, reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                // se la categoria è nulla, restituiamo "Nessuna categoria"
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
            });
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
```


