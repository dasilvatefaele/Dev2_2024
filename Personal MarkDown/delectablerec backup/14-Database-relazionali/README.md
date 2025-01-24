# DATABASE RELAZIONALI

I database relazionali sono un tipo di database che utilizza il modello relazionale, ovvero un modello di dati basato sul concetto matematico di relazione.

Ad esempio, una tabella di un database relazionale può essere rappresentata come una matrice bidimensionale, dove ogni riga rappresenta una tupla e ogni colonna un attributo.

## SQL

SQL (Structured Query Language) è un linguaggio standardizzato per database basati sul modello relazionale (RDBMS).

SQL è un linguaggio dichiarativo, ovvero non è necessario specificare come ottenere i dati ad esempio tramite cicli o condizioni, ma è sufficiente specificare quali dati.

## COMANDI CREAZIONE DATABASE

```sql
CREATE DATABASE database_name;
```

## COMANDI APERTURA DATABASE

```sql
USE database_name;
```

## COMANDI CREAZIONE TABELLA

```sql
CREATE TABLE table_name (
    column1 datatype,
    column2 datatype,
    ...
);
```

```sql
CREATE TABLE utenti (
    id INTEGER,
    nome TEXT
);

CREATE TABLE prodotti (
    id INTEGER,
    nome TEXT,
    prezzo REAL
);

CREATE TABLE categorie (
     id INTEGER,
    nome TEXT,
    descrizione TEXT,
    data_creazione DATE,
    stato TEXT
);
```

## COMANDO INSERIMENTO UTENTE

```sql
INSERT INTO utenti VALUES (1, 'Utente1');
```

# COMANDO INSERIMENTO MULTIPLO

```sql
INSERT INTO utenti VALUES (2, 'Utente2'), (3, 'Utente3');
```

# INSERIMENTO MULTIPLO ALTERNATIVO

```sql
INSERT INTO utenti (id, nome) VALUES (4, 'Utente4'), (5, 'Utente5');
```

## COMANDI MODIFICA STRUTTURA TABELLA

```sql
ALTER TABLE prodotti ADD COLUMN prezzo_finale REAL;
```

### SELECT

La clausola `SELECT` permette di selezionare i dati da una tabella.

```sql
SELECT * FROM table_name;
```

### SELECT TOP 5

```sql
SELECT * FROM table_name LIMIT 5;
```

### ORDINAMENTO

La clausola `ORDER BY` permette di ordinare i dati in base a una colonna.

In ordine decrescente:

```sql
SELECT * FROM utenti ORDER BY nome DESC;
```

In ordine crescente:

```sql
SELECT * FROM utenti ORDER BY nome ASC;
```

### WHERE

La clausola `WHERE` permette di filtrare i dati in base a una condizione.

```sql
SELECT * FROM table_name WHERE condition;
```

```sql
SELECT * FROM prodotti WHERE prezzo > 10;
```

### SELEZIONARE I RECORD CON CAMPI MANCANTI

```sql
SELECT * FROM prodotti WHERE prezzo IS NULL;
```

### AGGIORNARE UN VALORE A SECONDA DI UN CAMPO

```sql
UPDATE prodotti SET prezzo = 20 WHERE nome = 'banane';
```

agguirnare il nome dell utente con id 1

```sql
UPDATE utenti SET nome = 'Utente1' WHERE id = 1;
```

### ELIMINARE UN RECORD CON WHERE

```sql
DELETE FROM prodotti WHERE prezzo < 10;
```

### ELIMINARE UNA TABELLA

```sql
DROP TABLE table_name;
```

### ELIMINARE UNA COLONNA

```sql
ALTER TABLE table_name DROP COLUMN column_name;
```

### CREA TABELLA CON id_categoria COME CHIAVE PRIMARIA

```sql
CREATE TABLE categorie (
    id_categoria INTEGER PRIMARY KEY,
    nome TEXT NOT NULL,
    descrizione TEXT
);
```

```sql
CREATE TABLE prodotti (
    id_prodotto INTEGER PRIMARY KEY,
    nome TEXT NOT NULL,
    prezzo REAL,
    id_categoria INTEGER,
    FOREIGN KEY (id_categoria) REFERENCES categorie(id_categoria)
);
```

