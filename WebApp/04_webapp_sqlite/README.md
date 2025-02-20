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
namespace _04_webapp_sqlite.Models;

public class Prodotto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome del prodotto è obbligatorio.")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Il prezzo è obbligatorio.")]
    [Range (0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di 0")]
    public double Prezzo { get; set; }

    [Required(ErrorMessage = "La categoria è obbligatoria.")]
    public int CategoriaId { get; set; }
    [Required(ErrorMessage = "Il fornitore è obbligatorio.")]
    public int FornitoreId { get; set; }
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
                // Usiamo LEFT JOIN invece che JOIN per prendere anche i prodotti che non hanno una categoria associata
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

### Delegati

Uso Action per passare un metodo come parametri (in questo caso`Action<SQLiteCommand> setupParameters`).

`Invoke()` invoca il metodo passando come parametro il comando.

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

### Da testare (NON FUNZIONA)

Estrazione di un singolo elemento attraverso ExecuteScalar:

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

### NON FUNZIONA: motivo

`ExecuteScalar` non contiene il `ExecuteReader()` ma esegue il comando di SQLite `ExecuteScalar()`, che attraverso la Query restituisce un valore numerico, tipo `int`.

# USO CORRETTO:

```cs
public int TotaleProdotti { get; set; }
```

```cs
try
        {
            TotaleProdotti = UtilityDB.ExecuteScalar<int>("SELECT COUNT (*) FROM Prodotti");
        }
        catch(Exception ex)
        {
            SimpleLogger.Log(ex);
        }
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

---

## Implementazione Extra:

Da pagina Dettaglio, il tasto `Indietro` fa tornare alla pagina precedente alla relativa

Esempio:

> Front-End

```html
<form method="post">
  <input type="hidden" name="returnUrl"
  value="@HttpContext.Request.Headers["Referer"]" />
  <button type="submit" class="btn btn-primary">Indietro</button>
</form>
```

> Back-End

```cs
public IActionResult OnPost(string? returnUrl)
    {
        if (!string.IsNullOrEmpty(returnUrl))
        {
            return Redirect(returnUrl);
        }

        return RedirectToPage("Index"); // Se non c'è un URL di ritorno, vai a Index
    }
```

### Spiegazione:

Nel tag `<form method="post">`, attraverso un input nascosto

```html
<input type="hidden" name="returnUrl"
value="@HttpContext.Request.Headers["Referer"]" />
```

passiamo alla variabile stringa `returnUrl` il valore `@HttpContext.Request.Headers["Referer"]`, dove `"Referer"` contiene l'URL della pagina da cui proviene l'utente.

Se `returnUrl` NON è `Null` o `Empty` reindirizza verso la relativa pagina precedente:

```cs
return Redirect(returnUrl);
```

Nel caso invece la stringa sia vuota, reindizza all'index:

```cs
return RedirectToPage("Index");
```

# 18/02/2025

Necessita di:

```cs
using System.Globalization;
```

PriceFormatter.cs

```cs
/// <summary>
///  Formatta un valore double come valuta.
/// </summary>
/// <param name="price">Il prezzo da formattare.</param>
/// <returns>Una stringa formattata come valuta.</returns
public static class PriceFormatter
{
    public static string Format (double price)
    {
        return price.ToString("C", CultureInfo.CurrentCulture);
    }
}
```

Esempio di utilizzo:

```html
<td>@PriceFormatter.Format(prodotto.Prezzo)</td>
```

---

# Paginazione

## Classe della paginazione

PaginatedList.cs

```cs
public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count/(double)pageSize);
        this.AddRange(items); // Aggiunge gli elementi alla lista usando 'this'
        // che si riferisce alla lista stessa
    }

    public bool HasPreviewPage => PageIndex >1; // restituisce true
    // se c'è una pagina precedente
    public bool HasNextPage => PageIndex < TotalPages; // restituisce true
    // se c'è una pagina successiva
}
```

## Modello della paginazione

PaginationModel.cs

Questo modello viene usato nelle partial view per generare i link di paginazione. Include le informazioni sulla pagina corrente, sul numero totale di pagine e una funzione per generare l'URL di ciascuna pagina.

```cs
public class PaginationModel
{
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviewPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
    public Func<int, string> PageUrl { get; set; }
}
```

## Front-End della partial

Creiamo una partial per la paginazione

```html
@model PaginationModel
<nav aria-label="Page navigation">
  <ul class="pagination">
    @if (Model.HasPreviewPage) {
    <li class="page-item">
      <a
        class="page-link"
        href="@Model.PageUrl(Model.PageIndex - 1)"
        aria-label="Previous">
        <span aria-hidden="true">&laquo;</span>
      </a>
    </li>
    } else {
    <li class="page-item disabled">
      <span aria-hidden="true" aria-label="Previous">&laquo;</span>
    </li>
    } @for (int i = 1; i <= Model.TotalPages; i++) { if (i == Model.PageIndex) {
    <li class="page-item active">
      <span class="page-link">@i</span>
    </li>
    } else {
    <li class="page-item">
      <a class="page-link" href="@Model.PageUrl(i)"></a>
    </li>
    } } @if (Model.HasNextPage) {
    <li class="page-item">
      <a
        class="page-link"
        href="@Model.PageUrl(Model.PageIndex + 1)"
        aria-label="Next">
        <span aria-hidden="true">&raquo;</span>
      </a>
    </li>
    } else {
    <li class="page-item disabled">
      <span class="page-link" aria-label="Next">
        <span aria-hidden="true" aria-label="Previous">&raquo;</span>
      </span>
    </li>
    }
  </ul>
