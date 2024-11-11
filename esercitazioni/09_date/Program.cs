/*=========================================================
                            DATE
=========================================================*/

// ! Le stringhe in questo documento non sono interpolate, ma è uguale con l'interpolazione

/*

    ! Sintassi:       
    DateTime *NOME_VARIABILE* = new DateTime(*ANNO*,*MESE*,*GIORNO*);
    DateTime today = DateTime.Today; // oggi
    TimeSpan age = today - dataDiNascita;
    
    TODO :
    Gestione delle date
    Operazioni con date (sottrarre, sommare date)
    Confronto 

    ? PROSSIMAMENTE:
    using System.Globalization;;
    DateTime date2 = DateTime.ParseExact("2024-12-31", "yyyy,MM,dd", CultureInfo.InvariantCulture);

    ! Note:
    Funziona sia col costruttore new che come funzione.metodo

*/

using System.Data.Common;
using System.Globalization;

Console.Clear();

DateTime birthDate = new DateTime(1993,2,27);
// ? "DateTime" è una struttura che rappresenta un istante di tempo
// ? SINTASSI: (ANNO, MESE, GIORNO)

DateTime today = DateTime.Today; 
// ? "DateTime.Today" metodo che restituisce la data di oggi

TimeSpan age = today - birthDate;
// ? "TimeSpan" è una struttura che rappresenta un intervallo di tempo

Console.WriteLine($"Hai {age.Days / 365} anni");
Console.WriteLine($"Hai {age.TotalDays / 365} anni"); 

/*======================
// ! Alcuni metodi
======================*/
/* 

    Generici (meglio per .Days):
    age.Days 
    age.Hours
    age.Minutes
    age.Seconds
    age.Milliseconds
    age.Ticks    

    Più precisi (meglio per .TotalHours in poi):
    age.Days
    age.TotalHours
    age.TotalMinutes
    age.TotalSeconds
    age.TotalMilliseconds
    age.TotalTicks
*/

Console.WriteLine($"Si può anche dire che sei in vita da {age.TotalHours} ore");

DateTime nextYear = new DateTime(today.Year + 1 , 1 , 1);
// in questo caso ho usato il costruttore di DateTime con tre parametri che sono anno, mese e giorno
// metto 1 come mese e giorno perché voglio il primo giorno dell'anno

Console.WriteLine($"Mancano {nextYear - today} giorni a Capodanno");

DateTime nextMonth = today.AddMonths(1); // prossimo mese
// ? .AddMonth è un metodo di DateTime che aggiunge un numero di mesi a una data

Console.WriteLine($"Mancano {nextMonth - today} giorni al prossimo mese alla data di oggi");

DateTime nextWeek = today.AddDays(7); // prossima settimana
// ? .AddDays è un metodo di DateTime che aggiunge un numero di giorni a una data

Console.WriteLine($"Mancano {nextWeek - today} giorni alla prossima settimana");

DateTime date = DateTime.Parse("2024-12-31");
// Acquisizione di una data da stringa 

string dateString = date.ToString("dd//MM/yyyy");
// Converte in modo generico il TimeDate in una stringa. Quando inserito come argomento la formattazione, la formatta

Console.WriteLine(date);

/*======================
// ! Controllo inserimento
======================*/

DateTime parsedDate;
if(DateTime.TryParse("duemilaventiquattro-12-31", out parsedDate))
{
    Console.WriteLine("Conversione riuscita");
    Console.WriteLine(parsedDate);
}
else
{
    Console.WriteLine("Errore nella conversione");
}
// ? TryParse restituisce true se la conversione è riuscita, altrimenti restituisce false
// ? il risultato della conversione è restituito tramite il parametro out
// ? questa è un'introduzione alla gestione delle eccezioni

/*======================
// ! Formattazione
======================*/
// .ToLongDateString -> *GIORNO DELLA SETTIMANA* *GIORNO* *MESE* *ANNO*
Console.WriteLine($"Formato lungo: {birthDate.ToLongDateString()}");

// .ToShortDateString -> *GIORNO*/*MESE*/*ANNO*
Console.WriteLine($"Formato corto: {birthDate.ToShortDateString()}");

