# Sorteggio Partecipanti
## Versione 1

### Obiettivo
- Scrivere un programma che permetta di sorteggiare i partecipanti deel corso da una lista di nomi.
- Il programma estrae un partecipante singolo alla volta e lo stampa a video.

```csharp
Console.Clear();
string[] nomePartecipante = new string [8];
Random random = new Random();
int estrai;

nomePartecipante [0] = "Andrea";
nomePartecipante [1] = "Anita";
nomePartecipante [2] = "Diego";
nomePartecipante [3] = "Felipe";
nomePartecipante [4] = "Giorgio";
nomePartecipante [5] = "Ivan";
nomePartecipante [6] = "Sofia";
nomePartecipante [7] = "Tamer";

estrai = random.Next(0,8);

Console.WriteLine($"Il computer ha estratto... {nomePartecipante[estrai]}!");
```

> Comandi di versionamento
```powershell
git add --all
git commit -m "Sorteggio Partecipanti v1.0"
git push -u origin main
```