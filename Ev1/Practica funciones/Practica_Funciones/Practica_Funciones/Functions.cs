using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Funciones
{
    internal class Functions
    {
        #region EJERCICIO 1
        public enum Jugada { PIEDRA, PAPEL, TIJERA, LAGARTO, SPOCK }

        public static int PPTLS(Jugada player1, Jugada player2)
        {
            if (player1 == player2)
                return 0;
            if (player1 == Jugada.PIEDRA)
            {
                if (player2 == Jugada.TIJERA || player2 == Jugada.LAGARTO)
                    return 1;
            }
            if (player1 == Jugada.PAPEL)
            {
                if (player2 == Jugada.PIEDRA || player2 == Jugada.SPOCK)
                    return 1;
            }
            if (player1 == Jugada.TIJERA)
            {
                if (player2 == Jugada.PAPEL || player2 == Jugada.LAGARTO)
                    return 1;
            }
            if (player1 == Jugada.SPOCK)
            {
                if (player2 == Jugada.TIJERA || player2 == Jugada.PIEDRA)
                    return 1;
            }
            if (player1 == Jugada.LAGARTO)
            {
                if (player2 == Jugada.PAPEL || player2 == Jugada.SPOCK)
                    return 1;
            }

            return -1;
        }
        #endregion
        #region EJERCICIO 2
        public static double Equation(int a, int result) //a + x = result
        {
            return result - a;
        }
        #endregion
        #region EJERCICIO 3
        public static (double positive, double negative) Equation2(double a, double b, double c)
        {
            double resultPos = 0, resultNeg = 0;
            if (a == 0)
                return (double.NaN, double.NaN);
            double root = (b * b) - (4 * a * c);
            if (root < 0)
                return (double.NaN, double.NaN);

            resultPos = (-b + Math.Sqrt(root)) / (2 * a);
            resultNeg = (-b - Math.Sqrt(root)) / (2 * a);

            return (resultPos, resultNeg);
        }
        #endregion
        #region EJERCICIO 4
        public enum Triangulo { EQUILATERO, ISOSCELES, ESCALENO, INVALIDO }
        public static Triangulo IsValidTriangle(float side1, float side2, float side3)
        {
            if (side1 < side2 + side3 || side2 < side1 + side3 || side3 < side2 + side1)
                return Triangulo.INVALIDO;

            if (side1 == side2 && side2 == side3)
                return Triangulo.EQUILATERO;
            if (side1 == side2 || side2 == side3 || side1 == side3)
                return Triangulo.ISOSCELES;
            else
                return Triangulo.ESCALENO;
        }
        #endregion
        #region EJERCICIO 5
        public static int MCD(int a, int b)
        {
            for (int i = GetMinor(a, b); i > 1; i--)
            {
                if (a % i == 0 && b % i == 0)
                    return i;
            }
            return 1;
        }
        public static int GetMajor(int a, int b)
        {
            if (a < b)
                return b;
            return a;
        }
        public static int GetMinor(int a, int b)
        {
            if (a < b)
                return a;
            return b;
        }
        #endregion
        #region EJERCICIO 6
        public static int MCM(int a, int b)
        {
            for (int i = 2; i <= a * b; i++)
            {
                if (i % a == 0 && i % b == 0) 
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
        #region EJERCICIO 7
        public static string Exercise7(int n)
        {
            string result = "1";
            if (n <= 1)
                return result;
            for(int i = 2; i <= n; i++)
            {
                if(i % 3 != 0 && i % 7 != 0)
                {
                    result += ", " + i;
                }
            }
            return result;
        }
        #endregion
        #region EJERCICIO 8
        public static string DiceCombinations()
        {
            string result = "(1,1,1)";
            int dice1 = 1, dice2 = 1, dice3 = 1;
            for(int i = 0; dice1 < 7; i++)
            {
                
                dice3++;
                if (dice3 == 7)
                {
                    dice3 = 1;
                    dice2++;
                    result += "\n";
                }
                if (dice2 == 7)
                {
                    dice2 = 1;
                    dice1++;
                    result += "\n";
                }

                if(dice1 != 7)
                    result += "\n (" + dice1 + "," + dice2 + "," + dice3 + ")";
            }
            return result;
        }
        #endregion
        #region EJERCICIO 9
        public static string SeparateNumber(int n)
        {
            string aux = "" + n;
            string result = "";
            for (int i = 0; i < aux.Length; i++)
            {
                result += aux[i];
                if (i != aux.Length - 1)
                    result += "-";
            }
            return result;
        }
        #endregion
        public static string CubeSum100()
        {
            int a = -2000;
            int b = -2000;
            int c = -2000;

            (int, int, int) result1 = (0,0,0), result2 = (0,0,0), result3 = (0, 0, 0);

            
            string result = "";
            while(c < 2000)
            {
                if(a*a*a + b*b*b + c*c*c == 100)
                {
                    (int,int,int) ordered = OrderResults(a, b, c);
                    if(ordered != result1 && ordered != result2 && ordered != result3)
                    {
                        if (result1 == (0, 0, 0))
                        {
                            result1 = ordered;
                            result += result1;
                        }
                        else if (result2 == (0, 0, 0))
                        {
                            result2 = ordered;
                            result += result2;
                        }
                        else
                        {
                            result3 = ordered;
                            result += result3;
                        }                    
                    }
                    Console.WriteLine(result);
                }
                if (a < 2000)
                    a++;
                else
                {
                    a = -2000;
                    b++;
                }
                if(b >= 2000)
                {
                    b = -2000;
                    c++;
                }
            }
            return result;
        }
        public static (int,int,int) OrderResults(int a, int b, int c)
        {
            int aa = GetMinor(a, b, c);
            int bb = GetMiddle(a, b, c);
            int cc = GetMajor(a, b, c);
            return (aa, bb, cc);
        }
        public static int GetMinor(int a, int b, int c)
        {
            if (GetMinor(a, b) > c)
                return c;
            return GetMinor(a, b);
        }
        public static int GetMajor(int a, int b, int c)
        {
            if (GetMajor(a, b) < c)
                return c;
            return GetMajor(a, b);
        }
        public static int GetMiddle(int a, int b, int c)
        {
            if (a < b && a > c || a < c && a > c)
                return a;
            if (b < c && b > a || b < a && b > c)
                return b;
            if (c < a && c > b || c < b && c > a)
                return c;
            if (a == b && b < c)
                return b;
            if (a == c && c < b)
                return c;
            if (b == c && c < a)
                return c;
            return a;
        }

        public static string QuitaArroba(string s,bool delante, bool atras)
        {
            string resu = "";
            int min = 0;
            int max = s.Length - 1;
            if (delante)
            {
                for(int i = 0; i < max; i++)
                {
                    if (s[i] != '@')
                        break;
                    min++;
                }
            }
            if(atras)
            {
                for(int i = max; i > min; i--)
                {
                    if (s[i] != '@')
                        break;
                    max--;
                }
            }
            for(int i = min; i <= max; i++)
            {
                if (s[i] != '@')
                    resu += s[i];
            }
            return resu;

        }
    }
}
