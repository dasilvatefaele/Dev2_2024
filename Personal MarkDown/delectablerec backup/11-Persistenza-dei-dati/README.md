# PERSISTENZA DEI DATI

Prima parte:
- 1. Introduzione
- 2. File di testo
- 3. File csv
- 4. JSON
Seconda parte:
- 5. DATABASE RELAZIONALI
- 6. DATABASE NON RELAZIONALI
- 7. ENTITY FRAMEWORK

# Introduzione

La persistenza dei dati è la capacità di un programma di memorizzare i dati in modo permanente, in modo che possano essere recuperati in un secondo momento.
Può essere utile per salvare i dati di un programma, per esempio, quando si chiude il programma e poi si riapre, i dati sono ancora disponibili.

# File di testo

Un file di testo è un file che contiene solo testo, senza formattazione o immagini.
I file di testo possono essere letti e scritti da qualsiasi programma, quindi sono un modo semplice per memorizzare i dati.
Tuttavia, non sono molto efficienti per memorizzare grandi quantità di dati.

# File csv

Un file csv è un file di testo che contiene dati separati da virgole.
I file csv sono molto comuni per memorizzare dati tabellari, come ad esempio i dati di una tabella di Excel.
I file csv possono essere letti e scritti da qualsiasi programma, quindi sono un modo semplice per memorizzare i dati.
Tuttavia, non sono molto efficienti per memorizzare grandi quantità di dati.

# JSON

JSON è un formato di file che può essere letto e scritto da qualsiasi programma.
È molto comune per memorizzare dati strutturati, come ad esempio i dati di un database.
JSON è molto efficiente per memorizzare grandi quantità di dati.
JSON è un formato di file che necessita di serializzazione e deserializzazione.
Serializzazione significa convertire un oggetto in una stringa JSON.
Deserializzazione significa convertire una stringa JSON in un oggetto.

# DATABASE RELAZIONALI

Un database relazionale è un database che memorizza i dati in tabelle.
Un database relazionale è molto efficiente per memorizzare grandi quantità di dati.

# DATABASE NON RELAZIONALI

Un database non relazionale è un database che memorizza i dati in modo diverso da quello delle tabelle.
Un database non relazionale è molto efficiente per memorizzare grandi quantità di dati.
A differenza di un database relazionale, un database non relazionale non ha bisogno di una struttura fissa.

# ENTITY FRAMEWORK

Entity Framework è un framework che consente di lavorare con i database relazionali.
Grazie ad Entity Framework, è possibile creare un database relazionale senza scrivere codice SQL.
Inoltre grazie alla migrazione è possibile creare il database e succesivamente tradurlo in codice SQL specifico per il database che si sta utilizzando.

## Esercizi persistenza dei dati utilizzando file di testo

### Programma che legge un file di testo txt.

test.txt
```txt
ciao
mondo
```

```csharp
class Program
{
    static void Main(string[] args)
    {
        // string path = @"C:\Users\Utente\Desktop\test.txt";
        string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        foreach (string line in lines)
        {
            Console.WriteLine(line); // stampa la riga
        }
    }
}
```

### Programma che legge un file di testo txt creando un array di stringhe per ogni riga del file.

test.txt
```txt
nome 1
nome 2
nome 3
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[] nomi = new string[lines.Length]; // crea un array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i]; // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
        }
        foreach (string nome in nomi)
        {
            Console.WriteLine(nome); // stampa la riga
        }
    }
}
```

### Programma che legge un file di testo txt creando un array di stringhe per ogni riga del file e stampa solo le righe che iniziano con la lettera "a".

test.txt
```
antonio 1
nome 2
nome 3
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[] nomi = new string[lines.Length]; // crea un array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i]; // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
        }
        bool nessunNomeIniziaConA = true; // dichiaro un booleano che inizialmente è vero
        foreach (string nome in nomi)
        {
            if (nome.StartsWith("a")) // controlla se la riga inizia con la lettera "a"
            {
                Console.WriteLine(nome); // stampa la riga
                nessunNomeIniziaConA = false; // se la riga inizia con la lettera "a" allora il booleano diventa falso
            }
        }
        if (nessunNomeIniziaConA) // se il booleano è vero allora stampa "nessun nome inizia con la lettera a"
        {
            Console.WriteLine("nessun nome inizia con la lettera a");
        }

    }
}
```

### Programma che legge un file di testo txt creando un array di stringhe per ogni riga del file e crea un file txt con le rihe che iniziano con la lettera "a".

test.txt
```txt
antonio 1
nome 2
nome 3
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[] nomi = new string[lines.Length]; // crea un array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i]; // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
        }
        string path2 = @"test2.txt"; // in questo caso il file è nella stessa cartella del programma
        File.Create(path2).Close(); // crea il file e lo chiude
        bool nessunNomeIniziaConA = true; // dichiaro un booleano che inizialmente è vero
        foreach (string nome in nomi)
        {
            if (nome.StartsWith("a")) // controlla se la riga inizia con la lettera "a"
            {
                File.AppendAllText(path2, nome + "\n"); // scrive la riga nel file
                
                // Console.WriteLine(nome); // stampa la riga
                nessunNomeIniziaConA = false; // se la riga inizia con la lettera "a" allora il booleano diventa falso
            }
        }
        if (nessunNomeIniziaConA) // se il booleano è vero allora stampa "nessun nome inizia con la lettera a"
        {
            Console.WriteLine("nessun nome inizia con la lettera a");
        }
    }
}
```

