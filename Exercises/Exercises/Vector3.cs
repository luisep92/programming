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
        public double Magnitude(Vector3 vec)
        {
            double distX = vec.x * vec.x;
            double distY = vec.y * vec.y;
            double distZ = vec.z * vec.z;

            return Math.Sqrt(distX + distY + distZ);
        }
    }
}
