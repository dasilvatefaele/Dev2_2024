// Persistenza dei dati .csv

// ESEMPIO DI FILE CSV

// nome,cognome,eta
// Mario,Rossi,30
// Luigi,Bianchi,25

// LEGGERE UN CONTENUTO DA FILE CSV

Console.Clear();
string path = @"test.csv";
string[] lines = File.ReadAllLines(path);

foreach (string line in lines)
{
    Console.WriteLine(line); // stampa la riga
}

// creare una lista di stringhe partendo dal file csv

List<string> prodotti = new List<string>();

foreach (string line in lines)
{
    prodotti.Add(line);
}

// creare un file CSV con il nome del file che corrisponde al nome della prima colonna 
// ed il contenuto del file che corrisponde al contenuto delle altre colonne disponibili

int i = 0;

foreach (string line in prodotti)
{
    if (i != 0)
    {
        string[] elenco = line.Split(',');
        string nomeProdotto = elenco[0];
        string quantita = elenco[1];
        string prezzo = elenco[2];
        string newFile = $@"{nomeProdotto}.csv";
        File.Create(newFile).Close();
        File.AppendAllText(newFile, $"Quantità: {quantita}\nPrezzo: {prezzo}");
    }
    i++;
}

// salvare in un file .csv gli input dell'utente 

while(true)
{
    Console.WriteLine("Inserire PRODOTTO:"); 
    string nomeProdotto2 = Console.ReadLine();

    Console.WriteLine("Inserire QUANTITA:");
    string quantita2 = Console.ReadLine();

    Console.WriteLine("Inserire PREZZO:");
    string prezzo2 = Console.ReadLine();

    File.AppendAllText(path, $"{nomeProdotto2},{quantita2},{prezzo2}\n");  

    Console.WriteLine("Inserire nuovo prodotto? [s/n]");
    string risposta = Console.ReadLine();
    if (risposta.ToLower() == "n")
    {
        break;
    }
}

// Eliminare un elemento specifico da un file .csv (tutta una riga - prodotto, quantità, prezzo)

Console.WriteLine("Quale prodotto eliminare?");

string prodottoDaEliminare = Console.ReadLine(); 

 string [] lines2 = File.ReadAllLines(path);
 File.Create(path).Close();

 foreach (string line in lines2)
{
    string[] data2 = line.Split(',');
    if (data2[0] != prodottoDaEliminare)
    {
        File.AppendAllText(path, line + "\n");
    }
}

// Modificare un elemento specifico da un file .csv (tutta una riga - prodotto, quantità, prezzo) 

Console.WriteLine("Quale prodotto modificare?");

string prodottoDaModificare = Console.ReadLine(); 

 lines2 = File.ReadAllLines(path);
 File.Create(path).Close();

foreach (string line in lines2)
{
    string[] data2 = line.Split(',');

    if (data2[0] != prodottoDaModificare)
    {
       File.AppendAllText(path, line + "\n");
    }
    else
    {
        // Console.WriteLine("Inserire PRODOTTO:"); 
        // string nomeProdotto2 = Console.ReadLine();

        Console.WriteLine("Inserire QUANTITA:");
        string quantita2 = Console.ReadLine();

        Console.WriteLine("Inserire PREZZO:");
        string prezzo2 = Console.ReadLine();

        File.AppendAllText(path, $"{prodottoDaModificare},{quantita2},{prezzo2}\n");
    }
}