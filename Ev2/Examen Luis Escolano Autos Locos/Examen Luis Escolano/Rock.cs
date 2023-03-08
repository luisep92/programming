using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class Rock : Obstacle
    {
        private double _weight;


        public Rock(double position) : base("Piedra", position)
        {
            _weight = Utils.RandomRange(10, 30);
        }
        

        public override void Simulate(IRace race)
        {
            foreach(RaceObject c in race.GetRacers())
            {
                if(c.Position <= this.Position + 10 && c.Position >= this.Position - 10)
                {
                    if(Utils.Probability(10 + _weight))
                    {
                        c.Position -= 25;
                    }
                }
            }
        }
    }
}
