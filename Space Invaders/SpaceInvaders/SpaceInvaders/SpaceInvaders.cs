using DAM;
using static Luis.Utils;
using static Luis.Color;
using Luis;

namespace SpaceInvaders
{
    internal class SpaceInvaders : IGameDelegate
    {
        public static World world = new World();
        public static float time = 0;

        public void OnDraw(IAssetManager manager, IWindow window, ICanvas canvas)
        {
            Time.UpdateDeltaTime();
            time += Time.deltaTime * 1f;
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
                GameObject.Instantiate(Enemy.Prefab(manager), new Vector2(0, 5));
            }
            
        }

        public void OnLoad(IAssetManager manager, IWindow window)
        {
            Vector2 playerPos = new Vector2(0, world.Y.Min() + 3f);
            GameObject.Instantiate(Player.prefab(manager), playerPos);
            Enemy.FillImageList(manager);
            Particles.FillSpriteList(manager);
            EnemyMad.FillSpriteList(manager);
            world.background = manager.LoadImage("resources/background.jpg");
        }

        public void OnUnload(IAssetManager manager, IWindow window)
        {
            
        }
    }
}
