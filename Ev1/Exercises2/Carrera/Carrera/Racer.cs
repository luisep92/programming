using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera
{
    public enum RacerType { MARATHON, THIEF, SPEEDSTER}
    internal class Racer
    {
        public string name;
        public double position;
        public RacerType type;

        public void Move()
        {
            switch (type)
            {
                case RacerType.MARATHON:
                    position += 10 + Utils.RandomRange(-3, 3.5f);
                    break;
                case RacerType.THIEF: 
                    position += 10.4f;
                    break;
                case RacerType.SPEEDSTER:
                    position += Utils.RandomRange(5, 15.5f);
                    break;
                default:
                    Console.WriteLine("ERROR CON EL TIPO DEL CORREDOR " + this.name);
                    break;
            }
        }
        public static Racer NewRacer(string name, RacerType type)
        {
            Racer r = new Racer();

            r.name = name;
            r.position = 0;
            r.type = type;

            return r;
        }
    }
}
