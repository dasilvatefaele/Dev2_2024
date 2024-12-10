// // TEST CASES

// Console.Clear();
// //! MAIN
// var provaDizionario = new Dictionary<string, int>
// {
//     {"default", 0},
// };
// bool provaBooleana = false;

// Console.Write("\n***************************");
// Console.WriteLine("PRE Funzioni:");
// foreach (var elementi in provaDizionario)
// {
//     Console.WriteLine(elementi);
// }
// Console.WriteLine(provaBooleana);

// ModificaDizionario(provaDizionario);
// ModificaBooleana(provaBooleana);

// Console.WriteLine("***************************");
// Console.WriteLine("POST Funzioni:");
// foreach (var elementi in provaDizionario)
// {
//     Console.WriteLine(elementi);
// }
// Console.WriteLine(provaBooleana);


// //! FUNZIONI

// void ModificaDizionario(Dictionary<string, int> b)
// {
//     b["aggiunta"] = 1;
//     //Console.WriteLine(b["default"]);
// }

// void ModificaBooleana(bool c)
// {
//     c = true;
// }

// //Ottenere info su una directory
// string dir = "."; // parto dalla cartella del progetto dotnet nel quale sono 
// DirectoryInfo dirInfo = new DirectoryInfo(dir);
// Console.WriteLine(dirInfo.CreationTime);

// // Ottenere info su tutti i file in una directory (SOLO FILE)
// string[] files = Directory.GetFiles(dir);
// foreach(string file in files)
// {
//     Console.WriteLine(file);
// }

// // ottenere info su tutti i file e le dir in una dir (FILE E CARTELLE)
// string[] all = Directory.GetFileSystemEntries(dir);
// foreach( string a in all)
// {
//     Console.WriteLine(a);
// }

// // ottenere informazioni su tutti i file e dir in una dir con un filtro
// string[] txtFiles = Directory.GetFiles(dir,"*.txt");
// foreach (string txtFile in txtFiles)
// {
//     Console.WriteLine(txtFile);
// }

// string path = @"test.txt";
// File.Create(path).Close();
// List<string> elencoDiAnimali = new List<string> { "cane", "gatto", "topo", "gallina", "mucca" };
// File.AppendAllLines(path, elencoDiAnimali);

// string content = File.ReadAllText(path);

// Console.WriteLine(content);



class Program
{
    static void Main (string[] args)  // <--- Entry Point
    {
        Pokemon pokemon = new Pokemon(); // <--- Creazione dell'oggetto pokemon

        Console.WriteLine($"{pokemon.nome} usa {pokemon.attacco}");
    }
}

public class Pokemon // <--- Definizione Classe di un oggetto
{
    public string nome = "Pikachu";
    public string attacco = "Elettroshock!";
}