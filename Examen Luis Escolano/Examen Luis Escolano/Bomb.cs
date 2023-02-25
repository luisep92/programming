using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class Bomb : Obstacle
    {
        private int _turns;
        public Bomb(int turns, double position) : base("Bomb", position)
        {
            _turns = turns;
        }

   
        public override void Simulate(IRace race)
        {
            if(_turns == 0)
            {
                foreach (RaceObject c in race.GetRacers())
                {
                    if (c.Position <= this.Position + 50)
                    {
                        c.Position += 50;
                    }
                    else if(c.Position >= this.Position - 50)
                    {
                        c.Position -= 50;
                    }
                }
            }

            _turns--;
            if (_turns <= 0)
                Enabled = false;
        }
    }
}
