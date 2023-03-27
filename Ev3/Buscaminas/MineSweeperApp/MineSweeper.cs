using LunarLabs.Fonts;
using UDK;

namespace MineSweeperApp
{
    internal class MineSweeper : IGameDelegate
    {
        IFontFace? font;

        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {
            int w = 10;
            int h = 10;
            var rect = new rect2d_f64(-0, 0, w, h);

            canvas.Clear(new rgba_f64(0.2, 0.3, 0.3, 1.0));
            canvas.Camera.SetRect(rect, true);

            canvas.FillShader.SetColor(new rgba_f64(0.0, 0.0, 1.0, 1.0));
            canvas.Transform.SetIdentity();
            canvas.DrawRectangle(rect);

            PaintCells(w, h, canvas);
        }

        private void PaintCells(int w, int h, ICanvas canvas)
        {
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    var cellRect = new rect2d_f64(0.03, 0.03, 0.94, 0.94);
                    canvas.FillShader.SetColor(new rgba_f64(0.3, 0.3, 0.3, 1));
                    canvas.Transform.SetTranslation(i, j);
                    canvas.DrawRectangle(cellRect);

                    canvas.Transform.Translate(0.3, 0.3);
                    canvas.FillShader.SetColor(new rgba_f64(1, 1, 1, 1));
                    canvas.DrawText(new vec2d_f64(0, 0), (i + j * h).ToString(), font, new TextMode() { height = 0.5, bottomCoords = false });

                }
            }
        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {

        }

        public void OnLoad(GameDelegateEvent gameEvent)
        {
            font = gameEvent.canvasContext.CreateFont(CODEC.LoadFontFromFiles("resources/ArialCE.ttf"))?.CreateFontFace(64.0);

        }

        public void OnUnload(GameDelegateEvent gameEvent)
        {

        }
    }
}
