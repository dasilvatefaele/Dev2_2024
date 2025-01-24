# Sorteggio partecipanti con salvataggio su txt

## Obiettivo

- Creare un applicazione csharp che permetta di:
- Sorteggiare i partecipanti da una lista di nomi presi da un file txt.
- I nomi sorteggiati devono essere salvati su un file txt di output.
- Il programma chiede all utente quanti nomi sorteggiare

## Consigli

- Creare un file txt con una lista di nomi
- Creare un file txt di output
- Creare una funzione che legga i nomi dal file txt
- Creare una funzione che chieda all utente il numero di nomi da sorteggiare
- Creare una funzione che sorteggi i nomi
- Creare una funzione che scriva i nomi sorteggiati sul file txt di output
- Creare una funzione che chieda all utente se vuole sorteggiare altri nomi

## Versione 1

```csharp
string[] partecipanti = LeggiPartecipanti("partecipanti.txt");
List<string> sorteggiati = new List<string>();
List<string> partecipantiList = new List<string>(partecipanti);

do
{
    Console.Write("Quanti partecipanti vuoi sorteggiare? ");
    int n = int.Parse(Console.ReadLine());

    for (int i = 0; i < n; i++)
    {
        // string sorteggiato = Sorteggia(partecipanti);
        string sorteggiato = SorteggiaAdv(partecipanti, ref partecipantiList);
        sorteggiati.Add(sorteggiato);
        Console.WriteLine($"Sorteggiato: {sorteggiato}");
    }

    Console.Write("Vuoi sorteggiare altri partecipanti? (s/n) ");
} while (Console.ReadLine().ToLower() == "s");

SalvaSorteggiati(sorteggiati, "sorteggiati.txt");


static string[] LeggiPartecipanti(string path)
{
return File.ReadAllLines(path);
}

static string Sorteggia(string[] partecipanti)
{
Random random = new Random();
int index = random.Next(partecipanti.Length);
return partecipanti[index];
}

static void SalvaSorteggiati(List<string> sorteggiati, string path)
{
File.WriteAllLines(path, sorteggiati);
}

static string SorteggiaAdv(string[] partecipanti, ref List<string> partecipantiList)
{
Random random = new Random();
int index = random.Next(partecipantiList.Count);
string sorteggiato = partecipantiList[index];
partecipantiList.RemoveAt(index);
return sorteggiato;
}
    
```