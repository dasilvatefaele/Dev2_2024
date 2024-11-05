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

int nStudenti = nomePartecipante.Length;                // Salvo la lunghezza dell'array in una variabile decrementabile 

Console.WriteLine ("*** Sorteggio Partecipanti ***");

while (nStudenti != 0)                                  // nomePartecipante.Length è sempre 8 !!! andrebbe avanti all'infinito...                   
{
    estrazione = random.Next(nomePartecipante.Length);  
    if (nomePartecipante[estrazione] != null)           // *esegue solo se il nome non è già stato estratto (cioè != null)
    {
        // Console.WriteLine($"DEBUG: {nomePartecipante.Length}"); // sempre 8...
        Console.WriteLine ("Premi un tasto per estrarre...");
        Console.ReadKey ();
        Console.WriteLine($"Il computer ha estratto... {nomePartecipante[estrazione]}!");
        Array.Clear (nomePartecipante, estrazione,1);   // Array.Clear rende "null" l'elemento ma la lunghezza dell'array non varia dunque (riga 22*)
        nStudenti--;                                    // quindi decremento e ripeto while nStudenti != 0 (non stra performante ma funziona LOL)
    }
}

Console.WriteLine ("Hai estratto tutti i partecipanti.");