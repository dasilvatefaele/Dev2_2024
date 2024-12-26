# SIMULAZIONE SUPERMERCATO

---

### Struttura `prodottiConPrezzo`

```csharp
// Struttura del prodotto
var prodottiConPrezzo = new Dictionary<string,double[]>();
```

### Struttura `carrello`

```csharp
var carrello = new Dictionary<string,double[]>();
```

> NOTE IMPORTANTI:
> 
> Dal momento che dovremmo spostare lo stesso oggetto da un posto all'altro, ha senso utilizzare la stessa struttura di dati!

---



> Esempio di inizializzazione del dizionario `string/double[]`

```csharp

const int PREZZO = 0;
const int QUANTITA = 1 ; 
// indici dell'array

var prodottiConPrezzo = new Dictionary<string, double[]>
{
    {"LATTE INTERO", new double [] {2.89, 1}}
};

// ESEMPIO DI ACCESSO AI DATI:
// prodottiConPrezzo["LATTE INTERO"][PREZZO] = 2.89; 
// prodottiConPrezzo["LATTE INTERO"][QUANTITA] = 1; 


```

## Bug 1: Funzione VisualizzaProdotti

Data la struttura di dati `Dictionary<string, double[]>` la stampa via ciclo `foreach` non da in output i prezzi. 

> Codice attuale
> 
> ```csharp
> void VisualizzaProdotti(Dictionary<string, double[]> prodottiConPrezzo)
> {
>     Console.WriteLine("--- PRODOTTI DISPONIBILI ---");
>     foreach (var prodotto in prodottiConPrezzo)
>     {
>         Console.WriteLine(prodotto);
>     }
>     Console.WriteLine();
> }
> ```

> output
> 
> ```
> --- PRODOTTI DISPONIBILI ---
> [LATTE INTERO, System.Double[]]
> [MELA, System.Double[]]
> [PANE INTEGRALE, System.Double[]]
> [BANANA, System.Double[]]
> [ACQUA NATURALE, System.Double[]]
> [BISCOTTI AL CIOCCOLATO, System.Double[]]
> [RISO BASMATI, System.Double[]]
> [FORMAGGIO GRATTUGGIATO, System.Double[]]
> ```

## Risoluzione Bug 1

> Nuovo Codice
> 
> ```csharp
> void VisualizzaProdotti(Dictionary<string, double[]> prodottiConPrezzo)
> {
>     Console.WriteLine("--- PRODOTTI DISPONIBILI ---");
>     Console.WriteLine("[Prezzo]\t[Prodotto]");
>     foreach (var prodotto in prodottiConPrezzo)
>     {
>         Console.WriteLine($"{prodotto.Value[PREZZO]}\t\t{prodotto.Key}");
>     }
>     Console.WriteLine();
> }
> ```

**Info** risoluzione del bug:

Nel ciclo `foreach`, grazie al metodo `.Value` sulla var placeholder, ho avuto accesso all'array `double[]` del dizionario `prodottiConPrezzo`  e attraerso la costante `PREZZO` di valore `0` ho avuto accesso all'indice  dove ho scelto di immagazzinare il prezzo del prodotto.

---


