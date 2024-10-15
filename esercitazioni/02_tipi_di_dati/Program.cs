//      I TIPI DI DATI SEMPLICI
//      VARIABILI DI TIPO INTERO

// dichiarazione: definizione del tipo di dato, nome variabile, valore
//[tipo di dato] [nome variabile] = [valore];

int eta = 10;               //      NUMERO INTERO
double altezza = 1.70;      //      NUMERO CON LA VIRGOLA
char iniziale = 'F';        //      CARATTERE - Apice singole
string nome = "Felipe";     //      STRINGA - Apice doppie
bool maggiorenne = true;    //      TRUE / FALSE

DateTime dataNascita = new DateTime(2000,1,1);      //      DATE

// Utilizzo variabile attraverso metodo di console e interpolazione:
Console.WriteLine($"Il valore di nome è {nome}");
Console.WriteLine($"Il valore di altezza è {altezza}");
Console.WriteLine($"Il valore di iniziale è {iniziale}");
Console.WriteLine($"Il valore di maggiorenne è {maggiorenne}");
Console.WriteLine($"Il valore di maggiorenne è {dataNascita}");

