// todo: ************ SIMULAZIONE SUPERMERCATO Versione 3 ************

using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.Win32;
using Newtonsoft.Json;
Console.Clear();

//* ------------------------------------------------------------------
//* ------------------------------ MAIN ------------------------------
//* ------------------------------------------------------------------

#region DICHIARAZIONE VARIABILI

int     scelta = -1;
bool    continua = true;
bool    convertito;
bool    disponibile;
double  somma = 0;
string  prodottoDaCercare;
string  passwordAdmin       = "admin";
string  pathCatalogoMain    = @"catalogo supermercato.json";
string  pathCarrelloUser    = @"carrello Utente.json";
string  dirProdotti         = @"ADMIN dir";
string  dirFatture          = @"ADMIN fatture";
string  pathRegistro        = @"registro fatture.json";


var carrello        = new Dictionary<string, double[]>();
var carrelloSalvato = new List<dynamic>();

#endregion

#region MAIN

if (!Directory.Exists(dirProdotti))
{
    Directory.CreateDirectory(dirProdotti);
}

if (!Directory.Exists(dirFatture))
{
    Directory.CreateDirectory(dirFatture);
}

pathCatalogoMain = Path.Combine(dirProdotti, pathCatalogoMain);
pathCarrelloUser = Path.Combine(dirProdotti, pathCarrelloUser);
pathRegistro     = Path.Combine(dirFatture, pathRegistro);

while (continua)                                                        // MAIN LOOP {
{
    Console.WriteLine("\n-------------- MENU ---------------");
    Console.WriteLine("1. Visualizza i prodotti");
    Console.WriteLine("2. Cerca un prodotto");
    Console.WriteLine("3. Aggiungi un prodotto al carello");
    Console.WriteLine("4. Rimuovi un prodotto dal carrello");
    Console.WriteLine("5. Visualizza il carrello");
    Console.WriteLine("6. Procedi al pagamento");
    Console.WriteLine("7. ADMIN MODE");
    Console.WriteLine("0. Esci\n");

    scelta = NumberInRange(0, 7);

    Console.Clear();

    //switch Menu
    switch (scelta)
    {
        case 1:
            Console.WriteLine("-------- COOP: I Nostri Prodotti ---------");
            VisualizzaProdottiComeUSER(pathCatalogoMain);
            break;
        case 2:
            Console.WriteLine("---------- COOP: CERCA PRODOTTO ----------");
            CercaProdotto();
            break;
        case 3:
            Console.WriteLine("-------- COOP: I Nostri Prodotti ---------");
            AggiungiAlCarrello();
            break;
        case 4:
            Console.WriteLine("---------- RIMUOVI DAL CARRELLO ----------");
            RimuoviDalCarrello();
            break;
        case 5:
            Console.WriteLine("------------- IL TUO CARRELLO -------------");
            VisualizzaCarrello(pathCarrelloUser, ref somma);
            break;
        case 6:
            continua = ProcediAlPagamento();
            break;
        case 7:

            // verifica se operatore
            Console.Write("Inserisci il tuo Codice Operatore > ");
            string inputPassword = Console.ReadLine();
            if (inputPassword == passwordAdmin)
            {
                AdminMode();
            }
            else
            {
                Console.WriteLine("ATTENZIONE: Non hai i permessi per accedere.\n");
            }
            break;

        case 0:

            continua = Esci();
            break;

        default:
        
            Console.WriteLine("Opzione non valida");
            break;
    }

}                                                                       // MAIN LOOP }

// dialogo finale
Console.WriteLine("\nArrivederci!\n");

#endregion

//* ------------------------------------------------------------------
//* ------------------------------ USER ------------------------------
//* ------------------------------------------------------------------

#region USER

void VisualizzaProdottiComeUSER(string link)
{
    dynamic jsonDeserializzato = DeserializzaJSON(link);

    foreach (var item in jsonDeserializzato)
    {
        Console.WriteLine($"=====================================");
        Console.WriteLine($"NOME PRODOTTO:\t\t{item.NomeProdotto}");
        Console.WriteLine($"PREZZO:\t\t\t€{item.Prezzo}");
    }
    Console.WriteLine($"------------------------------------------");
}

