CREATE TABLE collezione (id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        artist TEXT, 
                        album TEXT, 
                        id_genre INTEGER, FOREIGN KEY id_genre REFERENCES genere(id), 
                        price REAL, 
                        quantity INTEGER, 
                        available BOOLEAN);
