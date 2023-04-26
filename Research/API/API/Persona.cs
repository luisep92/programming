using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public struct Persona
    {
    }

    public static class Utils
    {
        public static void HacerAlgo<T>(this T p) where T : struct
        {
            Console.WriteLine("Hago algo");
        }

        
    }
}