void CercaProdotto()
{
    // converto in una lista dinamica 
    dynamic jsonDeserializzato = DeserializzaJSON(pathCatalogoMain);
    List<dynamic> catalogoDes = jsonDeserializzato.ToObject<List<dynamic>>();
    //---------------------------------------------------------------------------

    bool trovato = false; 
    // controlla se ha trovato o meno l'articolo
    Console.Write("> ");
    string prodottoDaAggiungere;
    prodottoDaAggiungere = Console.ReadLine();
    prodottoDaAggiungere = prodottoDaAggiungere.ToUpper();

    // cerco corrispondenza tra tutti gli item
    foreach (var item in catalogoDes)
    {
        if ((string)item.NomeProdotto.ToString() == prodottoDaAggiungere.ToString())
        {
            trovato = true;
            Console.WriteLine($"Prodotto trovato! Prezzo {item.Prezzo} - Vuoi acquistare? [s/n]");
            string scelta = Inserimentofrase();
            scelta = scelta.ToLower();
            switch (scelta)
            {
                case "s":
                    SpostoItem(prodottoDaAggiungere);
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Inserimento non valido");
                    Console.WriteLine($"(premi un tasto per uscire...)");
                    Console.ReadKey();
                    Console.Clear();
                break;
            }
        }
    }
    //---------------------------------------------------------------------------------

    if (trovato == false)
    {
        Console.WriteLine($"'{prodottoDaAggiungere}': prodotto non trovato!");
        Console.WriteLine($"(premi un tasto per uscire...)");
        Console.ReadKey();
        Console.Clear();
    }
}

void AggiungiAlCarrello()
{
    Console.WriteLine("--- AGGIUNGI AL CARRELLO ---");
    VisualizzaProdottiComeUSER(pathCatalogoMain);
    Console.Write("> ");
    string prodottoDaAggiungere;
    prodottoDaAggiungere = Console.ReadLine();
    prodottoDaAggiungere = prodottoDaAggiungere.ToUpper();

    SpostoItem (prodottoDaAggiungere);
}

void RimuoviDalCarrello()
{
    dynamic jsonDeserializzato = DeserializzaJSON(pathCarrelloUser);
    List<dynamic> localList = jsonDeserializzato.ToObject<List<dynamic>>();
    var newList = new List<dynamic>();
    bool trovato = false;
    VisualizzaProdottiComeUSER(pathCarrelloUser);
    Console.Write("Cosa elimini dal carrello? > ");
    string elimina = Inserimentofrase();
    elimina = elimina.ToUpper();

    foreach (var item in localList)
    {
        if (item.NomeProdotto != elimina)
        {
            newList.Add(item);
            trovato = true;
        }
    }

    if (trovato)
    {
        SerializzaJSON(newList, pathCarrelloUser);
    }

    if (!trovato)
    {
        Console.WriteLine("Attenzione: prodotto non trovato.");
        Console.WriteLine("Premi un tasto per tornare indietro...");
        Console.ReadKey();
    }
}

void VisualizzaCarrello(string link, ref double somma)
{
    dynamic jsonDeserializzato = DeserializzaJSON(pathCarrelloUser);
    List<dynamic> carrelloDes = jsonDeserializzato.ToObject<List<dynamic>>();
    somma = 0;

    foreach (var item in carrelloDes)
    {
        Console.WriteLine($"=====================================");
        Console.WriteLine($"NOME PRODOTTO:\t\t{item.NomeProdotto}");
        Console.WriteLine($"PREZZO:\t\t\t€{item.Prezzo}");
        Console.WriteLine($"QNT.:\t\t\tx{item.Quantita}");
        if (item.Quantita == 1)
            somma += (double)item.Prezzo;
        else if(item.Quantita >= 2)
        {
            somma = somma + (double)item.Prezzo*(double)item.Quantita;
        }
    }

    Console.WriteLine($"------------------------------------------");
    Console.WriteLine($"TOTALE:\t\t\t€{somma:f2}");
}

