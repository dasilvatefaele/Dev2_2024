# TRIS

> Dipendenze:
```
dotnet add package Raylib-CsLo --version 4.2.0.9
```

> Boilerplate:
```csharp
using Raylib_CsLo;

namespace Tris 
{
    class Program
    {
        static void Main()
        {
            Raylib.InitWindow(800, 800, "Tic-tac-toe by Tefh33");
            // inizializzo finestra
            Raylib.InitAudioDevice();
            // inizializzo output audio
            
            while (!Raylib.WindowShouldClose()) // loop di gioco
            {
                /*

                QUI AVVIENE LA LOGICA DI GIOCO

                */

                ControlloGRIGLIA(GRIGLIA, out TRIS, ilTuoTurno);

                Raylib.BeginDrawing();
                    Raylib.ClearBackground(Raylib.BLACK);
                
                /*

                QUI AVVIENE LAA STAMPA SU SCHERMO

                */

                
                Raylib.EndDrawing();
            } 
            Raylib.CloseAudioDevice();
            Raylib.CloseWindow();
        }
    }
}
```

> Flowchart:

```Mermaid
flowchart LR

id0((inizio))-->id1[inizializzazioni iniziali]
id1-->id2([Main loop])
id2-->id3[Logica di gioco]
id3-->id4[Disegno]
id4-->id5
id5{TRIS?}
id5-->|si|id6((fine))
id5-->|no|id3
```


> Logica controllo matrici:
```csharp

    public static bool TrisPerRiga(string[,] GRIGLIA)
    {
        bool flag = false;
        if (GRIGLIA[0, 0] == GRIGLIA[0, 1] && GRIGLIA[0, 1] == GRIGLIA[0, 2] ||
            GRIGLIA[1, 0] == GRIGLIA[1, 1] && GRIGLIA[1, 1] == GRIGLIA[1, 2] ||
            GRIGLIA[2, 0] == GRIGLIA[2, 1] && GRIGLIA[2, 1] == GRIGLIA[2, 2])
        {
            if (GRIGLIA[0, 0] != "_" && GRIGLIA[0, 1] != "_" && GRIGLIA[0, 2] != "_" ||
                GRIGLIA[1, 0] != "_" && GRIGLIA[1, 1] != "_" && GRIGLIA[1, 2] != "_" ||
                GRIGLIA[2, 0] != "_" && GRIGLIA[2, 1] != "_" && GRIGLIA[2, 2] != "_")
            {
                flag = true;
                return flag;
            }
        }
        return flag;
    }


    public static bool TrisPerColonna(string[,] GRIGLIA)
    {
        bool flag = false;
        if (GRIGLIA[0, 0] == GRIGLIA[1, 0] && GRIGLIA[1, 0] == GRIGLIA[2, 0] ||
            GRIGLIA[0, 1] == GRIGLIA[1, 1] && GRIGLIA[1, 1] == GRIGLIA[2, 1] ||
            GRIGLIA[0, 2] == GRIGLIA[1, 2] && GRIGLIA[1, 2] == GRIGLIA[2, 2])
        {
            if (GRIGLIA[0, 0] != "_" && GRIGLIA[1, 0] != "_" && GRIGLIA[2, 0] != "_" ||
                GRIGLIA[0, 1] != "_" && GRIGLIA[1, 1] != "_" && GRIGLIA[2, 1] != "_" ||
                GRIGLIA[0, 2] != "_" && GRIGLIA[1, 2] != "_" && GRIGLIA[2, 2] != "_")
            {
                flag = true;
                return flag;
            }
        }

        return flag;
    }


    public static bool Tris_LEFT_RIGHT(string[,] GRIGLIA)
    {
        bool flag = false;
        if (GRIGLIA[0, 0] == GRIGLIA[1, 1] && GRIGLIA[1, 1] == GRIGLIA[2, 2])
        {
            if (!(GRIGLIA[0, 0] == "_" || GRIGLIA[1, 1] == "_" || GRIGLIA[2, 2] == "_"))
            {
                flag = true;
                return flag;
            }
        }
        return flag;
    }


    public static bool Tris_RIGHT_LEFT(string[,] GRIGLIA)
    {
        bool flag = false;
        if (GRIGLIA[0, 2] == GRIGLIA[1, 1] && GRIGLIA[1, 1] == GRIGLIA[2, 0])
        {
            if (!(GRIGLIA[0, 2] == "_" || GRIGLIA[1, 1] == "_" || GRIGLIA[2, 0] == "_"))
            {
                flag = true;
                return flag;
            }
        }
        return flag;
    }


    public static void ControlloGRIGLIA(string[,] GRIGLIA, out bool TRIS, bool ilTuoTurno)
    {
        TRIS = false;

        if (TrisPerRiga(GRIGLIA))
        {
            TRIS = true;
            ChiHafattoTris(TRIS, ilTuoTurno);
        }

        if (TrisPerColonna(GRIGLIA))
        {
            TRIS = true;
            ChiHafattoTris(TRIS, ilTuoTurno);
        }

        if (Tris_LEFT_RIGHT(GRIGLIA))
        {
            TRIS = true;
            ChiHafattoTris(TRIS, ilTuoTurno);
        }

        if (Tris_RIGHT_LEFT(GRIGLIA))
        {
            TRIS = true;
            ChiHafattoTris(TRIS, ilTuoTurno);
        }
    }


    public static void ChiHafattoTris(bool TRIS, bool ilTuoTurno)
    {


    }

```