using Newtonsoft.Json;
Console.Clear();

// ESEMPIO DI DESERIALIZZAZIONE 

ACapo();
string path = @"test.json";
string json = File.ReadAllText(path);
dynamic obj = JsonConvert.DeserializeObject(json); // deserializza il file
Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} eta: {obj.eta}");

// ESEMPIO DI DESERIALIZZAZIONE DI UN FILE JSON CON PIU LIVELLI

ACapo();
string path2 = @"test2.json";
string json2 = File.ReadAllText(path2);
dynamic objAvanzato = JsonConvert.DeserializeObject(json2); // deserializza il file
Console.WriteLine($"nome: {objAvanzato.nome} cognome: {objAvanzato.cognome} eta: {objAvanzato.eta} citta: {objAvanzato.indirizzo.citta}");

// ESEMPIO DI DESERIALIZZAZIONE DI UN FILE JSON COMPLESSO

ACapo();
string path3 = @"test3.json";
string json3 = File.ReadAllText(path3);
dynamic objComplesso = JsonConvert.DeserializeObject(json3); // deserializza il file
Console.WriteLine($"nome: {objComplesso.nome} cognome: {objComplesso.cognome} eta: {objComplesso.eta} citta: {objComplesso.indirizzo.citta}");
Console.WriteLine($"sposato: {objComplesso.sposato} madrelingua: {objComplesso.LingueParlate[0]}");
Console.WriteLine($"numero di {objComplesso.NumeroDiTelefono[0].tipo}: {objComplesso.NumeroDiTelefono[0].numero}");
Console.WriteLine($"numero di {objComplesso.NumeroDiTelefono[1].tipo}: {objComplesso.NumeroDiTelefono[1].numero}");

// ESEMPIO
ACapo();


#region FUNZIONI BABBE
void ACapo()
{
    Console.WriteLine();
}
#endregion