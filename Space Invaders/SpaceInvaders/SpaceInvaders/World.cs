using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class World
    {
        public static Vector2 X = new Vector2(-12, 12);
        public static Vector2 Y = new Vector2(-15, 15);
        public static List<GameObject> WorldObjects = new List<GameObject>();

        public static Vector2 Dimensions()
        {
            return Vector2.Diference(X, Y);
        }

        public static void InputBehavior(IKeyboard kb)
        {
            foreach (GameObject go in WorldObjects)
            {
                go.Behavior(kb);
            }
        }

        public static void OnDrawBehavior(ICanvas canvas)
        {
            foreach (GameObject go in WorldObjects)
            {
                go.Behavior(canvas);
            }
        }
    }
}
