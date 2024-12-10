#### VERSIONE 1
```c#
class Program
{
    static void Main(string[] args)  // <--- Entry Point:  da dove il programma INIZIA ad eseguire le istruzioni
    {
        // Creazione dell'oggetto 'primoPokemon', che è della classe Pokemon
        Pokemon primoPokemon = new Pokemon();

        Console.WriteLine($"{primoPokemon.Nome} usa {primoPokemon.Attacco}!");
        // in questo caso stampa: "Pikachu usa Elettroshock!"
        // Attraverso il '.' andiamo a leggere i dati PUBBLICI (public) della classe Pokemon.

        // ciò che è pubblico può essere modificato nel Main
        // esempio:
        primoPokemon.Attacco = "Azione";
        // Ho modificato la variabile "Attacco" dell'oggetto primoPokemon
        // "Attacco" essendo public è modificabile anche dal main

        Console.WriteLine($"{primoPokemon.Nome} usa {primoPokemon.Attacco}!");
        // in questo caso stampa: "Pikachu usa Azione!" perché l'ho modificato

        // ipotiziamo che un hacker voglia hackerare il suo Pikachu 
        // facendogli saltare tutti i livelli e sovrascrivendogli livello = 100;

        Console.WriteLine($"il tuo {primoPokemon.Nome} è di livello {primoPokemon.Livello}.");
        // NOTA BENE: ho usato Livello con la L maiuscola perché è pubblic
        // quando richiesta una lettura come in questo caso, attraverso 'get {return livello;}' restituisce il valore della variabile privata

        // Console.WriteLine($"il tuo {primoPokemon.Nome} è di livello {primoPokemon.livello}."); // (Commenta/scommenta questa linea di codice)
        // NOTA BENE: la linea di codice sopra da errore, perché sebbene 'livello' con la L minuscola esista
        // è PRIVATA, quindi ci si può accedere dal Main! 


        // primoPokemon.livello = 100; // (Commenta/scommenta questa linea di codice)
        // NOTA BENE: La linea di codice qua sopra da errore perché
        // non possiamo sovrascrivergli 100 dal momento che è privata

        // Per intermediare con la variabile privata usiamo la sua versione pubblica
        // che in questo caso ha la L maiuscola

        primoPokemon.Livello = 100;
        // NOTA BENE: posso provare a sovrascriverglielo attraverso la variabile pubblica
        // verrà eseguito il blocco di codice 'set{}' che in questo caso
        // ha un controllo per verificare che non si saltino livelli
        // siccome il livello precedente era 36
        // non trasferirà 100 nella varibile privata e stamperà
        // "Pikachu non può saltare livelli!"

        Console.WriteLine($"il tuo {primoPokemon.Nome} è ancora di livello {primoPokemon.Livello}."); // 36

        primoPokemon.Livello = 37;
    }
}

public class Pokemon // <--- Definizione della classe Pokemon
{
    //
    public string Nome = "Pikachu";
    public string Attacco = "Elettroshock";
    private int livello = 36; // !100 

    // 'public int Livello'  mi permette di portare il dato privato "private int livello = 36" all'esterno, ecco come:
    public int Livello
    {
        get { return livello; }
        // GET: viene eseguito quando nel main voglio solo leggere il livello primoPokemon.Livello (con la L maiuscola)  contiene il blocco di codice che ritorna 36 (return livello) 
        // SET: quando cerco di scriverci sopra, uso
        set
        {
            if (value == livello + 1) // 37
            {
                livello = value;
                Console.WriteLine($"{Nome} è salito al livello {livello}");
                // la variabile 'livello' privata qui la posso usare, perché sono dentro la classe!
                // mentre nel main, giustamente, mi dava errore
            }
            else
            {
                Console.WriteLine($"{Nome} non può saltare livelli!");
            }
        }
    }
}
```

