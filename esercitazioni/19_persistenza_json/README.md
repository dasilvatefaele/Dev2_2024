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



---