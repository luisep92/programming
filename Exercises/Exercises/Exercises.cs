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

        //Comprobar que la letra este entre 2 valores ASCII
        public static bool isBetweenChars(char a, char b, char c)
        {
            return a >= Math.Min(b, c) && a <= Math.Max(b, c);
        }
        //Devuelve el numero de caracteres (c) que tiene un texto
        public static int GetNumberOf(string text, char c)
        {
            int counter = 0;

            for(int i = 0; i < text.Length; i++)
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
            for(int i = 0; i < text.Length; i++)
            {
                if (!isBetweenChars(text[i],'a', 'z') && 
                    !isBetweenChars(text[i],'0','9') &&
                    !isBetweenChars(text[i],'A','Z') &&
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

            for(int i = 0; i < text.Length; i++)
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

            while(n > 9)
            {
                sum += n % 10;
                n /= 10;
            }
            sum += n;

            return sum;
        }
    }
}
