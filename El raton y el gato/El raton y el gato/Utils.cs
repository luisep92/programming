using DAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using static El_raton_y_el_gato.TomAndJerry;

namespace El_raton_y_el_gato
{
    internal class Utils
    {
        private static Random random = new Random();
        public static float AspectRatio(IWindow window)
        {
            return (float)window.Width / (float)window.Height;
        }
        public static float AspectRatio(float x, float y)
        {
            return x / y;
        }

        public static void RenderGrid(ICanvas canvas)
        {
            for (float i = -1; i < Dimensions().x; i += 2 / Dimensions().x)
            {
                canvas.FillRectangle(i, -1, 0.003f, 2, 0.7f, 0.7f, 0.7f, 0.5f);
            }
            for(float i = -1; i < Dimensions().y; i+= 2 / Dimensions().y)
            {
                canvas.FillRectangle(-1, i, 2, 0.003f, 0.7f, 0.7f, 0.7f, 0.5f);
            }
        }
        

        public static float RandomRange(float min, float max)
        {
            return (float)random.NextDouble() * (max - min) + min;
        }
    }
}
