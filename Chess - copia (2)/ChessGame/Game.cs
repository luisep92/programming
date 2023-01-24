using ChessLib;
using DAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Game : IGameDelegate
    {
        Board b = new Board();
        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {
            Renderer.canvas = canvas;
            canvas.Camera.SetRect(new Rect2D(1,1,8,8));
            canvas.Clear(Luis.Color.grey);
            Renderer.DrawBoard();
        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {
            
        }

        public void OnLoad(GameDelegateEvent gameEvent)
        {
            Renderer.FigureImages = Renderer.LoadImages(gameEvent);
        }

        public void OnUnload(GameDelegateEvent gameEvent)
        {
            
        }
    }
}
