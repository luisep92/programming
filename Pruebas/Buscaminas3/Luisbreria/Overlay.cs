using UDK;

namespace Luisbreria
{
    public class Overlay
    {
        static IBuffer hpImage;
        static Vector2 position;

        public static void RenderHUD(ICanvas canvas)
        {
            /*float posy = 3 * Player.instance.health / 2;
            for (int i = 0; i < Player.instance.health; i++)
            {
                canvas.FillRectangle(position.x,posy, 3, 3, hpImage, 0, 0, 1, 1, 1, 1, 1, 0.99999f);
                posy -= 3;
            }*/
        }
        public static void Init(Scene world, IAtomicDecoder manager)
        {
            /*hpImage = manager.LoadImage("resources/heart.png");
            position = new Vector2(world.X.Max() + 2, 0);*/
        }
    }
}
