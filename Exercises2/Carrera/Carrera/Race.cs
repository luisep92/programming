using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera
{
    internal class Race
    {
        public static List<Racer> generateRacers()
        {
            List<Racer> list = new List<Racer> ();

            
            list.Add(NewRacer("Pepe"));
            list.Add(NewRacer("Antonio"));
            list.Add(NewRacer("Jose"));

            return list;
        }

        public static Racer NewRacer(string name)
        {
            Racer r = new Racer();
            r.name = name;
            r.position = 0;
            return r;
        }
        public static Racer CheckWinner(List<Racer> list)
        {
            foreach (Racer r in list)
            {
                if (r.position >= 1000)
                    return r;
            }
            return null;
        }
        public static void MoveRacers(List<Racer> list)
        {
            foreach(Racer r in list)
            {
                r.Move();
            }
        }
    }
}
