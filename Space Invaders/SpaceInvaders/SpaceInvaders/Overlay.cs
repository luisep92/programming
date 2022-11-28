using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class Overlay : Component
    {
        int health;
        Player player;
        public Image hpImage;


        public Overlay(GameObject parent)
        {
            this.gameObject = parent;
            parent.AddComponent(this);
        }

        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            RenderHUD(canvas);
        }
        public void RenderHUD(ICanvas canvas)
        {
            Transform thisT = this.gameObject.transform;
            float posy;
            posy = thisT.position.y;
            for(int i = 0; i < health; i++)
            {
                canvas.FillRectangle(thisT.position.x,posy, thisT.size.x, thisT.size.y, hpImage, 0, 0, 1, 1, 1, 1, 1, 0.99999f);
                posy -= thisT.size.y;
            }
        }

        public void Update()
        {
            health = player.health;
        }

        public void Init(World world, IAssetManager manager)
        {
            hpImage = manager.LoadImage("resources/heart.png");
        }
        public static GameObject HUD(GameObject player)
        {
            GameObject go = new GameObject();
            Overlay ol = new Overlay(go);
            go.transform.size = new Vector2(2, 2);
            ol.player = player.GetComponent<Player>();
            ol.health = ol.player.health;
            return go;
        }
    }
}
