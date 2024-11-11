using System.Numerics;
using Raylib_CsLo;
using System;
using Microsoft.VisualBasic;

public class DrawXO
{
    public static bool DrawCircle (int mousePositionX, int mousePositionY,bool[] isCircleVisible, Texture circle, bool isCircleTurn)
    {     
        // *========================================================
        // POSIZIONE 1
        if (mousePositionX > 0 && mousePositionX < 300 && mousePositionY > 600 && mousePositionY < 900 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCircleVisible[0] = true;
                   isCircleTurn = false;

        }
        if (isCircleVisible[0])
        {
            Raylib.DrawTexture(circle, 40, 630, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 2
        if (mousePositionX > 300 && mousePositionX < 600 && mousePositionY > 600 && mousePositionY < 900 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCircleVisible[1] = true;
                   isCircleTurn = false;

        }

        if (isCircleVisible[1])
        {
            Raylib.DrawTexture(circle, 340, 630, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 3
        if (mousePositionX > 600 && mousePositionX < 900 && mousePositionY > 600 && mousePositionY < 900 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCircleVisible[2] = true;
                   isCircleTurn = false;

        }
        if (isCircleVisible[2])
        {
            Raylib.DrawTexture(circle, 640, 630, Raylib.WHITE);
        }
        // *========================================================
        // ? DrawCircle( CENTRO_X , CENTRO_Y , RAGGIO , COLORE );
        // *========================================================
        // POSIZIONE 4
        if (mousePositionX > 0 && mousePositionX < 300 && mousePositionY > 300 && mousePositionY < 600 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCircleVisible[3] = true;
            isCircleTurn = false;

        }
        if (isCircleVisible[3])
        {
            Raylib.DrawTexture(circle, 40, 345, Raylib.WHITE);
        }
        // *========================================================
        // ? DrawCircle( CENTRO_X , CENTRO_Y , RAGGIO , COLORE );
        // *========================================================
        // POSIZIONE 5
        if (mousePositionX > 300 && mousePositionX < 600 && mousePositionY > 300 && mousePositionY < 600 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCircleVisible[4] = true;
            isCircleTurn = false;

        }
        if (isCircleVisible[4])
        {
            Raylib.DrawTexture(circle, 340, 345, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 6
        if (mousePositionX > 600 && mousePositionX < 900 && mousePositionY > 300 && mousePositionY < 600 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCircleVisible[5] = true;
            isCircleTurn = false;
        }
        if (isCircleVisible[5])
        {
            Raylib.DrawTexture(circle, 640, 345, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 7
        if (mousePositionX > 0 && mousePositionX < 300 && mousePositionY > 0 && mousePositionY < 300 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCircleVisible[6] = true;
            isCircleTurn = false;
        }
        if (isCircleVisible[6])
        {
            Raylib.DrawTexture(circle, 40, 50, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 8
        if (mousePositionX > 300 && mousePositionX < 600 && mousePositionY > 0 && mousePositionY < 300 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCircleVisible[7] = true;
            isCircleTurn = false;
        }
        if (isCircleVisible[7])
        {
            Raylib.DrawTexture(circle, 340, 50, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 9
        if (mousePositionX > 600 && mousePositionX < 900 && mousePositionY > 0 && mousePositionY < 300 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCircleVisible[8] = true;
            isCircleTurn = false;
        }
        if (isCircleVisible[8])
        {
            Raylib.DrawTexture(circle, 640, 50, Raylib.WHITE);
        }
        // *========================================================

       return isCircleTurn;
    }

    public static bool DrawCross (int mousePositionX, int mousePositionY,bool[] isCrossVisible, Texture cross, bool isCircleTurn)
    {     
        // *========================================================
        // POSIZIONE 1
        if (mousePositionX > 0 && mousePositionX < 300 && mousePositionY > 600 && mousePositionY < 900 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCrossVisible[0] = true;
            isCircleTurn = true;
        }
        if (isCrossVisible[0])
        {
            Raylib.DrawTexture(cross, 40, 630, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 2
        if (mousePositionX > 300 && mousePositionX < 600 && mousePositionY > 600 && mousePositionY < 900 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCrossVisible[1] = true;
            isCircleTurn = true;
        }

        if (isCrossVisible[1])
        {
            Raylib.DrawTexture(cross, 340, 630, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 3
        if (mousePositionX > 600 && mousePositionX < 900 && mousePositionY > 600 && mousePositionY < 900 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCrossVisible[2] = true;
            isCircleTurn = true;
        }
        if (isCrossVisible[2])
        {
            Raylib.DrawTexture(cross, 640, 630, Raylib.WHITE);
        }
        // *========================================================
        // ? DrawCircle( CENTRO_X , CENTRO_Y , RAGGIO , COLORE );
        // *========================================================
        // POSIZIONE 4
        if (mousePositionX > 0 && mousePositionX < 300 && mousePositionY > 300 && mousePositionY < 600 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCrossVisible[3] = true;
            isCircleTurn = true;
        }
        if (isCrossVisible[3])
        {
            Raylib.DrawTexture(cross, 40, 345, Raylib.WHITE);
        }
        // *========================================================
        // ? DrawCircle( CENTRO_X , CENTRO_Y , RAGGIO , COLORE );
        // *========================================================
        // POSIZIONE 5
        if (mousePositionX > 300 && mousePositionX < 600 && mousePositionY > 300 && mousePositionY < 600 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCrossVisible[4] = true;
            isCircleTurn = true;
        }
        if (isCrossVisible[4])
        {
            Raylib.DrawTexture(cross, 340, 345, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 6
        if (mousePositionX > 600 && mousePositionX < 900 && mousePositionY > 300 && mousePositionY < 600 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCrossVisible[5] = true;
            isCircleTurn = true;
        }
        if (isCrossVisible[5])
        {
            Raylib.DrawTexture(cross, 640, 345, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 7
        if (mousePositionX > 0 && mousePositionX < 300 && mousePositionY > 0 && mousePositionY < 300 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCrossVisible[6] = true;
            isCircleTurn = true;
        }
        if (isCrossVisible[6])
        {
            Raylib.DrawTexture(cross, 40, 50, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 8
        if (mousePositionX > 300 && mousePositionX < 600 && mousePositionY > 0 && mousePositionY < 300 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCrossVisible[7] = true;
            isCircleTurn = true;
        }
        if (isCrossVisible[7])
        {
            Raylib.DrawTexture(cross, 340, 50, Raylib.WHITE);
        }
        // *========================================================
        // POSIZIONE 9
        if (mousePositionX > 600 && mousePositionX < 900 && mousePositionY > 0 && mousePositionY < 300 && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            isCrossVisible[8] = true;
            isCircleTurn = true;
        }
        if (isCrossVisible[8])
        {
            Raylib.DrawTexture(cross, 640, 50, Raylib.WHITE);
        }
        // *========================================================

        
        return isCircleTurn;

    }
}