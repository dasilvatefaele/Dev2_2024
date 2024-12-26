using System.Collections;
using System.Dynamic;

Console.Clear();

void CustomDebug() // funzione per mettere in pausa l'esecuzione
{
    Console.WriteLine("Premi per continuare l'esecuzione...");
    Console.ReadKey();
    return;
}

// Dichiarazione:
Dictionary<int, string>[] mazzoDiCarte = new Dictionary<int, string>[4];

//inizializzazione:
mazzoDiCarte[0] = new Dictionary<int, string>();  // Cuori
mazzoDiCarte[1] = new Dictionary<int, string>();  // Denari
mazzoDiCarte[2] = new Dictionary<int, string>();  // Picche
mazzoDiCarte[3] = new Dictionary<int, string>();  // Fiori

// Assegnazione:
for (int i = 1; i <= 13; i++)
{
    mazzoDiCarte[0].Add(i, "di Cuori");
    mazzoDiCarte[1].Add(i, "di Denari");
    mazzoDiCarte[2].Add(i, "di Picche");
    mazzoDiCarte[3].Add(i, "di Fiori");
}

// Verifico presenza delle carte in mazzoDiCarte via stampa // riuscito
foreach (var seme in mazzoDiCarte)
{
    foreach (var carta in seme)
    {
        switch (carta.Key){
            case 1:
                Console.Write($"A {carta.Value}\t");
            break;
            case 11:
                Console.Write($"J {carta.Value}\t");
            break;
            case 12:
                Console.Write($"Q {carta.Value}\t");
            break;
            case 13:
                Console.Write($"K {carta.Value}\t");
            break;
            default:
                Console.Write($"{carta.Key} {carta.Value}\t");
            break;
        };
    }
    Console.WriteLine("\n");
}

CustomDebug();

int totCarte = 53;
int contatoreMazzo = 1; // da incrementare dentro il ciclo
Random random = new Random();
int pescaRandom;

Dictionary<int, string>[] manoGiocatore = new Dictionary<int, string>[4];
// Inizializza i dizionari in manoGiocatore
manoGiocatore[0] = new Dictionary<int, string>();  // Cuori
manoGiocatore[1] = new Dictionary<int, string>();  // Denari
manoGiocatore[2] = new Dictionary<int, string>();  // Picche
manoGiocatore[3] = new Dictionary<int, string>();  // Fiori

string comando;

do
{
    //inizializzazioni variabili
    pescaRandom = random.Next(1, totCarte); // da 1 a 52
    contatoreMazzo = 1;

    Console.WriteLine("Pesca una carta...");
    Console.ReadKey();

    foreach (var seme in mazzoDiCarte)
    {
        foreach (var carta in seme)
        {
            if (contatoreMazzo == pescaRandom)
            {
                if (seme.ContainsValue("di Cuori"))
                {
                    manoGiocatore[0].Add(carta.Key, carta.Value);
                }
                else if (seme.ContainsValue("di Denari"))
                {
                    manoGiocatore[1].Add(carta.Key, carta.Value);
                }
                else if (seme.ContainsValue("di Picche"))
                {
                    manoGiocatore[2].Add(carta.Key, carta.Value);
                }
                else if (seme.ContainsValue("di Fiori"))
                {
                    manoGiocatore[3].Add(carta.Key, carta.Value);
                }

                seme.Remove(carta.Key); // rimuovi carta dal mazzo dopo averla copiata
                totCarte--;  // decremento totale carte
                break;
            }

            contatoreMazzo++;
        }
        if (contatoreMazzo == pescaRandom) { break; }
    }

    //stampa Mano Giocatore
    Console.WriteLine("*** La tua mano: ***");
    Console.WriteLine("\n");
    foreach (var seme in manoGiocatore)
    {
        foreach (var carta in seme)
        {
            switch (carta.Key)
            {
                case 1:
                    Console.Write($"A {carta.Value}\t");
                break;
                case 11:
                    Console.Write($"J {carta.Value}\t");
                break;
                case 12:
                    Console.Write($"Q {carta.Value}\t");
                break;
                case 13:
                    Console.Write($"K {carta.Value}\t");
                break;
                default:
                    Console.Write($"{carta.Key} {carta.Value}\t");
                break;
            };
        }
        // Console.WriteLine("\n");
    }
    Console.WriteLine("\n");
    //stampa carte restanti nel mazzo
    Console.WriteLine("*** Il mazzo: ***");
    foreach (var seme in mazzoDiCarte)
    {
        foreach (var carta in seme)
        {
            switch (carta.Key)
            {
                case 1:
                    Console.Write($"A {carta.Value}\t");
                break;
                case 11:
                    Console.Write($"J {carta.Value}\t");
                break;
                case 12:
                    Console.Write($"Q {carta.Value}\t");
                break;
                case 13:
                    Console.Write($"K {carta.Value}\t");
                break;
                default:
                    Console.Write($"{carta.Key} {carta.Value}\t");
                break;
            };
        }
        Console.WriteLine("\n");
    }

    //messaggi di dialogo
    Console.WriteLine("Debug Data *************");
    Console.WriteLine($"Carte nel mazzo: {totCarte - 1}");
    Console.WriteLine("Debug Data *************");
    Console.WriteLine("Continui?");

    comando = Console.ReadLine();
    comando = comando.ToUpper();

} while (comando != "EXIT");