### Programma che aggiunge una riga ad un file di testo in una posizione specifica
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.txt";
        string[] lines = File.ReadAllLines(path);
        lines[lines.Length - 2] += "Ciao Mondo";
        File.WriteAllLines(path, lines);
    }
}
```

### Programma che sovrascrive una riga ad un file di testo in una posizione specifica
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.txt";
        string[] lines = File.ReadAllLines(path);
        lines[lines.Length - 2] = "Ciao Mondo";
        File.WriteAllLines(path, lines);
    }
}
```
> NOTA: è possible utilizzare l'accento circonflesso (^) in modo da inserire l'elemento in una posizione specifica partendo dall'ultima posisione così:

```csharp
lines[^ 2] = "Ciao Mondo";
```

### Programma che legge un file di testo txt contenente dei nomi ed utilizza il metodo random per sorteggiare un nome da stampare.

test.txt
```txt
nome 1
nome 2
nome 3
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[] nomi = new string[lines.Length]; // crea un array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i]; // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
        }
        Random random = new Random(); // crea un oggetto random
        int index = random.Next(nomi.Length); // genera un numero casuale tra 0 e la lunghezza dell'array di stringhe
        Console.WriteLine(nomi[index]); // stampa il nome corrispondente all'indice generato casualmente
    }
}
```

### Programma che legge un file di testo txt contenente dei nomi ed utilizza il metodo random per sorteggiare un nome da stampare e crea un file txt con il nome sorteggiato.

test.txt
```txt
nome 1
nome 2
nome 3
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[] nomi = new string[lines.Length]; // crea un array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i]; // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
        }
        Random random = new Random(); // crea un oggetto random
        int index = random.Next(nomi.Length); // genera un numero casuale tra 0 e la lunghezza dell'array di stringhe
        Console.WriteLine(nomi[index]); // stampa il nome corrispondente all'indice generato casualmente
        string path2 = @"test2.txt"; // in questo caso il file è nella stessa cartella del programma
        File.Create(path2).Close(); // crea il file
        File.AppendAllText(path2, nomi[index] + "\n"); // scrive la riga nel file
    }
}
```

### Programma che legge un file di testo txt contenente dei nomi ed utilizza il metodo random per sorteggiare un nome da stampare e SE NON ESISTE crea un file txt con il nome sorteggiato. SE ESISTE aggiunge il nome sorteggiato al file.

test.txt
```txt
nome 1
nome 2
nome 3
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[] nomi = new string[lines.Length]; // crea un array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i]; // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
        }
        Random random = new Random(); // crea un oggetto random
        int index = random.Next(nomi.Length); // genera un numero casuale tra 0 e la lunghezza dell'array di stringhe
        Console.WriteLine(nomi[index]); // stampa il nome corrispondente all'indice generato casualmente
        string path2 = @"test2.txt"; // in questo caso il file è nella stessa cartella del programma
        if (!File.Exists(path2)) // controlla se il file esiste
        {
            File.Create(path2).Close(); // crea il file
        }
        File.AppendAllText(path2, nomi[index] + "\n"); // scrive la riga nel file
    }
}
```

### Programma che legge un file di testo txt contenente dei nomi ed utilizza il metodo random per sorteggiare un nome da stampare e SE NON ESISTE crea un file txt con il nome sorteggiato. SE ESISTE aggiunge il nome sorteggiato al file. SE IL NOME E' GIA' PRESENTE NEL FILE NON LO AGGIUNGE stampando un messaggio.

test.txt
```txt
nome 1
nome 2
nome 3
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[] nomi = new string[lines.Length]; // crea un array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i]; // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
        }
        Random random = new Random(); // crea un oggetto random
        int index = random.Next(nomi.Length); // genera un numero casuale tra 0 e la lunghezza dell'array di stringhe
        Console.WriteLine(nomi[index]); // stampa il nome corrispondente all'indice generato casualmente
        string path2 = @"test2.txt"; // in questo caso il file è nella stessa cartella del programma
        if (!File.Exists(path2)) // controlla se il file esiste
        {
            File.Create(path2).Close(); // crea il file
        }
        if (!File.ReadAllLines(path2).Contains(nomi[index])) // controlla se il nome sorteggiato è già presente nel file
        {
            File.AppendAllText(path2, nomi[index] + "\n"); // scrive la riga nel file
        }
        else
        {
            Console.WriteLine("il nome è già presente nel file");
        }
    }
}
```

## Esercizi persistenza dei dati utilizzando file csv

### Programma che legge un file csv.

test.csv
```csv
nome,cognome,eta
antonio,rossi,20
mario,verdi,30
luigi,neri,40
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        foreach (string line in lines)
        {
            Console.WriteLine(line); // stampa la riga
        }
    }
}
```

### Programma che legge un file csv creando un array di stringhe per ogni riga del file.

test.csv
```csv
nome,cognome,eta
antonio,rossi,20
mario,verdi,30
luigi,neri,40
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[] nomi = new string[lines.Length]; // crea un array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i]; // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
        }
        foreach (string nome in nomi)
        {
            Console.WriteLine(nome); // stampa la riga
        }
    }
}
```

### Programma che legge un file csv creando un array di stringhe per ogni riga del file e divide ogni riga in un array di stringhe utilizzato la virgola come separatore.

