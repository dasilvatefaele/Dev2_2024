Console.Write("Inserisci la lunghezza della password (tra 8 e 20): ");
if (!int.TryParse(Console.ReadLine(), out int lunghezza) || lunghezza < 8 || lunghezza > 20)
{
    Console.WriteLine("Lunghezza non valida."); // Se l'input non è valido, esce dal programma
    return;
}

string caratteri = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#*!$%&";
Random random = new Random();

char[] password = new char[lunghezza];
// uso il random in modo da prendere un carattere tra i primi 26 che so che sono le lettere maiuscole
password[0] = caratteri[random.Next(26)]; // Aggiungi una lettera maiuscola alla password
password[1] = caratteri[random.Next(26, 52)]; // Aggiungi una lettera minuscola alla password
password[2] = caratteri[random.Next(52, 62)]; // Aggiungi un numero alla password
password[3] = caratteri[random.Next(62, caratteri.Length)]; // Aggiungi un carattere speciale alla password

for (int i = 4; i < lunghezza; i++) // Riempi il resto della password
    password[i] = caratteri[random.Next(caratteri.Length)]; // Aggiungi caratteri casuali alla password fino a raggiungere la lunghezza richiesta

// Mischia i caratteri
for (int i = password.Length - 1; i > 0; i--)
    (password[i], password[random.Next(i + 1)]) = (password[random.Next(i + 1)], password[i]); // Mischia i caratteri della password

Console.WriteLine($"La tua password generata è: {new string(password)}");