bool ProcediAlPagamento()
{
    Console.WriteLine("--------------------- CASSA ---------------------");
    VisualizzaCarrello(pathCarrelloUser, ref somma);

    Console.WriteLine("Premi un tasto per effettuare il pagamento");
    Console.ReadLine();
    Console.WriteLine($"*** Pagati:€{somma:f2} ***");
    Console.WriteLine("Grazie per aver acquistato da noi!");

    SalvaScontrino(pathCarrelloUser);


    return false;

}

bool Esci()
{
    bool continua = true;
    Console.WriteLine("\nSicuro di voler uscire?\n[1] Procedi al pagamento\n[2] Continua la spesa\n[3] Abbandona ed esci");
    int scelta = NumberInRange(1,3);

    switch (scelta)
    {
        case 1:
            return ProcediAlPagamento();
            break;
        case 2:
            return continua = true;
            break;
        case 3:
            return continua = false;
            break;
    }
    return true;
}

int NumberInRange(int min, int max)
{
    bool repeat = false;
    int num = 0;
// Console.Write($"Inserisci intero tra {min} e {max} ");
    do
    {
        do
        {
            repeat = false;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("#Errore: dato non corretto");
                repeat = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("#Errore: dato non corretto");
                repeat = true;
            }
        } while (repeat);

        if (num >= min && num <= max)
        {
//Console.WriteLine("*Numero nel range corretto*");
            return num;
        }
        else
        {
            Console.WriteLine("#Errore: numero fuori dal range");
            repeat = true;
        }
    } while (repeat);
    return -1;
}

double InputDouble()
{
    double numero = 0;
    bool repeat = false;
    string s_numero;
    do
    {
        repeat = false;

// Console.Write("Inserisci numero decimale > ");
        s_numero = Console.ReadLine();
        s_numero = s_numero.Replace(".", ",");

        try
        {
            numero = Convert.ToDouble(s_numero);
        }
        catch (Exception e)
        {
            Console.WriteLine("#Errore: dato non corretto");
            repeat = true;
        }
    } while (repeat);

    return numero;
}

string Inserimentofrase()
{
    string frase;
    frase = Console.ReadLine();
    bool ripeti = false;
    do
    {
        ripeti = string.IsNullOrWhiteSpace(frase);

        if (ripeti) 
        {
            // if true
            Console.WriteLine("#Errore: stringa vuota");
            frase = Console.ReadLine();
        }
        else
        {
            return frase;
        }
    } while (ripeti);
    return frase;
}

#endregion

//* ------------------------------------------------------------------
//* ------------------------------ ADMIN -----------------------------
//* ------------------------------------------------------------------

#region ADMIN

void AdminMode()
{
    int sceltaAdmin;

    do
    {
        Console.WriteLine("\n---------- ADMIN -----------");
        Console.WriteLine("\t- [CATALOGO] -");
        Console.WriteLine("1. VISUALIZZA CATALOGO");
        Console.WriteLine("2. AGGIUNGI PRODOTTO");
        Console.WriteLine("3. MODIFICA PRODOTTO");
        Console.WriteLine("4. ELIMINA PRODOTTO");
        Console.WriteLine("\t- [STORE] -");
        Console.WriteLine("5. VISUALIZZA SCONTRINI");
        Console.WriteLine("6. CALCOLA INCASSO");
        Console.WriteLine("0.\t [ ESCI ]\n");

        Console.Write("> ");
        sceltaAdmin = NumberInRange(0, 6);

        switch (sceltaAdmin)
        {
            case 1:
                Console.Clear();
                VisualizzaCatalogoADMIN();
                break;

            case 2:
                Console.Clear();
                AggiungiProdottoADMIN();
                break;

            case 3:
                Console.Clear();
                ModificaProdottoADMIN();
                break;

            case 4:
                Console.Clear();
                EliminaProdottoADMIN();
                break;

            case 5:
                //todo: visualizza scontrini
                break;

            case 6:
                //todo: calcola incasso
                break;

            case 0:
                //esci: 
                break;
        }
    } while (sceltaAdmin != 0);
}

