/*
META CODICE
CALCOLATRICE v2.1 con ARRAY e LETTURA CARATTERI come OPERATORI

Stampa

Scrivi la tua espressione:
input: 13 + 18 - 9* 5,5
string stringaEspressione = “13 + 18 - 9* 5,5 =”

Possibili soluzioni: 
1) acquisire string e dividere gli elementi
		esempio: 
			foreach (char in stringaEspressione){
				leggi stringa fino a (+,-,*,/)
				ciò che trovi prima di uno di questi caratteri assegnalo in double var[i] e int nOperandi++;
				salva il carattere  in char operando [i] e nOperazione++;
				elimina dalla stringa primo valore e carattere 
				// stringaEspressione = 18 - 9 * 5,5;
				// var[0] = 13
				// char operando[0] = ‘+’
			}
			// alla fine di questi cicli dovrei avere:
				var[0] = 13
				operando[0] = ‘+’
				var[1] = 18
				operando[1] = ‘-‘
				var[2] = 9
				operando [2] = ‘*’
				var[3] =  5,5
				operando [3] = ‘=‘

				nOperandi = 4;
				nOperazioni = 4;

//2) comprendere ordine logico di calcolo
/*
		esempio:
			
			
			bool precedenza = false
			int contaPrecedenze = 0;
			//Dictionary<int, char> posizioneCarattere = new Dictionary<int, char>();
			

			foreach (I in operando[i])
				if (operando[I] == ‘*’ || operando [I] == ‘/‘){
					precedenza = true;
					contaPrecedenze++;					
				} else {
					precedenza = false; 
			}

			// controllo la precedenza di moltiplicazioni o divisioni
			// se ci sono, la variabile precedenza sarà true
			
			if (precedenza == true || contaPrecedenze != 0){
				foreach (I in operando[i]){
					switch operando[I]:
							case ‘*’ :	
									risultatoEspressione += var[i]*var[i+1] // 49,5
									// se operando [i-1] == ‘-‘
										risultatoEspressione *= -1;
									nOperazioni - -; // 3 nOperazioni.RemoveAt(i)
									nOperandi - -; // 3 
									
							case ‘/‘ :	
									risultatoEspressione += var[I]/var[i+1]
										// se operando [i-1] == ‘-‘
										risultatoEspressione *= -1;
									nOperazioni - -; // 3
									nOperandi - -; // 3 
							default:
								break;
				}
			}

*/
/*
			// 13 + 18 - 49,5
			bool fineEspressione = false;
			do {
					foreach (I in operando[i]){
					switch operando[I]:
							case ‘+’ :	
									risultatoEspressione += var[i] + var[i+1] // -49,5 + 31
									nOperazioni - -;
									nOperandi - - ;
							case ‘-‘ :	
									risultatoEspressione = risultatoEspressione + (var[i] - var[i+1])
									nOperazioni - -;
									nOperandi - - ;

							case ‘ = ‘:
									stampa risultatoEpressione;
									fineEspressione = True
									break;
							default:
								break;
				}
			}while (fineEspressione == False)	
Stampa “Grazie per aver usato la calcolatrice avanzata!”
*/

//acquisire string e dividere gli elementi (META-CODICE)
/*
Possibili soluzioni: 
1) acquisire string e dividere gli elementi
		esempio: 
			foreach (char in stringaEspressione){
				leggi stringa fino a (+,-,*,/)
				ciò che trovi prima di uno di questi caratteri assegnalo in double var[i] e int nOperandi++;
				salva il carattere  in char operando [i] e nOperazione++;
				elimina dalla stringa primo valore e carattere 
				// stringaEspressione = 18 - 9 * 5,5;
				// var[0] = 13
				// char operando[0] = ‘+’
			}
			// alla fine di questi cicli dovrei avere:
				var[0] = 13
				operando[0] = ‘+’
				var[1] = 18
				operando[1] = ‘-‘
				var[2] = 9
				operando [2] = ‘*’
				var[3] =  5,5
				operando [3] = ‘=‘

				nOperandi = 4;
				nOperazioni = 4;
*/

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

