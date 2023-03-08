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
            float dimX = Dimensions().x / 2;
            float dimY = Dimensions().y / 2;
            float width = 0.005f;

            if (World.window.Width < 300 || World.window.Height < 300)
                width = 0.01f;

            for (float i = -dimX; i < dimX; i += Meter(Dimensions().x))
            {
                FillRectangle(canvas, i, -dimY, width, dimY * 2, grey);
            }
            for(float i = -dimY; i < dimY; i+= Meter(Dimensions().y))
            {
                FillRectangle(canvas, -dimX, i, dimX * 2, width, grey);
            }
        }
        public static float RandomRange(float min, float max)
        {
            return (float)random.NextDouble() * (max - min) + min;
        }

        public static void FillRectangle(ICanvas canvas, float x, float y, float w, float h, RGBA color)
        {
            canvas.FillRectangle(x, y, w, h, (float)color.r, (float)color.g, (float)color.b, (float)color.a);
        }
    }
}
