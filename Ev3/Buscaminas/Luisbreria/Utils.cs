using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper2
{
    public class Utils
    {
        static Random r = new Random();

        public static double RandomRange(double min, double max)
        {
            if (min < max)
                return RandomRange(max, min);

            return r.NextDouble() * (max - min) + min;
        }

        public static int RandomRangeInt(int min, int max)
        {
            if (min < max)
                return RandomRangeInt(max, min);

            int res = (int)RandomRange(min, max);
            if (res == max)
                return RandomRangeInt(min, max);

            return (int)RandomRange(min, max);
        }
    }
}
