# SIMON (Gioco musicale)

#### OBIETTIVO:
Creare un gioco come il popolare Simon! 4 colori, 4 note musicali della scala pentatonica

---
```mermaid
flowchart LR

id0((start))
id11(sequenzaRandom.Count = 0)
id6(generaNota da 1 a 4)
id3(riproduci sequenzaRandom)
id4[sequenzaRandom.Add 'nota']
id5[/acquisisci sequenzaUtente/]
id10{sequenzaRandom == 
sequenzaUtente}


id0-->id11
id11-->id6
id6-->id4
id4-->id3
id3-->id5
id5-->id10
id10-->|si|id6
id10-->|no|id7(game over)
```
---

Cosa occorre:
- un generatore Random da 0 a 3
- un array di 4 suoni
- una variabile per scrivere e leggere la sequenza (lista)

Processo:
```mermaid
flowchart

ID0(VIENE GENERATO
UN INDEX)

ID1(INDEX VIENE USATO
NELL'ARRAY DI SUONI)

ID2(VIENE RIPRODOTTO IL SUONO
DI QUELL'INDEX)

ID3(INDEX VIENE SALVATO
NELLA LISTA)

```