void AggiungiProdottoADMIN()
{
// deserializzo catalogo e lo converto in una lista dinamica
    dynamic jsonDeserializzato = DeserializzaJSON(pathCatalogoMain);
    List<dynamic> catalogo = jsonDeserializzato.ToObject<List<dynamic>>();
//--------------------------------------------------------------------

    Console.WriteLine("--- ADMIN [ INSERISCI PRODOTTO ] ---");

    Console.Write("Nome Prodotto > ");
    string newProdotto = Console.ReadLine();
    newProdotto = newProdotto.ToUpper();

    Console.Write("Quantità > ");
    int newQuantita = NumberInRange(1, 10000);

    Console.Write("Prezzo > ");
    double newPrezzo = InputDouble();
 
// calcolo ID progressivo
    int ultimoID = 0;
    foreach (var item in catalogo)
    {

         ultimoID = item.ID;
    }

    int numeroID = ultimoID +1 ;
//----------------------------

//creo nuovo prodotto
    var newItem = new
    {
        ID = numeroID,
        NomeProdotto = newProdotto,
        Quantita = newQuantita,
        Prezzo = newPrezzo
    };
//----------------------------

// serializzo
    List<dynamic> localList = jsonDeserializzato.ToObject<List<dynamic>>();
    localList.Add(newItem);
    SerializzaJSON(localList, pathCatalogoMain);
}

void ModificaProdottoADMIN()
{
    dynamic jsonDeserializzato = DeserializzaJSON(pathCatalogoMain);
    Console.WriteLine("--- [ADMIN] : MODIFICA PRODOTTO ---");
    VisualizzaCatalogoADMIN();

    bool repeat = false;

    List<dynamic> prodottiEdit = jsonDeserializzato.ToObject<List<dynamic>>();

    do
    {
        Console.Write("Inserisci ID prodotto da editare > ");
        int editProdotto = NumberInRange(0,9999);
        // editProdotto = editProdotto.ToUpper();
        foreach (var item in prodottiEdit)
        {
            if (item.ID == editProdotto)
            {
                Console.WriteLine("Seleziona");
                Console.WriteLine("1. ID");
                Console.WriteLine("2. Nome Prodotto");
                Console.WriteLine("3. Quantita");
                Console.WriteLine("4. Prezzo");
                Console.WriteLine("5. Continua modifica");
                Console.WriteLine("0. Esci");
                Console.Write("> ");
                int scelta = NumberInRange(0, 5);
                switch (scelta)
                {
                    case 1:
                        Console.Write("nuovo ID > ");
                        item.ID = Inserimentofrase();
                        break;
                    case 2:
                        Console.Write("nuovo NOME PRODOTTO > ");
                        item.NomeProdotto = Inserimentofrase();
                        break;
                    case 3:
                        Console.WriteLine("nuova QUANTITA > ");
                        item.Quantita = NumberInRange(1, 10000);
                        break;
                    case 4:
                        Console.WriteLine("nuovo PREZZO > ");
                        item.Quantita = InputDouble();
                        break;
                    case 5:
                        repeat = true;
                        break;
                    case 0:
                        repeat = false;
                        Console.Clear();
                        continue;
                        break;
                }

            }
        }

    } while (repeat);

    SerializzaJSON(prodottiEdit, pathCatalogoMain);
}

void VisualizzaCatalogoADMIN()
{
    dynamic jsonDeserializzato = DeserializzaJSON(pathCatalogoMain);

    Console.WriteLine($"-------- [ CATALOGO ADMIN ] ---------");
    foreach (var item in jsonDeserializzato)
    {
        Console.WriteLine($"=====================================");
        Console.WriteLine($"ID:\t\t\t{item.ID}");
        Console.WriteLine($"NOME PRODOTTO:\t\t{item.NomeProdotto}");
        Console.WriteLine($"QUANTITA:\t\t{item.Quantita}");
        Console.WriteLine($"PREZZO:\t\t\t€{item.Prezzo}");
    }
    Console.WriteLine($"-------------------------------------");
}

