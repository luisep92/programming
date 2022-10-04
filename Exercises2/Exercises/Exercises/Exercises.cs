using System;
using System.Diagnostics;

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
        public static string GetPrimes(int n)
        {
            string result = "";

            for(int i = 1; i <= n; i++)
            {
                if (isPrime(i))
                {
                    if (i != 1)
                        result += ",";
                    result += i;
                }
            }
            return result;
        }
        public static string GenerateFibonacci(int n)
        {
            string result = "0";
            int a = 0, b = 1, t = 0;

            while(a+b <= n)
            {
                t = a;
                a = a + b;
                b = t;

                result += "," + a;
            }
            return result;
        }
        public static string SeparateCharacters(string a)
        {
            for(int i = 1; i < a.Length; i+= 2)
            {
                a = a.Insert(i, "-");
            }
            return a;
        }

        public static bool isBetweenChars(char a, char b, char c)
        {
            if (a >= Math.Min(b,c) && a <= Math.Max(b,c))
                return true;
            else 
                return false;
        }
    }
}
