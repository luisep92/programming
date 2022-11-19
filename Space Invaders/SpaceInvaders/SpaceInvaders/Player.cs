using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class Player : Component
    {
        public float speed;
        GameObject fireR;
        GameObject fireL;
        public Player(float speed, GameObject parent)
        {
            this.speed = speed;
            gameObject = parent;
        }
        public override void Behavior(ICanvas canvas)
        {
            Transform thisT = gameObject.transform;
            fireR.transform.position.y = thisT.position.y - (thisT.size.y/2f + fireR.transform.size.y/2f);
            fireR.transform.position.x = thisT.position.x - 0.8f*thisT.size.x/2;
            fireL.transform.position.y = fireR.transform.position.y;
            fireL.transform.position.x = thisT.position.x + 0.8f * thisT.size.x / 2;

            fireR.Behavior(canvas);
            fireL.Behavior(canvas);
        }
        public void Init(IAssetManager manager)
        {
            fireR = Fire(manager);
            fireL = Fire(manager);
        }
        public static GameObject prefab(IAssetManager manager)
        {
            GameObject go = new GameObject();
            go.transform.size = new Vector2(2,2);
            Renderer ren = new Renderer(go);
            ren.sprites.Add(manager.LoadImage("resources/ship2.png"));
            ren.sprites.Add(manager.LoadImage("resources/ship2L.png"));
            ren.sprites.Add(manager.LoadImage("resources/ship2R.png"));
            ren.sprite = ren.sprites[0];
            go.AddComponent(new Player(2f, go));
            go.AddComponent(ren);
            return go;
        }
        public static GameObject Fire(IAssetManager manager)
        {
            GameObject go = new GameObject();
            go.transform.size.x = 0.5f;
            Renderer ren = new Renderer(go);
            ren.sprites.Add(manager.LoadImage("resources/fire1.png"));
            ren.sprites.Add(manager.LoadImage("resources/fire2.png"));
            ren.sprite = ren.sprites[0];
            go.AddComponent(ren);
            return go;
        }
    }
}