Console.Clear();
Console.Write("Scrivi l'espressione e premi invio: "); // “13 + 18 - 9* 5,5”
string espressione = Console.ReadLine();

//  controllo acquisizione
//  Console.WriteLine(espressione);

char[] delimitatori = {'+','-','*','/'};
string[] stringNumeri= espressione.Split(delimitatori);
int nNumeri = 0;
int nOperatori = 0;
List<double> var = new List<double>();
List<char> operandi = new List<char>();

foreach ( string digit in stringNumeri){
    double conversione = double.Parse(digit);
    var.Add(conversione);
    nNumeri++;
}

List<double> backupVar = var;
List<char> backupOperandi = operandi;

foreach(char operatore in espressione){
    if (operatore == '+'){operandi.Add(operatore); nOperatori++;}
    if (operatore == '-'){operandi.Add(operatore); nOperatori++;}
    if (operatore == '*'){operandi.Add(operatore); nOperatori++;}
    if (operatore == '/'){operandi.Add(operatore); nOperatori++;}
    if (operatore == '='){operandi.Add(operatore); nOperatori++;}
}

//  Controllo acquisizione (TEST -OK)
/*
Console.WriteLine("In questa espressione le variabili sono:");
foreach ( double number in var){
    Console.Write(number);
    Console.Write(", ");
}

Console.WriteLine("\n\ne gli operatori sono:");
foreach ( char operatore in operandi){
    Console.Write(operatore);
    Console.Write(", ");
}

Console.WriteLine($"\n\nIl numero di variabili è {nNumeri} ed il numero di operazioni è {nOperatori}");
*/

// 13+18-9*5.5

//2) comprendere ordine logico di calcolo (META-CODICE)
/*
		esempio:
			
			
			bool precedenza = false;
			int contaPrecedenze = 0;

			foreach (I in operando[i])
				if (operando[I] == ‘*’ || operando [I] == ‘/‘){
					precedenza = true;
					contaPrecedenze++;					
				} else {
					precedenza = false; 
			}

			// controllo la precedenza di moltiplicazioni o divisioni
			// se ci sono, la variabile precedenza sarà true
			
			if (precedenza == true || contaPrecedenze != 0){
				foreach (I in operando[i]){
					switch operando[I]:
							case ‘*’ :	
									risultatoEspressione += var[i]*var[i+1] // 49,5
									// se operando [i-1] == ‘-‘
										risultatoEspressione *= -1;
									nOperazioni - -; // 3 nOperazioni.RemoveAt(i)
									nOperandi - -; // 3 
									
							case ‘/‘ :	
									risultatoEspressione += var[I]/var[i+1]
										// se operando [i-1] == ‘-‘
										risultatoEspressione *= -1;
									nOperazioni - -; // 3
									nOperandi - -; // 3 
							default:
								break;
				}
			}

*/

bool precedenza = false;
int contaPrecedenze = 0;

foreach (char op in operandi){
    if (op == '*' || op == '/'){
        precedenza = true;
        contaPrecedenze++;					
    } else {
        precedenza = false; 
    }
}

// controllo la presenza di moltiplicazioni o divisioni
// se ci sono, la variabile precedenza sarà true (TEST -OK)
/*
Console.WriteLine($"\nValore di precedenza: {precedenza}");
Console.WriteLine($"Valore di contaPrecedenza = {contaPrecedenze}");
*/


double risultatoEspressione = 0;
int contatore = 0;

