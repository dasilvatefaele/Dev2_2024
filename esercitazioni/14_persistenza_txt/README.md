# PERSISTENZA DEI DATI IN .txt

### Task

- leggere un contenuto da un file `.txt`
    - il file deve essere contenuto all'interno della directory del progetto

    ```csharp
    string path = @"test.txt";
    // collego ad una variabile stringa il collegamento

    string[] lines = File.ReadAllLines(path);
    // legge tutte le righe e le mette in un array di stringhe


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