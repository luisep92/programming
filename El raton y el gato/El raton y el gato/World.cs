using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_raton_y_el_gato
{
    internal class World
    {
        public static float AspectRatio()
        {
            return Utils.AspectRatio(800, 600);
        }
        public static Vector2 Dimensions()
        {
            return new Vector2(20, 20 / AspectRatio());
        }
        public static float Meter(float axis)
        {
            return (1f / (axis / 2f));
        }
    }
}