if (precedenza == true || contaPrecedenze != 0){
    foreach (char op in new List <char> (operandi)){
        switch (op) {
            case '*':	
                if (backupVar.Count == 1)
                {
                    int j = operandi.FindIndex(n => n == '*');
                    risultatoEspressione *= var[0] ;


                    try {
                    if (operandi[j-1] == '-') {risultatoEspressione *= -1;}
                    }
                    catch (System.ArgumentOutOfRangeException) {}

        
                    backupVar.RemoveAt(0);
                    operandi[j] = ' ';
                    backupOperandi.RemoveAt(j);
                }
                else if (backupVar.Count == 2)
                {
                    int j = operandi.FindIndex(n => n == '*');
                    risultatoEspressione += var[0]*var[1];

                    try {
                    if (operandi[j-1] == '-') {risultatoEspressione *= -1;}
                    }
                    catch (System.ArgumentOutOfRangeException) {}

                    backupVar.RemoveAt(0);
                    backupVar.RemoveAt(0);
                    operandi[j] = ' ';
                    backupOperandi.RemoveAt(j);
                }
                else
                {
                    int j = operandi.FindIndex(n => n == '*');
                    
                    try {
                    if (operandi[j-1] == '-') {risultatoEspressione += ((-1)*var[j])*var[j+1];}
                    }
                    catch (System.ArgumentOutOfRangeException) {risultatoEspressione += var[j]*var[j+1];
}

                    /*
                    risultatoEspressione += var[j]*var[j+1];

                    try {
                    if (operandi[j-1] == '-') {risultatoEspressione *= -1;}
                    }
                    catch (System.ArgumentOutOfRangeException) {}
                    */

                    backupVar.RemoveAt(j);
                    backupVar.RemoveAt(j);
                    operandi[j] = ' ';
                    backupOperandi.RemoveAt(j);
                }
                break;    
        }
    }
}



//  Controllo acquisizione (TEST -)

Console.WriteLine("In questa espressione le variabili sono:");

List<double> newAddExpression = new List<double>();

foreach ( double number in backupVar){
    Console.Write(number);
    Console.Write(", ");
    newAddExpression.Add(number);
}

Console.Write(risultatoEspressione);
newAddExpression.Add(risultatoEspressione);

Console.Write($"\n\nVariabili rimaste: {(backupVar.Count)+1}\nOperazioni rimaste: {backupOperandi.Count} (");
foreach (char c in backupOperandi){
    Console.Write($"{c}");
}
Console.Write(")\n\n");

//  Se nell'espressione vi é una moltiplicazione o divisione
//  questa è la prima ad essere eseguita (TEST -OK)
/*
Console.WriteLine($"\nPer il momento, il risultato della moltiplicazione è {risultatoEspressione}");
*/


risultatoEspressione = newAddExpression.Sum();

/*
bool fineEspressione = false;
do {
    foreach (char op in new List <char> (backupOperandi)){
        switch (op){
            case '+':
                if (backupVar.Count == 1)
                {
                    int j = operandi.FindIndex(n => n == '+');
                    risultatoEspressione += var[j]; // -49,5 + 31
                    //backupVar.RemoveAt(j);
                    backupVar.RemoveAt(j);
                }
                else if (backupVar.Count >= 2)
                {
                    int j = operandi.FindIndex(n => n == '+');
                    risultatoEspressione += var[j] + var[j+1]; // -49,5 + 31
                    //backupVar.RemoveAt(j);
                    backupVar.RemoveAt(j);
                }
                break;
            case '-':
                if (backupVar.Count == 1)
                {
                    int k = operandi.FindIndex(n => n == '-');
                    risultatoEspressione = (-1) * risultatoEspressione + var[k];
                    //backupVar.RemoveAt(k);
                    backupVar.RemoveAt(k);
                } 
                else if (backupVar.Count >= 2)
                {
                    int k = operandi.FindIndex(n => n == '-');
                    risultatoEspressione = (-1) * risultatoEspressione + var[k] - var[k+1];
                    //backupVar.RemoveAt(j);
                    backupVar.RemoveAt(k);

                }

                break;
            default:
                break;
        }
    }
    if (backupVar.Count==0){fineEspressione=true;}
}while (fineEspressione == false);
*/

Console.WriteLine($"\n\n\n={risultatoEspressione}");