### Inserimento di un prodotto associato ad una categoria

```sql
INSERT INTO prodotti (nome, prezzo, id_categoria)
VALUES ('Google home', 1000, 1);
```

### Inserimento di una categoria

```sql
INSERT INTO categorie (nome, descrizione)
VALUES ('Smart Home', 'Prodotti per la casa intelligente');
```

### JOIN

La clausola `JOIN` permette di unire due o più tabelle.

```sql
SELECT * FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id_categoria;
```

### ORDER BY

La clausola `ORDER BY` permette di ordinare i dati in base a una colonna.

```sql
SELECT * FROM table_name ORDER BY column_name;
```

### INSERT INTO

La clausola `INSERT INTO` permette di inserire una tupla in una tabella.

```sql
INSERT INTO table_name VALUES (value1, value2, value3, ...);
```

### UPDATE

La clausola `UPDATE` permette di modificare i dati di una tabella.

```sql
UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;
```

### DELETE

La clausola `DELETE` permette di eliminare una tupla da una tabella.

```sql
DELETE FROM table_name WHERE condition;
```

### JOIN

La clausola `JOIN` permette di unire due o più tabelle.

```sql
SELECT * FROM table1 JOIN table2 ON condition;
```

### GROUP BY

La clausola `GROUP BY` permette di raggruppare i dati in base a una colonna.

```sql
SELECT * FROM table_name GROUP BY column_name;
```

### UTILIZZO DI AS PER RINOMINARE LE COLONNE

```sql
SELECT prodotti.nome AS prodotto, prodotti.prezzo AS prezzo, categorie.nome AS categoria FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id_categoria;
```

### UTILIZZO DI AS DATA

```sql
SELECT strftime('%d/%m/%Y', data_creazione) AS data_formattata
FROM categorie;
```

- %Y: Anno con 4 cifre (es. 2024).
- %m: Mese con 2 cifre (01-12).
- %d: Giorno del mese con 2 cifre (01-31).
- %H: Ore (00-23).
- %M: Minuti (00-59).
- %S: Secondi (00-59).

Supponiamo di avere una tabella categorie con una colonna data_creazione. Se desideri visualizzare la data in formato DD/MM/YYYY, puoi scrivere una query come questa:

```sql
SELECT nome, strftime('%d/%m/%Y', data_creazione) AS data_formattata
FROM categorie;
```

Questo ti darà un output con la data formattata come desideri:

```txt
nome           data_formattata
-------------  ----------------
Elettronica    05/09/2024
Smart Home     09/09/2024
```

### UTILIZZO DI MODE PER VISUALIZZARE I DATI

```sql
.mode column
.mode table
.mode html
```

### UTILIZZO DI MODE PER VISUALIZZARE I DATI

```sql
.headers on
```

# SQLITE

