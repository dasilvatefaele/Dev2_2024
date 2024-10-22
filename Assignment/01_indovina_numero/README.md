# INDOVINA NUMERO

## Obiettivo 

L'obiettivo di questa di questa applicazione è generare un **numero casuale** generato dal computer.

> Generazione numero casuale:
1. **new** è il costruttore della classe **Random();** che istanzia un oggetto **Random**.

2. **random** è l'oggetto Random che possiamo utilizzare per generare numeri casuali.

3. **.Next** è il metodo che genera un numero casuale.

4. L'intervallo del metodo .Next **è semi aperto** tra 1 e 101. Comprende il numero iniziale (1) ma esclude quello finale (101). Dunque l'intervallo è da 1 a 100 (99 numeri).

>**Esempio di codice per generazione numero casuale:** 
```csharp
Random random = new Random();
numeroDaIndovinare = random.Next(1,101);
```

## v1.1
Pulizia codice, console più pulita, formattazione più omogenea.

## v1.2
Possibilità di scegliere Facile (1-20), Medio (1-50), Difficile (1-100)

## v1.3
Dopo 5 tentativi sbagliati propone 3 indizi (maggiore o minore / pari o dispari)

## v1.4
Oceano (differenza > 50%), Acqua (25% > differenza < 50% )  Fuoco (differenza < 25%) Fuochissmo (differenza < 10%)

## v1.5
Sessione di gioco prolungata. Sistema di punteggio

> SISTEMA DI PUNTEGGIO: 

1. Quando si indovina un numero, i tentativi rimasti vengono moltiplicati per x10 e sommati alla variabile int valPunteggio.

2. La sessione avrà 3 Round. 

3. Alla fine sarà possibile salvare in un file un punteggio associato al nome di un giocatore.