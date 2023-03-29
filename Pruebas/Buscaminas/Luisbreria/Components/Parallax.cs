using UDK;

namespace Luisbreria
{
    public class Parallax : Component
    {
        IBuffer img;

        GameObject img1;
        GameObject img2;
        GameObject img3;
        public Parallax(Scene world, GameObject parent)
        {
            this.gameObject = parent;
            this.gameObject.components.Add(this);
            this.img = world.background;
            img1 = Images(this.img, world);
            img1.transform.position = new Vector2(0, world.Y.Min);
            img2 = Images(this.img, world);
            img2.transform.position = new Vector2(0, img1.transform.position.y + img1.transform.size.y);
            img3 = Images(this.img, world);
            img3.transform.position = new Vector2(0, img2.transform.position.y + img1.transform.size.y);
        }

        public override void Behavior(ICanvas canvas, IAtomicDecoder manager, Scene world)
        {
            MoveImages();
            Recolocate(img1, img3, world);
            Recolocate(img2, img1, world);
            Recolocate(img3, img2, world);
            img1.Behavior(canvas, manager, world);

            img2.Behavior(canvas, manager, world);
            img3.Behavior(canvas, manager, world);
        }
        public void MoveImages()
        {
            float mov = Time.deltaTime * 1.5f;
            img1.transform.position.y -= mov;
            img2.transform.position.y -= mov;
            img3.transform.position.y -= mov;
        }

        public void Recolocate(GameObject go, GameObject go2, Scene world)
        {
            float min = world.Y.Min - go.transform.size.y / 2;
            if (go.transform.position.y < min)
                go.transform.position.y = go2.transform.position.y + go.transform.size.y;
        }

        //Revisar dimensiones preguntar a javi
        static GameObject Images(IBuffer img, Scene world)
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);
            ren.sprite = img;
            go.transform.size = new Vector2(world.Dimensions().x, world.Dimensions().x / Utils.AspectRatio(img., img.Dimensions.Height));
            return go;
        }
        public static GameObject Background(Scene world)
        {
            GameObject go = new GameObject();
            Parallax par = new Parallax(world, go);

            return go;
        }
    }
}
