using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_raton_y_el_gato
{
    internal class World
    {
        public static DAM.Window window;
       
        public static Vector2 Dimensions()
        {
            float width = 40;
            return new Vector2(width, width / Utils.AspectRatio(World.window));
        }
        public static float Meter(float axis)
        {
            return (1f / (axis / 2f));
        }
    }
}
