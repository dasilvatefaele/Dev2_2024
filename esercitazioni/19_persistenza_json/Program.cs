using System.Transactions;
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

// ESEMPIO DI SERIALIZZAZIONE
// ACapo();

// // chiedo all'utente di inserire i dati
// Console.Write("nome > ");
// string nome = Console.ReadLine();

// Console.Write("cognome > ");
// string cognome = Console.ReadLine();

// Console.Write("indirizzo > ");
// string indirizzo = Console.ReadLine();

// Console.Write("citta > ");
// string citta = Console.ReadLine();

// // creo un oggetto con i dati inseriti
// var obj4 = new
// {
//     nome = nome,
//     cognome = cognome,
//     indirizzo = indirizzo,
//     citta = citta
// };

// // serializzo l'oggetto nel formato adatto
// string json4 = JsonConvert.SerializeObject(obj4, Formatting.Indented);

// // scrivo il file (creazione implicita)
// File.WriteAllText("test4.json", json4);


// ESEMPIO DI SERIALIZZAZIONE DI UN OGGETTO COMPLESSO
ACapo();

// creo un oggetto con i dati inseriti
var obj5 = new
{
    nome = "Mario Rossi",
    eta = 30,
    impiegato = true,
    indirizzo = new
    {
        via = "Via Roma 10",
        citta = "Roma",
        CAP = "00100"
    },
    numeroDiTelefono = new[]
    {
        new { tipo = "casa", numero = "123-5678"},
        new { tipo = "ufficio", numero = "876-54321"}
    },

    lingueparlate = new[] {"italiano", "inglese", "spagnolo"},
    sposato = false,
    patente = (string)null
};

// serializzo l'oggetto nel formato adatto
string json5 = JsonConvert.SerializeObject(obj5, Formatting.Indented);

// scrivo il file (creazione implicita)
File.WriteAllText("test5.json", json5);

string path6 = @"test5.json";
string json6 = File.ReadAllText(path6);
dynamic objNuovo = JsonConvert.DeserializeObject(json6)!;
Console.WriteLine($"Estraggo da {path6} la citta: {objNuovo.indirizzo.citta}");

ACapo();

// ESEMPIO DI SCRITTURA DI PIU OGGETTI IN UN FILE JSON

// creo un array di oggetti
var obj7 = new[]
{
    new { nome = "Mario", cognome = "Rossi"},
    new { nome = "Luca", cognome = "Bianchi"} 
};

//serializzo l'array
string json7 = JsonConvert.SerializeObject(obj7, Formatting.Indented);

// scrivo il file
File.WriteAllText("test6.json", json7);


// deserializzazione

// string path8 = @"test6.json";
// string newJson = File.ReadAllText(path8);
// dynamic objArray = JsonConvert.DeserializeObject(newJson);
// Console.WriteLine($"estraggo da {path8} il nome dal secondo array: {objArray[1].nome}");



// AGGIUNTA DI UN OGGETTO IN UN FILE JSON
ACapo();

string path7 = @"test6.json";
string newJson = File.ReadAllText(path7);
dynamic objArray = JsonConvert.DeserializeObject(newJson);

var obj7new = new { nome = "Paolo", cognome = "Verdi"};

List<dynamic> list = objArray.ToObject<List<dynamic>>();
list.Add(obj7new);
string newJson2 = JsonConvert.SerializeObject(list, Formatting.Indented);

// SCRIVI IL FILE
File.WriteAllText("test6.json", newJson2);

// Console.WriteLine($"estraggo da {path8} il nome dal secondo array: {objArray[1].nome}");

// MODIFICA UN ELEMENTO 
ACapo();

string json9 = File.ReadAllText(path7);
dynamic obj9 = JsonConvert.DeserializeObject(json9);
List<dynamic> list9 = obj9.ToObject<List<dynamic>>();
list9[0].nome = "Giovanni";

string json9new  = JsonConvert.SerializeObject(list9, Formatting.Indented);

File.WriteAllText(path7, json9new);


// ELIMINO
ACapo();

list9.RemoveAt(0);
string json10new  = JsonConvert.SerializeObject(list9, Formatting.Indented);
File.WriteAllText(path7, json10new);

// STAMPO
ACapo();

foreach (var item in obj9)
{
    Console.WriteLine($"nome: {item.nome} cognome: {item.cognome}");
}







































#region FUNZIONI BABBE
void ACapo()
{
    Console.WriteLine();
}
#endregion