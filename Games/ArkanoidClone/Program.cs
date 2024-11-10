using System.Numerics;
using Raylib_CsLo;
using System;
using Microsoft.VisualBasic;

// dotnet add package Raylib-CsLo --version 4.2.0.9

// ! INIZIALIZZAZIONE VARIABILI DI GIOCO


namespace ArkanoidClone
{
    class Program
    {
        static void Main ()
        {

            // ! INIZIALIZZAZIONE FINESTRA

            Raylib.InitWindow(800,600, "Arkanoid Clone");
            Raylib.SetTargetFPS(60);

            // racchetta
            float paddleX = 400; 
            float paddleWidth = 100;
            float paddleHeight = 20;
            float paddleSpeed = 600;

            // palla
            float ballX = 400;
            float ballY = 300;
            float ballSpeedX = 300;
            float ballSpeedY = -300;
            float ballRadius = 10;

            // blocchi
            Rectangle[] blocks = new Rectangle[5];

            for (int i = 0; i < 5; i++)
            {
                blocks[i] = new Rectangle(100 + i * 150, 100,100,20);
            }

            

            while(!Raylib.WindowShouldClose())
            {
    
                // ! GESTIONE DELL'INPUT

                // movimento della racchetta

                if(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && paddleX > 0)
                {
                    paddleX -= paddleSpeed * Raylib.GetFrameTime(); // todo: capire questa cosa
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && paddleX < 800 - paddleWidth)
                {
                    paddleX += paddleSpeed * Raylib.GetFrameTime();
                }

                // ! MOVIMENTO DELLA PALLA

                ballX += ballSpeedX * Raylib.GetFrameTime();  // todo: capire questa cosa
                ballY += ballSpeedY * Raylib.GetFrameTime();

                // ! CONTROLLO COLLISIONI CON LE PARETI

                if (ballX <= 0 || ballX >= 800)
                {
                    ballSpeedX = -ballSpeedX;
                }
                if (ballY <= 0)
                {
                    ballSpeedY = -ballSpeedY;
                }

                // ! COLLISIONE CON LA RACCHETTA

                if (ballY + ballRadius >=580 && ballX > paddleX && ballX < paddleX + paddleWidth) // todo: capire questa cosa
                {
                    ballSpeedY = -ballSpeedY;
                }

                // ! COLLISIONE CON I BLOCCHI

                for (int i = 0; i < blocks.Length; i++)//foreach (var block in blocks)
                {
                    if (Raylib.CheckCollisionCircleRec(new Vector2 (ballX,ballY), ballRadius,blocks[i])) // todo: da capire meglio
                    {
                        ballSpeedY = -ballSpeedY;
                        blocks[i].width = 0; // todo: da capire
                    }
                }

                // ! DISEGNARE LA SCENA
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib.DARKGRAY); // TODO: capire cos'è, cosa cambia questo valore

                // ! DISEGNARE GLI OGGETTI
                // disegnare la racchetta
                Raylib.DrawRectangle((int)paddleX, 580, (int)paddleWidth, (int)paddleHeight, Raylib.DARKBLUE);
                // disegnare la palla
                Raylib.DrawCircle((int)ballX, (int)ballY, (int)ballRadius, Raylib.RED);

                // ! DISEGNARE I BLOCCHI
                foreach (var block in blocks)
                {
                    Raylib.DrawRectangleRec(block, Raylib.LIME);
                }

                Raylib.EndDrawing();
            } // ! ************** CHIUSURA MAIN LOOP

            Raylib.CloseWindow();
        }
    }
}


/*
namespace RaylibTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Raylib C# Test");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib.SKYBLUE);
                Raylib.DrawText("Hello Raylib with C#!", 10, 10, 20, Raylib.DARKGRAY);
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
*/