test.csv
```csv
nome,cognome,eta
antonio,rossi,20
mario,verdi,30
luigi,neri,40
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[][] nomi = new string[lines.Length][]; // crea un array di array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i].Split(','); // assegna ad ogni elemento dell'array di array di stringhe il valore della riga corrispondente divisa in un array di stringhe utilizzato la virgola come separatore
        }
        foreach (string[] nome in nomi)
        {
            foreach (string n in nome)
            {
                Console.Write(n + " "); // stampa la riga
            }
            Console.WriteLine();
        }
    }
}
```

### Programma che legge un file csv creando un array di stringhe per ogni riga del file e divide ogni riga in un array di stringhe utilizzato la virgola come separatore e crea un file csv per ogni riga del file con il nome del file che corrisponde al nome della prima colonna ed il contenuto del file che corrisponde al contenuto delle altre colonne disponibili.

test.csv
```csv
nome,cognome,eta
antonio,rossi,20
mario,verdi,30
luigi,neri,40
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[][] nomi = new string[lines.Length][]; // crea un array di array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i].Split(','); // assegna ad ogni elemento dell'array di array di stringhe il valore della riga corrispondente divisa in un array di stringhe utilizzato la virgola come separatore
        }
        foreach (string[] nome in nomi)
        {
            string path2 = nome[0] + ".csv"; // in questo caso il file è nella stessa cartella del programma
            File.Create(path2).Close(); // crea il file
            for (int i = 1; i < nome.Length; i++)
            {
                File.AppendAllText(path2, nome[i] + "\n"); // scrive la riga nel file
                // File.AppendAllText(path2,$"{nome[i]}\n"); // scrive la riga nel file utilizzando l'interpolazione di stringhe
            }
        }
        // elimino il file csv che contiene le intestazioni delle colonne
        File.Delete("nome.csv");
    }
}
```

### Programma che chiede all'utente di inserire una serie di nomi e cognomi ed eta (andando a capo ogni volta) e li salva in un file csv.

```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        File.Create(path).Close(); // crea il file
        while (true)
        {
            Console.WriteLine("inserisci nome, cognome ed eta");
            string nome = Console.ReadLine()!; // legge il nome
            string cognome = Console.ReadLine()!; // legge il cognome
            string eta = Console.ReadLine()!; // legge l'eta
            File.AppendAllText(path,$"{nome},{cognome},{eta}\n");
            Console.WriteLine("vuoi inserire un altro nome? (s/n)");
            string risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                break;
            }
        }
    }
}
```

### Programma che chiede all'utente di inserire una serie di nomi e cognomi ed eta (andando a capo ogni volta) e li salva in un file csv. SE IL NOME E' GIA' PRESENTE NEL FILE NON LO AGGIUNGE stampando un messaggio.

```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        File.Create(path).Close(); // crea il file
        while (true)
        {
            Console.WriteLine("inserisci nome, cognome ed eta");
            string nome = Console.ReadLine()!; // legge il nome
            string cognome = Console.ReadLine()!; // legge il cognome
            string eta = Console.ReadLine()!; // legge l'eta
            string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
            bool found = false;
            foreach (string line in lines) // per ogni riga
            {
                if (line.StartsWith(nome)) // controlla se il nome è già presente nel file
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n"); // scrive la riga nel file
            }
            else
            {
                Console.WriteLine("il nome è già presente nel file");
            }
            Console.WriteLine("vuoi inserire un altro nome? (s/n)");
            string risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                break;
            }
        }
    }
}
```

### Programma che chiede all'utente di inserire una serie di nomi e cognomi ed eta (andando a capo ogni volta) e li salva in un file csv. SE IL NOME E' GIA' PRESENTE NEL FILE AGGIORNA L'ETA' DEL NOME.

```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        File.Create(path).Close(); // crea il file
        while (true)
        {
            Console.WriteLine("inserisci nome, cognome ed eta");
            string nome = Console.ReadLine()!; // legge il nome
            string cognome = Console.ReadLine()!; // legge il cognome
            string eta = Console.ReadLine()!; // legge l'eta
            bool presente = false; // variabile boolean che controlla se il nome è già presente nel file
            foreach (string line in File.ReadAllLines(path)) // legge tutte le righe del file
            {
                if (line.StartsWith(nome)) // controlla se il nome è già presente nel file
                {
                    presente = true;
                }
            }
            if (!presente)
            {
                File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n"); // scrive la riga nel file
            }
            else
            {
                string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
                string[][] nomi = new string[lines.Length][]; // crea un array di array di stringhe con la lunghezza del numero di righe del file
                for (int i = 0; i < lines.Length; i++)
                {
                    nomi[i] = lines[i].Split(','); // assegna ad ogni elemento dell'array di array di stringhe il valore della riga corrispondente divisa in un array di stringhe utilizzando la virgola come separatore
                }
                for (int i = 0; i < nomi.Length; i++)
                {
                    if (nomi[i][0] == nome) // controlla se il nome è già presente nel file
                    {
                        nomi[i][2] = eta; // aggiorna l'eta
                    }
                }
                File.Delete(path); // elimina il file
                File.Create(path).Close(); // crea il file
                foreach (string[] n in nomi)
                {
                    File.AppendAllText(path, n[0] + "," + n[1] + "," + n[2] + "\n"); // scrive la riga nel file
                }
            }
            Console.WriteLine("vuoi inserire un altro nome? (s/n)");
            string risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                break;
            }
        }
    }
}
```

