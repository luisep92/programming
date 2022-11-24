using DAM;
using static Luis.Utils;
using static Luis.Color;
using Luis;

namespace SpaceInvaders
{
    internal class SpaceInvaders : IGameDelegate
    {
        public static World world = new World();
        public void OnDraw(IAssetManager manager, IWindow window, ICanvas canvas)
        {
            Time.UpdateDeltaTime();
            world.SetCamera(canvas, world);
            ClearCanvas(canvas, black);
            Debug(canvas, window, world);
            world.OnDrawBehavior(canvas, manager, world);
            Spawner.SpawnEnemies(manager, world);
            world.PoolObjects();
            GameObject.InstanceAndDestroyObjects(world);
        }
        public void OnKeyboard(IAssetManager manager, IWindow window, IKeyboard keyboard, IMouse mouse)
        {
            SetDebugMode(keyboard);
            world.InputBehavior(keyboard, manager, world);

            if (Input.GetKeyDown(keyboard, Keys.F)) //TEST ENEMIGOS
            {
                float posX = RandomRange(world.X.Min() + 2, world.X.Max() - 2);
                GameObject.Instantiate(Enemy.Prefab(manager), new Vector2(posX, world.Y.Max() - 2));
            }
        }

        public void OnLoad(IAssetManager manager, IWindow window)
        {
            Vector2 playerPos = new Vector2(0, world.Y.Min() + 3f);
            GameObject.Instantiate(Player.prefab(manager), playerPos);
            Particles.ChargeExplostionSprites(manager);
        }

        public void OnUnload(IAssetManager manager, IWindow window)
        {
            
        }
    }
}
