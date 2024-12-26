/*=========================================================
                   DateTime & TimeSpan
=========================================================*/

using System.Globalization;

Dictionary<string, DateTimeOffset> databaseNomeDataDiNascita = new Dictionary<string, DateTimeOffset>();



string inputNome;
int giorno; 
int mese;
int anno;
int eta;

do
{
    Console.WriteLine("Inserisci un nome");
    inputNome = Console.ReadLine();

    Console.WriteLine("Che giorno sei nato? (dd)");
    giorno = int.Parse(Console.ReadLine());

    Console.WriteLine("Di che mese? (MM)");
    mese = int.Parse(Console.ReadLine());

    Console.WriteLine("Di che anno? (yyyy)");
    anno = int.Parse(Console.ReadLine());

    DateTime dataDiNascita = new DateTime (anno, mese,giorno);

    eta = (DateTime.Today - dataDiNascita).Days/365;

    databaseNomeDataDiNascita.Add(inputNome,dataDiNascita);

    foreach (var elemento in databaseNomeDataDiNascita)
    {
        Console.WriteLine($"{elemento.Key}\t{elemento.Value.ToString("dd,MMMM,yyyy")}");
    }

    //Console.WriteLine(eta);

} while (true);