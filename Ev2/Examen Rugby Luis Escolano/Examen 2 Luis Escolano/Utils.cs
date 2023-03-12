using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_2_Luis_Escolano
{
    public delegate int Comparer<T>(T a, T b); //1 == a > b, -1 == b > a, 0 =
    public class Utils
    {
        private static Random r = new();

        public static double RandomRange(double min, double max)
        {
            if(min > max)
                return RandomRange(max, min);
            return r.NextDouble() * (max - min) + min;
        }

        public static int RandomRangeInt(int min, int max)
        {
            int r = (int)RandomRange(min, max);
            return r;
        }

        public static Vector2 AnyDirection(Vector2 p, int n, int distance)
        {
            switch (n)
            {
                case 0:
                    return new Vector2(p.x, p.y + distance);
                case 1:
                    return new Vector2(p.x, p.y - distance);
                case 2:
                    return new Vector2(p.x + distance, p.y);
                case 3:
                    return new Vector2(p.x - distance, p.y);
                case 4:
                    return new Vector2(p.x + distance, p.y + distance);
                case 5:
                    return new Vector2(p.x + distance, p.y - distance);
                case 6:
                    return new Vector2(p.x - distance, p.y + distance);
                default:
                    return new Vector2(p.x - distance, p.y - distance);
            }
        }

        static string[] names =
        {
            "Ojazos",
            "Papi",
            "Papito",
            "Ricura",
            "Caramelito",
            "Pastelito",
            "Cuerpazo",
            "Sr. Sexy",
            "Playboy",
            "Hoyuelos",
            "Ricitos",
            "Moreno",
            "Rubiales",
            "Perla",
            "Flaquito",
            "Bombon",
            "Hermoso",
            "Bonito",
            "Adonis",
            "Caraguapa",
            "Chati",
            "Chulo",
            "Boquita",
            "Guapo",
            "Fortachon",
            "Musculitos",
            "Pibon"
        };
        static string[] surnames =
        {
            "torpe",
            "culto",
            "bruto",
            "audaz",
            "rugoso",
            "suave",
            "salado",
            "sensible",
            "timido",
            "contento",
            "moreno",
            "dinamico",
            "agil",
            "tierno",
            "docil",
            "luchador",
            "malvado",
            "cobarde",
            "brillante",
            "tenebroso",
            "oscuro",
            "decadente",
            "moderno",
            "innovador",
            "desagradable",
            "divertido",
            "joven",
            "anciano",
            "disciplinado",
            "rubio",
            "directo"
        };

        public static string RandomName()
        {
            int name = RandomRangeInt(0, names.Length - 1);
            int surname = RandomRangeInt(0, surnames.Length - 1);

            return names[name] + " " + surnames[surname];
        }
  

        public static void SoryByY(List<Vector2> list)
        {
            list.Sort((a, b) =>
            {
                if (a.y > b.y) return 1;
                if (a.y < b.y) return -1;
                return 0;
            });
        }

        public static bool Probability(double chance)
        {
            if (RandomRange(0, 100) < chance)
                return true;
            return false;
        }
    }
}
