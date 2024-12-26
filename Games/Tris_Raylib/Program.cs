using System.Numerics;
using Raylib_CsLo;
using System;
using Microsoft.VisualBasic;

namespace ArkanoidClone
{
    class Program
    {
        static void Main ()
        {

            // * INIZIALIZZAZIONE FINESTRA

            Raylib.InitWindow(900,900, "Tic-tac-toe");
            Raylib.SetTargetFPS(60);

            int mousePositionX;
            int mousePositionY;

            Random random = new Random();
            int turnoXO = 0;

            bool[] isCircleVisible = new bool[9];
            bool[] isCrossVisible = new bool[9];

            for (int i = 0; i<9; i++)
            {
                isCircleVisible[i] = false;
                isCrossVisible[i] = false;
            }

            Texture bg = Raylib.LoadTexture("2D_images/bd.png");
            Texture cross = Raylib.LoadTexture("2D_images/cross.png");
            Texture circle = Raylib.LoadTexture("2D_images/circle.png");
            
            bool isCircleTurn = true;
           
            //  ************** MAIN LOOP {
            while(!Raylib.WindowShouldClose())  
            {

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib.BLACK); 

                // * GESTIONE DELL'INPUT

                mousePositionX = Raylib.GetMouseX();
                mousePositionY = Raylib.GetMouseY();

                // * DISEGNO GRIGLIA
                
                Raylib.DrawTexture(bg, 0, 0, Raylib.WHITE);

                switch (isCircleTurn){
                    case true:
                        isCircleTurn = DrawXO.DrawCircle(mousePositionX,mousePositionY,isCircleVisible, circle, isCircleTurn); 
                        //isCircleTurn = !isCircleTurn;
                        
                        break;
                    case false:
                        isCircleTurn = DrawXO.DrawCross(mousePositionX,mousePositionY,isCrossVisible, cross, isCircleTurn);  
                        //isCircleTurn = !isCircleTurn;
                        break;
                }
                
                Raylib.EndDrawing();
            }   
            //  ************** MAIN LOOP }
            Raylib.CloseWindow();
        }
    }
}
                /*
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

                */
