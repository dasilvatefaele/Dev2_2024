// GESTIONE FILES JSON

using Newtonsoft.Json; // libreria per gestire i file JSON

// 01 LETTURA DI UN FILE JSON

/*
{
    "nome": "nome1",
    "cognome": "cognome1",
    "eta": 20
}
*/

string path = @"test.json"; // in questo caso il file è nella stessa cartella del programma
string json = File.ReadAllText(path); // legge il file

dynamic obj = JsonConvert.DeserializeObject(json); // deserializza il file
Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} eta: {obj.eta}"); // stampa il file

// 02 ESEMPIO DI DESERIALIZZAZIONE DI UN FILE JSON CON PIU LIVELLI

/*
{
    "nome": "antonio",
    "cognome": "rossi",
    "eta": 20,
    "indirizzo": {
        "via": "via roma",
        "citta": "roma"
    }
}
*/

string path2 = @"test2.json"; // in questo caso il file è nella stessa cartella del programma
string json2 = File.ReadAllText(path2); // legge il file

dynamic obj2 = JsonConvert.DeserializeObject(json2); // deserializza il file
Console.WriteLine($"nome: {obj2.nome} cognome: {obj2.cognome} eta: {obj2.eta} via: {obj2.indirizzo.via} citta: {obj2.indirizzo.citta}");

// 03 ESEMPIO DI DESERIALIZZAZIONE DI UN FILE JSON COMPLESSO

/*
{
    "nome": "Mario Rossi",
    "eta": 30,
    "impiegato": true,
    "indirizzo": {
      "via": "Via Roma 10",
      "città": "Roma",
      "CAP": "00100"
    },
    "numeriditelefono": [
      {"tipo": "casa", "numero": "1234-5678"},
      {"tipo": "ufficio", "numero": "8765-4321"}
    ],
    "lingueparlate": ["italiano", "inglese", "spagnolo"],
    "sposato": false,
    "patente": null
  }
  */

string path3 = @"test3.json"; // in questo caso il file è nella stessa cartella del programma
string json3 = File.ReadAllText(path3); // legge il file

dynamic obj3 = JsonConvert.DeserializeObject(json3); // deserializza il file

// stampa il file
Console.WriteLine($"nome: {obj3.nome} eta: {obj3.eta} impiegato: {obj3.impiegato} via: {obj3.indirizzo.via} citta: {obj3.indirizzo.citta} CAP: {obj3.indirizzo.CAP}");
// stampo i numeri di telefono (tramite indice)
Console.WriteLine($"tipo: {obj3.numeriditelefono[0].tipo} numero: {obj3.numeriditelefono[0].numero}");
// stampo le lingue parlate (tramite indice)
Console.WriteLine($"lingua: {obj3.lingueparlate[0]}");
// stampo se è sposato
Console.WriteLine($"sposato: {obj3.sposato}");
// stampo se ha la patente
Console.WriteLine($"patente: {obj3.patente}");

// SCRITTURA DI UN FILE JSON

// 04 ESEMPIO DI SERIALIZZAZIONE DIRETTA DI UN OGGETTO COMPLESSO

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
    numeriditelefono = new[]
    {
        new { tipo = "casa", numero = "1234-5678" },
        new { tipo = "ufficio", numero = "8765-4321" }
    },
    lingueparlate = new[] { "italiano", "inglese", "spagnolo" },
    sposato = false,
    patente = (string)null
};

string json5 = JsonConvert.SerializeObject(obj5, Formatting.Indented); // serializza l'oggetto

File.WriteAllText("test5.json", json5); // scrive il file


// 05 ESEMPIO DI SCRITTURA DI DATI IN UN FILE JSON CON SERIALIZZAZIONE

