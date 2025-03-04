# FILE .JSON 

Invece di avere una struttura a matrice (come nel file .csv), abbiamo una coppia di CHIAVE: VALORE

> test.json
```json
{
    "nome":"antonio",
    "cognome":"rossi",
    "eta":20,
    "indirizzo": {
        "via":"via roma",
        "citta": "roma"
    }
}
```

supporta anche gli array (esempio: indirizzo) o elementi multipli (meno utilizzato, ma buono a sapersi):

```json
{
    "nome":"antonio",
    "cognome":"rossi",
    "eta":20,
    "indirizzo": {
        "via":"via roma",
        "citta": "roma"
    }
},
{
    "nome":"antonio",
    "cognome":"rossi",
    "eta":20,
    "indirizzo": {
        "via":"via roma",
        "citta": "roma"
    }
}
```
normalmente il file .json è unico per ogni oggetto (esempio l'oggetto "persona" viene rappresentato con il file persona.json, dove ogni persona diversa ha il proprio file .json).


```json
{
    "nome":"mario",
    "cognome":"verdi",
    "eta":20,
    "indirizzo": {
        "via":"via roma",
        "citta": "milano"
    },
    "NumeroDiTelefono":[
        {"tipo":"casa", "numero": "1234-56789"},
        {"tipo":"cellulare", "numero": "56789-1234"}
    ],
    "LingueParlate": ["italiano", "inglese", "spagnolo"],
    "sposato": false,
    "patente": null
}
```

# Serielizzazione / Deserializzazione 

Dipendenza necessaria per interpretare ed estrapolare informazioni dal file .json. **VA ESEGUITO IN OGNI PROGETTO IN CUI VOGLIAMO USARE**. 

`(Su www.nuget.org possiamo controllare la versione ufficiale o più aggiornato per .NET)`


---
#### Scriviamo del codice: 

```bash
dotnet add package Newtonsoft.Json
```
```csharp
using Newtonsoft.Json;
```


> test.json
```json
{
    "nome":"Felipe",
    "cognome":"Conceicao",
    "eta":20
}
```
> codice c#
```csharp
using Newtonsoft.Json;

Console.Clear();

string path = @"test.json";
string json = File.ReadAllText(path);
dynamic obj = JsonConvert.DeserializeObject(json); // deserializza il file
Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} eta: {obj.eta}");
```
> output console
```powershell
nome: Felipe cognome: Conceicao eta: 20
```
#### !!! NOTA !!!

- la variabile di destinazione del file .json deserializzato è di tipo `dynamic`
affinché cambi in base al valore richiamato.
- possiamo accedere alle informazioni interne attraverso sotto-proprietà o indici in caso di array.

---

# Serializzazione

## Obiettivo:

Chiedere all'utente di inserire in un file `.json` nome, cognome, indirizzo, citta
#### ESEMPIO DI SERIALIZZAZIONE:

```csharp
// chiedo all'utente di inserire i dati
Console.Write("nome > ");
string nome = Console.ReadLine();

Console.Write("cognome > ");
string cognome = Console.ReadLine();

Console.Write("indirizzo > ");
string indirizzo = Console.ReadLine();

Console.Write("citta > ");
string citta = Console.ReadLine();

// creo un oggetto con i dati inseriti
var obj4 = new
{
    nome = nome,
    cognome = cognome,
    indirizzo = indirizzo,
    citta = citta
};

// serializzo l'oggetto nel formato adatto
string json4 = JsonConvert.SerializeObject(obj4, Formatting.Indented);

// scrivo il file (creazione implicita)
File.WriteAllText("test4.json", json4);
```

> output: test4.json (dati inseriti durante il `dotnet run`)
```json
{
  "nome": "carlo",
  "cognome": "magno",
  "indirizzo": "roma",
  "citta": "impero romano"
}
```

### SERIALIZZAZIONE E DESERIALIZZAZIONE

```csharp
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

string path8 = @"test6.json";
string newJson = File.ReadAllText(path8);
dynamic objArray = JsonConvert.DeserializeObject(newJson);
Console.WriteLine($"estraggo da {path8} il nome dal secondo array: {objArray[1].nome}");
```

---

# Serializzazione e deserializzazione di modelli


## Classe

```cs
public class Chave
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Codigo { get; set; }
    public string Pagina { get; set; }
}
```

## Json

> esempio path = @"Data/chaves_list.json"
```json
[
    {
        "Id": "1071",
        "Nome": "AGL Fech Elétrica",
        "Codigo": "GYA001071",
        "Pagina": "1.1"
    },
    {
        "Id": "1105",
        "Nome": "AL Fech.",
        "Codigo": "GYA001105",
        "Pagina": "1.1"
    },
    {
        "Id": "31",
        "Nome": "Aliança Gde. L.Y.",
        "Codigo": "GYA000031",
        "Pagina": "1.1"
    },
    {
        "Id": "62",
        "Nome": "Aliança Pacific",
        "Codigo": "GYA000062",
        "Pagina": "1.1"
    }
]
```

## Deserializzazione

```cs
string path = @"Data/chaves_list.json";
var json = File.ReadAllText(path); 
// var json = System.IO.File.ReadAllText(path) // se File è una classe già usata nell'archetipo
var JsonConvert.DeserializeObject<List<Chave>>(json);
```