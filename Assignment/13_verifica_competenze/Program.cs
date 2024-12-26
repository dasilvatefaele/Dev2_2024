using System.Security.AccessControl;

const int NOME      = 0;
const int COGNOME   = 1;
const int INDIRIZZO = 2;
const int TELEFONO  = 3;

var rubrica = new List<string[]>();
string[] contatto = new string[4];

bool repeat = true;
int scelta = 0;

while (repeat)
{
    Console.Clear();
    // Dialogo
    Console.WriteLine("Menu");
    Console.WriteLine("1. Visualizza contatti");
    Console.WriteLine("2. Aggiungi");
    Console.WriteLine("3. Cerca contatto");
    Console.WriteLine("4. Modifica contatto");
    Console.WriteLine("5. Elimina contatto");
    Console.WriteLine("0. Termina il programma");

    scelta = NumberInRange(0, 5);

    switch (scelta)
    {
        case 1:
            // visualizza
            VisualizzaRubrica(rubrica);
            break;
        case 2:
            // aggiungi
            AggiungiContatto(rubrica, contatto);
            break;
        case 3:
            // cerca contatto
            CercaContatto(rubrica);
            break;
        case 4:
            ModificaContatto(rubrica);
            // modifica contatto
            break;
        case 5:
            EliminaContatto(rubrica);
            // elimina contatto
            break;
        case 0:
            repeat = false;
            break;
    }
}

Console.WriteLine("\nProgramma terminato.");

void ModificaContatto(List<string[]> rubrica)
{
    Console.Clear();
    Console.WriteLine("Elimina Contatto");
    VisualizzazioneGenerica(rubrica);
    Console.Write("\nInserisci contatto da modificare > ");
    string elementoDaCercare = Inserimentofrase();
    elementoDaCercare = elementoDaCercare.ToUpper();
    bool trovato = false;
    for (int i = 0; i < rubrica.Count; i++)
    {
        if (rubrica[i][NOME] == elementoDaCercare || rubrica[i][COGNOME] == elementoDaCercare || rubrica[i][INDIRIZZO] == elementoDaCercare || rubrica[i][TELEFONO] == elementoDaCercare)
        {
            trovato = true;
            Console.Clear();
            Console.WriteLine("Scegli cosa modificare");
            Console.WriteLine("1. Nome");
            Console.WriteLine("2. Cognome");
            Console.WriteLine("3. Indirizzo");
            Console.WriteLine("4. Telefono");

            int scelta = NumberInRange(1,4);
            switch (scelta)
            {
                case 1:
                    Console.Write("Nome > ");
                    rubrica[i][NOME] = Inserimentofrase();
                    break;
                case 2:
                    Console.Write("Cognome > ");
                    rubrica[i][COGNOME] = Inserimentofrase();
                    break;
                case 3:
                    Console.Write("Indirizzo > ");
                    rubrica[i][INDIRIZZO] = Inserimentofrase();
                    break;
                case 4:
                    Console.Write("Telefono > ");
                    rubrica[i][TELEFONO] = Inserimentofrase();
                    break;
            }
            Console.Write("Premi un tasto per salvare...");
            Console.ReadKey();
        }

        if (trovato == false && i == rubrica.Count - 1)
        {
            Console.WriteLine("Contatto non trovato");
            Console.Write("Premi un tasto per tornare al menu...");
            Console.ReadKey();
        }   
    }
}

void VisualizzazioneGenerica(List<string[]> rubrica)
{
    foreach (var contatto in rubrica)
    {
        Console.WriteLine($"NOME:\t\t\t{contatto[NOME]}\nCOGNOME:\t\t{contatto[COGNOME]}\nTELEFONO:\t\t{contatto[TELEFONO]}\nINDIRIZZO:\t\t{contatto[INDIRIZZO]}");
        Console.WriteLine("------------------------------------------");
    }
}

