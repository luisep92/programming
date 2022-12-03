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
            world.OnDrawBehavior(canvas, manager, world);
            Spawner.SpawnObjects(manager, world);
            world.PoolObjects();
            GameObject.InstanceAndDestroyObjects(world);

            Utils.FillRectangle(canvas, world.X.Min(), world.Y.Min(), -15, world.Dimensions().y, black);
            Utils.FillRectangle(canvas, world.X.Max(), world.Y.Min(), 15, world.Dimensions().y, black); 
            Overlay.RenderHUD(canvas);
            Debug(canvas, window, world);
            if (Player.instance.health == 0)
                window.Close();
        }
        public void OnKeyboard(IAssetManager manager, IWindow window, IKeyboard keyboard, IMouse mouse)
        {
            SetDebugMode(keyboard);
            world.InputBehavior(keyboard, manager, world);

         /*   if (Input.GetKeyDown(keyboard, Keys.F)) //TEST ENEMIGOS
            {
                float posX = RandomRange(world.X.Min() + 2, world.X.Max() - 2);
                GameObject m = GameObject.Instantiate(Meteor.Prefab(), new Vector2(world.X.Min()-3, 0));
                if (m.GetComponent<Meteor>().reverse)
                    m.transform.position.x *= -1;
            }*/
        }

        public void OnLoad(IAssetManager manager, IWindow window)
        {
            world.background = manager.LoadImage("resources/background.jpg");
            GameObject.Instantiate(Parallax.Background(world), Vector2.Zero);
            Vector2 playerPos = new Vector2(0, world.Y.Min() + 3f);
            GameObject player =  GameObject.Instantiate(Player.prefab(manager), playerPos);
            Player.instance = player.GetComponent<Player>();
            Enemy.FillImageList(manager);
            Particles.FillSpriteList(manager);
            EnemyMad.FillSpriteList(manager);
            PowerUp.SetSprites(manager);
            Meteor.SetSprite(manager);
            Overlay.Init(world, manager);

        }

        public void OnUnload(IAssetManager manager, IWindow window)
        {
            
        }
    }
}