### Programma che permette di eliminare un elemento specifico da un file csv

```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[][] nomi = new string[lines.Length][]; // crea un array di array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i].Split(','); // assegna ad ogni elemento dell'array di array di stringhe il valore della riga corrispondente divisa in un array di stringhe utilizzando la virgola come separatore
        }
        Console.WriteLine("quale nome vuoi eliminare?");
        string nomeScelto = Console.ReadLine()!;
        for (int i = 0; i < nomi.Length; i++)
        {
            if (nomi[i][0] == nomeScelto)
            {
                nomi[i][0] = "";
                nomi[i][1] = "";
                nomi[i][2] = "";
            }
        }
        File.Delete(path); // elimina il file
        File.Create(path).Close(); // crea il file
        foreach (string[] n in nomi)
        {
            File.AppendAllText(path, n[0] + "," + n[1] + "," + n[2] + "\n"); // scrive la riga nel file
        }
    }
}
```
### Programma che legge quali files csv sono stati creati chiedendo quale file si vuole leggere e stampa il contenuto del file.

```csharp
class Program
{
    static void Main(string[] args)
    {
        string[] files = Cartella.GetFiles(Cartella.GetCurrentCartella(), "*.csv"); // legge tutti i file csv nella cartella del programma
        foreach (string file in files)
        {
            Console.WriteLine(file); // stampa il nome del file
        }
        Console.WriteLine("quale file vuoi leggere?");
        string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
        string[] lines = File.ReadAllLines(fileScelto); // legge tutte le righe del file
        foreach (string line in lines)
        {
            Console.WriteLine(line); // stampa la riga
        }
    }
}
```

### Programma che legge files csv e chiede quale file si vuole eliminare e lo elimina se il file esiste. SE IL FILE NON ESISTE STAMPA UN MESSAGGIO.

```csharp
class Program
{
    static void Main(string[] args)
    {
        string[] files = Cartella.GetFiles(Cartella.GetCurrentCartella(), "*.csv"); // legge tutti i file csv nella cartella del programma
        foreach (string file in files)
        {
            Console.WriteLine(file); // stampa il nome del file
        }
        Console.WriteLine("quale file vuoi eliminare?");
        string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
        if (File.Exists(fileScelto)) // controlla se il file esiste
        {
            File.Delete(fileScelto); // elimina il file
        }
        else
        {
            Console.WriteLine("il file non esiste");
        }
    }
}
```

### Programma che legge quali files cvs sono presenti nella cartella del programma e stampa i nomi dei files come se fossero elementi di un menu. Chiede all'utente quale file vuole leggere e stampa il contenuto del file.

```csharp
class Program
{
    static void Main(string[] args)
    {
        string[] files = Cartella.GetFiles(Cartella.
        foreach (string file in files)
        {
            Console.WriteLine(Path.GetFileName(file)); // stampa solo il nome del file
        }
        Console.WriteLine("quale file vuoi leggere?");
        string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
        if (File.Exists(fileScelto)) // controlla se il file esiste
        {
            string[] lines = File.ReadAllLines(fileScelto); // legge tutte le righe del file
            foreach (string line in lines)
            {
                Console.WriteLine(line); // stampa la riga
            }
        }
        else
        {
            Console.WriteLine("il file non esiste");
        }
    }
}
```

### Programma che legge quali files cvs sono presenti nella cartella del programma e stampa i nomi dei files come se fossero dei menu. Chiede all'utente quale file vuole eliminare e lo elimina se il file esiste. SE IL FILE NON ESISTE STAMPA UN MESSAGGIO.

```csharp
class Program
{
    static void Main(string[] args)
    {
        string[] files = Cartella.GetFiles(Cartella.GetCurrentCartella(), "*.csv"); // legge tutti i file csv nella cartella del programma
        foreach (string file in files)
        {
            Console.WriteLine(Path.GetFileName(file)); // stampa il nome del file
        }
        Console.WriteLine("quale file vuoi eliminare?");
        string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
        if (File.Exists(fileScelto)) // controlla se il file esiste
        {
            File.Delete(fileScelto); // elimina il file
        }
        else
        {
            Console.WriteLine("il file non esiste");
        }
    }
}
```

### Programma che legge quali files cvs sono presenti nella cartella del programma e stampa i nomi dei files come se fossero dei menu. Chiede all'utente se vuole leggere o eliminare un file e chiede quale file vuole leggere o eliminare e lo elimina se il file esiste. SE IL FILE NON ESISTE STAMPA UN MESSAGGIO.

```csharp
class Program
{
    static void Main(string[] args)
    {
        string[] files = Cartella.GetFiles(Cartella.GetCurrentCartella(), "*.csv"); // legge tutti i file csv nella cartella del programma
        foreach (string file in files)
        {
            Console.WriteLine(Path.GetFileName(file)); // stampa il nome del file
        }
        Console.WriteLine("vuoi leggere o eliminare un file? (l/e)");
        string risposta = Console.ReadLine()!;
        if (risposta == "l")
        {
            Console.WriteLine("quale file vuoi leggere?");
            string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
            if (File.Exists(fileScelto)) // controlla se il file esiste
            {
                string[] lines = File.ReadAllLines(fileScelto); // legge tutte le righe del file
                foreach (string line in lines)
                {
                    Console.WriteLine(line); // stampa la riga
                }
            }
            else
            {
                Console.WriteLine("il file non esiste");
            }
        }
        else if (risposta == "e")
        {
            Console.WriteLine("quale file vuoi eliminare?");
            string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
            if (File.Exists(fileScelto)) // controlla se il file esiste
            {
                File.Delete(fileScelto); // elimina il file
            }
            else
            {
                Console.WriteLine("il file non esiste");
            }
        }
    }
}
```

