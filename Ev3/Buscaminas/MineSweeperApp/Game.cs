using DAM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperApp
{
    internal class Game : IGameDelegate
    {
        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {

            canvas.Camera.SetRect(new Rect2D(1, 1, 8, 8));
            canvas.Clear(new RGBA(0.2, 0.2, 0.2, 1));
            canvas.FillShader.SetColor(new RGBA(1,0,1,1));
            canvas.Transform.SetTranslation(1, 1);
            canvas.FillRectangle(new Rect2D(0, 0, 8, 8));
        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {

        }

        public void OnLoad(GameDelegateEvent gameEvent)
        {

        }

        public void OnUnload(GameDelegateEvent gameEvent)
        {

        }
    }
}
