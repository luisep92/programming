using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class Charco : Obstacle
    {
        public Charco(double position) : base("Charco", position)
        {

        }


        public override void Simulate(IRace race)
        {
            foreach(RaceObject r in race.GetRacers())
            {
                if (r.Position < this.Position + 20 || r.Position > this.Position - 20)
                {
                    DisableObject(r);
                }
            }
        }

        void DisableObject(RaceObject r)
        {
            if (Utils.Probability(20))
            {
                int turns = (int)Utils.RandomRange(1.0, 4.0);
                r.Disable(turns);
            }
        }
    }
}
