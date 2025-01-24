// gioco di dadi

/*
- implementare lo storico dei punteggi
- a fine partita viene stampato lo storico dei punteggi del giocatore e del computer.
- lo storico comprende solamente i punteggi della partita in corso.
*/

// pulisco la console
Console.Clear();

// generatore di numeri casuali
Random rnd = new Random();

// continuare a giocare
char giocareAncora;

// punteggio del giocatore e del computer
int punteggioGiocatore = 100;
int punteggioComputer = 100;

// storico dei punteggi
List<int> storicoGiocatore = new List<int>();
List<int> storicoComputer = new List<int>();

// inizia il gioco
do
{
    // lancio dei dadi per il giocatore e per il computer
    int dadoGiocatore = LancioDado();
    int dadoComputer = LancioDado();

    // stampa dei risultati
    StampaRisultatoLancio(dadoGiocatore, dadoComputer);

    // determinazione vincitore con out
    DeterminaVincitore(dadoGiocatore, dadoComputer, out punteggioGiocatore, out punteggioComputer);

    // stampa del punteggio
    StampaPunteggio(punteggioGiocatore, punteggioComputer);

    // aggiungo i punteggi allo storico
    storicoGiocatore.Add(punteggioGiocatore);
    storicoComputer.Add(punteggioComputer);

    // chiedere all'utente se vuole continuare a giocare
    giocareAncora = VuoiGiocareAncora();

    // a capo
    Console.WriteLine();

    // pulisco la console
    Console.Clear();
} while (punteggioGiocatore > 0 && punteggioComputer > 0 && (giocareAncora == 's' || giocareAncora == 'S'));

// stampa dello storico
Console.WriteLine("Storico dei punteggi:");
for (int i = 0; i < storicoGiocatore.Count; i++)
{
    Console.WriteLine($"Lancio {i + 1}: Giocatore {storicoGiocatore[i]} - Computer {storicoComputer[i]}");
}

// funzione per determinare il vincitore con out
void DeterminaVincitore(int dadoGiocatore, int dadoComputer, out int punteggioGiocatore, out int punteggioComputer)
{
    punteggioGiocatore = 100;
    punteggioComputer = 100;

    if (dadoGiocatore > dadoComputer)
    {
        punteggioGiocatore += 10 + (dadoGiocatore - dadoComputer);
        punteggioComputer -= 10 + (dadoGiocatore - dadoComputer);
        Console.WriteLine("Il giocatore ha vinto!");
    }
    else if (dadoGiocatore < dadoComputer)
    {
        punteggioGiocatore -= 10 + (dadoComputer - dadoGiocatore);
        punteggioComputer += 10 + (dadoComputer - dadoGiocatore);
        Console.WriteLine("Il computer ha vinto!");
    }
    else
    {
        Console.WriteLine("Pareggio!");
    }
}

// funzione per stampare il punteggio
void StampaPunteggio(int punteggioGiocatore, int punteggioComputer)
{
    Console.WriteLine($"Il punteggio del giocatore è {punteggioGiocatore}");
    Console.WriteLine($"Il punteggio del computer è {punteggioComputer}");
}

// funzione per chiedere all'utente se vuole continuare a giocare
char VuoiGiocareAncora()
{
    Console.WriteLine("Vuoi giocare ancora? (s/n)");
    return Console.ReadKey().KeyChar;
}

// funzione per stampare i risultati del lancio
void StampaRisultatoLancio(int dadoGiocatore, int dadoComputer)
{
    Console.WriteLine($"Il giocatore ha lanciato {dadoGiocatore}");
    Console.WriteLine($"Il computer ha lanciato {dadoComputer}");
}

// funzione per il lancio del dado
int LancioDado()
{
    return rnd.Next(1, 7);
}