using System.Threading.Tasks.Dataflow;

Console.Clear();
Random random = new Random();
int estrazione;

string[] nomePartecipante = new string[8];
nomePartecipante[0] = "Andrea";
nomePartecipante[1] = "Anita";
nomePartecipante[2] = "Diego";
nomePartecipante[3] = "Felipe";
nomePartecipante[4] = "Giorgio";
nomePartecipante[5] = "Ivan";
nomePartecipante[6] = "Sofia";
nomePartecipante[7] = "Tamer";

int nStudenti = nomePartecipante.Length;                // Salvo la lunghezza dell'array in una variabile decrementabile 
Dictionary<int, List<string>> dictSquadre = new Dictionary<int, List<string>>();

Console.WriteLine("*** Sorteggio Partecipanti ***");
//Console.ReadKey();
Console.WriteLine("> Inserisci il numero di quadre: ");
int nSquadre = int.Parse(Console.ReadLine());

while (nStudenti != 0)                                  // nomePartecipante.Length è sempre 8 !!! andrebbe avanti all'infinito...                   
{
    // Console.WriteLine($"DEBUG: {nomePartecipante.Length}"); // sempre 8...
    for (int i = 0; i < nSquadre; i++)
    {
        estrazione = random.Next(nomePartecipante.Length);
        if (nomePartecipante[estrazione] != null)           // *esegue solo se il nome non è già stato estratto (cioè != null)
        {
            Console.WriteLine($"Il computer ha estratto... {nomePartecipante[estrazione]}!");
            if (!dictSquadre.ContainsKey(i))
            {
                List<string> temp = new List<string>();
                temp.Add(nomePartecipante[estrazione]);
                dictSquadre.Add(i, temp);
                temp.Clear ();
            }
            else
            {
                dictSquadre[i].Add(nomePartecipante[estrazione]);
            }
            Array.Clear(nomePartecipante, estrazione, 1);   // Array.Clear rende "null" l'elemento ma la lunghezza dell'array non varia dunque (riga 22*)
            nStudenti--;
        }                                  // quindi decremento e ripeto while nStudenti != 0 (non stra performante ma funziona LOL)
    }
}

foreach (var squadra in dictSquadre)
{
    Console.WriteLine(string.Join(",", squadra.Value));
}
Console.WriteLine("Hai estratto tutti i partecipanti.");