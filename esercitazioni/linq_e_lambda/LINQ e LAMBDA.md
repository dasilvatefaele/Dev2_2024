# LINQ & LAMBDA

Funzionalità per scrivere query in modo conciso, 
e che funziona con tutte le strutture di dati , come liste, array, database ecc.

NOTA


---

## LINQ

Interamente tipizzato a tempo di compile-time (si usano il `var`, dunque non è neccessario il casting).

In C# interagisce molto bene con EntityFramework, perché semplifica le query.


## LAMBDA EXPRESSIONS


> SENZA LAMBDA
```cs
List <int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
List <int> numeriPari = new List<int>();

foreach (var numero in lista)
{
    if (numero % 2 == 0)
    {
        numeriPari.Add(numero);
    }
}

foreach (var numero in numeriPari)
{
    Console.WriteLine(numero);
}
```

---

> CON LINQ
```cs
List <int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var numPari = from n in lista       // Definiamo la query
              where n % 2 == 0      // Filtriamo i numeri pari
              select n;             // Selezioniamo i numeri che soddisfano la condizione
                                    // n è il nome della variabile che rappresenta l'elemento corrente
foreach (var numero in numPari)
{
    Console.WriteLine(numero);      // Stampa i numeri
}
```

---

> CON LINQ & LAMBDA
```cs
List <int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var numPari = from n in lista       
              where n % 2 == 0      
              select n;                                     
numPari.ToList().ForEach(n => Console.WriteLine(n));    // convertiamo IEnumerable in List per 
                                                        // usare il metodo ForEach 
                                                        // dove => è loperatore LAMBDA (cioè funzione anonima) 
                                                        // n è l'elemento corrente
                                                        // e Console.WriteLine(n); è il corpo della funzione 
```

---
> CON LINQ & LAMBDA avanzato
```cs
List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var numPari = lista.Where(n => n % 2 == 0).ToList();
numPari.ForEach(n => Console.WriteLine(n));
```

Metodi ricorrenti:

`Where()` - filtra gli elementi che soddisfano la condizione

`select()` - seleziona gli elementi che soddisfano la condizione

`ToList()` - converte il risultato in una lista

`ForEach()` - esegue un'azione per ogni elemento della lista

---  

> CON LINQ & LAMBDA combinate 

```cs
List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
lista.Where(n => n % 2 == 0).ToList().ForEach(n => Console.WriteLine(n));
```

---

# Filtrare una lista di oggetti

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

// filtro e salvo in una variabile 
var personeFiltrate = persone.Where(p => p.Eta > 30);

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```

> oppure filtro e stampo senza salvare la lista in una variabile 

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

// stampo i filtrati
persone.Where(p => p.Eta > 30).ToList().ForEach(p => Console.WriteLine($"{p.Nome} - {p.Eta}"));

var ordinatiPerEta = persone.OrderBy(p => p.Eta).ToList();

Console.WriteLine("Ordinati per età");
ordinatiPerEta.ForEach(p => Console.WriteLine($"{p.Nome} - {p.Eta}"));


// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}

// ordinati per età

```


# Order By (ordine crescente-decrescente)

> altro esempio

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

var nomi = persone.Where(p => p.Eta > 25)   // filtriamo le persone con età maggiore di 25
                .OrderBy(p => p.Nome)       // ordiniamo per nome
                .Select(p => p.Nome)        // selezioniamo solo il nome
                .ToList();                  // trasformiamo in lista

nomi.ForEach(n => Console.WriteLine(n));    // stampiamo i nomi

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```


```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

var nomi = persone.Where(p => p.Eta > 25)               // filtriamo le persone con età maggiore di 25
                .OrderByDescending(p => p.Nome)         // ordiniamo per nome (decrescente)
                .Select(p => p.Nome)                    // selezioniamo solo il nome
                .ToList();                              // trasformiamo in lista

