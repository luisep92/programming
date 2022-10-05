using System;

namespace Exercises
{
    internal class Vector3
    {
        public double x;
        public double y;
        public double z;

        public Vector3(double a, double b, double c)
        {
            x = a;
            y = b;
            z = c;
        }
        public Vector3(double a, double b)
        {
            x = a;
            y = b;
            z = 0;
        }
        public static double Distance(Vector3 a, Vector3 b)
        {
            double distX = a.x - b.x;
            double distY = a.y - b.y;
            double distZ = a.z - b.z;

            return Math.Sqrt(distX * distX + distY * distY + distZ * distZ);
        }
        public static double Magnitude(Vector3 a)
        {
            return Math.Sqrt(a.x*a.x + a.y*a.y + a.z*a.z);
        }
    }
}