void EliminaProdottoADMIN()
{
    dynamic jsonDeserializzato = DeserializzaJSON(pathCatalogoMain);
    List<dynamic> localList = jsonDeserializzato.ToObject<List<dynamic>>();
    var newList = new List<dynamic>();
    bool trovato = false;

    Console.Write("inserire ID da ELIMINARE> ");
    string elimina = Inserimentofrase();
    elimina = elimina.ToUpper();

    foreach (var item in localList)
    {
        if (item.ID != elimina)
        {
            newList.Add(item);
            trovato = true;
        }
    }

    if (trovato)
    {
        SerializzaJSON(newList, pathCatalogoMain);
    }
}

#endregion

//* ------------------------------------------------------------------
//* ------------------------------- JSON -----------------------------
//* ------------------------------------------------------------------

#region JSON

void SerializzaJSON(List<dynamic> list, string link)
{
    string item = JsonConvert.SerializeObject(list, Formatting.Indented);
    File.WriteAllText(link, item);
}

dynamic DeserializzaJSON(string pathCatalogoMain)
{
    string currentState = File.ReadAllText(pathCatalogoMain);
    dynamic jsonDeserializzato = JsonConvert.DeserializeObject(currentState)!;
    return jsonDeserializzato;
}

void SpostoItem (string prodottoDaAggiungere)
{
    dynamic catalogo = DeserializzaJSON(pathCatalogoMain);
    List<dynamic> catalogoLocale = catalogo.ToObject<List<dynamic>>();

    dynamic carrelloSalvato = DeserializzaJSON(pathCarrelloUser);
    List<dynamic> carelloDeserializzato = carrelloSalvato.ToObject<List<dynamic>>();

    bool trovato = false;

    foreach (var item in catalogoLocale)
    {
        if (item.NomeProdotto.ToString() == prodottoDaAggiungere)
        {
            Console.Write("Quantita > ");
            int quantita = NumberInRange (1,100);

            if (item.Quantita >= quantita)
            {
                int temp = item.Quantita;
                item.Quantita = quantita;
                carelloDeserializzato.Add(item);
                SerializzaJSON(carelloDeserializzato,pathCarrelloUser);
                item.Quantita = temp - quantita;
                SerializzaJSON(catalogoLocale,pathCatalogoMain);
                trovato = true;
                break;
            }
            else
            {
                Console.WriteLine($"Mi dispiace, la quantità non è disponibile. IN STOCK: {item.Quantita}");
                Console.WriteLine("Premi un tasto per uscire...");
                Console.ReadLine();
                trovato = true;
            }
        }
    }

    if (trovato == false)
    {
        Console.WriteLine($"Mi dispiace, '{prodottoDaAggiungere}' non trovato.");
        Console.WriteLine("Premi un tasto per tornare indietro...");
        Console.ReadKey();
    }
}

 void SalvaScontrino(string link)
{
    dynamic local = DeserializzaJSON(link);
    List<dynamic> scontrino = local.ToObject<List<dynamic>>();

    dynamic registro = DeserializzaJSON(pathRegistro);

    string path;

    int num = registro.numeroFattura;
    num++;
    path = @$"Fattura {num}.json";
    registro.numeroFattura = num;
        
    // serializza registro fatture
    string update = JsonConvert.SerializeObject(registro, Formatting.Indented);
    File.WriteAllText(pathRegistro, update);


    string newPath = Path.Combine(dirFatture, path);

    // serializza scontrino
    SerializzaJSON(scontrino,newPath);

    // svuota carrello
    File.Delete(link);
    File.Create(link).Close();
    File.WriteAllText(link,"[\n\n]");


}

#endregion