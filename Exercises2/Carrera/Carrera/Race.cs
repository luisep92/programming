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
            
            list.Add(NewRacer("Pepe", RacerType.MARATHON));
            list.Add(NewRacer("Antonio", RacerType.THIEF));
            list.Add(NewRacer("Jose", RacerType.SPEEDSTER));

            return list;
        }

        public static Racer NewRacer(string name, RacerType type)
        {
            Racer r = new Racer();

            r.name = name;
            r.position = 0;
            r.type = type;

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
