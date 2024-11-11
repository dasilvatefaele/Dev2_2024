# Calcolatrice semplice
Scrivere un programma che simuli una calcolatrice semplice.
## Versione 1
### Obiettivo:
- Utente deve poter inserire due numeri e selezionare un operatore matematico (+,-,*,/)
- Il programma deve eseguire l'operazione e stampare il risultato
- Il programma non gestisce nessun tipo di errore o eccezione


> Esempio di codice
```csharp
//* chiedi all'utente di inserire due numeri
double numero1;
double numero2;
double risultato = -1;

//Dialogo
Console.Clear();
Console.WriteLine("Inserisci numeri:");
Console.Write("> ");
numero1 = double.Parse(Console.ReadLine());
Console.Write("> ");
numero2 = double.Parse(Console.ReadLine());

//* chiedi all'utente di selezionare operatore matematico
Console.WriteLine("Scegli l'operatore:");
Console.WriteLine("\n+\t-\t*\t/\n");
Console.Write("> ");
string operatore = Console.ReadLine();


//* esegui l'operazione selezionata
switch (operatore)
{
    case "+":
        risultato = numero1+numero2;
        break;
    case "-":
        risultato = numero1-numero2;
        break;
    case "*":
        risultato = numero1*numero2;
        break;
    case "/":
        risultato = numero1/numero2;
        break;
    default:
        Console.WriteLine("Operatore non valido");
        break;
}

//* stampa risultato
Console.WriteLine($"= {risultato}");
```

> Comandi di versionamento
```powershell
git add --all
git commit -m "03 calcolatrice v1"
git push -u origin main
```

## Versione 2
### Obiettivo
- Gestione degli errori