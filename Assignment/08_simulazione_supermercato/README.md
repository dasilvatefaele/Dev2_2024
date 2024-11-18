# Simulazione supermercato

### Obiettivo

Realizzare un programma che simuli il funzionamento di un supermercato

### Versione 1

- creo una lista di stringhe contente i prodotti disponibili chiamata `prodotti`
- creo un dizionario string-intero per tenere traccia dei prodotti che ho nel carrello
- creare una variabile per continuare o terminare l'acquisto `continua`
- utilizzare un menu 
- visualizzare prodotti
- cercare tramite metodi di stringa
- visualizzare, aggiungere, rimuovere dal carrello
- utilizzare le funzioni

```Mermaid
flowchart

```
```
git add --all
git commit -m "08 supermercato v1"
git push -u origin main
```
### Versione 2

### Obiettivo
- espandere l'esercitazione con funzionalità extra come prezzi
 ---
## Analisi struttura di dati:

- Prodotto (string)
    - prezzo (double)
    - numero (double)


- Carrello
    - Prodotto
        - prezzo
        - numero
    - Prodotto
        - prezzo
        - numero
    - Prodotto
        - prezzo
        - numero
---
Ogni prodotto contiene due informazioni numeriche. Un prezzo, che non cambia, e un contatore, che verrà trattato come di tipo intero.

Il carrello dev'essere una lista di prodotti.

Dopo un ripasso sulle strutture di dati convengo che sia sensato utilizzare:

```csharp
//PRODOTTO 
const int PREZZO = 0;
const int QUANTITA = 1;
var prodotti = Dictionary<string, list<double>>();
```

dove:
- la variabile `string` nomeProdotto viene inizializzata col nome prodotto
- la `List<double>` viene inizializzata
    - `info[PREZZO]` = prezzo del prodotto
    - `info[QUANTITA]` = 1

Ad ogni chiave univoca `nomeProdotto` viene associata una lista `info` con indici `PREZZO` e `QUANTITA`

- Prezzo non cambia mai.
- Quantità inizia da 0
- aumenta se la chiave del prodotto è presente nella chiave del carrello
- decrementa se viene rimosso dal carrello
- se quantità arriva a 0, il prodotto viene rimosso dal carrello 
- al pagamento
    - ciò che ha quantità 1 viene sommato alla variabile `double saldoFinale`
    - ciò che ha quantità > 1, moltiplica `QUANTITA * PREZZO` e somma a `double saldoFinale`



#### Perplessità:
- capire come avere accesso e modificare la variabile di info[] dentro il dizionario

> non funzionate

Per incrementare la quantità ipotizzo una struttura di questo tipo:

```csharp
const int QUANTITA = 1;
var prodotti = Dictionary<string, list<double>>();
prodotto["latte"].Value[QUANTITA] = 1;
// incorretto
```

