﻿using LunarLabs.Fonts;
using UDK;
using BuscaminasLib;
using System.Runtime.CompilerServices;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace MineSweeperApp
{
    internal class MineSweeper : IGameDelegate
    {
        IFontFace? font;
        IBoard board = new Board2(15, 20, 5);
        bool winCondition = false;
        IImage image;
        ISound music;

        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {
            var rect = new rect2d_f64(-0, 0, board.GetWidth(), board.GetHeight());

            canvas.Clear(new rgba_f64(0.2, 0.3, 0.3, 1.0));
            canvas.Camera.SetRect(rect, true);

            canvas.FillShader.SetColor(new rgba_f64(0.0, 0.0, 1.0, 1.0));
            canvas.Transform.SetIdentity();
            canvas.DrawRectangle(rect);


            if (!winCondition)
                PaintCells(board.GetWidth(), board.GetHeight(), canvas);
            else
            {
                canvas.FillShader.SetImage(image, new rgba_f64(1, 1, 1, 1.0));
                canvas.Transform.SetIdentity();
                canvas.DrawRectangle(rect);
            }
        }

        private void PaintCells(int w, int h, ICanvas canvas)
        {
            for(int i = 0; i < w; i++)
            {
                for(int j = 0; j < h; j++)
                {
                    var cellRect = new rect2d_f64(0.03, 0.03, 0.94, 0.94);
                    SetColor(i,j, canvas);
                    canvas.Transform.SetTranslation(i,board.GetHeight() - 1 - j);
                    canvas.DrawRectangle(cellRect);

                    canvas.Transform.Translate(0.4, 0.35);
                    canvas.FillShader.SetColor(new rgba_f64(0, 0, 0, 1));
                    canvas.DrawText(new vec2d_f64(0, 0), SetText(i, j), font, new TextMode() { height = 0.5, bottomCoords = false });

                }
            }
        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {
            if (keyboard.IsKeyPressed(UDK.Keys.R))
                board = new Board2(board.GetWidth(), board.GetHeight(), 40);

            if(!winCondition)
                GameInputs(gameEvent, keyboard, mouse);
        }

        public void OnLoad(GameDelegateEvent gameEvent)
        {
            try
            {
                font = gameEvent.canvasContext.CreateFont(CODEC.LoadFontFromFiles("resources/ArialCE.ttf"))?.CreateFontFace(64.0);
                image = gameEvent.canvasContext.LoadImageFromFile("resources/david.png");
                music = gameEvent.audioContext.LoadSoundFromFile("resources/win.ogg");
            }
            catch
            {
                throw new Exception("Error when charging resources");
            }
            
        }

        public void OnUnload(GameDelegateEvent gameEvent)
        {

        }


        //Define the inputs of the game
        void GameInputs(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {
            var pos = gameEvent.coordinateConversor.ViewToWorld(mouse.X, mouse.Y);
            int x = (int)pos.x;
            int y = (int)(board.GetHeight() - pos.y);
            if (mouse.IsPressed(UDK.MouseButton.Left))
            {
                board.Init(x, y);
                board.OpenCell(x, y);
                board.DrawOnConsole();
                
            }
            if (mouse.IsPressed(UDK.MouseButton.Right))
            {
                if (board.IsFlagAt(x, y))
                    board.RemoveFlagAt(x, y);
                else
                    board.PutFlagAt(x, y);
            }
            if (mouse.IsReleased(UDK.MouseButton.Left))
            {
                if (board.HasWin())
                {
                    winCondition = true;
                    gameEvent.audioThread.AcquirePlayer()?.SetSound(music, false, true).Play();
                }
                if (board.IsBombAt(x, y) && board.IsOpenCell(x, y))
                    board = new Board2(board.GetWidth(), board.GetHeight(), 40);
            }
        }

        //Set color of a cell depending of its state
        void SetColor(int x, int y, ICanvas canvas)
        {
            if (board.IsBombAt(x, y) && board.IsOpenCell(x, y))
                canvas.FillShader.SetColor(new rgba_f64(1, 0, 0, 1));
            else if (board.IsOpenCell(x, y))
                canvas.FillShader.SetColor(new rgba_f64(0, 1, 0, 1));
            else if (board.IsFlagAt(x,y))
                canvas.FillShader.SetColor(new rgba_f64(1, 1, 0, 1));
            else
                canvas.FillShader.SetColor(new rgba_f64(0.3, 0.3, 0.3, 1));
        }

        //Set the text of a cell depending of its state
        string SetText(int x, int y)
        {
            if (board.IsBombAt(x, y) && board.IsOpenCell(x, y))
               return "B";
            if (board.IsOpenCell(x, y))
            {
                int b = board.GetBombsAround(x, y);
                if (b != 0)
                    return board.GetBombsAround(x, y).ToString();
                else return " ";
            }
            else if (board.IsFlagAt(x, y))
                return "F";
            else
                return " ";
        }
    }
}
