# LE FUNZIONI

Nel contesto della programmazione, il termine "funzione" si riferisce a un blocco di codice che è progettato per eseguire un compito specifico. Questo blocco di codice può essere chiamato (o invocato) quando necessario nel programma, potenzialmente molte volte e da diverse parti del codice. Le funzioni aiutano a rendere il codice più organizzato, riutilizzabile e più facile da leggere e mantenere.

**Caratteristiche delle Funzioni**

- Riutilizzabilità: Una volta definita, una funzione può essere riutilizzata in diverse parti del programma. Questo aiuta a ridurre la duplicazione del codice.
- Modularità: Le funzioni permettono di dividere un programma in parti più piccole e gestibili, ognuna delle quali si occupa di una parte specifica della funzionalità complessiva del programma.
- Incapsulamento: Le funzioni possono incapsulare la logica, nascondendo la complessità delle operazioni e esponendo solo le parti necessarie per il resto del programma (ad esempio, i parametri di input e i valori di ritorno)

# VOID TIPI DI RITORNO

In C#, la parola chiave void è utilizzata per indicare che un metodo non restituisce alcun valore. È spesso usata per definire metodi che eseguono un'azione, come stampare qualcosa sullo schermo o modificare lo stato di un oggetto, senza produrre un risultato che deve essere ritornato al chiamante.

Ecco alcuni esempi di metodi con e senza void per chiarire il concetto:

**Metodo void**

> Un metodo void esegue alcune operazioni ma non restituisce alcun valore.

```csharp
// Definizione di un metodo void
public void StampaMessaggio(string messaggio)
{
    Console.WriteLine(messaggio);
}

// Utilizzo del metodo
StampaMessaggio("Ciao, mondo!");
In questo esempio, il metodo StampaMessaggio prende una stringa come parametro e la stampa sulla console. Non restituisce nulla, quindi il tipo di ritorno è void.
```
Metodo con un valore di ritorno
Un metodo che restituisce un valore deve specificare il tipo di quel valore al posto di void.

```csharp
// Definizione di un metodo che restituisce un valore
public int Somma(int a, int b)
{
    return a + b;
}

// Utilizzo del metodo
int risultato = Somma(3, 4);
Console.WriteLine(risultato);  // Stampa 7
```
In questo esempio, il metodo Somma prende due interi come parametri e restituisce la loro somma. Poiché restituisce un intero, il tipo di ritorno è int anziché void.

Differenza tra void e tipi di ritorno

- void: Indica che il metodo non restituisce alcun valore. Viene utilizzato quando il metodo esegue un'azione, come la stampa di un messaggio, la modifica di un oggetto, o l'esecuzione di un'operazione.
- Tipi di ritorno (es. int, string, bool): Indicano che il metodo restituirà un valore di quel tipo. Viene utilizzato quando il metodo esegue calcoli, elabora dati, o determina una condizione che deve essere riportata al chiamante.

**Esempio completo**

Ecco un esempio che combina entrambi i tipi di metodi:

```csharp
static void Main()
{
    StampaMessaggio("Ciao, mondo!");

    int risultato = Somma(3, 4);
    Console.WriteLine($"La somma è: {risultato}");
}

// Metodo void
public static void StampaMessaggio(string messaggio)
{
    Console.WriteLine(messaggio);
}

// Metodo con ritorno di valore
public static int Somma(int a, int b)
{
    return a + b;
}
 ```


In questo programma, StampaMessaggio è un metodo void che stampa un messaggio sulla console,mentre Somma è un metodo che restituisce un valore intero che rappresenta la somma dei due numeri forniti come parametri

# PROGRAMMA GESTIONE TXT SENZA FUNZIONI

