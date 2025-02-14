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
<span asp-validation-for="Prodotto.Nome" class="text-danger"><span>
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

3. Costruire le _PartialView

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
3. Distribuisco i dati alle _PartialView richiamando il campo interessato (es. Model.ProdottiPiuCostosi)

---
