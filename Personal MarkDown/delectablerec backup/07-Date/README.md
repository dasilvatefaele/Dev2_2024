# DATE

**Esercizio 1:** Creazione e Formattazione di Date

- Obiettivo: Crea un oggetto DateTime per la tua data di nascita e stampalo in diversi formati.
- Compiti: Crea un oggetto DateTime con la tua data di nascita.
- Stampa la data in formato lungo.
- Stampa solo il mese in formato testuale (es. "Gennaio").
- Stampa la data in formato "dd-MM-yyyy".

**Esercizio 2:** Operazioni con Date

- Obiettivo: Aggiungi e sottrai giorni da una data specificata.
- Compiti:
- Partendo dalla data odierna, aggiungi 100 giorni e mostra la nuova data.
- Sottrai 75 giorni dalla data odierna e mostra il risultato.
- Determina quanti giorni ci sono fino al tuo prossimo compleanno.

**Esercizio 3:** Confronto tra Date

- Obiettivo: Confronta due date per determinare quale viene prima o se sono uguali.
- Compiti: Crea due oggetti DateTime, uno per oggi e uno per una data di tua scelta.
- Usa DateTime.Compare per determinare quale data viene prima.
- Stampa un messaggio appropriato basato sul confronto.

**Esercizio 4:** Differenza tra Date

- Obiettivo: Calcola la differenza in giorni, ore e minuti tra due date.
- Compiti: Crea due date, una rappresentante oggi e una rappresentante un altro giorno significativo (ad esempio, la data di un evento futuro).
- Calcola la differenza tra queste due date usando TimeSpan.
- Stampa la differenza in giorni, ore e minuti.

**Esercizio 5:** Uso di TimeSpan

- Obiettivo: Impara a usare TimeSpan per misurare intervalli di tempo.
- Compiti: Crea un TimeSpan per un intervallo di tempo specifico (es. 3 giorni, 5 ore, e 10 minuti).
- Aggiungi questo TimeSpan alla data odierna.
- Stampa la data e l'ora risultante.

> Questi esercizi ti forniranno una base solida per lavorare con le date e gli orari in C#

Esercizio 1: Creazione e Formattazione di Date
```csharp

DateTime birthDate = new DateTime(1990, 1, 1); // Inserisci la tua data di nascita
Console.WriteLine("Formato lungo: " + birthDate.ToLongDateString());
Console.WriteLine("Mese in formato testuale: " + birthDate.ToString("MMMM"));
Console.WriteLine("Formato personalizzato: " + birthDate.ToString("dd-MM-yyyy"));
    
```
Esercizio 2: Operazioni con Date
```csharp

DateTime today = DateTime.Today;
DateTime futureDate = today.AddDays(100);
DateTime pastDate = today.AddDays(-75);

Console.WriteLine("100 giorni da oggi: " + futureDate.ToShortDateString());
Console.WriteLine("75 giorni prima di oggi: " + pastDate.ToShortDateString());

DateTime nextBirthday = new DateTime(today.Year, 1, 1); // Inserisci la data del tuo compleanno
if (nextBirthday < today)
{
    nextBirthday = nextBirthday.AddYears(1);
}
int daysUntilBirthday = (nextBirthday - today).Days;
Console.WriteLine("Giorni fino al prossimo compleanno: " + daysUntilBirthday);
    
```
Esercizio 3: Confronto tra Date
```csharp

DateTime date1 = DateTime.Today;
DateTime date2 = new DateTime(2024, 12, 31); // Scegli una data
int result = DateTime.Compare(date1, date2);
if (result < 0)
{
    Console.WriteLine("La prima data viene prima della seconda data.");
}
else if (result > 0)
{
    Console.WriteLine("La seconda data viene prima della prima data.");
}
else
{
    Console.WriteLine("Le due date sono uguali.");
}
```
Esercizio 4: Differenza tra Date
```csharp

DateTime startDate = DateTime.Today;
DateTime endDate = new DateTime(2024, 12, 31); // Scegli una data significativa
TimeSpan difference = endDate - startDate;
Console.WriteLine("Differenza in giorni: " + difference.Days);
Console.WriteLine("Differenza in ore: " + difference.TotalHours);
Console.WriteLine("Differenza in minuti: " + difference.TotalMinutes);
    
```
Esercizio 5: Uso di TimeSpan
```csharp

TimeSpan timeSpan = new TimeSpan(3, 5, 10, 0); // 3 giorni, 5 ore, 10 minuti 0 secondi
DateTime today = DateTime.Today;
DateTime resultDate = today.Add(timeSpan);

Console.WriteLine("Data e ora risultante: " + resultDate);
    
```