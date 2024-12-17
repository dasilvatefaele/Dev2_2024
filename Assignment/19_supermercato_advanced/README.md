# SUPERMERCATO ADVANCED

Implementare le entita che compongono un supermercato.

---

|Dipendente|Tipo di dato|Note|
|---|---|---|
|ID|Int|viene generato in automatico con un progressivo|
|username|String|viene assegnato dall admin|
|ruolo|String|viene assegnato dall admin e puo essere cassiere o magazziniere|


|Cliente|Tipo di dato|Note|
|---|---|--|
|ID|int|viene generato in automatico con un progressivo|
|username|String|ognuno decide come vuole farlo|
|carrello|Prodotto[]||
|storico_acquisti|Purchases[]|viene popolato al termine di ogni acquisto|
|percentuale_sconto|int|viene incrementata a seconda del valore dello storico degli acquisti|
|credito|double|viene utilizzato per fare gli acquisti

|Prodotto|Tipo di dato|Note|
|---|---|---|
|ID|int|viene generato in automatico con un progressivo|
|nome|String|viene inserito dal magazziniere|
|prezzo|double|viene inserito dal magazziniere|
|giacenza|int|viene inserito dal magazziniere|
|categoria|string|viene inserito dal magaziniere|

|Categoria|Tipo di dato| Note|
|--|--|--|
ID|int|
Nome|string|

**Purchases è lo stato nel quale si trova l acquisto di un cliente. Prima di essere passato alla cassa**

- Quando viene passato allo stato `completato` la cassa puo processare lo scontrino.

|Purchases|Tipo di dato|Note|
|---|---|---|
|ID|int|viene generato in automatico con un progressivo|
|cliente|Cliente||
|prodotti|Prodotto[]|viene inserito dal cliente|
|quantita|int|viene inserita dal cliente|
|data|Date|viene generato in automatico con la data corrente (quando il cliente completa l acquisto)|
|stato|Bool|lo stato di un acquisto di default e `in corso` e puo essere modificato dal cliente in `completato` o `annullato`|

|Cassa|Tipo di dato|Note|
|---|---|---|
|ID|int|viene generato in automatico con un progressivo|
|dipendente|Dipendente|
|acquisti|Purchases[]|
|scontrino_processato|Bool|di default e `false` e diventa `true` quando la cassa ha processato lo scontrino|

**Ruoli (che sarebbe il menu):**

|Cassiere|Magazziniere|Amministratore|Cliente|
|---|---|---|---|
|puo registrare i prodotti acquistati da un cliente che ha degli acquisti in stato completato e calcolare il totale da pagare generando lo scontrino,e può ricaricare il credito del cliente quando è finito. |puo visualizzare aggiungere modificare o rimuovere prodotti dal magazzino e può gestire le categorie.|puo visualizzare ed impostare il ruolo dei dipendenti.|Può aggiungere o rimuovere prodotti e cambiare lo stato dell ordine|


---

# Stato dell'ultimo commit:
```mermaid
flowchart 

ID0(INIZIO)

ID100{SEI UN CLIENTE?}
ID101(MENU CLIENTE
 1.VISUALIZZA PRODOTTI
 2. AGGIUNGI AL CARRELLO
 3. RIMUOVI DAL CARRELLO
 5. VISUALIZZA CARRELLO
 0. ESCI SESSIONE/APP
)
ID201(MODALITA ADMIN)

ID202(CASSIERE)
ID203(MAGAZZINIERE)
ID204(AMMINISTRATORE)

ID99(ESCI SESSIONE/APP)

ID999((FINE))

ID0-->ID100
ID100-->|SI|ID101

ID100-->|NO|ID201
ID201-->ID202-->ID99
ID201-->ID203-->ID99
ID201-->ID204-->ID99

ID99-->|SESSIONE|ID100
ID99-->|APP|ID999
```
---

## Implementazioni:
- [x] Gestione generale del menu, passaggio da una modalità all'altra, gestione uscita dall'app
- [x] `CarrelloRepository` carica e salva correttamente sul file `json` (serialize, deserialize)
- [x] Logica di decremento giacenza e corretto aggiornamento dei repository di `Purchase.Json` e dei json in  `/catalogo`
- [x] Commenti completati su `CarrelloRepository.cs`
- [x] Commenti completati su `CarrelloAdvancedManager.cs > AggiungiProdotto`
- [x] Gestione del carello attraverso `CarrelloAdvancedManager` e `CarrelloRepository`
- [x] Visualizzazione del carrello (Qnt. - Nome - Prezzo)
- [x] Correzione bug 'condivisione giacenza tra carrello e catalogo'

## Obiettivi individuati (in aggiornamento):


- [ ] Generare nella cartella `/Carrello` un file Json `Stato Del Carrello.json` con stringa `"In Corso"` come default.

in `CarrelloAdvancedManager.cs`
- [ ] correggere `public void EliminaProdotto` 
    - deve prendere come argomento `NomeProdotto`
    - deve riaggiungere la quantità alla giacenza
- [ ] correggere `public void AggiornaProdotto` 
    - deve prendere come argomento `NomeProdotto`
    - deve poter modificare la quantità
    - deve riaggiungere la quantità alla giacenza
    - in caso la nuova quantità sia zero deve eliminare la voce da `Purchase.json`

    ## Prossime implementazioni 
- Creare un oggetto `Cliente cliente` e associargli un carrello `cliente.Carrello` che rispecchia `Carrello.json` 
- Acquisire lo `clente.Username` 



