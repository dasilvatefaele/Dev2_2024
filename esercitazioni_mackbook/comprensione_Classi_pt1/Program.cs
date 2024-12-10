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
        primoPokemon.RinominaPokemon("Pippo");

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