### versione con il try and catch. Programma che legge quali files cvs sono presenti nella cartella del programma e stampa i nomi dei files come se fossero dei menu. Chiede all'utente se vuole leggere o eliminare un file e chiede quale file vuole leggere o eliminare e lo elimina se il file esiste. SE IL FILE NON ESISTE STAMPA UN MESSAGGIO.

```csharp
class Program
{
    static void Main(string[] args)
    {
        string[] files = Cartella.GetFiles(Cartella.GetCurrentCartella(), "*.csv"); // legge tutti i file csv nella cartella del programma
        foreach (string file in files)
        {
            Console.WriteLine(Path.GetFileName(file)); // stampa il nome del file
        }
        Console.WriteLine("vuoi leggere o eliminare un file? (l/e)");
        string risposta = Console.ReadLine()!;
        if (risposta == "l")
        {
            Console.WriteLine("quale file vuoi leggere?");
            string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
            try
            {
                string[] lines = File.ReadAllLines(fileScelto); // legge tutte le righe del file
                foreach (string line in lines)
                {
                    Console.WriteLine(line); // stampa la riga
                }
            }
            catch (Exception)
            {
                Console.WriteLine("il file non esiste");
            }
        }
        else if (risposta == "e")
        {
            Console.WriteLine("quale file vuoi eliminare?");
            string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
            try
            {
                File.Delete(fileScelto); // elimina il file
            }
            catch (Exception)
            {
                Console.WriteLine("il file non esiste");
            }
        }
    }
}
```

### verisone con il try and catch. Programma che legge quali files cvs sono presenti nella cartella del programma e stampa i nomi dei files come se fossero dei menu. Chiede all'utente se vuole leggere o eliminare un file e chiede quale file vuole leggere o eliminare inserendo un numero identificativo e lo elimina se il file esiste. SE IL FILE NON ESISTE STAMPA UN MESSAGGIO.

```csharp
class Program
{
    static void Main(string[] args)
    {
        string[] files = Cartella.GetFiles(Cartella.GetCurrentCartella(), "*.csv"); // legge tutti i file csv nella cartella del programma
        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine(i + " " + Path.GetFileName(files[i])); // stampa il nome del file
        }
        Console.WriteLine("vuoi leggere o eliminare un file? (l/e)");
        string risposta = Console.ReadLine()!;
        if (risposta == "l")
        {
            Console.WriteLine("quale file vuoi leggere?");
            int fileScelto = int.Parse(Console.ReadLine()!); // legge il nome del file scelto
            try
            {
                string[] lines = File.ReadAllLines(files[fileScelto]); // legge tutte le righe del file
                foreach (string line in lines)
                {
                    Console.WriteLine(line); // stampa la riga
                }
            }
            catch (Exception)
            {
                Console.WriteLine("il file non esiste");
            }
        }
        else if (risposta == "e")
        {
            Console.WriteLine("quale file vuoi eliminare?");
            int fileScelto = int.Parse(Console.ReadLine()!); // legge il nome del file scelto
            try
            {
                File.Delete(files[fileScelto]); // elimina il file
            }
            catch (Exception)
            {
                Console.WriteLine("il file non esiste");
            }
        }
    }
}
```

## Esercizi persistenza dei dati utilizzando JSON

Per poter utilizzare JSON è necessario installare il pacchetto NuGet Newtonsoft.Json.

Il comando per installare il pacchetto NuGet Newtonsoft.Json è il seguente: 

> dotnet add package Newtonsoft.Json

Il comando va eseguito nella cartella del progetto.

> I file JSON (JavaScript Object Notation) sono un formato leggero di scambio dati, facilmente leggibile e scrivibile sia dagli umani che dalle macchine. Sono ampiamente utilizzati nel web per lo scambio di dati tra client e server, nonché per la configurazione e il salvataggio di dati in vari progetti

### Tipi di dati in JSON

JSON supporta i seguenti tipi di dati:

- Stringa: Una sequenza di caratteri racchiusa tra virgolette doppie. Esempio: "Ciao mondo".

- Numero: I numeri in JSON sono molto simili ai numeri in JavaScript, possono essere interi o floating-point. Esempio: 100, 20.5.

- Oggetto: Una collezione non ordinata di coppie chiave/valore. Gli oggetti sono racchiusi tra parentesi graffe {} con le chiavi che sono stringhe e i valori che possono essere di qualsiasi tipo di dati JSON. Esempio: {"nome": "Mario", "età": 30}.

- Array: Una lista ordinata di valori, che possono essere di qualsiasi tipo di dati JSON. Gli array sono racchiusi tra parentesi quadre []. Esempio: ["apple", "banana", "cherry"].

- Booleano: Rappresenta un valore vero o falso. Esempio: true, false.