> Commit
```bash
git add --all
git commit -m "Supermercato Avanzato 2/10 - prime implementazioni"
git push -u origin main
```

## Implementazioni:

in `class Cliente`
- [x] Creare un oggetto `Cliente cliente` e associargli un carrello `cliente.Carrello` che rispecchia `Carrello.json` 
- [x] Acquisire lo `clente.Username` 
- [x] Ottimizzazione della leggibilità del codice nel menu cliente + commenti completi 

## Obiettivi individuati (in aggiornamento):

Il file Purchase.json deve avere:
- [ ] un `purchaseIdProgressivo` generato da una classe manager
- [x] una variabile `bool` di `stato`
- [x] ora e data del momento in cui `stato` passa da `false` a `true`, ovvero quando viene completato l'acquisto

Creare una classe `ClientiAdvancedManager`
- [x] calcola `clienteIdProgressivo`, 
- [x] tiene traccia e ricalcola `PercentualeDiSconto`
- [x] controllo dell'username
    - se username già nel database, carica dati di quel cliente
    - se non esiste, crearne uno nuovo. 

In `CarrelloAdvancedManager.cs`:
- [ ] correggere `public void EliminaProdotto` 
    - deve prendere come argomento `NomeProdotto`
    - deve riaggiungere la quantità alla giacenza
- [ ] correggere `public void AggiornaProdotto` 
    - deve prendere come argomento `NomeProdotto`
    - deve poter modificare la quantità
    - deve riaggiungere la quantità alla giacenza
    - in caso la nuova quantità sia zero deve eliminare la voce da `Purchase.json`

> Commit
```bash
git add --all
git commit -m "Supermercato Avanzato 2/10 - implementazione classe cliente"
git push -u origin main
```
# Grafico che rappresenta il diagramma del ciclo di vita del prodotto
Dall'inserimento nel magazzino al completamento dell'acquisto, con i ruoli dei dipendenti che effettuani queste operazioni 

```mermaid
flowchart TD
ID0((INIZIO))

ID10(MAGAZZINIERE 
crea prodotto)
ID11(Creazione prodotto.Json)
ID12(Prodotto disponibile 
al CLIENTE)
ID13(CLIENTE aggiunge
prodotto al carrello)
ID14(Giacenza prodotto - Quantità 
nel carrello)
ID15(CLIENTE cambia 
STATO Purchase)

ID100{CASSIERE
credito sufficiente?}
ID101(CASSIERE
credito - Totale carrello)
ID102(credito non sufficiente)

ID200(CASSA
Stampa scontrino)

ID300{CASSIERE
Ricarica credito?}
ID301(Credito ricaricato)

ID999((FINE))

ID0-->ID10
ID10-->ID11
ID11-->ID12
ID12-->ID13
ID13-->ID14
ID14-->ID15
ID15-->ID100
ID100-->|SI|ID101
ID101-->ID200-->ID999
ID102-->ID300
ID300-->|NO|ID999
ID300-->|SI|ID301
ID301-->ID15
ID100-->|NO|ID102
```

## Implementazioni:

- [x] organizzazione file / cartelle
- [x] il file Purchase.json adesso salva Id e Stato
- [x] CarrelloRepository legge correttamente Purchase.json
- [x] implementazione `DipendentiRepository`
    - [x] SalvaDipendenti
    - [x] CaricaDipendenti
- [x] implementazione Menu `Amministratore`per operazioni CRUD su `Dipendenti`
    - [x] visualizza dipendenti
    - [x] aggiungi dipendenti
    - [x] elimina dipendenti
    - [x] modificare dipendenti
    - [x] Id automatico
- [x] implementazione Menu `Magaziniere` per operazioni CRUD su `Prodotti`
    - [x] aggiunge
    - [x] visualizza
    - [x] trova per id
    - [x] aggiorna
    - [x] elimina
    - [x] esce

> Commit
```bash
git add --all
git commit -m "Supermercato Advanced - 2/10 completamento in corso"
git push -u origin main
```

---

#### IMPLEMENTAZIONI

> NOTA: Disattivato temporaneamente la funzione Purchase
- [x] `AggiungiProdotto` in `CarrelloAdvancedManager` ora aggiunge i prodotti nel carrello salvato nel file Json del cliente.
- [x] Nuovo modello: `ProdottoCarrello`. Per risolvere un bug di trasferimento dal magazzino al carrello (dove nel carrello veniva trasferita la giacenza piuttosto che la quantità inserita dall'utente) è stato creato un nuovo modello che rappresenta il prodotto nel carrello. Rispecchia il modello del prodotto nel magazzino tranne per il campo Giacenza che in ProdottoCarrello si chiama `Quantita`.
- [x] Creata classe `ClientiManager.cs` per la gestione dei clienti. Esegue principalmente il controllo dell'username: se username già nel database, carica dati di quel cliente, se non esiste, crearne uno nuovo.
- [x] Creata Classe `ClientiRepository`, i quali metodi vengono richiamati per salvare in runtime le modifiche fatte nel carrello nel file json dello specifico cliente. 
- [x] Aggiornata classe `StampaTabella`, nello specifico il metodo `Carrello` per visualizzazione del carrello con i nuovi campi della classe ProdottoCarrello.

> In corso: RIMOZIONE DAL CARRELLO

```bash
git add --all
git commit -m "Supermercato Avanzato 2/10 - rimozione dal carrello non funzionante"
git push -u origin main
```