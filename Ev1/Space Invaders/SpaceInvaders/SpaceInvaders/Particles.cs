using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class Particles
    {
        static List<Image> explosionSprites = new List<Image>();
        static List<Image> explosion2Images = new List<Image>();

        public static void FillSpriteList(IAssetManager manager)
        {
            for (int i = 1; i < 20; i++)
            {
                explosionSprites.Add(manager.LoadImage("resources/Explosion/" + i + ".png"));
            }
            for (int i = 1; i < 15; i++)
            {
                explosion2Images.Add(manager.LoadImage("resources/Explosion2/" + i + ".png"));
            }
        }

        public static GameObject RandomExplosion()
        {
            if ((int)Utils.RandomRange(1, 2.99999f) == 1)
                return Explosion();
            else
                return Explosion2();
        }

        public static GameObject Explosion()
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);
            Animator anim = new Animator(ren, 1f/20f, go, true);

            go.transform.size = new Vector2(3, 3);

            ren.sprites = explosionSprites;
            ren.sprite = ren.sprites[0];

            return go;
        }
        public static GameObject Explosion2()
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);
            Animator anim = new Animator(ren, 1f / 15f, go, true);

            go.transform.size = new Vector2(3, 3);

            for (int i = 1; i < 20; i++)
            {
                ren.sprites = explosion2Images;
            }
            ren.sprite = ren.sprites[0];

            return go;
        }
    }
}
