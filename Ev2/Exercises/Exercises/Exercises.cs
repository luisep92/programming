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

            for (int i = 1; i <= n; i++)
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

            while (a + b <= n)
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
            for (int i = 1; i < a.Length; i += 2)
            {
                a = a.Insert(i, "-");
            }
            return a;
        }

        //Comprobar que la letra este entre 2 valores ASCII
        public static bool isBetweenChars(char a, char b, char c)
        {
            return a >= Math.Min(b, c) && a <= Math.Max(b, c);
        }
        //Devuelve el numero de caracteres (c) que tiene un texto
        public static int GetNumberOf(string text, char c)
        {
            int counter = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == c)
                    counter++;
            }
            return counter;
        }
        //Comprueba el caso de .., @., .@
        public static bool ContainsBadSyntax(string text)
        {
            return text.Contains("..") ||
                   text.Contains("@.") ||
                   text.Contains(".@");
        }
        //Comprueba caracteres especiales excepto numeros, "_", "." y "@"
        public static bool ContainsNotValidCharacters(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (!isBetweenChars(text[i], 'a', 'z') &&
                    !isBetweenChars(text[i], '0', '9') &&
                    !isBetweenChars(text[i], 'A', 'Z') &&
                     text[i] != '@' && text[i] != '.' && text[i] != '_')
                {
                    return true;
                }
            }
            return false;
        }
        //comprueba que no empiece o acabe con un caracter en concreto (c)
        public static bool StartOrEndWith(string text, char c)
        {
            return text[0] == c || text[text.Length - 1] == c;
        }

        //comprueba que despues de la @ hay un punto
        public static bool HaveDotAfterAtSign(string text)
        {
            bool gotAtSign = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '@')
                    gotAtSign = true;

                if (gotAtSign && text[i] == '.')
                    return true;
            }
            return false;
        }
        //comprueba que no es demasiado largo
        public static bool IsTooLarge(string text, int quantity)
        {
            return text.Length >= quantity;
        }
        //la vaina
        public static bool IsEmail(string mail)
        {
            if (GetNumberOf(mail, '@') != 1)
                return false;
            if (ContainsBadSyntax(mail))
                return false;
            if (ContainsNotValidCharacters(mail))
                return false;
            if (StartOrEndWith(mail, '@') || StartOrEndWith(mail, '.'))
                return false;
            if (!HaveDotAfterAtSign(mail))
                return false;
            if (IsTooLarge(mail, 80))
                return false;

            return true;
        }
        public static int SumDigits(int n)
        {
            int sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }

        //hacer una funcion que devuelva el productorio de un numero
        public static int CalculateProductory(int n)
        {
            int result = 1;

            if (n < 1)
                return 0;

            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        int[] arr = { 1, 2, 2, 2, 3, 4, 5, 5 };
        Vector3[] arr2 = new Vector3[5];
        int[,] TABLERO =    { { 1, 2, 3, 4 },
                              { 1, 2, 3, 4 },
                              { 1, 2, 3, 4 },
                              { 1, 2, 3, 4 }};
        public static int CalculateProductoryRecursive(int n)
        {
            if (n < 1)
                return 1;
            return n * CalculateProductoryRecursive(n - 1);
        }

        public static int CalculateMCD(int a, int b)
        {
            if (a <= 0 || b <= 0)
                return -1;

            for (int i = GetMinor(a, b); i > 0; i--)
            {
                if (a % i == 0 && b % i == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int GetMinor(int a, int b)
        {
            if (a <= b)
                return a;
            return b;
        }

        public static int Saturate(int n, int min, int max)
        {
            if (n < min)
                return min;
            if (max < n)
                return max;
            return n;
        }
        public static double Circular(double n, double min, double max)
        {
            double range = max - min;

            if (n > max)
                return Circular(n - range, min, max);
            if (n < min)
                return Circular(n + range, min, max);
            return n;
        }
        public static int Circular(int n, int min, int max)
        {
            int range = max - min;

            if (n > max)
                return Circular(n - range, min, max);
            if (n < min)
                return Circular(n + range, min, max);
            return n;
        }
        public static void RotateLeft(int[] arr, int displacement)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                int t1 = Circular((arr.Length - displacement + i), 0 , (arr.Length));
                int t2 = Circular(arr.Length - displacement - displacement + i, 0, arr.Length);
                int te1 = arr[t1];
                int te2 = arr[t2];

                arr[t1] = arr[i];
                arr[t2] = te1;

            }
        }
        public static double Circular2(double n, double min, double max)
        {
            double range = max - min;

            while (n < min)
            {
                n += range;
            }
            while (n > max)
            {
                n -= range;
            }
            return n;
        }

        public static double Lerp(double t, double min, double max)
        {
            return min + (max - min) * t;
        }
        public static double ULerp(double val, double min, double max)
        {
            return (val - min) / (max - min);
        }

        public static (double minor, double major) GetMinorAndMajor(double a, double b)
        {
            if (a < b)
                return (a, b);
            return (b, a);
        }
        public static double Compare(double a, double b)
        {
            if (a > b)
                return -1;
            if (a == b)
                return 0;
            return 1;
        }
        public static string ToBinary(int n)
        {
            string result = "";
            while (n > 0)
            {
                result = (n % 2) + result;
                n /= 2;
            }
            return result;
        }
        public static char ToMayus(char c)
        {
            string s = c.ToString();
            s = s.ToUpper();
            return s[0];
        }
        public static double GetAverage(double a, double b)
        {
            return (a + b) * 0.5;
        }
        public static string ToMorse(string s)
        {
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a' || s[i] == 'A')
                    result += "·-";
                else if (s[i] == 'b' || s[i] == 'B')
                    result += "-···";
                else if (s[i] == 'c' || s[i] == 'C')
                    result += "-·-·";
            }
            return result;
        }
        public static void PrintMuntiplyTable(int n)
        {
            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine(n + " x " + i + " = " + n * i);
            }
        }
        public static string JaviAlgorythm(int n)
        {
            string result = "";
            int num = -1;

            for (int i = 0; i < n; i++)
            {
                result += num;
                num *= -2;

                if (i != n - 1)
                    result += ",";
            }
            return result;
        }
        public static double SumPrimesBetween(int a, int b)
        {
            int result = 0;

            for (int i = a; i <= b; i++)
            {
                if (isPrime(i))
                {
                    result += i;
                }
            }
            return result;
        }
        public static string DiscomposePrimeMults(int n)
        {
            string result = "";

            for (int i = 2; i <= n; i++)
            {
                if (n % i == 0)
                {
                    result += i + "·";
                    n /= i;
                    i = 1;
                }
            }
            return result;
        }

        public static string CollatzSequence(int n)
        {
            string result = "";
            while (n != 1)
            {
                result += n + ",";
                if (isEven(n))
                    n /= 2;
                else
                    n = n * 3 + 1;
            }
            return result + "1";
        }
        public static (int num, int denom) SimplifyFraction(int n, int d)
        {
            int max = GetMinor(n, d) / 2;
            for (int i = 2; i <= max; i++)
            {
                if (n % i == 0 && d % i == 0)
                {
                    n /= i;
                    d /= i;
                    i--;
                }
            }
            return (n, d);
        }

        /*try{
        codigo potencialmente petable
       }
        catch
        {
            codigo a ejecutar si peta
        ejemplo
            Console.Writeline("NO VA" + e.Message);
            return;
        }
        finally
        {
            codigo que se ejecuta si o si
        }

         */
    }
}
