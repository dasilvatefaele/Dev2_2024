using System.Numerics;
using Raylib_CsLo;
using System;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;


namespace Tris
{
    class Program
    {
        static void Main()
        {

            // * INIZIALIZZAZIONE FINESTRA
            int framePause = 60;

            Raylib.InitWindow(800, 800, "Tic-tac-toe by Tefh33");


            bool[,] occupato = new bool[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    occupato[i, j] = false;
                }

            }

            float wiggleSpeed = 5f; // Velocità dell'animazione
            float wiggleAmount = 10f; // Intensità del movimento
            float time = 0f; // Tempo per il movimento






            // Incrementa il tempo per continuare l'animazione
            time += Raylib.GetFrameTime();

            int mousePositionX;
            int mousePositionY;
            bool ilTuoTurno = false;
            bool TRIS = false;
            int soundOn = 1;
            int maniMinime = 0;
            string[,] GRIGLIA = new string[3, 3];
            int slotLiberi = 9;

            Raylib.InitAudioDevice();
            Sound popSound = Raylib.LoadSound("sounds/pop.ogg");
            Sound win = Raylib.LoadSound("sounds/win.ogg");
            Sound lose = Raylib.LoadSound("sounds/lose.ogg");

            Texture cross = Raylib.LoadTexture("2D_images/X.png");
            Texture circle = Raylib.LoadTexture("2D_images/O.png");
            Texture bg = Raylib.LoadTexture("2D_images/bg.png");
            Texture gameOver = Raylib.LoadTexture("2D_images/game_over.png");
            Texture youWon = Raylib.LoadTexture("2D_images/you_won.png");


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GRIGLIA[i, j] = "_";
                }
            }

            while (!Raylib.WindowShouldClose()) //  ************** MAIN LOOP {
            {
                // update logic
                mousePositionX = Raylib.GetMouseX();
                mousePositionY = Raylib.GetMouseY();


                // Input da mouse
                #region 1^ RIGA


                // CASELLA 1A
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
                    && (mousePositionX > 100 && mousePositionY < 300)
                    && (mousePositionY > 100 && mousePositionX < 300) && !occupato[0, 0])
                {
                    switch (ilTuoTurno)
                    {
                        case true:
                            GRIGLIA[0, 0] = "X";
                            occupato[0, 0] = !occupato[0, 0];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                        case false:
                            GRIGLIA[0, 0] = "O";
                            occupato[0, 0] = !occupato[0, 0];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                    }
                }

                // CASELLA 1B
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
                    && (mousePositionX > 300 && mousePositionX < 490)
                    && (mousePositionY > 100 && mousePositionY < 300) && !occupato[0, 1])
                {
                    switch (ilTuoTurno)
                    {
                        case true:
                            GRIGLIA[0, 1] = "X";
                            occupato[0, 1] = !occupato[0, 1];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                        case false:
                            GRIGLIA[0, 1] = "O";
                            occupato[0, 1] = !occupato[0, 1];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                    }
                }
                // CASELLA 1C
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
                    && (mousePositionX > 490 && mousePositionX < 680)
                    && (mousePositionY > 100 && mousePositionY < 300) && !occupato[0, 2])
                {
                    switch (ilTuoTurno)
                    {
                        case true:
                            GRIGLIA[0, 2] = "X";
                            occupato[0, 2] = !occupato[0, 2];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                        case false:
                            GRIGLIA[0, 2] = "O";
                            occupato[0, 2] = !occupato[0, 2];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                    }
                }
                #endregion

                #region 2^ RIGA
                // CASELLA 2A
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
                    && (mousePositionX > 100 && mousePositionX < 300)
                    && (mousePositionY > 310 && mousePositionY < 505) && !occupato[1, 0])
                {
                    switch (ilTuoTurno)
                    {
                        case true:
                            GRIGLIA[1, 0] = "X";
                            occupato[1, 0] = !occupato[1, 0];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                        case false:
                            GRIGLIA[1, 0] = "O";
                            occupato[1, 0] = !occupato[1, 0];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                    }
                }

                // CASELLA 2B
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
                    && (mousePositionX > 300 && mousePositionX < 490)
                    && (mousePositionY > 310 && mousePositionY < 505) && !occupato[1, 1])
                {
                    switch (ilTuoTurno)
                    {
                        case true:
                            GRIGLIA[1, 1] = "X";
                            occupato[1, 1] = !occupato[1, 1];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                        case false:
                            GRIGLIA[1, 1] = "O";
                            occupato[1, 1] = !occupato[1, 1];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                    }
                }
                // CASELLA 2C
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
                    && (mousePositionX > 490 && mousePositionX < 680)
                    && (mousePositionY > 310 && mousePositionY < 505) && !occupato[1, 2])
                {
                    switch (ilTuoTurno)
                    {
                        case true:
                            GRIGLIA[1, 2] = "X";
                            occupato[1, 2] = !occupato[1, 2];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                        case false:
                            GRIGLIA[1, 2] = "O";
                            occupato[1, 2] = !occupato[1, 2];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                    }
                }
                #endregion

                #region 3^ RIGA
                // CASELLA 3A
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
                    && (mousePositionX > 100 && mousePositionX < 300)
                    && (mousePositionY > 505 && mousePositionY < 700) && !occupato[2, 0])
                {
                    switch (ilTuoTurno)
                    {
                        case true:
                            GRIGLIA[2, 0] = "X";
                            occupato[2, 0] = !occupato[2, 0];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                        case false:
                            GRIGLIA[2, 0] = "O";
                            occupato[2, 0] = !occupato[2, 0];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                    }
                }
                // void InputDaMouse (mousePositionX, mousePositionX, out occupato, out ilTuoTurno, out slotLiberi, popSound, out GRIGLIA);
                // CASELLA 3B
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
                    && (mousePositionX > 300 && mousePositionX < 490)
                    && (mousePositionY > 505 && mousePositionY < 700) && !occupato[2, 1])
                {
                    switch (ilTuoTurno)
                    {
                        case true:
                            GRIGLIA[2, 1] = "X";
                            occupato[2, 1] = !occupato[2, 1];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                        case false:
                            GRIGLIA[2, 1] = "O";
                            occupato[2, 1] = !occupato[2, 1];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                    }
                }
                // CASELLA 3C
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
                    && (mousePositionX > 490 && mousePositionX < 680)
                    && (mousePositionY > 505 && mousePositionY < 700) && !occupato[2, 2])
                {
                    switch (ilTuoTurno)
                    {
                        case true:
                            GRIGLIA[2, 2] = "X";
                            occupato[2, 2] = !occupato[2, 2];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                        case false:
                            GRIGLIA[2, 2] = "O";
                            occupato[2, 2] = !occupato[2, 2];
                            ilTuoTurno = !ilTuoTurno;
                            slotLiberi--;
                            Raylib.PlaySoundMulti(popSound);
                            break;
                    }
                }

                #endregion


                ControlloGRIGLIA(GRIGLIA, out TRIS, ilTuoTurno, occupato);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib.BLACK);
                Raylib.DrawTexture(bg, 0, 0, Raylib.WHITE);

                DrawXO(GRIGLIA, cross, circle);

                //TRIS = false;
                if (slotLiberi <= 5 && TRIS)
                {
                    if (!ilTuoTurno)
                    {
                        //Raylib.DrawText("HAI VINTO!", 450, 450, 36, Raylib.GREEN);

                        //! ANIMAZIONE: DA CAPIRE
                        double offset = Math.Sin(time * wiggleSpeed) * wiggleAmount;
                        // Incrementa il tempo per continuare l'animazione
                        time += Raylib.GetFrameTime();


                        Raylib.DrawTextureEx(youWon, new Vector2((int)(0 + offset), 0), 0f, 1.02f, Raylib.WHITE);
                        soundOn--;
                    }
                    else if (ilTuoTurno)
                    {
                        //Raylib.DrawText("HAI PERSO!", 450, 450, 36, Raylib.RED);

                        //! ANIMAZIONE: DA CAPIRE
                        double offset = Math.Sin(time * wiggleSpeed) * wiggleAmount;
                        // Incrementa il tempo per continuare l'animazione
                        time += Raylib.GetFrameTime();

                        Raylib.DrawTextureEx(gameOver, new Vector2((int)(0 + offset), 0), 0f, 1.02f, Raylib.WHITE);
                        soundOn--;
                    }
                }

                Raylib.EndDrawing();

                // output audio:
                if (soundOn == 0)
                {
                    if (!ilTuoTurno)
                    {
                        Raylib.PlaySoundMulti(win);
                        soundOn -= 2;
                    }
                    else if (ilTuoTurno)
                    {
                        Raylib.PlaySoundMulti(lose);
                        soundOn -= 2;

                    }
                }



            } //  ************** MAIN LOOP }
            Raylib.CloseAudioDevice();
            Raylib.CloseWindow();
        }

        public static bool TrisPerRiga(string[,] GRIGLIA)
        {
            bool flag = false;
            if (GRIGLIA[0, 0] == GRIGLIA[0, 1] && GRIGLIA[0, 1] == GRIGLIA[0, 2] &&
                GRIGLIA[0, 0] != "_" && GRIGLIA[0, 1] != "_" && GRIGLIA[0, 2] != "_" ||
                GRIGLIA[1, 0] == GRIGLIA[1, 1] && GRIGLIA[1, 1] == GRIGLIA[1, 2] &&
                GRIGLIA[1, 0] != "_" && GRIGLIA[1, 1] != "_" && GRIGLIA[1, 2] != "_" ||
                GRIGLIA[2, 0] == GRIGLIA[2, 1] && GRIGLIA[2, 1] == GRIGLIA[2, 2] &&
                GRIGLIA[2, 0] != "_" && GRIGLIA[2, 1] != "_" && GRIGLIA[2, 2] != "_")
            {
                flag = true;
            }

            return flag;
        }

        public static bool TrisPerColonna(string[,] GRIGLIA)
        {
            bool flag = false;
            if (GRIGLIA[0, 0] == GRIGLIA[1, 0] && GRIGLIA[1, 0] == GRIGLIA[2, 0] &&
                GRIGLIA[0, 0] != "_" && GRIGLIA[1, 0] != "_" && GRIGLIA[2, 0] != "_" ||
                GRIGLIA[0, 1] == GRIGLIA[1, 1] && GRIGLIA[1, 1] == GRIGLIA[2, 1] &&
                GRIGLIA[0, 1] != "_" && GRIGLIA[1, 1] != "_" && GRIGLIA[2, 1] != "_" ||
                GRIGLIA[0, 2] == GRIGLIA[1, 2] && GRIGLIA[1, 2] == GRIGLIA[2, 2] &&
                GRIGLIA[0, 2] != "_" && GRIGLIA[1, 2] != "_" && GRIGLIA[2, 2] != "_")
            {

                flag = true;
            }

            return flag;
        }

        public static bool Tris_LEFT_RIGHT(string[,] GRIGLIA)
        {
            bool flag = false;
            if (GRIGLIA[0, 0] == GRIGLIA[1, 1] && GRIGLIA[1, 1] == GRIGLIA[2, 2] &&
                GRIGLIA[0, 0] != "_" && GRIGLIA[1, 1] != "_" && GRIGLIA[2, 2] != "_")
            {

                flag = true;

            }
            return flag;
        }

        public static bool Tris_RIGHT_LEFT(string[,] GRIGLIA)
        {
            bool flag = false;
            if (GRIGLIA[0, 2] == GRIGLIA[1, 1] && GRIGLIA[1, 1] == GRIGLIA[2, 0] &&
                GRIGLIA[0, 2] != "_" && GRIGLIA[1, 1] != "_" && GRIGLIA[2, 0] != "_")
            {

                flag = true;

            }
            return flag;
        }

        public static void ControlloGRIGLIA(string[,] GRIGLIA, out bool TRIS, bool ilTuoTurno, bool[,] occupato)
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
            //? obsoleto
        }

        public static void DrawXO(string[,] GRIGLIA, Texture cross, Texture circle)
        {
            // 1A
            if (GRIGLIA[0, 0] == "X")
            {
                Raylib.DrawTexture(cross, 100, 110, Raylib.WHITE);

            }
            else if (GRIGLIA[0, 0] == "O")
            {
                Raylib.DrawTexture(circle, 100, 110, Raylib.WHITE);

            }

            // 1B
            if (GRIGLIA[0, 1] == "X")
            {
                Raylib.DrawTexture(cross, 300, 110, Raylib.WHITE);
            }
            else if (GRIGLIA[0, 1] == "O")
            {
                Raylib.DrawTexture(circle, 300, 110, Raylib.WHITE);
            }

            // 1C
            if (GRIGLIA[0, 2] == "X")
            {
                Raylib.DrawTexture(cross, 490, 110, Raylib.WHITE);
            }
            else if (GRIGLIA[0, 2] == "O")
            {
                Raylib.DrawTexture(circle, 490, 110, Raylib.WHITE);
            }

            // 2A
            if (GRIGLIA[1, 0] == "X")
            {
                Raylib.DrawTexture(cross, 100, 308, Raylib.WHITE);
            }
            else if (GRIGLIA[1, 0] == "O")
            {
                Raylib.DrawTexture(circle, 100, 308, Raylib.WHITE);
            }

            // 2B
            if (GRIGLIA[1, 1] == "X")
            {
                Raylib.DrawTexture(cross, 300, 308, Raylib.WHITE);
            }
            else if (GRIGLIA[1, 1] == "O")
            {
                Raylib.DrawTexture(circle, 300, 308, Raylib.WHITE);
            }

            // 2C
            if (GRIGLIA[1, 2] == "X")
            {
                Raylib.DrawTexture(cross, 490, 308, Raylib.WHITE);
            }
            else if (GRIGLIA[1, 2] == "O")
            {
                Raylib.DrawTexture(circle, 490, 308, Raylib.WHITE);
            }

            // 3A
            if (GRIGLIA[2, 0] == "X")
            {
                Raylib.DrawTexture(cross, 100, 505, Raylib.WHITE);
            }
            else if (GRIGLIA[2, 0] == "O")
            {
                Raylib.DrawTexture(circle, 100, 505, Raylib.WHITE);
            }

            // 3B
            if (GRIGLIA[2, 1] == "X")
            {
                Raylib.DrawTexture(cross, 300, 505, Raylib.WHITE);
            }
            else if (GRIGLIA[2, 1] == "O")
            {
                Raylib.DrawTexture(circle, 300, 505, Raylib.WHITE);
            }

            // 3C
            if (GRIGLIA[2, 2] == "X")
            {
                Raylib.DrawTexture(cross, 490, 505, Raylib.WHITE);
            }
            else if (GRIGLIA[2, 2] == "O")
            {
                Raylib.DrawTexture(circle, 490, 505, Raylib.WHITE);
            }
        }
    }
}