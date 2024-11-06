using System.Threading.Tasks.Dataflow;

// Dichiarazioni
int nSquadre;
int estrazione;
bool convertito;
string[] nomePartecipante = new string[8];
nomePartecipante[0] = "Andrea";
nomePartecipante[1] = "Anita";
nomePartecipante[2] = "Diego";
nomePartecipante[3] = "Felipe";
nomePartecipante[4] = "Giorgio";
nomePartecipante[5] = "Ivan";
nomePartecipante[6] = "Sofia";
nomePartecipante[7] = "Tamer";
Random random = new Random();
List<string> nomePartecipanteList = new List<string>{};
Dictionary<int, List<string>> dictSquadre = new Dictionary<int, List<string>>(); // Creo un dizionario di Squadre


// Converto l'array della versione precedente in una lista
nomePartecipanteList = nomePartecipante.ToList();


// Inizio Dialogo
Console.WriteLine("*** Sorteggio Partecipanti ***");


//Inserimento numero di squadre
do
{
    Console.WriteLine("> Inserisci il numero di quadre: ");
    convertito = int.TryParse(Console.ReadLine(), out  nSquadre);
} while (!convertito);


// Inizializzo Dizionario Squadre
for (int i = 0; i < nSquadre; i++)
{
    dictSquadre.Add(i+1, new List<string>());
}


int partecipantiInPiu = nomePartecipanteList.Count % nSquadre;
int partecipantiPerSquadra = nomePartecipanteList.Count / nSquadre;


for (int i = 0; i < nSquadre; i++)  // ciclo per ogni squadra
{

    for (int j = 0; j < partecipantiPerSquadra; j++)  // ciclo per ogni partecipante per squadra
    {
        estrazione = random.Next(nomePartecipanteList.Count);     
        dictSquadre[i+1].Add(nomePartecipanteList[estrazione]);
        nomePartecipanteList.RemoveAt(estrazione);    
    }

    if (partecipantiInPiu > 0)      // se ci sono partecipanti in più, distribuiscili in un'estrazione dedicata
    {
        estrazione = random.Next(nomePartecipanteList.Count);;
        dictSquadre[i+1].Add(nomePartecipanteList[estrazione]);
        nomePartecipanteList.RemoveAt(estrazione);
        partecipantiInPiu--; 
    }

}


// Pulizia Console
Console.Clear();


// Stampa le squadre
foreach (var squadra in dictSquadre)
{
    Console.Write($"Squadra {squadra.Key}: ");
    Console.WriteLine(string.Join(", ", squadra.Value));
}


Console.WriteLine("Hai estratto tutti i partecipanti.");