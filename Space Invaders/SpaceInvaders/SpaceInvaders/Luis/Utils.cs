using DAM;
using SpaceInvaders;

namespace Luis
{
    internal class Utils
    {
        private static Random random = new Random();
        public static bool isDebugging = false;

        #region DEBUG
        public static void RenderGrid(ICanvas canvas, IWindow window, float minX, float minY, float maxX, float maxY)
        {
            float width = 0.08f;
            float w = maxX - minX;
            float h = maxY - minY;

            if (window.Width < 500 || window.Height < 500)
                width *= 2;
            if (window.Width < 300 || window.Height < 300)
                width *= 2;

            for (float i = minX; i <= maxX; i += 1)
            {
                FillRectangle(canvas, i, minY, width, h, Color.Grey(0.6f));
            }
            for(float i = minY; i <= maxY; i+= 1)
            {
                FillRectangle(canvas, minX, i, w, width, Color.Grey(0.6f));
            }
        }
        public static void RenderGrid(ICanvas canvas, IWindow window, Vector2 x, Vector2 y)
        {
            float width = 0.08f;
            Vector2 size = Vector2.Diference(x, y);

            if (window.Width < 500 || window.Height < 500)
                width *= 2;
            if (window.Width < 300 || window.Height < 300)
                width *= 2;

            for (float i = x.Min(); i <= x.Max(); i += 1)
            {
                FillRectangle(canvas, i, y.Min(), width, size.y, Color.Grey(0.6f));
            }
            for (float i = y.Min(); i <= y.Max(); i += 1)
            {
                FillRectangle(canvas, x.Min(), i, size.x, width, Color.Grey(0.6f));
            }
        }
        public static void SetDebugMode(IKeyboard keyboard)
        {
            if (keyboard.IsKeyDown(Keys.LeftShift))
                isDebugging = true;
            else
                isDebugging = false;
        }
        public static void Debug(ICanvas canvas, IWindow window, World world)
        {
            if (isDebugging)
                RenderGrid(canvas, window, world.X, world.Y);
        }
        #endregion

        #region UTILS
        public static float RandomRange(float min, float max)
        {
            return (float)random.NextDouble() * (max - min) + min;
        }
        public static void FillRectangle(ICanvas canvas, float x, float y, float w, float h, RGBA color)
        {
            canvas.FillRectangle(x, y, w, h, (float)color.r, (float)color.g, (float)color.b, (float)color.a);
        }
        public static float PingPong(float incrementalValue)
        {
            return ((float)Math.Sin(SpaceInvaders.SpaceInvaders.time) + 1f) / 2f;
        }
        public static float PingPong(float incrementalValue, float maxValue)
        {
            return (((float)Math.Sin(incrementalValue) + 1f) / 2f)*maxValue;
        }
        public static void ClearCanvas(ICanvas canvas, RGBA color)
        {
            canvas.Clear((float)color.r, (float)color.g, (float)color.b, (float)color.a);
        }
        public static float AspectRatio(int width, int height)
        {
            return (float)width / (float)height;
        }
        #endregion
    }
}
