using System.Text.Json.Nodes;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        var catalogo = LoadChaves();

        Console.WriteLine($"{catalogo.Count}");
        bool run = true;

        while (run)
        {
            Menu();

            if (Escolha() == '0')
            {
                run = Exit();
            }
            else
            {
                ProcuraPorID(catalogo);
            }
        }




    }
public static bool Exit()
{
    Console.Clear();
                    Color.DarkGray();
                    Console.WriteLine("© 2025 GOLD DIGITAL CATALOGUE for NEGUEHT by TEFHAEL");
                    Color.Reset();
                    Thread.Sleep(1000);
                    return false;
}
    public static List<Chave> LoadChaves()
    {
        string path = @"Data/chaves_list.json";
        var json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<Chave>>(json);
    }
    public static void Menu()
    {
        Header();
        Console.WriteLine("\nBUSCA A PAGINA ESCREVENDO O ID");
        Color.DarkGray();
        Console.WriteLine("0. Exit\n");
        Color.Reset();
    }

    public static char Escolha()
    {
        Color.DarkGray();
        Console.WriteLine("Pressione uma tecla para continuar.\n");
        Color.Reset();
        return Console.ReadKey(true).KeyChar;
    }

    public static void ProcuraPorID(List<Chave> catalogo)
    {
        Console.Clear();
        Header();
        var input = InputManager.LeggiStringa("\nID DA CHAVE > ");
        bool found = false;
        int count = 0;
        foreach (var chave in catalogo)
        {
            if (input == chave.Id)
            {
                found = true;
                if (count == 0)
                {
                    Color.Green();
                    Console.WriteLine($"\n{"PAGINA",-10}{"NOME",-30}{"ID",-10}{"CODIGO",-10}");
                    Color.Reset();
                    Console.WriteLine(new string('-', 60));
                    count++;
                }
                Console.WriteLine($"{chave.Pagina,-10}{chave.Nome,-30}{chave.Id,-10}{chave.Codigo,-10}");
            }
        }
        if (!found)
        {
            NotFound();
        }
        Console.WriteLine();
        Wait();
    }

    public static void Header()
    {
        Color.DarkYellow();
        Console.WriteLine("GOLD DIGITAL CATALOGUE");
        Console.WriteLine(new string('-', 22));
        Color.Reset();
    }

    public static void ProcuraPorCodigo(List<Chave> catalogo)
    {
        Console.Clear();
        Header();
        var input = InputManager.LeggiStringa("Codigo da chave: ");
        bool found = false;
        int count = 0;
        foreach (var chave in catalogo)
        {
            {
                found = true;
                if (count == 0)
                {
                    Console.WriteLine($"\n{"PAGINA",-10}{"NOME",-30} {"ID",-10} {"CODIGO",-10}");
                    Color.Green();
                    Console.WriteLine(new string('-', 60));
                    Color.Reset();
                    count++;
                }
                Console.WriteLine($"{chave.Pagina,-10}{chave.Nome,-30}{chave.Id,-10}{chave.Codigo,-10}");
            }
        }
        if (!found)
        {
            NotFound();
        }
        Console.WriteLine();
        Wait();
    }

    public static void NotFound()
    {
        Color.Red();
        Console.WriteLine("\nerror: CHAVE NAO ENCONTRADA\n");
        Color.Reset();
        Wait();
    }

    public static void Wait()
    {
        Color.DarkGray();
        Console.WriteLine("Pressione uma tecla para continuar.\n");
        Color.Reset();
        Console.ReadKey();
        Console.Clear();
    }
}

