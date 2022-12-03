using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class Exercises
    {
        // Venga, ..., como veo que insiste, explicaré esto en clase para que todo el mundo lo haga
        // porque es una buena idea
        #region EXERCISE 1
        // Nota: 2
        public static double Exercise1 (int a, int b)
        {
            // Te colaste aquí
            return (a + 1) / b;
        }
        #endregion
        #region EXERCISE 2
        // Nota: 4
        public static double Exercise2 (double a, double b, double c, double d, double e, double x)
        {
            // Hombre, ya de paso, podías haberlo optimizado un poco
            return a * (x * x * x * x) + b * (x * x * x) + c * (x * x) + d * (x) + e;
        }
        #endregion
        #region EXERCISE 3
        // Nota: 4
        public static int GetMinor(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j)
        {
            int result = a;
            if(result > b)
                result = b;
            if (result > c)
                result = c;
            if (result > d)
                result = d;
            if (result > e)
                result = e;
            if (result > f)
                result = f;
            if (result > g)
                result = g;
            if (result > h)
                result = h;
            if (result > i)
                result = i;
            if (result > j)
                result = j;
            return result;
        }
        #endregion
        #region EXERCISE 4

        // Pensaba que por el numero del medio te referías a "b", por eso lo hice así
        public static int GetMinor(int a, int b)
        {
            if (a < b)
                return a;
            return b;
        }
        public static int GetMajor(int a, int b)
        {
            if (a < b)
                return b;
            return a;
        }
        // Nota: 0, ..., esto no era lo que pedía el ejercicio
        public static int Exercise4(int a, int b, int c)
        {
            int dist1, dist2;
            dist1 = b - a;
            dist2 = b - c;

            if (dist1 < 0)
                dist1 *= -1;
            if (dist2 < 0)
                dist2 *= -1;

            return GetMajor(dist1, dist2);
        }
        #endregion
        #region EXERCISE 5
        // Nota: 4
        public static int GetDigits(int n)
        {
            int digits = 1;

            while(n >= 10)
            {
                digits++;
                n /= 10;
            }
            return digits;
        }
        #endregion
        #region EXERCISE 6
        // Nota: 4
        public static int Exercise6(int n)
        {
            if (n <= 0)
                return 0;
            return (n * n) + Exercise6(n - 1);
        }
        #endregion
        #region EXERCISE 7
        public static bool IsVocal(char c)
        {
            if(c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' ||
               c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
            {
                return true;
            }
            return false;
        }
        // Nota: 4
        public static (int, int) Exercise7(string s)
        {
            int min = int.MinValue;
            int max = int.MaxValue;
            
            for(int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (IsVocal(c))
                {
                    min = i;
                    break;
                }
            }
            for(int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];

                if (IsVocal(c))
                {
                    max = i;
                    break;
                }
            }
            return(min, max);
        }
        #endregion
        #region EXERCISE 8
        public static bool IsPrime(int n)
        {
            // Muy bien
            if (n <= 1)
                return false;

            for(int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        // Nota: 4
        public static int GetPrimePosition(int n)
        {
            if (IsPrime(n))
            {
                int counter = 0;

                for(int i = 1; i <= n; i++)
                {
                    if (IsPrime(i))
                        counter++;
                }
                return counter;
            }
            return -1;
        }
        #endregion
        #region EXERCISE 9
        public enum state { PREPARED, PROCESSING, EXECUTING, ENDED }
        public static state NextState(state s)
        {
            if (s == state.PREPARED)
                return state.PROCESSING;
            if (s == state.PROCESSING)
                return state.EXECUTING;
            if(s == state.EXECUTING)
                return state.ENDED;
            return state.PREPARED;
        }
        // Nota: 4, muy bien!!!!!!!!
        public static state Exercise9(state s, bool next)
        {
            if(next)
                return NextState(s);
            return s;
        }
        #endregion
        #region EXERCISE 10
        // Nota: 4
        public static int SumDivisors(int n)
        {
            int result = 0;

            for(int i = 1; i < n; i++)
            {
                if(n%i == 0)
                    result += i;
            }
            return result;
        }
        #endregion
        #region EXERCISE 11
        // Nota: 4
        public static double Exercise11(double a, double b, double c, double d, double e,
                                        double xMin, double xMax, double sampler)
        {
            double maxValue = double.MinValue;

            for(double i = xMin; i <= xMax; i+= (xMax-xMin) / sampler)
            {
                double n = Exercise2(a, b, c, d, e, i);
                if(n > maxValue)
                    maxValue = n;
            }
            return maxValue;
        }
        #endregion
    }
}
