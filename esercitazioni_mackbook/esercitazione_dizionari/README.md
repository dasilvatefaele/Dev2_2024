# Ripasso dei Dizionari
```csharp
Dictionary<string,string> Rubrica = new Dictionary<string,string>()
```

## Obiettivo
Comprendere come aggiungere un nuovo elemento al dizionario "Rubrica" tramite inserimento dell'utente e stamparli.

### Considerazioni:
E' possibile dichiarare un dizionario e inizializzarlo contemporaneamente:

```csharp
//Esempio:
Dictionary<string,string> Rubrica = new Dictionary<string,string>()
{
    {"Default", "1234567890"},
};
```
Oppure creare un dizionario vuoto e riempirlo tramite il metodo `.Add`

```csharp
//Esempio:
Console.Write("Nome contatto: ");
string nomeContatto = Console.ReadLine();

Console.Write("Numero contatto: ");
string numeroContatto = Console.ReadLine();

Rubrica.Add(nomeContatto, numeroContatto); // <------
```
In questo caso salviamo l'inserimento all'interno di due variabili del tipo opportuno e le usiamo come argomenti del metodo `.Add` per inserirli come "Chiave" e "Valore".


### Stampa:
Il dizionario, a differenza delle `Liste` e degli `Array`, non posseggono un valore di `Index`, ma sono **reterabili** attraverso un ciclo `foreach`.

```csharp
//Esempio:
foreach(var contatto in Rubrica){
    Console.WriteLine($"{contatto.Key}\t{contatto.Value}");
}
```

Notare come nel `foreach` viene creata una variable `var contatto` utilizzata come nome "placeholder" dell'elemento `in` dizionario `Rubrica`. Infatti ci riferiamo a questo nome "placeholder" usando su di esso i metodi `.Key` e `.Value` per estrapolarne i contenuti di chiave e valore per ogni reiterazione.