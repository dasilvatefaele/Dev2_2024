# INSERIMENTO DATI

## Obietivo
- calcola delle statistiche sulla base di alcuni punteggi inseriti dall'ultente 
- l'utente deve inseririre numeri interi
- l'inserimento di un numero negativo interrompe l'inserimento
- dopo l'interruzone il programma deve mostrare 
    - numero totale degli elementi inseriti
    - il più alto 
    - il più basso
    - la media

- se il primo numero inserito è negativo stampiamo un messaggio di errore
- usa una lista per memorizzare gli elementi inseriti dall'utente
- controlla come vengono gestiti gli input
- usa i metodi della libreria math

```mermaid
flowchart TD

id1((inizio))
id2[/input in lista/]
id3{inserimento <0}
id4[controllo lista]
id5[stampa numero più alto]
id5[stampa numero più basso]
id6[stampa la media]

id1-->id2
id2-->id3
id3-->|no|id2
id3-->|si|id4
id4-->id5
id5-->id6



```