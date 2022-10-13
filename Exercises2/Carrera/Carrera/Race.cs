using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera
{
    internal class Race
    {
        public static List<Racer> generateRacers(int n)
        {
            List<Racer> list = new List<Racer> ();
            
           // n Racer racer1


            return list;
        }



        public static int RandomNegativeOrPositive()
        {
            Random r = new Random();

            if (r.Next(0, 1) == 0)
                return -1;
            return 1;
        }
    }
}
