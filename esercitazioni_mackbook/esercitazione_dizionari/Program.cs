
Console.Clear();

Dictionary<string,string> Rubrica = new Dictionary<string,string>()
{
    {"Default", "1234567890"},
};
string risposta = "";

do{
    Console.Write("Nome contatto: ");
    string nomeContatto = Console.ReadLine();

    Console.Write("Numero contatto: ");
    string numeroContatto = Console.ReadLine();

    Rubrica.Add(nomeContatto, numeroContatto);

    Console.WriteLine("Contatto Aggiunto correttamente!");

    Console.WriteLine("\nPremi un tasto per continuare...");
    Console.ReadKey();

    Console.WriteLine("Aggiungi nuovo contatto? s/n");
    risposta = Console.ReadLine();
    risposta = risposta.ToUpper();
    Console.Clear();

    while(risposta != "S" && risposta != "N" ){
        Console.WriteLine("Riposta non valida.");
        Console.WriteLine("Aggiungi nuovo contatto? s/n");
        risposta = Console.ReadLine();
        Console.Clear();
    }
}while(risposta == "S");

 Console.WriteLine("\nPremi un tasto per visualizzare la Rubrica...");
    Console.ReadKey();


        foreach(var contatto in Rubrica){
            Console.WriteLine($"{contatto.Key}\t{contatto.Value}");
        }
    

