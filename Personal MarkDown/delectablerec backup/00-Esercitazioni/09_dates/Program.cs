// GESTIONE DELLE DATE

DateTime birthDate = new DateTime(1990, 1, 1); // Inserisci la tua data di nascita
// DateTime e una struttura che rappresenta un istante di tempo
// Il costruttore di DateTime accetta tre parametri: anno, mese e giorno
Console.WriteLine($"Sei nato il {birthDate}"); // Stampa la data di nascita

DateTime today = DateTime.Today; // Oggi

TimeSpan age = today - birthDate; // Oggi - data di nascita
// TimeSpan e una struttura che rappresenta un intervallo di tempo

Console.WriteLine($"Hai {age.Days / 365} anni"); // Stampa l'eta
// age.Days restituisce il numero di giorni tra due date
// age.Days / 365 restituisce il numero di anni
// posso usare age.TotalDays per avere un valore decimale
// age.hours, age.minutes, age.seconds, age.milliseconds, age.ticks
// i ticks sono i decimi di microsecondi
// age.totalhours, age.totalminutes, age.totalseconds, age.totalmilliseconds, age.totalticks

DateTime nextYear = new DateTime(today.Year + 1, 1, 1); // Prossimo anno
// in questo caso ho usato il costruttore di DateTime con tre parametri che sono anno, mese e giorno
// metto 1 come mese e giorno perche voglio il primo giorno dell'anno

Console.WriteLine($"Mancano {nextYear - today} giorni a Capodanno"); // Stampa i giorni mancanti a Capodanno

DateTime nextMonth = today.AddMonths(1); // Prossimo mese
// AddMonths e un metodo di DateTime che aggiunge un numero di mesi a una data

Console.WriteLine($"Mancano {nextMonth - today} giorni al prossimo mese"); // Stampa i giorni mancanti al prossimo mese alla data di oggi

DateTime nextWeek = today.AddDays(7); // Prossima settimana
// AddDays e un metodo di DateTime che aggiunge un numero di giorni a una data

Console.WriteLine($"Mancano {nextWeek - today} giorni alla prossima settimana");

// CONVERSIONI

// DateTime.Parse e un metodo che converte una stringa in un oggetto DateTime
DateTime date = DateTime.Parse("2024-12-31");
Console.WriteLine(date);

// DateTime.ToString e un metodo che converte un oggetto DateTime in una stringa
string dateString = date.ToString("dd/MM/yyyy");
Console.WriteLine(dateString);

// DateTime.TryParse e un metodo che converte una stringa in un oggetto DateTime
DateTime parsedDate;
if (DateTime.TryParse("2024-12-31", out parsedDate))
{
    Console.WriteLine(parsedDate);
}
else
{
    Console.WriteLine("Errore nella conversione della data");
}
// TryParse restituisce true se la conversione e riuscita, altrimenti restituisce false
// il risultato della conversione e restituito tramite il parametro out
// questa e un introduzione alla gestione delle eccezioni

// FORMATTAZIONE

// e possibile formattare le date in diversi modi
Console.WriteLine($"Formato lungo: {birthDate.ToLongDateString()}");
Console.WriteLine($"Formato corto: {birthDate.ToShortDateString()}");

Console.WriteLine($"Anno: {birthDate.ToString("MMMM")}");
Console.WriteLine($"Mese in formato testuale: {birthDate.ToString("MM")}");

Console.WriteLine($"Formato personalizzato: {birthDate.ToString("yyyy-MM-dd")}");
Console.WriteLine($"Formato personalizzato: {birthDate.ToString("dd-MM-yyyy")}");

// si puo inserireuna data e farci restituire il giorno della settimana
Console.WriteLine($"Il giorno della settimana e: {birthDate.DayOfWeek}"); // lo scrive in inglese
// se lo vogliamo in italiano dobbiamo fare una conversione
Console.WriteLine($"Il giorno della settimana e: {birthDate:dddd}");
// dddd e il formato per il giorno della settimana in formato testuale

// possiamo farci restituire l indice numerico del giorno della settimana
Console.WriteLine($"Il giorno della settimana e: {(int)birthDate.DayOfWeek}");

// possiamo restituire il giorno dell anno con il metodo DayOfYear
Console.WriteLine($"Il giorno dell'anno e: {birthDate.DayOfYear}");

// OPERAZIONI CON LE DATE

// possiamo sommare o sottrarre un intervallo di tempo a una data
DateTime domani = today.AddDays(1);
Console.WriteLine($"Domani e: {domani}");
DateTime ieri = today.AddDays(-1);
Console.WriteLine($"Ieri era: {ieri}");
// ieri informato giorno stringa
Console.WriteLine($"Ieri era {ieri:dddd}");
// domani in formato stringa
Console.WriteLine($"Domani e {domani:dddd}");

// possiamo calcolare i giorni mancanti al prossimo compleanno
DateTime nextBirthday = new DateTime(today.Year, 1, 1); // Inserisci la data del tuo compleanno
if (nextBirthday < today)
{
    nextBirthday = nextBirthday.AddYears(1); // Aggiungi un anno se il compleanno e passato
}
int daysUntilBirthday = (nextBirthday - today).Days; // Calcola i giorni mancanti restituendo il numero di giorni
Console.WriteLine($"Mancano {daysUntilBirthday} giorni al tuo prossimo compleanno");

// confronto tra date usando il metodo Compare
DateTime date1 = DateTime.Today; // Oggi
DateTime date2 = new DateTime(2024, 12, 31); // Scegli una data
int result = DateTime.Compare(date1, date2); // confronto tra date
if (result < 0)
{
    Console.WriteLine("La prima data viene prima della seconda data");
}
else if (result > 0)
{
    Console.WriteLine("La seconda data viene prima della prima data");
}
else
{
    Console.WriteLine("Le due date sono uguali");
}

// calcolare la differenza tra due date usando il metodo Subtract
DateTime start = new DateTime(2024, 1, 1); // Inserisci la data di inizio
DateTime end = new DateTime(2024, 12, 31); // Inserisci la data di fine
TimeSpan difference = end.Subtract(start); // Calcola la differenza tra le due date
Console.WriteLine($"La differenza tra le due date e di {difference.Days} giorni");

// calcolare la differenza tra due date usando TimeSpan
DateTime startDate = DateTime.Today;
DateTime endDate = new DateTime(2024, 12, 31);
TimeSpan differenceDate = endDate - startDate;
Console.WriteLine($"La differenza tra le due date e di {differenceDate.Days} giorni"); // Days restituisce il numero di giorni interi
Console.WriteLine($"La differenza tra le due date e di {differenceDate.TotalDays} giorni"); // TotalDays restituisce il numero di giorni con i decimali
Console.WriteLine($"La differenza tra le due date e di {differenceDate.TotalHours} ore");

// manipalzione di date usando il metodo Add
TimeSpan timeSpan = new TimeSpan(5, 3, 5, 10, 0, 0); // 5 giorni, 3 ore, 5 minuti, 10 secondi e 0 millisecondi 0 microsecondi
DateTime todayDate = DateTime.Today; // Oggi
DateTime resultDate = todayDate.Add(timeSpan); // Aggiungi l'intervallo di tempo a oggi
Console.WriteLine($"La data risultante e: {resultDate}");