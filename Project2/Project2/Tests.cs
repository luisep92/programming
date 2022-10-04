using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class Tests
    {
        public static int GetMinor(int a, int b)
        {
            if (a < b)
                return a;
            else
                return b;
        }
        public static double GetMajor (double a, double b)
        {
            if (a < b)
                return b;
            else
                return a;
        }
        public static double SolveEquation(double a, double b)
        {
            if (a == 0)
                return double.NaN;
            else
                return (-b) / a;
        }
        public static double SolveEquation2(double a, double b, double c, bool usePositiveSolution)
        {
            double root = Math.Sqrt(b * b - 4 * a * c);
            double dividend;

            if (a == 0 || root == double.NaN)
                return double.NaN;

            if (usePositiveSolution)
                dividend = -b + root;
            else 
                dividend = -b - root;

            return dividend / (2 * a);
        }
        public static (double solution1, double solution2) SolveEquation3(double a, double b, double c)
        {
            double root = Math.Sqrt(b * b - 4 * a * c);

            if (a == 0 || root == double.NaN)
                return (double.NaN, double.NaN);

            return ((-b + root) / (2 * a), (-b - root) / 2 * a);
        }
        public static EquationSolution SolveEquation4(double a, double b, double c)
        {
            double root = Math.Sqrt(b * b - 4 * a * c);

            if (a == 0 || root == double.NaN)
                return null;

            EquationSolution solution = new EquationSolution();

            solution.result1 = (-b + root) / (2 * a);
            solution.result2 = (-b - root) / (2 * a);

            return solution;
        }
        public static double GetMultiplication(int a, int b)
        {
            return a * b;
        }
        public static int GetRest(int a, int b)
        {
            return a % b;
        }
        public static bool IsEven(int a)
        {
            return (a % 2) == 0;
        }
        public static double GetImc(double weight, double height)
        {
            if (height <= 0)
                return double.NaN;
            return weight / (height * height);
        }
        public static int GetSummation(int number)
        {
            if (number < 0)
                return -1;
            int result = 0;
            int i = 0;

            while(i <= number)
            {
                result += i;
                i++;
            }
            return result;
        }
        public static int GetSummation2(int number)
        {
            if (number < 0)
                return -1;

            int result = 0;

            for(int i = 0; i <= number; i++)
            {
                result += i;
            }
            return result;
        }
        public static string ConcatenateString(string text1, string text2)
        {
            return text1 + ", " + text2;
        }
        public static string GetNumbers(int number)
        {
            string result = "";

            for(int i = 1; i <= number; i++)
            {
                result += i + ",";
            }
            return result;
        }

        public static string GetNumbers2(int number)
        {
            int multiplier = 1;
            string result = "";

            for(int i = 0; i <= number; i+=2, multiplier *= -1)
            {
                result += (i * multiplier);

                if(i < number - 1)
                        result += ",";
            }
            return result;
        }
    }
}
