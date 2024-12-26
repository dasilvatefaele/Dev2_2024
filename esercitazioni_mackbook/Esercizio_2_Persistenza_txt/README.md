# SALVA I NOMI PER LE NEO-MAMME
**( !!! aprimi con l'anteprima !!! )**
```


    Questo è un programma per le neo-mamme!
    Le neo-mamme hanno in mente tanti nomi da dare ai propri bimbi, e questa app
    le aiuterà a scegliere!


    versione 1:

    1. CHIEDI ALLA NEO MAMMA COME SI CHIAMA 
        - salva il nome in una variabile 

    2. CHIEDI SU QUANTI NOMI E' INDECISA
        - salva il numero in una variabile 

    2. FALLE INSERIRE I NOMI
        - usa il numero dentro il ciclo for per farle inserire i nomi su cui è indecisa
        - salva il nome in una variabile
        - aggiungi la variabile ad una lista col metodo .Add

    3. SALVA I NOMI SU UN FILE
        - crea un file chiamato come la Neo-Mamma 
        - salvaci dentro la lista dei nomi

```


<details>
<summary>Soluzione (NON APRIRMI SENZA PRIMA PROVARCI !! 😼) </summary>

































































```csharp
Console.Clear();
string nomeNeoMamma;
int numeroDiNomi;
string nomeIndeciso;
List<string> listaDeiNomiDelBimbo = new List<string>();

Console.WriteLine("Benvenuta NEO-MAMMA! Come ti chiami?");
nomeNeoMamma = Console.ReadLine();

Console.WriteLine($"Ciao {nomeNeoMamma}! Su quanti nomi sei indecisa?");
numeroDiNomi = int.Parse(Console.ReadLine());

Console.WriteLine($"Mmm... capisco, sei indecisa su {numeroDiNomi} nomi... Quali sono questi nomi?\n");

for (int i = 0; i < numeroDiNomi; i++)
{
    Console.Write("> ");
    nomeIndeciso = Console.ReadLine();
    listaDeiNomiDelBimbo.Add(nomeIndeciso);
}

Console.WriteLine($"Ricapitoliamo... i {numeroDiNomi} su cui sei indecisa sono:\n");
Console.WriteLine(string.Join(", ", listaDeiNomiDelBimbo));


Console.WriteLine("\nAllora te li mettiamo da parte in un file col tuo nome!;)\nPremi un tasto per procedere...");
Console.ReadKey();

string archivioNeoMamma = $@"I nomi per il bimbo di {nomeNeoMamma}.txt";
File.Create(archivioNeoMamma).Close();

File.AppendAllLines(archivioNeoMamma, listaDeiNomiDelBimbo);

Console.WriteLine($"Fatto! {nomeNeoMamma}! Controlla la cartella! Lierremo da parte per te! <3\n");
```