// ? FORMATI PERSONALIZZATI

// .ToString("MMMM") -> *MESE IN LETTERE*
Console.WriteLine($"formato personalizzato: {birthDate.ToString("MMMM")}");

// .ToString("MM") -> *MESE IN NUMERO*
Console.WriteLine($"formato personalizzato: {birthDate.ToString("MM")}");

// .ToString("MM") -> *MESE IN NUMERO*
Console.WriteLine($"formato personalizzato: {birthDate.ToString("dd-MM-yyyy")}");

// Si può inserire una data e farci restituire il giorno della settimana corrispondente
Console.WriteLine("Il giorno della settimana è: " + birthDate.DayOfWeek);
// .DayOfWeek restituisce in inglese.

Console.WriteLine("Il giorno della settimana è: " + birthDate.ToString("dddd"));
// .ToString("dddd") restituisce nella lingua locale

Console.WriteLine("Il giorno della settimana è: " + (int)birthDate.DayOfWeek);
// (int)birthDate.DayOfWeek restituisce il numero della settimana 

Console.WriteLine("Il giorno della settimana è: " + (int)birthDate.DayOfYear);
// (int)birthDate.DayOfYear restituisce il numero giorno dell'anno


/*======================
// ! Operazione con le date
======================*/

DateTime domani = today.AddDays(1); 
Console.WriteLine($"Domani sarà {domani.ToString("dddd")}");

DateTime ieri = today.AddDays(-1); 
Console.WriteLine($"Ieri era {ieri.ToString("dddd")}");


// Calcolo quanti giorni mancano al mio compleanno

DateTime nextBirthday = new DateTime (today.Year, 2 , 27);

if (nextBirthday < today)
{
    nextBirthday = nextBirthday.AddYears(1);
}


int daysUntilBirthday = (nextBirthday - today).Days;
Console.WriteLine("Giorni fino al prossimo compleanno: " + daysUntilBirthday);

/*======================
// ! Confronto tra date
======================*/

DateTime date1 = DateTime.Today; // Oggi
DateTime date2 = new DateTime (2024,12,31); // scegli una data
int result = DateTime.Compare(date1,date2); // confronto tra le date

Console.WriteLine(result);

if (result < 0)
{
    Console.WriteLine("La prima data viene prima della seconda data");
}
else if (result > 0)
{
    Console.WriteLine("La seconda data  viene prima della prima data");
}
else
{
    Console.WriteLine("Le due date sono uguali");
}

// TODO: Calcolo differenza tra le date in giorni, ore, minuti con la struttura TimeSpan

TimeSpan daysLeft = date2 - date1;

Console.WriteLine($"Tra le due date c'è una differenza di {daysLeft.Days} giorni");
Console.WriteLine($"Oppure {daysLeft.TotalHours} ore");

// TODO: Calcolo differenza tra date in giorni, ore, minuti con il metodo .Subtract
// ? Syntax     :       end.Subtract(start);
/*
DateTime start = date1;
DateTime end = date2;

daysLeft = end.Subtract(start);
Console.WriteLine($"Differenza in giorni: {daysLeft.Days}");
Console.WriteLine($"Differenza in ore: {daysLeft.TotalHours}");
Console.WriteLine($"Differenza in minuti: {daysLeft.TotalMinutes}");
*/

daysLeft = date2.Subtract(date1);

Console.WriteLine($"Differenza in giorni: {daysLeft.Days}");  // restituisce numero di giorni interi
Console.WriteLine($"Differenza in ore: {daysLeft.TotalHours}");  // restituisce numero di giorni con i decimali
Console.WriteLine($"Differenza in minuti: {daysLeft.TotalMinutes}");

/*======================
// ! Manipolazione date
======================*/

// ? Metodo .Add(*TimeSpan Type*)

TimeSpan timeSpan = new TimeSpan (3,5,10,0); //3d,5h,10min,0sec

DateTime resultDate = today.Add(timeSpan);
Console.WriteLine($"Tra {timeSpan.ToString()} sarà il giorno {resultDate.ToLongDateString()} ");
