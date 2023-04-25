using UDK;

namespace Luisbreria
{
    public class Input
    {
        static List<Keys> pressedKeys = new List<Keys>();
        static List<Keys> PressedKeysUp = new List<Keys>();

        public static bool GetKeyDown(IKeyboard k, Keys key)
        {
            bool exist = IsInList(key, pressedKeys);
            bool isDown = k.IsKeyDown(key);

            if (isDown && !exist)
            {
                pressedKeys.Add(key);
                return true;
            }
            if (!isDown && exist)
                pressedKeys.Remove(key);
            return false;
        }
        public static bool GetKeyUp(IKeyboard k, Keys key)
        {
            bool exist = IsInList(key, PressedKeysUp);
            bool isDown = k.IsKeyDown(key);

            if (!isDown && exist)
            {
                PressedKeysUp.Remove(key);
                return true;
            }
            if (isDown && !exist)
                PressedKeysUp.Add(key);
            return false;
        }
        public static bool GetKey(IKeyboard k, Keys key)
        {
            return k.IsKeyDown(key);
        }
        public static bool IsInList(Keys key, List<Keys> list)
        {
            foreach (Keys k in list)
            {
                if (k == key)
                    return true;
            }
            return false;
        }
    }
}