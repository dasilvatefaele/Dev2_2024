using System.Security.Cryptography.X509Certificates;

Console.Clear();

int i_riga = 0;
int i_colonna = 0;
bool ilTuoTurno = true;
bool TRIS = false;
int maniMinime = 0;
string [,] GRIGLIA = new string [3,3];

//! Main {
ResetGRIGLIA(GRIGLIA); 
ilTuoTurno = XOStartCasuale (ilTuoTurno);

do
{
    StampaGRIGLIA(GRIGLIA); 
    InputCoordinata(out i_riga, out i_colonna); 
    ilTuoTurno = ScriviNellaGriglia(GRIGLIA, ilTuoTurno);

    if (maniMinime >= 4)
    {
        ControlloGRIGLIA(GRIGLIA, out TRIS); 
    }   
    if (!TRIS) 
    {
        Console.Clear();
    }
    maniMinime++;

} while (!TRIS);

Console.WriteLine("Grazie per aver giocato!");
Console.WriteLine();
//! } 

// ------------------------------------ FUNZIONI ------------------------------------
# region FUNZIONI

void StampaGRIGLIA (string[,] GRIGLIA)
{
    Console.Write("   a  b  c");
    Console.WriteLine();
    for (int i = 0; i < GRIGLIA.GetLength(0); i++)
    {
        Console.Write($"{i+1}  ");
        for (int j = 0; j < GRIGLIA.GetLength(1); j++)
        {
            Console.Write($"{GRIGLIA[i,j]}");
            Console.Write("  ");
        }
        Console.WriteLine();
    }
}

void InputCoordinata(out int i_riga, out int i_colonna)
{
    string s_colonna;
    bool convertito;
    i_colonna = -1;

    do
    {
        Console.Clear();
        StampaGRIGLIA(GRIGLIA);
        Console.WriteLine();
        Console.Write("RIGA => ");
        convertito = int.TryParse(Console.ReadLine(), out i_riga);

        if (convertito && i_riga <= 0 || i_riga > 4)
        {
            convertito = !convertito;
        }
    } while (!convertito);

    i_riga--; // ADJUST ARRAY OFFSET 

    do
    {    
        Console.Clear();
        StampaGRIGLIA(GRIGLIA);
        Console.WriteLine();
        Console.WriteLine($"RIGA => {i_riga+1}");
        Console.Write("COLONNA => ");
        s_colonna = Console.ReadLine();
        Console.WriteLine();
        s_colonna = s_colonna.ToUpper();

    } while (s_colonna != "A" && s_colonna != "B" && s_colonna != "C");

    switch (s_colonna)
    {
        case "A":
            i_colonna = 0;
        break;
        case "B":
            i_colonna = 1;
            break;
        case "C":
            i_colonna = 2;
            break;
    }
}

void ResetGRIGLIA(string[,]GRIGLIA)
{
    for (int i = 0; i < GRIGLIA.GetLength(0); i++)
    {
        for (int j = 0; j < GRIGLIA.GetLength(1); j++)
        {
            GRIGLIA[i,j]="_";
        }
    }
}

bool TrisPerRiga (string[,] GRIGLIA)
{
    bool flag = false;
    if (GRIGLIA[0,0] == GRIGLIA [0,1] && GRIGLIA [0,1] == GRIGLIA [0,2] && 
        GRIGLIA[0,0] != "_" && GRIGLIA [0,1] != "_" && GRIGLIA [0,2] != "_" ||
        GRIGLIA[1,0] == GRIGLIA [1,1] && GRIGLIA [1,1] == GRIGLIA [1,2] &&
        GRIGLIA[1,0] != "_" && GRIGLIA [1,1] != "_" && GRIGLIA [1,2] != "_" ||
        GRIGLIA[2,0] == GRIGLIA [2,1] && GRIGLIA [2,1] == GRIGLIA [2,2] &&
        GRIGLIA[2,0] != "_" && GRIGLIA [2,1] != "_" && GRIGLIA [2,2] != "_")
        {
                    flag = true;
        }

    return flag;
}