nomi.ForEach(n => Console.WriteLine(n));                // stampiamo i nomi

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```

---

> Contare numero di elementi (normale)

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

int conteggio = persone.Count();

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}

```

> Contare numero di elementi (con LINQ e LAMBDA)

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Pietro", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

var conteggio = (from p in persone select p).Count();

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```

> raggruppo per età

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Pietro", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

var stessaEta = persone.GroupBy(p => p.Eta).ToList();

stessaEta.ForEach(p => Console.WriteLine($"Età: {p.Key} Persone: {p.Count()} {string.Join(", ", p.Select(x => x.Nome))}"));

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```

output:

```powershell
Età: 20 Persone: 1 Mario
Età: 30 Persone: 2 Luigi, Pietro
Età: 40 Persone: 1 Paolo
Età: 50 Persone: 1 Giovanni
Età: 60 Persone: 1 Andrea
```

---

# .Take(), .Skip()

```cs
// creo una lista di persone 
var persone = new List<Persona>
{
    new Persona { Nome = "Mario", Eta = 20 },
    new Persona { Nome = "Luigi", Eta = 30 },
    new Persona { Nome = "Pietro", Eta = 30 },
    new Persona { Nome = "Paolo", Eta = 40 },
    new Persona { Nome = "Giovanni", Eta = 50 },
    new Persona { Nome = "Andrea", Eta = 60 }
};

// prende i primi due
Console.WriteLine("I primi due: ");
var primiDue = (from p in persone select p).Take(2);
primiDue.ToList().ForEach(p => Console.WriteLine(p.Nome));

// esclude i primi due
Console.WriteLine("\nEscludendo i primi due: ");
var esclusi = (from p in persone select p).Skip(2);
esclusi.ToList().ForEach(p => Console.WriteLine(p.Nome));

// definisco una classe Persona
class Persona
{
    public string Nome { get; set; }
    public int Eta { get; set; }
}
```

>output: 
```powershell
I primi due: 
Mario
Luigi
Escludendi i primi due:
Pietro
Paolo
Giovanni
Andrea
```

---

# Join

```cs
var ordini = new List<Ordine> 
{
    new Ordine { ClienteId = 1, Prodotto = "Laptop"},
    new Ordine { ClienteId = 2, Prodotto = "Smartphone"}
};

var clienti = new List<Cliente>
{
    new Cliente { Id = 1 , Nome = "Carlo"},
    new Cliente { Id = 2 , Nome = "Filippo"},
};

var joinQuery = from c in clienti
                join o in ordini
                on c.Id equals o.ClienteId
                select new { Cliente = c.Nome, Prodotto = o.Prodotto };

joinQuery.ToList().ForEach(j => Console.WriteLine($"{j.Cliente} ha acquistato un {j.Prodotto}"));

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

class Ordine
{
    public int ClienteId { get; set; }
    public string Prodotto { get; set; }
}
```
> output 
```
Carlo ha acquistato un Laptop
Filippo ha acquistato un Smartphone
```

> oppure (stesso risultato)

```cs
var ordini = new List<Ordine> 
{
    new Ordine { ClienteId = 1, Prodotto = "Laptop"},
    new Ordine { ClienteId = 2, Prodotto = "Smartphone"}
};

var clienti = new List<Cliente>
{
    new Cliente { Id = 1 , Nome = "Carlo"},
    new Cliente { Id = 2 , Nome = "Filippo"},
};

var joinQueryAlt = clienti.Join(
    ordini, 
    c => c.Id,
    o => o.ClienteId,
    (c, o) => new { Cliente = c.Nome, Prodotto = o.Prodotto });

joinQueryAlt.ToList().ForEach(j => Console.WriteLine($"{j.Cliente} ha acquistato un {j.Prodotto}"));

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

class Ordine
{
    public int ClienteId { get; set; }
    public string Prodotto { get; set; }
}
```
---

> output 
```
Carlo ha acquistato un Laptop
Filippo ha acquistato un Smartphone
```