- Null: Un tipo che rappresenta un valore nullo o "nessun valore". Esempio: null

### Esempio di file JSON

```json
{
  "nome": "Mario Rossi",
  "età": 30,
  "impiegato": true,
  "indirizzo": {
    "via": "Via Roma 10",
    "città": "Roma",
    "CAP": "00100"
  },
  "numeri di telefono": [
    {"tipo": "casa", "numero": "1234-5678"},
    {"tipo": "ufficio", "numero": "8765-4321"}
  ],
  "lingue parlate": ["italiano", "inglese", "spagnolo"],
  "sposato": false,
  "patente": null
}
```

### Programma che legge un file JSON.

test.json
```json
{
    "nome": "antonio",
    "cognome": "rossi",
    "eta": 20,
    "indirizzo": {
        "via": "via roma",
        "citta": "roma"
    }
}
```
```csharp
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json"; // in questo caso il file è nella stessa cartella del programma
        string json = File.ReadAllText(path); // legge il file
        Console.WriteLine(json); // stampa il file
    }
}
```

### Programma che legge un file JSON e lo stampa in modo formattato.

test.json
```json
{
    "nome": "antonio",
    "cognome": "rossi",
    "eta": 20
}
```
```csharp
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json"; // in questo caso il file è nella stessa cartella del programma
        string json = File.ReadAllText(path); // legge il file
        dynamic obj = JsonConvert.DeserializeObject(json)!; // deserializza il file
        Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} eta: {obj.eta}"); // stampa il file
    }
}
```

### Programma che legge un file JSON e lo stampa in modo formattato.

test.json
```json
{
    "nome": "antonio",
    "cognome": "rossi",
    "eta": 20,
    "indirizzo": {
        "via": "via roma",
        "citta": "roma"
    }
}
```
```csharp
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json"; // in questo caso il file è nella stessa cartella del programma
        string json = File.ReadAllText(path); // legge il file
        dynamic obj = JsonConvert.DeserializeObject(json)!; // deserializza il file
        Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} eta: {obj.eta}"); // stampa il livello 0
        Console.WriteLine($"via: {obj.indirizzo.via} citta: {obj.indirizzo.citta}"); // stampa il livello 1
    }
}
```

### Programma che legge un file JSON e crea un file csv con i dati del file JSON.

test.json che contiene due oggettie
```json
[
    {
        "nome": "antonio",
        "cognome": "rossi",
        "eta": 20,
        "indirizzo": {
            "via": "via roma",
            "citta": "roma"
        }
    },
    {
        "nome": "mario",
        "cognome": "verdi",
        "eta": 30,
        "indirizzo": {
            "via": "via milano",
            "citta": "milano"
        }
    }
]
```

```csharp
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json"; // in questo caso il file è nella stessa cartella del programma
        string json = File.ReadAllText(path); // legge il file
        dynamic obj = JsonConvert.DeserializeObject(json)!; // deserializza il file
        string path2 = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        File.Create(path2).Close(); // crea il file
        File.AppendAllText(path2, "nome,cognome,eta,via,citta\n"); // scrive la riga nel file
        for (int i = 0; i < obj.Count; i++)
        {
            File.AppendAllText(path2, $"{obj[i].nome},{obj[i].cognome},{obj[i].eta},{obj[i].indirizzo.via},{obj[i].indirizzo.citta}\n"); // scrive la riga nel file
        }
    }
}
```

### Programma che legge un file csv contenente un elenco di prodotti creando un file JSON per ogni prodotto.

test.csv
```csv
nome,prezzo
iphone,1000
samsung,800
huawei,600
```
```csharp
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[][] prodotti = new string[lines.Length][]; // crea un array di array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            prodotti[i] = lines[i].Split(','); // assegna ad ogni elemento dell'array di array di stringhe il valore della riga corrispondente divisa in un array di stringhe ed utilizza la virgola come separatore
        }
        for (int i = 0; i < prodotti.Length; i++)
        {
            string path2 = prodotti[i][0] + ".json"; // crea i files utilizzando la chiave come nome 
            File.Create(path2).Close(); // crea il file
            File.AppendAllText(path2, JsonConvert.SerializeObject(new { nome = prodotti[i][0], prezzo = prodotti[i][1] })); // scrive la riga nel file
        }
    }
}
```

### Programma che legge un file csv contenente un elenco di prodotti creando un file JSON per ogni prodotto. SE IL FILE ESISTE NON LO CREA.

test.csv
```csv
nome,prezzo
iphone,1000
samsung,800
huawei,600
ipad,600
ipad2,400
```
```csharp

using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
        string[][] prodotti = new string[lines.Length][]; // crea un array di array di stringhe con la lunghezza del numero di righe del file
        for (int i = 0; i < lines.Length; i++)
        {
            prodotti[i] = lines[i].Split(','); // assegna ad ogni elemento dell'array di array di stringhe il valore della riga corrispondente divisa in un array di stringhe utilizzato la virgola come separatore
        }
        for (int i = 0; i < prodotti.Length; i++)
        {
            string path2 = prodotti[i][0] + ".json"; // in questo caso il file è nella stessa cartella del programma
            if (!File.Exists(path2)) // controlla se il file esiste
            {
                File.Create(path2).Close(); // crea il file
                File.AppendAllText(path2, JsonConvert.SerializeObject(new { nome = prodotti[i][0], prezzo = prodotti[i][1] })); // scrive la riga nel file
            }
        }
    }
}
```

