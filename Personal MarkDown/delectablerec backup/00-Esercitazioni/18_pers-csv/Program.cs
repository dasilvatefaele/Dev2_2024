// GESTIONE FILES CSV

// ESEMPIO DI FILE CSV

// prodotto,quantita,prezzo
// Macchina,11,30
// Mouse,10,25

// LEGGERE UN CONTENUTO DA UN FILE CSV

string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
string[] lines = File.ReadAllLines(path); // legge tutte le righe del file e le mette in un array di stringhe

foreach (string line in lines)
{
    Console.WriteLine(line); // stampa la riga
}

// creare una lista di stringhe partendo dal file CSV

List<string> list = new List<string>();

foreach (string line in lines)
{
    list.Add(line);
}

// creare un file CSV con il nome del file che corrisponde al nome della prima colonna
// ed il contenuto del file che corrisponde al contenuto delle altre colonne disponibili

string[][] data = new string[lines.Length][];
for (int i = 0; i < lines.Length; i++)
{
    data[i] = lines[i].Split(','); // divide la riga in base alla virgola e mette i pezzi in un array di stringhe
}

for (int i = 1; i < data.Length; i++)
{
    string path2 = $"{data[i][0]}.csv"; // il nome del file è il nome del prodotto
    File.Create(path2).Close(); // crea il file e lo chiude subito

    for (int j = 1; j < data[i].Length; j++)
    {
        File.AppendAllText(path2, data[i][j] + "\n"); // scrive il contenuto del file [i] è il nome del prodotto e [j] è il contenuto delle altre colonne
    }
}

// salvare in un file CSV gli input inseriti dall utente (prodotto, quantita, prezzo)

while (true)
{
    Console.WriteLine("inserisci nome");
    string prodotto = Console.ReadLine();
    Console.WriteLine("inserisci quantita");
    string quantita = Console.ReadLine();
    Console.WriteLine("inserisci prezzo");
    string prezzo = Console.ReadLine();
    File.AppendAllText(path,$"\n{prodotto},{quantita},{prezzo}");
    Console.WriteLine("vuoi inserire un altro prodotto? (s/n)");
    string risposta = Console.ReadLine();
    if (risposta == "n")
    {
        break;
    }
}

// eliminare un elemento specifico da un file csv (prodotto, quantita, prezzo)

Console.WriteLine("inserisci il nome del prodotto da eliminare");
string prodottoDaEliminare = Console.ReadLine();
string[] lines2 = File.ReadAllLines(path);
File.Create(path).Close(); // bisogna creare il file perche altrimenti non si cancella il contenuto

foreach (string line in lines2)
{
    string[] data2 = line.Split(',');
    if (data2[0] != prodottoDaEliminare)
    {
        File.AppendAllText(path, line + "\n");
    }
}

// modificare un elemento specifico da un file csv (prodotto, quantita, prezzo)

Console.WriteLine("inserisci il nome del prodotto da modificare");
string prodottoDaModificare = Console.ReadLine();
string[] lines3 = File.ReadAllLines(path);
File.Create(path).Close(); // bisogna creare il file perche altrimenti non si cancella il contenuto

foreach (string line in lines3)
{
    string[] data3 = line.Split(',');
    if (data3[0] == prodottoDaModificare)
    {
        Console.WriteLine("inserisci la nuova quantita");
        string nuovaQuantita = Console.ReadLine();
        Console.WriteLine("inserisci il nuovo prezzo");
        string nuovoPrezzo = Console.ReadLine();
        File.AppendAllText(path, $"{prodottoDaModificare},{nuovaQuantita},{nuovoPrezzo}\n");
    }
    else
    {
        File.AppendAllText(path, line + "\n");
    }
}