bool TrisPerColonna(string[,] GRIGLIA)
{
    bool flag = false;
    if (GRIGLIA[0,0] == GRIGLIA [1,0] && GRIGLIA [1,0] == GRIGLIA [2,0] && 
        GRIGLIA[0,0] != "_" && GRIGLIA [1,0] != "_" && GRIGLIA [2,0] != "_" ||
        GRIGLIA[0,1] == GRIGLIA [1,1] && GRIGLIA [1,1] == GRIGLIA [2,1] &&
        GRIGLIA[0,1] != "_" && GRIGLIA [1,1] != "_" && GRIGLIA [2,1] != "_" ||
        GRIGLIA[0,2] == GRIGLIA [1,2] && GRIGLIA [1,2] == GRIGLIA [2,2] &&
        GRIGLIA[0,2] != "_" && GRIGLIA [1,2] != "_" && GRIGLIA [2,2] != "_")
        {
          
                flag = true;
        }

    return flag;
}

bool Tris_LEFT_RIGHT (string[,] GRIGLIA)
{
    bool flag = false;
    if (GRIGLIA[0,0] == GRIGLIA [1,1] && GRIGLIA [1,1] == GRIGLIA [2,2])
    {
            if ( !(GRIGLIA[0,0] == "_" || GRIGLIA[1,1] == "_" || GRIGLIA[2,2] == "_") )
            {            
                flag = true;
            }
    }
    return flag;
}

bool Tris_RIGHT_LEFT (string[,] GRIGLIA)
{
    bool flag = false;
    if( GRIGLIA[0,2] == GRIGLIA [1,1] && GRIGLIA [1,1] == GRIGLIA [2,0])
    {
        if ( !(GRIGLIA[0,2] == "_" || GRIGLIA[1,1] == "_" || GRIGLIA[2,0] == "_") )
        {      
            flag = true;      
        }        
    }
    return flag;
}

void ControlloGRIGLIA(string [,] GRIGLIA, out bool TRIS)
{
    TRIS = false;

    if(TrisPerRiga(GRIGLIA))
    {        
        TRIS = true;
        Console.Clear();
        Console.WriteLine("*** TRIS PER RIGA ***");
        StampaGRIGLIA(GRIGLIA);
        ChiHafattoTris(TRIS,ilTuoTurno);    
    }

    if (TrisPerColonna(GRIGLIA))
    {
        TRIS = true;
        Console.Clear();
        Console.WriteLine("*** TRIS PER COLONNA ***");
        StampaGRIGLIA(GRIGLIA);
        ChiHafattoTris(TRIS,ilTuoTurno);
    }

    if (Tris_LEFT_RIGHT(GRIGLIA))
    {
        TRIS = true;
        Console.Clear();
        Console.WriteLine("*** TRIS SINISTRA-DESTRA *** ");
        ChiHafattoTris(TRIS,ilTuoTurno);
    }

    if(Tris_RIGHT_LEFT(GRIGLIA))
    {
        TRIS = true;
        Console.Clear();
        Console.WriteLine("*** TRIS DESTRA-SINISTRA ***");
        ChiHafattoTris(TRIS,ilTuoTurno);
    }
}


void ChiHafattoTris(bool TRIS, bool ilTuoTurno)
 {   
    if (TRIS && !ilTuoTurno)
    {
        Console.WriteLine("X: HA VINTO!");
    } 
    else if (TRIS && ilTuoTurno)
    {
        Console.WriteLine("O: HA VINTO!");
    }   
}



bool ScriviNellaGriglia(string [,] GRIGLIA, bool ilTuoTurno)
{    
    if (ilTuoTurno)
    {
        GRIGLIA[i_riga,i_colonna] = "X";
        ilTuoTurno = !ilTuoTurno;
    } 
    else if (!ilTuoTurno)
    {
        GRIGLIA[i_riga,i_colonna] = "O";
        ilTuoTurno = !ilTuoTurno;
    }

    return ilTuoTurno;
}


bool XOStartCasuale(bool ilTuoTurno)
{
    Random random = new Random();
    int turno = random.Next(2);

    switch (turno)
    {
        case 0:
            ilTuoTurno = false;
            break;
        case 1:
            ilTuoTurno = true;
            break;
    }
    return ilTuoTurno;
}
# endregion
