using System;

namespace Exercises
{
    internal class Exercises
    {
        public static bool isEven(int n)
        {
            return n % 2 == 0;
        }

        public static bool isPrime(int n)
        {
            int max = (int)Math.Sqrt(n) + 1;

            for (int i = 2; i <= max; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        public static double GetAreaCircle(double r)
        {
            if (r < 0)
                return double.NaN;
            return Math.PI * (r * r);
        }
        public static double GetAreaRectangle(double b, double h)
        {
            if (b <= 0 || h <= 0)
                return double.NaN;
            return b * h;
        }
      //  public static double VectorDistance()
    }
}
