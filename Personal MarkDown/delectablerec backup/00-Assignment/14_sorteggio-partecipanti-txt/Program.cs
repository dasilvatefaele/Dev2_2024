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