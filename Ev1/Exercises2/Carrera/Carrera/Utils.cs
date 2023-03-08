using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera
{
    internal class Utils
    {
        private static Random random = new Random();

        public static double RandomRange(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}
