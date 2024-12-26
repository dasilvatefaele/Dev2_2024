
Console.Clear();
// LEGGERE UN CONTENUTO DA UN FILE TXT
string path = @"test.txt";
string[] lines = File.ReadAllLines(path);
// foreach (string line in lines)
// {
//     Console.WriteLine(line);
// }


// LEGGERE UN CONTENUTO DA UN TXT E STAMPARE SOLO LE RIGHE GHE INIZIANO CON UNA DETERMINATA LETTERA
// SE NESSUN NOME INIZIA CON LA LETTERA SCELTA, DA UN MESSAGGIO DI ERRORE

bool trovato = false;

foreach (string line in lines)
{
    if (line.StartsWith("X"))
    {
        Console.WriteLine(line);
        trovato = true;
    }
}

if (!trovato)
{
    Console.WriteLine("Nessun nome inizia con la lettera X");
}

// LEGGERE UN CONTENUTO DA UN TXT E STAMPARE SOLO LE RIGHE GHE INIZIANO CON UNA DETERMINATA LETTERA
// SE NESSUN NOME INIZIA CON LA LETTERA SCELTA, DA UN MESSAGGIO DI ERRORE
// CREARE UN TXT CON LE RIGHE CHE INIZIANO CON LA LETTERA SCELTA

// crea il file e lo chiude subito.
string path2 = @"testOutput.txt";
File.Create(path2).Close();


foreach (var line in lines)
{
    if (line.StartsWith("F"))
    {
        trovato = true;
        File.AppendAllText(path2, line + "\n");
    }
}
if (!trovato)
{
    Console.WriteLine("Nessun nome inizia con la lettera scelta");
}

// AGGIUNGERE UNA RIGA DI TESTO IN UNA POSIZIONE SPECIFICA

Console.WriteLine (lines.Length); // stampo la lunghezza dell'array
lines[lines.Length - 2] += "Indirizzo"; // aggiunge indirizzo alla penultima riga
File.WriteAllLines(path2, lines); // scrive tutte le righe nel file

// SOVRASCRIVERE UNA RIGA DI TESTO IN UNA POSIZIONE SPECIFICA

Console.WriteLine (lines.Length); // stampo la lunghezza dell'array
lines[lines.Length - 2] = "Numero di telefono"; // aggiunge indirizzo alla penultima riga
File.WriteAllLines(path2, lines); // scrive tutte le righe nel file

// AGGIUNGERE UNA RIGA IN UNA POSIZIONE SPECIFICA USANDO L'ACCENTO CIRCONFELSSO

lines[^ 2] = "ciao";
File.WriteAllLines(path2, lines); // scrive tutte le righe nel file