```csharp
List<string> partecipanti = new List<string>();
const string filePath = "partecipanti.txt";


// Carica i partecipanti dal file se esiste
if (File.Exists(filePath))
{
    partecipanti = new List<string>(File.ReadAllLines(filePath));
}

int scelta;
do
{
    Console.Clear();
    Console.WriteLine("1. Inserisci partecipante");
    Console.WriteLine("2. Visualizza partecipanti");
    Console.WriteLine("3. Ordina partecipanti");
    Console.WriteLine("4. Cerca partecipante");
    Console.WriteLine("5. Elimina partecipante");
    Console.WriteLine("6. Modifica partecipante");
    Console.WriteLine("7. Numero partecipanti");
    Console.WriteLine("8. Dividi partecipanti in 2 squadre");
    Console.WriteLine("9. Dividi partecipanti in 2 squadre con random");
    Console.WriteLine("10. Esci");
    Console.Write("Scelta: ");
    scelta = Convert.ToInt32(Console.ReadLine());
    switch (scelta)
    {
        case 1:
            Console.Write("Nome partecipante: ");
            string nome = Console.ReadLine();
            partecipanti.Add(nome);
            // Salva i partecipanti nel file
            File.WriteAllLines(filePath, partecipanti);
            break;
        case 2:
            Console.WriteLine("Elenco partecipanti:");
            foreach (string partecipante in partecipanti)
            {
                Console.WriteLine(partecipante);
            }
            break;
        case 3:
            Console.WriteLine("1. Ordine crescente");
            Console.WriteLine("2. Ordine decrescente");
            Console.Write("Scelta: ");
            int ordine = Convert.ToInt32(Console.ReadLine());
            if (ordine == 1)
            {
                partecipanti.Sort();
            }
            else if (ordine == 2)
            {
                partecipanti.Sort();
                partecipanti.Reverse();
            }
            else
            {
                Console.WriteLine("Scelta non valida");
            }
            // Salva i partecipanti nel file
            File.WriteAllLines(filePath, partecipanti);
            break;
        case 4:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                Console.WriteLine("Il partecipante è presente nella lista");
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista");
            }
            break;
        case 5:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                partecipanti.Remove(nome);
                Console.WriteLine("Il partecipante è stato eliminato dalla lista");
                // Salva i partecipanti nel file
                File.WriteAllLines(filePath, partecipanti);
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista");
            }
            break;
        case 6:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                Console.Write("Nuovo nome: ");
                string nuovoNome = Console.ReadLine();
                int indice = partecipanti.IndexOf(nome);
                partecipanti[indice] = nuovoNome;
                Console.WriteLine("Il partecipante è stato modificato nella lista");
                // Salva i partecipanti nel file
                File.WriteAllLines(filePath, partecipanti);
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista");
            }
            break;
        case 7:
            Console.WriteLine($"Numero partecipanti: {partecipanti.Count}");
            break;
        case 8:
            int split = partecipanti.Count / 2;
            List<string> squadra1 = partecipanti.GetRange(0, split);
            List<string> squadra2 = partecipanti.GetRange(split, partecipanti.Count - split);
            Console.WriteLine("Squadra 1:");
            foreach (string partecipante in squadra1)
            {
                Console.WriteLine(partecipante);
            }
            Console.WriteLine("Squadra 2:");
            foreach (string partecipante in squadra2)
            {
                Console.WriteLine(partecipante);
            }
            break;
        case 9:
            List<string> squadra1Random = new List<string>();
            List<string> squadra2Random = new List<string>();
            List<string> tempPartecipanti = new List<string>(partecipanti);
            Random random = new Random();
            while (tempPartecipanti.Count > 0)
            {
                int indice = random.Next(tempPartecipanti.Count);
                string partecipante = tempPartecipanti[indice];
                tempPartecipanti.RemoveAt(indice);
                if (squadra1Random.Count < squadra2Random.Count)
                {
                    squadra1Random.Add(partecipante);
                }
                else
                {
                    squadra2Random.Add(partecipante);
                }
            }
            Console.WriteLine("Squadra 1:");
            foreach (string partecipante in squadra1Random)
            {
                Console.WriteLine(partecipante);
            }
            Console.WriteLine("Squadra 2:");
            foreach (string partecipante in squadra2Random)
            {
                Console.WriteLine(partecipante);
            }
            break;
        case 10:
            Console.WriteLine("Arrivederci!");
            break;
        default:
            Console.WriteLine("Scelta non valida");
            break;
    }
    if (scelta != 8 && scelta != 10)
    {
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }
} while (scelta != 10);

```

# PROGRAMMA GESTIONE TXT CON FUNZIONI