Scaricare i files di sqlite dal sito [sqlite](https://www.sqlite.org/download.html) e scompattare il file zip.

Mettere il file sqlite3.exe nel percorso C:\Program Files\Sqlite

Per utilizzare un database relazionale in C# è necessario installare il pacchetto `System.Data.SQLite`.

Verificare la versione di sqlite3 installata con il comando:

```bash
sqlite3 --version
```

Il comando dotnet per installare il pacchetto è il seguente:

```bash
dotnet add package System.Data.SQLite
```

Inoltre se vogliamo utilizzare il tool `sqlite3` per visualizzare il contenuto del database è necessario installare il pacchetto `sqlite3`:

```bash
sudo apt install sqlite3
```

I comandi sudo apt install sqlite3 è relativo a linux, per windows è necessario installare il pacchetto tramite [sito](https://www.sqlite.org/download.html) o dotnet comando.

Installare tramite comando dotnet

```bash
dotnet tool install --global dotnet-sqlite
```

oppure installarlo da [sito](https://www.sqlite.org/download.html).

Su windows bisogna impostare la variabile d'ambiente `PATH` con il percorso della cartella `bin` di `sqlite3`.

Per farlo `Pannello di controllo > Sistema e sicurezza > Sistema > Impostazioni di sistema avanzate > Variabili d'ambiente` e aggiungere il percorso della cartella `bin` di `sqlite3` alla variabile `PATH`.

Ad esempio, se `sqlite3` è installato in `C:\sqlite3` aggiungere `C:\sqlite3\bin` alla variabile `PATH`.

## INSTALLARE ESTENSION VSCODE

Sqlite Viewer

## COMANDI SQLITE3

una volta installato il pacchetto possiamo creare un database con il seguente comando:

```bash
sqlite3 database.db
```

## Visualizzare l'elenco di operazioni disponibili

```bash
sqlite> .help
```

## Creare i file del db selezionare un database su cui lavorare

```bash
sqlite> .open database.db
```

## Visualizzare le tabelle presenti nel database

```bash
sqlite> .tables
```

## Visualizzare lo schema di una tabella

```bash
sqlite> .schema table_name
```

## Visualizzare il contenuto di una tabella

```bash
sqlite> SELECT * FROM table_name;
```

## Creare una tabella

```bash
sqlite> CREATE TABLE table_name (column1 type1, column2 type2, ...);
```

## Inserire una tupla (la tupla è una riga della tabella) in una tabella (senza specificare le colonne)

```bash
sqlite> INSERT INTO table_name VALUES (value1, value2, value3, ...);
se si inserisce un valore di tipo TEXT bisogna mettere gli apici singoli ('valore')
```

## Inserire una tupla (la tupla è una riga della tabella) in una tabella (specificando le colonne)

```bash
sqlite> INSERT INTO table_name (column1, column2, ...) VALUES (value1, value2, value3, ...);
```

## Modificare una tupla

```bash
sqlite> UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;
```

### Esercizio 1 - Database di prodotti

Creare un database di prodotti con le seguenti caratteristiche:

- nome
- prezzo
- quantità

Il database deve essere salvato in un file `database.db`.

Il database deve contenere una tabella `prodotti`

Il database deve contenere i seguenti dati:

| nome | prezzo | quantità |
| ---- | ------ | -------- |
| p1   | 1      | 10       |
| p2   | 2      | 20       |
| p3   | 3      | 30       |

```sql
CREATE TABLE prodotti (nome TEXT, prezzo REAL, quantita INTEGER);
INSERT INTO prodotti VALUES ('p1', 1, 10);
INSERT INTO prodotti VALUES ('p2', 2, 20);
INSERT INTO prodotti VALUES ('p3', 3, 30);
```

> è possibile inserire la query da un file sql in questo modo:

- entrare nel prompt di sql con il comando `sqlite3`
- creare il file database.bs con il comando `.open database.db`
- creare un file script.sql con il contenuto della query

- uscire dal prompt sql3 `.exit`
- lanciare il comando `sqlite3 database.db < script.sql`

oppure

- lanciare il comando .read script.sql

### Esercizio 2 - Visualizzare il contenuto del database

Visualizzare il contenuto del database.

```sql
SELECT * FROM prodotti;
```

> è possibile formattare la visualizzazione dei dati coni ìl comando '.mode table' o '.mode column' o avere un output di tipo html '.mode html'

### Esercizio 3 - Visualizzare il contenuto del database ordinato per prezzo

Visualizzare il contenuto del database ordinato per prezzo.

```sql
SELECT * FROM prodotti ORDER BY prezzo;
```

### Esercizio 4 - Visualizzare il contenuto del database ordinato per quantità

Visualizzare il contenuto del database ordinato per quantità.

```sql
SELECT * FROM prodotti ORDER BY quantita;
```

> è possibile utilizzare gli attributi ASC e DESC per l'ordinamento

### Esercizio 5 - Modificare il prezzo di un prodotto

Modificare il prezzo del prodotto con nome `p1` in `10`.

```sql
UPDATE prodotti SET prezzo = 10 WHERE nome = 'p1';
```

### Esercizio 6 - Eliminare un prodotto

Eliminare il prodotto con nome `p2`.

```sql
DELETE FROM prodotti WHERE nome = 'p2';
```

### Esercizio 7 - Visualizzare il prodotto p1

Visualizzare il prodotto con nome `p1`.

```sql
SELECT * FROM prodotti WHERE nome = 'p1';
```

### Esercizio 8 - Visualizzare il prodotto più costoso

Visualizzare il prodotto più costoso.

```sql
SELECT * FROM prodotti ORDER BY prezzo DESC LIMIT 1;
```

### Esercizio 9 - Visualizzare il prodotto meno costoso

Visualizzare il prodotto meno costoso.

```sql
SELECT * FROM prodotti ORDER BY prezzo ASC LIMIT 1;
```

### Esercizio 10 - creare un database di prodotti con id autoincrement

```sql
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, prezzo REAL, quantita INTEGER);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);
```

Si possono aggiungere più prodotti con il seguente comando:

```sql
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p4', 4, 40), ('p5', 5, 50);
```

### Esercizio 11 - creare un database di prodotti con id autoincrement e nome univoco

```sql
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);
```

### Esercizio 12 - creare un database di prodotti con id autoincrement e nome univoco e quantità non negativa

```sql
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0));
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);
```

### Esercizio 13 - creare un database di prodotti con una tabella prodotti ed una tabella categorie collegate tramite id_categoria

Creare un database di prodotti con le seguenti caratteristiche:

- id
- nome
- prezzo
- quantità
- id_categoria

Il database deve essere salvato in un file `database.db`.

Il database deve contenere una tabella `prodotti` ed una tabella `categorie`.

Il database deve contenere i seguenti dati:

| id  | nome | prezzo | quantità | id_categoria |
| --- | ---- | ------ | -------- | ------------ |
| 1   | p1   | 1      | 10       | 1            |
| 2   | p2   | 2      | 20       | 2            |
| 3   | p3   | 3      | 30       | 3            |

| id  | nome |
| --- | ---- |
| 1   | c1   |
| 2   | c2   |
| 3   | c3   |

```sql
CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
INSERT INTO categorie (nome) VALUES ('c1');
INSERT INTO categorie (nome) VALUES ('c2');
INSERT INTO categorie (nome) VALUES ('c3');
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p1', 1, 10, 1);
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p2', 2, 20, 2);
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p3', 3, 30, 3);
```

Esempio di join:

```sql
SELECT * FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id;
```

I dati vengono visualizzati in questo modo:

| id  | nome | prezzo | quantità | id_categoria | id  | nome |
| --- | ---- | ------ | -------- | ------------ | --- | ---- |
| 1   | p1   | 1      | 10       | 1            | 1   | c1   |
| 2   | p2   | 2      | 20       | 2            | 2   | c2   |
| 3   | p3   | 3      | 30       | 3            | 3   | c3   |

oppure si possono visualizzare i dati solo di alcune colonne con il comando:

```sql
SELECT prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id;
```

I dati vengono visualizzati in questo modo:

| nome | prezzo | quantità | nome |
| ---- | ------ | -------- | ---- |
| p1   | 1      | 10       | c1   |
| p2   | 2      | 20       | c2   |
| p3   | 3      | 30       | c3   |

> utilizzando .schema si può vedere la query di creazione delle tabelle

```sql
sqlite3> .schema prodotti
```

> si può creare un database con 3 tabelle prodotti categoria produttori relazionate in questo modo:

```sql
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, id_produttore INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id), FOREIGN KEY (id_produttore) REFERENCES produttori(id));
CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE produttori (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
```

> si possono inserire i dati in questo modo:

```sql
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria, id_produttore) VALUES ('p1', 1, 10, 1, 1);
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria, id_produttore) VALUES ('p2', 2, 20, 2, 2);
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria, id_produttore) VALUES ('p3', 3, 30, 3, 3);
INSERT INTO categorie (nome) VALUES ('c1');
INSERT INTO categorie (nome) VALUES ('c2');
INSERT INTO categorie (nome) VALUES ('c3');
INSERT INTO produttori (nome) VALUES ('pr1');
INSERT INTO produttori (nome) VALUES ('pr2');
INSERT INTO produttori (nome) VALUES ('pr3');
```

> si possono creare campi booleani in questo modo:

```sql
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, id_produttore INTEGER, disponibile BOOLEAN, FOREIGN KEY (id_categoria) REFERENCES categorie(id), FOREIGN KEY (id_produttore) REFERENCES produttori(id));
```

> il valore boolean può essere 0 o 1

```sql
SELECT * FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id JOIN produttori ON prodotti.id_produttore = produttori.id;
```

> si possono visualizzare i dati solo di alcune colonne con il comando:

```sql
SELECT prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome, produttori.nome FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id JOIN produttori ON prodotti.id_produttore = produttori.id;
```

> è possibile rinominare le colonne con il comando AS

```sql
SELECT prodotti.nome AS prodotto, prodotti.prezzo AS prezzo, prodotti.quantita AS quantita, categorie.nome AS categoria, produttori.nome AS produttore FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id JOIN produttori ON prodotti.id_produttore = produttori.id;
```

# App console per la creazione di un database di prodotti con 3 funzioni inserisci prodotto, visualizza prodotti ed elimina prodotto

```csharp
using System.Data.SQLite;
// comando installazione pacchetto System.Data.SQLite
// dotnet add package System.Data.SQLite


string path = @"database.db"; // la rotta del file del database

if (!File.Exists(path)) // se il file del database non esiste
{
    SQLiteConnection.CreateFile(path); // crea il file del database

    // crea la connessione al database la versione 3 è un indicazione della versione del database e può esser personalizzata
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;");

    connection.Open(); // apre la connessione al database

    string sql = @"
                CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0));
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto1', 1, 10);
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto2', 2, 20);
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto3', 3, 30);
                ";
    // opure insert multiplo cosi
    // INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto1', 1, 10), ('prodotto2', 2, 20), ('prodotto3', 3, 30);

    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database sql è la stringa che contiene il comando sql
    command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database nonquery significa che non si aspetta un risultato
    connection.Close(); // chiude la connessione al database
}
while (true)
{
    Console.WriteLine("1 - inserisci prodotto");
    Console.WriteLine("2 - visualizza prodotti");
    Console.WriteLine("3 - modifica prodotto");
    Console.WriteLine("4 - elimina prodotto");
    Console.WriteLine("0 - esci");
    Console.WriteLine("scegli un'opzione");
    string scelta = Console.ReadLine()!;
    if (scelta == "1")
    {
        Console.Clear(); // pulisco la console
        InserisciProdotto();
    }
    else if (scelta == "2")
    {
        Console.Clear(); // pulisco la console
        VisualizzaProdotti();
    }
    else if (scelta == "3")
    {
        Console.Clear(); // pulisco la console
        VisualizzaProdotti();
        Console.WriteLine("");
        ModificaProdotto();
    }
    else if (scelta == "4")
    {
        Console.Clear(); // pulisco la console
        VisualizzaProdotti();
        Console.WriteLine("");
        EliminaProdotto();
    }
    else if (scelta == "0")
    {
        break;
    }
}

static void InserisciProdotto()
{
    Console.WriteLine("inserisci il nome del prodotto");
    string nome = Console.ReadLine();
    Console.WriteLine("inserisci il prezzo del prodotto");
    string prezzo = Console.ReadLine();
    Console.WriteLine("inserisci la quantità del prodotto");
    string quantita = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
    connection.Open(); // apre la connessione al database
    string sql = $"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}', {prezzo}, {quantita})";
    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
    command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
    connection.Close(); // chiude la connessione al database
}

static void VisualizzaProdotti()
{
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
    connection.Open(); // apre la connessione al database
    string sql = "SELECT * FROM prodotti";
    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
    SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e
                                                       // salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
    while (reader.Read()) // legge i dati dal reader finche ce ne sono
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
    }
    connection.Close(); // chiude la connessione al database
}

static void ModificaProdotto()
{
    Console.WriteLine("inserisci il nome del prodotto da modificare");
    string nome = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
    connection.Open(); // apre la connessione al database
    string sql = $"SELECT * FROM prodotti WHERE nome = '{nome}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
    SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e
                                                       // salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
    if (reader.Read())
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
        Console.WriteLine("inserisci il nuovo nome del prodotto");
        string nuovoNome = Console.ReadLine();
        Console.WriteLine("inserisci il nuovo prezzo del prodotto");
        string nuovoPrezzo = Console.ReadLine();
        Console.WriteLine("inserisci la nuova quantità del prodotto");
        string nuovaQuantita = Console.ReadLine();
        
        sql = $"UPDATE prodotti SET nome = '{nuovoNome}', prezzo = {nuovoPrezzo}, quantita = {nuovaQuantita} WHERE nome = '{nome}'";
        command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
    }
    connection.Close(); // chiude la connessione al database
}

static void EliminaProdotto()
{
    Console.WriteLine("inserisci il nome del prodotto");
    string nome = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
    connection.Open(); // apre la connessione al database
    string sql = $"DELETE FROM prodotti WHERE nome = '{nome}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
    command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
    connection.Close(); // chiude la connessione al database
}
```

# App console per la gestione di un database di prodotti

Creare un'app console per la gestione di un database di prodotti.

L'applicazione deve permettere di:

- visualizzare i prodotti
- visualizzare i prodotti ordinati per prezzo
- visualizzare i prodotti ordinati per quantità
- modificare il prezzo di un prodotto
- eliminare un prodotto
- visualizzare il prodotto più costoso
- visualizzare il prodotto meno costoso
- inserire un prodotto
- visualizzare un prodotto
- visualizzare i prodotti di una categoria
- inserire una categoria
- eliminare una categoria

## App console completa

```csharp
using System.Data.SQLite;
// comando per installare il pacchetto System.Data.SQLite
// dotnet add package System.Data.SQLite


string path = @"database.db"; // il file deve essere nella stessa cartella del programma

if (!File.Exists(path))
{
    SQLiteConnection.CreateFile(path); // crea il file del database se non esiste
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"); // crea la connessione al database se non esiste utilizzando il file appena creato versiion identificata dal numero 3
    connection.Open(); // apre la connessione al database se non è già aperta

    string sql = @"
                    CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                    CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE,
                    prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER,
                    FOREIGN KEY (id_categoria) REFERENCES categorie(id));
                    INSERT INTO categorie (nome) VALUES ('categoria1'), ('categoria2'), ('categoria3');
                    INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('prodotto1', 1, 10, 1), ('prodotto2', 2, 20, 2), ('prodotto3', 3, 30, 3);
                    ";

    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database se non esiste
    command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database se non esiste
    connection.Close(); // chiude la connessione al database se non è già chiusa
}
while (true)
{
    Console.WriteLine("1 - visualizzare i prodotti");
    Console.WriteLine("2 - visualizzare i prodotti ordinati per prezzo");
    Console.WriteLine("3 - visualizzare i prodotti ordinati per quantità");
    Console.WriteLine("4 - modificare il prezzo di un prodotto");
    Console.WriteLine("5 - eliminare un prodotto");
    Console.WriteLine("6 - visualizzare il prodotto più costoso");
    Console.WriteLine("7 - visualizzare il prodotto meno costoso");
    Console.WriteLine("8 - inserire un prodotto");
    Console.WriteLine("9 - visualizzare un prodotto");
    Console.WriteLine("10 - visualizzare i prodotti di una categoria");
    Console.WriteLine("11 - inserire una categoria");
    Console.WriteLine("12 - eliminare una categoria");
    Console.WriteLine("13 - inserire un prodotto in una categoria");
    Console.WriteLine("14 - visualizzare i prodotti con la categoria");
    Console.WriteLine("15 - uscire");
    Console.WriteLine("scegli un'opzione");

    string scelta = Console.ReadLine()!;
    if (scelta == "1")
    {
        VisualizzaProdotti();
    }
    else if (scelta == "2")
    {
        VisualizzaProdottiOrdinatiPerPrezzo();
    }
    else if (scelta == "3")
    {
        VisualizzaProdottiOrdinatiPerQuantita();
    }
    else if (scelta == "4")
    {
        ModificaPrezzoProdotto();
    }
    else if (scelta == "5")
    {
        EliminaProdotto();
    }
    else if (scelta == "6")
    {
        VisualizzaProdottoPiuCostoso();
    }
    else if (scelta == "7")
    {
        VisualizzaProdottoMenoCostoso();
    }
    else if (scelta == "8")
    {
        InserisciProdotto();
    }
    else if (scelta == "9")
    {
        VisualizzaProdotto();
    }
    else if (scelta == "10")
    {
        VisualizzaProdottiCategoria();
    }
    else if (scelta == "11")
    {
        InserisciCategoria();
    }
    else if (scelta == "12")
    {
        EliminaCategoria();
    }
    else if (scelta == "13")
    {
        InserisciProdottoCategoria();
    }
    else if (scelta == "14")
    {
        VisualizzaProdottiAdvanced();
    }
    else if (scelta == "15")
    {
        break;
    }
    else
    {
        Console.WriteLine("scelta non valida");
    }
    /* oppure invece di usare if else if si può usare uno switch
    switch (scelta)
    {
        case "1":
            VisualizzaProdotti();
            break;
        case "2":
            VisualizzaProdottiOrdinatiPerPrezzo();
            break;
        case "3":
            VisualizzaProdottiOrdinatiPerQuantita();
            break;
        case "4":
            ModificaPrezzoProdotto();
            break;
        case "5":
            EliminaProdotto();
            break;
        case "6":
            VisualizzaProdottoPiuCostoso();
            break;
        case "7":
            VisualizzaProdottoMenoCostoso();
            break;
        case "8":
            InserisciProdotto();
            break;
        case "9":
            VisualizzaProdotto();
            break;
        case "10":
            VisualizzaProdottiCategoria();
            break;
        case "11":
            InserisciCategoria();
            break;
        case "12":
            EliminaCategoria();
            break;
        case "13":
            break;
    }

    */
}


static void VisualizzaProdotti()
{
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione di nuovo perché è stata chiusa alla fine del while in modo da poter visualizzare i dati aggiornati
connection.Open();

string sql = @"SELECT * FROM prodotti"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti

SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati

while (reader.Read())
{
    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
}
connection.Close(); // chiude la connessione al database se non è già chiusa
}

static void VisualizzaProdottiAdvanced()
{
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();

// Modifica la query SQL per includere una join con la tabella categorie
string sql = @"
SELECT prodotti.id, prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome AS nome_categoria
FROM prodotti
JOIN categorie ON prodotti.id_categoria = categorie.id";

SQLiteCommand command = new SQLiteCommand(sql, connection);
SQLiteDataReader reader = command.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, categoria: {reader["nome_categoria"]}");
}

connection.Close();
}

static void VisualizzaProdottiOrdinatiPerPrezzo()
{
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = "SELECT * FROM prodotti ORDER BY prezzo"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo
SQLiteCommand command = new SQLiteCommand(sql, connection);
SQLiteDataReader reader = command.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
}
connection.Close();
}

static void VisualizzaProdottiOrdinatiPerQuantita()
{
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = "SELECT * FROM prodotti ORDER BY quantita"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per quantita
SQLiteCommand command = new SQLiteCommand(sql, connection);
SQLiteDataReader reader = command.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
}
connection.Close();
}

static void ModificaPrezzoProdotto()
{
Console.WriteLine("inserisci il nome del prodotto"); // chiede il nome del prodotto da modificare
string nome = Console.ReadLine()!; // legge il nome del prodotto da modificare
Console.WriteLine("inserisci il nuovo prezzo"); // chiede il nuovo prezzo del prodotto da modificare
string prezzo = Console.ReadLine()!; // legge il nuovo prezzo del prodotto da modificare
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = $"UPDATE prodotti SET prezzo = {prezzo} WHERE nome = '{nome}'"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
SQLiteCommand command = new SQLiteCommand(sql, connection);
command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database ExecuteNonQuery() viene utilizzato per eseguire comandi che non restituiscono dati, ad esempio i comandi INSERT, UPDATE, DELETE
connection.Close();
}

static void EliminaProdotto()
{
Console.WriteLine("inserisci il nome del prodotto");
string nome = Console.ReadLine()!;
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = $"DELETE FROM prodotti WHERE nome = '{nome}'"; // crea il comando sql che elimina il prodotto con nome uguale a quello inserito
SQLiteCommand command = new SQLiteCommand(sql, connection);
command.ExecuteNonQuery();
connection.Close();
}

static void VisualizzaProdottoPiuCostoso()
{
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = "SELECT * FROM prodotti ORDER BY prezzo DESC LIMIT 1"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo in modo decrescente e ne prende solo il primo
SQLiteCommand command = new SQLiteCommand(sql, connection);
SQLiteDataReader reader = command.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
}
connection.Close();
}

static void VisualizzaProdottoMenoCostoso()
{
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = "SELECT * FROM prodotti ORDER BY prezzo ASC LIMIT 1"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo in modo crescente e ne prende solo il primo
SQLiteCommand command = new SQLiteCommand(sql, connection);
SQLiteDataReader reader = command.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
}
connection.Close();
}

static void InserisciProdotto()
{
Console.WriteLine("inserisci il nome del prodotto");
string nome = Console.ReadLine()!;
Console.WriteLine("inserisci il prezzo del prodotto");
string prezzo = Console.ReadLine()!;
Console.WriteLine("inserisci la quantità del prodotto");
string quantita = Console.ReadLine()!;
Console.WriteLine("inserisci l'id della categoria del prodotto");
string id_categoria = Console.ReadLine()!;
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = $"INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('{nome}', {prezzo}, {quantita}, {id_categoria})"; // crea il comando sql che inserisce un prodotto
SQLiteCommand command = new SQLiteCommand(sql, connection);
command.ExecuteNonQuery();
connection.Close();
}

// inserimento di prodotto chiamando prima la categoria e poi il prodotto in modo da avere in inserimento il nome della categoria invece dell id
static void InserisciProdottoCategoria()
{
//visualizza le categorie
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = "SELECT * FROM categorie";
SQLiteCommand command = new SQLiteCommand(sql, connection);
SQLiteDataReader reader = command.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}");
}
connection.Close();
//seleziona categoria
Console.WriteLine("inserisci l'id della categoria");
string id_categoria = Console.ReadLine()!;
//inserisci prodotto
Console.WriteLine("inserisci il nome del prodotto");
string nome = Console.ReadLine()!;
Console.WriteLine("inserisci il prezzo del prodotto");
string prezzo = Console.ReadLine()!;
Console.WriteLine("inserisci la quantità del prodotto");
string quantita = Console.ReadLine()!;
SQLiteConnection connectionins = new SQLiteConnection($"Data Source=database.db;Version=3;");
connectionins.Open();
string sqlins = $"INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('{nome}', {prezzo}, {quantita}, {id_categoria})"; // crea il comando sql che inserisce un prodotto
SQLiteCommand commandins = new SQLiteCommand(sqlins, connectionins);
commandins.ExecuteNonQuery();
connectionins.Close();
}

static void VisualizzaProdotto()
{
Console.WriteLine("inserisci il nome del prodotto");
string nome = Console.ReadLine()!;
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = $"SELECT * FROM prodotti WHERE nome = '{nome}'"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti con nome uguale a quello inserito
SQLiteCommand command = new SQLiteCommand(sql, connection);
SQLiteDataReader reader = command.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
}
connection.Close();
}

static void VisualizzaProdottiCategoria()
{
Console.WriteLine("inserisci l'id della categoria");
string id_categoria = Console.ReadLine()!;
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = $"SELECT * FROM prodotti WHERE id_categoria = {id_categoria}"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti con id_categoria uguale a quello inserito
SQLiteCommand command = new SQLiteCommand(sql, connection);
SQLiteDataReader reader = command.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
}
connection.Close();
}

static void InserisciCategoria()
{
Console.WriteLine("inserisci il nome della categoria");
string nome = Console.ReadLine()!;
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = $"INSERT INTO categorie (nome) VALUES ('{nome}')"; // crea il comando sql che inserisce una categoria
SQLiteCommand command = new SQLiteCommand(sql, connection);
command.ExecuteNonQuery();
connection.Close();
}

static void EliminaCategoria()
{
Console.WriteLine("inserisci il nome della categoria");
string nome = Console.ReadLine()!;
SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
connection.Open();
string sql = $"DELETE FROM categorie WHERE nome = '{nome}'"; // crea il comando sql che elimina la categoria con nome uguale a quello inserito
SQLiteCommand command = new SQLiteCommand(sql, connection);
command.ExecuteNonQuery();
connection.Close();
}
```
