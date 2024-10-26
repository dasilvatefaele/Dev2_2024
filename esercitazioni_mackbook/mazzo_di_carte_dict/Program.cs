using System.Collections;
using System.Dynamic;

void CustomDebug(){
    Console.WriteLine("CustomDebug: Premi per continuare l'esecuzione...");
 //   Console.ReadKey();
    return;
}

Dictionary<int,string> diCuori = new Dictionary<int,string>();
Dictionary<int,string> diDenari = new Dictionary<int,string>();
Dictionary<int,string> diPicche = new Dictionary<int,string>();
Dictionary<int,string> diFiori = new Dictionary<int,string>();
List<Dictionary<int,string>> mazzoDiCarte = new List<Dictionary<int,string>>();

Console.Clear();

//inizializzazione array carte
int[] numCarte = new int[13];
for (int i = 1; i <= 13; i++){
    numCarte[i-1] = i;
}
// Console.WriteLine(string.Join(", ", numCarte)); // Verifico inserimento valore carte (riuscito)

// Inizializzazione per ogni seme
foreach (int num in numCarte){
    diCuori.Add(num, "di Cuori");
}

foreach (int num in numCarte){
    diDenari.Add(num, "di Denari");
}

foreach (int num in numCarte){
    diPicche.Add(num, "di Picche");
}

foreach (int num in numCarte){
    diFiori.Add(num, "di Fiori");
}

// Inizializzazione Lista mazzoDiCarte
mazzoDiCarte.Add(diCuori);
mazzoDiCarte.Add(diFiori);
mazzoDiCarte.Add(diDenari);
mazzoDiCarte.Add(diPicche);

// Verifico presenza delle carte in mazzoDiCarte // riuscito
/*

foreach (var seme in mazzoDiCarte){
    foreach (var carta in seme){
        Console.WriteLine($"{carta.Key} {carta.Value}");
    }
}
*/

CustomDebug();

int totCarte = 53;
int contatoreMazzo = 1; // da incrementare dentro il ciclo
Random random = new Random();
int pescaRandom;

List<Dictionary<int,string>> manoGiocatore = new List<Dictionary<int,string>>(){};
Dictionary<int,string> mano = new Dictionary<int,string>();
string comando; 

do{
    pescaRandom = random.Next(1,totCarte); // da 1 a 52
    contatoreMazzo = 1;
    Console.WriteLine("Pesca una carta...");
    //Console.ReadKey();

    foreach (var seme in mazzoDiCarte){
        foreach (var carta in seme){
            if (contatoreMazzo == pescaRandom){
                mano.Add(carta.Key, carta.Value);
                manoGiocatore.Clear();
                manoGiocatore.Add(mano);  
                seme.Remove(carta.Key);
                totCarte--;
                break;
            }
            
            contatoreMazzo++;
        }
        if (contatoreMazzo == pescaRandom){break;}
    }

    Console.WriteLine("*** La tua mano: ***");
    
    foreach (var seme in manoGiocatore){
        foreach (var cartaInMano in seme){
            Console.WriteLine($"{cartaInMano.Key} {cartaInMano.Value}");
        }
    }


    Console.WriteLine("*** Il mazzo: ***");
    foreach (var seme in mazzoDiCarte){
        foreach (var carta in seme){
            Console.Write($"{carta.Key} {carta.Value}\t");
        }
        Console.WriteLine("\n");
    }
    /*
    .
    .
    .
    */
    Console.WriteLine("Debug Data *************");
    Console.WriteLine($"Carte nel mazzo: {totCarte-1}");
    Console.WriteLine("Debug Data *************");
    Console.WriteLine("Continui?");
    comando = Console.ReadLine();
    comando = comando.ToUpper();

}while(comando != "EXIT");