```csharp

class Program
{
    static List<string> partecipanti = new List<string>();
    const string filePath = "partecipanti.txt";

    static void Main()
    {
        CaricaPartecipanti();
        int scelta;
        do
        {
            Console.Clear();
            Console.WriteLine("1. Inserisci partecipante");
            Console.WriteLine("2. Visualizza partecipanti");
            Console.WriteLine("3. Ordina partecipanti");
            Console.WriteLine("4. Cerca partecipante");
            Console.WriteLine("5. Elimina partecipante");
            Console.WriteLine("6. Modifica partecipante");
            Console.WriteLine("7. Numero partecipanti");
            Console.WriteLine("8. Dividi partecipanti in 2 squadre");
            Console.WriteLine("9. Dividi partecipanti in 2 squadre con random");
            Console.WriteLine("10. Esci");
            Console.Write("Scelta: ");
            scelta = Convert.ToInt32(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    InserisciPartecipante();
                    break;
                case 2:
                    VisualizzaPartecipanti();
                    break;
                case 3:
                    OrdinaPartecipanti();
                    break;
                case 4:
                    CercaPartecipante();
                    break;
                case 5:
                    EliminaPartecipante();
                    break;
                case 6:
                    ModificaPartecipante();
                    break;
                case 7:
                    NumeroPartecipanti();
                    break;
                case 8:
                    DividiPartecipantiInSquadre();
                    break;
                case 9:
                    DividiPartecipantiInSquadreConRandom();
                    break;
                case 10:
                    Console.WriteLine("Arrivederci!");
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
            if (scelta != 10)
            {
                Console.WriteLine("Premi un tasto per continuare...");
                Console.ReadKey();
            }
        }
        while (scelta != 10);
    }

    static void CaricaPartecipanti()
    {
        if (File.Exists(filePath))
        {
            partecipanti = new List<string>(File.ReadAllLines(filePath));
        }
    }

    static void SalvaPartecipanti()
    {
        File.WriteAllLines(filePath, partecipanti);
    }

    static void InserisciPartecipante()
    {
        Console.Write("Nome partecipante: ");
        string nome = Console.ReadLine();
        partecipanti.Add(nome);
        SalvaPartecipanti();
    }

    static void VisualizzaPartecipanti()
    {
        Console.WriteLine("Elenco partecipanti:");
        foreach (string partecipante in partecipanti)
        {
            Console.WriteLine(partecipante);
        }
    }

    static void OrdinaPartecipanti()
    {
        Console.WriteLine("1. Ordine crescente");
        Console.WriteLine("2. Ordine decrescente");
        Console.Write("Scelta: ");
        int ordine = Convert.ToInt32(Console.ReadLine());
        if (ordine == 1)
        {
            partecipanti.Sort();
        }
        else if (ordine == 2)
        {
            partecipanti.Sort();
            partecipanti.Reverse();
        }
        else
        {
            Console.WriteLine("Scelta non valida");
        }
        SalvaPartecipanti();
    }

    static void CercaPartecipante()
    {
        Console.Write("Nome partecipante: ");
        string nome = Console.ReadLine();
        if (partecipanti.Contains(nome))
        {
            Console.WriteLine("Il partecipante è presente nella lista");
        }
        else
        {
            Console.WriteLine("Il partecipante non è presente nella lista");
        }
    }

    static void EliminaPartecipante()
    {
        Console.Write("Nome partecipante: ");
        string nome = Console.ReadLine();
        if (partecipanti.Contains(nome))
        {
            partecipanti.Remove(nome);
            Console.WriteLine("Il partecipante è stato eliminato dalla lista");
            SalvaPartecipanti();
        }
        else
        {
            Console.WriteLine("Il partecipante non è presente nella lista");
        }
    }

    static void ModificaPartecipante()
    {
        Console.Write("Nome partecipante: ");
        string nome = Console.ReadLine();
        if (partecipanti.Contains(nome))
        {
            Console.Write("Nuovo nome: ");
            string nuovoNome = Console.ReadLine();
            int indice = partecipanti.IndexOf(nome);
            partecipanti[indice] = nuovoNome;
            Console.WriteLine("Il partecipante è stato modificato nella lista");
            SalvaPartecipanti();
        }
        else
        {
            Console.WriteLine("Il partecipante non è presente nella lista");
        }
    }

    static void NumeroPartecipanti()
    {
        Console.WriteLine($"Numero partecipanti: {partecipanti.Count}");
    }

    static void DividiPartecipantiInSquadre()
    {
        int split = partecipanti.Count / 2;
        List<string> squadra1 = partecipanti.GetRange(0, split);
        List<string> squadra2 = partecipanti.GetRange(split, partecipanti.Count - split);
        Console.WriteLine("Squadra 1:");
        foreach (string partecipante in squadra1)
        {
            Console.WriteLine(partecipante);
        }
        Console.WriteLine("Squadra 2:");
        foreach (string partecipante in squadra2)
        {
            Console.WriteLine(partecipante);
        }
    }

    static void DividiPartecipantiInSquadreConRandom()
    {
        List<string> squadra1Random = new List<string>();
        List<string> squadra2Random = new List<string>();
        List<string> tempPartecipanti = new List<string>(partecipanti);
        Random random = new Random();
        while (tempPartecipanti.Count > 0)
        {
            int indice = random.Next(tempPartecipanti.Count);
            string partecipante = tempPartecipanti[indice];
            tempPartecipanti.RemoveAt(indice);
            if (squadra1Random.Count < squadra2Random.Count)
            {
                squadra1Random.Add(partecipante);
            }
            else
            {
                squadra2Random.Add(partecipante);
            }
        }
        Console.WriteLine("Squadra 1:");
        foreach (string partecipante in squadra1Random)
        {
            Console.WriteLine(partecipante);
        }
        Console.WriteLine("Squadra 2:");
        foreach (string partecipante in squadra2Random)
        {
            Console.WriteLine(partecipante);
        }
    }
}

```

