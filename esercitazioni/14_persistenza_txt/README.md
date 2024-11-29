# PERSISTENZA DEI DATI IN .txt

### Task

- leggere un contenuto da un file `.txt`
  
  - il file deve essere contenuto all'interno della directory del progetto
    
    ```csharp
    string path = @"test.txt";
    // collego ad una variabile stringa il collegamento
    
    string[] lines = File.ReadAllLines(path);
    // legge tutte le righe e le mette in un array di stringhe
    ```
    
    foreach (string line in lines)
    {
    
        Console.WriteLine(line); // stampo la riga
    
    }
    
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

- metodo per leggere tutte le righe del file e inserirle in (ad esempio) in un array

```csharp
// Creare un file
string path = @"test.txt";
File.Create(path).Close();

//Scrivere un file
File.WriteAllText(path, "Hello World!");

//Aggiungere ad un file
File.AppendAllText(file, numero + "\n");

// Leggere da un file
string content = File.ReadAllText(path);

// Copiare un file 
string path2 = @"test2.txt";

// Eliminare un file
File.Delete(path2);

// Creare una directory
string dir = @"test";
Directory.CreateDirectory(dir);

// Eliminare una directory
Directory.Delete(dir);

// Crea un file temporaneo
string tempFile = Path.GetTempFileName();
Console.WriteLine(tempFile);

// Creare un file temporaneo in una directory specifica
// Path.Combine unisce i path in questo caso aggiunge "temp alla deirectory temporaena
string tempDir = Path.Combine(Path.GetTempPath(), "temp");
Directory.CreateDirectory(tempDir);
```