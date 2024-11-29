# PERSISTENZA DEI DATI

---

### Task: Creare, Leggere, Scrivere da un file .txt

NOTA: file deve essere contenuto/viene creato all'interno della directory del progetto

---

## LETTURA DI UN FILE

```csharp
string path = @"test.txt";
// collego ad una variabile stringa il collegamento

string[] lines = File.ReadAllLines(path);
// legge tutte le righe e le mette in un array di stringhe

foreach (string line in lines)
{
    Console.WriteLine(line); // stampo la riga
}
```

OPPURE creo un nuovo array della stessa lunghezza

```csharp
//OPPURE creo un nuovo array della stessa lunghezza 
string [] nomi = new string[lines.Length]; 
for (int i = 0; i < lines.Length; i++)
{
    nomi[i] = lines[i];
}

foreach (string nome in nomi)
{
    Console.WriteLine(nome);
}
```

---

## METODI DI FILE

```csharp
// Creare un file
string path = @"test.txt";
File.Create(path).Close();

// Crare un file con un nome personalizzato
string nomeUtente = Console.ReadLine();
//---
string nomeFile = nomeUtente + ".txt";
File.Create(nomeFile).Close();
//OPPURE
string nomeFile2 = $"@{nomeUtente}.txt" 
File.Create(nomeFile2).Close();

//Scrivere un file
File.WriteAllText(path, "Hello World!");

//Aggiungere ad un file
File.AppendAllText(file, numero + "\n");

//Aggiungi una lista ad un file
File.AppendAllLines

// Leggere da un file
string content = File.ReadAllText(path);

// Copiare un file 
string path2 = @"test2.txt";

// Eliminare un file
File.Delete(path2);

// Controlla se un file esiste
if(File.Exists(path))
{
    //do this;
}
else
{
    //do that;
}
```

## METODI DIRECTORY

```csharp
//Ottenere info su una directory
string dir = "."; // parto dalla cartella del progetto dotnet nel quale sono 
DirectoryInfo dirInfo = new DirectoryInfo(dir);
Console.WriteLine(dirInfo.CreationTime);

// Ottenere info su tutti i file in una directory (SOLO FILE)
string[] files = Directory.GetFiles(dir);
foreach(string file in files)
{
    Console.WriteLine(file);
}

// ottenere info su tutti i file e le dir in una dir (FILE E CARTELLE)
string[] all = Directory.GetFileSystemEntries(dir);
foreach( string a in all)
{
    Console.WriteLine(a);
}

// ottenere informazioni su tutti i file e dir in una dir con un filtro
string[] txtFiles = Directory.GetFiles(dir,"*.txt");
foreach (string txtFile in txtFiles)
{
    Console.WriteLine(txtFile);
}
```