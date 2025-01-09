
# SQLite Syntax Checker

# CHECK YOUR QUERY
```sql

CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE prodotti ( id INTEGER PRIMARY KEY AUTOINCREMENT, nome Text, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
INSERT INTO categorie (nome) VALUES ('cat1'), ('cat2'), ('cat3');
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('prodotto1', 1, 10,1), ('prodotto2', 2, 20, 2),  ('prodotto3', 3, 30, 3);























```
