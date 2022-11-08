using DAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using static El_raton_y_el_gato.TomAndJerry;
using static El_raton_y_el_gato.World;

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
            RGBA grey = new RGBA(0.7f, 0.7f, 0.7f, 0.5f);

            for (float i = -Dimensions().x; i < Dimensions().x; i += Meter(Dimensions().x))
            {
                canvas.FillRectangle(i, -Dimensions().y, 0.008f, Dimensions().y*2, grey);
            }
            for(float i = -Dimensions().y; i < Dimensions().y; i+= Meter(Dimensions().y))
            {
                canvas.FillRectangle(-Dimensions().x, i, Dimensions().x*2, 0.008f, grey);
            }
        }
        public static float RandomRange(float min, float max)
        {
            return (float)random.NextDouble() * (max - min) + min;
        }
    }
}
