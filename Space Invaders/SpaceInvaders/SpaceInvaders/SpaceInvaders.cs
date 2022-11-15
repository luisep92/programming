using DAM;
using static Luis.Utils;
using static Luis.Color;
namespace SpaceInvaders
{
    internal class SpaceInvaders : IGameDelegate
    {
        Image img;
        public void OnDraw(IAssetManager manager, IWindow window, ICanvas canvas)
        {
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
            img = manager.LoadImage("resources/fire1");
        }

        public void OnUnload(IAssetManager manager, IWindow window)
        {
            
        }
    }
}
