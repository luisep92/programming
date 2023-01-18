using DAM;

namespace Luis
{
    internal class Utils
    {
        private static Random random = new Random();
        public static bool isDebugging = false;

        #region DEBUG
        public static void RenderGrid(ICanvas canvas, float minX, float minY, float maxX, float maxY)
        {
            float width = 0.08f;
            float w = maxX - minX;
            float h = maxY - minY;

            for (float i = minX; i <= maxX; i += 1)
            {
                FillRectangle(canvas, i, minY, width, h, Color.Grey(0.6f));
            }
            for(float i = minY; i <= maxY; i+= 1)
            {
                FillRectangle(canvas, minX, i, w, width, Color.Grey(0.6f));
            }
        }
        public static void RenderGrid(ICanvas canvas, Vector2 x, Vector2 y)
        {
            float width = 0.03f;
            Vector2 size = Vector2.Diference(x, y);

            for (float i = x.Min; i <= x.Max; i += 1)
            {
                FillRectangle(canvas, i, y.Min, width, size.y, Color.Grey(0.6f));
            }
            for (float i = y.Min; i <= y.Max; i += 1)
            {
                FillRectangle(canvas, x.Min, i, size.x, width, Color.Grey(0.6f));
            }
        }
        public static void SetDebugMode(IKeyboard keyboard)
        {
            if (Input.GetKeyDown(keyboard, Keys.LeftShift))
                isDebugging = true;
            if (Input.GetKeyUp(keyboard, Keys.LeftShift))
                isDebugging = false;
        }
        public static void Debug(ICanvas canvas, Scene world)
        {
            if (isDebugging)
                RenderGrid(canvas, world.X, world.Y);
        }
        #endregion

        #region UTILS
        public static float RandomRange(float min, float max)
        {
            return (float)random.NextDouble() * (max - min) + min;
        }
        public static void FillRectangle(ICanvas canvas, float x, float y, float w, float h, RGBA color)
        {
            canvas.FillShader.SetColor(color);
            canvas.Transform.SetTranslation(0, 0);
            canvas.FillRectangle(new Rect2D(x, y, w, h));
        }
        public static float PingPong(float incrementalValue)
        {
            return ((float)Math.Sin(ChessGame.Game.Time) + 1f) / 2f;
        }
        public static float PingPong(float incrementalValue, float maxValue)
        {
            return (((float)Math.Sin(incrementalValue) + 1f) / 2f)*maxValue;
        }
        
        public static float AspectRatio(int width, int height)
        {
            return (float)width / (float)height;
        }
        #endregion
    }
}
