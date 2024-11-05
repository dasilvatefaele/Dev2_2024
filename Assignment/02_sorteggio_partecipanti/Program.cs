Console.Clear();
Random random = new Random();
int estrazione;

string[] nomePartecipante = new string [8]; 
nomePartecipante [0] = "Andrea";
nomePartecipante [1] = "Anita";
nomePartecipante [2] = "Diego";
nomePartecipante [3] = "Felipe";
nomePartecipante [4] = "Giorgio";
nomePartecipante [5] = "Ivan";
nomePartecipante [6] = "Sofia";
nomePartecipante [7] = "Tamer";

int nStudenti = nomePartecipante.Length; // potevo anche scriverci 8

Console.WriteLine ("*** Sorteggio Partecipanti ***");

while (nStudenti != 0)                                  
{
    estrazione = random.Next(nomePartecipante.Length);  
    if (nomePartecipante[estrazione] != null)           // esegue solo se il nome non è già stato estratto
    {
        // Console.WriteLine($"DEBUG: {nomePartecipante.Length}");
        Console.WriteLine ("Premi un tasto per estrarre...");
        Console.ReadKey ();
        Console.WriteLine($"Il computer ha estratto... {nomePartecipante[estrazione]}!");
        Array.Clear (nomePartecipante, estrazione,1);   // Array.Clear rende "null" l'elemento ma la lunghezza dell'array non varia
        nStudenti--;                                    // quindi decremento nStudenti e ripeto while != 0, non super efficente ma funziona LOL
    }
}

Console.WriteLine ("Hai estratto tutti i partecipanti.");