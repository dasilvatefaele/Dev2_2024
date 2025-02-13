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

# 4. che nel back-end ci sia nell' OnPost() il controllo della validazione

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

