Console.Clear();

// CREO I FILE
string studentiInput = @"lista_studentiInput.txt";
File.Create(studentiInput).Close();
string studentiOutput = @"lista_studentiOutput.txt";
File.Create(studentiOutput).Close();

// INIZIALIZZO IL FILE DEI PARTECIPANTI
File.WriteAllText(studentiInput, "DIEGO\nTAMER\nANDREA\nFELIPE\nIVAN\nANITA\nSOFIA\nGIORGIO");

// CREO UN ARRAY DALLA LISTA DI INPUT
string[] listaStudenti = File.ReadAllLines(studentiInput);
var listaTemp = listaStudenti.ToList();

// DIALOGO
Console.WriteLine("Quanti studenti vuoi selezionare?");
int scelta = NumberInRange(1, listaTemp.Count());
    Random random = new Random();

for (int i = 0; i < scelta; i++)
{
    // GENERO UN NUMERO CASUALE 
    int selezionato = random.Next(0, listaTemp.Count());
    File.AppendAllText(studentiOutput, listaTemp[selezionato] + "\n");
    listaTemp.RemoveAt(selezionato);
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