### Programma che chiede all'utente di inserire una serie di prodotti ed il prezzo (andando a capo ogni volta) e li salva in un file JSON con le parentesi quadre iniziali e finali.

```csharp
using Newtonsoft.Json;
 
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json"; // in questo caso il file è nella stessa cartella del programma
        File.Create(path).Close(); // crea il file
        File.AppendAllText(path, "[\n"); // scrive la riga nel file
        while (true)
        {
            Console.WriteLine("inserisci nome e prezzo");
            string nome = Console.ReadLine()!; // legge il nome
            string prezzo = Console.ReadLine()!; // legge il prezzo

            // File.AppendAllText(path, JsonConvert.SerializeObject(new { nome, prezzo }) + ",\n"); // scrive la riga nel file
            // Serializza l'oggetto con indentazione
            string jsonString = JsonConvert.SerializeObject(new { nome, prezzo }, Formatting.Indented);
            File.AppendAllText(path, jsonString + ",\n"); // scrive la riga nel file

            Console.WriteLine("vuoi inserire un altro prodotto? (s/n)");
            string risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                break;
            }
        }
        // togli l'ultima virgola
        string file = File.ReadAllText(path);
        file = file.Remove(file.Length - 2, 1); // gli argomanti -2 e 1 indicano rispettivamente la posizione e il numero di caratteri da rimuovere dalla stringa
        File.WriteAllText(path, file);
        File.AppendAllText(path, "]"); // scrive la riga nel file
    }
}
```
# utilizzi pratici:

- Gestione dell'inventario: Potrebbe essere utilizzato per creare o aggiornare un file di inventario per un piccolo negozio o per uso personale. Gli utenti possono facilmente aggiungere dettagli sui prodotti, come nome e prezzo, e mantenere traccia dell'inventario disponibile.

- Registrazione di ordini: In un contesto di vendita, lo script può essere adattato per registrare ordini da clienti, salvando dettagli come il nome del prodotto, il prezzo, e potenzialmente la quantità ordinata.

- Creazione di un database semplice: Per chi ha bisogno di un sistema per memorizzare dati semplici senza l'overhead di un database completo, questo script offre un modo per creare rapidamente un file JSON che funge da database rudimentale.

- Gestione della lista della spesa: Potrebbe essere adattato come uno strumento per creare e mantenere liste della spesa, permettendo agli utenti di aggiungere articoli e i relativi prezzi mentre pianificano gli acquisti.

- Registrazione di spese: Simile alla gestione dell'inventario, ma focalizzato sulle finanze personali. Gli utenti possono inserire dettagli sulle spese incorse, compresi i costi, per tenere traccia delle proprie finanze.

- Raccolta di feedback dei clienti: Con alcune modifiche, potrebbe essere utilizzato per raccogliere feedback o recensioni dai clienti su prodotti o servizi, serializzando e salvando le risposte in un file per un'analisi successiva.

- Organizzazione di eventi: Può servire per gestire registrazioni o prenotazioni per eventi, raccogliendo nomi di partecipanti e eventuali quote di partecipazione.

- Creazione di un semplice sistema di prenotazione: Per piccoli business che offrono servizi (come parrucchieri, insegnanti privati, ecc.), lo script può essere adattato per gestire prenotazioni, registrando il nome del cliente e i dettagli del servizio prenotato.
# VERSIONE MIGLIORATA:

```csharp
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json";
        // verifica se il file esiste, altrimenti lo crea e inizializza il formato JSON
        if (!File.Exists(path))
        {
            File.Create(path).Close();
            File.AppendAllText(path, "[\n");
        }

        while (true) // ciclo infinito per permettere all'utente di inserire più prodotti finchè non decide di smettere di inserire prodotti
        {
            Console.WriteLine("Inserisci nome:");
            string nome = Console.ReadLine().Trim(); // legge il nome e rimuove gli spazi bianchi il metodo trim rimuove gli spazi bianchi all'inizio e alla fine della stringa

            Console.WriteLine("Inserisci prezzo:");
            if (decimal.TryParse(Console.ReadLine(), out decimal prezzo)) // legge il prezzo e verifica se è un numero valido out restituisce il valore della variabile prezzo
            {
                File.AppendAllText(path, JsonConvert.SerializeObject(new { nome, prezzo = prezzo.ToString() }) + ",\n"); // scrive la riga nel file prezzo = prezzo.ToString() converte il prezzo in stringa in modo da poterlo scrivere nel file JSON
                
                Console.WriteLine("Vuoi inserire un altro prodotto? (s/n)");
                if (Console.ReadLine().Trim().ToLower() != "s") // legge la risposta e verifica se è uguale a "s" o "S" e se non è così esce dal ciclo il metodo tolower converte la stringa in minuscolo in modo che l'utente possa inserire "s" o "S" per continuare ad inserire prodotti
                {
                    break; // esce dal ciclo se l'utente non vuole inserire un altro prodotto
                }
            }
            else
            {
                Console.WriteLine("Prezzo non valido. Riprova.");
            }
        }

        FinalizzaFileJSON(path); // funzione per finalizzare il file JSON
    }

    static void FinalizzaFileJSON(string path) // funzione per finalizzare il file JSON aggiunge la parentesi quadra chiusa per chiudere il formato JSON il parametro path è il percorso del file JSON
    {
        string file = File.ReadAllText(path).TrimEnd('\n', ','); // legge il file e rimuove l'ultima virgola e a capo dalla stringa cioè il metodo trimend ha come parametri i caratteri da rimuovere dalla fine della stringa
        File.WriteAllText(path, file + "\n]"); // scrive la riga nel file ed aggiunge la parentesi quadra chiusa per chiudere il formato JSON
    }
}
```
# VERSIONE CON lista