void EliminaContatto(List<string[]> rubrica)
{
    Console.Clear();
    Console.WriteLine("Elimina Contatto");
    VisualizzazioneGenerica(rubrica);
    Console.Write("\nInserisci contatto da eliminare > ");
    string elementoDaCercare = Inserimentofrase();
    elementoDaCercare = elementoDaCercare.ToUpper();
    bool trovato = false;

    for (int i = 0; i < rubrica.Count; i++)
    {
        if (rubrica[i][NOME] == elementoDaCercare || rubrica[i][COGNOME] == elementoDaCercare || rubrica[i][INDIRIZZO] == elementoDaCercare || rubrica[i][TELEFONO] == elementoDaCercare)
        {
            trovato = true;
            rubrica.RemoveAt(i);
            Console.WriteLine("Contatto Eliminato");
        }

        if (trovato == false && i == rubrica.Count - 1)
        {
            Console.WriteLine("Contatto non trovato");
        }

        Console.Write("Premi un tasto per tornare al menu...");
        Console.ReadKey();
    }
}

void CercaContatto(List<string[]> rubrica)
{
    Console.Clear();
    Console.WriteLine("Cerca Contatto");
    Console.WriteLine("[inserisci NOME, COGNOME, INDIRIZZO O NUMERO DI TELEFONO]");
    string elementoDaCercare = Inserimentofrase();
    elementoDaCercare = elementoDaCercare.ToUpper();
    bool trovato = false;

    for (int i = 0; i < rubrica.Count; i++)
    {
        if (rubrica[i][NOME] == elementoDaCercare || rubrica[i][COGNOME] == elementoDaCercare || rubrica[i][INDIRIZZO] == elementoDaCercare || rubrica[i][TELEFONO] == elementoDaCercare)
        {
            Console.WriteLine("Contatto Trovato:");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"NOME:\t\t\t{rubrica[i][NOME]}\nCOGNOME:\t\t{rubrica[i][COGNOME]}\nTELEFONO:\t\t{rubrica[i][TELEFONO]}\nINDIRIZZO:\t\t{rubrica[i][INDIRIZZO]}");
            Console.WriteLine("------------------------------------------");
            trovato = true;
        }

        if (trovato == false && i == rubrica.Count - 1)
        {
            Console.WriteLine("Contatto NON Trovato:");
        }
    }

    Console.Write("Premi un tasto per tornare al menu...");
    Console.ReadKey();
}

void AggiungiContatto(List<string[]> rubrica, string[] contatto)
{
    Console.Clear();
    Console.WriteLine("Aggiungi Contatto");

    Console.Write("Nome > ");
    contatto[NOME] = Inserimentofrase();

    Console.Write("Cognome > ");
    contatto[COGNOME] = Inserimentofrase();

    Console.Write("Indirizzo > ");
    contatto[INDIRIZZO] = Inserimentofrase();

    Console.Write("Telefono > ");
    contatto[TELEFONO] = Inserimentofrase();

    Console.Write("Premi un tasto per salvare...");
    Console.ReadKey();

    rubrica.Add((string[])contatto.Clone());
}


void VisualizzaRubrica(List<string[]> rubrica)
{
    if (rubrica.Count == 0)
    {
        Console.Clear();
        Console.WriteLine("Non ci sono contatti nella rubrica");
        Console.WriteLine("\nPremi un tasto per tornare al menu");
        Console.ReadKey();
        return;
    }

    Console.Clear();
    Console.WriteLine("Visualizza Rubrica:");
    VisualizzazioneGenerica(rubrica);

    Console.WriteLine("\nPremi un tasto per tornare al menu");
    Console.ReadKey();
}

int NumberInRange(int min, int max)
{
    bool repeat = false;
    int num = 0;
    Console.Write($"\nScegli tra [{min} - {max}] ");
    do
    {
        do
        {
            Console.Write("> ");
            repeat = false;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("#Errore: dato non corretto");
                repeat = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("#Errore: dato non corretto");
                repeat = true;
            }
        } while (repeat);

        if (num >= min && num <= max)
        {
            return num;
        }
        else
        {
            Console.WriteLine("#Errore: numero fuori dal range");
            repeat = true;
        }
    } while (repeat);
    return -1;
}

string Inserimentofrase()
{
    bool ripeti = false;
    string frase;
    frase = Console.ReadLine();
    do
    {
        ripeti = string.IsNullOrWhiteSpace(frase);

        if (ripeti) // if true
        {
            Console.WriteLine("#Errore: stringa vuota");
            frase = Console.ReadLine();
        }
        else
        {
            //Console.WriteLine("*Stringa inserita*");
            return frase.ToUpper();
        }
    } while (ripeti);
    return frase.ToUpper();
}