# SUPERMERCATO ADVANCED

#### OBIETTIVO :

Implementare le entita che compongono un supermercato.

> Partendo dalla soluzione dell'esercizio `27_cassi_parte_8` implementare le seguenti entità.
---

| # Dipendente|Tipo|Note
|--|--|--|
ID |`int`|Viene generato in automatico con il progressivo
username |`string`|Viene assegnato dall # Amministratore
ruolo: | `string`|Viene assegnato dall # Amministratore

| # Cliente|Tipo|Note|
|--|--|--|
ID | `int`|Viene generato in automatico con il progressivo
username |`string`| Viene inserito dal cliente
carrello|`Prodotto[]`
storico_acquisti|`Purchases[]`|Viene popolato al termine di ogni acquisto
percentuale di sconto |`int`|Viene incrementata a seconda del valore dello storico degli acquisti

| # Prodotto|Tipo|Note|
|--|--|--|
ID | `int`|Viene generato in automatico con il progressivo
nome |`string`| Viene inserito dal # Magazziniere
prezzo |`double`| Viene inserito dal # Magazziniere
giacenza|`int` | Viene inserito dal # Magazziniere

| # Purchases|Tipo|Tipo
|--|--|--|
ID | `int`| Viene generato in automatico con il progressivo
cliente |`Cliente` | | Viene generato automaticamente
quantita | `int `| Viene inserita dal cliente
prodotti |`Prodotto[]` | Viene modificato dal # Cliente
data |`date` | Viene generato automaticamente
stato |`bool` | Di default è `in corso`. Può essere cambiato dal # Cliente come `completato` o `annullato`. 

| # Cassa|Tipo|Note|
|--|--|--|
ID | `int`|
dipendente | `Dipendente`
acquisti | `Purchases[]`
scontrino_processato | `bool`| di default è `false` e diventa `true` quando la cassa ha processato lo scontrino.
 ---
**Ruoli :**

|Dipendenti|Cosa può fare
|--|--|
Amministratore|Può visualizzare ed impostare il ruolo dei dipendenti.
Cassiere|Può registrare i prodotti acquistati da un cliente e calcolare il totale da pagare generando lo scontrino.
Magazziniere|Può viualizzare, aggiungere, rimuovere o modificare prodotti dal magazzino.

|Cliente|
|--|
Può aggiungere o rimuovere prodotti dal carrello, visualizzare il carrello cambiare lo stato dell'ordine.