```csharp
using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json"; // Path del file JSON
        List<object> prodotti = new List<object>(); // Lista di prodotti

        // Carica i dati esistenti se il file esiste
        if (File.Exists(path) && new FileInfo(path).Length > 0)
        {
            string contenutoEsistente = File.ReadAllText(path); // Legge il contenuto del file
            prodotti = JsonConvert.DeserializeObject<List<object>>(contenutoEsistente) ?? new List<object>(); // Deserializza il contenuto in una lista
            // ?? è l'operatore di null-coalescing: restituisce il primo operando se non è null, altrimenti restituisce il secondo operando in questo caso una nuova lista vuota di oggetti
        }

        while (true)
        {
            string nome = RichiediInputNonVuoto("Inserisci nome:");

            Console.WriteLine("Inserisci prezzo:");
            if (decimal.TryParse(Console.ReadLine(), out decimal prezzo)) // Tenta di convertire l'input in un numero decimale lo assegna a prezzo
            {
                prodotti.Add(new { nome, prezzo }); // Aggiunge un nuovo oggetto con le proprietà nome e prezzo alla lista

                Console.WriteLine("Vuoi inserire un altro prodotto? (s/n)");
                if (Console.ReadLine().Trim().ToLower() != "s") // Se l'utente non vuole inserire un altro prodotto esce dal ciclo
                // Trim() rimuove gli spazi all'inizio e alla fine della stringa
                // ToLower() trasforma la stringa in minuscolo
                {
                    break; // Esce dal ciclo while e prosegue con il codice successivo
                }
            }
            else
            {
                Console.WriteLine("Prezzo non valido. Riprova."); // Se il prezzo non è valido ripete il ciclo
            }
        }

        // Salva la lista aggiornata nel file JSON
        SalvaProdottiInFileJSON(path, prodotti); // Chiama il metodo per salvare i prodotti nel file JSON
    }

    static void SalvaProdottiInFileJSON(string path, List<object> prodotti) // Metodo per salvare i prodotti nel file JSON
    {
        string json = JsonConvert.SerializeObject(prodotti, Formatting.Indented); // Serializza la lista di prodotti in una stringa JSON
        // Formatting.Indented formatta la stringa JSON in modo leggibile
        File.WriteAllText(path, json);
    }

    static string RichiediInputNonVuoto(string prompt)
    {
        string input; // Dichiarazione della variabile input di tipo stringa (string) che conterrà l'input dell'utente dopo la validazione del metodo
        do // Ciclo do-while per richiedere l'input finché non è valido (non utilizzo un ciclo while perché voglio che il prompt venga stampato almeno una volta altimenti l'utente non saprebbe cosa fare)
        {
            Console.WriteLine(prompt); // Stampa il prompt passato come argomento al metodo
            input = Console.ReadLine().Trim(); // Assegna all'input la stringa inserita dall'utente dopo aver rimosso gli spazi all'inizio e alla fine
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Il campo non può essere vuoto. Riprova.");
            }
        } while (string.IsNullOrEmpty(input));

        return input; // Restituisce l'input validato
    }
}
```

# PROGRAMMA CHE LEGGE UN ELENCO DI FILES JSON DENTRO AD UNA CARTELLA ED PERMETTE DI SELEZIONARNE UNO E VISUALIZZARNE IL CONTENUTO

```csharp
using Newtonsoft.Json;

// Legge tutti i file JSON nella cartella del programma e permette all'utente di selezionarne uno per visualizzarne il contenuto

string Cartella = @".\json"; // Percorso della cartella contenente i file JSON
// se il files è in una catella nel progetto di vscode
// string Cartella = Cartella.GetCurrentCartella(); // Percorso della cartella del programma

string[] files = Cartella.GetFiles(Cartella, "*.json"); // Legge tutti i file JSON nella cartella

if (files.Length == 0) // Se non ci sono file JSON nella cartella
{
    Console.WriteLine("Non ci sono file JSON nella cartella.");
    return; // Esce dal programma
}

Console.WriteLine("Elenco dei file JSON:");
for (int i = 0; i < files.Length; i++)
{
    Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}"); // Stampa il nome del file con il numero di indice
}

Console.WriteLine("Quale file vuoi leggere? (Inserisci il numero corrispondente):");
if (int.TryParse(Console.ReadLine(), out int scelta) && scelta > 0 && scelta <= files.Length) // Tenta di convertire l'input in un numero intero e verifica che sia compreso tra 1 e il numero di file
{
    string fileScelto = files[scelta - 1]; // Assegna il file scelto in base all'indice
    string json = File.ReadAllText(fileScelto); // Legge il contenuto del file
    dynamic obj = JsonConvert.DeserializeObject(json); // Deserializza il contenuto in un oggetto dinamico
    Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented)); // Stampa il contenuto formattato
}
else
{
    Console.WriteLine("Scelta non valida.");
}
```