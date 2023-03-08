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
            
            list.Add(Racer.NewRacer("Pepe", RacerType.MARATHON));
            list.Add(Racer.NewRacer("Antonio", RacerType.THIEF));
            list.Add(Racer.NewRacer("Jose", RacerType.SPEEDSTER));

            return list;
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