# FUNZIONI VALORI RITORNO

In C#, una funzione può restituire un valore di qualsiasi tipo specificato. Questo valore può essere utilizzato per passare informazioni dal metodo chiamato al metodo chiamante. Ad esempio, una funzione che calcola la somma di due numeri potrebbe restituire il risultato della somma come valore di ritorno.

Ecco un esempio di una funzione che restituisce un valore:

```csharp\\\\\\
class Program
{
    static void Main()
    {
        int risultato = Somma(3, 4);
        Console.WriteLine($"La somma è: {risultato}");
    }

    static int Somma(int a, int b)
    {
        return a + b;
    }
}
```

In questo esempio, la funzione Somma prende due parametri interi a e b e restituisce la loro somma come risultato. Il risultato viene quindi assegnato a una variabile risultato e stampato sulla console.

**Valori di ritorno multipli**

In C#, una funzione può restituire solo un valore. Tuttavia, è possibile restituire più di un valore combinando i valori in una struttura di dati complessa, come un array, una lista o un oggetto personalizzato.

Ecco un esempio di una funzione che restituisce più valori utilizzando una tupla:

```csharp
class Program
{
    static void Main()
    {
        int[] numeri = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
        (int minimo, int massimo) risultato = CalcolaMinMax(numeri);
        Console.WriteLine($"Valore minimo: {risultato.minimo}");
        Console.WriteLine($"Valore massimo: {risultato.massimo}");
    }

    static (int, int) CalcolaMinMax(int[] numeri)
    {
        int minimo = numeri.Min();
        int massimo = numeri.Max();
        return (minimo, massimo);
    }
}
```

In questo esempio, la funzione CalcolaMinMax prende un array di numeri e restituisce il valore minimo e massimo come una tupla. I valori restituiti vengono quindi assegnati a una variabile risultato e stampati sulla console.

**Valori di ritorno opzionali**

In C#, è possibile specificare che una funzione non restituisce alcun valore utilizzando la parola chiave void. Tuttavia, è anche possibile specificare che una funzione restituisce un valore opzionale utilizzando la parola chiave nullable ?.

Ecco un esempio di una funzione che restituisce un valore opzionale:

```csharp
class Program
{
    static void Main()
    {
        int? risultato = Dividi(10, 2); // Restituisce 5
        if (risultato.HasValue) // Controlla se il valore è presente
        {
            Console.WriteLine($"Il risultato è: {risultato.Value}");
        }
        else
        {
            Console.WriteLine("Divisione per zero");
        }
    }

    static int? Dividi(int a, int b)
    {
        if (b == 0) // Divisione per zero
        {
            return null; // Valore opzionale
        }
        return a / b; // Divisione
    }
}
```

In questo esempio, la funzione Dividi prende due parametri interi a e b e restituisce il risultato della divisione a / b come un valore opzionale. Se b è uguale a zero, la funzione restituisce null per indicare una divisione per zero. Il valore restituito viene quindi assegnato a una variabile risultato e stampato sulla console.

# FUNZIONI PARAMETRI

La differenza fra valori ed parametri è che i valori sono i dati che vengono passati a una funzione, mentre i parametri sono le variabili che vengono utilizzate per ricevere quei dati.

In C#, una funzione può accettare uno o più parametri che vengono passati al momento della chiamata. I parametri sono utilizzati per passare informazioni alla funzione in modo che possa eseguire operazioni specifiche su quei dati.

Ecco un esempio di una funzione con parametri:

```csharp
class Program
{
    static void Main()
    {
        Saluta("Mondo");
    }

    static void Saluta(string nome)
    {
        Console.WriteLine($"Ciao, {nome}!");
    }
}
```

In questo esemppio, la funzione Saluta prende un parametro stringa nome e stampa un messaggio di saluto personalizzato utilizzando quel nome. Il parametro nome viene passato alla funzione al momento della chiamata.

