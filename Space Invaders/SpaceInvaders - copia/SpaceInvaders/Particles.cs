using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class Particles
    {
        static List<Image> explosionSprites = new List<Image>();

        public static void FillSpriteList(IAssetManager manager)
        {
            for (int i = 1; i < 20; i++)
            {
                explosionSprites.Add(manager.LoadImage("resources/Explosion/" + i + ".png"));
            }
        }
        public static GameObject Explosion(IAssetManager manager)
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);
            Animator anim = new Animator(ren, 1f/20f, go, true);

            go.transform.size = new Vector2(3, 3);

            ren.sprites = explosionSprites;
            ren.sprite = ren.sprites[0];

            return go;
        }
    }
}
