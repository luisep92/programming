using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class Utils
    {
        static Random r = new Random();

        public static double RandomRange(double min, double max)
        {
            if (min > max)
                return RandomRange(max, min);
            return (r.NextDouble() * (max - min)) + min;
        }

        public static bool Probability(double percent)
        {
            return percent >= RandomRange(0.0, 100.0);
        }
    }
}