</nav>
```

#

PaginatedIndex.cshtml.cs

```cs
namespace _04_webapp_sqlite.Prodotti;

public class PaginatedIndexModel : PageModel
{
    public PaginatedList<ProdottoViewModel> Products { get; set; }
    public int PageSize { get; set; } = 5; // numero di prodotti per pagina
    public void OnGet(int? pageIndex)
    {
        // L'espressione sotto equivale a:

        // int currentPage;
        // if (pageIndex != null)
        // {
        //     currentPage = pageIndex.Value; // Estrai il valore dall'Nullable<int>
        // }
        // else
        // {
        //     currentPage = 1;
        // }

        int currentpage = pageIndex ?? 1;

        //recupera il numero totale di prodotti
        int totalCount = UtilityDB.ExecuteScalar<int>("SELECT COUNT(*) FROM Prodotti");
        //calcola l'offest per la query
        int offset = (currentpage - 1) * PageSize;

        // Recupera i prodotti per la pagina corrente
        // in SQLite si usa LIMIT  e OFFSET per la paginazione
        // limit = quanti elementi voglio
        // offset = da dove voglio partire
        // offset = (pagina corrente - 1) * elementi per pagina
        // LIMIT 5 OFFSET 0 -> 5 elementi a partire dall'elemento 0

        string sql = $@"
                        SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
                        FROM Prodotti p
                        LEFT JOIN Categorie c ON p.Categorie = c.Id
                        ORDER BY p.Id
                        LIMIR {PageSize} OFFSET {offset}
                        ";

        var items = UtilityDB.ExecuteReader(sql, reader => new ProdottoViewModel
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Prezzo = reader.GetDouble(2),
            // se la categoria è nulla, restituiamo "Nessuna categoria"
            CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3)
        });

        Products = new PaginatedList<ProdottoViewModel>(items, totalCount, currentpage, PageSize);
    }
}
```

## Front-end della pagina

PaginatedIndex.cshtml

```html
@page "PaginatedIndex"
@model PaginatedIndexModel
@namespace _04_webapp_sqlite.Prodotti
@{
    ViewData["Title"] = "Prodotti impaginati";
    // configuriamo il modello per la paginazione
    PaginationModel paginationModel = new PaginationModel
    {
        PageIndex = Model.Products.PageIndex,
        TotalPages = Model.Products.TotalPages,
        PageUrl = page => Url.Page("PaginatedIndex", new { pageIndex = page })
    };
}

<div class="container">
    <table class="table">
        <thead>
            <tr>
                <th class="">Nome</th>
                <th class="" style="display:block">Prezzo</th>
                <th class="">Categoria</th>
                <th class="">Actions</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var prodotto in Model.Products)
            {
                <tr>
                    <td class="">
                        <a asp-page="Dettaglio" asp-route-id="@prodotto.Id">
                            @prodotto.Nome
                        </a>
                    </td>
                    <td>@PriceFormatter.Format(prodotto.Prezzo)</td>
                    <td class="">@prodotto.CategoriaNome</td>

                    <td><a asp-route-id="@prodotto.Id" asp-page="Modifica">
                            <div class="btn green"><i class="fa-solid fa-pen-to-square" style="color:white"></i>
                            </div>
                        </a>

                        <a asp-page="Elimina" asp-route-id="@prodotto.Id">
                            <div class="btn red"><i class="fa-solid fa-trash" style="color:white"></i></div>
                        </a>
                    </td>
                </tr>
            }

        </tbody>
    </table>
    <partial name="_Pagination" model="paginationModel">
</div>
```

# 19/02/2025

Utility che restituisce un `.css` a seconda delle condizioni.

```cs
///<summary>
/// Restituisce "active" se currentPage è uguale a expectedPage (ignorano il case), altrimenti una stringa vuota.
///</summary>
public static class FrontendUtil
{
    public static string ActiveClass(string currentPage, string expectedPage)
    {
        return currentPage.Equals(expectedPage, StringComparison.OrdinalIgnoreCase) ? "active" : "";
    }
}
```

Utilizzo:

```html
 <li class="nav-item">
    <a class="nav-link @FrontendUtil.ActiveClass(ViewContext.RouteData.Values["page"]?.ToString() ?? "", "/Index")" asp-area="" asp-page="/Index">Home</a>
</li>
```

```css
.active{
  text-decoration: underline;
  color: white;
}
```


# 20/02/2025

Implementazione fornitori:

> Note: non essendo stati esplicitati i campi necessari, la classe fornitori conterrà 
solo i campi Id, Nome, Contatto

+ 1 Creazione del modello

Modello fornitori `Fornitori.cs`
```cs
namespace _04_webapp_sqlite.Models;

