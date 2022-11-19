using DAM;
using static Luis.Utils;
using static Luis.Color;
using Luis;

namespace SpaceInvaders
{
    internal class SpaceInvaders : IGameDelegate
    {
        float t = 0;
        GameObject go = new GameObject();
        public void OnDraw(IAssetManager manager, IWindow window, ICanvas canvas)
        {
            Timer();
            canvas.SetCamera(World.X.Min(), World.Y.Min(), World.X.Max(), World.Y.Max(), true);
            ClearCanvas(canvas, black);
            if (isDebugging)
                RenderGrid(canvas, window, World.X, World.Y);
            go.Behavior(canvas);
        }

        public void OnKeyboard(IAssetManager manager, IWindow window, IKeyboard keyboard, IMouse mouse)
        {
            Renderer r = go.GetComponent<Renderer>() as Renderer;

            SetDebugMode(keyboard);
            go.Behavior(keyboard);
            if (Input.GetKeyDown(keyboard, Keys.A))
            {
                Console.WriteLine(go.transform.position.ToString());
                if(r.sprite != null)
                    Console.WriteLine("2");
            }

            if (Input.GetKeyDown(keyboard, Keys.D))
                go.SetActive(false);
            if (Input.GetKeyDown(keyboard, Keys.S))
                go.transform.position = new Vector2(2, 2);
            if (Input.GetKeyDown(keyboard, Keys.F))
                go.SetActive(true);

        }

        public void OnLoad(IAssetManager manager, IWindow window)
        {
            go = Player.prefab(manager);
            Player p = go.GetComponent<Player>() as Player;
            p.Init(manager);
        }

        public void OnUnload(IAssetManager manager, IWindow window)
        {
            
        }

        void Timer()
        {
            Time.CountTime();
        }
    }
}
