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
            Spawner.SpawnObjects(manager, world);
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
                GameObject.Instantiate(PowerUp.SpeedPrefab(), new Vector2(0, 5));
            }
            
        }

        public void OnLoad(IAssetManager manager, IWindow window)
        {
            world.background = manager.LoadImage("resources/background.jpg");
            GameObject.Instantiate(Parallax.Background(world), Vector2.Zero);
            Vector2 playerPos = new Vector2(0, world.Y.Min() + 3f);
            GameObject player =  GameObject.Instantiate(Player.prefab(manager), playerPos);
            Enemy.FillImageList(manager);
            Particles.FillSpriteList(manager);
            EnemyMad.FillSpriteList(manager);
            PowerUp.SetSprites(manager);
            GameObject hud = GameObject.Instantiate(Overlay.HUD(player), new Vector2(world.X.Max() + 2, 0));
            hud.GetComponent<Overlay>().Init(world, manager);
        }

        public void OnUnload(IAssetManager manager, IWindow window)
        {
            
        }
    }
}
