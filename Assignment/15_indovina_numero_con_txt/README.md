# INDOVINA NUMERO CON .txt

## Obiettivo

> Versione 1

Implementare la persistenza del gioco "indovina numero" su un file di testo (versione con funzioni).

- Implementare una funzione che scriva l'elenco dei tentativi fatti dall'utente su un file di testo. 

- Il programma chiede all'utente di inserire il proprio nome ed usa il nome (input utente) per creare un file di testo con il nome dell'utente (esempio "nomeutente.txt")


> Versionamento:

```powershell
git add --all
git commit -m "Indovina numero con txt v1"
git push -u origin main
```

---

> Versione 2

## Implementazioni:
- Usare lo `using` e il costruttore `new StreamWriter` per scrivere su un file.
- Stampo il timestamp all'interno del file al primo accesso

```csharp
void SalvaTentativi(List<int> numeri, string nomePlayer, bool primoAccesso)
{
    using (StreamWriter sw = new StreamWriter($"{nomePlayer}.txt"))
    {

        foreach (int numero in numeri )
        {
            if (primoAccesso)
            {
            sw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy-HH:mm"));
            }
            primoAccesso= false;
            sw.WriteLine($"{numero}");
        }
        
    }

}
```

> Versionamento:

```powershell
git add --all
git commit -m "Indovina numero con txt v2"
git push -u origin main
```

---

> Versione 3

## Implementazioni:

-
-
-


> Versionamento:

```powershell
git add --all
git commit -m "Indovina numero con txt v3"
git push -u origin main
```