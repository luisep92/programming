
namespace El_raton_y_el_gato
{
    internal class World
    {
        public static Vector2 X = new Vector2(-10,10);
        public static Vector2 Y = new Vector2(-5,5);

        public static Vector2 Dimensions()
        {
            return Vector2.Diference(X, Y);
        }
    }
}