// chiedo al utente di inserire i dati
Console.Write("Inserisci il nome: ");
string nome = Console.ReadLine();
Console.Write("Inserisci il cognome: ");
string cognome = Console.ReadLine();
Console.Write("Inserisci indirizzo: ");
string indirizzo = Console.ReadLine();
Console.Write("Inserisci citta: ");
string citta = Console.ReadLine();
// creo un oggetto con i dati inseriti
var obj4 = new
{
    nome = nome,
    cognome = cognome,
    indirizzo = indirizzo,
    citta = citta
};
// serializzo l'oggetto
string json4 = JsonConvert.SerializeObject(obj4, Formatting.Indented);
// scrivo il file
// File.WriteAllText("test4.json", json4);
// uso di formatting indented: posso formattare il file in modo che sia più leggibile andando a capo dopo ogni virgola e parentesi graffa
File.WriteAllText("test4.json", json4);

// 06 ESEMPIO DI SCRITTURA DI PIU OGGETTI IN UN FILE JSON

// creo un array di oggetti
var obj6 = new[]
{
    new { nome = "Mario", cognome = "Rossi" },
    new { nome = "Luca", cognome = "Bianchi" }
};
// serializzo l'array
string json6 = JsonConvert.SerializeObject(obj6, Formatting.Indented);
// scrivo il file
File.WriteAllText("test6.json", json6);

// 07 ESEMPIO DI AGGIUNTA DI UN OGGETTO IN UN FILE JSON

// leggo il file
string json7 = File.ReadAllText("test6.json");
// deserializzo il file
dynamic obj7 = JsonConvert.DeserializeObject(json7);
// aggiungo un oggetto all'array
var obj7new = new { nome = "Paolo", cognome = "Verdi" };
// converto l'oggetto in un array di oggetti dinamici
List<dynamic> list = obj7.ToObject<List<dynamic>>();
list.Add(obj7new);
// serializzo l'array
string json7new = JsonConvert.SerializeObject(list, Formatting.Indented);
// scrivo il file
File.WriteAllText("test6.json", json7new);

// 08 ESEMPIO DI CANCELLAZIONE DI UN OGGETTO IN UN FILE JSON

// leggo il file
string json8 = File.ReadAllText("test6.json");
// deserializzo il file
dynamic obj8 = JsonConvert.DeserializeObject(json8);
// rimuovo l'oggetto dall'array
List<dynamic> list8 = obj8.ToObject<List<dynamic>>();
list8.RemoveAt(0);
// serializzo l'array
string json8new = JsonConvert.SerializeObject(list8, Formatting.Indented);
// scrivo il file
File.WriteAllText("test6.json", json8new);

// 09 ESEMPIO DI MODIFICA DI UN OGGETTO IN UN FILE JSON

// leggo il file
string json9 = File.ReadAllText("test6.json");
// deserializzo il file
dynamic obj9 = JsonConvert.DeserializeObject(json9);
// modifico l'oggetto nell'array
List<dynamic> list9 = obj9.ToObject<List<dynamic>>();
list9[0].nome = "Giovanni";
// serializzo l'array
string json9new = JsonConvert.SerializeObject(list9, Formatting.Indented);
// scrivo il file
File.WriteAllText("test6.json", json9new);

// 10 ESEMPIO DI LETTURA DI UN FILE JSON CON UN ARRAY DI OGGETTI

/*
[
    {
        "nome": "Mario",
        "cognome": "Rossi"
    },
    {
        "nome": "Luca",
        "cognome": "Bianchi"
    }
]
*/

string path10 = @"test6.json"; // in questo caso il file è nella stessa cartella del programma
string json10 = File.ReadAllText(path10); // legge il file

dynamic obj10 = JsonConvert.DeserializeObject(json10); // deserializza il file

// stampo il file
foreach (var item in obj10)
{
    Console.WriteLine($"nome: {item.nome} cognome: {item.cognome}");
}

// 11 ESEMPIO DI CREAZIONE DI UN FILE JSON DA UN DIZIONARIO

Dictionary<string, string> dizionario = new Dictionary<string, string>
{
    { "nome", "Mario" },
    { "cognome", "Rossi" }
};

string json11 = JsonConvert.SerializeObject(dizionario, Formatting.Indented); // serializzo il dizionario

File.WriteAllText("test11.json", json11); // scrivo il file
