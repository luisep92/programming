using DAM;
using static Luis.Utils;
using static Luis.Color;
namespace SpaceInvaders
{
    internal class SpaceInvaders : IGameDelegate
    {
        Image img;
        int t = 0;
        public void OnDraw(IAssetManager manager, IWindow window, ICanvas canvas)
        {
            Time.CountTime();
            if(t != (int)Time.dTime)
                Console.WriteLine(t);
            t = (int)Time.dTime;
            canvas.SetCamera(World.X.Min(), World.Y.Min(), World.X.Max(), World.Y.Max(), true);
            ClearCanvas(canvas, black);
            if (isDebugging)
                RenderGrid(canvas, window, World.X, World.Y);
        }

        public void OnKeyboard(IAssetManager manager, IWindow window, IKeyboard keyboard, IMouse mouse)
        {
            SetDebugMode(keyboard);
        }

        public void OnLoad(IAssetManager manager, IWindow window)
        {
            img = manager.LoadImage("resources/fire1.png");
        }

        public void OnUnload(IAssetManager manager, IWindow window)
        {
            
        }
    }
}
