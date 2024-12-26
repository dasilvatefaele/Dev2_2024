using System.Threading.Tasks.Dataflow;

// Dichiarazioni
int nSquadre;
int estrazione;
string risposta;
string editLista;
bool convertito;
bool esci = false;
bool ritenta = false;
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
Console.WriteLine("Premi un tasto per continuare...");
Console.ReadKey();
Console.Clear();


// Stampo lista partecipanti
Console.WriteLine("Lista partecipanti:\n");
foreach(var partecipante in nomePartecipanteList)
{
    Console.WriteLine(partecipante);
}


do
{

    Console.WriteLine("\nVuoi modificare la lista? [si/no]");
    Console.Write("> ");
    risposta = Console.ReadLine();
    risposta = risposta.ToUpper();

    //Console.WriteLine(risposta);


    if (risposta != "SI" && risposta != "NO")
    {
        Console.WriteLine("Risposta non valida.");
    }

}while (risposta != "SI" && risposta != "NO");


if (risposta == "SI")
{

    do
    {

        //Dialogo
        Console.WriteLine("\nVuoi INSERIRE o ELIMINARE dalla lista?");
        Console.Write("> ");
        risposta = Console.ReadLine();
        risposta = risposta.ToUpper();

        if (risposta != "INSERIRE" && risposta != "ELIMINARE")
        {

            do
            {
                Console.WriteLine("Risposta non valida.");
                Console.WriteLine("\nVuoi INSERIRE o ELIMINARE dalla lista?");
                Console.Write("> ");
                risposta = Console.ReadLine();
                risposta = risposta.ToUpper();
            } while (risposta != "INSERIRE" && risposta != "ELIMINARE");

        }

        switch (risposta)
        {

            case "INSERIRE":

                Console.Clear();
                // Stampo lista partecipanti
                Console.WriteLine("Lista partecipanti:\n");
                foreach(var partecipante in nomePartecipanteList)
                {
                    Console.WriteLine(partecipante);
                }

                // Dialogo
                Console.WriteLine("\nInserisci il nome del nuovo partecipante:");
                Console.Write("> ");
                string nuovoPartecipante = Console.ReadLine();
                nomePartecipanteList.Add(nuovoPartecipante);

            break;

            case "ELIMINARE":

                Console.Clear();
                // Stampo lista partecipanti
                Console.WriteLine("Lista partecipanti:\n");
                foreach(var partecipante in nomePartecipanteList)
                {
                    Console.WriteLine(partecipante);
                }

                do
                {
                    // Dialogo
                    Console.WriteLine("\nInserisci il nome del partecipante da eliminare:");
                    Console.Write("> ");
                    string partecipante = Console.ReadLine();

                    if (nomePartecipanteList.Contains(partecipante))
                    {
                        nomePartecipanteList.Remove(partecipante);
                        Console.WriteLine($"{partecipante} è stato eliminato dalla lista.");
                    }
                    else
                    {
                        Console.WriteLine($"{partecipante} non c'è nella lista.");
                        Console.WriteLine("Vuoi riprovare?[si/no]");
                        Console.Write("> ");
                        string risposta2 = Console.ReadLine();
                        risposta2 = risposta2.ToUpper();
                        if (risposta2 == "SI")
                        {
                            ritenta = true;
                        }
                        else
                        {
                            ritenta = false;
                        }
                    }
                }while(ritenta==true);
            break;

            default:
            break;
            
        }

        

        // Dialogo
        Console.WriteLine("Vuoi continuare ad editare la lista?");
        Console.Write("> ");
        string risposta3 = Console.ReadLine();
        risposta3 = risposta3.ToUpper();
        

        if (risposta3 == "SI")
        {
            esci = true;
            Console.Clear();


            // Stampo lista partecipanti
            Console.WriteLine("Lista partecipanti:\n");
            foreach(var partecipante in nomePartecipanteList)
            {
                Console.WriteLine(partecipante);
            }
        }
        else
        {
            esci = false;
        }


    }while (risposta != "INSERIRE" && risposta != "ELIMINARE" || esci == true);
    
}

Console.Clear();

// Stampo lista partecipanti
Console.WriteLine("Lista partecipanti:\n");
foreach(var partecipante in nomePartecipanteList)
{
    Console.WriteLine(partecipante);
}

//Inserimento numero di squadre
do
{
    Console.WriteLine("\nInserisci il numero di quadre: ");
    Console.Write("> ");
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