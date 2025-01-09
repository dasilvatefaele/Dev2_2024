# SQLite

### DIPENDENZE
```bash
dotnet add package System.Data.SQLite
```

```c#
using System.Data.SQLite;
```

> in SQLite i comandi sono in MAIUSCOLO



```
Utile per la visualizzazione per sviluppatori estensione:
SQLite Viewer 
```



## Inizio

Crea una nuova cartella, aprila su terminale e con questi due comandi

entra nel pannello SQL

```sql
sqlite3 database.db
```

il terminale cambierà in questo modo
```sql
sqlite> 
```

apri il file database.db:

```SQL
.open database.db
```

proviamo a visualizzare le tabelle
```SQL
.tables
```
> non fa niente perché non ci sono tabelle quindi creo una tabella

```SQL
CREATE TABLE utenti (
    id INTEGER,
    nome TEXT
);
```

inserisco i valori. 
```SQL
INSERT INTO utenti VALUES (1, 'Utente');
```

ora aprendo il file con SQLite Viewer 
(chiudere e riaprire nel caso non si aggiorni)

inserimento multiplo
```SQL
INSERT INTO utenti VALUES (2, 'Utente2'), (3, 'Utente3');
```

inserimento multiplo selettivo
```SQL
INSERT INTO utenti (id, nome) VALUES (4, 'Utente4'), (5, 'Utente5');
```

estrazione della tabella 
```SQL
SELECT * FROM utenti;
```

estrazione della tabella limitando
```SQL
SELECT * FROM utenti LIMIT 2;
```

visualizza in ordine crescente
```SQL
SELECT * FROM utenti ORDER BY nome ASC;
```

visualizza in ordine decrescente
```SQL
SELECT * FROM utenti ORDER BY nome DESC;
```

filtra secondo una condizione, in questo caso, (id > 1)
```SQL
SELECT * FROM utenti WHERE id > 1;
```

modifica un elemento
```SQL
UPDATE utenti SET nome = 'Utente1' WHERE id = 1;
```

rimozione di un elemento dalla tabella
```SQL
DELETE FROM utenti WHERE id = 2;
```

elimina la tabella:
```SQL
DROP TABLE utenti;
```

elimina colonna 
```SQL
ALTER TABLE prodotti DROP COLUMN data;
```

COMANDI MODIFICA STRUTTURA TABELLA
```SQL
ALTER TABLE prodotti ADD COLUMN prezzo_finale REAL;
```


COMANDI
 - `NOT NULL` : nella inizializzazione di una TABLE vincola il database ad accettare i dati completi
 - `INTEGER PRIMARY KEY` : quando associato all'ID, viene generato in automatico e in modo progressivo
 - `.tables` : visualizza le tabelle esistenti, se esistenti
 - `.mode column` : formattazione delle tabelle
 - `.mode html` : formattazione per html
 - `.schema` nome_tabella: restituisce il codice (script) SQL per ricreare quella tabella
 - `AUTOINCREMENT` - 
 - `UNIQUE` - univoco
 - 


## esercizio: CATEGORIE E PRODOTTI RELAZIONATI

```SQl
CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
```

```SQl
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
```

popolo le categorie
```sql
INSERT INTO categorie (nome) VALUES ('frutta'),('verdura'),('verura'); 
```
--- 

> test: siccome in categorie `nome TEXT UNIQUE` 
```sql
sqlite> INSERT INTO categorie (nome) VALUES ('frutta');
```
> abbiamo questo output 
```output
Runtime error: UNIQUE constraint failed: categorie.nome (19)
```
---

elimino quella sbagliata
```sql
DELETE FROM categorie WHERE id = 3; 
```

inserisco nuova categoria
```sql
INSERT INTO categorie (nome) VALUES ('latticini');
```

ora popolo i prodotti
```SQL
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('mele',1.30,50,1),('pere',1.20,60,1),('insalata', 0.90,80,2);
```

> merge: unione orizzontale di due tabelle

> append: unione verticale di due tabelle

grazie a 
```
FOREIGN KEY (id_categoria) REFERENCES categorie(id);
```

Attraverso `JOIN` facciamo un merge con categoria
```sql
SELECT * FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id;
```

aggiungo una colonna disponibile alla tabella prodotto
```sql
ALTER TABLE prodotti ADD COLUMN disponibile BOOLEAN
```

assegno un valore ai booleani
> notare che vengono accettati sia 1/0 che true/false
```sql
UPDATE prodotti SET disponibile = 1 WHERE id = 1; 
UPDATE prodotti SET disponibile = TRUE  WHERE id = 2;
UPDATE prodotti SET disponibile = FALSE  WHERE id = 3; 
```

> fase di seed: creazione dati fittizi per un database