// Creare un file
string path = @"test.txt";
File.Create(path).Close();

//Scrivere un file
File.WriteAllText(path, "Hello World!");

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