#### VERSIONE CON LE FUNZIONI
```C#
class Program
{
    static void Main(string[] args)  // <--- Entry Point:  da dove il programma INIZIA ad eseguire le istruzioni
    {
        // Creazione dell'oggetto 'primoPokemon', che è della classe Pokemon
        Pokemon primoPokemon = new Pokemon();

        Console.WriteLine($"{primoPokemon.Nome} usa {primoPokemon.Attacco}!");
        primoPokemon.Attacco = "Azione";

        Console.WriteLine($"{primoPokemon.Nome} usa {primoPokemon.Attacco}!");
        Console.WriteLine($"il tuo {primoPokemon.Nome} è di livello {primoPokemon.Livello}.");

        primoPokemon.Livello = 100;

        Console.WriteLine($"il tuo {primoPokemon.Nome} è ancora di livello {primoPokemon.Livello}."); // 36

        primoPokemon.Livello = 37;

        Console.WriteLine($"Come vuoi chiamare il tuo {primoPokemon.Nome}?");
        string pokemonRinominato = Console.ReadLine();

        RinominaPokemon(pokemonRinominato, primoPokemon);
        Console.WriteLine($"Ora il tuo Pokemon si chiama {primoPokemon.Nome}");


        int quandoSiEvolve = ProssimaEvoluzione();
        Console.WriteLine($"{primoPokemon.Nome} si evolverà quando raggiungerà il livello {quandoSiEvolve}");

        void RinominaPokemon(string nuovoNome, Pokemon pokemon)
        {
            pokemon.Nome = nuovoNome;
        }

        int ProssimaEvoluzione()
        {
            int livelloEvoluzione = 48;
            return livelloEvoluzione;
        }

    }
}

public class Pokemon
{

    public string Nome = "Pikachu";
    public string Attacco = "Elettroshock";
    private int livello = 36;

    public int Livello
    {
        get { return livello; }
        set
        {
            if (value == livello + 1) // 37
            {
                livello = value;
                Console.WriteLine($"{Nome} è salito al livello {livello}");
            }
            else
            {
                Console.WriteLine($"{Nome} non può saltare livelli!");
            }
        }
    }
}
```

#### VERSIONE CON I METODI
```C#
class Program
{
    static void Main(string[] args)  // <--- Entry Point:  da dove il programma INIZIA ad eseguire le istruzioni
    {
        // Creazione dell'oggetto 'primoPokemon', che è della classe Pokemon
        Pokemon primoPokemon = new Pokemon();

        Console.WriteLine($"{primoPokemon.Nome} usa {primoPokemon.Attacco}!");
        primoPokemon.Attacco = "Azione";

        Console.WriteLine($"{primoPokemon.Nome} usa {primoPokemon.Attacco}!");
        Console.WriteLine($"il tuo {primoPokemon.Nome} è di livello {primoPokemon.Livello}.");

        primoPokemon.Livello = 100;

        Console.WriteLine($"il tuo {primoPokemon.Nome} è ancora di livello {primoPokemon.Livello}."); // 36

        primoPokemon.Livello = 37;

        Console.WriteLine($"Come vuoi chiamare il tuo {primoPokemon.Nome}?");
        string pokemonRinominato = Console.ReadLine();

        primoPokemon.RinominaPokemon(pokemonRinominato);
        Console.WriteLine($"Ora il tuo Pokemon si chiama {primoPokemon.Nome}");


        int quandoSiEvolve = primoPokemon.ProssimaEvoluzione();
        Console.WriteLine($"{primoPokemon.Nome} si evolverà quando raggiungerà il livello {quandoSiEvolve}");
    }
}

public class Pokemon
{

    public string Nome = "Pikachu";
    public string Attacco = "Elettroshock";
    private int livello = 36;

    public int Livello
    {
        get { return livello; }
        set
        {
            if (value == livello + 1) // 37
            {
                livello = value;
                Console.WriteLine($"{Nome} è salito al livello {livello}");
            }
            else
            {
                Console.WriteLine($"{Nome} non può saltare livelli!");
            }
        }
    }

    public void RinominaPokemon(string nuovoNome)
    {
        Nome = nuovoNome;
    }


    public int ProssimaEvoluzione()
    {
        int livelloEvoluzione = 48;
        return livelloEvoluzione;
    }

}
```