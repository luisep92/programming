using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class Particles
    {

        public static GameObject Explosion(IAssetManager manager)
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);
            Animator anim = new Animator(ren, 1f/20f, go, true);

            go.transform.size = new Vector2(3, 3);

            for(int i = 1; i < 20; i++)
            {
                ren.sprites.Add(manager.LoadImage("resources/Explosion/" + i + ".png"));
            }
            ren.sprite = ren.sprites[0];

            return go;
        }
    }
}