public class Fornitori
{
    public int Id { get; set; }
    public string Nome { get; set; }
    [Required]
    [EmailAddress]
    public string Contatto { get; set; }
}
```

Modifico modello Prodotti e ProdottoViewModel per contenere anche Id del fornitore

Prodotto.cs

```cs
using System.ComponentModel.DataAnnotations;

// Modello del prodotto
namespace _04_webapp_sqlite.Models;

public class Prodotto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome del prodotto è obbligatorio.")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Il prezzo è obbligatorio.")]
    [Range (0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di 0")]
    public double Prezzo { get; set; }

    [Required(ErrorMessage = "La categoria è obbligatoria.")]
    public int CategoriaId { get; set; }
    public int FornitorieId { get; set; }
}
```

ProdottoViewModel.cs

```cs
namespace _04_webapp_sqlite.Models;
public class ProdottoViewModel {
    // proprietà
    public int Id { get; set; }
    public string? Nome { get; set; }
    public double Prezzo { get; set; }
    public string? CategoriaNome { get; set; }
    // Attraverso la LEFT JOIN sarà collegato il nome del fornitore
    // attraverso il suo Id
    public string? FornitoreNome { get; set; } 
}
```

+ 2 Creazione della tabella Fornitori in `DatabaseInitializer.cs`

```cs
// Se la tabella non esistente creo la tabella la creo tramite query e ExecuteNonQuery
string createFornitoriTabella = @"CREATE TABLE IF NOT EXISTS Fornitori (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nome TEXT NOT NULL,
    Contatto TEXT NOT NULL";
    
// Eseguo il comando SQL
UtilityDB.ExecuteNonQuery(createFornitoriTabella);
```

Modifico la query di creazione dei prodotti per ospitare i fornitori (sarà necessario eliminare il Database per re-Inizializzarlo con le nuove tabelle)

```cs
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
using (var command = new SQLiteCommand(createCategorieTabella, connection)) {
    // eseguiamo il comando
    command.ExecuteNonQuery();
};
```

> NOTA: necessario creare prima la tabella dei fornitori e delle categorie dal momento
che i prodotti faranno riferimento all'Id delle due tabelle

+ 3 Seeding dei fornitori

```cs
// Leggo il numero di elementi nella tabella Fornitori del DB
var countFornitori = UtilityDB.ExecuteScalar<int>("SELECT COUNT (*) FROM Fornitori");
// Se la tabella è vuota eseguo il seeding
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

+ 4 Seeding dei prodotti con collegamento alla tabella fornitori

```cs

var countProdotti = (long)countProdottiCommand.ExecuteScalar();
// se non ci sono prodotti li creiamo
if (countProdotti == 0){
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
    using (var command = new SQLiteCommand(insertProdotti, connection)) {
        command.ExecuteNonQuery();                
    }
}
```

+ 5 Distrubuzione dei dati

Distribuzione dei dati del modello aggiornato da DB in Index.cshtml.cs 

```cs
List<ProdottoViewModel> items = UtilityDB.ExecuteReader($@"
                SELECT p.Id, p.Nome, p.Prezzo, 
                c.Nome as Categoria,
                f.Nome as Fornitore
                FROM Prodotti p
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                LEFT JOIN Fornitori f ON p.FornitoreId = f.Id
                ORDER BY p.Nome LIMIT {PageSize} OFFSET {offset}", reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    // se la categoria è nulla, restituiamo "Nessuna categoria"
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna categoria" : reader.GetString(3),
                    FornitoreNome = reader.IsDBNull(4) ? "Nessun fornitore" : reader.GetString(4),
                });

Prodotti = new PaginatedList<ProdottoViewModel>(items, totalCount, currentpage, PageSize);
```

+ 6 Visualizzazione del campo fornitore in `Prodotti/Index`

Aggiungo la colonna Fornitori alla tabella 

```html
<th class="">Fornitore</th>
```

Aggiungo il campo alla colonna 

```html
@foreach (var prodotto in Model.Prodotti)
{
    <tr>
        ...
        <td class="">@prodotto.FornitoreNome</td>
        ...
    </tr>
}
```

---

# TODO:

- [x] Gestione CRUD dei prodotti <u>considerando la modifica ai due modelli</u> (`Prodotto.cs` e `ProdottoView.cs`)

- [x] Creazione di una pagina `Dettaglio Fornitore` che esporrà il contatto del fornitore. 
- [x] Creazione di una pagina `Lista Fornitori`, con link a `Dettaglio Fornitore`
- [x] Implementae operazioni CRUD sui Fornitori


- [ ] La pagina deve essere accessibile tramite link da Prodotti/Index. 
*NOTA* : il modello ProdottoViewModel possiede il `Nome` del fornitore ma non il suo `Id`
chè è richiesto per eseguire la query di `Fornitori/Dettaglio.cshtmlcs`.

Possibile patch: discrinare nell OnGet se Id è null, esegui una query che cerca per nome
e espone i dati dell'oggetto trovato







