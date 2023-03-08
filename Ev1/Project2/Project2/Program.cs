using System.Diagnostics;

namespace Project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Tests.GetNumbers2(4));
        }
        static void MinorExample()
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int res = Tests.GetMinor(a, b);

            Console.WriteLine("El menor entre " + a + " y " + b + " es: " + res);
        }
        static void MajorExample()
        {
            double c = Convert.ToDouble(Console.ReadLine());
            double d = Convert.ToDouble(Console.ReadLine());
            double resu = Tests.GetMajor(c, d);

            Console.WriteLine("El mayor entre " + c + " y " + d + " es: " + resu);
        }
        static void MinorExample2()
        {
            int e, f, g;

            e = 3 + 5;
            f = e * 2 + 3;
            g = f * f;
            g = g + 2;
            e = Tests.GetMinor(e, f);
            e = Tests.GetMinor(e + 1, Tests.GetMinor(f, g));

            Console.WriteLine("\n e = " + e);
            Console.WriteLine("f = " + f);
            Console.WriteLine("g = " + g);
        }
        static void EquationExample()
        {
            double g = Convert.ToDouble(Console.ReadLine()); ;
            double h;

            while (g != 0)
            {
                h = Convert.ToDouble(Console.ReadLine());
                double x = Tests.SolveEquation(g, h);

                Console.WriteLine("La solucion con a = " + g + " y b = " + h + " es: " + x);

                g = Convert.ToDouble(Console.ReadLine());
            }
        }
        static void Equation2Example()
        {
            double i = Convert.ToDouble(Console.ReadLine()); ;
            double j;
            double k;

            while (i != 0)
            {
                j = Convert.ToDouble(Console.ReadLine());
                k = Convert.ToDouble(Console.ReadLine());
                bool usePositiveSol = Convert.ToBoolean(Console.ReadLine());
                double x = Tests.SolveEquation2(i, j, k, usePositiveSol);

                Console.WriteLine("La solucion con a = " + i + ", b = " + j + " y c = " + k + " es: " + x);

                i = Convert.ToDouble(Console.ReadLine());
            }
        }
        static void Equation3Example()
        {
            double l = Convert.ToDouble(Console.ReadLine()); ;
            double m;
            double n;

            while (l != 0)
            {
                m = Convert.ToDouble(Console.ReadLine());
                n = Convert.ToDouble(Console.ReadLine());                
                var x = Tests.SolveEquation3(l, m, n);

                Console.WriteLine("Las soluciones con a = " + l + ", b = " + m + " y c = " + n + " son: " + x.solution1 + " y " + x.solution2);

                l = Convert.ToDouble(Console.ReadLine());
            }
        }
        static void Equation4Example()
        {
            double o = Convert.ToDouble(Console.ReadLine());
            double p;
            double q;

            while (o != 0)
            {
                p = Convert.ToDouble(Console.ReadLine());
                q = Convert.ToDouble(Console.ReadLine());
                EquationSolution x = Tests.SolveEquation4(o, p, q);

                Console.WriteLine("Las soluciones con a = " + o + ", b = " + p + " y c = " + q + " son: " + x.result1 + " y " + x.result2);

                o = Convert.ToDouble(Console.ReadLine());
            }
        }
    }
}