**Parametri opzionali**

In C#, è possibile specificare che un parametro è opzionale utilizzando il modificatore di parametro opzionale ? e fornendo un valore predefinito per quel parametro. Gli argomenti per i parametri opzionali possono essere omessi al momento della chiamata, e verrà utilizzato il valore predefinito.

Ecco un esempio di una funzione con parametri opzionali:

```csharp
class Program
{
    static void Main()
    {
        Saluta("Mondo");
        Saluta("Mondo", "Ciao");
    }

    static void Saluta(string nome, string saluto = "Ciao")
    {
        Console.WriteLine($"{saluto}, {nome}!");
    }
}
```

In questo esempio, la funzione Saluta prende due parametri stringa nome e saluto, con saluto come parametro opzionale con il valore predefinito "Ciao". La funzione stampa un messaggio di saluto personalizzato utilizzando il nome e il saluto forniti.

**Parametri di output**

In C#, è possibile utilizzare il modificatore di parametro out per passare un parametro per riferimento e restituire un valore dalla funzione. Il parametro out deve essere inizializzato all'interno della funzione prima di restituire un valore.

Ecco un esempio di una funzione con un parametro di output:

```csharp
class Program
{
    static void Main()
    {
        int risultato;
        Somma(3, 4, out risultato);
        Console.WriteLine($"La somma è: {risultato}");
    }

    static void Somma(int a, int b, out int risultato)
    {
        risultato = a + b;
    }
}
```

In questo esempio, la funzione Somma prende due parametri interi a e b e restituisce la loro somma come un parametro di output risultato. Il parametro risultato deve essere dichiarato come out al momento della chiamata per indicare che verrà restituito un valore dalla funzione.

**Parametri ref**

In C#, è possibile utilizzare il modificatore di parametro ref per passare un parametro per riferimento e modificare il valore del parametro all'interno della funzione. Il parametro ref deve essere inizializzato al momento della chiamata.

Ecco un esempio di una funzione con un parametro ref:

```csharp
class Program
{
    static void Main()
    {
        int valore = 10;
        Incrementa(ref valore);
        Console.WriteLine($"Il valore è: {valore}");
    }

    static void Incrementa(ref int valore)
    {
        valore++;
    }
}
```

In questo esempio, la funzione Incrementa prende un parametro intero valore e incrementa il valore di 1. Il parametro valore deve essere dichiarato come ref al momento della chiamata per indicare che verrà modificato all'interno della funzione.

# FUNZIONI PARAMETRI DEFAULT

Funzione che implementa funzionalità al console readline

```csharp
class Program
{
    static void Main()
    {
        string nome = LeggiStringa("Inserisci il tuo nome: ");
        int eta = LeggiIntero("Inserisci la tua età: ");
        Console.WriteLine($"Ciao, {nome}! Hai {eta} anni.");
    }

    static string LeggiStringa(string messaggio)
    {
        Console.Write(messaggio);
        return Console.ReadLine();
    }

    static int LeggiIntero(string messaggio)
    {
        Console.Write(messaggio);
        return Convert.ToInt32(Console.ReadLine());
    }
}
```

In questo esempio, la funzione LeggiStringa prende un parametro stringa messaggio e stampa il messaggio sulla console, quindi restituisce la stringa inserita dall'utente. La funzione LeggiIntero prende un parametro stringa messaggio e stampa il messaggio sulla console, quindi restituisce l'intero inserito dall'utente.

Funzione che implementa funzionalità al console in modo da evitare gli errori di inserimento 

```csharp
class Program
{
    static void Main()
    {
        string nome = LeggiStringa("Inserisci il tuo nome: ");
        int eta = LeggiIntero("Inserisci la tua età: ");
        Console.WriteLine($"Ciao, {nome}! Hai {eta} anni.");
    }

    static string LeggiStringa(string messaggio)
    {
        Console.Write(messaggio);
        return Console.ReadLine();
    }

    static int LeggiIntero(string messaggio)
    {
        int valore;
        bool successo;
        do
        {
            Console.Write(messaggio);
            successo = int.TryParse(Console.ReadLine(), out valore);
            if (!successo)
            {
                Console.WriteLine("Inserimento non valido. Riprova.");
            }
        } while (!successo);
        return valore;
    }
}
```

In questo esempio, la funzione LeggiIntero utilizza un ciclo do-while per continuare a richiedere all'utente di inserire un intero finché l'input non è valido. La funzione int.TryParse viene utilizzata per convertire l'input dell'utente in un intero e restituire true se la conversione ha successo, altrimenti restituisce false.