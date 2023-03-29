using UDK;

namespace Luisbreria
{
    /// <summary>
    /// Utilities
    /// </summary>
    public class Utils
    {
        static Random r = new Random();
        public static bool isDebugging = false;

        public static double RandomRange(double min, double max)
        {
            if (min < max)
                return RandomRange(max, min);

            return r.NextDouble() * (max - min) + min;
        }

        
        /// <summary>
        /// Gets a random int between a range
        /// </summary>
        /// <param name="min">The min parameter of the range</param>
        /// <param name="max">The max parameter of the range</param>
        /// <returns>A random int between a range</returns>
        public static int RandomRangeInt(int min, int max)
        {
            if (min < max)
                return RandomRangeInt(max, min);

            int res = (int)RandomRange(min, max);
            if (res == max)
                return RandomRangeInt(min, max);

            return (int)RandomRange(min, max);
        }





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
            for (float i = minY; i <= maxY; i += 1)
            {
                FillRectangle(canvas, minX, i, w, width, Color.Grey(0.6f));
            }
        }
        
        public static void RenderGrid(ICanvas canvas, Vector2 x, Vector2 y)
        {
            RenderGrid(canvas, x.Min, x.Max, y.Min, y.Max);
        }
        #endregion
        #region UTILS
        /*public static bool IsInList(Position pos, List<Position> list)
        {
           float width = 0.03f;
           Vector2 size = Vector2.Diference(x, y);

           for (float i = x.Min; i <= x.Max; i += 1)
           {
               FillRectangle(canvas, i, y.Min, width, size.y, Color.Grey(0.6f));
           }
           for (float i = y.Min; i <= y.Max; i += 1)
               for (int i = 0; i < list.Count; i++)
               {
                   FillRectangle(canvas, x.Min, i, size.x, width, Color.Grey(0.6f));
                   if (pos == list[i])
                       return true;
               }
        }*/
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
            return (float)r.NextDouble() * (max - min) + min;
        }

        //REVISAR
        public static void FillRectangle(ICanvas canvas, float x, float y, float w, float h, rgba_f64 color)
        {
            canvas.FillShader.SetColor(color);
            canvas.Transform.SetTranslation(0, 0);
            canvas.DrawRectangle(new rect2d_f64(x, y, w, h));
        }

        //REVISAR LOS 2 PING PONG
        public static float PingPong(float incrementalValue)
        {
            return ((float)Math.Sin(Time.AppTime) + 1f) / 2f;
        }
        public static float PingPong(float incrementalValue, float maxValue)
        {
            return (((float)Math.Sin(incrementalValue) + 1f) / 2f) * maxValue;
        }

        public static float AspectRatio(int width, int height)
        {
            return (float)width / (float)height;
        }

        //REVISAR COMO SE CARGAN IMAGENES
        public static IBuffer LoadImage(string path, GameDelegateEvent gameEvent)
        {
            try
            {
                return gameEvent.canvasContext.LoadImageFromFile("resources/david.png");
            }
            catch
            {
                throw new Exception("Ruta de cargar imagen invalida: " + path);
            }
        }
        #endregion
    }
}
   
