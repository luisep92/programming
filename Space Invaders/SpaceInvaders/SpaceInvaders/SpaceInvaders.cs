using DAM;
using static Luis.Utils;
using static Luis.Color;
using Luis;

namespace SpaceInvaders
{
    internal class SpaceInvaders : IGameDelegate
    {
        public void OnDraw(IAssetManager manager, IWindow window, ICanvas canvas)
        {
            Time.UpdateDeltaTime();
            canvas.SetCamera(World.X.Min(), World.Y.Min(), World.X.Max(), World.Y.Max(), true);
            ClearCanvas(canvas, black);
            Debug(canvas, window);
            World.OnDrawBehavior(canvas);
            Spawner.SpawnEnemies(manager);
            GameObject.InstanceAndDestroyObjects();
        }
        public void OnKeyboard(IAssetManager manager, IWindow window, IKeyboard keyboard, IMouse mouse)
        {
            SetDebugMode(keyboard);
            World.InputBehavior(keyboard);

            float posX = RandomRange(World.X.Min() + 2, World.X.Max() - 2);
            if(Input.GetKeyDown(keyboard,Keys.F))
                GameObject.Instantiate(Enemy.Prefab(manager), new Vector2(posX, World.Y.Max() - 2));
        }

        public void OnLoad(IAssetManager manager, IWindow window)
        {
            Vector2 playerPos = new Vector2(0, World.Y.Min() + 3f);
            GameObject.Instantiate(Player.prefab(manager), playerPos);
        }

        public void OnUnload(IAssetManager manager, IWindow window)
        {
            
        }
    }
}
